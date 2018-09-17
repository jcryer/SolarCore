using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarForms.Components
{
    public partial class MainWindow : GameWindow
    {
        private int _program;
        private int _vertexArray;
        private double _time;

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
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = true;
            _program = CreateProgram();
            GL.GenVertexArrays(1, out _vertexArray);
            GL.BindVertexArray(_vertexArray);
            Closed += OnClosed;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            HandleKeyboard();
        }
        private void HandleKeyboard()
        {
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            GL.DeleteVertexArrays(1, ref _vertexArray);
            GL.DeleteProgram(_program);
            base.Exit();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += e.Time;

            Title = $"SolarCore (Vsync: {VSync}) FPS: {1f / e.Time:0}";

            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_program);

            GL.VertexAttrib1(0, _time);

            Vector4 position;
            position.X = (float)Math.Sin(_time) * 0.5f;
            position.Y = (float)Math.Cos(_time) * 0.5f;
            position.Z = 0.0f;
            position.W = 1.0f;
            GL.VertexAttrib4(1, position);

            
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
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
