using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace SolarForms.Components.Menus
{
    public partial class MainForm : MetroForm
    {
        new int Location = 0;
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            testButton.Select();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Navigates to the relevant form, depending on what button has been previously pressed.
            if (Location == 1)
                new SimForm().Show();
            else if (Location == 0)
            {
                // Closes the application.
                Application.Exit();
            }
        }
        
        private void RunButton_Click(object sender, EventArgs e)
        {
            // If the Run button is clicked, the Location is set to 1. This means that in "MainMenu_FormClosed", the form will redirect to SimForm.
            Location = 1;
            // Closes the form, triggering "MainMenu_FormClosed".
            Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            // If the Run button is clicked, the Location is set to 0. This means that in "MainMenu_FormClosed", the application will close.
            Location = 0;
            // Closes the form, triggering "MainMenu_FormClosed".
            Close();
        }
    }
}
