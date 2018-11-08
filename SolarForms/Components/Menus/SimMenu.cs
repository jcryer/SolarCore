using MetroFramework.Forms;
using SolarForms.Components;
using SolarForms.Components.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class SimMenu : MetroForm
    {
        int Location = 0;

        public SimMenu()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            testButton.Select();
        }

        private void SimMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Location == 1)
                new PresetMenu().Show();
            else if (Location == 2)
                new SimMenu().Show();
            else if (Location == 3)
            {
                var ctrl = new ControlClass();
                new ControlForm(ctrl).Show();
            }
            else if (Location == 0)
                new MainMenu().Show();
        }

        private void PresetButton_Click(object sender, EventArgs e)
        {
            Location = 1;
            Close();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            Location = 2;
            Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Location = 0;
            Close();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Location = 3;
            Close();
        }
    }
}
