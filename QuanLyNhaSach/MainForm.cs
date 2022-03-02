using QuanLyNhaSach.connection;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dauSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dausach frm = new Dausach();
            frm.ShowDialog();
        }

        private void ngonNguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NgonNgu frm = new NgonNgu();
            frm.Show();
        }

        private void tacGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia frm = new TacGia();
            frm.Show();
        }

        private void nhaXuatBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NXB frm = new NXB();
            frm.Show();
        }

        private void theLoaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheLoai frm = new TheLoai();
            frm.Show();
        }

        private void nhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCap frm = new NhaCungCap();
            frm.Show();
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            Global.username = "";
            Global.password = "";
            Global.chucVu = "";
            this.Close();
            loginForm.Show();
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.Show();
        }

        private void timKiemSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Global.chucVu == "Nhan Vien Kho")
            {
                quanLyToolStripMenuItem.Visible = false;
                thuNganToolStripMenuItem.Visible = false;
            }
            else if (Global.chucVu == "Thu Ngan")
            {
                quanLyToolStripMenuItem.Visible = false;
                nhanVienKhoToolStripMenuItem.Visible = false;
            }
        }

        private void nguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmkho = new frmKho();
            frmkho.Show();
        }

        private void phieuNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frmphieunhap = new frmPhieuNhap();
            frmphieunhap.Show();
        }

        private void hoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frmhoadon = new frmHoaDon();
            frmhoadon.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanhThu frmdoanhthu = new frmDoanhThu();
            frmdoanhthu.Show();
        }

        private void sachBanChayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSachBanChay frmsachbanchay = new frmSachBanChay();
            frmsachbanchay.Show();
        }

        private void nhapKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapKhoForm nhapKhoForm = new NhapKhoForm();
            nhapKhoForm.Show();
        }

        private void thanhToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThanhToanForm thanhToanForm = new ThanhToanForm();
            thanhToanForm.Show();
        }
    }
}
