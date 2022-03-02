using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ChiTietSach : Form
    {
        Sach dao = new Sach();
        string book_id;
        public ChiTietSach(string id)
        {
            InitializeComponent();
            book_id = id;
        }

        private void ChiTietSach_Load(object sender, EventArgs e)
        {
            DataTable table = dao.getBookByid(book_id);
            if (table.Rows.Count > 0)
            {
                this.id.Text = table.Rows[0][0].ToString();
                this.tuatxt.Text = table.Rows[0][1].ToString();
                try
                {
                    byte[] pic;
                    pic = (byte[])table.Rows[0]["AnhBia"];
                    MemoryStream picture = new MemoryStream(pic);
                    this.anhbia.Image = Image.FromStream(picture);
                    this.anhbia.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {

                }
                this.namxbtxt.Text = table.Rows[0][3].ToString();
                this.tgtxt.Text = table.Rows[0][4].ToString();
                this.ngngutxt.Text = table.Rows[0][5].ToString();
                this.ncctxt.Text = table.Rows[0][9].ToString();
                this.nxbtxt.Text = table.Rows[0][8].ToString();
                this.tltxt.Text = table.Rows[0][6].ToString();
                this.giatxt.Text = table.Rows[0][7].ToString();
                this.motatxt.Text = table.Rows[0][11].ToString();
            }
        }
        
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    string tuaSach = this.tuatxt.Text;
                    int namXB = int.Parse(this.namxbtxt.Text);
                    string tacgia = this.tgtxt.Text;
                    string ngongu = this.ngngutxt.Text;
                    string ncc = this.ncctxt.Text;
                    string nxb = this.nxbtxt.Text;
                    string theloai = this.tltxt.Text;
                    int gia = int.Parse(this.giatxt.Text);
                    string mota = this.motatxt.Text;
                    MemoryStream picture = new MemoryStream();
                    if (dao.insertViewSach(tuaSach, namXB, tacgia, ngongu, ncc, nxb, theloai, gia, mota))
                    {
                        string ma = dao.getIdNewBook();
                        anhbia.Image.Save(picture, anhbia.Image.RawFormat);
                        if (dao.updateAnhBia(ma, picture))
                        {
                            MessageBox.Show("Thêm sách thành công", "Thêm sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset();
                        }

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            string maSach = this.id.Text;
            string tuaSach = this.tuatxt.Text;
            int namXB = int.Parse(this.namxbtxt.Text);
            int gia = int.Parse(this.giatxt.Text);
            string mota = this.motatxt.Text;
            MemoryStream picture = new MemoryStream();
            try
            {
                 anhbia.Image.Save(picture, anhbia.Image.RawFormat);
                if (dao.updateDauSach(maSach, tuaSach, namXB, gia, mota, picture))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                else
                {
                    MessageBox.Show("Lỗi!Kiểm tra lại", "Thông tin sách", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.anhbia.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            string maSach = this.id.Text;
            try
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa đầu sách này?","Thông tin sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(dao.deleteViewSach(maSach).ToString());
                    if (dao.deleteViewSach(maSach) == true)
                    {
                        MessageBox.Show("Xóa thành công", "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        private bool verif()
        {
            if(this.tuatxt.Text.Trim()=="" || this.nxbtxt.Text.Trim()==""||this.ncctxt.Text.Trim()=="" || this.ngngutxt.Text.Trim()==""
                || this.tgtxt.Text.Trim()=="" || this.namxbtxt.Text.Trim()=="" || this.giatxt.Text.Trim()=="" || this.motatxt.Text.Trim()=="")
            {
                MessageBox.Show("Trường rỗng", "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                int namXB, giaBan;
                if (int.TryParse(this.namxbtxt.Text, out namXB) && int.TryParse(this.giatxt.Text,out giaBan))
                {
                    if (namXB > DateTime.Now.Year)
                    {
                        MessageBox.Show("Sai năm xuất bản", "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (giaBan < 0)
                    {
                        MessageBox.Show("Giá bán < 0", "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra kiểu dữ liệu", "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
           
            return true;
        }
        private void reset()
        {
            this.tuatxt.Text = null;
            this.namxbtxt.Text = null;
            this.tgtxt.Text = null;
            this.ngngutxt.Text = null;
            this.ncctxt.Text = null;
            this.nxbtxt.Text = null;
            this.tltxt.Text = null;
            this.giatxt.Text = null;
            this.motatxt.Text = null;
            this.anhbia.Image = Properties.Resources.none_image;
        }
    }
}
