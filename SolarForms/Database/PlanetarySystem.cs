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
        // All fields flagged with [JsonIgnore] are only used within the context of the running simulation.
        // Therefore, they have been marked so they aren't exported with the rest of the simulation if it were exported to a file.

        [JsonIgnore]
        public int DatabaseID;
        [JsonIgnore]
        public List<SolarObject> DeletedObjects = new List<SolarObject>();

        public string Name = "";
        public string Description = "";
        public List<SolarObject> Objects;

        // In some cases, new PlanetarySystems are defined (such as creating a new simulation). In these cases, this constructor is required.
        public PlanetarySystem()
        {
            Objects = new List<SolarObject>();
            DatabaseID = -1;
        }

        // In most cases, pre-existing PlanetarySystem records are pulled from the database and stored in the class model. 
        // In these cases, this constructor is required.
        public PlanetarySystem(string name, string description)
        {
            Name = name;
            Description = description;
            Objects = new List<SolarObject>();
            DatabaseID = -1;
        }
    }
}
