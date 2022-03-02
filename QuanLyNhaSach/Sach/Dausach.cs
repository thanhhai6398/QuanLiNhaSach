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
    public partial class Dausach : Form
    {
        public Dausach()
        {
            InitializeComponent();
        }
        Sach dao = new Sach();
        private void Dausach_Load(object sender, EventArgs e)
        {
            ChiTietDauSach.ReadOnly = true;
            ChiTietDauSach.RowTemplate.Height = 80;
            DataTable table = dao.getViewBook();
            this.ChiTietDauSach.DataSource = table;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)ChiTietDauSach.Columns[2];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ChiTietDauSach.AllowUserToAddRows = false;
            ChiTietDauSach.Columns[0].HeaderText = "Mã";
            ChiTietDauSach.Columns[1].HeaderText = "Tựa";
            ChiTietDauSach.Columns[2].HeaderText = "Ảnh Bìa";
            ChiTietDauSach.Columns[3].HeaderText = "Năm";
            ChiTietDauSach.Columns[4].HeaderText = "Tác Giả";
            ChiTietDauSach.Columns[5].HeaderText = "Ngôn Ngữ";
            ChiTietDauSach.Columns[6].HeaderText = "Thể Loại";
            ChiTietDauSach.Columns[7].HeaderText = "Giá Bán";
            ChiTietDauSach.Columns[8].HeaderText = "Nhà Xuất Bản";
            ChiTietDauSach.Columns[9].HeaderText = "Nhà Cung Cấp";
            ChiTietDauSach.Columns[10].HeaderText = "Kho";
            ChiTietDauSach.Columns[11].HeaderText = "Mô Tả";
            ChiTietDauSach.Columns[1].Width = 200;
            this.checkKho();

        }
        private void checkKho()
        {
            for(int i=0;i< ChiTietDauSach.Rows.Count; i++)
            {
                string sl = ChiTietDauSach.Rows[i].Cells[10].Value.ToString();
                if (sl.Equals("0"))
                {
                    ChiTietDauSach.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                    ChiTietDauSach.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void fillGrid(DataGridView dgv, SqlCommand command)
        {
            dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 80;
            dgv.DataSource = dao.getTable(command);
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgv.Columns["AnhBia"];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgv.AllowUserToAddRows = false;
        }

        private void ChiTietDauSach_DoubleClick(object sender, EventArgs e)
        {
            string id;
            if (ChiTietDauSach.CurrentCell.Value != DBNull.Value)
            {
                id =ChiTietDauSach.CurrentRow.Cells[0].Value.ToString();
                ChiTietSach frm = new ChiTietSach(id);
                frm.ShowDialog();
            }
            else MessageBox.Show("Lựa chọn không hợp lệ", "Chi tiết đầu sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChiTietSach frm = new ChiTietSach("");
            frm.ShowDialog();
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            ChiTietDauSach.ReadOnly = true;
            ChiTietDauSach.RowTemplate.Height = 80;
            DataTable table = dao.getViewBook();
            this.ChiTietDauSach.DataSource = table;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)ChiTietDauSach.Columns[2];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ChiTietDauSach.AllowUserToAddRows = false;
            ChiTietDauSach.AllowUserToAddRows = false;
            ChiTietDauSach.Columns[0].HeaderText = "Mã";
            ChiTietDauSach.Columns[1].HeaderText = "Tựa";
            ChiTietDauSach.Columns[2].HeaderText = "Ảnh Bìa";
            ChiTietDauSach.Columns[3].HeaderText = "Năm";
            ChiTietDauSach.Columns[4].HeaderText = "Tác Giả";
            ChiTietDauSach.Columns[5].HeaderText = "Ngôn Ngữ";
            ChiTietDauSach.Columns[6].HeaderText = "Thể Loại";
            ChiTietDauSach.Columns[7].HeaderText = "Giá Bán";
            ChiTietDauSach.Columns[8].HeaderText = "Nhà Xuất Bản";
            ChiTietDauSach.Columns[9].HeaderText = "Nhà Cung Cấp";
            ChiTietDauSach.Columns[10].HeaderText = "Kho";
            ChiTietDauSach.Columns[11].HeaderText = "Mô Tả";
            this.checkKho();
        }

        private void searchbtn_Click(object sender, EventArgs e)

        {
            if (this.searchTxt.Text.Trim() != "")
            {
                string searchTxt = this.searchTxt.Text.Trim();
                DataTable result = dao.search(searchTxt);
                if (result.Rows.Count > 0)
                {
                    this.ChiTietDauSach.DataSource = result;
                    ChiTietDauSach.ReadOnly = true;
                    ChiTietDauSach.RowTemplate.Height = 80;
                }
                else MessageBox.Show("Khong tìm ra");
               
            }
           
            
        }
    }
}
