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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komutdok = new SqlCommand("Select *From Tbl_Doktor where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            komutdok.Parameters.AddWithValue("@p1", maskedTC.Text);
            komutdok.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komutdok.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frdok = new FrmDoktorDetay();
                frdok.tc = maskedTC.Text;
                frdok.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC ve şifre girdiniz");
            }
           
            bgl.baglanti().Close();
        }
    }
}
