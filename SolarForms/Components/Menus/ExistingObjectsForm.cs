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
        public SolarObject Object;
        public List<SolarObject> Objects;
        public ExistingObjectsForm()
        {
            Objects = DatabaseMethods.GetObjects();
            InitializeComponent();
            foreach (var o in Objects)
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

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Object = Objects.First(x => x.Name == ObjectList.SelectedItems[0].Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
