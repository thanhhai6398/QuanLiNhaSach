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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        PhieuNhap phieunhap = new PhieuNhap();
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT MaPN as 'Mã phiếu nhập', NgayNhap as 'Ngày nhập', TuaSach as 'Tựa sách', SoLuong as 'Số lượng', GiaNhap as ' Giá nhập' FROM ChiTietPhieuNhap"));
        }
        public void fillGrid(SqlCommand command)
        {
            dgvPhieuNhap.ReadOnly = true;
            dgvPhieuNhap.RowTemplate.Height = 50;
            dgvPhieuNhap.DataSource = phieunhap.getTable(command);
            dgvPhieuNhap.AllowUserToAddRows = false;
        }

        private void dgvPhieuNhap_Click(object sender, EventArgs e)
        {
            txtPN.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker.Value = (DateTime)dgvPhieuNhap.CurrentRow.Cells[1].Value;
            txttuasach.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            txtsoluong.Text = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            txtGia.Text = dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mapn = txtPN.Text;
            if ((MessageBox.Show("Bạn muốn xóa phiếu nhập này?", "Xóa phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (phieunhap.deletePhieuNhap(mapn))
                {
                    // clear fields after delete
                    txtPN.Text = "";
                    dateTimePicker.Value = DateTime.Now;

                }
                MessageBox.Show("Đã xóa", "Xóa phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string mapn = txtPN.Text;
            DateTime ngayNhap = dateTimePicker.Value;

            if (phieunhap.updatePhieuNhap(mapn, ngayNhap))
            {
                MessageBox.Show("Đã cập nhật", "Cập nhật phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi", "Cập nhật phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
