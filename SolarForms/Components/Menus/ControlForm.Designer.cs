namespace SolarForms.Components.Menus
{
    partial class ControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SpeedControl = new MetroFramework.Controls.MetroTrackBar();
            this.SpeedControlLabel = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PauseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PauseButton.BackgroundImage")));
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseButton.Location = new System.Drawing.Point(81, 459);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(33, 36);
            this.PauseButton.TabIndex = 3;
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayButton.BackgroundImage")));
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButton.Location = new System.Drawing.Point(32, 459);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(33, 36);
            this.PlayButton.TabIndex = 4;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ResetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResetButton.BackgroundImage")));
            this.ResetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetButton.Location = new System.Drawing.Point(132, 459);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(33, 36);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SpeedControl
            // 
            this.SpeedControl.BackColor = System.Drawing.Color.Transparent;
            this.SpeedControl.LargeChange = 2;
            this.SpeedControl.Location = new System.Drawing.Point(12, 131);
            this.SpeedControl.Maximum = 20;
            this.SpeedControl.Minimum = -20;
            this.SpeedControl.Name = "SpeedControl";
            this.SpeedControl.Size = new System.Drawing.Size(178, 23);
            this.SpeedControl.TabIndex = 7;
            this.SpeedControl.Text = "SpeedControl";
            this.SpeedControl.Value = 0;
            this.SpeedControl.ValueChanged += new System.EventHandler(this.metroTrackBar1_ValueChanged);
            // 
            // SpeedControlLabel
            // 
            this.SpeedControlLabel.AutoSize = true;
            this.SpeedControlLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedControlLabel.Location = new System.Drawing.Point(15, 109);
            this.SpeedControlLabel.Name = "SpeedControlLabel";
            this.SpeedControlLabel.Size = new System.Drawing.Size(99, 19);
            this.SpeedControlLabel.TabIndex = 1;
            this.SpeedControlLabel.Text = "Speed Control";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(12, 64);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(178, 23);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Run";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 507);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.SpeedControl);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.SpeedControlLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlForm";
            this.Text = "Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button ResetButton;
        private MetroFramework.Controls.MetroTrackBar SpeedControl;
        private System.Windows.Forms.Label SpeedControlLabel;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}