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
    class SecondWindow
    {
        private int _program;
        private int _vertexArray;
        private double _time;
        private Matrix4 _modelView;
        private Matrix4 _projectionMatrix;
        private List<SolarObject> _solarObjects = new List<SolarObject>();

        private int mouseX;
        private int mouseY;
        private float mouseScroll;
        private bool isMouseDown;
        private bool isMouseRightDown;
        private GameWindow game;
        private static float timePeriod = 16;
        Timer t = new Timer(timePeriod);

        private Vector3 _cameraAngle = new Vector3(0, 0, 0);

        private Vector3 _cameraPosition = new Vector3(0, 0, 0);

        public SecondWindow()
        {
            using (game = new GameWindow())
            {
                game.RenderFrame += (sender, e) => OnRenderFrame(e);
                game.Resize += (sender, e) => OnResize(e);
                game.Load += (sender, e) => OnLoad(e);
                game.Closed += OnClosed;
                game.RenderFrame += (sender, e) => OnRenderFrame(e);
                game.UpdateFrame += (sender, e) => OnUpdateFrame(e);
            }
        }

        protected void OnResize(EventArgs e)
        {

            //   GL.Viewport(0, 0, Width, Height);
            GL.Ortho(-0.99, 1, -0.99, 1, -1, 1);

            //    CreateProjection();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
        }

        protected void OnLoad(EventArgs e)
        {
            Stopwatch sw;

            for (int index = 0; index < 10; index++)
            {
                sw = Stopwatch.StartNew();
                UpdatePositions();
                Console.WriteLine("aaa" + sw.ElapsedMilliseconds);
                sw.Stop();

            }
            CreateProjection();
            _solarObjects.Add(new SolarObject(1000000000, 5, 0, 0, new Vector3(0, -0.2f, 1), new Vector3(0.8f, 0, 0)));
            //    _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0.4f, 0, 1), new Vector3(0, 0, -0.5f)));
            //    _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(-0.4f, 0, 1), new Vector3(0, 0, 0.5f)));
            _solarObjects.Add(new SolarObject(1000000000, 5, 0, 0, new Vector3(0, 0.2f, 1), new Vector3(-0.8f, 0, 0)));
            _solarObjects.Add(new SolarObject(100, 1, 0, 0, new Vector3(0, -0.5f, 1), new Vector3(0.9f, 0, 0)));
            //     _solarObjects.Add(new SolarObject(100, 5, 0, 0, new Vector3(0, 0.8f, 1), new Vector3(0, 0, 0)));

            //   _solarObjects.Add(new SolarObject(1, 1, 0, 0, new Vector3(0, -0.5f, 1), new Vector3(0.9f, 0, 0)));

            game.CursorVisible = true;

            

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);

        }

        protected void OnUpdateFrame(FrameEventArgs e)
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
                timePeriod -= 1;
                if (timePeriod <= 0) timePeriod = 1;
                t.Interval = timePeriod;
            }
            if (keyState.IsKeyDown(Key.Right))
            {
                timePeriod += 1;
                t.Interval = timePeriod;

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
            var aspectRatio = (float)game.Width / game.Height;
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

        public void Exit()
        {
            Debug.WriteLine("Exit called");
            foreach (var obj in _solarObjects)
                obj.Object.Dispose();
            GL.DeleteProgram(_program);
            game.Exit();
        }

        private void UpdatePositions()
        {
            List<List<Vector3>> actualStuff = new List<List<Vector3>>();
            foreach (var obj in _solarObjects)
            {
                List<List<Vector3>> stuff = new List<List<Vector3>>();
                foreach (var obj2 in _solarObjects)
                {
                    if (obj != obj2)
                    {
                        stuff.Add(obj.RecalculateValues(obj2, 0.01f));

                    }

                }

                var vels = new Vector3();
                var poss = new Vector3();


                foreach (var velocities in stuff)
                {
                    vels += velocities.First();
                    poss += velocities.Last();

                }

                vels = vels / stuff.Count;
                poss = poss / stuff.Count;

                actualStuff.Add(new List<Vector3>() { vels, poss });
            }


            for (int i = 0; i < actualStuff.Count; i++)
            {
                _solarObjects[i].Velocity = actualStuff[i][0];
                _solarObjects[i].Position = actualStuff[i][1];

            }
            /*var list1 = _solarObjects[0].RecalculateValues(_solarObjects[3], 0.01f);
            var list2 = _solarObjects[3].RecalculateValues(_solarObjects[0], 0.01f);

            _solarObjects.First().Velocity = list1[0];

            _solarObjects.First().Position = list1[1];

            _solarObjects.Last().Velocity = list2[0];

            _solarObjects.Last().Position = list2[1];
            */

        }

        protected void OnRenderFrame(FrameEventArgs e)
        {
            //  _cameraAngle.X += 0.01f;
            //  _cameraAngle.Y += 0.001f;
            //  _cameraAngle.Z -= 0.01f;


            _projectionMatrix = Matrix4.LookAt(new Vector3(0, 0, 0), Vector3.UnitZ, Vector3.UnitY) * Matrix4.CreatePerspectiveFieldOfView(60 * ((float)Math.PI / 180f), 1, .01f, 4000.0f);

            _time += e.Time;
            game.Title = $"(Vsync: {game.VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_program);
            GL.UniformMatrix4(20, false, ref _projectionMatrix);
            foreach (var solarObject in _solarObjects)
            {
                solarObject.Object.Bind();
                for (int i = 0; i < 1; i++)
                {
                    //   var k = i +(float)(_time * (0.05f + (0.1 * c)));
                    /*   var t2 = Matrix4.CreateTranslation(
                           (float)(Math.Sin(k * 5f) * (c + 0.5f)),
                           (float)(Math.Cos(k * 5f) * (c + 0.5f)),
                           -2.7f);*/
                    var t1 = Matrix4.CreateTranslation(_cameraPosition);

                    var t2 = Matrix4.CreateTranslation(solarObject.Position);
                    var r1 = Matrix4.CreateRotationZ(solarObject.Obliquity);
                    var r2 = Matrix4.CreateRotationY(0.2f * (float)_time);
                    var lll = Matrix4.CreateScale(0.01f * solarObject.Radius);
                    var modelView = lll * r2 * t2 * r1 * t1;// * aaaah;
                    GL.UniformMatrix4(21, false, ref modelView);
                    solarObject.Object.Render();
                }
            }

            GL.PointSize(10);
            game.SwapBuffers();
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
