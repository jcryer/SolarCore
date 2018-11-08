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
        [STAThread]
        static void Main()
        {
            new Components.Menus.MainMenu().Show();
            //new PresetMenu().Show();
            Application.Run();
            //new ControlForm().ShowDialog();
           // new MainWindow().Run(60);
        }
    }
}
