using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BA_APPS
{
    public partial class frmLoginManagement : Form
    {
        public frmLoginManagement()
        {
            InitializeComponent();
        }

        private OracleConnection KoneksiDatabase = new OracleConnection();

        private void MulaiKoneksiKeDatabase()
        {
            try
            {
                KoneksiDatabase.ConnectionString = "User Id=" + textBox1.Text +
                ";Password=" + textBox2.Text +
                ";Data Source=" + textBox3.Text + ";";
            }
            catch (Exception alertforerrormulaikoneksikedatabase)
            {
                MessageBox.Show("The Connection Cannot Be Established, Because Username OR Password Are Incorect Nor The Database Services Are Stop", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /**koding sampe disini, kejar hari ini user management selesai, dan coba kejar semua module dengan data kelar, 
                dan coba mulai simulasi perhitungan */
            }
        }

        // ini adalah event handler untuk keluar aplikasi
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terimakasih Telah Menggunakan Aplikasi Kami", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }

        // ini adalah event handler keluar form dan kembali ke form login
        private void button3_Click(object sender, EventArgs e)
        {
            frmLogin flluar = new frmLogin();
            flluar.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //KoneksiDatabase.ConnectionString = "User Id=" + textBox1.Text +
            //    ";Password=" + textBox2.Text +
            //    ";Data Source=" + textBox3.Text + ";";

            #region "Call The Function For Start Connection To Database"
            MulaiKoneksiKeDatabase();
            #endregion

            try
            {
                #region "Code To Open Connection"
                KoneksiDatabase.Open();
                #endregion

                //textBox1.Enabled = false;
                //textBox2.Enabled = false;
                //textBox3.Enabled = false;
                //textBox4.Enabled = true;
                //textBox5.Enabled = true;
                //textBox4.Enabled = false;
                //button1.Enabled = false;
                //button4.Enabled = true;
                //button5.Enabled = true;
            }
            catch (Exception alerterrorkoneksi)
            {
                MessageBox.Show(alerterrorkoneksi.Message + alerterrorkoneksi.Source + alerterrorkoneksi.StackTrace + alerterrorkoneksi.TargetSite);
            }
            finally
            {
                MessageBox.Show("Connection To Database Are Succeed, Please Continue By Filled The Schema And Table Name", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //KoneksiDatabase.Close();

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                button1.Enabled = false;
                button4.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region "code to close and disposed connection to database"
            KoneksiDatabase.Close();
            KoneksiDatabase.Dispose();
            #endregion

            button1.Enabled = true;
            button5.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region "This Is Error Code Part 1"
            //try
            //{
            //    /*OracleCommand cmd = new OracleCommand("SELECT * FROM haritz.tbluserlogin", KoneksiDatabase);
            //    OracleCommand cmd = new OracleCommand("SELECT * FROM tbluserlogin", KoneksiDatabase);
            //    OracleCommand cmd = new OracleCommand("SELECT * FROM '" + textBox4.Text + "'.'" + textBox5.Text + "', KoneksiDatabase");*/
            //    //OracleCommand cmd = new OracleCommand("SELECT * FROM " + textBox4.Text + ", KoneksiDatabase");
            //    //OracleCommand cmd = new OracleCommand();
            //    //cmd.Connection = KoneksiDatabase;
            //    //cmd.CommandText = "SELECT * FROM " + textBox4.Text + "";
            //    //cmd.CommandType = CommandType.Text;

            //    //OracleDataReader dro = cmd.ExecuteReader();
            //    //dro.Read();
            //    //OracleCommand cmd = new OracleCommand("SELECT * FROM " + textBox4.Text + "." + textBox5.Text + ", KoneksiDatabase");
                
            //    /*error sampe disini, stugnya adalah saat coba kueri tarik datatable ga bisa kalau kita ambil salah satu trigger 
            //    nama skema dan table dari textbox*/
                
            //    //OracleDataAdapter oda = new OracleDataAdapter(cmd);
            //    //DataSet ds = new DataSet();
            //    //oda.Fill(ds);
            //    //if (ds.Tables.Count > 0)
            //    //{
            //    //    dataGridView1.DataSource = ds.Tables[0].DefaultView;
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("Maaf datatable tidak ditemukan, silahkan cek lagi teknisnya", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Terjadi Error Saat Coba Koneksi Table, atau user ataupun nama tablenya tidak ada atau salah", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    MessageBox.Show(ex.Message + ex.Source + ex.StackTrace + ex.TargetSite);
            //}
            #endregion

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = KoneksiDatabase;
            cmd.CommandText = "SELECT * FROM " + textBox4.Text + "" + textBox5.Text;
            cmd.CommandType = CommandType.Text;

            OracleDataReader dro = cmd.ExecuteReader();

            #region "This Is The Error Code Part 2"
            //DataTable dto = new DataTable();
            //dto.Load(dro);
            //dro.Read();
            #endregion

            try
            {
                //KoneksiDatabase.Open();
                if (dro.Read())
                {
                    DataTable dto = new DataTable();
                    dto.Load(dro);
                    //dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dto;
                }
                else
                {
                    MessageBox.Show("Maaf datatable tidak ditemukan, silahkan cek lagi teknisnya", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show(ex.Message + ex.Source + ex.StackTrace + ex.TargetSite);
                }
            }
            catch (Exception alererrorkoneksi)
            {
                MessageBox.Show("Terjadi Error Saat Coba Koneksi Table, atau user ataupun nama tablenya tidak ada atau salah", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(alererrorkoneksi.Message + alererrorkoneksi.Source + alererrorkoneksi.StackTrace + alererrorkoneksi.TargetSite);
            }
            finally
            {
                KoneksiDatabase.Close();
            }

        }

        private void frmLoginManagement_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button5.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("Anda belum melakukan pengisian pada kolom username untuk data koneksi, silahkan isi dahulu", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {
                    textBox1.Enabled = false;
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (textBox2.Text == "" || textBox2.Text == null)
                {
                    MessageBox.Show("Anda belum melakukan pengisian pada kolom password untuk data koneksi, silahkan isi dahulu", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
                else
                {
                    textBox2.Enabled = false;
                    textBox3.Focus();
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (textBox3.Text == "" || textBox3.Text == null)
                {
                    MessageBox.Show("Anda belum melakukan pengisian pada kolom password untuk data koneksi, silahkan isi dahulu", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
                else
                {
                    textBox3.Enabled = false;
                    textBox4.Enabled = true;
                    textBox4.Focus();
                }
            }
        }
    }
}