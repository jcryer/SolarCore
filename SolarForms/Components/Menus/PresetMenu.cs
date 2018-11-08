using MetroFramework.Forms;
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
    public partial class PresetMenu : MetroForm
    {
        int Location = 0;
        Presets Preset = Presets.None;
        public PresetMenu()
        {
            InitializeComponent();
        }

        private void PresetMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Location == 1)
            {
                //new ControlForm().Show();
            }
            else if (Location == 0)
                new SimMenu().Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Location = 0;
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Location = 1;
            Close();
        }

        private void PresetList_Click(object sender, EventArgs e)
        {
           /* if (PresetList.SelectedItems.Count == 1)
            {
                ConfirmButton.Enabled = true;

                Console.WriteLine(PresetList.SelectedItems[0].Text);
            }
            else
            {
                ConfirmButton.Enabled = false;

            }*/

        }

        private void PresetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PresetList.SelectedItems.Count == 0)
            {
                ConfirmButton.Enabled = false;
                Preset = Presets.None;
            }
            else
            {
                ConfirmButton.Enabled = true;
                switch (PresetList.SelectedItems[0].Text)
                {
                    case "Binary Star":
                        Preset = Presets.BinaryStar;
                        break;
                    case "Solar System":
                        Preset = Presets.SolarSystem;
                        break;
                    case "Two-Body Diagram":
                        Preset = Presets.TwoBodyDiagram;
                        break;
                    case "Three-Body Diagram":
                        Preset = Presets.ThreeBodyDiagram;
                        break;
                    case "Black Hole":
                        Preset = Presets.BlackHole;
                        break;
                }
            }
        }
    }
    public enum Presets
    {
        None,
        BinaryStar,
        SolarSystem,
        TwoBodyDiagram,
        ThreeBodyDiagram,
        BlackHole
    }
}
