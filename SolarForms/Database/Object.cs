using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Database
{
    class Object
    {
        int ObjectID;
        string Name;
        double Mass;
        double Radius;
        double Obliquity;
        double OrbitalSpeed;

        public Object(int objectID, string name, double mass, double radius, double obliquity, double orbitalSpeed)
        {
            ObjectID = objectID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Mass = mass;
            Radius = radius;
            Obliquity = obliquity;
            OrbitalSpeed = orbitalSpeed;
        }
    }
}
