namespace SolarForms.Components.Menus
{
    partial class ObjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.XPos = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.NameTextbox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ZPos = new MetroFramework.Controls.MetroTextBox();
            this.YPos = new MetroFramework.Controls.MetroTextBox();
            this.YVec = new MetroFramework.Controls.MetroTextBox();
            this.ZVec = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.XVec = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.Mass = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.Radius = new MetroFramework.Controls.MetroTextBox();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.ColourDialog = new System.Windows.Forms.ColorDialog();
            this.testButton = new MetroFramework.Controls.MetroButton();
            this.ObjectColour = new System.Windows.Forms.TextBox();
            this.ExistingButton = new MetroFramework.Controls.MetroButton();
            this.TrailsActive = new MetroFramework.Controls.MetroCheckBox();
            this.TrailLength = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.TrailColour = new System.Windows.Forms.TextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.Obliquity = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.OrbitalSpeed = new MetroFramework.Controls.MetroTextBox();
            this.ObjectColourButton = new MetroFramework.Controls.MetroButton();
            this.TrailColourButton = new MetroFramework.Controls.MetroButton();
            this.ErrorMessage = new MetroFramework.Controls.MetroLabel();
            this.PositionPresetButton = new MetroFramework.Controls.MetroButton();
            this.VelocityPresetButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // XPos
            // 
            // 
            // 
            // 
            this.XPos.CustomButton.Image = null;
            this.XPos.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.XPos.CustomButton.Name = "";
            this.XPos.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.XPos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.XPos.CustomButton.TabIndex = 1;
            this.XPos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.XPos.CustomButton.UseSelectable = true;
            this.XPos.CustomButton.Visible = false;
            this.XPos.Lines = new string[0];
            this.XPos.Location = new System.Drawing.Point(143, 85);
            this.XPos.MaxLength = 32767;
            this.XPos.Name = "XPos";
            this.XPos.PasswordChar = '\0';
            this.XPos.PromptText = "X";
            this.XPos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.XPos.SelectedText = "";
            this.XPos.SelectionLength = 0;
            this.XPos.SelectionStart = 0;
            this.XPos.ShortcutsEnabled = true;
            this.XPos.Size = new System.Drawing.Size(100, 25);
            this.XPos.Style = MetroFramework.MetroColorStyle.Black;
            this.XPos.TabIndex = 0;
            this.XPos.UseSelectable = true;
            this.XPos.WaterMark = "X";
            this.XPos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.XPos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.XPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XPos_KeyPress);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(5, 85);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(112, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Initial Position (m)";
            // 
            // NameTextbox
            // 
            // 
            // 
            // 
            this.NameTextbox.CustomButton.Image = null;
            this.NameTextbox.CustomButton.Location = new System.Drawing.Point(267, 1);
            this.NameTextbox.CustomButton.Name = "";
            this.NameTextbox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.NameTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameTextbox.CustomButton.TabIndex = 1;
            this.NameTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameTextbox.CustomButton.UseSelectable = true;
            this.NameTextbox.CustomButton.Visible = false;
            this.NameTextbox.Lines = new string[0];
            this.NameTextbox.Location = new System.Drawing.Point(56, 44);
            this.NameTextbox.MaxLength = 32767;
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.PasswordChar = '\0';
            this.NameTextbox.PromptText = "Type a name here";
            this.NameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextbox.SelectedText = "";
            this.NameTextbox.SelectionLength = 0;
            this.NameTextbox.SelectionStart = 0;
            this.NameTextbox.ShortcutsEnabled = true;
            this.NameTextbox.Size = new System.Drawing.Size(291, 25);
            this.NameTextbox.TabIndex = 2;
            this.NameTextbox.UseSelectable = true;
            this.NameTextbox.WaterMark = "Type a name here";
            this.NameTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(5, 44);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Name";
            // 
            // ZPos
            // 
            // 
            // 
            // 
            this.ZPos.CustomButton.Image = null;
            this.ZPos.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.ZPos.CustomButton.Name = "";
            this.ZPos.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.ZPos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ZPos.CustomButton.TabIndex = 1;
            this.ZPos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ZPos.CustomButton.UseSelectable = true;
            this.ZPos.CustomButton.Visible = false;
            this.ZPos.Lines = new string[0];
            this.ZPos.Location = new System.Drawing.Point(356, 85);
            this.ZPos.MaxLength = 32767;
            this.ZPos.Name = "ZPos";
            this.ZPos.PasswordChar = '\0';
            this.ZPos.PromptText = "Z";
            this.ZPos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ZPos.SelectedText = "";
            this.ZPos.SelectionLength = 0;
            this.ZPos.SelectionStart = 0;
            this.ZPos.ShortcutsEnabled = true;
            this.ZPos.Size = new System.Drawing.Size(100, 25);
            this.ZPos.TabIndex = 4;
            this.ZPos.UseSelectable = true;
            this.ZPos.WaterMark = "Z";
            this.ZPos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ZPos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ZPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZPos_KeyPress);
            // 
            // YPos
            // 
            // 
            // 
            // 
            this.YPos.CustomButton.Image = null;
            this.YPos.CustomButton.Location = new System.Drawing.Point(74, 1);
            this.YPos.CustomButton.Name = "";
            this.YPos.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.YPos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.YPos.CustomButton.TabIndex = 1;
            this.YPos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.YPos.CustomButton.UseSelectable = true;
            this.YPos.CustomButton.Visible = false;
            this.YPos.Lines = new string[0];
            this.YPos.Location = new System.Drawing.Point(249, 85);
            this.YPos.MaxLength = 32767;
            this.YPos.Name = "YPos";
            this.YPos.PasswordChar = '\0';
            this.YPos.PromptText = "Y";
            this.YPos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.YPos.SelectedText = "";
            this.YPos.SelectionLength = 0;
            this.YPos.SelectionStart = 0;
            this.YPos.ShortcutsEnabled = true;
            this.YPos.Size = new System.Drawing.Size(98, 25);
            this.YPos.TabIndex = 5;
            this.YPos.UseSelectable = true;
            this.YPos.WaterMark = "Y";
            this.YPos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.YPos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.YPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YPos_KeyPress);
            // 
            // YVec
            // 
            // 
            // 
            // 
            this.YVec.CustomButton.Image = null;
            this.YVec.CustomButton.Location = new System.Drawing.Point(73, 1);
            this.YVec.CustomButton.Name = "";
            this.YVec.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.YVec.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.YVec.CustomButton.TabIndex = 1;
            this.YVec.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.YVec.CustomButton.UseSelectable = true;
            this.YVec.CustomButton.Visible = false;
            this.YVec.Lines = new string[0];
            this.YVec.Location = new System.Drawing.Point(250, 124);
            this.YVec.MaxLength = 32767;
            this.YVec.Name = "YVec";
            this.YVec.PasswordChar = '\0';
            this.YVec.PromptText = "Y";
            this.YVec.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.YVec.SelectedText = "";
            this.YVec.SelectionLength = 0;
            this.YVec.SelectionStart = 0;
            this.YVec.ShortcutsEnabled = true;
            this.YVec.Size = new System.Drawing.Size(97, 25);
            this.YVec.TabIndex = 9;
            this.YVec.UseSelectable = true;
            this.YVec.WaterMark = "Y";
            this.YVec.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.YVec.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.YVec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YVec_KeyPress);
            // 
            // ZVec
            // 
            // 
            // 
            // 
            this.ZVec.CustomButton.Image = null;
            this.ZVec.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.ZVec.CustomButton.Name = "";
            this.ZVec.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.ZVec.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ZVec.CustomButton.TabIndex = 1;
            this.ZVec.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ZVec.CustomButton.UseSelectable = true;
            this.ZVec.CustomButton.Visible = false;
            this.ZVec.Lines = new string[0];
            this.ZVec.Location = new System.Drawing.Point(356, 124);
            this.ZVec.MaxLength = 32767;
            this.ZVec.Name = "ZVec";
            this.ZVec.PasswordChar = '\0';
            this.ZVec.PromptText = "Z";
            this.ZVec.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ZVec.SelectedText = "";
            this.ZVec.SelectionLength = 0;
            this.ZVec.SelectionStart = 0;
            this.ZVec.ShortcutsEnabled = true;
            this.ZVec.Size = new System.Drawing.Size(100, 25);
            this.ZVec.TabIndex = 8;
            this.ZVec.UseSelectable = true;
            this.ZVec.WaterMark = "Z";
            this.ZVec.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ZVec.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ZVec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZVec_KeyPress);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(5, 124);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(126, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Initial Velocity (ms⁻¹)";
            // 
            // XVec
            // 
            // 
            // 
            // 
            this.XVec.CustomButton.Image = null;
            this.XVec.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.XVec.CustomButton.Name = "";
            this.XVec.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.XVec.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.XVec.CustomButton.TabIndex = 1;
            this.XVec.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.XVec.CustomButton.UseSelectable = true;
            this.XVec.CustomButton.Visible = false;
            this.XVec.Lines = new string[0];
            this.XVec.Location = new System.Drawing.Point(143, 124);
            this.XVec.MaxLength = 32767;
            this.XVec.Name = "XVec";
            this.XVec.PasswordChar = '\0';
            this.XVec.PromptText = "X";
            this.XVec.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.XVec.SelectedText = "";
            this.XVec.SelectionLength = 0;
            this.XVec.SelectionStart = 0;
            this.XVec.ShortcutsEnabled = true;
            this.XVec.Size = new System.Drawing.Size(100, 25);
            this.XVec.TabIndex = 6;
            this.XVec.UseSelectable = true;
            this.XVec.WaterMark = "X";
            this.XVec.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.XVec.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.XVec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XVec_KeyPress);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(5, 203);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(64, 19);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Mass (kg)";
            // 
            // Mass
            // 
            // 
            // 
            // 
            this.Mass.CustomButton.Image = null;
            this.Mass.CustomButton.Location = new System.Drawing.Point(130, 1);
            this.Mass.CustomButton.Name = "";
            this.Mass.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.Mass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Mass.CustomButton.TabIndex = 1;
            this.Mass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Mass.CustomButton.UseSelectable = true;
            this.Mass.CustomButton.Visible = false;
            this.Mass.Lines = new string[0];
            this.Mass.Location = new System.Drawing.Point(89, 203);
            this.Mass.MaxLength = 32767;
            this.Mass.Name = "Mass";
            this.Mass.PasswordChar = '\0';
            this.Mass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Mass.SelectedText = "";
            this.Mass.SelectionLength = 0;
            this.Mass.SelectionStart = 0;
            this.Mass.ShortcutsEnabled = true;
            this.Mass.Size = new System.Drawing.Size(154, 25);
            this.Mass.TabIndex = 10;
            this.Mass.UseSelectable = true;
            this.Mass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Mass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Mass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Mass_KeyPress);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(5, 242);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(71, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Radius (m)";
            // 
            // Radius
            // 
            // 
            // 
            // 
            this.Radius.CustomButton.Image = null;
            this.Radius.CustomButton.Location = new System.Drawing.Point(130, 1);
            this.Radius.CustomButton.Name = "";
            this.Radius.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.Radius.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Radius.CustomButton.TabIndex = 1;
            this.Radius.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Radius.CustomButton.UseSelectable = true;
            this.Radius.CustomButton.Visible = false;
            this.Radius.Lines = new string[0];
            this.Radius.Location = new System.Drawing.Point(89, 242);
            this.Radius.MaxLength = 32767;
            this.Radius.Name = "Radius";
            this.Radius.PasswordChar = '\0';
            this.Radius.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Radius.SelectedText = "";
            this.Radius.SelectionLength = 0;
            this.Radius.SelectionStart = 0;
            this.Radius.ShortcutsEnabled = true;
            this.Radius.Size = new System.Drawing.Size(154, 25);
            this.Radius.TabIndex = 12;
            this.Radius.UseSelectable = true;
            this.Radius.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Radius.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Radius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Radius_KeyPress);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(440, 322);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(356, 322);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseSelectable = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(521, 347);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(10, 10);
            this.testButton.TabIndex = 17;
            this.testButton.UseSelectable = true;
            this.testButton.Visible = false;
            // 
            // ObjectColour
            // 
            this.ObjectColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ObjectColour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ObjectColour.Enabled = false;
            this.ObjectColour.Location = new System.Drawing.Point(356, 164);
            this.ObjectColour.Multiline = true;
            this.ObjectColour.Name = "ObjectColour";
            this.ObjectColour.ReadOnly = true;
            this.ObjectColour.Size = new System.Drawing.Size(159, 25);
            this.ObjectColour.TabIndex = 18;
            // 
            // ExistingButton
            // 
            this.ExistingButton.Location = new System.Drawing.Point(356, 44);
            this.ExistingButton.Name = "ExistingButton";
            this.ExistingButton.Size = new System.Drawing.Size(159, 23);
            this.ExistingButton.TabIndex = 20;
            this.ExistingButton.Text = "Copy from Existing";
            this.ExistingButton.UseSelectable = true;
            this.ExistingButton.Click += new System.EventHandler(this.ExistingButton_Click);
            // 
            // TrailsActive
            // 
            this.TrailsActive.AutoSize = true;
            this.TrailsActive.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.TrailsActive.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.TrailsActive.Location = new System.Drawing.Point(355, 209);
            this.TrailsActive.Name = "TrailsActive";
            this.TrailsActive.Size = new System.Drawing.Size(98, 19);
            this.TrailsActive.TabIndex = 23;
            this.TrailsActive.Text = "Trails Active?";
            this.TrailsActive.UseSelectable = true;
            this.TrailsActive.CheckedChanged += new System.EventHandler(this.TrailsActive_CheckedChanged);
            // 
            // TrailLength
            // 
            // 
            // 
            // 
            this.TrailLength.CustomButton.Image = null;
            this.TrailLength.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.TrailLength.CustomButton.Name = "";
            this.TrailLength.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.TrailLength.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TrailLength.CustomButton.TabIndex = 1;
            this.TrailLength.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TrailLength.CustomButton.UseSelectable = true;
            this.TrailLength.CustomButton.Visible = false;
            this.TrailLength.Enabled = false;
            this.TrailLength.Lines = new string[0];
            this.TrailLength.Location = new System.Drawing.Point(356, 242);
            this.TrailLength.MaxLength = 32767;
            this.TrailLength.Name = "TrailLength";
            this.TrailLength.PasswordChar = '\0';
            this.TrailLength.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TrailLength.SelectedText = "";
            this.TrailLength.SelectionLength = 0;
            this.TrailLength.SelectionStart = 0;
            this.TrailLength.ShortcutsEnabled = true;
            this.TrailLength.Size = new System.Drawing.Size(159, 25);
            this.TrailLength.TabIndex = 24;
            this.TrailLength.UseSelectable = true;
            this.TrailLength.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TrailLength.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TrailLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrailLength_KeyPress);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(251, 242);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(75, 19);
            this.metroLabel8.TabIndex = 25;
            this.metroLabel8.Text = "Trail Length";
            // 
            // TrailColour
            // 
            this.TrailColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TrailColour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrailColour.Enabled = false;
            this.TrailColour.Location = new System.Drawing.Point(356, 282);
            this.TrailColour.Multiline = true;
            this.TrailColour.Name = "TrailColour";
            this.TrailColour.ReadOnly = true;
            this.TrailColour.Size = new System.Drawing.Size(159, 25);
            this.TrailColour.TabIndex = 21;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(251, 203);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(50, 25);
            this.metroLabel9.TabIndex = 26;
            this.metroLabel9.Text = "Trails";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(5, 282);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(79, 19);
            this.metroLabel10.TabIndex = 28;
            this.metroLabel10.Text = "Obliquity (°)";
            // 
            // Obliquity
            // 
            // 
            // 
            // 
            this.Obliquity.CustomButton.Image = null;
            this.Obliquity.CustomButton.Location = new System.Drawing.Point(130, 1);
            this.Obliquity.CustomButton.Name = "";
            this.Obliquity.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.Obliquity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Obliquity.CustomButton.TabIndex = 1;
            this.Obliquity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Obliquity.CustomButton.UseSelectable = true;
            this.Obliquity.CustomButton.Visible = false;
            this.Obliquity.Lines = new string[0];
            this.Obliquity.Location = new System.Drawing.Point(89, 282);
            this.Obliquity.MaxLength = 32767;
            this.Obliquity.Name = "Obliquity";
            this.Obliquity.PasswordChar = '\0';
            this.Obliquity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Obliquity.SelectedText = "";
            this.Obliquity.SelectionLength = 0;
            this.Obliquity.SelectionStart = 0;
            this.Obliquity.ShortcutsEnabled = true;
            this.Obliquity.Size = new System.Drawing.Size(154, 25);
            this.Obliquity.TabIndex = 27;
            this.Obliquity.UseSelectable = true;
            this.Obliquity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Obliquity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Obliquity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Obliquity_KeyPress);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(5, 166);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(130, 19);
            this.metroLabel11.TabIndex = 30;
            this.metroLabel11.Text = "Orbital Speed (ms⁻¹)";
            // 
            // OrbitalSpeed
            // 
            // 
            // 
            // 
            this.OrbitalSpeed.CustomButton.Image = null;
            this.OrbitalSpeed.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.OrbitalSpeed.CustomButton.Name = "";
            this.OrbitalSpeed.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.OrbitalSpeed.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.OrbitalSpeed.CustomButton.TabIndex = 1;
            this.OrbitalSpeed.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.OrbitalSpeed.CustomButton.UseSelectable = true;
            this.OrbitalSpeed.CustomButton.Visible = false;
            this.OrbitalSpeed.Lines = new string[0];
            this.OrbitalSpeed.Location = new System.Drawing.Point(141, 164);
            this.OrbitalSpeed.MaxLength = 32767;
            this.OrbitalSpeed.Name = "OrbitalSpeed";
            this.OrbitalSpeed.PasswordChar = '\0';
            this.OrbitalSpeed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OrbitalSpeed.SelectedText = "";
            this.OrbitalSpeed.SelectionLength = 0;
            this.OrbitalSpeed.SelectionStart = 0;
            this.OrbitalSpeed.ShortcutsEnabled = true;
            this.OrbitalSpeed.Size = new System.Drawing.Size(102, 25);
            this.OrbitalSpeed.TabIndex = 29;
            this.OrbitalSpeed.UseSelectable = true;
            this.OrbitalSpeed.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.OrbitalSpeed.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.OrbitalSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrbitalSpeed_KeyPress);
            // 
            // ObjectColourButton
            // 
            this.ObjectColourButton.Location = new System.Drawing.Point(251, 164);
            this.ObjectColourButton.Name = "ObjectColourButton";
            this.ObjectColourButton.Size = new System.Drawing.Size(96, 25);
            this.ObjectColourButton.TabIndex = 31;
            this.ObjectColourButton.Text = "Object Colour";
            this.ObjectColourButton.UseSelectable = true;
            this.ObjectColourButton.Click += new System.EventHandler(this.ObjectColourButton_Click);
            // 
            // TrailColourButton
            // 
            this.TrailColourButton.Enabled = false;
            this.TrailColourButton.Location = new System.Drawing.Point(249, 282);
            this.TrailColourButton.Name = "TrailColourButton";
            this.TrailColourButton.Size = new System.Drawing.Size(98, 25);
            this.TrailColourButton.TabIndex = 32;
            this.TrailColourButton.Text = "Trail Colour";
            this.TrailColourButton.UseSelectable = true;
            this.TrailColourButton.Click += new System.EventHandler(this.TrailColourButton_Click);
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(6, 322);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(0, 0);
            this.ErrorMessage.Style = MetroFramework.MetroColorStyle.Red;
            this.ErrorMessage.TabIndex = 33;
            this.ErrorMessage.UseStyleColors = true;
            // 
            // PositionPresetButton
            // 
            this.PositionPresetButton.Location = new System.Drawing.Point(462, 85);
            this.PositionPresetButton.Name = "PositionPresetButton";
            this.PositionPresetButton.Size = new System.Drawing.Size(53, 23);
            this.PositionPresetButton.TabIndex = 34;
            this.PositionPresetButton.Text = "Presets";
            this.PositionPresetButton.UseSelectable = true;
            this.PositionPresetButton.Click += new System.EventHandler(this.PositionPresetButton_Click);
            // 
            // VelocityPresetButton
            // 
            this.VelocityPresetButton.Location = new System.Drawing.Point(462, 124);
            this.VelocityPresetButton.Name = "VelocityPresetButton";
            this.VelocityPresetButton.Size = new System.Drawing.Size(53, 23);
            this.VelocityPresetButton.TabIndex = 35;
            this.VelocityPresetButton.Text = "Presets";
            this.VelocityPresetButton.UseSelectable = true;
            this.VelocityPresetButton.Click += new System.EventHandler(this.VelocityPresetButton_Click);
            // 
            // ObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 352);
            this.Controls.Add(this.VelocityPresetButton);
            this.Controls.Add(this.PositionPresetButton);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.TrailColourButton);
            this.Controls.Add(this.ObjectColourButton);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.OrbitalSpeed);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.Obliquity);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.TrailLength);
            this.Controls.Add(this.TrailsActive);
            this.Controls.Add(this.TrailColour);
            this.Controls.Add(this.ExistingButton);
            this.Controls.Add(this.ObjectColour);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.Mass);
            this.Controls.Add(this.YVec);
            this.Controls.Add(this.ZVec);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.XVec);
            this.Controls.Add(this.YPos);
            this.Controls.Add(this.ZPos);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.XPos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectForm";
            this.Resizable = false;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox XPos;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox NameTextbox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox ZPos;
        private MetroFramework.Controls.MetroTextBox YPos;
        private MetroFramework.Controls.MetroTextBox YVec;
        private MetroFramework.Controls.MetroTextBox ZVec;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox XVec;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox Mass;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox Radius;
        private MetroFramework.Controls.MetroButton SaveButton;
        private new MetroFramework.Controls.MetroButton CancelButton;
        private System.Windows.Forms.ColorDialog ColourDialog;
        private MetroFramework.Controls.MetroButton testButton;
        private System.Windows.Forms.TextBox ObjectColour;
        private MetroFramework.Controls.MetroButton ExistingButton;
        private MetroFramework.Controls.MetroCheckBox TrailsActive;
        private MetroFramework.Controls.MetroTextBox TrailLength;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.TextBox TrailColour;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox Obliquity;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox OrbitalSpeed;
        private MetroFramework.Controls.MetroButton ObjectColourButton;
        private MetroFramework.Controls.MetroButton TrailColourButton;
        private MetroFramework.Controls.MetroLabel ErrorMessage;
        private MetroFramework.Controls.MetroButton PositionPresetButton;
        private MetroFramework.Controls.MetroButton VelocityPresetButton;
    }
}