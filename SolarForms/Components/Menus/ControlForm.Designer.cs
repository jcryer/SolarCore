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
            this.RunButton = new MetroFramework.Controls.MetroButton();
            this.PlayButton = new MetroFramework.Controls.MetroButton();
            this.PauseButton = new MetroFramework.Controls.MetroButton();
            this.RestartButton = new MetroFramework.Controls.MetroButton();
            this.ObjectList = new MetroFramework.Controls.MetroListView();
            this.ColumnOne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new MetroFramework.Controls.MetroButton();
            this.RemoveButton = new MetroFramework.Controls.MetroButton();
            this.EditButton = new MetroFramework.Controls.MetroButton();
            this.AdvancedButton = new MetroFramework.Controls.MetroButton();
            this.SaveSimulation = new MetroFramework.Controls.MetroButton();
            this.BackButton = new MetroFramework.Controls.MetroButton();
            this.ErrorLabel = new MetroFramework.Controls.MetroLabel();
            this.ExportButton = new MetroFramework.Controls.MetroButton();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // SpeedControl
            // 
            this.SpeedControl.BackColor = System.Drawing.Color.Transparent;
            this.SpeedControl.LargeChange = 2;
            this.SpeedControl.Location = new System.Drawing.Point(12, 131);
            this.SpeedControl.Minimum = -100;
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
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(12, 83);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(172, 23);
            this.RunButton.TabIndex = 8;
            this.RunButton.Text = "Run";
            this.RunButton.UseSelectable = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.Location = new System.Drawing.Point(12, 349);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(80, 25);
            this.PlayButton.TabIndex = 9;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseSelectable = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseButton.Location = new System.Drawing.Point(104, 349);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(80, 25);
            this.PauseButton.TabIndex = 10;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseSelectable = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartButton.Location = new System.Drawing.Point(12, 380);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(172, 25);
            this.RestartButton.TabIndex = 11;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseSelectable = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // ObjectList
            // 
            this.ObjectList.AllowSorting = true;
            this.ObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectList.AutoArrange = false;
            this.ObjectList.CheckBoxes = true;
            this.ObjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnOne});
            this.ObjectList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ObjectList.FullRowSelect = true;
            this.ObjectList.Location = new System.Drawing.Point(12, 162);
            this.ObjectList.MultiSelect = false;
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.OwnerDraw = true;
            this.ObjectList.Scrollable = false;
            this.ObjectList.Size = new System.Drawing.Size(172, 148);
            this.ObjectList.TabIndex = 12;
            this.ObjectList.UseCompatibleStateImageBehavior = false;
            this.ObjectList.UseSelectable = true;
            this.ObjectList.View = System.Windows.Forms.View.List;
            this.ObjectList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ObjectList_ItemChecked);
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
            this.AddButton.Location = new System.Drawing.Point(12, 316);
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
            this.RemoveButton.Location = new System.Drawing.Point(73, 316);
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
            this.EditButton.Location = new System.Drawing.Point(134, 316);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(50, 25);
            this.EditButton.TabIndex = 15;
            this.EditButton.Text = "Edit";
            this.EditButton.UseSelectable = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AdvancedButton
            // 
            this.AdvancedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdvancedButton.Location = new System.Drawing.Point(12, 539);
            this.AdvancedButton.Name = "AdvancedButton";
            this.AdvancedButton.Size = new System.Drawing.Size(172, 23);
            this.AdvancedButton.TabIndex = 19;
            this.AdvancedButton.Text = "Advanced";
            this.AdvancedButton.UseSelectable = true;
            this.AdvancedButton.Click += new System.EventHandler(this.AdvancedButton_Click);
            // 
            // SaveSimulation
            // 
            this.SaveSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSimulation.Location = new System.Drawing.Point(12, 477);
            this.SaveSimulation.Name = "SaveSimulation";
            this.SaveSimulation.Size = new System.Drawing.Size(172, 25);
            this.SaveSimulation.TabIndex = 20;
            this.SaveSimulation.Text = "Save as Preset";
            this.SaveSimulation.UseSelectable = true;
            this.SaveSimulation.Click += new System.EventHandler(this.SaveSimulation_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Location = new System.Drawing.Point(12, 571);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(172, 23);
            this.BackButton.TabIndex = 21;
            this.BackButton.Text = "Back";
            this.BackButton.UseSelectable = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(12, 60);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 0);
            this.ErrorLabel.Style = MetroFramework.MetroColorStyle.Red;
            this.ErrorLabel.TabIndex = 22;
            this.ErrorLabel.UseStyleColors = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.Location = new System.Drawing.Point(12, 508);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(172, 25);
            this.ExportButton.TabIndex = 23;
            this.ExportButton.Text = "Export to File";
            this.ExportButton.UseSelectable = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 611);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveSimulation);
            this.Controls.Add(this.AdvancedButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ObjectList);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.SpeedControl);
            this.Controls.Add(this.SpeedControlLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlForm";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.Resize += new System.EventHandler(this.ControlForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTrackBar SpeedControl;
        private System.Windows.Forms.Label SpeedControlLabel;
        private MetroFramework.Controls.MetroButton RunButton;
        private MetroFramework.Controls.MetroButton PlayButton;
        private MetroFramework.Controls.MetroButton PauseButton;
        private MetroFramework.Controls.MetroButton RestartButton;
        private MetroFramework.Controls.MetroListView ObjectList;
        private System.Windows.Forms.ColumnHeader ColumnOne;
        private MetroFramework.Controls.MetroButton AddButton;
        private MetroFramework.Controls.MetroButton RemoveButton;
        private MetroFramework.Controls.MetroButton EditButton;
        private MetroFramework.Controls.MetroButton AdvancedButton;
        private MetroFramework.Controls.MetroButton SaveSimulation;
        private MetroFramework.Controls.MetroButton BackButton;
        private MetroFramework.Controls.MetroLabel ErrorLabel;
        private MetroFramework.Controls.MetroButton ExportButton;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}