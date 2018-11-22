﻿namespace SolarForms.Components.Menus
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
            this.RadiusTextbox = new MetroFramework.Controls.MetroTextBox();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.ColourDialog = new System.Windows.Forms.ColorDialog();
            this.testButton = new MetroFramework.Controls.MetroButton();
            this.ColourSquare = new System.Windows.Forms.TextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
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
            this.metroLabel1.Location = new System.Drawing.Point(12, 85);
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
            this.NameTextbox.CustomButton.Location = new System.Drawing.Point(288, 1);
            this.NameTextbox.CustomButton.Name = "";
            this.NameTextbox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.NameTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameTextbox.CustomButton.TabIndex = 1;
            this.NameTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameTextbox.CustomButton.UseSelectable = true;
            this.NameTextbox.CustomButton.Visible = false;
            this.NameTextbox.Lines = new string[0];
            this.NameTextbox.Location = new System.Drawing.Point(144, 44);
            this.NameTextbox.MaxLength = 32767;
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.PasswordChar = '\0';
            this.NameTextbox.PromptText = "Type a name here";
            this.NameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextbox.SelectedText = "";
            this.NameTextbox.SelectionLength = 0;
            this.NameTextbox.SelectionStart = 0;
            this.NameTextbox.ShortcutsEnabled = true;
            this.NameTextbox.Size = new System.Drawing.Size(312, 25);
            this.NameTextbox.TabIndex = 2;
            this.NameTextbox.UseSelectable = true;
            this.NameTextbox.WaterMark = "Type a name here";
            this.NameTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 44);
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
            this.ZPos.Location = new System.Drawing.Point(355, 85);
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
            this.YPos.CustomButton.Location = new System.Drawing.Point(76, 1);
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
            this.YPos.Size = new System.Drawing.Size(100, 25);
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
            this.YVec.CustomButton.Location = new System.Drawing.Point(76, 1);
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
            this.YVec.Size = new System.Drawing.Size(100, 25);
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
            this.metroLabel3.Location = new System.Drawing.Point(12, 124);
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
            this.metroLabel4.Location = new System.Drawing.Point(13, 162);
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
            this.Mass.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.Mass.CustomButton.Name = "";
            this.Mass.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.Mass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Mass.CustomButton.TabIndex = 1;
            this.Mass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Mass.CustomButton.UseSelectable = true;
            this.Mass.CustomButton.Visible = false;
            this.Mass.Lines = new string[0];
            this.Mass.Location = new System.Drawing.Point(144, 162);
            this.Mass.MaxLength = 32767;
            this.Mass.Name = "Mass";
            this.Mass.PasswordChar = '\0';
            this.Mass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Mass.SelectedText = "";
            this.Mass.SelectionLength = 0;
            this.Mass.SelectionStart = 0;
            this.Mass.ShortcutsEnabled = true;
            this.Mass.Size = new System.Drawing.Size(131, 25);
            this.Mass.TabIndex = 10;
            this.Mass.UseSelectable = true;
            this.Mass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Mass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Mass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Mass_KeyPress);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(12, 201);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(71, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Radius (m)";
            // 
            // RadiusTextbox
            // 
            // 
            // 
            // 
            this.RadiusTextbox.CustomButton.Image = null;
            this.RadiusTextbox.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.RadiusTextbox.CustomButton.Name = "";
            this.RadiusTextbox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.RadiusTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RadiusTextbox.CustomButton.TabIndex = 1;
            this.RadiusTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.RadiusTextbox.CustomButton.UseSelectable = true;
            this.RadiusTextbox.CustomButton.Visible = false;
            this.RadiusTextbox.Lines = new string[0];
            this.RadiusTextbox.Location = new System.Drawing.Point(143, 201);
            this.RadiusTextbox.MaxLength = 32767;
            this.RadiusTextbox.Name = "RadiusTextbox";
            this.RadiusTextbox.PasswordChar = '\0';
            this.RadiusTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RadiusTextbox.SelectedText = "";
            this.RadiusTextbox.SelectionLength = 0;
            this.RadiusTextbox.SelectionStart = 0;
            this.RadiusTextbox.ShortcutsEnabled = true;
            this.RadiusTextbox.Size = new System.Drawing.Size(131, 25);
            this.RadiusTextbox.TabIndex = 12;
            this.RadiusTextbox.UseSelectable = true;
            this.RadiusTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.RadiusTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(375, 203);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(81, 23);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(280, 203);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 23);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseSelectable = true;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(460, 230);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(10, 10);
            this.testButton.TabIndex = 17;
            this.testButton.UseSelectable = true;
            this.testButton.Visible = false;
            // 
            // ColourSquare
            // 
            this.ColourSquare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ColourSquare.Enabled = false;
            this.ColourSquare.Location = new System.Drawing.Point(356, 162);
            this.ColourSquare.Multiline = true;
            this.ColourSquare.Name = "ColourSquare";
            this.ColourSquare.ReadOnly = true;
            this.ColourSquare.Size = new System.Drawing.Size(100, 25);
            this.ColourSquare.TabIndex = 18;
            this.ColourSquare.TextChanged += new System.EventHandler(this.ColourSquare_TextChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(290, 162);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(49, 19);
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "Colour";
            // 
            // ObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 239);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.ColourSquare);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.RadiusTextbox);
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
        private MetroFramework.Controls.MetroTextBox RadiusTextbox;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroButton CancelButton;
        private System.Windows.Forms.ColorDialog ColourDialog;
        private MetroFramework.Controls.MetroButton testButton;
        private System.Windows.Forms.TextBox ColourSquare;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}