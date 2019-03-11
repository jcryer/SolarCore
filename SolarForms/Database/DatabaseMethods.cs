using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using SolarForms.Components;

namespace SolarForms.Database
{
    class DatabaseMethods
    {

        public static List<Simulation> GetSimulations()
        {
            List<int> simulationIDs = new List<int>();
            string simString = "select Simulation.SimulationID FROM Simulation;";
            var simQuery = new SQLiteCommand(simString, Program.DBConnection);
            var simReader = simQuery.ExecuteReader();

            while (simReader.Read())
            {
                simulationIDs.Add(int.Parse(simReader[0].ToString()));
            }

            List<Simulation> simulations = new List<Simulation>();

            foreach (var ID in simulationIDs)
            {
                simulations.Add(GetSimulation(ID));
            }
            return simulations;
        }

        public static Simulation GetSimulation (int simulationId)
        {
            Simulation sim = new Simulation();
            string simQueryString = "select Simulation.SimulationID, Simulation.Zoom, Simulation.ZoomModifier, Simulation.Focus, " +
                "Simulation.Fixed, Simulation.Speed, Simulation.Scale, PlanetarySystem.PlanetarySystemID, PlanetarySystem.Name, " +
                "PlanetarySystem.Description from Simulation " +
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
                sim = new Simulation() { DatabaseID = int.Parse(dict["SimulationID"]), PlanetarySystem = new PlanetarySystem(dict["Name"], 
                    dict["Description"]) { DatabaseID = int.Parse(dict["PlanetarySystemID"])}, Speed = int.Parse(dict["Speed"]),
                    Scale = int.Parse(dict["Scale"]), Camera = new Camera(double.Parse(dict["Zoom"]), double.Parse(dict["ZoomModifier"]), 
                    int.Parse(dict["Focus"]), Convert.ToBoolean(int.Parse(dict["Fixed"]))) };
            }

            string objectQueryString = "select Object.ObjectID, ObjectView.TrailActive, ObjectView.TrailLength, ObjectView.TrailColour, ObjectView.ObjectColour, " +
                "Object.Name, Object.Mass, Object.Radius, Object.Obliquity, " +
                "Object.OrbitalSpeed, InitialValues.PositionX, InitialValues.PositionY, InitialValues.PositionZ, " +
                "InitialValues.VelocityX, InitialValues.VelocityY, InitialValues.VelocityZ " +
                "from Simulation " +
                "left join InitialValues on InitialValues.PlanetarySystemID = Simulation.PlanetarySystemID " +
                "left join Object on Object.ObjectID = InitialValues.ObjectID " +
                "left join ObjectView on ObjectView.ObjectID = Object.ObjectID " +
                $"where Simulation.SimulationID = {simulationId} AND ObjectView.SimulationID = {simulationId};";

            var objectQuery = new SQLiteCommand(objectQueryString, Program.DBConnection);
            var objectReader = objectQuery.ExecuteReader();
            while (objectReader.Read())
            {
                var dict = new Dictionary<string, string>();

                for (int i = 0; i < objectReader.FieldCount; i++)
                {
                    dict.Add(objectReader.GetName(i), objectReader[i].ToString());
                }
                sim.PlanetarySystem.Objects.Add(new SolarObject(dict["Name"], double.Parse(dict["Mass"]), double.Parse(dict["Radius"]), 
                    double.Parse(dict["Obliquity"]), double.Parse(dict["OrbitalSpeed"]), Convert.ToBoolean(int.Parse(dict["TrailActive"])), 
                    int.Parse(dict["TrailLength"]), ColorTranslator.FromHtml(dict["TrailColour"]), ColorTranslator.FromHtml(dict["ObjectColour"]), 
                    new Vector3(float.Parse(dict["PositionX"]), float.Parse(dict["PositionY"]), float.Parse(dict["PositionZ"])), 
                    new Vector3(float.Parse(dict["VelocityX"]), float.Parse(dict["VelocityY"]), 
                    float.Parse(dict["VelocityZ"]))) { DatabaseID = int.Parse(dict["ObjectID"]) });
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
                objects.Add(new SolarObject(dict["Name"], double.Parse(dict["Mass"]), double.Parse(dict["Radius"]), 
                    double.Parse(dict["Obliquity"]), double.Parse(dict["OrbitalSpeed"]), 
                    int.Parse(dict["ObjectID"])) { DatabaseID = int.Parse(dict["ObjectID"]) });
            }
            return objects;
        }

