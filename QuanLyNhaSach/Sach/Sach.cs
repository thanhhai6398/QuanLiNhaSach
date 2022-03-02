using QuanLyNhaSach.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    class Sach
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
        //Tim kiem DauSach
        public DataTable search(string txt)
        {
            SqlCommand command = new SqlCommand("select * from fu_TimKiemSach(@text,null,null,null)", db.GetConnection);
            command.Parameters.Add("@text", SqlDbType.NVarChar).Value = txt;
            DataTable result = getTable(command);
            return result;

        }
        //Tac gia
        public DataTable searchTG(string txt)
        {
            SqlCommand cmd = new SqlCommand("select * from TacGia where TenTacGia like N'%" + txt + "%'", db.GetConnection);
            DataTable table = getTable(cmd);
            return table;
        }
        //NXB
        public DataTable searchNXB(string txt)
        {
            SqlCommand cmd = new SqlCommand("select * from NhaXuatBan where TenNXB like N'%" + txt + "%'", db.GetConnection);
            DataTable table = getTable(cmd);
            return table;
        }
        //NCC
        public DataTable searchNCC(string txt)
        {
            SqlCommand cmd = new SqlCommand("select * from NhaCungCap where TenNCC like N'%" + txt + "%'", db.GetConnection);
            DataTable table = getTable(cmd);
            return table;
        }
        // CRUD Sach
        public  string getIdNewBook()
        {
            string id;
            SqlCommand command = new SqlCommand("SELECT [dbo].[func_NewIdSach] ()", db.GetConnection);
            DataTable table = this.getTable(command);
            id = table.Rows[0][0].ToString();
            return id;

        }
        public bool updateAnhBia(string ma, System.IO.MemoryStream anh)
        {
            SqlCommand command = new SqlCommand("update DauSach set AnhBia=@anh where MaSach = @ma", db.GetConnection);
            command.Parameters.Add("@anh", SqlDbType.Image).Value = anh.ToArray();
            command.Parameters.Add("@ma", SqlDbType.Char).Value = ma;
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
        public DataTable getViewBook()
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("select * from ChiTietDauSach");
            table = getTable(command);
            return table;
        }
        public DataTable getBookByid(String id)
        {
            SqlCommand command = new SqlCommand("select * from ChiTietDauSach Where MaSach = @id");
            command.Parameters.Add("@id", SqlDbType.Char).Value=id;
            DataTable table = getTable(command);
            return table;
        }
        public bool insertViewSach(string tua,int namXB,string tg,string ngonngu,string ncc,string nxb,string tl,
            int gia,string mota)
        {
            SqlCommand command = new SqlCommand("insert into ChiTietDauSach(TuaSach,NamXB,TenTacGia,TenNgonNgu,TenNCC,TenNXB,TenTL,GiaBan,MoTa)" +
                "Values(@tua,@nam,@tg,@ngngu,@ncc,@nxb,@tl,@gia,@mota)", db.GetConnection);
            command.Parameters.Add("@tua", SqlDbType.NVarChar).Value = tua;
            command.Parameters.Add("@nam", SqlDbType.Int).Value = namXB;
            command.Parameters.Add("@tg", SqlDbType.NVarChar).Value = tg;
            command.Parameters.Add("@ngngu", SqlDbType.NVarChar).Value = ngonngu;
            command.Parameters.Add("@ncc", SqlDbType.NVarChar).Value = ncc;
            command.Parameters.Add("@nxb", SqlDbType.NVarChar).Value = nxb;
            command.Parameters.Add("@tl", SqlDbType.NVarChar).Value = tl;
            command.Parameters.Add("@gia", SqlDbType.NVarChar).Value = gia;
            command.Parameters.Add("@mota", SqlDbType.Text).Value = mota;
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
        public bool updateDauSach(string ma,string tua,int namXB,int gia,string mota, System.IO.MemoryStream anh)
        {
            SqlCommand command = new SqlCommand("sp_UpdateDauSach", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = ma;
            command.Parameters.AddWithValue("@TuaSach", SqlDbType.NVarChar).Value = tua;
            command.Parameters.AddWithValue("@AnhBia", SqlDbType.Image).Value = anh.ToArray();
            command.Parameters.AddWithValue("@NamXB", SqlDbType.Int).Value = namXB;
            command.Parameters.AddWithValue("@Gia", SqlDbType.Int).Value = gia;
            command.Parameters.AddWithValue("@Mota", SqlDbType.Text).Value = mota;
            db.openConnection();
            if (command.ExecuteNonQuery()==1)
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
        public bool deleteViewSach(string ma)
        {
            SqlCommand command = new SqlCommand("sp_deleteSach", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ma", SqlDbType.Char).Value = ma;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            return true;
        }
        //Nha Xuat Ban
        public DataTable getViewNXB()
        {
            SqlCommand command = new SqlCommand("select * from NhaXuatBan", db.GetConnection);
            DataTable table = this.getTable(command);
            return table;
        }
        public bool insertNXB(string name,string address,string phone)
        {
            SqlCommand command = new SqlCommand("pro_InsertNXB", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = "";
            command.Parameters.AddWithValue("Ten", SqlDbType.NVarChar).Value = name;
            command.Parameters.AddWithValue("@Diachi", SqlDbType.NVarChar).Value = address;
            command.Parameters.AddWithValue("@Sdt", SqlDbType.Char).Value = phone;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public DataTable getNXBById(string id)
        {
            SqlCommand command = new SqlCommand("select * from NhaXuatBan where MaNXB=@id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Char).Value = id;
            DataTable table = this.getTable(command);
            return table;
        }
        public bool updateNXB(string id,string name,string address,string phone)
        {
            SqlCommand command = new SqlCommand("sp_UpdateNXB", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = id;
            command.Parameters.AddWithValue("@Ten", SqlDbType.NVarChar).Value = name;
            command.Parameters.AddWithValue("@Diachi", SqlDbType.NVarChar).Value = address;
            command.Parameters.AddWithValue("@Sdt", SqlDbType.Char).Value = phone;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public bool deleteNXB(string id)
        {
            SqlCommand command = new SqlCommand("sp_DeleteNXB", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaNXB", SqlDbType.Char).Value = id;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        //Tac Gia
        public DataTable getViewTacGia()
        {
            SqlCommand command = new SqlCommand("select * from TacGia", db.GetConnection);
            DataTable table = this.getTable(command);
            return table;
        }
        public bool insertTacGia(string name)
        {
            SqlCommand command = new SqlCommand("sp_InsertTacGia", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = "";
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value =name;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public bool updateTacGia(string id,string name)
        {
            SqlCommand command = new SqlCommand("sp_UpdateTacGia", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = id;
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public bool deleteTacGia(string id)
        {

            SqlCommand command = new SqlCommand("sp_DeleteTacGia", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaTG", SqlDbType.Char).Value = id;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public DataTable getAuthorById(string id)
        {
            SqlCommand command = new SqlCommand("select * from TacGia where MaTG=@ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            DataTable table = this.getTable(command);
            return table;
        }
        public DataTable getListBookByAuthor( string name)
        {
            SqlCommand command = new SqlCommand("select * from dbo.func_getListBookByAuthor(@name)", db.GetConnection);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            DataTable table = this.getTable(command);
            return table;
        }
        //Ngon Ngu
        public DataTable getViewNgonNgu()
        {
            SqlCommand command = new SqlCommand("select * from NgonNgu", db.GetConnection);
            DataTable table = this.getTable(command);
            return table;
        }
        public DataTable getNgonNguById(string id)
        {
            SqlCommand command = new SqlCommand("select * from NgonNgu where MaNN=@ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            DataTable table = this.getTable(command);
            return table;
        }
        public bool insertNgonNgu(string name)
        {
            SqlCommand command = new SqlCommand("sp_InsertNgonNgu",db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = " ";
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public bool updateNgonNgu(string id,string name)
        {
            SqlCommand command = new SqlCommand("sp_UpdateNgonNgu", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = id;
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;
        }
        public bool deleteNgonNgu(string id)
        {
            SqlCommand command = new SqlCommand("sp_DeleteNgonNgu", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaNN", SqlDbType.Char).Value = id;
            db.openConnection();
            command.ExecuteNonQuery();
            return true;

        }

        //The Loai
        public DataTable getViewTheLoai()
        {
            SqlCommand command = new SqlCommand("select * from TheLoai", db.GetConnection);
            DataTable table = this.getTable(command);
            return table;
        }
        public DataTable getTheLoaiById(string id)
        {
            SqlCommand command = new SqlCommand("select * from TheLoai where MaTL=@ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            DataTable table = this.getTable(command);
            return table;
        }
        public void insertTheLoai(string name)
        {
            SqlCommand command = new SqlCommand("sp_InsertTheLoai", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = " ";
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        public void updateTheLoai(string id,string name)
        {
            SqlCommand command = new SqlCommand("sp_UpdateTheLoai", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = id;
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        public void deleteTheLoai(string id)
        {
            SqlCommand command = new SqlCommand("sp_DeleteTheLoai", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaTL", SqlDbType.Char).Value = id;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        //Nha Cung Cap
        public DataTable getViewNCC()
        {
            SqlCommand command = new SqlCommand("select * from NhaCungCap", db.GetConnection);
            DataTable table = this.getTable(command);
            return table;
        }
        public DataTable getNCCById(string id)
        {
            SqlCommand command = new SqlCommand("select * from NhaCungCap where MaNCC=@ma", db.GetConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            DataTable table = this.getTable(command);
            return table;
        }
        public void insertNCC(string name)
        {
            SqlCommand command = new SqlCommand("sp_InsertNCC", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = " ";
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        public void updateNCC(string id,string name)
        {
            SqlCommand command = new SqlCommand("sp_UpdateNCC", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ma", SqlDbType.Char).Value = id;
            command.Parameters.AddWithValue("@Ten", SqlDbType.Char).Value = name;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        public void deleteNCC(string id)
        {
            SqlCommand command = new SqlCommand("sp_DeleteNCC", db.GetConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaNCC", SqlDbType.Char).Value = id;
            db.openConnection();
            command.ExecuteNonQuery();
        }
    }
}
