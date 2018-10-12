using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    class Simulation
    {
        public List<SimulationObject> Objects;
        public Simulation()
        {
            Objects = new List<SimulationObject>();
        }
    }

    class SimulationObject
    {
        public SolarObject Object;
        public List<Vector3> Positions;

        public SimulationObject(SolarObject @object)
        {
            Object = @object;
            Positions = new List<Vector3>();
        }
    }

    class SaveObject
    {
        public List<SolarObject> Objects;
        public int InitialTime;
    }
}
