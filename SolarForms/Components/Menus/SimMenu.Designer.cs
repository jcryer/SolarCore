namespace SolarForms.Components.Menus
{
    partial class SimMenu
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
            this.PresetButton = new MetroFramework.Controls.MetroButton();
            this.FileButton = new MetroFramework.Controls.MetroButton();
            this.NewButton = new MetroFramework.Controls.MetroButton();
            this.BackButton = new MetroFramework.Controls.MetroButton();
            this.testButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // PresetButton
            // 
            this.PresetButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.PresetButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.PresetButton.Location = new System.Drawing.Point(23, 63);
            this.PresetButton.Name = "PresetButton";
            this.PresetButton.Size = new System.Drawing.Size(342, 40);
            this.PresetButton.TabIndex = 10;
            this.PresetButton.Text = "Load From Presets";
            this.PresetButton.UseSelectable = true;
            this.PresetButton.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // FileButton
            // 
            this.FileButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.FileButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.FileButton.Location = new System.Drawing.Point(23, 117);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(342, 40);
            this.FileButton.TabIndex = 11;
            this.FileButton.Text = "Load From File";
            this.FileButton.UseSelectable = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.NewButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.NewButton.Location = new System.Drawing.Point(23, 172);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(342, 40);
            this.NewButton.TabIndex = 12;
            this.NewButton.Text = "New Custom Simulation";
            this.NewButton.UseSelectable = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BackButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BackButton.Location = new System.Drawing.Point(23, 227);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(342, 40);
            this.BackButton.TabIndex = 13;
            this.BackButton.Text = "Back";
            this.BackButton.UseSelectable = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(377, 277);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(10, 10);
            this.testButton.TabIndex = 14;
            this.testButton.UseSelectable = true;
            this.testButton.Visible = false;
            // 
            // SimMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 290);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.PresetButton);
            this.MaximizeBox = false;
            this.Name = "SimMenu";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Sim Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SimMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton PresetButton;
        private MetroFramework.Controls.MetroButton FileButton;
        private MetroFramework.Controls.MetroButton NewButton;
        private MetroFramework.Controls.MetroButton BackButton;
        private MetroFramework.Controls.MetroButton testButton;
    }
}