        public static Dictionary<string, Vector3> GetLocationPresets(int mode)
        {
            Dictionary<string, Vector3> results = new Dictionary<string, Vector3>();
            string objQueryString = "select PositionX, PositionY, PositionZ, Object.Name from InitialValues " +
                "inner join Object on Object.ObjectID = InitialValues.ObjectID WHERE InitialValues.PlanetarySystemID = 0;";
            if (mode == 1)

                objQueryString = "select VelocityX, VelocityY, VelocityZ, Object.Name from InitialValues " +
                    "inner join Object on Object.ObjectID = InitialValues.ObjectID WHERE InitialValues.PlanetarySystemID = 0;";

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
                {
                    string key = dict["Name"];
                    if (results.ContainsKey(dict["Name"]))
                    {
                        key += "-1";
                    }
                    results.Add(key, new Vector3(float.Parse(dict["PositionX"]), float.Parse(dict["PositionY"]), float.Parse(dict["PositionZ"])));
                }
                else
                {
                    string key = dict["Name"];
                    if (results.ContainsKey(dict["Name"]))
                    {
                        key += "-1";
                    }
                    results.Add(key, new Vector3(float.Parse(dict["VelocityX"]), float.Parse(dict["VelocityY"]), float.Parse(dict["VelocityZ"])));
                }

            }
            return results;
        }

        public static bool AddObject(int id)
        {
            var t = new Telnet().Run(id);
            var cmd = new SQLiteCommand($"SELECT count(*) FROM Object;", Program.DBConnection);

            int countObjectView = Convert.ToInt32(cmd.ExecuteScalar());

            string addString = $"insert into Object (ObjectID, Name, Mass, Radius, Obliquity, OrbitalSpeed) " +
                $"values('{countObjectView}', '{t.Name}', '{t.Mass}', '{t.Radius}', 0, 0);";

            var add = new SQLiteCommand(addString, Program.DBConnection);
            add.ExecuteNonQuery();
            var position = t.GetPosition();
            var velocity = t.GetVelocity();
            string addinitvaluesString = $"insert into InitialValues (ObjectID, PlanetarySystemID, PositionX, PositionY, PositionZ, " +
                $"VelocityX, VelocityY, VelocityZ) values('{countObjectView}', '0', '{position.X}', '{position.Y}', '{position.Z}', '{velocity.X}', '{velocity.Y}', '{velocity.Z}');";

            var addinitValues = new SQLiteCommand(addinitvaluesString, Program.DBConnection);
            addinitValues.ExecuteNonQuery();

            return true;
        }

        public static bool SetSimulation(Simulation sim)
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.DBConnection);

            int planetarySystemID = -1;
            int simulationID = -1;

            if (sim.PlanetarySystem.DatabaseID == -1)
            {
                cmd.CommandText = $"INSERT INTO PlanetarySystem (Name, Description) VALUES ('{sim.PlanetarySystem.Name}', '{sim.PlanetarySystem.Description}');"; ;
                cmd.ExecuteScalar();
                planetarySystemID = (int)cmd.Connection.LastInsertRowId;
                sim.PlanetarySystem.DatabaseID = planetarySystemID;
            }
            else
            {
                planetarySystemID = sim.PlanetarySystem.DatabaseID;
                cmd.CommandText = $"UPDATE PlanetarySystem SET Name = '{sim.PlanetarySystem.Name}', " +
                    $"Description = '{sim.PlanetarySystem.Description}' " +
                    $"WHERE PlanetarySystemID = {planetarySystemID};";
                cmd.ExecuteScalar();
            }

            if (sim.DatabaseID == -1)
            {
                cmd.CommandText = $"INSERT INTO Simulation (PlanetarySystemID, Zoom, ZoomModifier, Focus, Fixed, Speed, SpeedModifier, Scale) " +
                    $"VALUES ({sim.PlanetarySystem.DatabaseID}, {sim.Camera.Zoom}, {sim.Camera.ZoomModifier}, {sim.Camera.Focus}, {sim.Camera.Fixed}, {sim.Speed}, " +
                    $"{sim.SpeedModifier}, {sim.Scale});";
                cmd.ExecuteScalar();
                simulationID = (int)cmd.Connection.LastInsertRowId;
                sim.DatabaseID = simulationID;
            }
            else
            {
                simulationID = sim.DatabaseID;

                cmd.CommandText = $"UPDATE Simulation SET PlanetarySystemID = {sim.PlanetarySystem.DatabaseID}, " +
                    $"Zoom = {sim.Camera.Zoom}, " +
                    $"ZoomModifier = {sim.Camera.ZoomModifier}, " +
                    $"Focus = {sim.Camera.Focus}, " +
                    $"Fixed = {sim.Camera.Fixed}, " +
                    $"Speed = {sim.Speed}, " +
                    $"SpeedModifier = {sim.SpeedModifier}, " +
                    $"Scale = {sim.Scale} " +
                    $"WHERE SimulationID = {sim.DatabaseID};";
                cmd.ExecuteScalar();
            }
            foreach (var delObj in sim.PlanetarySystem.DeletedObjects)
            {
                if (delObj.DatabaseID > 8)
                {
                    cmd.CommandText = $"DELETE FROM Object WHERE ObjectID = {delObj.DatabaseID};";
                    cmd.ExecuteScalar();
                }
                cmd.CommandText = $"DELETE FROM ObjectView WHERE ObjectID = {delObj.DatabaseID} AND SimulationID = {simulationID};";
                cmd.ExecuteScalar();
                cmd.CommandText = $"DELETE FROM InitialValues WHERE ObjectID = {delObj.DatabaseID} AND PlanetarySystemID = {planetarySystemID};";
                cmd.ExecuteScalar();
            }

            foreach (var obj in sim.PlanetarySystem.Objects)
            {
                int objectID = -1;
                if (obj.DatabaseID == -1)
                {
                    cmd.CommandText = $"INSERT INTO Object (Name, Mass, Radius, Obliquity, OrbitalSpeed) VALUES ('{obj.Name}', " +
                    $"{obj.Mass}, {obj.Radius}, {obj.Obliquity}, {obj.OrbitalSpeed});";
                    cmd.ExecuteScalar();
                    objectID = (int)cmd.Connection.LastInsertRowId;
                    obj.DatabaseID = objectID;
                }
                else
                {
                    objectID = obj.DatabaseID;
                    cmd.CommandText = $"UPDATE Object SET " +
                    $"Name = '{obj.Name}', " +
                    $"Mass = {obj.Mass}, " +
                    $"Radius = {obj.Radius}, " +
                    $"Obliquity = {obj.Obliquity}, " +
                    $"OrbitalSpeed = {obj.OrbitalSpeed} " +
                    $"WHERE ObjectID = {obj.DatabaseID};";
                    cmd.ExecuteScalar();
                }

                cmd.CommandText = $"SELECT count(*) FROM ObjectView WHERE SimulationID = {simulationID} AND ObjectID = {objectID};";
                int countObjectView = Convert.ToInt32(cmd.ExecuteScalar());
                if (countObjectView == 0)
                {
                    cmd.CommandText = $"INSERT INTO ObjectView(SimulationID, ObjectID, TrailActive, TrailLength, TrailColour, ObjectColour) " +
                     $" VALUES ({simulationID}, {objectID}, {obj.TrailsActive}, {obj.TrailLength}, " +
                     $"\"{ColorTranslator.ToHtml((Color)obj.TrailColour)}\", \"{ColorTranslator.ToHtml((Color)obj.ObjectColour)}\");";
                    cmd.ExecuteScalar();
                }
                else
                {
                    cmd.CommandText = $"UPDATE ObjectView SET " +
                       $"TrailActive = {obj.TrailsActive}, " +
                       $"TrailLength = {obj.TrailLength}, " +
                       $"TrailColour = \"{ColorTranslator.ToHtml((Color)obj.TrailColour)}\", " +
                       $"ObjectColour = \"{ColorTranslator.ToHtml((Color)obj.ObjectColour)}\" " +
                       $"WHERE ObjectID = {obj.DatabaseID} AND SimulationID = {simulationID};";
                    cmd.ExecuteScalar();
                }

                cmd.CommandText = $"SELECT count(*) FROM InitialValues WHERE PlanetarySystemID = {planetarySystemID} AND ObjectID = {objectID};";
                int countInitialValues = Convert.ToInt32(cmd.ExecuteScalar());
                if (countInitialValues == 0)
                {
                    cmd.CommandText = $"INSERT INTO InitialValues(ObjectID, PlanetarySystemID, PositionX, PositionY, " +
                    $"PositionZ, VelocityX, VelocityY, VelocityZ) VALUES ({obj.DatabaseID}, {planetarySystemID}, {obj.Position.X}, " +
                    $"{obj.Position.Y}, {obj.Position.Z}, {obj.Velocity.X}, {obj.Velocity.Y}, {obj.Velocity.Z});";
                    cmd.ExecuteScalar();
                }
                else
                {
                    cmd.CommandText = $"UPDATE InitialValues SET " +
                       $"PositionX = {obj.Position.X}, " +
                       $"PositionY = {obj.Position.Y}, " +
                       $"PositionZ = {obj.Position.Z}, " +
                       $"VelocityX = {obj.Velocity.X}, " +
                       $"VelocityY = {obj.Velocity.Y}, " +
                       $"VelocityZ = {obj.Velocity.Z} " +
                       $"WHERE ObjectID = {obj.DatabaseID} AND PlanetarySystemID = {planetarySystemID};";
                    cmd.ExecuteScalar();
                }
            }
            return true;
        }
    }
}