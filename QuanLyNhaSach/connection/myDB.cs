using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.connection
{
    class myDB
    {
        SqlConnection con;

        public myDB(String UID, String password, String svName, String dbName)
        {
            con = new SqlConnection("UID=" + UID + "; password=" + password + "; server=" + svName + "; database=" + dbName);
        }

        public SqlConnection GetConnection
        {
            get
            {
                return con;
            }
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
