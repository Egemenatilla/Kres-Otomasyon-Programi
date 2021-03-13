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
    public partial class OgrenciPanel : Form
    {
        public OgrenciPanel()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiDetay frm = new YoneticiDetay();
            //frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_ogrenci", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedtc.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtanne.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtbaba.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtveli.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txtyas.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            maskedev.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            maskedanne.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            maskedbaba.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_ogrenci where ogrencitc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedtc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void butKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Ogrenci set OgrenciAd=@d1,OgrenciSoyad=@d2,OgrenciYas=@d3,OgrenciSinif=@d4,OgrenciSifre=@d5,OgrenciAnne=@d6,OgrenciBaba=@d7,OgrenciVeli=@d8,OgrenciAlacak=@d9,OgrenciTelefon=@d11,OgrenciAnneTelefon=@d12,OgrenciBabaTelefon=@d13  where OgrenciTC = @d10", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", txtyas.Text);
            komut.Parameters.AddWithValue("@d4", comboBox1.Text);
            komut.Parameters.AddWithValue("@d5", txtsifre.Text);
            komut.Parameters.AddWithValue("@d6", txtanne.Text);
            komut.Parameters.AddWithValue("@d7", txtbaba.Text);
            komut.Parameters.AddWithValue("@d8", txtveli.Text);
            komut.Parameters.AddWithValue("@d9", richTextBox1.Text);
            komut.Parameters.AddWithValue("@d10", maskedtc.Text);
            komut.Parameters.AddWithValue("@d11", maskedev.Text);
            komut.Parameters.AddWithValue("@d12", maskedanne.Text);
            komut.Parameters.AddWithValue("@d13", maskedbaba.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğretmen Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
