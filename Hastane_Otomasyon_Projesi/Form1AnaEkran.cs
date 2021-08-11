using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hastane_Otomasyon_Projesi
{
    public partial class Form1AnaEkran : Form
    {
        public Form1AnaEkran()
        {
            InitializeComponent();
        }

        private void btnHastaGrisi_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frhastagirisi = new FrmHastaGiris();
            frhastagirisi.Show();
            this.Hide();
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frdoktorgirisi = new FrmDoktorGiris();
            frdoktorgirisi.Show();
           this.Hide();
        }

        private void btnSekreterGirisi_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frsekretergiris = new FrmSekreterGiris();
            frsekretergiris.Show();
            this.Hide();
        }
    }
}
