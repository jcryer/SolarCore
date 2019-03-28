using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SolarForms.Database;
using OpenTK;
using KeyPressEventArgs = System.Windows.Forms.KeyPressEventArgs;

namespace SolarForms.Components.Menus
{
    public partial class ObjectForm : MetroForm
    {
        Simulation Sim;
        public SolarObject SolarObject;
        public ObjectForm(Simulation sim, SolarObject s = null)
        {

            Sim = sim;
            InitializeComponent();
            if (s != null)
            {
                Update(s);
            }
            else
            {
                SolarObject = new SolarObject();
            }
        }

        private void Update(SolarObject s)
        {
            // This method fills in all fields in the ObjectForm that already have a corresponding value in the object's related SolarObject
            // This will only trigger if "Edit" was selected on a pre-existing object.

            SolarObject = s;
            NameTextbox.Text = s.Name;
            XPos.Text = s.Position.X.ToString();
            YPos.Text = s.Position.Y.ToString();
            ZPos.Text = s.Position.Z.ToString();
            XVec.Text = s.Velocity.X.ToString();
            YVec.Text = s.Velocity.Y.ToString();
            ZVec.Text = s.Velocity.Z.ToString();
            Mass.Text = s.Mass.ToString();
            Radius.Text = s.Radius.ToString();
            OrbitalSpeed.Text = s.OrbitalSpeed.ToString();
            Obliquity.Text = s.Obliquity.ToString();
            TrailLength.Text = s.TrailLength.ToString();
            TrailsActive.Checked = SolarObject.TrailsActive;

            // Converting from OpenTK colour objects to System.Drawing colour objects in order to display the colour in the form.
            if (SolarObject.ObjectColour.ToArgb() != 0)
                ObjectColour.BackColor = Color.FromArgb(SolarObject.ObjectColour.ToArgb());
            if (SolarObject.TrailColour.ToArgb() != 0)
                TrailColour.BackColor = Color.FromArgb(SolarObject.TrailColour.ToArgb());

            // Only allow the "Trail Length" and "Trail Colour" values to be modified if the "Trails Active?" checkbox is ticked.
            if (TrailsActive.Checked)
            {
                TrailLength.Enabled = true;
                TrailColour.Enabled = true;
                TrailColourButton.Enabled = true;
            }
            
            // Takes focus away from any other button in the form, meaning no button is highlighted on form open.
            testButton.Select();
        }

        private bool SetName()
        {
            // Returns true if the SolarObject's name has been successfully updated with the new name from the textbox. Otherwise, returns false.
            if (NameTextbox.Text != "")
            {
                SolarObject.Name = NameTextbox.Text;
                return true;
            }
            return false;
        }

        private int SetPosition()
        {
            // Returns "0" if the SolarObject's position has been successfully updated with the new position values from the textboxes.
            // Returns "1" if any one of the position textboxes are empty.
            // Returns "2" if any one of the position textboxes cannot be successfully parsed from strings into floats.

            if (XPos.Text != "" && YPos.Text != "" && ZPos.Text != "")
            {
                try
                {
                    SolarObject.Position = new Vector3(float.Parse(XPos.Text), float.Parse(YPos.Text), float.Parse(ZPos.Text));
                    return 0;
                }
                catch
                {
                    return 2;
                }
            }
            return 1;
        }

        private int SetVelocity()
        {
            // Returns "0" if the SolarObject's velocity has been successfully updated with the new velocity values from the textboxes.
            // Returns "1" if any one of the velocity textboxes are empty.
            // Returns "2" if any one of the velocity textboxes cannot be successfully parsed from strings into floats.

            if (XVec.Text != "" && YVec.Text != "" && ZVec.Text != "")
            {
                try
                {
                    SolarObject.Velocity = new Vector3(float.Parse(XVec.Text), float.Parse(YVec.Text), float.Parse(ZVec.Text));
                    return 0;
                }
                catch
                {
                    return 2;
                }
            }
            return 1;
        }

        private int SetMass() 
        {
            // Returns "0" if the SolarObject's mass has been successfully updated with the new mass value from the textbox.
            // Returns "1" if the mass textbox is empty.
            // Returns "2" if the mass textbox cannot be successfully parsed from a string into a float.

            if (Mass.Text != "")
            {
                try
                {
                    var mass = double.Parse(Mass.Text);
                    SolarObject.Mass = mass;
                    return 0;
                }
                catch
                {
                    return 2;
                }
            }
            return 1;
        }

        private int SetRadius() 
        {
            // Returns "0" if the SolarObject's radius has been successfully updated with the new radius value from the textbox.
            // Returns "1" if the radius textbox is empty.
            // Returns "2" if the radius textbox cannot be successfully parsed from a string into a float.

            if (Radius.Text != "")
            {
                try
                {
                    SolarObject.Radius = double.Parse(Radius.Text);
                    return 0;
                }
                catch
                {
                    return 2;
                }
            }
            return 1;
        }

