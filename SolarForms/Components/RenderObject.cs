using OpenTK.Graphics.OpenGL;
using System;

namespace SolarForms.Components
{
    public class RenderObject : IDisposable
    {
        private bool _initialized;
        private readonly int _vertexArray;
        private readonly int _buffer;
        private readonly int _verticeCount;

        // Method to setup the RenderObject as a renderable object for the rest of the simulation, given a Vertex Array.
        public RenderObject(Vertex[] vertices)
        {
            _verticeCount = vertices.Length;
            _vertexArray = GL.GenVertexArray();
            _buffer = GL.GenBuffer();

            // Low level OpenGL method that binds the vertex array to a buffer.
            GL.BindVertexArray(_vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexArray);

            // Create Vertex buffer, setting up the size required and passing it the Vertex array that specifies the IcoSphere.
            GL.NamedBufferStorage(_buffer, Vertex.Size * vertices.Length, vertices, BufferStorageFlags.MapWriteBit); 

            // Low level OpenGL methods that request that the vertex array is rendered with a certain shader (Shader 0: see vertexShader.c)
            GL.VertexArrayAttribBinding(_vertexArray, 0, 0);
            GL.EnableVertexArrayAttrib(_vertexArray, 0);
            GL.VertexArrayAttribFormat(_vertexArray, 0, 4, VertexAttribType.Float, false, 0);

            // Low level OpenGL methods that request that the vertex array is rendered with a certain shader (Shader 1: see vertexShader.c)
            GL.VertexArrayAttribBinding(_vertexArray, 1, 0);
            GL.EnableVertexArrayAttrib(_vertexArray, 1);
            GL.VertexArrayAttribFormat(_vertexArray, 1, 4, VertexAttribType.Float, false, 16);
            
            // Links the vertex array in memory to the previously setup buffer in memory
            GL.VertexArrayVertexBuffer(_vertexArray, 0, _buffer, IntPtr.Zero, Vertex.Size);
            _initialized = true;
        }

        // Method that binds the current vertex array object to a buffer.
        public void Bind()
        {
            GL.BindVertexArray(_vertexArray);
        }

        // Method that triggers a render event of the RenderObject to the Simulation window.
        public void Render()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, _verticeCount);
        }

        // Method that disposes of the RenderObject and all of its information from the buffers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Method that disposes of the RenderObject and all of its information from the buffers.
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_initialized)
                {
                    GL.DeleteVertexArray(_vertexArray);
                    GL.DeleteBuffer(_buffer);
                    _initialized = false;
                }
            }
        }
    }
}
