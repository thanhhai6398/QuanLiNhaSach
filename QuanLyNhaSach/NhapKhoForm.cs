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
    public partial class NhapKhoForm : Form
    {
        public NhapKhoForm()
        {
            InitializeComponent();
        }

        PhieuNhap phieunhap = new PhieuNhap();
        Sach sach = new Sach();
        private void AddButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(PhieuNhapDataGridView);
            row.Cells[0].Value = TuaSachComboBox.SelectedValue.ToString();
            row.Cells[1].Value = TuaSachComboBox.Text;
            row.Cells[2].Value = SoLuongTextBox.Text;
            row.Cells[3].Value = GiaNhapTextBox.Text;
            PhieuNhapDataGridView.Rows.Add(row);

        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.PhieuNhapDataGridView.SelectedRows)
                PhieuNhapDataGridView.Rows.RemoveAt(item.Index);
        }
        private void NhapKhoForm_Load(object sender, EventArgs e)
        {
            TuaSachComboBox.DataSource = sach.getTable(new System.Data.SqlClient.SqlCommand("SELECT * FROM DauSach"));
            TuaSachComboBox.DisplayMember = "TuaSach";
            TuaSachComboBox.ValueMember = "MaSach";
        }

        private void NhapPhieuButton_Click(object sender, EventArgs e)
        {
            string mapn = MaPNTextBox.Text;
            DateTime ngayNhap = DateTime.Now;
            PhieuNhapDataGridView.AllowUserToAddRows = false;
            for (int i = 0; i < PhieuNhapDataGridView.Rows.Count; i++)
            {

                string maS = PhieuNhapDataGridView.Rows[i].Cells[0].Value.ToString();
                int sl = Convert.ToInt32(PhieuNhapDataGridView.Rows[i].Cells[2].Value);
                string gia = PhieuNhapDataGridView.Rows[i].Cells[3].Value.ToString();
                phieunhap.insertPhieuNhap(mapn, ngayNhap, maS, sl, gia);

            }
            {
                MessageBox.Show("Đã thêm", "Thêm phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
