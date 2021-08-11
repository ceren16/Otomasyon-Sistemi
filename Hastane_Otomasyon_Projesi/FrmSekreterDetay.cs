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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string tc;
        SqlBaglantisi bgl = new SqlBaglantisi();


        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Ad-Soyad

            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd From Tbl_Brans", bgl.baglanti());
            da.Fill(dt);
            datagridBrans.DataSource = dt;


            //Doktorları Listeye Aktarma 
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select (DoktorAd +''+DoktorSoyad) as 'Doktorlar',DoktorBrans From Tbl_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            datagridBrans.DataSource = dt1;


            //Branşı Comboya Aktarma 
            SqlCommand komutbr = new SqlCommand("Select BransAd From Tbl_Brans", bgl.baglanti());
            SqlDataReader drbr = komutbr.ExecuteReader();
            while (drbr.Read())
            {
                comboBox1Brans.Items.Add(drbr[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into Tbl_Randevu (RandevuTarih, RandevuSaat,RandevuBrans,RandevuDoktor) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut1.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut1.Parameters.AddWithValue("@p3", comboBox1Brans.Text);
            komut1.Parameters.AddWithValue("@p4", comboBox2Doktor.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturulmuştur", "Bilgi", MessageBoxButtons.OK);
        }

        private void comboBox1Brans_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2Doktor.Items.Clear();
            SqlCommand komutbrans = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktor where DoktorBrans=@p1", bgl.baglanti());
            komutbrans.Parameters.AddWithValue("@p1", comboBox1Brans.Text);
            SqlDataReader drdr = komutbrans.ExecuteReader();
            while (drdr.Read())
            {
                comboBox2Doktor.Items.Add(drdr[0] + "" + drdr[1]);

            }
            bgl.baglanti().Close();
        }

        private void button1olustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutduyuru = new SqlCommand("insert into Tbl_Duyuru (duyuru) values (@p1)", bgl.baglanti());
            komutduyuru.Parameters.AddWithValue("@p1", richTextBox1);
            komutduyuru.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frdoktorpaneli = new FrmDoktorPaneli();
            frdoktorpaneli.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frbranspaneli = new FrmBransPaneli();
            frbranspaneli.Show();
        }

        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frran = new FrmRandevuListesi();
            frran.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

    
    }
}

