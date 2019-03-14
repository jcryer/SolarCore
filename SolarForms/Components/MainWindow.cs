using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using SolarForms.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SolarForms.Components
{
    public class MainWindow : GameWindow
    {
        private int _program;
        public Simulation Simulation;
        private Matrix4 _projectionMatrix;
        private List<LineObject> LineObjects = new List<LineObject>();

        public MainWindow(Simulation simulation) : base(1000, // initial width
        1000, // initial height
        GraphicsMode.Default, "SolarCore",  // initial title
        GameWindowFlags.Default,
        DisplayDevice.Default,
        4, // OpenGL major version
        0, // OpenGL minor version
        GraphicsContextFlags.ForwardCompatible)
        {
            Simulation = simulation;
        }

        public bool LocalIsDisposed
        {
            get { return IsDisposed; }
        }


        protected override void OnResize(EventArgs e)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Viewport(0, 0, Width, Height);

            CreateProjection();
        }

        protected override void OnLoad(EventArgs e)
        {
            Simulation.OldMouseState = Mouse.GetState();
            Simulation.OldKeyState = Keyboard.GetState();
            VSync = VSyncMode.Off;
            CreateProjection();
            foreach (var x in Simulation.PlanetarySystem.Objects)
            {
                x.Obj = new RenderObject(new Sphere().CreateSphere(3, x.ObjectColour));
                x.InitialPosition = x.Position;
                x.InitialVelocity = x.Velocity;
            }
            Simulation.Run(300, false, 0);
            CursorVisible = true;

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
            RenderFrame += (sender, f) => OnRenderFrame(f);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var deleteList = new List<LineObject>();
            foreach (var obj in LineObjects)
            {
                if (obj.DeleteBy < 0)
                {
                    deleteList.Add(obj);
                }
            }
            foreach (var obj in deleteList)
            {
                obj.Object.Dispose();
                LineObjects.Remove(obj);
            }


            bool newObjects = false;
            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                if (obj.Obj == null)
                {
                    obj.InitialPosition = obj.Position;
                    obj.InitialVelocity = obj.Velocity;
                    newObjects = true;
                    break;
                }
            }

            if (newObjects || Simulation.Changed)
            {
                foreach (var obj in Simulation.PlanetarySystem.Objects)
                {
                    obj.Obj = new RenderObject(new Sphere().CreateSphere(3, obj.ObjectColour));
                    LineObjects.ForEach(x => x.Object.Dispose());
                    LineObjects.Clear();
                    obj.Positions.Clear();
                    obj.Velocities.Clear();
                }
                if (!Simulation.PlanetarySystem.Objects.Any())
                    return;
                if (Simulation.Speed < 0)
                {
                    Simulation.Run(300, true, Simulation.CurrentFrame);
                    Simulation.CurrentFrame = Simulation.MaximumSpeed-1;
                }
                else
                {
                    Simulation.Run(300, false, Simulation.CurrentFrame);
                    Simulation.CurrentFrame = 0;
                }
                Simulation.Changed = false;
            }
            if (!Simulation.PlanetarySystem.Objects.Any())
                return;
            HandleKeyboard();

        }

        private void HandleKeyboard()
        {
            var mouseState = Mouse.GetState();
            var keyState = Keyboard.GetState();

            if (Focused)
            {
                if (Simulation.OldMouseState.Scroll.Y != mouseState.Scroll.Y)
                {
                    Simulation.Camera.Zoom -= Simulation.Camera.ZoomModifier * (mouseState.Scroll.Y - Simulation.OldMouseState.Scroll.Y);
                }

                if (mouseState.IsButtonDown(MouseButton.Left))
                {
                    if (Simulation.OldMouseState.IsButtonDown(MouseButton.Left) == true)
                    {
                        Simulation.Camera.XVal += 0.01f * (mouseState.X - Simulation.OldMouseState.X);
                        Simulation.Camera.YVal += 0.01f * (Simulation.OldMouseState.Y - mouseState.Y);
                    }
                }

                if (keyState.IsKeyDown(Key.Escape))
                {
                    Exit();
                }
                if (keyState.IsKeyDown(Key.Left))
                {
                    Simulation.Speed = Simulation.Speed <= -Simulation.MaximumSpeed ? -Simulation.MaximumSpeed : Simulation.Speed - 1;
                }
                if (keyState.IsKeyDown(Key.Right))
                {
                    Simulation.Speed = Simulation.Speed >= Simulation.MaximumSpeed ? Simulation.MaximumSpeed : Simulation.Speed + 1;
                }
                if (keyState.IsKeyDown(Key.S))
                {
                    Simulation.Camera.XVal += 0.01;
                }
                if (keyState.IsKeyDown(Key.W))
                {
                    Simulation.Camera.XVal -= 0.01;
                }
                if (keyState.IsKeyDown(Key.A))
                {
                    Simulation.Camera.YVal += 0.01;
                }
                if (keyState.IsKeyDown(Key.D))
                {
                    Simulation.Camera.YVal -= 0.01;
                }
                if (keyState.IsKeyDown(Key.R))
                {
                    ResetSim();
                }
                if (keyState.IsKeyDown(Key.Comma))
                {
                    if (!Simulation.OldKeyState.IsKeyDown(Key.Comma))
                    {
                        Simulation.Camera.Focus -= 1;
                        if (Simulation.Camera.Focus < 0)
                            Simulation.Camera.Focus = 0;
                    }
                }

                if (keyState.IsKeyDown(Key.Period))
                {
                    if (!Simulation.OldKeyState.IsKeyDown(Key.Period))
                    {
                        Simulation.Camera.Focus += 1;
                        if (Simulation.Camera.Focus >= Simulation.PlanetarySystem.Objects.Count)
                            Simulation.Camera.Focus -= 1;
                    }
                }

                if (keyState.IsKeyDown(Key.Space))
                {
                    if (!Simulation.OldKeyState.IsKeyDown(Key.Space))
                    {
                        Simulation.Paused = !Simulation.Paused;
                    }
                }

                if (Simulation.Camera.YVal > 0.49) Simulation.Camera.YVal = 0.49;
                if (Simulation.Camera.YVal < -0.49) Simulation.Camera.YVal = -0.49;

                if (Simulation.Camera.Zoom < 10000) Simulation.Camera.Zoom = 10000;
                if (Simulation.Camera.Zoom > 10000000) Simulation.Camera.Zoom = 10000000;

                var pi180 = Math.PI;
                Vector3 initialPosition;
                if (!Simulation.Camera.Fixed)
                    initialPosition = Simulation.PlanetarySystem.Objects[Simulation.Camera.Focus].RenderPosition;
                else
                    initialPosition = new Vector3(0, 0, 0);
                Simulation.Camera.Position.X = initialPosition.X + (float)Simulation.Camera.Zoom * (float)(Math.Sin(Simulation.Camera.XVal * pi180) * Math.Cos(Simulation.Camera.YVal * pi180));
                Simulation.Camera.Position.Y = initialPosition.Y + (float)Simulation.Camera.Zoom * (float)(Math.Sin(Simulation.Camera.YVal * pi180));
                Simulation.Camera.Position.Z = initialPosition.Z + (float)Simulation.Camera.Zoom * -(float)(Math.Cos(Simulation.Camera.XVal * pi180) * Math.Cos(Simulation.Camera.YVal * pi180));

                Simulation.OldKeyState = keyState;
                Simulation.OldMouseState = mouseState;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (!Simulation.PlanetarySystem.Objects.Any())
                return;

            Title = $"SolarCore: {Simulation.PlanetarySystem.Name}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (!Simulation.Camera.Fixed)
            {
                if (Simulation.PlanetarySystem.Objects.Any())
                Simulation.Camera.LookAt = Simulation.PlanetarySystem.Objects[Simulation.Camera.Focus].RenderPosition;
            }
            var matrixStuff = Matrix4.LookAt(Simulation.Camera.Position, Simulation.Camera.LookAt, Vector3.UnitY);

            while (true) {
                if (Simulation.CurrentFrame >= Simulation.PlanetarySystem.Objects.First().Positions.Count)
                {
                    Simulation.Run(300, false, Simulation.PlanetarySystem.Objects.First().Positions.Count - 1);
                }
                else if (Simulation.CurrentFrame < 0)
                {
                    Simulation.Run(300, true, Simulation.CurrentFrame);
                }
                else
                {
                    break;
                }
            }

            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                if (!Simulation.Paused)
                {
                    obj.RenderPosition = obj.Positions[Simulation.CurrentFrame] / Simulation.Scale;
                    if (obj.TrailsActive)
                    {
                        LineObjects.Add(new LineObject(obj.RenderPosition, obj.TrailColour, obj.TrailLength, obj.Radius / (Simulation.TrailScale * 10)));
                    }
                }
                obj.Render(matrixStuff, Simulation.TrailScale);
            }
            
            for (int i = 0; i < LineObjects.Count; i++)
            {
                if (!Simulation.Paused)
                {
                    LineObjects[i].DeleteBy -= Math.Abs(Simulation.Speed);
                }
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                LineObjects[i].Render(matrixStuff);
            }
            
            GL.PointSize(10);
            SwapBuffers();

            if (!Simulation.Paused)
            {
                Simulation.CurrentFrame += Simulation.Speed;
                if (Simulation.CurrentFrame < 0) Simulation.CurrentFrame = 0;
            }
        }

        public void ResetSim()
        {
            LineObjects.ForEach(x => x.Object.Dispose());
            LineObjects.Clear();

            Simulation.CurrentFrame = 0;
            Simulation.Paused = false;
        }

        private void CreateProjection()
        {
            var aspectRatio = (float)Width / Height;
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                60 * ((float)Math.PI / 180f), // field of view angle, in radians
                aspectRatio,                // current window aspect ratio
                0.1f,                       // near plane
                4000000000000000f);                     // far plane
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit called");
            foreach (var obj in Simulation.PlanetarySystem.Objects)
                obj.Obj.Dispose();
            foreach (var obj in LineObjects.Select(x => x.Object))
                obj.Dispose();
            GL.DeleteProgram(_program);
            Dispose();
        }

        private int CompileShader(ShaderType type, string path)
        {
            var shader = GL.CreateShader(type);
            var src = File.ReadAllText(path);
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            var info = GL.GetShaderInfoLog(shader);
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLine($"GL.CompileShader [{type}] had info log: {info}");
            return shader;
        }

        private int CreateProgram()
        {
            var program = GL.CreateProgram();
            var shaders = new List<int>();
            shaders.Add(CompileShader(ShaderType.VertexShader, @"Components\Shaders\vertexShader.c"));
            shaders.Add(CompileShader(ShaderType.FragmentShader, @"Components\Shaders\fragmentShader.c"));

            foreach (var shader in shaders)
                GL.AttachShader(program, shader);
            GL.LinkProgram(program);
            var info = GL.GetProgramInfoLog(program);
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLine($"GL.LinkProgram had info log: {info}");

            foreach (var shader in shaders)
            {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }
            return program;
        }
    }
}
