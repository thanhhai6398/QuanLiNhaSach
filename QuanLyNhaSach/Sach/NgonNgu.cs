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
    public partial class NgonNgu : Form
    {
        public NgonNgu()
        {
            InitializeComponent();
        }
        Sach dao = new Sach();
        private void NgonNgu_Load(object sender, EventArgs e)
        {
            this.ngonNguCB.DataSource = dao.getViewNgonNgu();
            this.ngonNguCB.ValueMember = "MaNN";
            this.ngonNguCB.DisplayMember = "TenNgonNgu";
        }
        private void refresh()
        {
            this.ngonNguCB.DataSource = dao.getViewNgonNgu();
            this.ngonNguCB.ValueMember = "MaNN";
            this.ngonNguCB.DisplayMember = "TenNgonNgu";
        }

        private void ngonNguCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.ngonNguCB.SelectedValue.ToString();
            DataTable ngonNgu = dao.getNgonNguById(id);
            if (ngonNgu.Rows.Count > 0)
            {
                this.idTxt.Text = ngonNgu.Rows[0][0].ToString();
                this.nameTxt.Text = ngonNgu.Rows[0][1].ToString();
            }
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.nameTxt.Text.Trim() != "")
                {
                    string name = this.nameTxt.Text;
                    if (dao.insertNgonNgu(name))
                    {
                        MessageBox.Show("Thêm thành công", "Thông tin ngôn ngữ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                    }
                   
                }
                else MessageBox.Show("Trường rỗng", "Thông tin ngôn ngữ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
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
                    if (dao.updateNgonNgu(id,name))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông tin Ngôn Ngữ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                    }
                   

                }
                else MessageBox.Show("Trường rỗng", "Thông tin Ngôn Ngữ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Ngôn Ngữ này ? ", "Thông tin Ngôn Ngữ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (this.idTxt.Text.Trim() != "")
                    {
                        string id = this.idTxt.Text;
                        if (dao.deleteNgonNgu(id))
                        {
                            MessageBox.Show("Xóa thành công", "Thông tin Ngôn Ngữ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.refresh();
                        }
                    }
                    else MessageBox.Show("Trường rỗng", "Thông tin Ngôn Ngữ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
