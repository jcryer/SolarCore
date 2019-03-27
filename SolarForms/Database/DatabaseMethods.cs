using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using SolarForms.Components;
using System.IO;

namespace SolarForms.Database
{
    class DatabaseMethods
    {
        public static SQLiteConnection DBConnection;

        // This method performs various SQL commands setting up the initial database if it doesn't already exist.
        // It connects to the database and runs a series of table creation statements.
        public static void Setup()
        {
            if (!File.Exists("SolarDB.sqlite"))
                SQLiteConnection.CreateFile("SolarDB.sqlite");

            DBConnection = new SQLiteConnection("Data Source=SolarDB.sqlite;Version=3;");
            DBConnection.Open();

            SQLiteCommand Object = new SQLiteCommand("" +
                "CREATE TABLE IF NOT EXISTS `Object` (" +
                "`ObjectID`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                 "`Name`	TEXT NOT NULL," +
                "`Mass`	REAL NOT NULL," +
                "`Radius`	REAL NOT NULL," +
                "`Obliquity`	REAL NOT NULL," +
                "`OrbitalSpeed`	REAL NOT NULL); ", DBConnection);

            SQLiteCommand InitialValues = new SQLiteCommand("" +
                "CREATE TABLE IF NOT EXISTS `InitialValues` (" +
                "`ObjectID`	INTEGER NOT NULL," +
                "`PlanetarySystemID`	INTEGER NOT NULL," +
                "`PositionX`	REAL NOT NULL," +
                "`PositionY`	REAL NOT NULL," +
                "`PositionZ`	REAL NOT NULL," +
                "`VelocityX`	REAL NOT NULL," +
                "`VelocityY`	REAL NOT NULL," +
                "`VelocityZ`	REAL NOT NULL," +
                "foreign key(ObjectID) references Object(ObjectID)," +
                "foreign key(PlanetarySystemID) references PlanetarySystem(PlanetarySystemID));", DBConnection);

            SQLiteCommand PlanetarySystem = new SQLiteCommand("" +
                "CREATE TABLE IF NOT EXISTS `PlanetarySystem` (" +
                "`PlanetarySystemID`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                "`Name`	TEXT NOT NULL," +
                "`Description`	TEXT NOT NULL); ", DBConnection);

            SQLiteCommand Simulation = new SQLiteCommand("" +
                "CREATE TABLE IF NOT EXISTS `Simulation` (" +
                "`SimulationID`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                "`PlanetarySystemID`	INTEGER NOT NULL," +
                "`Zoom`	REAL NOT NULL," +
                "`ZoomModifier`	REAL NOT NULL," +
                "`Focus`	INTEGER NOT NULL," +
                "`Fixed`	INTEGER NOT NULL," +
                "`Speed`	INTEGER NOT NULL," +
                "'SpeedModifier' INTEGER NOT NULL," +
                "`Scale`	INTEGER NOT NULL," +
                "FOREIGN KEY(`PlanetarySystemID`) REFERENCES `PlanetarySystem`(`PlanetarySystemID`)); ", DBConnection);

            SQLiteCommand ObjectView = new SQLiteCommand("" +
            "CREATE TABLE IF NOT EXISTS `ObjectView` (" +
            "`SimulationID`	INTEGER NOT NULL," +
            "`ObjectID`	INTEGER NOT NULL," +
            "`TrailActive`	INTEGER NOT NULL," +
            "`TrailLength`	INTEGER NOT NULL," +
            "`TrailColour`	TEXT NOT NULL," +
            "`ObjectColour`	TEXT NOT NULL," +
            "foreign key(SimulationID) references Simulation(SimulationID)," +
            "foreign key(ObjectID) references Object(ObjectID)); ", DBConnection);

            Object.ExecuteNonQuery();
            InitialValues.ExecuteNonQuery();
            PlanetarySystem.ExecuteNonQuery();
            Simulation.ExecuteNonQuery();
            ObjectView.ExecuteNonQuery();
        }

