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

            if (SolarObject.ObjectColour.ToArgb() != 0)
                ObjectColour.BackColor = Color.FromArgb(SolarObject.ObjectColour.ToArgb());
            if (SolarObject.TrailColour.ToArgb() != 0)
                TrailColour.BackColor = Color.FromArgb(SolarObject.TrailColour.ToArgb());

            if (TrailsActive.Checked)
            {
                TrailLength.Enabled = true;
                TrailColour.Enabled = true;
                TrailColourButton.Enabled = true;
            }
            
            testButton.Select();
        }

        private bool SetName()
        {
            if (NameTextbox.Text != "")
            {
                SolarObject.Name = NameTextbox.Text;
                return true;
            }
            return false;
        }

        private int SetPosition() // 0: No issue. 1: Blank. 2: Parse error.
        {
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

        private int SetVelocity() // 0: No issue. 1: Blank. 2: Parse error.
        {
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

        private int SetMass() // 0: No issue. 1: Blank. 2: Parse error.
        {
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

        private int SetRadius() // 0: No issue. 1: Blank. 2: Parse error.
        {
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
            SolarObject.ObjectColour = ObjectColour.BackColor;
            SolarObject.TrailsActive = TrailsActive.Checked;
            SolarObject.TrailColour = TrailColour.BackColor;

            if (TrailLength.Text != "")
            {
                try {
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
                SolarObject.TrailLength = 1000;
            }

            if (Obliquity.Text != "")
            {
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
                SolarObject.Obliquity = 0;
            }

            if (OrbitalSpeed.Text != "")
            {
                try { 
                    SolarObject.OrbitalSpeed = double.Parse(OrbitalSpeed.Text);
                }
                catch
                {
                    SolarObject.OrbitalSpeed = 0;
                }
            }
            else
            {
                SolarObject.OrbitalSpeed = 0;
            }
        }

        private bool IsNumberKey (char c, bool i = false)
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

        private void OrbitalSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void Obliquity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar))
                e.Handled = true;
        }

        private void TrailLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumberKey(e.KeyChar, true))
                e.Handled = true;
        }
        private void ExistingButton_Click(object sender, EventArgs e)
        {
            var form = new ExistingObjectsForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                form.Object.Position = DatabaseMethods.GetLocationPresets(0)[form.Object.Name];
                form.Object.Velocity = DatabaseMethods.GetLocationPresets(1)[form.Object.Name];
                Update(form.Object);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrailsActive_CheckedChanged(object sender, EventArgs e)
        {
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
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                ObjectColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private void TrailColourButton_Click(object sender, EventArgs e)
        {
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                TrailColour.BackColor = ColourDialog.Color;
                testButton.Select();
            }
        }

        private void PositionPresetButton_Click(object sender, EventArgs e)
        {
            var form = new ExistingObjectsForm(1);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                SolarObject.Position = form.Location;
                Update(SolarObject);
            }
        }

        private void VelocityPresetButton_Click(object sender, EventArgs e)
        {
            var form = new ExistingObjectsForm(2);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                SolarObject.Velocity = form.Location;
                Update(SolarObject);
            }
        }
    }
}
