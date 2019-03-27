using MetroFramework.Forms;
using SolarForms.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class PresetForm : MetroForm
    {
        new int Location = 0;
        Simulation Simulation;
        List<Simulation> Simulations = new List<Simulation>();
        public PresetForm()
        {
            InitializeComponent();

            // Pulls all simulation from the database, and returns them as a list of Simulations.
            Simulations = DatabaseMethods.GetSimulations();

            // Foreach loop iterates through list of Simulations, adding each name to the table of objects on the form.
            foreach (var name in Simulations.Select(x => x.PlanetarySystem.Name))
            {
                PresetList.Items.Add(name);
            }
        }

        private void PresetMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Navigates to the relevant form, depending on what button has been previously pressed.
            if (Location == 1)
            {
                // Passes the selected Simulation object into the ControlForm form.
                new ControlForm(Simulation).Show();
            }
            else if (Location == 0)
                new SimForm().Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // If the Back button is clicked, the Location is set to 0. This means that in "PresetMenu_FormClosed", the form will redirect to SimForm.
            Location = 0;
            // Closes the form, triggering "PresetMenu_FormClosed".
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // If the Confirm button is clicked, the Location is set to 1. This means that in "PresetMenu_FormClosed", the form will redirect to ControlForm.
            Location = 1;
            // Closes the form, triggering "PresetMenu_FormClosed".
            Close();
        }

        // Occurs when the item selected in the list changes.
        private void PresetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check whether any objects are selected.
            if (PresetList.SelectedItems.Count == 0)
            {
                // If they aren't, disable the Confirm button.
                ConfirmButton.Enabled = false;
            }
            else
            {
                // If they are, enable the Confirm button.
                ConfirmButton.Enabled = true;

                if (Simulations.Any(x => x.PlanetarySystem.Name == PresetList.SelectedItems[0].Text))
                {
                    // Set the "Simulation" variable to be equal to the selected Simulation from the table, based on name.
                    Simulation = Simulations.First(x => x.PlanetarySystem.Name == PresetList.SelectedItems[0].Text);
                }
            }
        }

        // Occurs when an item in the list is double clicked.
        private void PresetList_DoubleClick(object sender, EventArgs e)
        {
            if (Simulations.Any(x => x.PlanetarySystem.Name == PresetList.SelectedItems[0].Text))
            {
                // Set the "Simulation" variable to be equal to the selected Simulation from the table, based on name.
                Simulation = Simulations.First(x => x.PlanetarySystem.Name == PresetList.SelectedItems[0].Text);
                Location = 1;
                Close();
            }
        }
    }
}
