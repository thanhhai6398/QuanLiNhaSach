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
    class PhieuNhap
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

        public bool deletePhieuNhap(string maPN)
        {
            SqlCommand command = new SqlCommand("Exec sp_DeletePhieuNhap @mpn", db.GetConnection);
            command.Parameters.Add("@mpn", SqlDbType.Char).Value = maPN;

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
        public bool updatePhieuNhap(string maPN, DateTime ngayNhap)
        {
            SqlCommand command = new SqlCommand("UPDATE PhieuNhap SET NgayNhap=@ngay WHERE MaPN=@mpn", db.GetConnection);
            command.Parameters.Add("@mpn", SqlDbType.Char).Value = maPN;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngayNhap;

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
        public bool insertPhieuNhap(string maPN, DateTime ngayNhap, string maS, int sl, string gia)
        {
            SqlCommand command = new SqlCommand("Exec sp_InsertPhieuNhap @Ma,@Ngay,@MaS,@sl,@gia", db.GetConnection);
            command.Parameters.Add("@Ma", SqlDbType.Char).Value = maPN;
            command.Parameters.Add("@Ngay", SqlDbType.DateTime).Value = ngayNhap;
            command.Parameters.Add("@MaS", SqlDbType.NVarChar).Value = maS;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = sl;
            command.Parameters.Add("@gia", SqlDbType.NVarChar).Value = gia;

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
