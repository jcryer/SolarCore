using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    public class LineObject
    {
        public double Radius;
        public Vector3 Position;
        public RenderObject Object;
        public DateTime DeleteBy;

        public LineObject(Vector3 position, Color4 colour, DateTime deleteBy, double radius = 1)
        {
            Position = position;
            Object = new RenderObject(new Sphere().CreateSphere(2, colour));
            DeleteBy = deleteBy;
            Radius = radius;
        }

        public void Render(Matrix4 projectionMatrix)
        {
            Object.Bind();
            var t = Matrix4.CreateTranslation(Position);

            var s = Matrix4.CreateScale(0.01f * (float)Radius);
            var _modelView = s * t * projectionMatrix;
            GL.UniformMatrix4(21, false, ref _modelView);
            Object.Render();
        }

    }
}
