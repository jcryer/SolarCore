using MetroFramework.Forms;
using SolarForms.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class PresetMenu : MetroForm
    {
        new int Location = 0;
        Simulation Simulation;
        List<Simulation> Simulations = new List<Simulation>();
        public PresetMenu()
        {
            InitializeComponent();
            Simulations = DatabaseMethods.GetSimulations();
            foreach (var name in Simulations.Select(x => x.PlanetarySystem.Name))
            {
                PresetList.Items.Add(name);
            }
        }

        private void PresetMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Location == 1)
            {
                new ControlForm(Simulation).Show();
            }
            else if (Location == 0)
                new SimMenu().Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Location = 0;
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Location = 1;
            Close();
        }

        private void PresetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PresetList.SelectedItems.Count == 0)
            {
                ConfirmButton.Enabled = false;
            }
            else
            {
                ConfirmButton.Enabled = true;

                if (Simulations.Any(x => x.PlanetarySystem.Name == PresetList.SelectedItems[0].Text))
                {
                    Simulation = Simulations.First(x => x.PlanetarySystem.Name == PresetList.SelectedItems[0].Text);
                }
            }
        }
    }
}
