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
        // All fields flagged with [JsonIgnore] are only used within the context of the running simulation.
        // Therefore, they have been marked so they aren't exported with the rest of the simulation if it were exported to a file.

        [JsonIgnore]
        public int DatabaseID;
        [JsonIgnore]
        public MouseState OldMouseState = Mouse.GetState();
        [JsonIgnore]
        public KeyboardState OldKeyState = Keyboard.GetState();
        [JsonIgnore]
        public int CurrentFrame;
        [JsonIgnore]
        public bool Paused;
        [JsonIgnore]
        public bool Changed = false;
        [JsonIgnore]
        public bool FromFile = false;

        public Camera Camera;
        public PlanetarySystem PlanetarySystem;
        public int Speed;
        public int SpeedModifier = 1;
        public int Scale;
        public int TrailScale;
        public int MaximumSpeed = 100;

        // Simulation constructor
        public Simulation()
        {
            PlanetarySystem = new PlanetarySystem();
            DatabaseID = -1;
        }

        // Method to calculate a certain number of frames of the simulation, for all objects within the Simulation object.
        public void Run(int frames, bool backwards, int frameNum)
        {
            // Foreach statement iterates through each SolarObject in the Simulation
            foreach (var obj in PlanetarySystem.Objects)
            {
                if (!obj.Positions.Any())
                    break;
                // Sets the SolarObject's "Position" Vector3 to its current position (from the "Positions" List of Vector3 s)
                obj.Position = obj.Positions[frameNum];
                // Sets the SolarObject's "Velocity" Vector3 to its current velocity (from the "Velocities" List of Vector3 s)
                obj.Velocity = obj.Velocities[frameNum];
            }

            // Number of frames in the simulation before additional frames are calculated.
            int initialNumber = PlanetarySystem.Objects.First().Positions.Count;

            // While loop that will iterate until "int frames" number of extra frames have been generated.
            while (PlanetarySystem.Objects.First().Positions.Count < frames + initialNumber)
            {
                List<AggregateObject> response = new List<AggregateObject>();

                // Foreach statement iterates through each SolarObject in the Simulation
                // This calculates the resultant velocities and positions of each object in the simulation due to every other object in the simulation.
                // It is stored into a list initially (rather than updating the relevant object immediately),
                // in order to prevent one object from being recalculated multiple times.
                foreach (var obj in PlanetarySystem.Objects)
                {
                    response.Add(GravityMethods.RecalculateValues(obj, PlanetarySystem.Objects.Where(x => x != obj).ToList(), SpeedModifier));
                }

                // Foreach statement iterates through each resultant velocity and position of each object in the simulation.
                // It updates the relevant object's position and velocity vectors to the newly calculated values (in order to facilitate further frame calculations)
                // It also adds the latest frame to the "Positions" and "Velocities" frame lists.
                foreach (var obj in response)
                {
                    var currentObject = PlanetarySystem.Objects.First(y => y.Obj == obj.Object.Obj);
                    currentObject.Velocity = obj.Velocity;
                    currentObject.Position = obj.Position;

                    // This simply checks whether to add the frames to the beginning or end of the frame list, depending on the direction being calculated.
                    if (backwards)
                    {
                        currentObject.Positions.Insert(0, obj.Position);
                        currentObject.Velocities.Insert(0, obj.Velocity);
                    }
                    else
                    {
                        currentObject.Positions.Add(obj.Position);
                        currentObject.Velocities.Add(obj.Velocity);
                    }
                }
            }
        }
    }

    public class Camera
    {
        // All fields flagged with [JsonIgnore] are only used within the context of the running simulation.
        // Therefore, they have been marked so they aren't exported with the rest of the simulation if it were exported to a file.

        [JsonIgnore]
        public Vector3 Position = new Vector3(0, 0, -1);
        [JsonIgnore]
        public Vector3 LookAt = new Vector3(0, 0, 0);
        [JsonIgnore]
        public double XVal;
        [JsonIgnore]
        public double YVal;

        public double Zoom;
        public double ZoomModifier;
        public int Focus;
        public bool Fixed;

        // Camera constructor
        public Camera(double zoom, double zoomModifier, int focus, bool _fixed)
        {
            Zoom = zoom;
            ZoomModifier = zoomModifier;
            Focus = focus;
            Fixed = _fixed;
        }
    }
}
