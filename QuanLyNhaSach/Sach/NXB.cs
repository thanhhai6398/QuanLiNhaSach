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
    public partial class NXB : Form
    {
        public NXB()
        {
            InitializeComponent();
        }
        Sach dao = new Sach();
        private void NXB_Load(object sender, EventArgs e)
        {
            dgv.ReadOnly = true;
            dgv.DataSource = dao.getViewNXB();
            dgv.AllowUserToAddRows = false;
            dgv.Columns[0].HeaderText = "Mã";
            dgv.Columns[1].HeaderText = "Nhà Xuất Bản";
            dgv.Columns[2].HeaderText = "Địa Chỉ";
            dgv.Columns[3].HeaderText = "SĐT";
        }
        private bool verif()
        {
            if( this.nameTxt.Text.Trim()=="" || this.addressTxt.Text.Trim()=="" || this.sdtTxt.Text.Trim()=="")
            {
                MessageBox.Show("Trường rỗng", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    string name = this.nameTxt.Text;
                    string address = this.addressTxt.Text;
                    string phone = this.sdtTxt.Text;
                    if (dao.insertNXB(name,address,phone))
                    {
                        MessageBox.Show("Thêm thành công", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshDGV();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!Kiểm tra lại", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            string id;
            if (dgv.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                id = dgv.CurrentRow.Cells[0].Value.ToString();
                DataTable nxb = dao.getNXBById(id);
                this.idTxt.Text = nxb.Rows[0][0].ToString();
                this.nameTxt.Text = nxb.Rows[0][1].ToString();
                this.addressTxt.Text = nxb.Rows[0][2].ToString();
                this.sdtTxt.Text = nxb.Rows[0][3].ToString();
            }
            else
            {
                MessageBox.Show("Lựa chọn không hợp lệ", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(verif() && this.idTxt.Text.Trim() != "")
                {
                    string id = this.idTxt.Text;
                    string name = this.nameTxt.Text;
                    string address = this.addressTxt.Text;
                    string phone = this.sdtTxt.Text;
                    if (dao.updateNXB(id,name, address, phone))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshDGV();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!Kiểm tra lại", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa Nhà Xuất Bản này ? ", "Thông tin Nhà Xuất Bản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if ( this.idTxt.Text.Trim() != "")
                    {
                        string id = this.idTxt.Text;
                        if (dao.deleteNXB(id))
                        {
                            MessageBox.Show("Xóa thành công", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refreshDGV();
                        }
                        else MessageBox.Show("Lỗi!Kiểm tra lại", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Trường rỗng", "Thông tin Nhà Xuất Bản", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
        private void refreshDGV()
        {
            dgv.ReadOnly = true;
            dgv.DataSource = dao.getViewNXB();
            dgv.AllowUserToAddRows = false;
            dgv.Columns[0].HeaderText = "Mã";
            dgv.Columns[1].HeaderText = "Nhà Xuất Bản";
            dgv.Columns[2].HeaderText = "Địa Chỉ";
            dgv.Columns[3].HeaderText = "SĐT";
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (this.searchTxt.Text.Trim() != "")
            {
                string searchTxt = this.searchTxt.Text;
                DataTable tgTable = dao.searchNXB(searchTxt);
                if (tgTable.Rows.Count > 0)
                {
                    this.dgv.DataSource = tgTable;
                }
                else MessageBox.Show("Không có kết quả", "Thông tin Nhà xuất bản");

            }
        }
    }
}
