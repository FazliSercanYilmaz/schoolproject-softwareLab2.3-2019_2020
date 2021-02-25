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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (!Int32.TryParse(otoTextbox.Text, out i))
            {
                i = -1;
            }
            if (i >0)
            {
                Nodeolusturucusu.NodeOlusturucu(i);
                this.Hide();
                var vanaBaglama = new VanaBaglama();
                vanaBaglama.Closed += (s, args) => this.Close();
                vanaBaglama.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (!Int32.TryParse(otoTextbox.Text, out i))
            {
                i = -1;
            }
            if (i > 0)
            {
                Nodeolusturucusu.NodeOlusturucu(i);
                this.Hide();
                var manuelGiris = new ManuelGiris();
                manuelGiris.Closed += (s, args) => this.Close();
                manuelGiris.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
