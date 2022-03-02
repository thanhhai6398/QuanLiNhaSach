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
    class search
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

        public DataTable getAllBooks()
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select * from dbo.fu_getViewSach ()");
            table = getTable(command);
            return table;
        }

        public DataTable searchBooks(string s, string type)
        {
            DataTable table = new DataTable();
            SqlCommand command;
            if (type == "Ten")
            {
                command = new SqlCommand("SELECT * FROM dbo.fu_TimKiemSach (@ten, NULL, NULL, NULL)", db.GetConnection);
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = s;
            }
            else if (type == "Ngon Ngu")
            {
                command = new SqlCommand("SELECT * FROM dbo.fu_TimKiemSach (NULL, @ngonngu, NULL, NULL)", db.GetConnection);
                command.Parameters.Add("@ngonngu", SqlDbType.NVarChar).Value = s;
            }
            else if (type == "The Loai")
            {
                command = new SqlCommand("SELECT * FROM dbo.fu_TimKiemSach (NULL, NULL, @theloai, NULL)", db.GetConnection);
                command.Parameters.Add("@theloai", SqlDbType.NVarChar).Value = s;
            }
            else
            {
                command = new SqlCommand("SELECT * FROM dbo.fu_TimKiemSach (NULL, NULL, NULL, @tacgia)", db.GetConnection);
                command.Parameters.Add("@tacgia", SqlDbType.NVarChar).Value = s;
            }
            table = getTable(command);
            return table;
        }
    }
}
