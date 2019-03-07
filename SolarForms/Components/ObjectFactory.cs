using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    public class ObjectFactory
    {
        /*
        public static TexturedVertex[] CreateTexturedCharacter()
        {
            float h = 1;
            float w = RenderText.CharacterWidthNormalized;
            float side = 1f / 2f; // half side - and other half

            TexturedVertex[] vertices =
            {
        new TexturedVertex(new Vector4(-side, -side, side, 1.0f),    new Vector2(0, h)),
        new TexturedVertex(new Vector4(side, -side, side, 1.0f),     new Vector2(w, h)),
        new TexturedVertex(new Vector4(-side, side, side, 1.0f),     new Vector2(0, 0)),
        new TexturedVertex(new Vector4(-side, side, side, 1.0f),     new Vector2(0, 0)),
        new TexturedVertex(new Vector4(side, -side, side, 1.0f),     new Vector2(w, h)),
        new TexturedVertex(new Vector4(side, side, side, 1.0f),      new Vector2(w, 0)),
    };
            return vertices;
        }
        */

        public static Vertex[] CreateSolidCube(float side, Color4 color)
        {
            side = side / 2f; // half side - and other half
            Vertex[] vertices =
            {
                new Vertex(new Vector4(-side, -side, -side, 1.0f),   color),
                new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
                new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
                new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
                new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
                new Vertex(new Vector4(-side, side, side, 1.0f),     color),

                new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
                new Vertex(new Vector4(side, side, -side, 1.0f),     color),
                new Vertex(new Vector4(side, -side, side, 1.0f),     color),
                new Vertex(new Vector4(side, -side, side, 1.0f),     color),
                new Vertex(new Vector4(side, side, -side, 1.0f),     color),
                new Vertex(new Vector4(side, side, side, 1.0f),      color),

                new Vertex(new Vector4(-side, -side, -side, 1.0f),   color),
                new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
                new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
                new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
                new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
                new Vertex(new Vector4(side, -side, side, 1.0f),     color),

                new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
                new Vertex(new Vector4(-side, side, side, 1.0f),     color),
                new Vertex(new Vector4(side, side, -side, 1.0f),     color),
                new Vertex(new Vector4(side, side, -side, 1.0f),     color),
                new Vertex(new Vector4(-side, side, side, 1.0f),     color),
                new Vertex(new Vector4(side, side, side, 1.0f),      color),

                new Vertex(new Vector4(-side, -side, -side, 1.0f),   color),
                new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
                new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
                new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
                new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
                new Vertex(new Vector4(side, side, -side, 1.0f),     color),

                new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
                new Vertex(new Vector4(side, -side, side, 1.0f),     color),
                new Vertex(new Vector4(-side, side, side, 1.0f),     color),
                new Vertex(new Vector4(-side, side, side, 1.0f),     color),
                new Vertex(new Vector4(side, -side, side, 1.0f),     color),
                new Vertex(new Vector4(side, side, side, 1.0f),      color),
            };
            return vertices;
        }
    }
}
