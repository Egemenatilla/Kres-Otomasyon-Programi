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
    public partial class OgretmenGiris : Form
    {
        public OgretmenGiris()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ogretmen where OgretmenTc=@p1 and OgretmenSifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                OgretmenDetay frm = new OgretmenDetay();
                frm.TCno = maskedTextBox1.Text;
                frm.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Yanlış TC No veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(maskedTextBox1.Text == "")
            {
                MessageBox.Show("Lütfen TC Kimlik Numaranızı Giriniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ogretmen where OgretmenTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);            
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Ogretmensifredegisimi frm = new Ogretmensifredegisimi();
                frm.TCno = maskedTextBox1.Text;
                frm.Show();

            }           
            
        }

        
    }
}
