using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarForms.Components
{
    static class GravityMethods
    {
        private const double GRAV = 6.67408e-11;

        public static double GetDistance(SolarObject obj1, SolarObject obj2)
        {
            var x = obj1.Position.X - obj2.Position.X;
            var y = obj1.Position.Y - obj2.Position.Y;
            var z = obj1.Position.Z - obj2.Position.Z;

            return Math.Sqrt(x * x + y * y + z * z);
        }

        public static double GetDistance(LineObject obj1, LineObject obj2)
        {
            var x = obj1.Position.X - obj2.Position.X;
            var y = obj1.Position.Y - obj2.Position.Y;
            var z = obj1.Position.Z - obj2.Position.Z;

            return Math.Sqrt(x * x + y * y + z * z);
        }

        public static double CalculateAcceleration(SolarObject of, SolarObject by)
        {
            return (GRAV * by.Mass * 10) / (Math.Pow(GetDistance(of, by), 2));
        }

        public static Vector3 GetPositionDifference(SolarObject obj1, SolarObject obj2)
        {

            return new Vector3(obj1.Position.X - obj2.Position.X, obj1.Position.Y - obj2.Position.Y, obj1.Position.Z - obj2.Position.Z);
        }

        public static Vector3 GetUnitVector(Vector3 diff)
        {
            float multiply = (float)Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y + diff.Z * diff.Z);
            return new Vector3(diff.X / multiply, diff.Y / multiply, diff.Z / multiply);
        }

        public static Vector3 GetAccelerationVector(Vector3 unitVector, float acc)
        {
            return new Vector3(unitVector.X * acc, unitVector.Y * acc, unitVector.Z * acc);
        }

        public static Vector3 GetVelocityVector(SolarObject obj, Vector3 accVector, float timePeriod)
        {
            return new Vector3(obj.Velocity.X + (accVector.X * timePeriod), obj.Velocity.Y + (accVector.Y * timePeriod), obj.Velocity.Z + (accVector.Z * timePeriod));
        }

        public static Vector3 GetPositionVector(SolarObject obj, Vector3 velVector, float timePeriod)
        {
            return new Vector3(obj.Position.X + (velVector.X * timePeriod), obj.Position.Y + (velVector.Y * timePeriod), obj.Position.Z + (velVector.Z * timePeriod));
        }

        public static AggregateObject RecalculateValues(SolarObject main, List<SolarObject> all, float timePeriod)
        {
            all = all.Where(x => x != main).ToList();
            Vector3 totalAcceleration = new Vector3(0, 0, 0);
            foreach (var obj in all)
            {
                var acc = CalculateAcceleration(main, obj);
                var posDiffVector = GetPositionDifference(obj, main);
                var posDiffUnitVector = GetUnitVector(posDiffVector);
                var accVector = GetAccelerationVector(posDiffUnitVector, (float)acc);
                totalAcceleration += accVector;
            }
          
            var velVector = GetVelocityVector(main, totalAcceleration, timePeriod);

            var posVector = GetPositionVector(main, velVector, timePeriod);
            return new AggregateObject(main, velVector, posVector);
        }

    }

    public class AggregateObject
    {
        public SolarObject Object;
        public Vector3 Velocity;
        public Vector3 Position;

        public AggregateObject(SolarObject obj, Vector3 velocity, Vector3 position)
        {
            Object = obj;
            Velocity = velocity;
            Position = position;
        }
    }
}
