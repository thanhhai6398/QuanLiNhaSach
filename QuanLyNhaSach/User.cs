using QuanLyNhaSach.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach
{
    class User
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

        public DataTable getUserByID(string manv)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select * from NguoiDung WHERE MaNV = @manv");
            command.Parameters.Add("@manv", SqlDbType.Char).Value = manv;
            table = getTable(command);
            return table;
        }

        public DataTable getAllUsers()
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select * from NguoiDung", db.GetConnection);
            table = getTable(command);
            return table;
        }

        public bool checkMANV(String manv)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select Count(*) from NguoiDung WHERE MaNV = @manv", db.GetConnection);
            command.Parameters.Add("@manv", SqlDbType.Char).Value = manv;
            db.openConnection();
            int count = (Int32) command.ExecuteScalar();
            db.closeConnection();
            if (count > 0)
            {
                return false;
            }
            return true;
        }

        public bool insertUser(string manv, string username, string password, string hoten, string email, string sdt, MemoryStream anh, string chucvu)
        {
            SqlCommand command = new SqlCommand("exec dbo.sp_themthongtinnhanvien @manv,@username,@pwd,@hoten,@email,@sdt,@hinh,@chucvu ", db.GetConnection);
            command.Parameters.Add("@manv", SqlDbType.Char).Value = manv;
            command.Parameters.Add("@hinh", SqlDbType.Image).Value = anh.ToArray();
            command.Parameters.Add("@username", SqlDbType.Char).Value = username;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
            command.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdt;
            command.Parameters.Add("@chucvu", SqlDbType.NVarChar).Value = chucvu;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                command = new SqlCommand("dbo.sp_TaoLogin @username, @pwd, @chucvu", db.GetConnection);
                command.Parameters.Add("@username", SqlDbType.Char).Value = username;
                command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@chucvu", SqlDbType.NVarChar).Value = chucvu;
                command.ExecuteNonQuery();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool editUser(string manv, string username, string password, string hoten, string email, string sdt, MemoryStream anh, string chucvu)
        {
            SqlCommand command = new SqlCommand("exec dbo.sp_suathongtinnhanvien @manv,@username,@pwd,@hoten,@email,@sdt,@hinh,@chucvu ", db.GetConnection);
            command.Parameters.Add("@manv", SqlDbType.Char).Value = manv;
            command.Parameters.Add("@hinh", SqlDbType.Image).Value = anh.ToArray();
            command.Parameters.Add("@username", SqlDbType.Char).Value = username;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
            command.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdt;
            command.Parameters.Add("@chucvu", SqlDbType.NVarChar).Value = chucvu;
            string oldrole = getRoleByMSNV(manv);
            
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                if (chucvu == oldrole)
                {
                    db.closeConnection();
                    return true;
                }
                command = new SqlCommand("dbo.sp_TaoUser @uname, @pwd, @cv", db.GetConnection);
                command.Parameters.Add("@uname", SqlDbType.Char).Value = username;
                command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@cv", SqlDbType.NVarChar).Value = chucvu;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteUser(string manv)
        {
            string username = getUsernameByMSNV(manv);
            SqlCommand command = new SqlCommand("exec dbo.sp_xoathongtinnhanvien @manv", db.GetConnection);
            command.Parameters.Add("@manv", SqlDbType.Char).Value = manv;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                command = new SqlCommand("EXEC dbo.sp_XoaLogin @uname", db.GetConnection);
                command.Parameters.Add("@uname", SqlDbType.Char).Value = username;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public string getUsernameByMSNV(string manv)
        {
            SqlCommand command = new SqlCommand("SELECT Username FROM NguoiDung WHERE MaNV = @ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = manv;
            db.openConnection();
            string idnv = (string)command.ExecuteScalar();
            db.closeConnection();
            return idnv;
        }

        public string getRoleByMSNV(string manv)
        {
            SqlCommand command = new SqlCommand("SELECT ChucVu FROM NguoiDung WHERE MaNV = @ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = manv;
            db.openConnection();
            string cv = (string)command.ExecuteScalar();
            db.closeConnection();
            return cv;
        }

        public string getMSNVByUsername(string uname)
        {
            SqlCommand command = new SqlCommand("SELECT MaNV FROM NguoiDung WHERE Username = @uname", db.GetConnection);
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            db.openConnection();
            string cv = (string)command.ExecuteScalar();
            db.closeConnection();
            return cv;
        }

        public DataTable Login(string username, string password)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("exec dbo.sp_DangNhap @user, @pwd");
            command.Parameters.Add("@user", SqlDbType.Char).Value = username;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
            table = getTable(command);
            return table;
        }

        public bool ChangePassword(string username, string password)
        {
            SqlCommand command = new SqlCommand("exec dbo.sp_DoiMatKhau @manv, @pwd", db.GetConnection);
            command.Parameters.Add("@manv", SqlDbType.Char).Value = getMSNVByUsername(username);
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                command = new SqlCommand("exec dbo.sp_DoiMatKhauLogin @user, @pwd, @opwd", db.GetConnection);
                command.Parameters.Add("@user", SqlDbType.Char).Value = username;
                command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@opwd", SqlDbType.NVarChar).Value = Global.password;
                db.openConnection();
                command.ExecuteNonQuery();
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
