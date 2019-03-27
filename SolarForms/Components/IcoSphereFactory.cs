using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;

namespace SolarForms.Components
{
    public class Sphere
    {
        private List<Vector3> pointList;
        private int indexInt;

        // Stores previously calculated middle points between two Vector3's, as this calculation is a very resource intensive operation.
        private Dictionary<long, int> middlePointCache = new Dictionary<long, int>();

        // In this case, a "Face" holds the three Vector3 co-ordinate sets that make up each triangular section of the outside of the sphere.
        private struct Face
        {
            public Vector3 Vertex1;
            public Vector3 Vertex2;
            public Vector3 Vertex3;

            // Face struct constructor
            public Face(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
            {
                Vertex1 = vertex1;
                Vertex2 = vertex2;
                Vertex3 = vertex3;
            }
        }
        
        // Method that generates a Vertex array resembling a sphere
        public Vertex[] CreateSphere(int recursionLevel, Color4 colour)
        {
            pointList = new List<Vector3>();
            indexInt = 0;
            var t = (float)((1.0 + Math.Sqrt(5.0)) / 2.0);
            var s = 1;

            // Sets up a regular icosahedron (three intersecting planes).
            AddVertex(new Vector3(-s, t, 0));
            AddVertex(new Vector3(s, t, 0));
            AddVertex(new Vector3(-s, -t, 0));
            AddVertex(new Vector3(s, -t, 0));

            AddVertex(new Vector3(0, -s, t));
            AddVertex(new Vector3(0, s, t));
            AddVertex(new Vector3(0, -s, -t));
            AddVertex(new Vector3(0, s, -t));

            AddVertex(new Vector3(t, 0, -s));
            AddVertex(new Vector3(t, 0, s));
            AddVertex(new Vector3(-t, 0, -s));
            AddVertex(new Vector3(-t, 0, s));

            var faces = new List<Face>
            {

                // Sets up faces from the corners of the planes as needed. 
                new Face(pointList[0], pointList[11], pointList[5]),
                new Face(pointList[0], pointList[5], pointList[1]),
                new Face(pointList[0], pointList[1], pointList[7]),
                new Face(pointList[0], pointList[7], pointList[10]),
                new Face(pointList[0], pointList[10], pointList[11]),

                new Face(pointList[1], pointList[5], pointList[9]),
                new Face(pointList[5], pointList[11], pointList[4]),
                new Face(pointList[11], pointList[10], pointList[2]),
                new Face(pointList[10], pointList[7], pointList[6]),
                new Face(pointList[7], pointList[1], pointList[8]),

                new Face(pointList[3], pointList[9], pointList[4]),
                new Face(pointList[3], pointList[4], pointList[2]),
                new Face(pointList[3], pointList[2], pointList[6]),
                new Face(pointList[3], pointList[6], pointList[8]),
                new Face(pointList[3], pointList[8], pointList[9]),

                new Face(pointList[4], pointList[9], pointList[5]),
                new Face(pointList[2], pointList[4], pointList[11]),
                new Face(pointList[6], pointList[2], pointList[10]),
                new Face(pointList[8], pointList[6], pointList[7]),
                new Face(pointList[9], pointList[8], pointList[1])
            };



            // For loop iterates through to a certain recursion level.
            for (int i = 0; i < recursionLevel; i++)
            {
                var faces2 = new List<Face>();
                // Foreach loop iterates through each Face(triangle), splitting it up into four other triangles and more closely representing a sphere.
                // The higher the recursion level, the closer to the sphere the Vertex array is.
                foreach (var tri in faces)
                {
                    // Gets midpoint of vertexes, and then generates four new Faces from the current Face.
                    int a = GetMiddlePoint(tri.Vertex1, tri.Vertex2);
                    int b = GetMiddlePoint(tri.Vertex2, tri.Vertex3);
                    int c = GetMiddlePoint(tri.Vertex3, tri.Vertex1);

                    faces2.Add(new Face(tri.Vertex1, pointList[a], pointList[c]));
                    faces2.Add(new Face(tri.Vertex2, pointList[b], pointList[a]));
                    faces2.Add(new Face(tri.Vertex3, pointList[c], pointList[b]));
                    faces2.Add(new Face(pointList[a], pointList[b], pointList[c]));
                }
                faces = faces2;
            }


            var vertices = new List<Vertex>();

            // Foreach loop iterates through each Face object in the list, and adds each Vector3 to the vertex list. The colours of the vertices are specified here.
            foreach (var tri in faces)
            {
                var uv1 = GetSphereCoord(tri.Vertex1);
                var uv2 = GetSphereCoord(tri.Vertex2);
                var uv3 = GetSphereCoord(tri.Vertex3);
                vertices.Add(new Vertex(new Vector4(tri.Vertex1, 1), colour));
                vertices.Add(new Vertex(new Vector4(tri.Vertex2, 1), colour));
                vertices.Add(new Vertex(new Vector4(tri.Vertex3, 1), colour));
            }

            return vertices.ToArray();
        }

        // Calculates the midpoint between two Vector3s.
        private int GetMiddlePoint(Vector3 vector1, Vector3 vector2)
        {
            // Checks to see whether the midpoint of these two Vector3s have been calculated beforehand.
            // If they have, the value is pulled from the cache, saving processing power and speeding up the simulation.
            // If they haven't, the midpoint is calculated, and then stored into the cache for future reference.

            long i1 = pointList.IndexOf(vector1);
            long i2 = pointList.IndexOf(vector2);

            var firstIsSmaller = i1 < i2;
            long smallerIndex = firstIsSmaller ? i1 : i2;
            long greaterIndex = firstIsSmaller ? i2 : i1;
            long key = (smallerIndex << 32) + greaterIndex;

            int ret;
            if (middlePointCache.TryGetValue(key, out ret))
            {
                return ret;
            }

            var middle = new Vector3(
                (vector1.X + vector2.X) / 2.0f,
                (vector1.Y + vector2.Y) / 2.0f,
                (vector1.Z + vector2.Z) / 2.0f);

            int i = AddVertex(middle);

            // Stores the calculated midpoint into the cache.
            middlePointCache.Add(key, i);
            return i;
        }

        // Method to normalise a Vector3 and add it to the pointList Vector3 list.
        private int AddVertex(Vector3 p)
        {
            pointList.Add(p.Normalized());
            return indexInt++;
        }

        // Uses Vector maths to calculate the co-ordinates of the sphere.
        public static Vector2 GetSphereCoord(Vector3 i)
        {
            var len = i.Length;
            Vector2 uv;
            uv.Y = (float)(Math.Acos(i.Y / len) / Math.PI);
            uv.X = -(float)((Math.Atan2(i.Z, i.X) / Math.PI + 1.0f) * 0.5f);
            return uv;
        }
    }
}
