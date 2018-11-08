using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
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
        public ControlClass Controller = new ControlClass();
        private Matrix4 _projectionMatrix;
        private List<LineObject> LineObjects = new List<LineObject>();

        public MainWindow(ControlClass controller) : base(1000, // initial width
        1000, // initial height
        GraphicsMode.Default, "SolarCore",  // initial title
        GameWindowFlags.Default,
        DisplayDevice.Default,
        4, // OpenGL major version
        0, // OpenGL minor version
        GraphicsContextFlags.ForwardCompatible)
        {
            Controller = controller;
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
            
            Controller.OldMouseState = Mouse.GetState();
            Controller.OldKeyState = Keyboard.GetState();
            VSync = VSyncMode.Off;
            CreateProjection();

            Controller.SimObject.Objects.Add(new SimulationObject(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, 0, 0), new Vector3(0, 0, 0), Color4.DeepSkyBlue)));
            Controller.SimObject.Objects.Add(new SimulationObject(new SolarObject(10, 2, 0, 0, new Vector3(0, 0.2f, 0), new Vector3(0, 0, 1.8f), Color4.LightGoldenrodYellow)));
            Controller.SimObject.Objects.Add(new SimulationObject(new SolarObject(10, 4, 0, 0, new Vector3(0, 0.4f, 0), new Vector3(0.9f, 0, 0.9f), Color4.MediumPurple)));
            Controller.SimObject.Objects.Add(new SimulationObject(new SolarObject(10, 5, 0, 0, new Vector3(0, 0.6f, 0), new Vector3(1f, 0, 0), Color4.Red)));
            
            RunSimulation(1);

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
            HandleKeyboard();
        }
        
        private void HandleKeyboard()
        {
            var mouseState = Mouse.GetState();
            var keyState = Keyboard.GetState();

            if (Focused)
            {
                if (Controller.OldMouseState.Scroll.Y != mouseState.Scroll.Y)
                {
                    Controller.Camera.Radius -= 0.05f * (mouseState.Scroll.Y - Controller.OldMouseState.Scroll.Y);
                }

                if (mouseState.IsButtonDown(MouseButton.Left))
                {
                    if (Controller.OldMouseState.IsButtonDown(MouseButton.Left) == true)
                    {
                        Controller.Camera.XVal += 0.01f * (mouseState.X - Controller.OldMouseState.X);
                        Controller.Camera.YVal += 0.01f * (Controller.OldMouseState.Y - mouseState.Y);
                    }
                }


                if (keyState.IsKeyDown(Key.Escape))
                {
                    Exit();
                }
                if (keyState.IsKeyDown(Key.Left))
                {
                    Controller.TimePeriod = Controller.TimePeriod >= 20 ? 20 : Controller.TimePeriod - 1;
                }
                if (keyState.IsKeyDown(Key.Right))
                {
                    Controller.TimePeriod = Controller.TimePeriod <= -20 ? 20 : Controller.TimePeriod + 1;
                }
                if (keyState.IsKeyDown(Key.S))
                {
                    Controller.Camera.XVal += 0.01;
                }
                if (keyState.IsKeyDown(Key.W))
                {
                    Controller.Camera.XVal -= 0.01;
                }
                if (keyState.IsKeyDown(Key.A))
                {
                    Controller.Camera.YVal += 0.01;
                }
                if (keyState.IsKeyDown(Key.D))
                {
                    Controller.Camera.YVal -= 0.01;
                }
                if (keyState.IsKeyDown(Key.R))
                {
                    ResetSim();
                }
                if (keyState.IsKeyDown(Key.Comma))
                {
                    if (!Controller.OldKeyState.IsKeyDown(Key.Comma))
                    {
                        Controller.Camera.Focus -= 1;
                        if (Controller.Camera.Focus < 0)
                            Controller.Camera.Focus = 0;
                    }
                }

                if (keyState.IsKeyDown(Key.Period))
                {
                    if (!Controller.OldKeyState.IsKeyDown(Key.Period))
                    {
                        Controller.Camera.Focus += 1;
                        if (Controller.Camera.Focus >= Controller.SimObject.Objects.Count)
                            Controller.Camera.Focus -= 1;
                    }
                }

                if (keyState.IsKeyDown(Key.Space))
                {
                    if (!Controller.OldKeyState.IsKeyDown(Key.Space))
                    {
                        Controller.Paused = !Controller.Paused;
                    }
                }

                if (Controller.Camera.YVal > 0.49) Controller.Camera.YVal = 0.49999;
                if (Controller.Camera.YVal < -0.49) Controller.Camera.YVal = -0.49999;

                var pi180 = (Math.PI);

                var initialPosition = Controller.SimObject.Objects[Controller.Camera.Focus].Object.Position;
                Controller.Camera.Position.X = initialPosition.X + Controller.Camera.Radius * (float)(Math.Sin(Controller.Camera.XVal * pi180) * Math.Cos(Controller.Camera.YVal * pi180));
                Controller.Camera.Position.Y = initialPosition.Y + Controller.Camera.Radius * (float)(Math.Sin(Controller.Camera.YVal * pi180));
                Controller.Camera.Position.Z = initialPosition.Z + Controller.Camera.Radius * -(float)(Math.Cos(Controller.Camera.XVal * pi180) * Math.Cos(Controller.Camera.YVal * pi180));

                Controller.OldKeyState = keyState;
                Controller.OldMouseState = mouseState;
            }
        }

        public void ResetSim()
        {
            LineObjects.ForEach(x => x.Object.Dispose());
            LineObjects.Clear();
            Controller.Frame = 0;
            Controller.TimePeriod = 1;
            Controller.Paused = false;
        }

        private void CreateProjection()
        {
            var aspectRatio = (float)Width / Height;
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                60 * ((float)Math.PI / 180f), // field of view angle, in radians
                aspectRatio,                // current window aspect ratio
                0.1f,                       // near plane
                4000f);                     // far plane
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit called");
            foreach (var obj in Controller.SimObject.Objects.Select(x => x.Object))
                obj.Object.Dispose();
            foreach (var obj in LineObjects.Select(x => x.Object))
                obj.Dispose();
            GL.DeleteProgram(_program);
            base.Exit();
        }

        private void RunSimulation(int initialRender)
        {
            var endTime = DateTime.Now.AddSeconds(initialRender);
            while (DateTime.Now < endTime)
            {
                List<AggregateObject> response = new List<AggregateObject>();
                foreach (var obj in Controller.SimObject.Objects.Select(x => x.Object))
                {
                    response.Add(GravityMethods.RecalculateValues(obj, Controller.SimObject.Objects.Select(x => x.Object).ToList(), 0.001f));
                }

                foreach (var x in response)
                {
                    var currentObject = Controller.SimObject.Objects.First(y => y.Object == x.Object);
                    currentObject.Object.Velocity = x.Velocity;
                    currentObject.Object.Position = x.Position;
                    currentObject.Positions.Add(x.Position);
                }
            }
        }

        DateTime endTime = DateTime.Now;
        double secondsElapsed = 0;
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            var matrixStuff = Matrix4.LookAt(Controller.Camera.Position, Controller.SimObject.Objects[Controller.Camera.Focus].Object.Position, Vector3.UnitY);
            if (!Controller.Paused)
                Controller.Frame += Controller.TimePeriod;

            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (Controller.Frame >= Controller.SimObject.Objects.First().Positions.Count)
            {
                if (secondsElapsed == 0)
                    secondsElapsed = (DateTime.Now - endTime).TotalSeconds;
                Console.WriteLine("Reached end of simulation: " + secondsElapsed);
                Controller.Frame = Controller.SimObject.Objects.First().Positions.Count - 1;
            }
            if (Controller.Frame < 0)
            {
                Console.WriteLine("Beginning of simulation");
                Controller.Frame = 0;
            }

            foreach (var obj in Controller.SimObject.Objects)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                if (!Controller.Paused)
                {

                    obj.Object.Position = obj.Positions[Controller.Frame];
                    LineObjects.Add(new LineObject(obj.Object.Position, obj.Object.Colour, obj.Object.Radius / 10));
                }
                obj.Object.Render(matrixStuff);
            }

            for (int i = 0; i < LineObjects.Count; i++)
            {
                if (!Controller.Paused)
                {
                    LineObjects[i].DeleteBy -= Math.Abs(Controller.TimePeriod);
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
