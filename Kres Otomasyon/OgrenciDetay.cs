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
    public partial class OgrenciDetay : Form
    {
        public OgrenciDetay()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        public string TCno;

        private void OgrenciDetay_Load(object sender, EventArgs e)
        {
            tc.Text = TCno;
            //AD Soyad
            SqlCommand komut = new SqlCommand("Select OgrenciAd, OgrenciSoyad from Tbl_Ogrenci where Ogrencitc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                adsoyad.Text = dr1[0] + " " + dr1[1];
            }
            bgl.baglanti().Close();
           
            //Sınıf adı
            SqlCommand komut1 = new SqlCommand("Select OgrenciSinif from Tbl_Ogrenci where Ogrencitc = @p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", tc.Text);
            SqlDataReader dr2 = komut1.ExecuteReader();
            while (dr2.Read())
            {
                lblsinif.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();

            //Ogretmen ad soyad            
            SqlCommand komut2 = new SqlCommand("Select OgretmenAd, OgretmenSoyad from Tbl_Ogretmen where ogretmensinif=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", lblsinif.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblogretmen.Text =dr[0]+" "+dr[1];
            }
            bgl.baglanti().Close();
            //bilgi getirme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_ogrenci where OgrenciTC='" + tc.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Aidat Bilgisi
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from tbl_aidat where Ogrencitc='" + tc.Text + "'", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;






        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciDuyuruEkranı frm = new OgrenciDuyuruEkranı();
            frm.sinifad = lblsinif.Text;
            frm.Show();
        }
    }
}
