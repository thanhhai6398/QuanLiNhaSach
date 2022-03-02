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
    public partial class ThanhToanForm : Form
    {
        public ThanhToanForm()
        {
            InitializeComponent();
        }

        HoaDonQ hoaDonDAO = new HoaDonQ();
        int tongGia = 0;
        int tongHoaDon = 0;

        private void ThanhToanForm_Load(object sender, EventArgs e)
        {
            TuaSachComboBox.DataSource = hoaDonDAO.getAllBook();
            TuaSachComboBox.DisplayMember = "TuaSach";
            TuaSachComboBox.ValueMember = "MaSach";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (SoLuongTextBox.Text.Trim() != "" && GiaBanTextBox.Text.Trim() != "")
            {
                try
                {
                    string id = TuaSachComboBox.SelectedValue.ToString();
                    foreach (DataGridViewRow item in ThanhToanDataGridView.Rows)
                    {
                        if (item.Cells[0].Value.ToString().Equals(id))
                        {
                            MessageBox.Show("Sách đã được thêm vào hóa đơn", "Thêm hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }    
                    }
                    string tuasach = TuaSachComboBox.Text;
                    int soluong = Int32.Parse(SoLuongTextBox.Text);
                    int gia = Int32.Parse(GiaBanTextBox.Text);
                    ThanhToanDataGridView.Rows.Add(id, tuasach, soluong, gia);
                    tongGia += soluong * gia;
                    if (GiamGiaTextBox.Text.Trim() != "")
                    {
                        tongHoaDon = (int)tongGia * (100 - Int32.Parse(GiamGiaTextBox.Text.Trim())) / 100;
                    }
                    else
                    {
                        tongHoaDon = tongGia;
                    }    
                    TongHoaDonTextBox.Text = tongHoaDon.ToString();
                    SoLuongTextBox.Text = "";
                }
                catch
                {
                    MessageBox.Show("Thông tin nhập không hợp lệ", "Thêm hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TuaSachComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = (string)TuaSachComboBox.SelectedValue;
                string gia = hoaDonDAO.getGiaSachByID(id);
                GiaBanTextBox.Text = gia;
            }
            catch
            {

            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in ThanhToanDataGridView.SelectedRows)
            {
                tongGia -= Int32.Parse(item.Cells[2].Value.ToString()) * Int32.Parse(item.Cells[3].Value.ToString());
                ThanhToanDataGridView.Rows.RemoveAt(item.Index);
            }
            TinhTongHoaDon();
        }

        private void ThanhToanButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (verify())
                {
                    string mahd = MaHDTextBox.Text;
                    string giamgia = GiamGiaTextBox.Text;
                    foreach (DataGridViewRow row in ThanhToanDataGridView.Rows)
                    {
                        hoaDonDAO.insertHoaDon(mahd, row.Cells[0].Value.ToString(), Int32.Parse(row.Cells[2].Value.ToString()), giamgia, tongHoaDon.ToString());
                    }
                    MessageBox.Show("Thêm hóa đơn thành công", "Thêm hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
            
        }

        private bool verify()
        {
            if (MaHDTextBox.Text.Trim() == "" || GiamGiaTextBox.Text.Trim() == "" || ThanhToanDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Trường trống", "Thêm hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if  (!hoaDonDAO.checkMAHD(MaHDTextBox.Text.Trim()))
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại", "Thêm hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void GiamGiaTextBox_TextChanged(object sender, EventArgs e)
        {
            TinhTongHoaDon();   
        }

        private void TinhTongHoaDon()
        {
            try
            {
                tongHoaDon = (int)tongGia * (100 - Int32.Parse(GiamGiaTextBox.Text.Trim())) / 100;
                TongHoaDonTextBox.Text = tongHoaDon.ToString();
            }
            catch
            {
                tongHoaDon = tongGia;
                TongHoaDonTextBox.Text = tongHoaDon.ToString();
            }
        }
    }
}
