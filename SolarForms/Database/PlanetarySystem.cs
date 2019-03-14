using Newtonsoft.Json;
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
        [JsonIgnore]
        public int DatabaseID;
        public string Name = "";
        public string Description = "";
        public List<SolarObject> Objects;
        [JsonIgnore]
        public List<SolarObject> DeletedObjects = new List<SolarObject>();
        public PlanetarySystem()
        {
            Objects = new List<SolarObject>();
            DatabaseID = -1;

        }
        public PlanetarySystem(string name, string description)
        {
            Name = name;
            Description = description;
            Objects = new List<SolarObject>();
            DatabaseID = -1;
        }

        
    }
}
