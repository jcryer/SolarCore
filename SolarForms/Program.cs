using System;
using System.Windows.Forms;

namespace SolarForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Runs initial database setup SQL statements if the database doesn't exist
            Database.DatabaseMethods.Setup();

            // Code to pull data down from NASA's Horizons system, using a Telnet interface.
            /*
              
            int[] test = new int[] { 10, 199, 299, 399, 499, 599, 699, 799, 899, 999 };
            foreach (int i in test) 
            {
                Database.DatabaseMethods.AddObject(i);
            }

            */

            // Opens up the Main Form
            new Components.Menus.MainForm().Show();
            Application.Run();
        }
    }
}