        private void SetOther()
        {
            // Updates all non-mandatory values of the SolarObject. 
            // If the values in the textboxes cannot successfully be parsed into the relevant data types or no value is entered whatsoever,
            // default values are set.

            SolarObject.ObjectColour = ObjectColour.BackColor;
            SolarObject.TrailsActive = TrailsActive.Checked;
            SolarObject.TrailColour = TrailColour.BackColor;

            if (TrailLength.Text != "")
            {
                // Attempts to parse the Trail Length to an int. If it fails or the resultant value is less than 0, the Trail Length is set to 0.
                try
                {
                    SolarObject.TrailLength = int.Parse(TrailLength.Text);
                    if (SolarObject.TrailLength < 0) SolarObject.TrailLength = 0;
                }
                catch
                {
                    SolarObject.TrailLength = 0;
                }
            }
            else
            {
                // If no value was entered into the Trail Length textbox, the Trail Length is set to 1000.
                SolarObject.TrailLength = 1000;
            }

            if (Obliquity.Text != "")
            {
                // Attempts to parse the Obliquity to a double. If it fails, the Obliquity is set to 0.
                try
                {
                    SolarObject.Obliquity = double.Parse(Obliquity.Text);
                }
                catch
                {
                    SolarObject.Obliquity = 0;
                }
            }
            else
            {
                // If no value was entered into the Obliquity textbox, the Obliquity is set to 0.
                SolarObject.Obliquity = 0;
            }

            if (OrbitalSpeed.Text != "")
            {
                // Attempts to parse the Orbital Speed to a double. If it fails, the Orbital Speed is set to 0.
                try
                { 
                    SolarObject.OrbitalSpeed = double.Parse(OrbitalSpeed.Text);
                }
                catch
                {
                    SolarObject.OrbitalSpeed = 0;
                }
            }
            else
            {
                // If no value was entered into the Orbital Speed textbox, the Orbital Speed is set to 0.
                SolarObject.OrbitalSpeed = 0;
            }
        }

        private bool IsValidChar (char c, bool numbersOnly = false)
        {
            // Simple regex to validate character presses on the textboxes as they are pressed. 
            // If "numbersOnly" is true, only 0-9 is allowed.
            // Otherwise, 0-9, +, -, . and E are allowed.

            string regex = "";
            if (!numbersOnly) regex = "[\\d.E\b+-]+";
            else regex = "[\\d\b]+";

            if (Regex.IsMatch(c.ToString(), regex))
            {
                // Returns true if the char is in the valid regex set.
                return true;
            }
            // Otherwise, returns false.
            return false;
        }

        private void XPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void YPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void ZPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void XVec_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void YVec_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void ZVec_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void OrbitalSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void Obliquity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void TrailLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the key pressed is a valid character for this field. If it isn't, prevent it from being typed.
            if (!IsValidChar(e.KeyChar, true))
                e.Handled = true;
        }
        private void ExistingButton_Click(object sender, EventArgs e)
        {
            // Opens up a new instance of the ExistingObjectsForm.
            var form = new ExistingObjectsForm();
            var result = form.ShowDialog();
            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // an object was selected and the "Confirm" button was pressed.
            if (result == DialogResult.OK)
            {
                // The selected object's position and velocity values are pulled from the database based on the selected object's name.
                // The form's SolarObject entity is then updated with these values.
                form.Object.Position = DatabaseMethods.GetLocationPresets(0)[form.Object.Name];
                form.Object.Velocity = DatabaseMethods.GetLocationPresets(1)[form.Object.Name];
                // The ObjectForm fields are updated with the new values, to show the change in position and velocity values to the user.
                Update(form.Object);
            }
        }

        private void TrailsActive_CheckedChanged(object sender, EventArgs e)
        {
            // Only allows the "Trail Length" and "Trail Colour" values to be modified if the "Trails Active?" checkbox is ticked.
            if (!TrailsActive.Checked)
            {
                TrailLength.Enabled = false;
                TrailColour.Enabled = false;
                TrailColourButton.Enabled = false;
            }
            else
            {
                TrailLength.Enabled = true;
                TrailColour.Enabled = true;
                TrailColourButton.Enabled = true;
            }
        }

