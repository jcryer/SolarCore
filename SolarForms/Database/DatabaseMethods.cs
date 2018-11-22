using System;
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
        public Simulation GetSimulation (int simulationId)
        {
            var simQuery = new SQLiteCommand("select * from PlanetarySystem where SimulationID = " + simulationId, Program.DBConnection);
            var simReader = simQuery.ExecuteReader();
            simReader.Read();
            var planetarySystem = new PlanetarySystem((int)simReader[0], (string)simReader[1], (string)simReader[2]);

            var initialValuesQuery = new SQLiteCommand("select * from InitialValues where SimulationID = " + simulationId, Program.DBConnection);
            var initialValuesReader = initialValuesQuery.ExecuteReader();

            while (initialValuesReader.Read())
            {
                var initialValue = new ObjectInitialValue((int)initialValuesReader[0], (int)initialValuesReader[1], (float)initialValuesReader[2], (float)initialValuesReader[3], (float)initialValuesReader[4], (float)initialValuesReader[2], (float)initialValuesReader[5], (float)initialValuesReader[6]);

                var objectQuery = new SQLiteCommand("select * from Object where ObjectID = " + initialValue.ObjectID, Program.DBConnection);
                var objectReader = objectQuery.ExecuteReader();
                var o = new Object((int)simReader[0], (string)simReader[1], (double)simReader[2], (double)simReader[3], (double)simReader[4], (double)simReader[5]);

            }
            var c = new SQLiteCommand("select * from Object where ObjectID = " + id, Program.DBConnection);
            var reader = c.ExecuteReader();
            reader.Read();
            new SolarObject((string)reader[1], (double)reader[2], (double)reader[3], (double)reader[4], (double)reader[5]);
                //(new Object((int)reader[0], (string)reader[1], (double)reader[2], (double)reader[3], (double)reader[4], (double)reader[5]));
            
        }

        public void Set ()
        {

        }
    }
}
