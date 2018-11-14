using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolarForms.Components;
using SolarForms.Components.Menus;

namespace SolarForms
{
    static class Program
    {
        static List<ReturnObject> testing = new List<ReturnObject>();

        [STAThread]
        static void Main()
        {
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
