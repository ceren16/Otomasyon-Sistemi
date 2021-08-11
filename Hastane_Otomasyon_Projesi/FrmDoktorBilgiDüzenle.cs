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
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;

        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            maskedTC.Text = tc;
            // tcverilen doktorun diğer bilgilerini getirme
            SqlCommand komuttik = new SqlCommand("Select *From Tbl_Doktor where DoktorTC=@p1", bgl.baglanti());
            komuttik.Parameters.AddWithValue("@p1", maskedTC.Text);
            SqlDataReader dr = komuttik.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                comboBox1Brans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();

            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutg = new SqlCommand("update Tbl_Doktor set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komutg.Parameters.AddWithValue("@p1", txtAd.Text);
            komutg.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutg.Parameters.AddWithValue("@p3", comboBox1Brans.Text);
            komutg.Parameters.AddWithValue("@p4", txtSifre.Text);
            komutg.Parameters.AddWithValue("@p5", maskedTC.Text);
            komutg.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncellendi");
        }
    }
}
