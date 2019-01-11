using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SolarForms
{
    static class Program
    {
        public static SQLiteConnection DBConnection;
        [STAThread]
        static void Main()
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
            "`TrailColour`	INTEGER NOT NULL," +
            "`ObjectColour`	INTEGER NOT NULL," +
            "foreign key(SimulationID) references Simulation(SimulationID)," +
            "foreign key(ObjectID) references Object(ObjectID)); ", DBConnection);

            Object.ExecuteNonQuery();
            InitialValues.ExecuteNonQuery();
            PlanetarySystem.ExecuteNonQuery();
            Simulation.ExecuteNonQuery();
            ObjectView.ExecuteNonQuery();

            /*
            int[] test = new int[] { 199, 299, 399, 499, 599, 699, 799, 899, 999 };
            foreach (int i in test)
                Database.DatabaseMethods.AddObject(i);
            Console.WriteLine("Done!");
            */

            new Components.Menus.MainMenu().Show();
            Application.Run();
        }
    }
}