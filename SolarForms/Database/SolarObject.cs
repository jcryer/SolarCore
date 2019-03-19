using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using SolarForms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SolarForms.Database
{
    public class SolarObject
    {
        [JsonIgnore]
        public int DatabaseID;
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

        [JsonIgnore]
        public Vector3 Position;

        [JsonIgnore]
        public Vector3 RenderPosition;

        [JsonIgnore]
        public Vector3 Velocity;

        public float PositionX;
        public float PositionY;
        public float PositionZ;
        public float VelocityX;
        public float VelocityY;
        public float VelocityZ;

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

        public void SetVectors()
        {
            PositionX = Position.X;
            PositionY = Position.Y;
            PositionZ = Position.Z;
            VelocityX = Velocity.X;
            VelocityY = Velocity.Y;
            VelocityZ = Velocity.Z;
        }

        public void GetVectors()
        {
            Position = new Vector3(PositionX, PositionY, PositionZ);
            Velocity = new Vector3(VelocityX, VelocityY, VelocityZ);
        }
        public SolarObject()
        {
            Positions = new List<Vector3>();
            Velocities = new List<Vector3>();
            DatabaseID = -1;

        }
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

        public void Render(Matrix4 projectionMatrix, int trailScale)
        {
            Obj.Bind();
            var t2 = Matrix4.CreateTranslation(RenderPosition);
            var r1 = Matrix4.CreateRotationZ((float)Obliquity);

            var s = Matrix4.CreateScale((float)Radius / trailScale);
            var _modelView = r1 * s * t2 * projectionMatrix;
            GL.UniformMatrix4(21, false, ref _modelView);
            Obj.Render();
        }
    }
}
