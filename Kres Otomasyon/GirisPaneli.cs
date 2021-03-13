using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kreş_Otomasyon
{
    public partial class GirisPaneli : Form
    {
        public GirisPaneli()
        {
            InitializeComponent();
        }

        private void btnogrenci_Click(object sender, EventArgs e)
        {
            OgrenciGiris frm = new OgrenciGiris();
            frm.Show();
            this.Hide();
        }

        private void btnogretmen_Click(object sender, EventArgs e)
        {
            OgretmenGiris frm = new OgretmenGiris();
            frm.Show();
            this.Hide();
        }

        private void btnpersonel_Click(object sender, EventArgs e)
        {
            PersonelGiris frm = new PersonelGiris();
            frm.Show();
            this.Hide();
        }

        private void btnyonetici_Click(object sender, EventArgs e)
        {
            YoneticiGiris frm = new YoneticiGiris();
            frm.Show();
            this.Hide();
        }
    }
}
