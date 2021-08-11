
namespace Hastane_Otomasyon_Projesi
{
    partial class FrmDuyurular
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1Duyurular = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1Duyurular)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1Duyurular
            // 
            this.dataGridView1Duyurular.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1Duyurular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1Duyurular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1Duyurular.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1Duyurular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1Duyurular.Name = "dataGridView1Duyurular";
            this.dataGridView1Duyurular.Size = new System.Drawing.Size(541, 406);
            this.dataGridView1Duyurular.TabIndex = 0;
            // 
            // FrmDuyurular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 406);
            this.Controls.Add(this.dataGridView1Duyurular);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDuyurular";
            this.Text = "FrmDuyurular";
            this.Load += new System.EventHandler(this.FrmDuyurular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1Duyurular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1Duyurular;
    }
}