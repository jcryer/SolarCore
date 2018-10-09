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
        private const double GRAV = 6.67408e-11;
      //  private const double GRAV = 1;

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

        public double CalculateAcceleration(SolarObject obj)
        {
           return (GRAV * obj.Mass * 10) / (Math.Pow(GetDistance(obj), 2));
        }

        public Vector3 GetPositionDifference (SolarObject obj)
        {

            return new Vector3(obj.Position.X - Position.X, obj.Position.Y - Position.Y, obj.Position.Z - Position.Z);
        }

        public Vector3 GetUnitVector(Vector3 diff)
        {
            float multiply = (float)Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y + diff.Z * diff.Z);
            return new Vector3(diff.X / multiply, diff.Y / multiply, diff.Z / multiply);
        }

        public Vector3 GetAccelerationVector(Vector3 unitVector, float acc)
        {
            return new Vector3(unitVector.X * acc, unitVector.Y * acc, unitVector.Z * acc);
        }

        public Vector3 GetVelocityVector(Vector3 accVector, float timePeriod)
        {
            return new Vector3(Velocity.X + (accVector.X * timePeriod), Velocity.Y + (accVector.Y * timePeriod), Velocity.Z + (accVector.Z * timePeriod));
        }

        public Vector3 GetPositionVector(Vector3 velVector, float timePeriod)
        {
            return new Vector3(Position.X + (velVector.X * timePeriod), Position.Y + (velVector.Y * timePeriod), Position.Z + (velVector.Z * timePeriod));
        }

        public List<Vector3> RecalculateValues(SolarObject obj, float timePeriod)
        {
            float acc = (float)CalculateAcceleration(obj);
            var aaa = GetPositionDifference(obj);
            var accVector = GetAccelerationVector(GetUnitVector(aaa), acc);
            var velVector = GetVelocityVector(accVector, timePeriod);
            var posVector = GetPositionVector(velVector, timePeriod);
         /*   Console.WriteLine($"Acc: {accVector.X} {accVector.Y} {accVector.Z}");

            Console.WriteLine($"Pos: {posVector.X} {posVector.Y} {posVector.Z}");
            Console.WriteLine(acc);*/
            return new List<Vector3>() { velVector, posVector };
        }
    }
}
