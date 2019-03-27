using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SolarForms.Components
{
    public class LineObject
    {
        // Radius of the LineObject
        public double Radius;
        // Position of the LineObject
        public Vector3 Position;
        // RenderObject as a child class of LineObject.
        public RenderObject Object;
        // Number of frames before the LineObject will be destroyed.
        public int DeleteBy;

        // LineObject constructor
        public LineObject(Vector3 position, Color4 colour,int deleteBy, double radius = 1)
        {
            Position = position;
            Object = new RenderObject(new Sphere().CreateSphere(2, colour));
            DeleteBy = deleteBy;
            Radius = radius;
        }

        public void Render(Matrix4 projectionMatrix)
        {
            // Low level OpenGL method to bind the current vertex array object.
            Object.Bind();

            // Matrix4 translation of the object to its new position in the simulation 
            // (based on its calculated position, scaled down using a consistent scale factor).
            var t = Matrix4.CreateTranslation(Position);
            
            // Matrix4 scaling of the object to its correct relative size.
            var s = Matrix4.CreateScale((float)Radius);

            // Matrix4 multiplication combining the previous set of translations/rotations/scalings into one.
            var _modelView = s * t * projectionMatrix;

            // Low level OpenGL method to load the created _modelView variable into the OpenGL buffer before then rendering the object.
            GL.UniformMatrix4(21, false, ref _modelView);
            Object.Render();
        }
    }
}