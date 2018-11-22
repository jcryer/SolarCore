using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SolarForms.Components
{
    public class SolarObject
    {
        public string Name;
        public double Mass;
        public double Radius;
        public double Obliquity;
        public double OrbitalSpeed;
        public Color4 Colour;

        private float px;
        private float py;
        private float pz;
        private float vx;
        private float vy;
        private float vz;

        [JsonIgnore]
        public RenderObject Object;

        [JsonIgnore]
        public Vector3 Position
        {
            get
            {
                return new Vector3(px, py, pz);
            }
            set
            {
                px = value.X;
                py = value.Y;
                pz = value.Z;
            }
        }

        [JsonIgnore]
        public Vector3 Velocity {
            get
            {
                return new Vector3(vx, vy, vz);
            }
            set
            {
                vx = value.X;
                vy = value.Y;
                vz = value.Z;
            }
        }
        [JsonConstructor]
        public SolarObject(string name, double mass, double radius, double obliquity, double orbitalSpeed, Color4 colour, float px, float py, float pz, float vx, float vy, float vz)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
            Colour = colour;
            this.px = px;
            this.py = py;
            this.pz = pz;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
            Object = new RenderObject(new Sphere().CreateSphere(3, colour));
        }

        public SolarObject(string name, double mass, double radius, double obliquity, double orbitalSpeed, Vector3 position, Vector3 velocity, Color4 colour)
        {
            Name = name;
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

            var s = Matrix4.CreateScale( (float)Radius);
            var _modelView = r1 * s * t2 * projectionMatrix; 
            GL.UniformMatrix4(21, false, ref _modelView);
            Object.Render();
        }
    }
}