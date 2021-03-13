using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kreş_Otomasyon
{
    public partial class Ogretmensifredegisimi : Form
    {
        public Ogretmensifredegisimi()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        public string TCno;

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (maskedTextBox1.Text == lbltc.Text)
            {
                MessageBox.Show("Değişim Talebiniz Gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Yanlış TC Kimlik Numarası Girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Ogretmensifredegisimi_Load(object sender, EventArgs e)
        {
            lbltc.Text = TCno;           
               
            
        }
    }
}
