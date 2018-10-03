using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SolarForms.Components
{
    public partial class MainWindow : GameWindow
    {
        private int _program;
        private int _vertexArray;
        private double _time;
        private List<RenderObject> _renderObjects = new List<RenderObject>();
        private Matrix4 _modelView;
        private Matrix4 _projectionMatrix;
        private List<SolarObject> _solarObjects = new List<SolarObject>();

        private int mouseX;
        private int mouseY;
        private float mouseScroll;
        private bool isMouseDown;
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
           GL.Viewport(0, 0, Width, Height);
           CreateProjection();

        }

        protected override void OnLoad(EventArgs e)
        {
            VSync = VSyncMode.On;
            CreateProjection();
            _solarObjects.Add(new SolarObject(100, 1, 10, 15, new Vector3(0, 0, -0.1f), new Vector3(6, 6, 12)));
            _solarObjects.Add(new SolarObject(100, 3, 10, 15, new Vector3(0, 1, -2), new Vector3(4236, 3256, 512)));

            _renderObjects.Add(new RenderObject(new Sphere().CreateSphere(3, Color4.White)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.BlueViolet)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.5f, Color4.Red)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(1f, Color4.LimeGreen)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(1.5f, Color4.DarkSlateBlue)));

            CursorVisible = true;

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
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

            if (mouseState.IsButtonDown(MouseButton.Left))
            {
                if (isMouseDown == true)
                {
                    _cameraPosition.X += 0.001f * (mouseState.X - mouseX);
                    _cameraPosition.Y += 0.001f * (mouseY - mouseState.Y);
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
            if (keyState.IsKeyDown(Key.S))
            {
                _cameraPosition.Z -= 0.01f;
            }
            if (keyState.IsKeyDown(Key.W))
            {
                _cameraPosition.Z += 0.01f;
            }
            if (keyState.IsKeyDown(Key.A))
            {
                _cameraPosition.X += 0.01f;
            }
            if (keyState.IsKeyDown(Key.D))
            {
                _cameraPosition.X -= 0.01f;
            }
            if (keyState.IsKeyDown(Key.Q))
            {
                _cameraPosition.Y += 0.01f;
            }
            if (keyState.IsKeyDown(Key.E))
            {
                _cameraPosition.Y -= 0.01f;
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
                _projectionMatrix = Matrix4.LookAt(Vector3.UnitZ, Vector3.UnitX
                    , Vector3.UnitY) * Matrix4.CreatePerspectiveFieldOfView(60 * ((float)Math.PI / 180f),aspectRatio, .01f, 4000.0f);
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit called");
            foreach (var obj in _renderObjects)
                obj.Dispose();
            GL.DeleteProgram(_program);
            base.Exit();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += e.Time;
            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_program);
            GL.UniformMatrix4(20, false, ref _projectionMatrix);
            float c = 0f;
            foreach (var solarObject in _solarObjects)
            {
                solarObject.Object.Bind();
                for (int i = 0; i < 1; i++)
                {
                    var k = i +(float)(_time * (0.05f + (0.1 * c)));
                    /*   var t2 = Matrix4.CreateTranslation(
                           (float)(Math.Sin(k * 5f) * (c + 0.5f)),
                           (float)(Math.Cos(k * 5f) * (c + 0.5f)),
                           -2.7f);*/

                    var t2 = Matrix4.CreateTranslation(solarObject.Position);
                    var r1 = Matrix4.CreateRotationZ(solarObject.Obliquity);
                    var r2 = Matrix4.CreateRotationY(0.2f * (float)_time);
                    var lll = Matrix4.CreateScale(0.1f * solarObject.Radius);
                    var modelView = lll * r2 * t2 * r1 * Matrix4.CreateTranslation(_cameraPosition);// * aaaah;
                    GL.UniformMatrix4(21, false, ref modelView);
                    solarObject.Object.Render();
                }
                c += 0.3f;
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
