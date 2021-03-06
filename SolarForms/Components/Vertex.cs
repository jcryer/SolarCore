﻿using OpenTK;
using OpenTK.Graphics;

namespace SolarForms.Components
{
    // Vertex strut. Stores position and colour of a vertex.
    public struct Vertex
    {
        public const int Size = (4 + 4) * 4; 

        private readonly Vector4 _position;
        private readonly Color4 _color;

        public Vertex(Vector4 position, Color4 color)
        {
            _position = position;
            _color = color;
        }
    }
}