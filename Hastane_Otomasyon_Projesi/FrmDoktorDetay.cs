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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;


        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Doktor Ad soyad

            SqlCommand komutad = new SqlCommand("Select  DoktorAd,DoktorSoyad From Tbl_Doktor where DoktorTC=@p1", bgl.baglanti());
            komutad.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komutad.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + "" + dr[1];
            }
            bgl.baglanti().Close();

            //Randevular getir
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Randevu whre RandevuDoktor='" + LblAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource=(dt);
        
        }

        private void btnBilgiduzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle frm = new FrmDoktorBilgiDüzenle();
            frm.tc = LblTC.Text;
            frm.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
