using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;

namespace SolarForms.Components
{
    public partial class MainWindow : GameWindow
    {
        private int _program;
        private double _time;

        private Matrix4 _projectionMatrix;
        private Simulation SimObject = new Simulation();
        private List<LineObject> LineObjects = new List<LineObject>();

        private MouseState oldMouseState;
        private KeyboardState oldKeyState;
        private float radius = 1;
        private int objToFollow = 0;
        private int simPosition = 0;

        private int pauseSavedTimePeriod = 0;
        private int timePeriod = 0;

        private double a = 0;
        private double b = 0;

        private Vector3 _cameraPosition = new Vector3(0, 0, -1);

        public MainWindow() : base(1000, // initial width
        1000, // initial height
        GraphicsMode.Default, "SolarCore",  // initial title
        GameWindowFlags.Default,
        DisplayDevice.Default,
        4, // OpenGL major version
        0, // OpenGL minor version
        GraphicsContextFlags.ForwardCompatible)
        {
            Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
        }

        protected override void OnResize(EventArgs e)
        {

         //   GL.Viewport(0, 0, Width, Height);
            GL.Ortho(-0.99, 1, -0.99, 1, -1, 1);

            //    CreateProjection();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
        }

        protected override void OnLoad(EventArgs e)
        {
            oldMouseState = Mouse.GetState();
            oldKeyState = Keyboard.GetState();
            VSync = VSyncMode.Off;
            CreateProjection();
         //   test.Objects.Add(new SimulationObject(new SolarObject(10000000000, 20, 0, 0, new Vector3(0, 0, 0), new Vector3(0.1f, 0, 0), Color4.Yellow)));

            SimObject.Objects.Add(new SimulationObject(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, 0, 0), new Vector3(0, 0, 0), Color4.DeepSkyBlue)));
            //    _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, 0, 1), new Vector3(1.2f, 0f, 0)));
            SimObject.Objects.Add(new SimulationObject(new SolarObject(10, 2, 0, 0, new Vector3(0, 0.2f, 0), new Vector3(0, 0, 1.8f), Color4.LightGoldenrodYellow)));
            SimObject.Objects.Add(new SimulationObject(new SolarObject(10, 4, 0, 0, new Vector3(0, 0.4f, 0), new Vector3(0.9f, 0, 0.9f), Color4.MediumPurple)));
            SimObject.Objects.Add(new SimulationObject(new SolarObject(10, 5, 0, 0, new Vector3(0, 0.6f, 0), new Vector3(1f, 0, 0), Color4.Red)));

            //   _solarObjects.Add(new SolarObject(1000, 1, 0, 0, new Vector3(0.4f, 0, 1), new Vector3(0, 0, 1f), Color4.MediumPurple));
            //         SimObject.Objects.Add(new SimulationObject(new SolarObject(1000000000, 3, 0, 0, new Vector3(0.4f, 0, 0), new Vector3(-0.25f, 0, 0.4f), Color4.MediumPurple)));

            SimTest(1);

            CursorVisible = true;
            
            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
            RenderFrame += OnRenderFrame;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var deleteList = new List<LineObject>();
            foreach (var obj in LineObjects)
            {
                if (obj.DeleteBy < DateTime.Now)
                {
                    deleteList.Add(obj);
                }
            }
            foreach (var obj in deleteList)
            {
                obj.Object.Dispose();
                LineObjects.Remove(obj);
            }

