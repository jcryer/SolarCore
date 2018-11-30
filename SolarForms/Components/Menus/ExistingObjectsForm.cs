using MetroFramework.Forms;
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
        public ExistingObjectsForm()
        {
            InitializeComponent();
            foreach (var o in DatabaseMethods.GetObjects())
            {
                ObjectList.Items.Add(o.Name);
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
    }
}
