namespace SolarForms.Components.Menus
{
    partial class PresetForm
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
            this.PresetList = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackButton = new MetroFramework.Controls.MetroButton();
            this.ConfirmButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // PresetList
            // 
            this.PresetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.PresetList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PresetList.FullRowSelect = true;
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
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 1000;
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
        private MetroFramework.Controls.MetroListView PresetList;
        private MetroFramework.Controls.MetroButton BackButton;
        private MetroFramework.Controls.MetroButton ConfirmButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}