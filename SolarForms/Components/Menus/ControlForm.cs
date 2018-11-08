using MetroFramework.Forms;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class ControlForm : MetroForm
    {

        public MainWindow Window;
        public ControlClass Controller;
        public ControlForm(ControlClass controller)
        {
            Controller = controller;
            InitializeComponent();
            KeyPreview = true;
            Thread t = new Thread(() => UpdateFields());
            t.Start();
            
        }
        
        private void UpdateFields()
        {
            while (true)
            {
                try
                {
                    MethodInvoker mi = delegate ()
                    {
                        if (SpeedControl.Value != Controller.TimePeriod)
                            SpeedControl.Value = Controller.TimePeriod;
                    };
                    Invoke(mi);
                }
                catch {}
                Thread.Sleep(200);
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           Controller.TimePeriod = SpeedControl.Value;
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
                Window = new MainWindow(Controller);
                Window.Run(60);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SpeedControl_ValueChanged(object sender, EventArgs e)
        {
            Controller.TimePeriod = SpeedControl.Value;

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Controller.Paused = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            Controller.Paused = true;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Window.ResetSim();
            Controller.TimePeriod = SpeedControl.Value;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void ControlForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Size = new Size(Size.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Window.Height = Screen.PrimaryScreen.WorkingArea.Height;
                Window.Width = Screen.PrimaryScreen.WorkingArea.Width - Size.Width;
                Window.Location = new Point(Size.Width-10, 0);
            }
        }
    }
}