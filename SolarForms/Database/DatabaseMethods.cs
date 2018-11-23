using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarForms.Components;

namespace SolarForms.Database
{
    class DatabaseMethods
    {
        public static void GetSimulation (int simulationId)
        {
            string query = "select * from Simulation " +
                "inner join PlanetarySystem on PlanetarySystem.PlanetarySystemID = Simulation.PlanetarySystemID " +
                "inner join InitialValues on InitialValues.PlanetarySystemID = Simulation.PlanetarySystemID " +
                "inner join Object on Object.ObjectID = InitialValues.ObjectID " +
                "inner join ObjectView on ObjectView.ObjectID = Object.ObjectID " +
                "where SimulationID = " + simulationId + ";";

            var simQuery = new SQLiteCommand(query, Program.DBConnection);
            var simReader = simQuery.ExecuteReader();
            while (simReader.Read())
            {
                continue;
            }
            
        }

        public void Set ()
        {

        }
    }
}
