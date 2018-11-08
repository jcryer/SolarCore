namespace SolarForms.Components.Menus
{
    partial class PresetMenu
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
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "Binary Star"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Segoe UI", 16F));
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "Solar System"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Segoe UI", 16F));
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "Two-Body Diagram"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Segoe UI", 16F));
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "Three-Body Diagram"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Segoe UI", 16F));
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "Black Hole"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Segoe UI", 16F));
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.PresetList = new MetroFramework.Controls.MetroListView();
            this.BackButton = new MetroFramework.Controls.MetroButton();
            this.ConfirmButton = new MetroFramework.Controls.MetroButton();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // PresetList
            // 
            this.PresetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.PresetList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PresetList.FullRowSelect = true;
            this.PresetList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15});
            this.PresetList.Location = new System.Drawing.Point(24, 64);
            this.PresetList.MultiSelect = false;
            this.PresetList.Name = "PresetList";
            this.PresetList.OwnerDraw = true;
            this.PresetList.Size = new System.Drawing.Size(351, 318);
            this.PresetList.TabIndex = 7;
            this.PresetList.UseCompatibleStateImageBehavior = false;
            this.PresetList.UseSelectable = true;
            this.PresetList.View = System.Windows.Forms.View.List;
            this.PresetList.SelectedIndexChanged += new System.EventHandler(this.PresetList_SelectedIndexChanged);
            this.PresetList.Click += new System.EventHandler(this.PresetList_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(24, 389);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(170, 40);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Back";
            this.BackButton.UseSelectable = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Location = new System.Drawing.Point(200, 389);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(175, 40);
            this.ConfirmButton.TabIndex = 9;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseSelectable = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 1000;
            // 
            // PresetMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 452);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PresetList);
            this.MaximizeBox = false;
            this.Name = "PresetMenu";
            this.Resizable = false;
            this.Text = "Preset Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PresetMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private MetroFramework.Controls.MetroListView PresetList;
        private MetroFramework.Controls.MetroButton BackButton;
        private MetroFramework.Controls.MetroButton ConfirmButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}