namespace SolarForms.Components.Menus
{
    partial class ExistingObjectsForm
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
            this.ObjectList = new MetroFramework.Controls.MetroListView();
            this.ColumnOne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConfirmButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
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
            this.ObjectList.Location = new System.Drawing.Point(23, 24);
            this.ObjectList.MultiSelect = false;
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.OwnerDraw = true;
            this.ObjectList.Size = new System.Drawing.Size(151, 236);
            this.ObjectList.TabIndex = 13;
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
            // ConfirmButton
            // 
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Location = new System.Drawing.Point(104, 266);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(70, 23);
            this.ConfirmButton.TabIndex = 14;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseSelectable = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(23, 266);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(70, 23);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseSelectable = true;
            // 
            // ExistingObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 303);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ObjectList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExistingObjectsForm";
            this.Resizable = false;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroListView ObjectList;
        private System.Windows.Forms.ColumnHeader ColumnOne;
        private MetroFramework.Controls.MetroButton ConfirmButton;
        private MetroFramework.Controls.MetroButton CancelButton;
    }
}