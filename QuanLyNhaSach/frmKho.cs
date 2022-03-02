using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frmKho : Form
    {
        public frmKho()
        {
            InitializeComponent();
        }

        Kho kho = new Kho();
        private void frmKho_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT MaSach as 'Mã sách', SoLuong as 'Số lượng' FROM Kho"));
        }
        public void fillGrid(SqlCommand command)
        {
            dgvKho.ReadOnly = true;
            dgvKho.RowTemplate.Height = 50;
            dgvKho.DataSource = kho.getTable(command);
            dgvKho.AllowUserToAddRows = false;
        }

        private void dgvKho_Click(object sender, EventArgs e)
        {
            txtmasach.Text = dgvKho.CurrentRow.Cells[0].Value.ToString();
            txtsoluong.Text = dgvKho.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string masach = txtmasach.Text;
            if ((MessageBox.Show("Bạn muốn xóa mã sách này trong kho?", "Xóa sách trong kho", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (kho.deleteKho(masach))
                {
                    MessageBox.Show("Đã xóa", "Xóa sách trong kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // clear fields after delete
                    txtmasach.Text = "";
                    txtsoluong.Text = "";

                }
                else
                {
                    MessageBox.Show("Chưa xóa", "Xóa sách trong kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int sl;
            string masach = txtmasach.Text;
            sl = Convert.ToInt32(txtsoluong.Text);

            if (kho.updateKho(masach, sl))
            {
                MessageBox.Show("Đã cập nhật", "Cập nhật kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi", "Cập nhật kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
