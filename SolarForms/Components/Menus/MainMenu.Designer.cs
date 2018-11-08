namespace SolarForms.Components.Menus
{
    partial class MainMenu
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
            this.QuitButton = new MetroFramework.Controls.MetroButton();
            this.SettingsButton = new MetroFramework.Controls.MetroButton();
            this.RunButton = new MetroFramework.Controls.MetroButton();
            this.testButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.QuitButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.QuitButton.Location = new System.Drawing.Point(23, 172);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(342, 40);
            this.QuitButton.TabIndex = 15;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseSelectable = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.SettingsButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.SettingsButton.Location = new System.Drawing.Point(23, 117);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(342, 40);
            this.SettingsButton.TabIndex = 14;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseSelectable = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.RunButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.RunButton.Location = new System.Drawing.Point(23, 63);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(342, 40);
            this.RunButton.TabIndex = 13;
            this.RunButton.Text = "Run Simulation";
            this.RunButton.UseSelectable = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(375, 218);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(10, 10);
            this.testButton.TabIndex = 12;
            this.testButton.UseSelectable = true;
            this.testButton.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 230);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.RunButton);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton QuitButton;
        private MetroFramework.Controls.MetroButton SettingsButton;
        private MetroFramework.Controls.MetroButton RunButton;
        private MetroFramework.Controls.MetroButton testButton;
    }
}