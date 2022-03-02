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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }
        Sach dao = new Sach();
        private void refresh()
        {
            this.dgv.DataSource = dao.getViewNCC();
            this.dgv.ReadOnly = true;
            this.dgv.AllowUserToAddRows = false;
            dgv.Columns[0].HeaderText = "Mã";
            dgv.Columns[1].HeaderText = "Nhà Cung Cấp";
            this.nameTxt.Text = "";
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.nameTxt.Text.Trim() != "")
                {
                    string name = this.nameTxt.Text;
                    dao.insertNCC(name);
                    MessageBox.Show("Thêm thành công", "Thông tin Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.refresh();
                }
                else MessageBox.Show("Trường rỗng", "Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.nameTxt.Text.Trim() != "")
                {
                    string name = this.nameTxt.Text;
                    string id = this.idTxt.Text;
                    dao.updateNCC(id, name);
                    MessageBox.Show("Cập nhật thành công", "Thông tin Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.refresh();
                }
                else MessageBox.Show("Trường rỗng", "Thông tin Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Nhà cung cấp này ? ", "Thông tin Ngôn Ngữ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (this.idTxt.Text.Trim() != "")
                    {
                        string id = this.idTxt.Text;
                        dao.deleteNCC(id);
                        MessageBox.Show("Xóa thành công", "Thông tin Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                    }
                    else MessageBox.Show("Trường rỗng", "Thông tin Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            this.dgv.DataSource = dao.getViewNCC();
            this.dgv.ReadOnly = true;
            this.dgv.AllowUserToAddRows = false;
            dgv.Columns[0].HeaderText = "Mã";
            dgv.Columns[1].HeaderText = "Nhà Cung Cấp";
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                string id = dgv.CurrentRow.Cells[0].Value.ToString();
                DataTable ncc = dao.getNCCById(id);
                if (ncc.Rows.Count > 0)
                {
                    this.idTxt.Text = ncc.Rows[0][0].ToString();
                    this.nameTxt.Text = ncc.Rows[0][1].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.searchTxt.Text.Trim() != "")
            {
                string searchTxt = this.searchTxt.Text;
                DataTable tgTable = dao.searchNCC(searchTxt);
                if (tgTable.Rows.Count > 0)
                {
                    this.dgv.DataSource = tgTable;
                }
                else MessageBox.Show("Không có kết quả", "Thông tin Nhà cung cấp");

            }
        }
    }
}
