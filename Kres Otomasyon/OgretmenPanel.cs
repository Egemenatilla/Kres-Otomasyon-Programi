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
    public partial class OgretmenPanel : Form
    {
        public OgretmenPanel()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Ogretmen", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiDetay frm = new YoneticiDetay();
           // frm.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenTC,ogretmenyas,ogretmensinif,ogretmensifre,ogretmentelefon) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", maskedTC.Text);
            komut.Parameters.AddWithValue("@d4", txtyas.Text);
            komut.Parameters.AddWithValue("@d5", txtsinif.Text);
            komut.Parameters.AddWithValue("@d6", txtsifre.Text);
            komut.Parameters.AddWithValue("@d7", maskedTelefon.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğretmen Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtyas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsinif.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            maskedTelefon.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_ogretmen where ogretmentc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void butKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Ogretmen set OgretmenAd=@d1,OgretmenSoyad=@d2,OgretmenYas=@d3,OgretmenSinif=@d4,OgretmenSifre=@d5,OgretmenTelefon=@d6 where OgretmenTC = @d7", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);            
            komut.Parameters.AddWithValue("@d3", txtyas.Text);
            komut.Parameters.AddWithValue("@d4", txtsinif.Text);
            komut.Parameters.AddWithValue("@d5", txtsifre.Text);
            komut.Parameters.AddWithValue("@d6", maskedTelefon.Text);
            komut.Parameters.AddWithValue("@d7", maskedTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğretmen Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OgretmenPanel_Load(object sender, EventArgs e)
        {

        }

        
    }
}
