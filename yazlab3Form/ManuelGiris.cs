using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yazlab3;

namespace yazlab3Form
{
    public partial class ManuelGiris : Form
    {
        public ManuelGiris()
        {
            InitializeComponent();
            nodeListYenile();
        }
        private void nodeListYenile()
        {
            nodeList.ClearSelected();
            nodeList.Items.Clear();
            foreach(var vana in Nodeolusturucusu.vanalar)
            {
                nodeList.Items.Add(vana.ismi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nodeIsmi.Text != "" && nodeList.SelectedIndex !=-1)
            {
                Nodeolusturucusu.vanalar[nodeList.SelectedIndex].ismi = nodeIsmi.Text;
            }
            nodeListYenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var vanaBaglama = new VanaBaglama();
            vanaBaglama.Closed += (s, args) => this.Close();
            vanaBaglama.Show();
        }
    }
    
}
