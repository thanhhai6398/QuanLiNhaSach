using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class EditEmployeeForm : Form
    {
        User userDAO = new User();
        private string manv;
        public EditEmployeeForm(string id)
        {
            InitializeComponent();
            this.manv = id;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.picPictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private bool verify()
        {
            if (IDTextBox.Text.Trim() == "" || UsernameTextBox.Text.Trim() == "" || PasswordTextBox.Text.Trim() == "" || NameTextBox.Text.Trim() == ""
                || EmailTextBox.Text.Trim() == "" || PhoneTextBox.Text.Trim() == "" || RoleTextBox.Text.Trim() == "" || picPictureBox.Image == null)
            {
                MessageBox.Show("Trường rỗng", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!PhoneTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            DataTable table = userDAO.getUserByID(manv);
            if (table.Rows.Count > 0)
            {
                IDTextBox.Text = table.Rows[0]["MaNV"].ToString();
                UsernameTextBox.Text = table.Rows[0]["Username"].ToString();
                byte[] pic;
                pic = (byte[])table.Rows[0]["HinhAnh"];
                MemoryStream picture = new MemoryStream(pic);
                picPictureBox.Image = Image.FromStream(picture);
                picPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PasswordTextBox.Text = table.Rows[0]["Passwd"].ToString();
                NameTextBox.Text = table.Rows[0]["HoTen"].ToString();
                EmailTextBox.Text = table.Rows[0]["Email"].ToString();
                PhoneTextBox.Text = table.Rows[0]["SDT"].ToString();
                RoleTextBox.Text = table.Rows[0]["ChucVu"].ToString();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (verify())
                {
                    string manv = IDTextBox.Text;
                    string username = UsernameTextBox.Text;
                    string pwd = PasswordTextBox.Text;
                    string name = NameTextBox.Text;
                    string email = EmailTextBox.Text;
                    string sdt = PhoneTextBox.Text;
                    string chucvu = RoleTextBox.Text;
                    MemoryStream picture = new MemoryStream();
                    picPictureBox.Image.Save(picture, picPictureBox.Image.RawFormat);
                    if (userDAO.editUser(manv, username, pwd, name, email, sdt, picture, chucvu))
                    {
                        MessageBox.Show("Sữa thông tin người dùng thành công", "Sữa thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sữa thông tin người dùng không thành công", "Sữa thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
