﻿using OpenTK.Input;
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

namespace SolarForms.Components
{
    public partial class ControlForm : Form
    {
        public MainWindow Window;
        public ControlClass Controller;

        public ControlForm()
        {
            Controller = new ControlClass();
            InitializeComponent();
            KeyPreview = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           Controller.TimePeriod = SpeedControl.Value;
        }

        private void ControlForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Window == null)
            {
                Window = new MainWindow(this, Controller);
                Window.Run(60);
            }
        }

        public void ChangeSpeed (int val)
        {
            int newValue = SpeedControl.Value + val;

            if (SpeedControl.Minimum <= newValue && SpeedControl.Maximum >= newValue)
                SpeedControl.Value += val;
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Window != null)
                Window.Exit();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

        }

        private void PauseButton_Click(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {

        }
    }
}
