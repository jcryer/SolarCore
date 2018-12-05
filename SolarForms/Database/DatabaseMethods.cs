using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using SolarForms.Components;

namespace SolarForms.Database
{
    class DatabaseMethods
    {
        public static Simulation GetSimulation (int simulationId)
        {
            Simulation sim = new Simulation();
            string simQueryString = "select Simulation.Zoom, Simulation.ZoomModifier, Simulation.Focus, Simulation.Fixed, Simulation.Speed, Simulation.Scale, PlanetarySystem.Name, PlanetarySystem.Description from Simulation " +
                "inner join PlanetarySystem on PlanetarySystem.PlanetarySystemID = Simulation.PlanetarySystemID " + 
                "where Simulation.SimulationID = " + simulationId + ";";
            
            var simQuery = new SQLiteCommand(simQueryString, Program.DBConnection);
            var simReader = simQuery.ExecuteReader();

            while (simReader.Read())
            {
                var dict = new Dictionary<string, string>();
                for (int i = 0; i < simReader.FieldCount; i++)
                {
                    dict.Add(simReader.GetName(i), simReader[i].ToString());
                }
                sim = new Simulation() { PlanetarySystem = new PlanetarySystem(dict["Name"], dict["Description"]), Speed = int.Parse(dict["Speed"]), Scale = int.Parse(dict["Scale"]), Camera = new Camera(double.Parse(dict["Zoom"]), double.Parse(dict["ZoomModifier"]), int.Parse(dict["InitialFocus"]), Convert.ToBoolean(int.Parse(dict["Fixed"]))) };
            }

            string objectQueryString = "select Object.ObjectID, ObjectView.TrailActive, ObjectView.TrailLength, ObjectView.TrailColour, ObjectView.ObjectColour, Object.Name, Object.Mass, Object.Radius, Object.Obliquity, Object.OrbitalSpeed, InitialValues.PositionX, InitialValues.PositionY, InitialValues.PositionZ, InitialValues.VelocityX, InitialValues.VelocityY, InitialValues.VelocityZ from Simulation " +
                "inner join PlanetarySystem on PlanetarySystem.PlanetarySystemID = Simulation.PlanetarySystemID " +
                "inner join InitialValues on InitialValues.PlanetarySystemID = Simulation.PlanetarySystemID " +
                "inner join Object on Object.ObjectID = InitialValues.ObjectID " +
                "inner join ObjectView on ObjectView.ObjectID = Object.ObjectID " +
                "where Simulation.SimulationID = " + simulationId + ";";

            var objectQuery = new SQLiteCommand(objectQueryString, Program.DBConnection);
            var objectReader = objectQuery.ExecuteReader();
            while (objectReader.Read())
            {
                var dict = new Dictionary<string, string>();

                for (int i = 0; i < objectReader.FieldCount; i++)
                {
                    dict.Add(objectReader.GetName(i), objectReader[i].ToString());
                }
                sim.PlanetarySystem.Objects.Add(new SolarObject(dict["Name"], double.Parse(dict["Mass"]), double.Parse(dict["Radius"]), double.Parse(dict["Obliquity"]), double.Parse(dict["OrbitalSpeed"]), Convert.ToBoolean(int.Parse(dict["TrailActive"])), int.Parse(dict["TrailLength"]), Color.FromArgb(int.Parse(dict["TrailColour"])), Color4.LightGoldenrodYellow, new Vector3(float.Parse(dict["PositionX"]), float.Parse(dict["PositionY"]), float.Parse(dict["PositionZ"])), new Vector3(float.Parse(dict["VelocityX"]), float.Parse(dict["VelocityY"]), float.Parse(dict["VelocityZ"]))));
            }
            return sim;
        }

        public static List<SolarObject> GetObjects ()
        {
            List<SolarObject> objects = new List<SolarObject>();
            string objQueryString = "select * from Object;";

            var objQuery = new SQLiteCommand(objQueryString, Program.DBConnection);
            var objReader = objQuery.ExecuteReader();

            while (objReader.Read())
            {
                var dict = new Dictionary<string, string>();
                for (int i = 0; i < objReader.FieldCount; i++)
                {
                    dict.Add(objReader.GetName(i), objReader[i].ToString());
                }
                objects.Add(new SolarObject(dict["Name"], double.Parse(dict["Mass"]), double.Parse(dict["Radius"]), double.Parse(dict["Obliquity"]), double.Parse(dict["OrbitalSpeed"]), int.Parse(dict["ObjectID"])));
            }
            return objects;
        }

        public static Dictionary<string, Vector3> GetLocationPresets(int mode)
        {
            Dictionary<string, Vector3> results = new Dictionary<string, Vector3>();
            string objQueryString = "select PositionX, PositionY, PositionZ, Object.Name from InitialValues inner join Object on Object.ObjectID = InitialValues.ObjectID;";
            if (mode == 1)

                objQueryString = "select VelocityX, VelocityY, VelocityZ, Object.Name from InitialValues inner join Object on Object.ObjectID = InitialValues.ObjectID;";

            var objQuery = new SQLiteCommand(objQueryString, Program.DBConnection);
            var objReader = objQuery.ExecuteReader();

            while (objReader.Read())
            {
                var dict = new Dictionary<string, string>();
                for (int i = 0; i < objReader.FieldCount; i++)
                {
                    dict.Add(objReader.GetName(i), objReader[i].ToString());
                }
                if (mode == 0)
                    results.Add(dict["Name"], new Vector3(float.Parse(dict["PositionX"]), float.Parse(dict["PositionY"]), float.Parse(dict["PositionZ"])));
                else
                    results.Add(dict["Name"], new Vector3(float.Parse(dict["VelocityX"]), float.Parse(dict["VelocityY"]), float.Parse(dict["VelocityZ"])));

            }
            return results;
        }

        public static bool AddObject(int id)
        {
            var t = new Telnet().Run(id);

            string addString = $"insert into Object (Name, Mass, Radius, Obliquity, OrbitalSpeed) values('{t.Name}', '{t.Mass}', '{t.Radius}', 0, 0);";

            var add = new SQLiteCommand(addString, Program.DBConnection);
            add.ExecuteNonQuery();

            string addinitvaluesString = $"insert into InitialValues (Name, Mass, Radius, Obliquity, OrbitalSpeed) values('{t.Name}', '{t.Mass}', '{t.Radius}', 0, 0);";

            var addinitValues = new SQLiteCommand(addinitvaluesString, Program.DBConnection);
            add.ExecuteNonQuery();
            return true;
        }
    }
}