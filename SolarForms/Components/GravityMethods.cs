using OpenTK;
using SolarForms.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarForms.Components
{
    static class GravityMethods
    {
        // The Universal Gravitational Constant (G)
        private const double GRAV = 6.67408e-11; 

        
        public static double GetDistance(SolarObject obj1, SolarObject obj2)
        {
            // Calculates difference between two X co-ordinates
            var x = obj1.Position.X - obj2.Position.X;
            // Calculates difference between two Y co-ordinates
            var y = obj1.Position.Y - obj2.Position.Y;
            // Calculates difference between two Z co-ordinates
            var z = obj1.Position.Z - obj2.Position.Z;

            // Uses the Pythagoras Theorem to calculate the total scalar distance between Obj1's position and Obj2's position
            return Math.Sqrt(x * x + y * y + z * z); 
        }

        public static double CalculateAcceleration(SolarObject of, SolarObject by)
        {
            // Gets distance between two objects
            var distance = GetDistance(of, by); 
           // Uses the Gravitational Acceleration formula to determine the acceleration of one object due to another object (a = GM/r^2)
            return (GRAV * by.Mass) / (Math.Pow(distance, 2)); 
        }

        public static Vector3 GetPositionDifference(Vector3 vec1, Vector3 vec2)
        {
            // Returns the difference between two vectors in vector form
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z); 
        }

        public static Vector3 GetUnitVector(Vector3 diff)
        {
            // A unit vector is a vector which has a magnitude of 1.
            float multiply = (float)Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y + diff.Z * diff.Z); 
            // So, each co-ordinate is divided by the multiplier, meaning that the total magnitude of this resultant vector will be 1.
            return new Vector3(diff.X / multiply, diff.Y / multiply, diff.Z / multiply);
        }

        public static Vector3 GetAccelerationVector(Vector3 unitVector, float acc)
        {
            // Multiplies each co-ordinate of the unit position vector by the given acceleration value.
            return new Vector3(unitVector.X * acc, unitVector.Y * acc, unitVector.Z * acc);
        }

        public static Vector3 GetVelocityVector(SolarObject obj, Vector3 accVector, float timePeriod)
        {
            // Change in velocity is acceleration multiplied by time, and so each velocity vector is increased by the relevant acceleration vector multiplied by the time period
            return new Vector3(obj.Velocity.X + (accVector.X * timePeriod), obj.Velocity.Y + (accVector.Y * timePeriod), obj.Velocity.Z + (accVector.Z * timePeriod));
        }
        
        public static Vector3 GetPositionVector(SolarObject obj, Vector3 velVector, float timePeriod)
        {
            // Change in position is velocity multiplied by time, and so each position vector is increased by the relevant velocity vector multiplied by the time period
            return new Vector3(obj.Position.X + (velVector.X * timePeriod), obj.Position.Y + (velVector.Y * timePeriod), obj.Position.Z + (velVector.Z * timePeriod));
        }

        public static AggregateObject RecalculateValues(SolarObject main, List<SolarObject> all, float timePeriod)
        {
            // A list of all objects other than the object being calculated for is formed (as calculating an acceleration of an object due to itself is unnecessary)
            all = all.Where(x => x != main).ToList();
            // Initial acceleration is 0. This value is added to throughout this method.
            Vector3 totalAcceleration = new Vector3(0, 0, 0);
            // Iterate through each object in the "all" list of SolarObjects.
            foreach (var obj in all)
            {
                // Acceleration of the main object due to the object currently being iterated through is calculated
                var acc = CalculateAcceleration(main, obj);
                // The position difference between the main object and the object currently being iterated through is calculated
                var posDiffVector = GetPositionDifference(obj.Position, main.Position);
                // This position difference vector is converted to a unit position vector
                var posDiffUnitVector = GetUnitVector(posDiffVector);
                // The unit position vector is formed into an acceleration vector
                var accVector = GetAccelerationVector(posDiffUnitVector, (float)acc);
                // Vector addition occurs here, adding the three-dimensional acceleration vector to the "totalAcceleration" value set before the for loop.
                // As the for loop iterated through, accelerations caused by various objects may cancel each other out, 
                // and a resultant acceleration vector will be reached at the end of the for loop.
                totalAcceleration += accVector;
            }
            // The resultant acceleration vector is used to calculate a resultant velocity vector
            var velVector = GetVelocityVector(main, totalAcceleration, timePeriod);
            // The resultant velocity vector is used to calculate a resultant position for the object after the time elapsed (timePeriod)
            var posVector = GetPositionVector(main, velVector, timePeriod);

            // This calculation method is not perfect, as it is mathematically impossible to create a model that perfectly represents 
            // three or more bodies affecting each other at all times.
            // Therefore, I am using the best method available to me, which is calculating the positions and velocities in "jumps" - time periods. 
            // The lower the time period, the more accurate the simulation is.

            // The resultant velocity and position vectors are returned along with the SolarObject itself.
            return new AggregateObject(main, velVector, posVector); 
        }
    }

    // Simple object created to be able to return three values in a format that can then be worked with more easily later on.
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
