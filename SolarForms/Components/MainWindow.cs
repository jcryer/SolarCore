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
        private int _vertexArray;
        private double _time;
        private Matrix4 _modelView;
        private Matrix4 _projectionMatrix;
        private List<SolarObject> _solarObjects = new List<SolarObject>();
        private List<LineObject> _lineObjects = new List<LineObject>();
        public ICamera _camera;
        private int mouseX;
        private int mouseY;
        private float mouseScroll;
        private bool isMouseDown;
        private bool isMouseRightDown;
        List<Vertex> x = new List<Vertex>();
        private static float timePeriod = 0.001f;
      //  Timer t = new Timer(timePeriod);

        private Vector3 _cameraAngle = new Vector3(0, 0, 0);

        private Vector3 _cameraPosition = new Vector3(0, 0, 0);

        public MainWindow() : base(720, // initial width
        720, // initial height
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
            _solarObjects.Add(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, -0.5f, 1), new Vector3(0.25f, 0, -0.4f), Color4.DeepSkyBlue));
            //    _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, 0, 1), new Vector3(1.2f, 0f, 0)));
            _solarObjects.Add(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, 0.5f, 1), new Vector3(-0.25f, 0, 0.4f), Color4.DeepSkyBlue));
            _camera = new ThirdPersonCamera(_solarObjects.Last(), new Vector3(1, 1, 1));

            _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0.4f, 0, 1), new Vector3(0, 0, -1f), Color4.MediumPurple));
            //  _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(-0.4f, 0, 1), new Vector3(0, 0, -1f), Color4.MediumPurple));
            //  _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, 0.4f, 1), new Vector3(0, 0, 1f), Color4.MediumPurple));
            //        _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0.4f, 0, 1), new Vector3(0, 0, 1f), Color4.MediumPurple));


            //        _solarObjects.Add(new SolarObject(1000000000, 10, 0, 0, new Vector3(0, 0.2f, 1), new Vector3(-0.75f, 0, 0), Color4.Maroon));
            //       _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, -1f, 1), new Vector3(0.9f, 0, 0), Color4.Navy));
            //       _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, 1f, 1), new Vector3(0.9f, 0, 0), Color4.Navy));

            //     _solarObjects.Add(new SolarObject(100, 5, 0, 0, new Vector3(0, 0.8f, 1), new Vector3(0, 0, 0)));

            //   _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, -0.5f, 1), new Vector3(0.9f, 0, 0)));

            CursorVisible = true;
            //t.Elapsed += new ElapsedEventHandler(UpdatePositions);
            // t.AutoReset = true;
            // t.Start();
            

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
            
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            UpdatePositions();
            _time += e.Time;
            HandleKeyboard();
            _camera.Update(_time, e.Time);

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
              //  _projectionMatrix = Matrix4.LookAt(new Vector3(-0.5f, -0.2f, -1), _solarObjects.First().Position, Vector3.UnitY);

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
                    _cameraPosition.X += 0.01f * (mouseState.X - mouseX);
                    _cameraPosition.Y += 0.01f * (mouseY - mouseState.Y);
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
                timePeriod += 0.001f;
          //      t.Interval = timePeriod;
            }
            if (keyState.IsKeyDown(Key.Right))
            {
                timePeriod -= 0.001f;
            //    t.Interval = timePeriod;

            }
            if (keyState.IsKeyDown(Key.S))
            {
                _cameraPosition.Z -= 0.1f;
            }
            if (keyState.IsKeyDown(Key.W))
            {
                _cameraPosition.Z += 0.1f;
            }
            if (keyState.IsKeyDown(Key.A))
            {
                _cameraPosition.X += 0.1f;
            }
            if (keyState.IsKeyDown(Key.D))
            {
                _cameraPosition.X -= 0.1f;
            }
            if (keyState.IsKeyDown(Key.Q))
            {
                _cameraPosition.Y += 0.1f;
            }
            if (keyState.IsKeyDown(Key.E))
            {
                _cameraPosition.Y -= 0.1f;
            }

            if (keyState.IsKeyDown(Key.Comma))
            {
                _cameraAngle.X += 0.1f;
            }
            if (keyState.IsKeyDown(Key.Period))
            {
                _cameraAngle.X -= 0.1f;
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
            var z = Vector3.UnitZ;
            var zneg = -Vector3.UnitZ;
            var y = Vector3.UnitY;
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
        int i = 0;

        private void UpdatePositions()
        {
            List<TestObject> test = new List<TestObject>();
            foreach (var obj in _solarObjects)
            {
                test.Add(GravityMethods.RecalculateValues(obj, _solarObjects, timePeriod));
            }

            foreach (var x in test)
            {
                var currentObject = _solarObjects.First(y => x.Object == y);
                currentObject.Velocity = x.Velocity;
                currentObject.Position = x.Position;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            //  _cameraAngle.X += 0.01f;
            //  _cameraAngle.Y += 0.001f;
            //  _cameraAngle.Z -= 0.01f;


         //   _projectionMatrix = _camera.LookAtMatrix;

            _time += e.Time;
            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            

            foreach (var obj in _solarObjects)
            {
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);

                obj.Render(_camera);
            }
            /*
            foreach (var solarObject in _solarObjects)
            {
                solarObject.Object.Bind();
                var t1 = Matrix4.CreateTranslation(_cameraPosition);

                var t2 = Matrix4.CreateTranslation(solarObject.Position);
                var r1 = Matrix4.CreateRotationZ(solarObject.Obliquity);
                var r2 = Matrix4.CreateRotationY(0.2f * (float)_time);
                var lll = Matrix4.CreateScale(0.01f * solarObject.Radius);
                var modelView = lll * r2 * t2 * t1 * r1;// * aaaah;
                GL.UniformMatrix4(21, false, ref modelView);
                solarObject.Object.Render();
                
            }
            
            foreach (var solarObject in _lineObjects.Select(x => x.Obj))
            {
                solarObject.Object.Bind();
                var t1 = Matrix4.CreateTranslation(_cameraPosition);

                var t2 = Matrix4.CreateTranslation(solarObject.Position);
                var lll = Matrix4.CreateScale(0.001f * solarObject.Radius);
                var modelView = lll * t2 * t1;// * aaaah;
                GL.UniformMatrix4(21, false, ref modelView);
                solarObject.Object.Render();

            }*/

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
