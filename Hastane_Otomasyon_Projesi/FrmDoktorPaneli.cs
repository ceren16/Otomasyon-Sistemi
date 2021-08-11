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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select *From Tbl_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

        
        // branşı comboya aktarma 
            SqlCommand komutbr = new SqlCommand("Select BransAd From Tbl_Brans", bgl.baglanti());
            SqlDataReader drbr = komutbr.ExecuteReader();
            while (drbr.Read())
            {
                cmbBrans.Items.Add(drbr[0]);
            }
            bgl.baglanti().Close();
        }
    

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into Tbl_Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komutekle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutekle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutekle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutekle.Parameters.AddWithValue("@p5", txtSifre.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Doktor where DoktorTC=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", mskTC.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle=new SqlCommand("update Tbl_Doktor set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4  where HastaTC=@p4", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutguncelle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtSifre.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgi Güncellendi", "Bilgi", MessageBoxButtons.OK);
        }
    }
}
