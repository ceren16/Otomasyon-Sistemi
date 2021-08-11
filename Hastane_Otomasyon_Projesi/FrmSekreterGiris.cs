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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
             SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frsekreterdetay = new FrmSekreterDetay();
                frsekreterdetay.tc = maskedTC.Text;
                frsekreterdetay.Show();
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

