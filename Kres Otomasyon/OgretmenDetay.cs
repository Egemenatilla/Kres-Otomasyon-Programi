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
    public partial class OgretmenDetay : Form
    {
        public OgretmenDetay()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        public string TCno;


        private void OgretmenDetay_Load(object sender, EventArgs e)
        {
            tc.Text = TCno;
            //ad soyad sınıf çekme
            SqlCommand komut = new SqlCommand("Select OgretmenAd,OgretmenSoyad,ogretmensinif from tbl_ogretmen where ogretmentc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                adsoyad.Text = dr1[0] + " " + dr1[1];
                lblsinif.Text = dr1[2].ToString();
            }
            bgl.baglanti().Close();

            //ogrenci listesi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_ogrenci where OgrenciSinif='" + lblsinif.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            
        }

        private void butolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert tbl_duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Yapıldı", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretmenDuyuruEkranı frm = new OgretmenDuyuruEkranı();
            frm.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_ogrenci where OgrenciSinif='" + lblsinif.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OkulDuyuruEkranı frm = new OkulDuyuruEkranı();
            frm.Show();
        }
    }
}
