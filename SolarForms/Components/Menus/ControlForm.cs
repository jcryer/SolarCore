using MetroFramework.Forms;
using Newtonsoft.Json;
using SolarForms.Database;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class ControlForm : MetroForm
    {
        public MainWindow Window;
        public Simulation Simulation;
        public ControlForm(Simulation simulation = null)
        {
            InitializeComponent();
            Height = Screen.AllScreens[0].WorkingArea.Height;

            // Disable the Save button (as it is assumed the Simulation has been opened from a Preset)
            SaveSimulation.Enabled = false;

            // Checks to see whether a Simulation object has been passed into the initialiser method.
            if (simulation != null)
            {
                Simulation = simulation;
                Simulation.TrailScale = 100;
                Simulation.SpeedModifier = 10000;

                // Checks to see whether there are any objects in the current Simulation.
                if (!Simulation.PlanetarySystem.Objects.Any())
                {
                    // If there aren't, disable the Run button
                    RunButton.Enabled = false;
                }
                else
                {
                    // If there are, enable the Run button
                    RunButton.Enabled = true;
                }

                // Enable the Save button if the Simulation was imported from a file.
                if (Simulation.FromFile)
                {
                    SaveSimulation.Enabled = true;
                }
            }
            else
            {
                // If no Simulation object was passed into the initialiser method, set default values for the Simulation object.
                Simulation = new Simulation();
                Simulation.Camera = new Camera(10000, 10000, 0, false);
                Simulation.Scale = 10000000;
                Simulation.TrailScale = 100;
                Simulation.SpeedModifier = 100;
                Simulation.Speed = 1;

                // Disable the Run button, as no objects in the current Simulation.
                RunButton.Enabled = false;
            }
            KeyPreview = true;
            
            // Starts a thread that continuously checks to see whether any values have been changed by the MainWindow instance. 
            // If they have, updates the ControlForm.
            Thread t = new Thread(() => UpdateFields());
            t.Start();

            // Adds each object's name to the ControlForm object list.
            int id = 0;
            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                id++;
                ObjectList.Items.Add($"{id}: {obj.Name}");
                obj.ID = id;
            }
        }

        // Triggers when the Simulation window closes.
        private void Window_Closed(object sender, EventArgs e)
        {
            Window = null;
        }

        // Method that runs in a background thread. It continuously checks to see whether any values have been changed by the MainWindow instance.
        // If they have, update the ControlForm.
        private void UpdateFields()
        {
            while (true)
            {
                try
                {
                    MethodInvoker mi = delegate ()
                    {
                        SpeedControl.Maximum = Simulation.MaximumSpeed;
                        SpeedControl.Minimum = -Simulation.MaximumSpeed;
                        if (SpeedControl.Value != Simulation.Speed)
                        {
                            SpeedControl.Value = Simulation.Speed;
                        }
                        if (Simulation.CurrentFrame == 0 && Simulation.Speed <= 0)
                        {

                            // Shows an error message when the simulation has reached the beginning. 
                            // The speed is also set to 0.
                            Simulation.Speed = 0;
                            ErrorLabel.Text = "Reached Start of Sim";
                        }
                        else
                        {
                            ErrorLabel.Text = "";
                        }
                    };
                    Invoke(mi);
                }
                catch {}
                Thread.Sleep(200);
            }
        }
        
        // Triggers when the ControlForm is closing.
        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Closes the Simulation window as well.
            if (Window != null)
            {
                Window.Exit();
            }
        }

        // Triggers when the Speed Control slider value changes
        private void SpeedControl_ValueChanged(object sender, EventArgs e)
        {
            // Sets the Simulation speed to the Speed Control slider's value.
            Simulation.Speed = SpeedControl.Value;
        }

        // Triggers when the Play button is clicked.
        // Toggles between playing and pausing the simulation.
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (Simulation.Paused)
            {
                Simulation.Paused = false;
                PlayButton.Text = "Pause";
            }
            else
            {
                Simulation.Paused = true;
                PlayButton.Text = "Play";

            }
        }

        // Triggers when the Restart button is clicked.
        private void RestartButton_Click(object sender, EventArgs e)
        {
            // Resets the simulation.
            Window.ResetSim();
            Simulation.Speed = SpeedControl.Value;
        }

        // Triggers when the ControlForm is resized.
        private void ControlForm_Resize(object sender, EventArgs e)
        {
            // Makes the Simulation window fit perfectly next to the ControlForm menu when both are maximised.
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Size = new Size(Size.Width, Screen.AllScreens[0].WorkingArea.Height);
                Window.Height = Screen.AllScreens[0].WorkingArea.Height;
                Window.Width = Screen.AllScreens[0].WorkingArea.Width - Size.Width;
                Window.Location = new Point(Size.Width-10, 0);
            }
        }

        // Triggers when the Add button is clicked.
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Opens up a new instance of the ObjectForm.
            var form = new ObjectForm(Simulation);
            var result = form.ShowDialog();
            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // the ObjectForm has returned a SolarObject successfully.
            if (result == DialogResult.OK)
            {
                int last = 1;
                if (ObjectList.Items.Count != 0)
                {
                    last = ObjectList.Items.Count + 1;
                }
                form.SolarObject.ID = last;
                // Adds the new SolarObject to the Simulation Object list
                Simulation.PlanetarySystem.Objects.Add(form.SolarObject);
                // Adds the new SolarObject's name to the ControlForm object list
                ObjectList.Items.Add(form.SolarObject.ID + ": " + form.SolarObject.Name);
                // Enables the Run button if it wasn't already enabled, as there are now objects in the Simulation
                RunButton.Enabled = true;
                // Sets the "Changed" flag to true, to indicate to the Simulation Window that a new object has been added to the Simulation.
                if (Window != null) Simulation.Changed = true;
            }
        }

        // Triggers when the Remove button is clicked.
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            // Adds the relevant SolarObject to the "DeletedObjects" list, awaiting garbage collection by the Simulation window.
            Simulation.PlanetarySystem.DeletedObjects.Add(Simulation.PlanetarySystem.Objects.First(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text));
            // Removes the relevant SolarObject from the Simulation Object list.
            Simulation.PlanetarySystem.Objects.RemoveAll(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text);
            // Removes the relevant SolarObject's name from the ControlForm object list
            ObjectList.Items.Remove(ObjectList.SelectedItems[0]);

            // Disables the Run button if there are no more objects left in the Simulation.
            if (Simulation.PlanetarySystem.Objects.Count == 0)
                RunButton.Enabled = false;
            // Sets the "Changed" flag to true, to indicate to the Simulation Window that a new object has been added to the Simulation.
            if (Window != null) Simulation.Changed = true;

        }

        // Triggers when the Edit button is clicked.
        private void EditButton_Click(object sender, EventArgs e)
        {
            // Opens up a new instance of the ObjectForm. The selected object is passed into the instance.
            var form = new ObjectForm(Simulation, Simulation.PlanetarySystem.Objects.First(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text));
            var result = form.ShowDialog();
            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // the ObjectForm has returned the modified successfully.
            if (result == DialogResult.OK)
            {
                // The relevant SolarObject is updated from the form's returned SolarObject.
                Simulation.PlanetarySystem.Objects[Simulation.PlanetarySystem.Objects.IndexOf(form.SolarObject)] = form.SolarObject;
                // The relevant SolarObject's name is updated from the form's returned SolarObject's name.
                ObjectList.SelectedItems[0].Text = form.SolarObject.ID + ": " + form.SolarObject.Name;
                // Sets the "Changed" flag to true, to indicate to the Simulation Window that an object in the Simulation has been changed.
                if (Window != null) Simulation.Changed = true;
            }
        }

        // Occurs when the item selected in the list changes.
        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check whether any objects are selected.
            if (ObjectList.SelectedItems.Count == 0)
            {
                // If they aren't, disable the Remove and Edit buttons.
                RemoveButton.Enabled = false;
                EditButton.Enabled = false;
            }
            else
            {
                // If they aren't, enable the Remove and Edit buttons.
                RemoveButton.Enabled = true;
                EditButton.Enabled = true;
            }
        }

        // Triggers when the Run button is clicked.
        private void RunButton_Click(object sender, EventArgs e)
        {
            // Checks to see whether or not the Simulation window is already open.
            if (Window == null || Window.LocalIsDisposed)
            {
                // If it isn't, create a new instance of the Simulation window, and run it.
                Window = new MainWindow(Simulation);
                Window.Run(60);
                // Setup the Window.Closed event handler.
                Window.Closed += Window_Closed;
            }

        }

        // Occurs when the checkbox next to an item in the object list is ticked.
        private void ObjectList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            // Checks to see whether or not only one object has been ticked.
            if (ObjectList.CheckedItems.Count == 1)
            {
                // If it has, set the Simulation's focus (centre) to be that object.
                Simulation.Camera.Focus = int.Parse(ObjectList.CheckedItems[0].Text.Split(':')[0]) -1;
            }
            else
            {
                // If more than one object has been ticked, untick every other object.
                for (int i = 0; i < ObjectList.CheckedItems.Count; i++)
                {
                    if (ObjectList.CheckedItems[i] != item)
                    {
                        ObjectList.CheckedItems[i].Checked = false;
                    }
                }
            }
        }

        // Triggers when the Save button is pressed
        private void SaveSimulation_Click(object sender, EventArgs e)
        {
            // If the Simulation has previously been saved, update the relevant database records.
            if (Simulation.PlanetarySystem.Name != "")
            {
                DatabaseMethods.SetSimulation(Simulation);
                return;
            }
            // Otherwise, open a new instance of SaveAsForm.
            var form = new SaveAsForm();
            var result = form.ShowDialog();

            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // a new name for the Simulation has been successfully entered.
            if (result == DialogResult.OK)
            {
                // Sets the Simulation name as the form's response, and create and/or update the relevant database records.
                Simulation.PlanetarySystem.Name = form.Response;
                DatabaseMethods.SetSimulation(Simulation);
            }
        }

        // Triggers when the Back button is pressed
        private void BackButton_Click(object sender, EventArgs e)
        {
            // Opens a new MainForm instance.
            new MainForm().Show();
            // Closes the current form.
            Close();
        }

        // Triggers when the Advanced button is pressed.
        private void AdvancedButton_Click(object sender, EventArgs e)
        {
            // Open a new instance of AdvancedControlForm.
            var form = new AdvancedControlForm(Simulation);
            var result = form.ShowDialog();
            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // Simulation were successfully updated.
            if (result == DialogResult.OK)
            {
                // Updates the local Simulation object from the returned Simulation object
                Simulation = form.Simulation;
                // Sets the "Changed" flag to true, to indicate to the Simulation Window that some part of the Simulation has changed.
                Simulation.Changed = true;
            }
        }

        // Triggers when the Export button is pressed.
        private void ExportButton_Click(object sender, EventArgs e)
        {
            // Opens the Windows File Save Dialog form, and gets the user to select a save location and file name for the exported Simulation.
            // If "DialogResult.OK" is returned, then this was successful.
            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName != "")
            {
                // This converts the six individual position and velocity values into the position and velocity vectors.
                // It then attempts to serialise the currently open Simulation object into a JSON string.
                // If this is successful, it will then attempt to write the JSON string to the file location specified by the File Save Dialog.
                try
                {
                    Simulation.PlanetarySystem.Objects.ForEach(x => x.SetVectors());
                    string sim = JsonConvert.SerializeObject(Simulation);
                    File.WriteAllText(SaveFileDialog.FileName, sim);
                }
                // If this fails, an error message shows, stating that the location may not be valid.
                catch
                {
                    MessageBox.Show($"Export failed. Is the location valid?");
                }
            }
        }
    }
}