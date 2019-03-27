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

        public MainWindow(Simulation simulation) : base(1000, // Initial window width
        1000, // Initial window height
        GraphicsMode.Default, "SolarCore",  // Window title
        GameWindowFlags.Default,
        DisplayDevice.Default,
        4, // OpenGL Major version
        0, // OpenGL Minor version
        GraphicsContextFlags.ForwardCompatible)
        {
            Simulation = simulation;
        }

        public bool LocalIsDisposed
        {
            get { return IsDisposed; }
        }

        // This triggers when the MainWindow is resized.
        // It resizes the viewport, meaning that the aspect ratio is maintained.
        protected override void OnResize(EventArgs e)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Viewport(0, 0, Width, Height);

            CreateProjection();
        }

        // This triggers when the MainWindow initially starts up.
        protected override void OnLoad(EventArgs e)
        {
            Simulation.OldMouseState = Mouse.GetState();
            Simulation.OldKeyState = Keyboard.GetState();
            VSync = VSyncMode.Off;
            CreateProjection();

            // Creates a new RenderObject (sphere) for each object within the Simulation, and saves their initial positions.
            foreach (var x in Simulation.PlanetarySystem.Objects)
            {
                x.Obj = new RenderObject(new Sphere().CreateSphere(3, x.ObjectColour));
                x.InitialPosition = x.Position;
                x.InitialVelocity = x.Velocity;
            }

            // Calculates the first 300 positions for each object within the Simulation.
            Simulation.Run(300, false, 0);
            CursorVisible = true;

            // Low level OpenGL methods to open the MainWindow screen and set it up to display the generated polygons as required.
            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);

            // Setting up event handlers for when the MainWindow closes, and for the OnRenderFrame event (occurs 60 times a second).
            Closed += OnClosed;
            RenderFrame += (sender, f) => OnRenderFrame(f);
        }

        // This method is also triggered 60 times a second, before each OnRenderFrame event being triggered.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Deletes all SolarObject that have been deleted from the simulation via the ControlForm, and disposes of them from the OpenGL buffers.
            // Also disposes of all LineObjects connected to each deleted SolarObject.
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

            // Checks to see whether or not there are any new SolarObjects in the simulation, that haven't yet had their initial positions and velocities saved.
            // If there are, save their initial positions and velocities.
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

            // Triggers if a new object has been added to the simulation, or any other values have been changed using the ControlForm.
            if (newObjects || Simulation.Changed)
            {
                // Foreach loop iterates through each SolarObject in the Simulation, and recreates the RenderObject information for that SolarObject.
                // Also clears all LineObjects, and any already calculated frames in the Simulation.
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
                // Calculates more frames of the Simulation backwards if the direction of the Simulation is backwards.
                if (Simulation.Speed < 0)
                {
                    Simulation.Run(300, true, Simulation.CurrentFrame);
                    Simulation.CurrentFrame = Simulation.MaximumSpeed-1;
                }
                else
                {
                    // Calculates more frames of the Simulation going forwards if the direction of the Simulation is forwards.
                    Simulation.Run(300, false, Simulation.CurrentFrame);
                    Simulation.CurrentFrame = 0;
                }
                Simulation.Changed = false;
            }

            // Method that checks all keyboard and mouse states
            HandleKeyboard();

        }

        private void HandleKeyboard()
        {
            // Gets current states of keyboard and mouse (key presses, clicks etc.)
            var mouseState = Mouse.GetState();
            var keyState = Keyboard.GetState();

            // Only uses the keyboard and mouse states if the MainWindow currently has focus
            if (Focused)
            {
                // Compares the old mouse scroll position to the new mouse scroll position.
                // If there is a difference, zoom in/out of the simulation accordingly.
                if (Simulation.OldMouseState.Scroll.Y != mouseState.Scroll.Y)
                {
                    Simulation.Camera.Zoom -= Simulation.Camera.ZoomModifier * (mouseState.Scroll.Y - Simulation.OldMouseState.Scroll.Y);
                }

                // Checks to see if the left mouse button is currently held down, and if it was previously held down.
                if (mouseState.IsButtonDown(MouseButton.Left))
                {
                    if (Simulation.OldMouseState.IsButtonDown(MouseButton.Left))
                    {
                        // Changes the camera position X and Y values based on the difference in mouse positions between last run and this one.
                        Simulation.Camera.XVal += 0.01f * (mouseState.X - Simulation.OldMouseState.X);
                        Simulation.Camera.YVal += 0.01f * (Simulation.OldMouseState.Y - mouseState.Y);
                    }
                }

                // Closes the simulation if the Escape key is pressed.
                if (keyState.IsKeyDown(Key.Escape))
                {
                    Exit();
                }

                // Reduces the speed if the left arrow key is pressed.
                if (keyState.IsKeyDown(Key.Left))
                {
                    Simulation.Speed = Simulation.Speed <= -Simulation.MaximumSpeed ? -Simulation.MaximumSpeed : Simulation.Speed - 1;
                }

                // Increases the speed if the right arrow key is pressed.
                if (keyState.IsKeyDown(Key.Right))
                {
                    Simulation.Speed = Simulation.Speed >= Simulation.MaximumSpeed ? Simulation.MaximumSpeed : Simulation.Speed + 1;
                }

                // Increases the Camera X-value when the S key is pressed.
                if (keyState.IsKeyDown(Key.S))
                {
                    Simulation.Camera.XVal += 0.01;
                }

                // Reduces the Camera X-value when the W key is pressed.
                if (keyState.IsKeyDown(Key.W))
                {
                    Simulation.Camera.XVal -= 0.01;
                }

                // Increases the Camera Y-value when the A key is pressed.
                if (keyState.IsKeyDown(Key.A))
                {
                    Simulation.Camera.YVal += 0.01;
                }

                // Reduces the Camera Y-value when the D key is pressed.
                if (keyState.IsKeyDown(Key.D))
                {
                    Simulation.Camera.YVal -= 0.01;
                }

                // Resets the simulation if the R key is pressed.
                if (keyState.IsKeyDown(Key.R))
                {
                    ResetSim();
                }

                // Changes the focus of the simulation (to one lower down the list) if the comma key is pressed.
                if (keyState.IsKeyDown(Key.Comma))
                {
                    if (!Simulation.OldKeyState.IsKeyDown(Key.Comma))
                    {
                        Simulation.Camera.Focus -= 1;
                        if (Simulation.Camera.Focus < 0)
                            Simulation.Camera.Focus = 0;
                    }
                }

                // Changes the focus of the simulation (to one higher up the list) if the period key is pressed.
                if (keyState.IsKeyDown(Key.Period))
                {
                    if (!Simulation.OldKeyState.IsKeyDown(Key.Period))
                    {
                        Simulation.Camera.Focus += 1;
                        if (Simulation.Camera.Focus >= Simulation.PlanetarySystem.Objects.Count)
                            Simulation.Camera.Focus -= 1;
                    }
                }

                // Toggles play/pause when the space key is pressed.
                if (keyState.IsKeyDown(Key.Space))
                {
                    if (!Simulation.OldKeyState.IsKeyDown(Key.Space))
                    {
                        Simulation.Paused = !Simulation.Paused;
                    }
                }

                // Sets X and Y value limits (-0.49 to 0.49).
                if (Simulation.Camera.YVal > 0.49) Simulation.Camera.YVal = 0.49;
                if (Simulation.Camera.YVal < -0.49) Simulation.Camera.YVal = -0.49;

                // Sets Zoom limits (10000 to 10000000).
                if (Simulation.Camera.Zoom < 10000) Simulation.Camera.Zoom = 10000;
                if (Simulation.Camera.Zoom > 10000000) Simulation.Camera.Zoom = 10000000;

                var pi180 = Math.PI;
                Vector3 initialPosition;
                // Checks to see if the camera should be focused on a fixed position. If it shouldn't, focus on the currently focused object. Otherwise, focus on a Vector3 co-ordinate object.
                if (!Simulation.Camera.Fixed)
                    initialPosition = Simulation.PlanetarySystem.Objects[Simulation.Camera.Focus].RenderPosition;
                else
                    initialPosition = new Vector3(0, 0, 0);

                // Uses Vector maths and the previously set Camera X and Y values to create a "trackball" effect for the camera pan around the focused co-ordinates.
                Simulation.Camera.Position.X = initialPosition.X + (float)Simulation.Camera.Zoom * (float)(Math.Sin(Simulation.Camera.XVal * pi180) * Math.Cos(Simulation.Camera.YVal * pi180));
                Simulation.Camera.Position.Y = initialPosition.Y + (float)Simulation.Camera.Zoom * (float)(Math.Sin(Simulation.Camera.YVal * pi180));
                Simulation.Camera.Position.Z = initialPosition.Z + (float)Simulation.Camera.Zoom * -(float)(Math.Cos(Simulation.Camera.XVal * pi180) * Math.Cos(Simulation.Camera.YVal * pi180));

                // Sets the old key and mouse state variables to be the current key and mouse state variables, for next time.
                Simulation.OldKeyState = keyState;
                Simulation.OldMouseState = mouseState;
            }
        }

        // This method is  triggered 60 times a second.
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (!Simulation.PlanetarySystem.Objects.Any())
                return;

            // Sets the title of the window to be the name of the Simulation.
            Title = $"SolarCore: {Simulation.PlanetarySystem.Name}";
            
            // Clears the screen from the last frame.
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Checks to see if the camera is fixed.
            // If it isn't, set the camera focus to be the currently focused SolarObject in the Simulation.
            if (!Simulation.Camera.Fixed)
            {
                if (Simulation.PlanetarySystem.Objects.Any())
                Simulation.Camera.LookAt = Simulation.PlanetarySystem.Objects[Simulation.Camera.Focus].RenderPosition;
            }

            // Builds a world space to camera space matrix. 
            // Generates a camera view relative to the position of the camera and the focus of the camera.
            var translationMatrix = Matrix4.LookAt(Simulation.Camera.Position, Simulation.Camera.LookAt, Vector3.UnitY);

            // Calculate more frames of the simulation (either going forwards or backwards).
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

            // Foreach loop iterates through each object in the Simulation
            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                // Low level OpenGL methods bind the previously created projection matrix to the buffer.
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);
                
                // If the simulation isn't paused, change the currently rendered location for the object to the next frame andd add a new LineObject at the same location.
                if (!Simulation.Paused)
                {
                    obj.RenderPosition = obj.Positions[Simulation.CurrentFrame] / Simulation.Scale;
                    if (obj.TrailsActive)
                    {
                        LineObjects.Add(new LineObject(obj.RenderPosition, obj.TrailColour, obj.TrailLength, obj.Radius / (Simulation.TrailScale * 10)));
                    }
                }

                // Render the SolarObject, scaled down by TrailScale and translated with translationMatrix.
                obj.Render(translationMatrix, Simulation.TrailScale);
            }
            
            // For loop iterates through each LineObject in the Simulation.
            for (int i = 0; i < LineObjects.Count; i++)
            {
                // If the simulation isn't paused, reduce the amount of time until the currently selected LineObject is deleted.
                if (!Simulation.Paused)
                {
                    LineObjects[i].DeleteBy -= Math.Abs(Simulation.Speed);
                }

                // Low level OpenGL methods bind the previously created projection matrix to the buffer.
                GL.UseProgram(_program);
                GL.UniformMatrix4(20, false, ref _projectionMatrix);

                // Render the LineObject, translated with translationMatrix.
                LineObjects[i].Render(translationMatrix);
            }
            
            // Low level OpenGL methods specify the diamater of rasterised points, and then swaps the front and back buffers (presenting the rendered scene to the user).
            GL.PointSize(10);
            SwapBuffers();

            // If the simulation isn't paused, advance the simulation by the current speed value. 
            // If at the beginning of the simulation, stay on frame 0.
            if (!Simulation.Paused)
            {
                Simulation.CurrentFrame += Simulation.Speed;
                if (Simulation.CurrentFrame < 0) Simulation.CurrentFrame = 0;
            }
        }

        // Method to reset the Simulation, clearing and disposing of all LineObject objects and their information stored in the buffer.
        // Also unpauses the Simulation, and sets the CurrentFrame value to the beginning.
        public void ResetSim()
        {
            LineObjects.ForEach(x => x.Object.Dispose());
            LineObjects.Clear();

            Simulation.CurrentFrame = 0;
            Simulation.Paused = false;
        }

        // Sets the _projectionMatrix Matrix4 value that dictates the field of view of the camera in all simulations.
        private void CreateProjection()
        {
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(60 * ((float)Math.PI / 180f), (float)Width / Height, 0.1f, 4000000000000000f);
        }

        // Triggered when the MainWindow screen is closed. 
        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        // Method to clear and dispose of all SolarObject and LineObject objects and their information stored in the buffer.
        // Also clears the OpenGL program from the buffer, and releases all resources previously allocated to the MainWindow screen.
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

        // Compiles the OpenGL shaders (written in C - See vertexShader.c) for later use.
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

        // This method creates an OpenGL Program object, and compiles and attaches each shader to this Program object before returning an integer that 
        // relates to the program ID in memory.
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
