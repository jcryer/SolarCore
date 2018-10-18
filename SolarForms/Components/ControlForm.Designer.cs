namespace SolarForms.Components
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.SpeedControlLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(12, 25);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = -20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(178, 45);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // SpeedControlLabel
            // 
            this.SpeedControlLabel.AutoSize = true;
            this.SpeedControlLabel.Location = new System.Drawing.Point(12, 9);
            this.SpeedControlLabel.Name = "SpeedControlLabel";
            this.SpeedControlLabel.Size = new System.Drawing.Size(74, 13);
            this.SpeedControlLabel.TabIndex = 1;
            this.SpeedControlLabel.Text = "Speed Control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 507);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SpeedControlLabel);
            this.Controls.Add(this.trackBar1);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label SpeedControlLabel;
        private System.Windows.Forms.Button button1;
    }
}