using OpenTK;
using OpenTK.Input;
using SolarForms.Components.Menus;
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
        public Camera Camera = new Camera();

        public Simulation SimObject = new Simulation();

    }

    public class Camera
    {
        public float Radius = 1;
        public int Focus = 0;
        public Vector3 Position = new Vector3(0, 0, -1);
        public double XVal;
        public double YVal;
    }
}
