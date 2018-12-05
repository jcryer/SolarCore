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
            Mode = mode;
            InitializeComponent();

            if (mode == 0)
            {
                Objects = DatabaseMethods.GetObjects();
                foreach (var o in Objects)
                {
                    ObjectList.Items.Add(o.Name);
                }
            }
            else
            {
                Locations = DatabaseMethods.GetLocationPresets(mode-1);
                foreach (var o in Locations.Keys)
                {
                    ObjectList.Items.Add(o);
                }
            }
        }

        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItems.Count == 0)
            {
                ConfirmButton.Enabled = false;
            }
            else
            {
                ConfirmButton.Enabled = true;

            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (Mode == 0)
                Object = Objects.First(x => x.Name == ObjectList.SelectedItems[0].Text);
            else
                Location = Locations[ObjectList.SelectedItems[0].Text];

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
