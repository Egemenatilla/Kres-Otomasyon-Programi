using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kreş_Otomasyon
{
    class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=******;Initial Catalog=KreşOtomasyon;Integrated Security=True"); //** = your sql connect link
            baglan.Open();
            return baglan;
        }
    }
}
