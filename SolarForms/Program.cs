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
            SQLiteCommand c = new SQLiteCommand("create table if not exists ObjectInitialValues(ObjectID int, PlanetarySystemID int,  PositionX real, PositionY real, PositionZ real, VelocityX real, VelocityY real, VelocityZ real)", DBConnection);
            c.ExecuteNonQuery();
            //   var obj = JsonConvert.DeserializeObject<SolarObject>(File.ReadAllText("PlanetaryData/Earth.json"));

            //    new Components.Menus.ObjectForm(obj).Show();
            /*
            testing.Add(new Telnet().Run(10));
            Console.WriteLine("done!");
            
            testing.Add(new Telnet().Run(299));
            Console.WriteLine("done!");

            testing.Add(new Telnet().Run(399));
            Console.WriteLine("done!");

            testing.Add(new Telnet().Run(499));
            Console.WriteLine("done!");*/
            new Components.Menus.MainMenu().Show();
            //new PresetMenu().Show();
            Application.Run();
            //new ControlForm().ShowDialog();
           // new MainWindow().Run(60);
        }
    }
}
