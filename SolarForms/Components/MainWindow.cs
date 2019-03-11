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
using System.Threading;

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
            Simulation.Run(10000);
            CursorVisible = true;
            
            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
            RenderFrame += (sender, f) => OnRenderFrame(f);

          //  Thread t = new Thread(() => test());
          //  t.Start();
        }

        private void test()
        {
            /*
            while (true)
            {
                if (Simulation.CurrentFrame + 1000 > Simulation.PlanetarySystem.Objects.First().Positions.Count && !Simulation.SimObject.PreRenderComplete)
                {
                    Console.WriteLine("Re-rendering!");
                    Simulation.SimObject.Run(1000, true);
                }
            }*/
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
                    Simulation.Speed = Simulation.Speed <= -50 ? -50 : Simulation.Speed - 1;
                }
                if (keyState.IsKeyDown(Key.Right))
                {
                    Simulation.Speed = Simulation.Speed >= 50 ? 50 : Simulation.Speed + 1;
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

                if (Simulation.Camera.YVal > 0.49) Simulation.Camera.YVal = 0.49999;
                if (Simulation.Camera.YVal < -0.49) Simulation.Camera.YVal = -0.49999;

                if (Simulation.Camera.Zoom < 10000) Simulation.Camera.Zoom = 10000;
                if (Simulation.Camera.Zoom > 10000000) Simulation.Camera.Zoom = 10000000;

                var pi180 = (Math.PI);

                var initialPosition = Simulation.PlanetarySystem.Objects[Simulation.Camera.Focus].Position;
                Simulation.Camera.Position.X = initialPosition.X + (float)Simulation.Camera.Zoom * (float)(Math.Sin(Simulation.Camera.XVal * pi180) * Math.Cos(Simulation.Camera.YVal * pi180));
                Simulation.Camera.Position.Y = initialPosition.Y + (float)Simulation.Camera.Zoom * (float)(Math.Sin(Simulation.Camera.YVal * pi180));
                Simulation.Camera.Position.Z = initialPosition.Z + (float)Simulation.Camera.Zoom * -(float)(Math.Cos(Simulation.Camera.XVal * pi180) * Math.Cos(Simulation.Camera.YVal * pi180));

                Simulation.OldKeyState = keyState;
                Simulation.OldMouseState = mouseState;
            }
        }

        public void ResetSim()
        {
            LineObjects.ForEach(x => x.Object.Dispose());
            LineObjects.Clear();
            Simulation.CurrentFrame = 0;
            Simulation.Speed = 1;
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
            base.Exit();
        }

        DateTime endTime = DateTime.Now;
        double secondsElapsed = 0;
        protected override void OnRenderFrame(FrameEventArgs e)
        {
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
                    obj.Position = obj.InitialPosition;
                    obj.Velocity = obj.InitialVelocity;
                    obj.Positions.Clear();
                }
                ResetSim();
                Simulation.Run(10000);
                foreach (var obj in Simulation.PlanetarySystem.Objects)
                {
                    obj.Position = obj.Positions.First();
                }
                Simulation.Changed = false;
            }
            /*
            if (Simulation.PlanetarySystem.PreRenderedObjects != null)
            {
                if (Simulation.PlanetarySystem.PreRenderedObjects.Count > 0 && Simulation.SimObject.PreRenderComplete)
                {
                    Simulation.SimObject.Objects.AddRange(Simulation.SimObject.PreRenderedObjects);
                    Simulation.SimObject.PreRenderedObjects.Clear();
                    Simulation.SimObject.PreRenderComplete = false;
                }
            }
            */

            if (!Simulation.Camera.Fixed)
            {
                Simulation.Camera.LookAt = Simulation.PlanetarySystem.Objects[Simulation.Camera.Focus].Position / Simulation.Scale;
            }
            var matrixStuff = Matrix4.LookAt(Simulation.Camera.Position, Simulation.Camera.LookAt, Vector3.UnitY);
            if (!Simulation.Paused)
                Simulation.CurrentFrame += Simulation.Speed;

            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (Simulation.CurrentFrame >= Simulation.PlanetarySystem.Objects.First().Positions.Count)
            {
                if (secondsElapsed == 0)
                    secondsElapsed = (DateTime.Now - endTime).TotalSeconds;
                Console.WriteLine("Reached end of simulation: " + secondsElapsed);
                Simulation.Run(10000);
               // Simulation.CurrentFrame = Simulation.PlanetarySystem.Objects.First().Positions.Count - 1;
            }
            if (Simulation.CurrentFrame < 0)
            {
                Console.WriteLine("Beginning of simulation");
                Simulation.CurrentFrame = 0;
            }

            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                if (!Simulation.Paused)
                {
                    if (obj.TrailsActive)
                    {
                        obj.Position = obj.Positions[Simulation.CurrentFrame];
                        LineObjects.Add(new LineObject(obj.Position, obj.TrailColour,  obj.TrailLength, obj.Radius / Simulation.TrailScale));
                    }
                }
                obj.Render(matrixStuff, Simulation.TrailScale, Simulation.Scale);
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
