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
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameText.Text))
            {
                Response = NameText.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            ErrorLabel.Show();
        }
    }
}