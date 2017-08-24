using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace BA_APPS
{
    public partial class frmMaster : Form
    {
        public frmMaster()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Terimakasih Telah Menggunakan Aplikasi Kami", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    Application.ExitThread();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Terimakasih Telah Menggunakan Aplikasi Kami", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }

        private void frmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Terimakasih Telah Menggunakan Aplikasi Kami", "Incore Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Administrator";
            toolStripStatusLabel8.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel10.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("Please Select");
            comboBox1.Text = "Please Select";
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            //comboBox2.Items.Add("Please Select");
            //comboBox3.Items.Add("Please Select");
            //comboBox4.Items.Add("Please Select");
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("KKS Yang Kesatu");
            comboBox1.Items.Add("KKS Yang Kedua");
            comboBox1.Items.Add("KKS Yang Ketiga");
            comboBox1.Items.Add("KKS Yang Keempat");
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("CTP Yang Kesatu");
            comboBox2.Items.Add("CTP Yang Kedua");
            comboBox2.Items.Add("CTP Yang Ketiga");
            comboBox2.Items.Add("CTP Yang Keempat");
        }

        //private void LoadingDataToGridFromExcel()
        //{
        //    try
        //    {
        //        //System.Data.OleDb.OleDbConnection MyConnection;
        //        //System.Data.DataSet DtSet;
        //        //System.Data.OleDb.OleDbDataAdapter MyCommand;
        //        ////MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Data Project\project vendor migas\project Aplikasi Back Allocation(BA - Gw - or Haritz)\BA_APPS\BA_APPS\BA_APPS\datatemp.xls';Extended Properties=Excel 8.0;");
        //        //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Data Project\project vendor migas\project Aplikasi Back Allocation(BA - Gw - or Haritz)\BA_APPS\BA_APPS\BA_APPS\datatemp.xls';Extended Properties=""Excel 12.0 Xml;HDR=YES");
        //        ////MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        //        //MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        //        //MyCommand.TableMappings.Add("Table", "Net-informations.com");
        //        //DtSet = new System.Data.DataSet();
        //        //MyCommand.Fill(DtSet);
        //        //dataGridView1.DataSource = DtSet.Tables[0];
        //        //MyConnection.Close();

        //        string path = @"D:\Data Project\project vendor migas\project Aplikasi Back Allocation(BA - Gw - or Haritz)\BA_APPS\BA_APPS\BA_APPS\datatemp.xlsx";

        //        //Excel.Application MyXLApp = default(Excel.Application);
        //        //Excel.Workbook MyXLWorkBook = default(Excel.Workbook);
        //        //Excel.Worksheet MyXLSheets = default(Excel.Worksheet);
        //        //MyXLApp = new Excel.Application();

        //        //MyXLWorkBook = MyXLApp.Workbooks.Open(path);
        //        //for (int i = 1; i <= MyXLWorkBook.Sheets.Count; i++)
        //        //{
        //        //    MyXLSheets = MyXLWorkBook.Sheets[i];
        //        //    MyXLSheets.Select();
        //        //    //ComboBox1.Items.Add(MyXLSheets.Name);
        //        //    string pathkedua = MyXLSheets.Name;

        //        //    OleDbConnection koneksi = new OleDbConnection();
        //        //    koneksi.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathkedua + "; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
        //        //    OleDbCommand perintah = new OleDbCommand("select * from [Sheet1$]", koneksi);
        //        //    DataSet dsimportsiswa = new DataSet();
        //        //    OleDbDataAdapter adapternya = new OleDbDataAdapter(perintah);
        //        //    adapternya.Fill(dsimportsiswa);
        //        //    dataGridView1.DataSource = dsimportsiswa.Tables[0];

        //        //}

        //        // You can change C:\Members.xlsx to any path where 
        //        // the file is located.
        //        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";

        //        // if you don't want to show the header row (first row)
        //        // use 'HDR=NO' in the string

        //        string strSQL = "SELECT * FROM [Sheet1$]";

        //        OleDbConnection excelConnection = new OleDbConnection(connectionString);
        //        excelConnection.Open(); // This code will open excel file.

        //        OleDbCommand dbCommand = new OleDbCommand(strSQL, excelConnection);
        //        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

        //        // create data table
        //        DataTable dTable = new DataTable();
        //        dataAdapter.Fill(dTable);

        //        // bind the datasource
        //        dataBingingSrc.DataSource = dTable;

        //        // assign the dataBindingSrc to the DataGridView
        //        dataGridView1.DataSource = dataBingingSrc;

        //        // dispose used objects
        //        dTable.Dispose();
        //        dataAdapter.Dispose();
        //        dbCommand.Dispose();

        //        excelConnection.Close();
        //        excelConnection.Dispose();

        //        //OleDbConnection koneksi = new OleDbConnection();
        //        ////string path = @"D:\Data Project\project vendor migas\project Aplikasi Back Allocation(BA - Gw - or Haritz)\BA_APPS\BA_APPS\BA_APPS\datatemp.xls";
        //        ////koneksi.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRow=0"
        //        ////koneksi.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
        //        //koneksi.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathkedua + "; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
        //        //OleDbCommand perintah = new OleDbCommand("select * from [Sheet1$]", koneksi);
        //        //DataSet dsimportsiswa = new DataSet();
        //        //OleDbDataAdapter adapternya = new OleDbDataAdapter(perintah);
        //        //adapternya.Fill(dsimportsiswa);
        //        //dataGridView1.DataSource = dsimportsiswa.Tables[0];

        //    }
        //    catch
        //    {

        //    }
        //}

        protected void loadingdatagridsementara()
        {
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "ID CTP";
            dataGridView1.Columns[1].Name = "Kalibrasi Terakhir";
            dataGridView1.Columns[2].Name = "Jenis Minyak";
            dataGridView1.Columns[3].Name = "ID KPS";
            dataGridView1.Columns[4].Name = "Volume Lifting";
            dataGridView1.Columns[5].Name = "Kapal";
            dataGridView1.Columns[6].Name = "Tujuan";

            string[] row = new string[] {
	"1",
	"ORF Porong",
	"29/05/2015",
    "Minyak Tabuan",
    "Bangka Marine Terminal",
    "250.172",
    "FSL SHANGHAI",
    "Petro-Diamond Singapore (PTE) LTD"
};
            dataGridView1.Rows.Add(row);
            row = new string[] {
	"2",
    "ORF Porong",
	"1-31 May 15",
	"Gas",
    "RU III Plaju",
    "89.579,65",
    "Pipeline",
    "Domestik",
    ""
};
//            dataGridView1.Rows.Add(row);
//            row = new string[] {
//    "3",
//    "",
//    ""
//};
//            dataGridView1.Rows.Add(row);
//            row = new string[] {
//    "4",
//    "",
//    ""
//};
//            dataGridView1.Rows.Add(row);
//            row = new string[] {
//    "5",
//    "",
//    ""
//};
//            dataGridView1.Rows.Add(row);
//            row = new string[] {
//    "6",
//    "",
//    ""
//};
//            dataGridView1.Rows.Add(row);
//            row = new string[] {
//    "7",
//    "",
//    ""
//};
            dataGridView1.Rows.Add(row);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                comboBox2.Enabled = true;
                comboBox2.Text = "Please Select";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //LoadingDataToGridFromExcel();
            loadingdatagridsementara();
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
    }
}