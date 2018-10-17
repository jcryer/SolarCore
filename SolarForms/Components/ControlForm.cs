using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarForms.Components
{
    public partial class ControlForm : Form
    {

        public ControlClass Controller;
        public ControlForm(MainWindow window)
        {
            Controller = window.Controller;
            InitializeComponent();
            KeyPreview = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Controller.TimePeriod = trackBar1.Value;
        }

        private void ControlForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K)
                trackBar1.Value += 1;
        }


    }
}
