using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolarForms.Components;

namespace SolarForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new ControlForm().ShowDialog();
           // new MainWindow().Run(60);
        }
    }
}
