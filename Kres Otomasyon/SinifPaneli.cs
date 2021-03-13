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
    public partial class SinifPaneli : Form
    {
        public SinifPaneli()
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
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_sinif", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_sinif (SinifAd) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", textsinif.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sınıf Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textsinif.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_sinif where sinifID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_sinif set sinifAd=@d1 where sinifID = @d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", textsinif.Text);
            komut.Parameters.AddWithValue("@d2", textıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sinif Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
