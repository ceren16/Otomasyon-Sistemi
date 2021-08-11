using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hastane_Otomasyon_Projesi
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection("Data Source=DESKTOP-ETP7352\\SQLEXPRESS;Initial Catalog=Proje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
