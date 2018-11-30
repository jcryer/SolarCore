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
            foreach (var obj in Simulation.PlanetarySystem.Objects)
            {
                ObjectList.Items.Add(obj.Name);
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
                if (Simulation.PlanetarySystem.Objects.Any(x => x.Id == form.obj.Id))
                {
                    Simulation.PlanetarySystem.Objects[Simulation.PlanetarySystem.Objects.IndexOf(form.obj)] = form.obj;
                }
                else
                {
                    Simulation.PlanetarySystem.Objects.Add(form.obj);
                    ObjectList.Items.Add(form.obj.Name);
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Simulation.PlanetarySystem.Objects.RemoveAll(x => x.Name == ObjectList.SelectedItems[0].Text);
            ObjectList.Items.Remove(ObjectList.SelectedItems[0]);
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

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