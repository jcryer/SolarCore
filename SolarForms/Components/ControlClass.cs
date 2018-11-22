using Newtonsoft.Json;
using OpenTK;
using OpenTK.Input;
using SolarForms.Components.Menus;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SolarForms.Components
{
    public class ControlClass
    {
        public int Frame = 0;
        public int TimePeriod = 1;
        public bool Focused = false;
        public bool Paused = false;
        public MouseState OldMouseState = Mouse.GetState();
        public KeyboardState OldKeyState = Keyboard.GetState();
        public Camera Camera = new Camera() { Radius = 1};

        public Simulation SimObject = new Simulation();

        public ControlClass(Presets preset = Presets.None)
        {
            //File.WriteAllText($"SimulationData/{SimObject.Name}.json", JsonConvert.SerializeObject(SimObject));
            if (preset != Presets.None) {
                
                SimObject = JsonConvert.DeserializeObject<Simulation>(File.ReadAllText($"SimulationData/{preset.ToString()}.json"));
            }
        }
    }

    public class Camera
    {
        public float Radius = 10000f;
        public int Focus = 0;
        public Vector3 Position = new Vector3(0, 0, -1);
        public Vector3 LookAt = new Vector3(0, 0, 0);
        public double XVal;
        public double YVal;
    }
}
