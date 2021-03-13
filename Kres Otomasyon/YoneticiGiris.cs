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
    public partial class YoneticiGiris : Form
    {
        public YoneticiGiris()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where yoneticiTc=@p1 and yoneticiSifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                YoneticiDetay frm = new YoneticiDetay();
                frm.TCno = maskedTextBox1.Text;
                frm.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Yanlış TC No veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
