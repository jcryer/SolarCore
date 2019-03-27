using MetroFramework.Forms;
using System;

namespace SolarForms.Components.Menus
{
    public partial class SaveAsForm : MetroForm
    {
        public string Response = "";
        public SaveAsForm()
        {
            InitializeComponent();
            ErrorLabel.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Closes the form. The DialogResult is not changed, and so the parent form will assume that nothing has occured.
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Checks whether or not a valid name has been entered.
            if (!string.IsNullOrWhiteSpace(NameText.Text))
            {
                Response = NameText.Text;
                // Sets the DialogResult of this Dialog window to "OK", meaning the parent form of this form will know that something has occured.
                DialogResult = System.Windows.Forms.DialogResult.OK;
                // Closes the form. 
                Close();
            }
            // If a valid name hasn't been entered, display an error message stating that a valid name must be entered.
            ErrorLabel.Show();
        }
    }
}