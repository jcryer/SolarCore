using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolarForms.Components;

namespace SolarForms
{
    static class Program
    {
        public static ControlClass Controller = new ControlClass();
        [STAThread]
        static void Main()
        {
            new MainWindow().Run(60);
        }
    }
}
