namespace SolarForms.Components.Menus
{
    partial class SaveAsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAsForm));
            this.NameText = new MetroFramework.Controls.MetroTextBox();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.ErrorLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // NameText
            // 
            // 
            // 
            // 
            this.NameText.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.NameText.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.NameText.CustomButton.Name = "";
            this.NameText.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.NameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameText.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.NameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameText.CustomButton.UseSelectable = true;
            this.NameText.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.NameText.Lines = new string[0];
            resources.ApplyResources(this.NameText, "NameText");
            this.NameText.MaxLength = 32767;
            this.NameText.Name = "NameText";
            this.NameText.PasswordChar = '\0';
            this.NameText.PromptText = "Name";
            this.NameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameText.SelectedText = "";
            this.NameText.SelectionLength = 0;
            this.NameText.SelectionStart = 0;
            this.NameText.ShortcutsEnabled = true;
            this.NameText.UseSelectable = true;
            this.NameText.WaterMark = "Name";
            this.NameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseSelectable = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ErrorLabel
            // 
            resources.ApplyResources(this.ErrorLabel, "ErrorLabel");
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Style = MetroFramework.MetroColorStyle.Red;
            this.ErrorLabel.UseCustomForeColor = true;
            // 
            // SaveAsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NameText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveAsForm";
            this.Resizable = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox NameText;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroButton CancelButton;
        private MetroFramework.Controls.MetroLabel ErrorLabel;
    }
}