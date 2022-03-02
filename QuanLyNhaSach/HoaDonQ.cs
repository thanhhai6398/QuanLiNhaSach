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
    class HoaDonQ
    {
        // myDB db = new myDB("sa", "hiimkq0901", "DESKTOP-8M2NJ75\\SQLEXPRESS01", "QLNS");
        myDB db = new myDB(Global.username, Global.password, Global.svName, Global.dbName);

        public DataTable getTable(SqlCommand command)
        {
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getAllBook()
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select MaSach, TuaSach from DauSach");
            table = getTable(command);
            return table;
        }

        public string getGiaSachByID(string id)
        {
            SqlCommand command = new SqlCommand("SELECT GiaBan FROM DauSach WHERE MaSach = @ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            db.openConnection();
            string gia = command.ExecuteScalar().ToString();
            return gia;
        }

        public bool insertHoaDon(string mahd, string masach, int sl, string giamgia, string tonghd)
        {
            SqlCommand command = new SqlCommand("exec dbo.sp_ThemHoaDon @manv,@ngaymua,@masach,@sl,@giamgia,@tonghd", db.GetConnection);
            if (giamgia == "")
            {
                giamgia = "0";
            }
            command.Parameters.Add("@manv", SqlDbType.Char).Value = mahd;
            command.Parameters.Add("@ngaymua", SqlDbType.DateTime).Value = DateTime.Now;
            command.Parameters.Add("@masach", SqlDbType.Char).Value = masach;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = sl;
            command.Parameters.Add("@giamgia", SqlDbType.NVarChar).Value = giamgia;
            command.Parameters.Add("@tonghd", SqlDbType.NVarChar).Value = tonghd;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
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

        public bool checkMAHD(String mahd)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select Count(*) from HoaDon WHERE MaHD = @mahd", db.GetConnection);
            command.Parameters.Add("@mahd", SqlDbType.Char).Value = mahd;
            db.openConnection();
            int count = (Int32)command.ExecuteScalar();
            db.closeConnection();
            if (count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
