using Newtonsoft.Json;
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
        [JsonIgnore]
        public int DatabaseID;
        public PlanetarySystem PlanetarySystem;
        public int Speed;
        public int SpeedModifier = 1;
        [JsonIgnore]
        public MouseState OldMouseState = Mouse.GetState();
        [JsonIgnore]
        public KeyboardState OldKeyState = Keyboard.GetState();
        [JsonIgnore]
        public int CurrentFrame;
        public Camera Camera;
        [JsonIgnore]
        public bool Paused;
        public int Scale;
        [JsonIgnore]
        public bool Changed = false;
        public int TrailScale;
        public int MaximumSpeed = 100;
        [JsonIgnore]
        public bool FromFile = false;
        public Simulation()
        {
            PlanetarySystem = new PlanetarySystem();
            DatabaseID = -1;
        }

        public void Run(int frames, bool backwards, int frameNum)
        {
            foreach (var obj in PlanetarySystem.Objects)
            {
                if (!obj.Positions.Any())
                    break;
                obj.Position = obj.Positions[frameNum];
                obj.Velocity = obj.Velocities[frameNum];
            }
            int initialNumber = PlanetarySystem.Objects.First().Positions.Count;

            while (PlanetarySystem.Objects.First().Positions.Count < frames + initialNumber)
            {
                List<AggregateObject> response = new List<AggregateObject>();
                foreach (var obj in PlanetarySystem.Objects)
                {
                    response.Add(GravityMethods.RecalculateValues(obj, PlanetarySystem.Objects.Where(x => x != obj).ToList(), SpeedModifier));
                }

                foreach (var x in response)
                {
                    var currentObject = PlanetarySystem.Objects.First(y => y.Obj == x.Object.Obj);
                    currentObject.Velocity = x.Velocity;
                    currentObject.Position = x.Position;
                    if (backwards)
                    {
                        currentObject.Positions.Insert(0, x.Position);
                        currentObject.Velocities.Insert(0, x.Velocity);
                    }
                    else
                    {
                        currentObject.Positions.Add(x.Position);
                        currentObject.Velocities.Add(x.Velocity);
                    }
                }
            }
        }
    }

    public class Camera
    {
        public double Zoom;
        public double ZoomModifier;
        public int Focus;
        [JsonIgnore]
        public Vector3 Position = new Vector3(0, 0, -1);
        [JsonIgnore]
        public Vector3 LookAt = new Vector3(0, 0, 0);
        [JsonIgnore]
        public double XVal;
        [JsonIgnore]
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
