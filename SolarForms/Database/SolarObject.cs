using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using SolarForms.Components;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SolarForms.Database
{
    public class SolarObject
    {
        // All fields flagged with [JsonIgnore] are only used within the context of the running simulation.
        // Therefore, they have been marked so they aren't exported with the rest of the object if it were exported to a file.

        [JsonIgnore]
        public int DatabaseID;
        [JsonIgnore]
        public Vector3 Position;
        [JsonIgnore]
        public Vector3 RenderPosition;
        [JsonIgnore]
        public Vector3 Velocity;
        [JsonIgnore]
        public RenderObject Obj;
        [JsonIgnore]
        public Vector3 InitialPosition;
        [JsonIgnore]
        public Vector3 InitialVelocity;
        [JsonIgnore]
        public List<Vector3> Velocities;
        [JsonIgnore]
        public List<Vector3> Positions;

        public int ID;
        public string Name = "";
        public double Mass;
        public double Radius;
        public double Obliquity;
        public double OrbitalSpeed;
        public bool TrailsActive;
        public int TrailLength;
        public Color4 TrailColour;
        public Color4 ObjectColour;

        // The Newtonsoft.Json library used to convert C# class objects into json strings cannot handle OpenTK Vector3 objects.
        // As such, before a file export the position and velocity vectors are saved into six individual floats - see SetVectors().
        public float PositionX;
        public float PositionY;
        public float PositionZ;
        public float VelocityX;
        public float VelocityY;
        public float VelocityZ;

        public void SetVectors()
        {
            PositionX = Position.X;
            PositionY = Position.Y;
            PositionZ = Position.Z;
            VelocityX = Velocity.X;
            VelocityY = Velocity.Y;
            VelocityZ = Velocity.Z;
        }

        // Similarly, upon loading a simulation from a previously exported file, the six individual floats are converted back to two OpenTK Vector3 objects.
        public void GetVectors()
        {
            Position = new Vector3(PositionX, PositionY, PositionZ);
            Velocity = new Vector3(VelocityX, VelocityY, VelocityZ);
        }

        // In some cases, new SolarObjects are defined (such as adding a new object to a simulation). In these cases, this constructor is required.
        public SolarObject()
        {
            Positions = new List<Vector3>();
            Velocities = new List<Vector3>();
            DatabaseID = -1;
        }

        // In most cases, pre-existing Object records are being pulled from the database and stored in the class model. 
        // In these cases, this constructor is required.
        public SolarObject(string name, double mass, double radius, double obliquity, double orbitalSpeed, int databaseId = -1)
        {
            DatabaseID = databaseId;
            Name = name;
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
            Positions = new List<Vector3>();
            Velocities = new List<Vector3>();
        }

        // In other cases, pre-existing Object records as well as all related records (the relevant InitialValues and ObjectView records)
        // are being pulled from the database and stored in the class model. 
        // In these cases, this constructor is required.
        public SolarObject(string name, double mass, double radius, double obliquity, double orbitalSpeed, bool trailsActive, int trailLength, Color4 trailColour, Color4 objectColour, Vector3 position, Vector3 velocity)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
            TrailsActive = trailsActive;
            TrailLength = trailLength;
            TrailColour = trailColour;
            ObjectColour = objectColour;
            Position = position;
            Velocity = velocity;
            Velocities = new List<Vector3>();
            Positions = new List<Vector3>();
            DatabaseID = -1;
        }

        public void Render(Matrix4 projectionMatrix, int trailScale)
        {
            // Low level OpenGL method to bind the current vertex array object.
            Obj.Bind();

            // Matrix4 translation of the object to its new position in the simulation 
            // (based on its calculated position, scaled down using a consistent scale factor).
            var t2 = Matrix4.CreateTranslation(RenderPosition);

            // Matrix4 rotation of the object to its correct obliquity.
            var r1 = Matrix4.CreateRotationZ((float)Obliquity);

            // Matrix4 scaling of the object to its correct relative size.
            var s = Matrix4.CreateScale((float)Radius / trailScale);

            // Matrix4 multiplication combining the previous set of translations/rotations/scalings into one.
            var _modelView = r1 * s * t2 * projectionMatrix;
            
            // Low level OpenGL method to load the created _modelView variable into the OpenGL buffer before then rendering the object.
            GL.UniformMatrix4(21, false, ref _modelView);
            Obj.Render();
        }
    }
}
