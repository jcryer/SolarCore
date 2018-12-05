using MetroFramework.Forms;
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
        public ControlForm(Presets preset = Presets.None)
        {
            Simulation = DatabaseMethods.GetSimulation(1);
            InitializeComponent();
            KeyPreview = true;
            Thread t = new Thread(() => UpdateFields());
            t.Start();
            if (preset != Presets.None)
            {
                metroButton1.PerformClick();
                Hide();
            }
            int id = 0;
            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                id++;
                ObjectList.Items.Add($"{id}: {obj.Name}");
                obj.ID = id;
            }
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

        private void ControlForm_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Window != null)
                Window.Exit();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
         //   metroButton1.PerformClick();

        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (Window == null)
            {
                Window = new MainWindow(Simulation);
                Window.Run(60);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void ControlForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Size = new Size(Size.Width, Screen.AllScreens[1].WorkingArea.Height);

                Window.Height = Screen.AllScreens[1].WorkingArea.Height;
                Window.Width = Screen.AllScreens[1].WorkingArea.Width - Size.Width;
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
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Simulation.PlanetarySystem.Objects.RemoveAll(x => x.Name == ObjectList.SelectedItems[0].Text);
            ObjectList.Items.Remove(ObjectList.SelectedItems[0]);
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var form = new ObjectForm(Simulation, Simulation.PlanetarySystem.Objects.First(x => x.ID + ": " + x.Name == ObjectList.SelectedItems[0].Text));
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Simulation.PlanetarySystem.Objects[Simulation.PlanetarySystem.Objects.IndexOf(form.SolarObject)] = form.SolarObject;
                ObjectList.SelectedItems[0].Text = form.SolarObject.ID + ": " + form.SolarObject.Name;
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
    }
}