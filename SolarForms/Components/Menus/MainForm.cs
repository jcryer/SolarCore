﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace SolarForms.Components.Menus
{
    public partial class MainForm : MetroForm
    {
        new int Location = 0;
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            testButton.Select();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Location = 1;
            Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Location == 1)
                new SimForm().Show();
            else if (Location == 0)
            {
                Application.Exit();
            }
                //new ControlForm().Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Location = 0;
            Close();
        }
    }
}