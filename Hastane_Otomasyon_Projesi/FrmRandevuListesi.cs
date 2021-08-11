using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Otomasyon_Projesi
{
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dtx = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Randevu", bgl.baglanti());
            da1.Fill(dtx);
            dataGridView1.DataSource = dtx; 
        }
        

        
    }
}
