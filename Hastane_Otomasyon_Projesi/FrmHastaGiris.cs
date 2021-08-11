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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void linkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUyeOl frmuyeol = new FrmUyeOl();
            frmuyeol.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *From Tbl_Hasta where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay frhastadetay = new FrmHastaDetay();
                frhastadetay.tc = maskedTC.Text;
                frhastadetay.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Hatalı TC veya şifre,Lütfen bilgileri tekrar kontrol ediniz");
            }
            bgl.baglanti().Close();
        }

       

       
    }
}
