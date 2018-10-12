using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SolarForms.Components
{
    public class SolarObject
    {
        private const double GRAV = 6.67408e-11;

        public double Mass;
        public double Radius;
        public double Obliquity;
        public double OrbitalSpeed;

        public Vector3 Position;
        public Vector3 Velocity;
        public RenderObject Object;
        public Color4 Colour;
        public SolarObject(double mass, double radius, double obliquity, double orbitalSpeed, Vector3 position, Vector3 velocity, Color4 colour)
        {
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
            Position = position;
            Velocity = velocity;
            Colour = colour;
            Object = new RenderObject(new Sphere().CreateSphere(3, colour));
        }

        public void Render (Matrix4 projectionMatrix)
        {
            Object.Bind();
            var t2 = Matrix4.CreateTranslation(Position);
            var r1 = Matrix4.CreateRotationZ((float)Obliquity);

            var s = Matrix4.CreateScale(0.01f * (float)Radius);
            var _modelView = r1 * s * t2 * projectionMatrix; 
            GL.UniformMatrix4(21, false, ref _modelView);
            Object.Render();
        }
    }
}