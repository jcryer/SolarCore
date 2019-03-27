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
            // Navigates to the relevant form, depending on what button has been previously pressed.
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
            // If the Preset button is clicked, the Location is set to 1. This means that in "SimMenu_FormClosed", the form will redirect to PresetForm.
            Location = 1;
            // Closes the form, triggering "SimMenu_FormClosed".
            Close();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            // Opens the Windows File Selection Dialog form, and gets the user to select a file.
            // If "DialogResult.OK" is returned, then a file was selected.
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                // This attempts to read the selected file and deserialise the JSON object into a Simulation object. 
                // If this is successful, it then converts the six individual position and velocity values into the position and velocity vectors.
                // The location is then set to 2. This means that in "SimMenu_FormClosed", the form will redirect to ControlForm.
                try
                {
                    var sr = new StreamReader(FileDialog.FileName);
                    string simString = sr.ReadToEnd();
                    Sim = JsonConvert.DeserializeObject<Simulation>(simString);
                    Sim.PlanetarySystem.Objects.ForEach(x => x.GetVectors());
                    Sim.FromFile = true;

                    // The location is then set to 2. This means that in "SimMenu_FormClosed", the form will redirect to ControlForm.
                    Location = 2;
                    // Closes the form, triggering "SimMenu_FormClosed".
                    Close();
                }
                // If this fails, an error message shows, stating that the file may not be valid. The ControlForm does not open.
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Import failed. Is the file valid?");
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // If the Back button is clicked, the Location is set to 0. This means that in "SimMenu_FormClosed", the form will redirect to MainForm.
            Location = 0;
            // Closes the form, triggering "SimMenu_FormClosed".
            Close();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            // If the New Simulation button is clicked, the Location is set to 3. This means that in "SimMenu_FormClosed", the form will redirect to ControlForm.
            Location = 3;
            // Closes the form, triggering "SimMenu_FormClosed".
            Close();
        }
    }
}
