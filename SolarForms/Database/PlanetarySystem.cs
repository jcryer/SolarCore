using SolarForms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Database
{
    public class PlanetarySystem
    {
        public string Name;
        public string Description;
        public List<SolarObject> Objects;

        public PlanetarySystem()
        {
            Objects = new List<SolarObject>();

        }
        public PlanetarySystem(string name, string description)
        {
            Name = name;
            Description = description;
            Objects = new List<SolarObject>();
        }

        
    }
}
