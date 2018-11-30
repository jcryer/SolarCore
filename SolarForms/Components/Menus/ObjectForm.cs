﻿using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SolarForms.Database;

namespace SolarForms.Components.Menus
{
    public partial class ObjectForm : MetroForm
    {
        Simulation Sim;
        public SolarObject obj;
        public ObjectForm(Simulation sim, SolarObject s = null)
        {
            Sim = sim;
            InitializeComponent();
            if (s != null)
            {
                obj = s;
                NameTextbox.Text = s.Name;
                XPos.Text = s.Position.X.ToString();
                YPos.Text = s.Position.Y.ToString();
                ZPos.Text = s.Position.Z.ToString();
                XVec.Text = s.Velocity.X.ToString();
                YVec.Text = s.Velocity.Y.ToString();
                ZVec.Text = s.Velocity.Z.ToString();
                Mass.Text = s.Mass.ToString();
                RadiusTextbox.Text = s.Radius.ToString();
                ColourDialog.Color = Color.FromArgb(s.ObjectColour.ToArgb());
                ColourSquare.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private bool IsNumberKey (char c)
        {
            if (!Regex.IsMatch(c.ToString(), "[\\d.E]+"))
            {
                return true;
            }
            return false;

        }
        private void XPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void YPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void ZPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void XVec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void YVec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void ZVec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void ColourSquare_TextChanged(object sender, EventArgs e)
        {
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                ColourSquare.BackColor = ColourDialog.Color;
                testButton.Select();

            }
        }

        private void ExistingButton_Click(object sender, EventArgs e)
        {
            new ExistingObjectsForm().Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
