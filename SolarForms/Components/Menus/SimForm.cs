using MetroFramework.Forms;
using Newtonsoft.Json;
using SolarForms.Components;
using SolarForms.Components.Menus;
using SolarForms.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class SimForm : MetroForm
    {
        new int Location = 0;
        Simulation Sim;

        public SimForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            testButton.Select();
        }

        private void SimMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Location == 1)
                new PresetForm().Show();
            else if (Location == 2)
            {
                if (Sim != null)
                {
                    new ControlForm(Sim).Show();
                }
            }
            else if (Location == 3)
            {
                new ControlForm().Show();
            }
            else if (Location == 0)
                new MainForm().Show();
        }

        private void PresetButton_Click(object sender, EventArgs e)
        {
            Location = 1;
            Close();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(FileDialog.FileName);
                    string simString = sr.ReadToEnd();
                    Sim = JsonConvert.DeserializeObject<Simulation>(simString);
                    Sim.PlanetarySystem.Objects.ForEach(x => x.GetVectors());

                    Location = 2;
                    Sim.FromFile = true;
                    Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Import failed. Is the file valid?");
                }
            }
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