        private void ObjectColourButton_Click(object sender, EventArgs e)
        {
            // Opens the Windows Colour Dialog form, and gets the user to select a colour.
            // If "DialogResult.OK" is returned, then a colour was selected, and the ObjectColour is therefore updated with the new value.
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                ObjectColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private void ObjectColour_Click(object sender, EventArgs e)
        {
            // Opens the Windows Colour Dialog form, and gets the user to select a colour.
            // If "DialogResult.OK" is returned, then a colour was selected, and the ObjectColour is therefore updated with the new value.
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                ObjectColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private void TrailColourButton_Click(object sender, EventArgs e)
        {
            // Opens the Windows Colour Dialog form, and gets the user to select a colour.
            // If "DialogResult.OK" is returned, then a colour was selected, and the TrailColour is therefore updated with the new value.
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                TrailColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private void PositionPresetButton_Click(object sender, EventArgs e)
        {
            // Opens up a new instance of the ExistingObjectsForm.
            var form = new ExistingObjectsForm(1);
            var result = form.ShowDialog();
            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // an object was selected and the "Confirm" button was pressed.
            if (result == DialogResult.OK)
            {
                // The SolarObject's position value is updated with the value selected from the preset dialog.
                SolarObject.Position = form.Location;
                // The ObjectForm fields are updated with the new values, to show the change in position values to the user.
                Update(SolarObject);
            }
        }

        private void VelocityPresetButton_Click(object sender, EventArgs e)
        {
            // Opens up a new instance of the ExistingObjectsForm.
            var form = new ExistingObjectsForm(2);
            var result = form.ShowDialog();
            // Waits until the form has closed, and then checks the outcome of it. If DialogResult.OK is returned, 
            // an object was selected and the "Confirm" button was pressed.
            if (result == DialogResult.OK)
            {
                // The SolarObject's position value is updated with the value selected from the preset dialog.
                SolarObject.Velocity = form.Location;
                // The ObjectForm fields are updated with the new values, to show the change in position values to the user.
                Update(SolarObject);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Performs a variety of checks as to whether the required fields are filled in and valid. 
            // For each field checked, relevant error messages have been written and are displayed on the form detailing the specific issue.
            // This method then returns.
            // If all checks pass, then something else occurs (see bottom of method).
       
            if (!SetName())
            {
                ErrorMessage.Text = "'Name' field must not be empty.";
                return;
            }
            if (SolarObject.Name.Length >= 30)
            {
                ErrorMessage.Text = "'Name' field must be less than 30 chars.";
                return;
            }

            int posResp = SetPosition();
            if (posResp == 1)
            {
                ErrorMessage.Text = "'Position' fields must not be empty.";
                return;
            }
            else if (posResp == 2)
            {
                ErrorMessage.Text = "'Position' fields are invalid.";
                return;
            }

            int velResp = SetVelocity();
            if (velResp == 1)
            {
                ErrorMessage.Text = "'Velocity' fields must not be empty.";
                return;
            }
            else if (velResp == 2)
            {
                ErrorMessage.Text = "'Velocity' fields are invalid.";
                return;
            }

            int massResp = SetMass();
            if (massResp == 1)
            {
                ErrorMessage.Text = "'Mass' field must not be empty.";
                return;
            }
            else if (massResp == 2)
            {
                ErrorMessage.Text = "'Mass' field is invalid.";
                return;
            }
            if (SolarObject.Mass <= 0)
            {
                ErrorMessage.Text = "'Mass' field must be greater than 0.";
                return;
            }

            int radResp = SetRadius();
            if (radResp == 1)
            {
                ErrorMessage.Text = "'Radius' field must not be empty.";
                return;
            }
            else if (radResp == 2)
            {
                ErrorMessage.Text = "'Radius' field is invalid.";
                return;
            }
            if (SolarObject.Radius <= 0)
            {
                ErrorMessage.Text = "'Radius' field must be greater than 0.";
                return;
            }
            SetOther();
            // Sets the DialogResult of this Dialog window to "OK", meaning the parent form of this form will know that something has changed in the SolarObject entity.
            DialogResult = DialogResult.OK;
            // Closes the form, after all values have been updated in the SolarObject entity.
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Closes the form. The DialogResult is not changed, and so the parent form will assume that nothing has changed in the SolarObject entity.
            Close();
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data for all preset objects is pulled from NASA's Horizons database.\n\n" +
                $"The co-ordinate system used is a heliocentric one - That is, the Sun is considered to be " +
                $"at the co-ordinates (0,0,0) and all other objects are relative to it.\n" +
                $"In reality, the Sun and all bodies orbiting it are orbiting our galactic centre at very high speeds, " +
                $"and our galaxy is also moving at very high speeds relative to other galaxies.\n\n" +
                $"The 'Copy from Existing' button copies an entire preset object into this object.\n" +
                $"The 'Presets' buttons copy either the preset position or velocity (depending on the button pressed) " +
                $"of a preset object into this object.");
        }

        private void ObjectColour_Click_1(object sender, EventArgs e)
        {
            // Opens the Windows Colour Dialog form, and gets the user to select a colour.
            // If "DialogResult.OK" is returned, then a colour was selected, and the ObjectColour 
            // is therefore updated with the new value.
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                ObjectColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private void TrailColour_Click(object sender, EventArgs e)
        {
            // Opens the Windows Colour Dialog form, and gets the user to select a colour.
            // If "DialogResult.OK" is returned, then a colour was selected, and the TrailColour
            // is therefore updated with the new value.
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                TrailColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }
    }
}