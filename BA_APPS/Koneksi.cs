#region "Ini adalah deklarasi import referensinya"
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
#endregion

namespace BA_APPS
{
    public class Koneksi
    {
        private OracleConnection conn;

        private string OracleServer = "Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ORCL)));"
             + "User Id=system;Password=Haritzis1212;";

        public bool Open()
        {
            try
            {
                conn = new OracleConnection(OracleServer);
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public OracleDataReader ExecuteReader(string sql)
        {
            try
            {
                OracleDataReader reader;
                OracleCommand cmd = new OracleCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                OracleTransaction mytransaction = conn.BeginTransaction();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }
}