        // This method returns a list of all Simulations and related values in the database.
        // It pulls all Simulations (and connected Planetary Simulations) using an inner join, and parses this into the Simulation class model.
        // It then performs a series of SQL statements to pull all Object (and connected InitialValues and ObjectView) records connected to each Simulation using three left joins.
        // This is then parsed and added to each relevant Simulation object.
        // Each simulation is added to a List of Simulations, and this list is returned.
        public static List<Simulation> GetSimulations()
        {
            List<int> simulationIDs = new List<int>();
            string simString = "select Simulation.SimulationID FROM Simulation;";
            var simQuery = new SQLiteCommand(simString, DBConnection);
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

        // This method returns a single Simulation and all related values in the database, based on SimulationID.
        // It pulls the requested Simulation (and connected Planetary Simulation) using an inner join, and parses this into the Simulation class model.
        // It then performs another SQL statement to pull all Object (and connected InitialValues and ObjectView) records connected to the Simulation using three left joins.
        // This is then parsed and added to the Simulation object. This Simulation object is then returned.
        public static Simulation GetSimulation (int simulationId)
        {
            Simulation sim = new Simulation();
            string simQueryString = "select Simulation.SimulationID, Simulation.Zoom, Simulation.ZoomModifier, Simulation.Focus, " +
                "Simulation.Fixed, Simulation.Speed, Simulation.Scale, PlanetarySystem.PlanetarySystemID, PlanetarySystem.Name, " +
                "PlanetarySystem.Description from Simulation " +
                "inner join PlanetarySystem on PlanetarySystem.PlanetarySystemID = Simulation.PlanetarySystemID " + 
                "where Simulation.SimulationID = " + simulationId + ";";
            
            var simQuery = new SQLiteCommand(simQueryString, DBConnection);
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

            var objectQuery = new SQLiteCommand(objectQueryString, DBConnection);
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

        // This method returns a list of all objects in the database.
        // It performs a simple SQL statement that pulls all Objects from the database, before parsing each returned record into a SolarObject.
        // A list of SolarObjects is then returned.
        public static List<SolarObject> GetObjects ()
        { 
            List<SolarObject> objects = new List<SolarObject>();
            string objQueryString = "select * from Object;";

            var objQuery = new SQLiteCommand(objQueryString, DBConnection);
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

        // This method EITHER returns a Dictionary of all preset Position OR Velocity values (along with the name of the object they have been orphaned from).
        // It performs an SQL statement that pulls in all position/velocity presets (and the object name) with the PlanetarySystemID of 0 (reserved for preset objects) 
        // using an inner join between the Object and InitialValues tables.
        public static Dictionary<string, Vector3> GetLocationPresets(int mode)
        {
            Dictionary<string, Vector3> results = new Dictionary<string, Vector3>();
            string objQueryString = "select PositionX, PositionY, PositionZ, Object.Name from InitialValues " +
                "inner join Object on Object.ObjectID = InitialValues.ObjectID WHERE InitialValues.PlanetarySystemID = 0;";
            if (mode == 1)

                objQueryString = "select VelocityX, VelocityY, VelocityZ, Object.Name from InitialValues " +
                    "inner join Object on Object.ObjectID = InitialValues.ObjectID WHERE InitialValues.PlanetarySystemID = 0;";

            var objQuery = new SQLiteCommand(objQueryString, DBConnection);
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

        // This method uses the Telnet class to pull down a specific celestial body from NASA's Horizons server based on NASA's unique object ID system.
        // It then adds the SolarObject object to the database, as a new record in both the InitialValues and the Object tables.
        public static bool AddObject(int nasaID)
        {
            var t = new Telnet().Run(nasaID);
            var cmd = new SQLiteCommand($"SELECT count(*) FROM Object;", DBConnection);

            int countObjectView = Convert.ToInt32(cmd.ExecuteScalar());

            string addString = $"insert into Object (ObjectID, Name, Mass, Radius, Obliquity, OrbitalSpeed) " +
                $"values('{countObjectView}', '{t.Name}', '{t.Mass}', '{t.Radius}', 0, 0);";

            var add = new SQLiteCommand(addString, DBConnection);
            add.ExecuteNonQuery();
            var position = t.GetPosition();
            var velocity = t.GetVelocity();
            string addinitvaluesString = $"insert into InitialValues (ObjectID, PlanetarySystemID, PositionX, PositionY, PositionZ, " +
                $"VelocityX, VelocityY, VelocityZ) values('{countObjectView}', '0', '{position.X}', '{position.Y}', '{position.Z}', '{velocity.X}', '{velocity.Y}', '{velocity.Z}');";

            var addinitValues = new SQLiteCommand(addinitvaluesString, DBConnection);
            addinitValues.ExecuteNonQuery();

            return true;
        }

        // This method adds a new Simulation to the database, or updates existing records if it already exists within the database.
        // It also creates or updates the connected PlanetarySystem record, as well as all Object, InitialValues and ObjectView records connected to the Simulation 
        // (contained within the Simulation object).
        public static bool SetSimulation(Simulation sim)
        {
            SQLiteCommand cmd = new SQLiteCommand(DBConnection);

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