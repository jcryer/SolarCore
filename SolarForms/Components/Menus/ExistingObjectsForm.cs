using MetroFramework.Forms;
using OpenTK;
using SolarForms.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarForms.Components.Menus
{
    public partial class ExistingObjectsForm : MetroForm
    {
        public SolarObject Object;
        public Vector3 Location;
        public List<SolarObject> Objects;
        public Dictionary<string, Vector3> Locations;

        int Mode = 0;
        public ExistingObjectsForm(int mode = 0)
        {
            // If mode is 0, a list of objects is pulled from the database and their names are displayed in the table.
            // If mode is 1, a list of preset position values (for specific preset objects) is pulled from the database and their names are displayed in the table.
            // If mode is 2, a list of preset velocity values (for specific preset objects) is pulled from the database and their names are displayed in the table.

            Mode = mode;
            InitializeComponent();

            if (mode == 0)
            {
                // Pulls all objects from the database, and returns them as a list of SolarObjects.
                Objects = DatabaseMethods.GetObjects();

                // Foreach loop iterates through list of SolarObjects, adding each name to the table of objects on the form.
                foreach (var o in Objects)
                {
                    ObjectList.Items.Add(o.Name);
                }
            }
            else
            {
                // Pulls all relevant position/velocity (depending on the mode) presets from the database, and returns them as a Dictionary made up of strings (Object names) and Vector3 s.
                Locations = DatabaseMethods.GetLocationPresets(mode-1);
                foreach (var o in Locations.Keys)
                {
                    ObjectList.Items.Add(o);
                }
            }
        }

        // Occurs when the item selected in the list changes.
        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check whether any objects are selected.
            if (ObjectList.SelectedItems.Count == 0)
            {
                // If they aren't, disable the Confirm button.
                ConfirmButton.Enabled = false;
            }
            else
            {
                // If they are, enable the Confirm button.
                ConfirmButton.Enabled = true;
            }
        }

        // Occurs when the Confirm button is clicked.
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (Mode == 0)
                // Set the "Object" variable to be equal to the object selected in the list.
                Object = Objects.First(x => x.Name == ObjectList.SelectedItems[0].Text);
            else
                // Set the "Location" variable to be equal to the object position/velocity selected in the list (depending on mode)
                Location = Locations[ObjectList.SelectedItems[0].Text];

            // Sets the DialogResult of this Dialog window to "OK", meaning the parent form of this form will know that something has occured.
            DialogResult = DialogResult.OK;
            // Closes the form.
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Closes the form. The DialogResult is not changed, and so the parent form will assume that nothing has occured.
            Close();
        }
    }
}
