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
    public partial class PersonelPaneli : Form
    {
        public PersonelPaneli()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_personel", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_personel (personelAd,personelSoyad,personelTC,personelyas,personeltelefon,personelsifre,) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", maskedtc.Text);
            komut.Parameters.AddWithValue("@d4", txtyas.Text);
            komut.Parameters.AddWithValue("@d5", maskedtelefon.Text);
            komut.Parameters.AddWithValue("@d6", txtsifre.Text);
            komut.Parameters.AddWithValue("@d7", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_personel where personeltc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedtc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Kaydı Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_personel set personelAd=@d1,personelSoyad=@d2,personelYas=@d3,personeltelefon=@d4,personelsifre=@d5 where OgretmenTC = @d6", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", txtyas.Text);
            komut.Parameters.AddWithValue("@d4", maskedtelefon.Text);
            komut.Parameters.AddWithValue("@d5", txtsifre.Text);            
            komut.Parameters.AddWithValue("@d6", maskedtc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiDetay frm = new YoneticiDetay();
            //frm.Show();
            this.Hide();
        }
    }
}
