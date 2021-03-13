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
    public partial class YoneticiDetay : Form
    {
        public YoneticiDetay()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        public string TCno;

        private void YoneticiDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad Tc Çekme
            labeltc.Text = TCno;
            SqlCommand komut = new SqlCommand("Select YoneticiAd,YoneticiSoyad from tbl_yonetici where yoneticitc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", labeltc.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                labeladsoyad.Text = dr1[0] + " " + dr1[1];
                
            }
            bgl.baglanti().Close();
            //------
            //Öğretmenlerin Listelenmesi
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Ogretmen", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Sınıfların Listelenmesi
            DataTable dt2 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from tbl_Sinif", bgl.baglanti());
            da1.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Duyuruların Listelenmesi
            DataTable dt3 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Tbl_yetkiliduyuru", bgl.baglanti());
            da2.Fill(dt3);
            dataGridView3.DataSource = dt3;


        }

        private void butolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Yetkiliduyuru (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butogretmen_Click(object sender, EventArgs e)
        {
            OgretmenPanel frm = new OgretmenPanel();
            frm.Show();
            //this.Hide();
        }

        private void butogrenci_Click(object sender, EventArgs e)
        {
            OgrenciPanel frm = new OgrenciPanel();
            frm.Show();
            //this.Hide();
        }

        private void butsınıf_Click(object sender, EventArgs e)
        {
            SinifPaneli frm = new SinifPaneli();
            frm.Show();
           // this.Hide();
        }

        private void butduyuru_Click(object sender, EventArgs e)
        {
            YoneticiDuyuruEkrani frm = new YoneticiDuyuruEkrani();
            frm.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelPaneli frm = new PersonelPaneli();
            frm.Show();
           // this.Hide();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AidatTakip frm = new AidatTakip();
            frm.Show();
            //this.Hide();
        }
    }
}
