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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;
        SqlBaglantisi bgl = new SqlBaglantisi();


        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;
            //Ad soyada göre çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hasta where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + "" + dr[1];
            }
            bgl.baglanti().Close();

            //Hastanın randevu geçmişi

            DataTable dt = new DataTable();
            SqlDataAdapter da= new SqlDataAdapter ("Select *From Tbl_Randevu where HastaTC="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            //Branş Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Brans",bgl.baglanti() );
            SqlDataReader dr2 = komut2.ExecuteReader();
             while (dr2.Read())
            {
                comboBox1Brans.Items.Add(dr2[0]) ;
            }
             bgl.baglanti().Close();
        }
        //Branşa göre Doktor Çağırma 

        private void comboBox1Brans_SelectedIndexChanged(object sender, EventArgs e)
        {
              comboBox2Doktor.Items.Clear();
              SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktor where DoktorBrans=@p1", bgl.baglanti());
              komut3.Parameters.AddWithValue("@p1", comboBox1Brans.Text);
              SqlDataReader dr3 = komut3.ExecuteReader();
              while (dr3.Read())
            {
                comboBox2Doktor.Items.Add(dr3[0] + "" + dr3[1]);
            }
             bgl.baglanti().Close();
        }

        private void comboBox2Doktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Randevu where RandevuBrans='" + comboBox1Brans.Text + "'+ and RandevuDoktor='"+comboBox2Doktor.Text+"'and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void linkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle frbilgidüzenle = new FrmBilgiDuzenle();
            frbilgidüzenle.Show();
            frbilgidüzenle.tcno = LblTC.Text;  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            
        }

        private void button1RandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komutrandevu = new SqlCommand("update Tbl_Randevu set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where HastaId=@p3", bgl.baglanti());
            komutrandevu.Parameters.AddWithValue("@p1", LblTC.Text);
            komutrandevu.Parameters.AddWithValue("@p2", richTextBox1.Text);
            komutrandevu.Parameters.AddWithValue("@p3", txtID.Text);
            komutrandevu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("randevu alındı");
        }
        }
    }

