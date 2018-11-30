﻿using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using SolarForms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Database
{
    public class SolarObject
    {
        public int Id;
        public string Name;
        public double Mass;
        public double Radius;
        public double Obliquity;
        public double OrbitalSpeed;
        public bool TrailsActive;
        public int TrailLength;
        public Color4 TrailColour;
        public Color4 ObjectColour;
        public Vector3 Position;
        public Vector3 Velocity;
        public RenderObject Obj;

        public List<Vector3> Positions;
        public SolarObject(int id, string name, double mass, double radius, double obliquity, double orbitalSpeed, bool trailsActive, int trailLength, Color4 trailColour, Color4 objectColour, Vector3 position, Vector3 velocity)
        {
            Id = id;
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
            Positions = new List<Vector3>();

        }

        public SolarObject(string name, double mass, double radius, double obliquity, double orbitalSpeed)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
        }
        public void Render(Matrix4 projectionMatrix)
        {
            Obj.Bind();
            var t2 = Matrix4.CreateTranslation(Position);
            var r1 = Matrix4.CreateRotationZ((float)Obliquity);

            var s = Matrix4.CreateScale((float)Radius);
            var _modelView = r1 * s * t2 * projectionMatrix;
            GL.UniformMatrix4(21, false, ref _modelView);
            Obj.Render();
        }
    }
}
