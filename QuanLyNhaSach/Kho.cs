using QuanLyNhaSach.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach
{
    class Kho
    {
        myDB db = new myDB(Global.username, Global.password, Global.svName, Global.dbName);
        public DataTable getTable(SqlCommand command)
        {
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateKho(string maSach, int sl)
        {
            SqlCommand command = new SqlCommand("EXECUTE sp_UpdateKho @ms,@sl", db.GetConnection);
            command.Parameters.Add("@ms", SqlDbType.Char).Value = maSach;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = sl;

            db.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool deleteKho(string maSach)
        {
            SqlCommand command = new SqlCommand("Exec sp_DeleteKho @ms", db.GetConnection);
            command.Parameters.Add("@ms", SqlDbType.Char).Value = maSach;

            db.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
