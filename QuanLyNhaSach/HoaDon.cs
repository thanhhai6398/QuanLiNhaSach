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
    class HoaDon
    {
        // myDB db = new myDB("sa", "12", "DESKTOP-DVLN21C\\SQLEXPRESS", "QLNS");
        myDB db = new myDB(Global.username, Global.password, Global.svName, Global.dbName);
        public DataTable getTable(SqlCommand command)
        {
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateHoaDon(string maHD, DateTime ngayMua, string giam, string tongHD)
        {
            SqlCommand command = new SqlCommand("UPDATE HoaDon SET NgayMua=@ngay, GiamGia=@giam, TongHoaDon=@tong WHERE MaHD=@mhd", db.GetConnection);
            command.Parameters.Add("@mhd", SqlDbType.Char).Value = maHD;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngayMua;
            command.Parameters.Add("@giam", SqlDbType.NVarChar).Value = giam;
            command.Parameters.Add("@tong", SqlDbType.NVarChar).Value = tongHD;

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
        public bool deleteHoaDon(string maHD)
        {
            SqlCommand command = new SqlCommand("Exec sp_XoaHoaDon @mhd", db.GetConnection);
            command.Parameters.Add("@mhd", SqlDbType.Char).Value = maHD;

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
