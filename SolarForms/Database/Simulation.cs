using OpenTK;
using OpenTK.Input;
using SolarForms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Database
{
    public class Simulation
    {
        public PlanetarySystem PlanetarySystem;
        public int Speed;
        public int SpeedModifier;
        public MouseState OldMouseState = Mouse.GetState();
        public KeyboardState OldKeyState = Keyboard.GetState();
        public int CurrentFrame;
        public Camera Camera;
        public bool Paused;
        public int Scale;

        public Simulation()
        {
            PlanetarySystem = new PlanetarySystem();
        }

        public void Run(int frames)
        {
            while (PlanetarySystem.Objects.First().Positions.Count < frames)
            {
                List<AggregateObject> response = new List<AggregateObject>();
                foreach (var obj in PlanetarySystem.Objects)
                {
                    response.Add(GravityMethods.RecalculateValues(obj, PlanetarySystem.Objects.Where(x => x != obj).ToList(), Speed * SpeedModifier));
                }

                foreach (var x in response)
                {
                    var currentObject = PlanetarySystem.Objects.First(y => y.Obj == x.Object.Obj);
                    currentObject.Velocity = x.Velocity;
                    currentObject.Position = x.Position;
                    currentObject.Positions.Add(x.Position);
                }
            }
        }
    }

    public class Camera
    {
        public double Zoom;
        public double ZoomModifier;
        public int Focus;
        public Vector3 Position = new Vector3(0, 0, -1);
        public Vector3 LookAt = new Vector3(0, 0, 0);
        public double XVal;
        public double YVal;
        public bool Fixed;

        public Camera(double zoom, double zoomModifier, int focus, bool @fixed)
        {
            Zoom = zoom;
            ZoomModifier = zoomModifier;
            Focus = focus;
            Fixed = @fixed;
        }
    }
}
