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
    public partial class AidatTakip : Form
    {
        public AidatTakip()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        

        private void AidatTakip_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select ogrencitc from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combogrenci.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_aidat where ogrencitc='"+combogrenci.Text+"'", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_aidat set ocak=@d1,subat=@d2,mart=@d3,nisan=@d4,mayis=@d5,haziran=@d6,temmuz=@d7,agustos=@d8,eylul=@d9,ekim=@d10,kasim=@d11,aralik=@d12 where ogrencitc = @d13", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", combocak.Text);
            komut.Parameters.AddWithValue("@d2", combosubat.Text);
            komut.Parameters.AddWithValue("@d3", combomart.Text);
            komut.Parameters.AddWithValue("@d4", combonisan.Text);
            komut.Parameters.AddWithValue("@d5", combomayis.Text);
            komut.Parameters.AddWithValue("@d6", combohaziran.Text);
            komut.Parameters.AddWithValue("@d7", cmbtemmuz.Text);
            komut.Parameters.AddWithValue("@d8", cmbagustos.Text);
            komut.Parameters.AddWithValue("@d9", cmbeylul.Text);
            komut.Parameters.AddWithValue("@d10", cmbekim.Text);
            komut.Parameters.AddWithValue("@d11", cmnkasim.Text);
            komut.Parameters.AddWithValue("@d12", cmbaralik.Text);
            komut.Parameters.AddWithValue("@d13", combogrenci.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Aidat Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            combocak.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            combosubat.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            combomart.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            combonisan.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            combomayis.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            combohaziran.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            cmbtemmuz.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            cmbagustos.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            cmbeylul.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            cmbekim.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            cmnkasim.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            cmbaralik.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiDetay frm = new YoneticiDetay();
            //frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_aidat (ocak,subat,mart,nisan,mayis,haziran,temmuz,agustos,eylul,ekim,kasim,aralik,ogrencitc) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", combocak.Text);
            komut.Parameters.AddWithValue("@d2", combosubat.Text);
            komut.Parameters.AddWithValue("@d3", combomart.Text);
            komut.Parameters.AddWithValue("@d4", combonisan.Text);
            komut.Parameters.AddWithValue("@d5", combomayis.Text);
            komut.Parameters.AddWithValue("@d6", combohaziran.Text);
            komut.Parameters.AddWithValue("@d7", cmbtemmuz.Text);
            komut.Parameters.AddWithValue("@d8", cmbagustos.Text);
            komut.Parameters.AddWithValue("@d9", cmbeylul.Text);
            komut.Parameters.AddWithValue("@d10", cmbekim.Text);
            komut.Parameters.AddWithValue("@d11", cmnkasim.Text);
            komut.Parameters.AddWithValue("@d12", cmbaralik.Text);
            komut.Parameters.AddWithValue("@d13", combogrenci.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Aidat Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