            _time += e.Time;
            HandleKeyboard();

        }

        private void HandleKeyboard()
        {
            var mouseState = Mouse.GetState();
            var keyState = Keyboard.GetState();

            if (oldMouseState.Scroll.Y != mouseState.Scroll.Y)
            {
                radius -= 0.05f * (mouseState.Scroll.Y - oldMouseState.Scroll.Y);
            }
            
            if (mouseState.IsButtonDown(MouseButton.Left))
            {
                if (oldMouseState.IsButtonDown(MouseButton.Left) == true)
                {
                    a += 0.01f * (mouseState.X - oldMouseState.X);
                    b += 0.01f * (oldMouseState.Y - mouseState.Y);
                }
            }

            if (keyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if (keyState.IsKeyDown(Key.Left))
            {
                timePeriod += 1;
            }
            if (keyState.IsKeyDown(Key.Right))
            {
                timePeriod -= 1;
            }
            if (keyState.IsKeyDown(Key.S))
            {
                a += 0.01;
            }
            if (keyState.IsKeyDown(Key.W))
            {
                a -= 0.01;
            }
            if (keyState.IsKeyDown(Key.A))
            {
                b += 0.01;
            }
            if (keyState.IsKeyDown(Key.D))
            {
                b -= 0.01;
            }
            if (keyState.IsKeyDown(Key.R))
            {
                LineObjects.ForEach(x => x.Object.Dispose());
                LineObjects.Clear();
                simPosition = 0;
                timePeriod = 1;
            }
            if (keyState.IsKeyDown(Key.Comma))
            {
                if (!oldKeyState.IsKeyDown(Key.Comma))
                {
                    objToFollow -= 1;
                    if (objToFollow < 0)
                        objToFollow = 0;
                }
            }

            if (keyState.IsKeyDown(Key.Period))
            {
                if (!oldKeyState.IsKeyDown(Key.Period))
                {
                    objToFollow += 1;
                    if (objToFollow >= SimObject.Objects.Count)
                        objToFollow -= 1;
                }
            }
            if (keyState.IsKeyDown(Key.Space))
            {
                if (!oldKeyState.IsKeyDown(Key.Space))
                {
                    if (timePeriod != 0)
                    {
                        pauseSavedTimePeriod = timePeriod;
                        timePeriod = 0;
                    }
                    else
                    {
                        timePeriod = pauseSavedTimePeriod;
                    }
                }
            }

            if (b > 0.49) b = 0.49;
            if (b < -0.49) b = -0.49;

            var pi180 = (Math.PI);
            
            var initialPosition = SimObject.Objects[objToFollow].Object.Position;
            _cameraPosition.X = initialPosition.X + radius * (float)(Math.Sin(a * pi180) * Math.Cos(b * pi180));
            _cameraPosition.Y = initialPosition.Y + radius * (float)(Math.Sin(b * pi180));
            _cameraPosition.Z = initialPosition.Z + radius * -(float)(Math.Cos(a * pi180) * Math.Cos(b * pi180));

            oldKeyState = keyState;
            oldMouseState = mouseState;
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
            foreach (var obj in SimObject.Objects.Select(x => x.Object))
                obj.Object.Dispose();
            GL.DeleteProgram(_program);
            base.Exit();
        }

        private void SimTest(int initialRender)
        {
            var endTime = DateTime.Now.AddSeconds(initialRender);
            while (DateTime.Now < endTime)
            {
                List<AggregateObject> response = new List<AggregateObject>();
                foreach (var obj in SimObject.Objects.Select(x => x.Object))
                {
                    response.Add(GravityMethods.RecalculateValues(obj, SimObject.Objects.Select(x => x.Object).ToList(), 0.001f));
                }

                foreach (var x in response)
                {
                    var currentObject = SimObject.Objects.First(y => y.Object == x.Object);
                    currentObject.Object.Velocity = x.Velocity;
                    currentObject.Object.Position = x.Position;
                    currentObject.Positions.Add(x.Position);
                }
            }
        }

        DateTime endTime = DateTime.Now;
        double secondsElapsed = 0;
        protected void OnRenderFrame(object sender, FrameEventArgs e)
        {
            var matrixStuff = Matrix4.LookAt(_cameraPosition, SimObject.Objects[objToFollow].Object.Position, Vector3.UnitY);
            simPosition+= timePeriod;
            
            _time += e.Time;
            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (simPosition >= SimObject.Objects.First().Positions.Count)
            {
                if (secondsElapsed == 0)
                    secondsElapsed = (DateTime.Now - endTime).TotalSeconds;
                Console.WriteLine("Reached end of simulation: " + secondsElapsed);
                simPosition = SimObject.Objects.First().Positions.Count - 1;
            }
            if (simPosition < 0)
            {
                Console.WriteLine("Beginning of simulation");
                simPosition = 0;
            }
            foreach (var obj in SimObject.Objects)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                obj.Object.Position = obj.Positions[simPosition];
                LineObjects.Add(new LineObject(obj.Object.Position, obj.Object.Colour, DateTime.Now.AddSeconds(5), obj.Object.Radius / 10));
                
                obj.Object.Render(matrixStuff);
            }

            for (int i = 0; i < LineObjects.Count; i++)
            {
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
