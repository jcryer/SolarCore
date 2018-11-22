using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Database
{
    class PlanetarySystem
    {
        int PlanetarySystemID;
        string Name;
        string Description;

        public PlanetarySystem(int planetarySystemID, string name, string description)
        {
            PlanetarySystemID = planetarySystemID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
