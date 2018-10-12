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
        private List<SolarObject> _solarObjects = new List<SolarObject>();
        private Simulation test = new Simulation();
        private List<LineObject> _lineObjects = new List<LineObject>();
        private int mouseX;
        private int mouseY;
        private float mouseScroll;
        private bool isMouseDown;
        private bool isMouseRightDown;
        private int simPosition = 0;
        private int pauseSavedTimePeriod = 0;
        private static int timePeriod = 1;
        private double a = 0;
        private double b = 0;

        private bool DansIdea = false;
        private Vector3 _cameraAngle = new Vector3(0, 0, 0);

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
            VSync = VSyncMode.Off;
            CreateProjection();
            test.Objects.Add(new SimulationObject(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, -0.5f, 0), new Vector3(0.25f, 0, -0.4f), Color4.DeepSkyBlue)));
            //    _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, 0, 1), new Vector3(1.2f, 0f, 0)));
            test.Objects.Add(new SimulationObject(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, 0.5f, 0), new Vector3(-0.25f, 0, 0.4f), Color4.LightGoldenrodYellow)));
            //   _solarObjects.Add(new SolarObject(1000, 1, 0, 0, new Vector3(0.4f, 0, 1), new Vector3(0, 0, 1f), Color4.MediumPurple));
            test.Objects.Add(new SimulationObject(new SolarObject(1000000000, 3, 0, 0, new Vector3(0.4f, 0, 0), new Vector3(-0.25f, 0, 0.4f), Color4.MediumPurple)));
        //    _camera = new ThirdPersonCamera(test.Objects.First().Object);

            SimTest();

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
            foreach (var obj in _lineObjects)
            {
                if (obj.DeleteBy < DateTime.Now)
                {
                    deleteList.Add(obj);
                }
            }
            foreach (var obj in deleteList)
            {
                obj.Object.Dispose();
                _lineObjects.Remove(obj);
            }

            _time += e.Time;
            HandleKeyboard();

        }

        private void HandleKeyboard()
        {
            var mouseState = Mouse.GetState();
            if (mouseScroll != mouseState.Scroll.Y)
            {
                _cameraPosition.Z += 0.01f * (mouseState.Scroll.Y - mouseScroll);

                mouseScroll = mouseState.Scroll.Y;
            }

            if (mouseState.IsButtonDown(MouseButton.Right))
            {

                if (isMouseRightDown == true)
                {
                    _cameraAngle.X += 0.01f * (mouseX - mouseState.X);
                    _cameraAngle.Y += 0.01f * (mouseState.Y - mouseY);
                    Console.WriteLine($"Angle: {_cameraAngle.X} {_cameraAngle.Y} {_cameraAngle.Z}");
                    Console.WriteLine($"Position: {_cameraPosition.X} {_cameraPosition.Y} {_cameraPosition.Z}");
                }
                isMouseRightDown = true;
                mouseX = mouseState.X;
                mouseY = mouseState.Y;
            }
            else
            {
                isMouseRightDown = false;
            }

            if (mouseState.IsButtonDown(MouseButton.Left))
            {
                if (isMouseDown == true)
                {
                    a += 0.01f * (mouseState.X - mouseX);
                    b += 0.01f * (mouseY - mouseState.Y);
                }
                isMouseDown = true;
                mouseX = mouseState.X;
                mouseY = mouseState.Y;

            }
            else
            {
                isMouseDown = false;
            }
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if (keyState.IsKeyDown(Key.Left))
            {
                timePeriod += 1;
          //      t.Interval = timePeriod;
            }
            if (keyState.IsKeyDown(Key.Right))
            {
                timePeriod -= 1;
            //    t.Interval = timePeriod;

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
            if (keyState.IsKeyDown(Key.Q))
            {
                _cameraPosition.Y += 0.01f;
            }
            if (keyState.IsKeyDown(Key.E))
            {
                _cameraPosition.Y -= 0.01f;
            }
            if (keyState.IsKeyDown(Key.R))
            {
                _lineObjects.ForEach(x => x.Object.Dispose());
                _lineObjects.Clear();
                simPosition = 0;
                timePeriod = 1;
            }
            if (keyState.IsKeyDown(Key.Comma))
            {
                _cameraAngle.X += 0.1f;
            }
            if (keyState.IsKeyDown(Key.Period))
            {
                _cameraAngle.X -= 0.1f;
            }
            if (keyState.IsKeyDown(Key.Space))
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

            var pi180 = (Math.PI);
            Console.WriteLine("1 - " + Math.Cos(a) + " 2 - " + Math.Cos(b)) ;
            
            /*
            _cameraPosition.X = 0 + 1 * (float)(Math.Cos(a));
            _cameraPosition.Y = 0 + 1 * (float)(Math.Sin(a));

            _cameraPosition.Z = 0;
            
            
            
             _cameraPosition.X = 0 + 1 *(float)(Math.Cos(a) * Math.Sin(b));
            _cameraPosition.Y = 0 + 1 *(float)(Math.Sin(a) * Math.Sin(b));

            _cameraPosition.Z = 0 + 1 *(float)(Math.Cos(b));*/

            
             _cameraPosition.X = 0 + 1 *(float)(Math.Sin(a * pi180) * Math.Cos(b * pi180));
             _cameraPosition.Y = 0 + 1 *(float)(Math.Sin(b * pi180));

            // 1 - (0.5*a*a) == a
            if (Math.Round(Math.Cos(a), 3) == 1 || Math.Round(Math.Cos(b), 3) == 1 )
            {
                DansIdea = !DansIdea;
            }
            if (DansIdea)
            {
                _cameraPosition.Z = 0 + 1 * (float)(Math.Cos(a * pi180) * Math.Cos(b * pi180));
            }
            else
            {
                _cameraPosition.Z = 0 + 1 * -(float)(Math.Cos(a * pi180) * Math.Cos(b * pi180));

            }

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
            foreach (var obj in _solarObjects)
                obj.Object.Dispose();
            GL.DeleteProgram(_program);
            base.Exit();
        }

        private void SimTest()
        {
            var endTime = DateTime.Now.AddSeconds(1);
            while (DateTime.Now < endTime)
            {
                List<AggregateObject> response = new List<AggregateObject>();
                foreach (var obj in test.Objects.Select(x => x.Object))
                {
                    response.Add(GravityMethods.RecalculateValues(obj, test.Objects.Select(x => x.Object).ToList(), 0.001f));
                }

                foreach (var x in response)
                {
                    var currentObject = test.Objects.First(y => y.Object == x.Object);
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
            var matrixStuff = Matrix4.LookAt(_cameraPosition, new Vector3(0, 0, 0), (DansIdea? -1 : 1 ) * Vector3.UnitY);
            simPosition+= timePeriod;
            //  _cameraAngle.X += 0.01f;
            //  _cameraAngle.Y += 0.001f;
            //  _cameraAngle.Z -= 0.01f;
            
            _time += e.Time;
            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (simPosition >= test.Objects.First().Positions.Count)
            {
                if (secondsElapsed == 0)
                    secondsElapsed = (DateTime.Now - endTime).TotalSeconds;
                Console.WriteLine("Reached end of simulation: " + secondsElapsed);
                simPosition = test.Objects.First().Positions.Count - 1;
            }
            if (simPosition < 0)
            {
                Console.WriteLine("Beginning of simulation");
                simPosition = 0;
            }
            foreach (var obj in test.Objects)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                obj.Object.Position = obj.Positions[simPosition];
                _lineObjects.Add(new LineObject(obj.Object.Position, obj.Object.Colour, DateTime.Now.AddSeconds(5), obj.Object.Radius / 10));
                
                obj.Object.Render(matrixStuff);
            }

            for (int i = 0; i < _lineObjects.Count; i++)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                _lineObjects[i].Render(matrixStuff);
                
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
