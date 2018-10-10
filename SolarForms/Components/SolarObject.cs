using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    public class SolarObject
    {
        private const double GRAV = 6.67408e-11;
      //  private const double GRAV = 1;

        public int Mass;
        public int Radius;
        public int Obliquity;
        public int OrbitalSpeed;

        public Vector3 Position;
        public Vector3 Velocity;
        public RenderObject Object;


        public SolarObject(int mass, int radius, int obliquity, int orbitalSpeed, Vector3 position, Vector3 velocity, Color4 colour)
        {
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
            Position = position;
            Velocity = velocity;
            Object = new RenderObject(new Sphere().CreateSphere(3, colour));
        }

        public void Render (ICamera camera)
        {
            Object.Bind();
            var t2 = Matrix4.CreateTranslation(Position);
            var r1 = Matrix4.CreateRotationZ(Obliquity);

            var s = Matrix4.CreateScale(0.01f * Radius);
            var _modelView = r1 * s * t2 * camera.LookAtMatrix;
            GL.UniformMatrix4(21, false, ref _modelView);
            Object.Render();
        }
        
    }
}
