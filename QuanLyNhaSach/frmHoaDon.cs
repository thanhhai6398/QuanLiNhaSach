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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        HoaDon hoadon = new HoaDon();
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT MaHD as 'Mã hóa đơn', NgayMua as 'Ngày mua',TuaSach as 'Tựa sách', SoLuong as 'Số lượng', GiamGia as 'Giảm giá', TongHoaDon as 'Tổng hóa đơn' FROM ChiTietHoaDon"));
        }
        public void fillGrid(SqlCommand command)
        {
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowTemplate.Height = 50;
            dgvHoaDon.DataSource = hoadon.getTable(command);
            dgvHoaDon.AllowUserToAddRows = false;
        }
        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            txtmahd.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker.Value = (DateTime)dgvHoaDon.CurrentRow.Cells[1].Value;
            txttuasach.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
            txtsoluong.Text = dgvHoaDon.CurrentRow.Cells[3].Value.ToString();
            txtmagiamgia.Text = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
            txtthanhtien.Text = dgvHoaDon.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            DateTime ngayMua = dateTimePicker.Value;
            string giam = txtmagiamgia.Text;
            string tong = txtthanhtien.Text;

            if (hoadon.updateHoaDon(mahd, ngayMua, giam, tong))
            {
                MessageBox.Show("Đã cập nhật", "Cập nhật hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi", "Cập nhật hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            if ((MessageBox.Show("Bạn muốn xóa hóa đơn này?", "Xóa hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                hoadon.deleteHoaDon(mahd);
                MessageBox.Show("Đã xóa", "Xóa hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // clear fields after delete
                txtmahd.Text = "";
                dateTimePicker.Value = DateTime.Now;
                txtmagiamgia.Text = "";
                txtthanhtien.Text = "";

            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
