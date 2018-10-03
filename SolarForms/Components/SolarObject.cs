using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    class SolarObject
    {
        public int Mass;
        public int Radius;
        public int Obliquity;
        public int OrbitalSpeed;

        public Vector3 Position;
        public Vector3 Velocity;
        public RenderObject Object;

        public SolarObject(int mass, int radius, int obliquity, int orbitalSpeed, Vector3 position, Vector3 velocity)
        {
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
            Position = position;
            Velocity = velocity;
            Object = new RenderObject(new Sphere().CreateSphere(3, Color4.White));
        }

        public double GetDistance(SolarObject obj)
        {
            var x = obj.Position.X - Position.X;
            var y = obj.Position.Y - Position.Y;
            var z = obj.Position.Z - Position.Z;

            return Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
