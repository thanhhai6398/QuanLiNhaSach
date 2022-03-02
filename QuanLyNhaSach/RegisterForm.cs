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
    public partial class RegisterForm : Form
    {
        User userDAO = new User();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

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

        private void reset()
        {
            this.IDTextBox.Text = null;
            this.UsernameTextBox.Text = null;
            this.PasswordTextBox.Text = null;
            this.NameTextBox.Text = null;
            this.EmailTextBox.Text = null;
            this.PhoneTextBox.Text = null;
            this.RoleTextBox.Text = null;
            this.picPictureBox.Image = Properties.Resources.none_image;
        }

        private bool verify()
        {
            if (IDTextBox.Text.Trim()== "" || UsernameTextBox.Text.Trim()=="" || PasswordTextBox.Text.Trim()=="" || NameTextBox.Text.Trim()==""
                || EmailTextBox.Text.Trim()=="" || PhoneTextBox.Text.Trim()=="" || RoleTextBox.Text.Trim()=="" || picPictureBox.Image==null)
            {
                MessageBox.Show("Trường rỗng", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!PhoneTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!userDAO.checkMANV(IDTextBox.Text))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (RoleTextBox.Text != "Quan Ly" && RoleTextBox.Text != "Nhan Vien Kho" && RoleTextBox.Text != "Thu Ngan")
            {
                MessageBox.Show("Chức vụ không hợp lệ", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }    
            return true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //try
            //{
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
                    if (userDAO.insertUser(manv, username, pwd, name, email, sdt, picture, chucvu))
                    {
                        MessageBox.Show("Thêm người dùng thành công", "Thêm người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm người dùng không thành công", "Thêm người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
    }
}
