using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BA_APPS
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            //this.pictureBox.Image = Properties.Resources.InformationImage;
            //LoadTheProgressBar();
        }

        private void LoadTheProgressBar()
        {
            //this.pictureBox3.Width = 0;
            this.progressBar1.Value = 0;

            this.timer1.Interval = 100;
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value < 100)
            {
                this.progressBar1.Value++;
                label1.Text = "Melakukan Koneksi Ke Database, Mohon Tunggu.....";
                label2.Text = this.progressBar1.Value.ToString() + " %";

                if (this.progressBar1.Value > 25)
                {
                    label1.Text = "Koneksi Ke Database Terhubung, Melakukan Koneksi Ke Datatable, Mohon Tunggu.....";
                    //label2.Text = this.progressBar1.Value.ToString();

                    if (this.progressBar1.Value > 50)
                    {
                        label1.Text = "Koneksi Semua Data Terhubung, Melakukan Proses Sinkronisasi data, Mohon Tunggu.....";
                        //label2.Text = this.progressBar1.Value.ToString();

                        if (this.progressBar1.Value == 100)
                        {
                            frmMaster tunjukformmaster = new frmMaster();
                            tunjukformmaster.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            LoadTheProgressBar();
        }
    }
}