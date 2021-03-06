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
    public partial class YetkiliProjeEkrani : Form
    {
        public YetkiliProjeEkrani()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void button3_Click(object sender, EventArgs e)
        {
            PersonelDetayEkranı frm = new PersonelDetayEkranı();
            //frm.Show();
            this.Hide();
        }

        private void YetkiliProjeEkrani_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_yetkiliduyuru", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update tbl_yetkiliduyuru set duyuru=@p1 where duyuruıd=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_yetkiliduyuru where duyuruID=@b1", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_yetkiliduyuru", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
}
