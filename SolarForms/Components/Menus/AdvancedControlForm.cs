using MetroFramework.Forms;
using OpenTK;
using SolarForms.Database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class AdvancedControlForm : MetroForm
    {
        public Simulation Simulation;
        public AdvancedControlForm(Simulation s)
        {
            Simulation = s;
            InitializeComponent();
            Update(Simulation);
        }

        private void Update(Simulation s)
        {
            Scale.Text = s.Scale.ToString();
            ObjectScale.Text = s.TrailScale.ToString();
            SpeedModifier.Text = s.SpeedModifier.ToString();
            ZoomModifier.Text = s.Camera.ZoomModifier.ToString();
            FixedCamera.Checked = s.Camera.Fixed;
            XPos.Text = s.Camera.LookAt.X.ToString();
            YPos.Text = s.Camera.LookAt.Y.ToString();
            ZPos.Text = s.Camera.LookAt.Z.ToString();
            MaximumSpeed.Text = s.MaximumSpeed.ToString();
            
            if (FixedCamera.Checked)
            {
                XPos.Enabled = true;
                YPos.Enabled = true;
                ZPos.Enabled = true;
            }
             
            metroButton1.Select();
        }

        private bool IsNumberKey(char c, bool i = false)
        {
            string regex = "";
            if (!i) regex = "[\\d.E\b+-]+";
            else regex = "[\\d\b]+";

            if (!Regex.IsMatch(c.ToString(), regex))
            {
                return true;
            }
            return false;

        }

        private void Set()
        {
            if (Scale.Text != "")
            {
                Simulation.Scale = int.Parse(Scale.Text);
            }
            if (ObjectScale.Text != "")
            {
                Simulation.TrailScale = int.Parse(ObjectScale.Text);
            }
            if (ZoomModifier.Text != "")
            {
                Simulation.Camera.ZoomModifier = int.Parse(ZoomModifier.Text);
            }
            if (SpeedModifier.Text != "")
            {
                Simulation.SpeedModifier = int.Parse(SpeedModifier.Text);
            }
            if (MaximumSpeed.Text != "")
            {
                Simulation.MaximumSpeed = int.Parse(MaximumSpeed.Text);
            }
            if (XPos.Text != "" && YPos.Text != "" && ZPos.Text != "")
            {
                Simulation.Camera.LookAt = new Vector3(float.Parse(XPos.Text), float.Parse(YPos.Text), float.Parse(ZPos.Text));
            }
            Simulation.Camera.Fixed = FixedCamera.Checked;
        }

        private void ZoomModifier_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar, true))
                e.Handled = true;
        }

        private void Scale_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar, true))
                e.Handled = true;
        }

        private void ObjectScale_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar, true))
                e.Handled = true;
        }

        private void SpeedModifier_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar, true))
                e.Handled = true;
        }

        private void XPos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void YPos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void ZPos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Set();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FixedCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (!FixedCamera.Checked)
            {
                XPos.Enabled = false;
                YPos.Enabled = false;
                ZPos.Enabled = false;
            }
            else
            {
                XPos.Enabled = true;
                YPos.Enabled = true;
                ZPos.Enabled = true;
            }
        }

        private void MaximumSpeed_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar, true))
                e.Handled = true;
        }
    }
}
