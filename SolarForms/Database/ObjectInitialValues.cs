using OpenTK;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SolarForms.Database
{
    class ObjectInitialValues
    {
        List<ObjectInitialValue> Values;

        public ObjectInitialValues()
        {
            Values = new List<ObjectInitialValue>();
        }

        public bool Get()
        {
            var c = new SQLiteCommand("select * from ObjectInitialValues", Program.DBConnection);
            var reader = c.ExecuteReader();
            while (reader.Read())
            {
                Values.Add(new ObjectInitialValue((int)reader[0], (int)reader[1], (float)reader[2], (float)reader[3], (float)reader[4], (float)reader[5], (float)reader[6], (float)reader[7]));
            }
            return true;
        }
    }

    class ObjectInitialValue
    {
        public int ObjectID;
        public int PlanetarySystemID;
        public Vector3 Position;
        public Vector3 Velocity;

        public ObjectInitialValue(int objectID, int planetarySystemID, float px, float py, float pz, float vx, float vy, float vz)
        {
            ObjectID = objectID;
            PlanetarySystemID = planetarySystemID;
            Position = new Vector3(px, py, pz);
            Velocity = new Vector3(vx, vy, vz);
        }
    }
}
