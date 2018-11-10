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
            this.SpeedControl = new MetroFramework.Controls.MetroTrackBar();
            this.SpeedControlLabel = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.PlayButton = new MetroFramework.Controls.MetroButton();
            this.PauseButton = new MetroFramework.Controls.MetroButton();
            this.RestartButton = new MetroFramework.Controls.MetroButton();
            this.ObjectList = new MetroFramework.Controls.MetroListView();
            this.ColumnOne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new MetroFramework.Controls.MetroButton();
            this.RemoveButton = new MetroFramework.Controls.MetroButton();
            this.EditButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // SpeedControl
            // 
            this.SpeedControl.BackColor = System.Drawing.Color.Transparent;
            this.SpeedControl.LargeChange = 2;
            this.SpeedControl.Location = new System.Drawing.Point(12, 131);
            this.SpeedControl.Maximum = 500;
            this.SpeedControl.Minimum = -500;
            this.SpeedControl.Name = "SpeedControl";
            this.SpeedControl.Size = new System.Drawing.Size(172, 23);
            this.SpeedControl.TabIndex = 7;
            this.SpeedControl.Text = "SpeedControl";
            this.SpeedControl.Value = 0;
            this.SpeedControl.ValueChanged += new System.EventHandler(this.SpeedControl_ValueChanged);
            // 
            // SpeedControlLabel
            // 
            this.SpeedControlLabel.AutoSize = true;
            this.SpeedControlLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedControlLabel.Location = new System.Drawing.Point(8, 109);
            this.SpeedControlLabel.Name = "SpeedControlLabel";
            this.SpeedControlLabel.Size = new System.Drawing.Size(99, 19);
            this.SpeedControlLabel.TabIndex = 1;
            this.SpeedControlLabel.Text = "Speed Control";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(12, 64);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(172, 23);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Run";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.Location = new System.Drawing.Point(12, 395);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(172, 25);
            this.PlayButton.TabIndex = 9;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseSelectable = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseButton.Location = new System.Drawing.Point(12, 426);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(172, 25);
            this.PauseButton.TabIndex = 10;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseSelectable = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartButton.Location = new System.Drawing.Point(12, 457);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(172, 25);
            this.RestartButton.TabIndex = 11;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseSelectable = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // ObjectList
            // 
            this.ObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnOne});
            this.ObjectList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ObjectList.FullRowSelect = true;
            this.ObjectList.Location = new System.Drawing.Point(12, 162);
            this.ObjectList.MultiSelect = false;
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.OwnerDraw = true;
            this.ObjectList.Size = new System.Drawing.Size(172, 184);
            this.ObjectList.TabIndex = 12;
            this.ObjectList.UseCompatibleStateImageBehavior = false;
            this.ObjectList.UseSelectable = true;
            this.ObjectList.View = System.Windows.Forms.View.List;
            this.ObjectList.SelectedIndexChanged += new System.EventHandler(this.ObjectList_SelectedIndexChanged);
            // 
            // ColumnOne
            // 
            this.ColumnOne.Text = "Objects";
            this.ColumnOne.Width = 147;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(12, 352);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(50, 25);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Add";
            this.AddButton.UseSelectable = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(73, 352);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(50, 25);
            this.RemoveButton.TabIndex = 14;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseSelectable = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(134, 352);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(50, 25);
            this.EditButton.TabIndex = 15;
            this.EditButton.Text = "Edit";
            this.EditButton.UseSelectable = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 500);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ObjectList);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.SpeedControl);
            this.Controls.Add(this.SpeedControlLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlForm";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.Resize += new System.EventHandler(this.ControlForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTrackBar SpeedControl;
        private System.Windows.Forms.Label SpeedControlLabel;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton PlayButton;
        private MetroFramework.Controls.MetroButton PauseButton;
        private MetroFramework.Controls.MetroButton RestartButton;
        private MetroFramework.Controls.MetroListView ObjectList;
        private System.Windows.Forms.ColumnHeader ColumnOne;
        private MetroFramework.Controls.MetroButton AddButton;
        private MetroFramework.Controls.MetroButton RemoveButton;
        private MetroFramework.Controls.MetroButton EditButton;
    }
}