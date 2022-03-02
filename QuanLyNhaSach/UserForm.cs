using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class UserForm : Form
    {
        User userDAO = new User();

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            UserDataGridView.ReadOnly = true;
            UserDataGridView.RowTemplate.Height = 80;
            DataTable table = userDAO.getAllUsers();
            this.UserDataGridView.DataSource = table;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)UserDataGridView.Columns[6];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            UserDataGridView.AllowUserToAddRows = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = (string)UserDataGridView.SelectedRows[0].Cells["MaNV"].Value;
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Thông tin nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (userDAO.deleteUser(manv) == true)
                    {
                        MessageBox.Show("Xóa thành công", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }    

                }

            }
            catch
            {
                
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = (string)UserDataGridView.SelectedRows[0].Cells["MaNV"].Value;
                EditEmployeeForm editEmployeeForm = new EditEmployeeForm(manv);
                editEmployeeForm.Show();
            }
            catch
            {

            }
        }

        private void reload()
        {
            DataTable table = userDAO.getAllUsers();
            this.UserDataGridView.DataSource = table;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)UserDataGridView.Columns[6];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            UserDataGridView.AllowUserToAddRows = false;
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            reload();
        }
    }
}
