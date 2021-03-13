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
    public partial class PersonelDetayEkranı : Form
    {
        public PersonelDetayEkranı()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        public string TCno;
        private void PersonelDetayEkranı_Load(object sender, EventArgs e)
        {
            labeltc.Text = TCno;
            // ad soyad çekme
            SqlCommand komut = new SqlCommand("Select personelad,personelsoyad from tbl_personel where personeltc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", labeltc.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                labeladsoyad.Text = dr1[0] + " " + dr1[1];               
            }
            bgl.baglanti().Close();

        }

        private void butolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Yetkiliduyuru (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YetkiliProjeEkrani frm = new YetkiliProjeEkrani();
            frm.Show();
           // this.Hide();
        }

        private void butKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_ogrenci (OgrenciAd,OgrenciSoyad,Ogrencitc,Ogrencisifre,Ogrencianne,Ogrencibaba,Ogrenciveli,Ogrencialacak,Ogrenciyas,Ogrencitelefon,Ogrenciannetelefon,Ogrencibabatelefon,Ogrencisinif) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", maskedtc.Text);
            komut.Parameters.AddWithValue("@d4", txtsifre.Text);
            komut.Parameters.AddWithValue("@d5", txtanne.Text);
            komut.Parameters.AddWithValue("@d6", txtbaba.Text);
            komut.Parameters.AddWithValue("@d7", txtveli.Text);
            komut.Parameters.AddWithValue("@d8", richTextBox1.Text);
            komut.Parameters.AddWithValue("@d9", txtyas.Text);
            komut.Parameters.AddWithValue("@d10", maskedev.Text);
            komut.Parameters.AddWithValue("@d11", maskedanne.Text);
            komut.Parameters.AddWithValue("@d12", maskedbaba.Text);
            komut.Parameters.AddWithValue("@d13", comboBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
