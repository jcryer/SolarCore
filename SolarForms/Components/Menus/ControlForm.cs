using MetroFramework.Forms;
using OpenTK.Graphics.OpenGL4;
using SolarForms.Database;
using System;
using System.Drawing;
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
            
            if (simulation != null)
            {
                Simulation = simulation;
              //  Simulation.Camera = new Camera(10000, 10000, 0, true);
             //   Simulation.Scale = 10000000;
                Simulation.TrailScale = 100;
                Simulation.SpeedModifier = 100;
            //    Simulation.Speed = 1;
                
                if (!Simulation.PlanetarySystem.Objects.Any())
                {
                    RunButton.Enabled = false;
                    SaveSimulation.Enabled = false;
                }
                else
                {
                    RunButton.Enabled = true;
                    SaveSimulation.Enabled = true;
                }
            }
            else
            {
                Simulation = new Simulation();
                Simulation.Camera = new Camera(10000, 10000, 0, false);
                Simulation.Scale = 10000000;
                Simulation.TrailScale = 100;
                Simulation.SpeedModifier = 100;
                Simulation.Speed = 1;

                RunButton.Enabled = false;
            }
            KeyPreview = true;
            Thread t = new Thread(() => UpdateFields());
            t.Start();

            int id = 0;
            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                id++;
                ObjectList.Items.Add($"{id}: {obj.Name}");
                obj.ID = id;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window = null;

        }

        private void UpdateFields()
        {
            while (true)
            {
                try
                {
                    MethodInvoker mi = delegate ()
                    {
                        if (SpeedControl.Value != Simulation.Speed)
                            SpeedControl.Value = Simulation.Speed;
                    };
                    Invoke(mi);
                }
                catch {}
                Thread.Sleep(200);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Simulation.Speed = SpeedControl.Value;
        }
        
        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Window != null)
            {
                GL.Clear(ClearBufferMask.None);

                Window.Exit();
            }
        }
        
        private void SpeedControl_ValueChanged(object sender, EventArgs e)
        {
            Simulation.Speed = SpeedControl.Value;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Simulation.Paused = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            Simulation.Paused = true;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Window.ResetSim();
            Simulation.Speed = SpeedControl.Value;
        }

        private void ControlForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Size = new Size(Size.Width, Screen.AllScreens[0].WorkingArea.Height);
                Window.Height = Screen.AllScreens[0].WorkingArea.Height;
                Window.Width = Screen.AllScreens[0].WorkingArea.Width - Size.Width;
                Window.Location = new Point(Size.Width-10, 0);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            var form = new ObjectForm(Simulation);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                int last = 1;
                if (ObjectList.Items.Count != 0)
                {
                    last = ObjectList.Items.Count + 1;
                }
                form.SolarObject.ID = last;
                Simulation.PlanetarySystem.Objects.Add(form.SolarObject);
                ObjectList.Items.Add(form.SolarObject.ID + ": " + form.SolarObject.Name);
                RunButton.Enabled = true;
                if (Window != null) Simulation.Changed = true;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Simulation.PlanetarySystem.DeletedObjects.Add(Simulation.PlanetarySystem.Objects.First(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text));
            Simulation.PlanetarySystem.Objects.RemoveAll(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text);
            ObjectList.Items.Remove(ObjectList.SelectedItems[0]);
            if (Simulation.PlanetarySystem.Objects.Count == 0)
                RunButton.Enabled = false;
            if (Window != null) Simulation.Changed = true;

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var form = new ObjectForm(Simulation, Simulation.PlanetarySystem.Objects.First(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text));
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Simulation.PlanetarySystem.Objects[Simulation.PlanetarySystem.Objects.IndexOf(form.SolarObject)] = form.SolarObject;
                ObjectList.SelectedItems[0].Text = form.SolarObject.ID + ": " + form.SolarObject.Name;
                if (Window != null) Simulation.Changed = true;
            }
        }

        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItems.Count == 0)
            {
                RemoveButton.Enabled = false;
                EditButton.Enabled = false;
            }
            else
            {
                RemoveButton.Enabled = true;
                EditButton.Enabled = true;

            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (Window == null)
            {
                Window = new MainWindow(Simulation);
                Window.Run(60);
                Size = new Size(Size.Width, Screen.AllScreens[0].WorkingArea.Height);
                Window.Height = Screen.AllScreens[0].WorkingArea.Height;
                Window.Width = Screen.AllScreens[0].WorkingArea.Width - Size.Width;
                Window.Location = new Point(Size.Width - 10, 0);
            }
            Window.Closed += Window_Closed;

        }

        private void ObjectList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            if (ObjectList.CheckedItems.Count == 1)
            {
                Simulation.Camera.Focus = int.Parse(ObjectList.CheckedItems[0].Text.Split(':')[0]) -1;
            }
            else
            {
                for (int i = 0; i < ObjectList.CheckedItems.Count; i++)
                {
                    if (ObjectList.CheckedItems[i] != item)
                    {
                        ObjectList.CheckedItems[i].Checked = false;
                    }
                }
            }
        }


        private void SaveSimulation_Click(object sender, EventArgs e)
        {
            if (Simulation.PlanetarySystem.Name != "")
            {

                DatabaseMethods.SetSimulation(Simulation);
                return;
            }
            var form = new SaveAsForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Simulation.PlanetarySystem.Name = form.Response;
                DatabaseMethods.SetSimulation(Simulation);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {

            new MainMenu().Show();
            Close();
        }
    }
}