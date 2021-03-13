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
    public partial class OgrenciDuyuruEkranı : Form
    {
        public OgrenciDuyuruEkranı()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        public string sinifad;
        private void OgrenciDuyuruEkranı_Load(object sender, EventArgs e)
        {
            label1.Text = sinifad;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_duyurular where duyurusinif = '"+label1.Text +"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
