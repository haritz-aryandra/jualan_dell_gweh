using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BA_APPS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            textBox1.Focus();
            textBox2.Enabled = false;
        }

        public OracleConnection KoneksiDatabase = new OracleConnection();

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terimakasih Telah Menggunakan Aplikasi Kami", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }

        protected void fungsijalankanvalidasiuser()
        {
            try
            {
                // ini fungsi validasi textbox salah satu atau semua kosong
                if (textBox1.Text == "")
                {
                    MessageBox.Show("kolom username belum terisi", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    textBox2.Clear();
                }
                else
                {
                    if (textBox1.Text == "admin")
                    {
                        textBox1.ReadOnly = true;
                        textBox2.Enabled = true;
                        textBox2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Username yang anda masukkan salah, Ulangi lagi", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Clear();
                        textBox2.Enabled = false;
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Terjadi Error pada saat menjalankan fungsijalankanvalidasiuserpass");
                MessageBox.Show(ex.Message + ex.Source + ex.StackTrace + ex.TargetSite);
            }
        }

        protected void fungsijalankanvalidasipassword()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("kolom password belum terisi", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
            else
            {

                if (textBox2.Text != "admin")
                {
                    MessageBox.Show("password yang anda masukkan salah, Ulangi lagi", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox2.Focus();
                    //textBox2.Enabled = false;
                    //textBox1.Enabled = true;
                    //textBox1.Clear();
                    //textBox1.Focus();
                }
                else
                {
                    frmSplash panggilformsplash = new frmSplash();
                    panggilformsplash.Show();
                    this.Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fungsijalankanvalidasiuser();
            fungsijalankanvalidasipassword();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                fungsijalankanvalidasiuser();
                //fungsijalankanvalidasipassword();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                fungsijalankanvalidasipassword();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Maaf button ini belum berfungsi, karena masih demo", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Application.ExitThread();
            frmLoginManagement flm = new frmLoginManagement();
            flm.Show();
            Hide();
        }
    }
}