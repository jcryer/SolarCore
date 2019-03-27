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
            // This method fills in all fields in the AdvancedControlForm that already have a corresponding value in the related Simulation object.
            Scale.Text = s.Scale.ToString();
            ObjectScale.Text = s.TrailScale.ToString();
            SpeedModifier.Text = s.SpeedModifier.ToString();
            ZoomModifier.Text = s.Camera.ZoomModifier.ToString();
            FixedCamera.Checked = s.Camera.Fixed;
            XPos.Text = s.Camera.LookAt.X.ToString();
            YPos.Text = s.Camera.LookAt.Y.ToString();
            ZPos.Text = s.Camera.LookAt.Z.ToString();
            MaximumSpeed.Text = s.MaximumSpeed.ToString();

            // Only allow the Camera position fields to be modified if the "Fixed Camera?" checkbox is ticked.
            if (FixedCamera.Checked)
            {
                XPos.Enabled = true;
                YPos.Enabled = true;
                ZPos.Enabled = true;
            }

            // Takes focus away from any other button in the form, meaning no button is highlighted on form open.
            metroButton1.Select();
        }

        private bool IsValidChar(char c, bool numbersOnly = false)
        {
            // Simple regex to validate character presses on the textboxes as they are pressed. 
            // If "numbersOnly" is true, only 0-9 is allowed.
            // Otherwise, 0-9, +, -, . and E are allowed.

            string regex = "";
            if (!numbersOnly) regex = "[\\d.E\b+-]+";
            else regex = "[\\d\b]+";

            if (!Regex.IsMatch(c.ToString(), regex))
            {
                // Returns true if the char is in the valid regex set.
                return true;
            }
            // Otherwise, returns false.
            return false;
        }

        private void Set()
        {
            // Attempts to update the Simulation object with the new values from the various fields.
            // As this form is primarily designed for experienced users on initial setup, no major validation was deemed necessary.
            // Therefore, only basic error catching has been implemented.
            try
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
            catch
            {

            }
        }

        private void ZoomModifier_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar, true))
                e.Handled = true;
        }

        private void Scale_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar, true))
                e.Handled = true;
        }

        private void ObjectScale_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar, true))
                e.Handled = true;
        }

        private void SpeedModifier_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar, true))
                e.Handled = true;
        }

        private void XPos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void YPos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void ZPos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void MaximumSpeed_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar, true))
                e.Handled = true;
        }

        private void FixedCamera_CheckedChanged(object sender, EventArgs e)
        {
            // Only allows the Camera position fields to be modified if the "Fixed Camera?" checkbox is ticked.
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

        // Triggers when the Save button is pressed.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Updates values in the Simulation object from the fields on the form.
            Set();
            // Sets the DialogResult of this Dialog window to "OK", meaning the parent form of this form will know that something has changed in the Simulation object.
            DialogResult = DialogResult.OK;
            // Closes the form, after all values have been updated in the Simulation object.
            Close();
        }

        // Triggers when the Cancel button is pressed.
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Closes the form. The DialogResult is not changed, and so the parent form will assume that nothing has changed in the Simulation object.
            Close();
        }
    }
}
