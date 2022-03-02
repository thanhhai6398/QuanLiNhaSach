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
    public partial class TheLoai : Form
    {
        public TheLoai()
        {
            InitializeComponent();
        }
        Sach dao = new Sach();

        private void TheLoai_Load(object sender, EventArgs e)
        {
            this.theLoaiCB.DataSource = dao.getViewTheLoai();
            this.theLoaiCB.DisplayMember = "TenTL";
            this.theLoaiCB.ValueMember = "MaTL";
        }

        private void theLoaiCB_SelectedValueChanged(object sender, EventArgs e)
        {
            string id = theLoaiCB.SelectedValue.ToString();
            DataTable tl = dao.getTheLoaiById(id);
            if (tl.Rows.Count > 0)
            {
                this.idTxt.Text = tl.Rows[0][0].ToString();
                this.nameTxt.Text = tl.Rows[0][1].ToString();
            }
        }
        private void refresh()
        {
            this.theLoaiCB.DataSource = dao.getViewTheLoai();
            this.theLoaiCB.ValueMember = "MaTL";
            this.theLoaiCB.DisplayMember = "TenTL";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.nameTxt.Text.Trim() != "")
                {
                    string name = this.nameTxt.Text;
                    dao.insertTheLoai(name);
                    MessageBox.Show("Thêm thành công", "Thông tin Thể loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.refresh();
                }
                else MessageBox.Show("Trường rỗng", "Thông tin Thể loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    dao.updateTheLoai(id,name);
                    MessageBox.Show("Cập nhật thành công", "Thông tin Thể loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.refresh();
                }
                else MessageBox.Show("Trường rỗng","Thông tin Thể loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Thể loại này ? ", "Thông tin Thể loại", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (this.idTxt.Text.Trim() != "")
                    {
                        string id = this.idTxt.Text;
                        dao.deleteTheLoai(id);
                        MessageBox.Show("Xóa thành công", "Thông tin Thể loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                    }
                    else MessageBox.Show("Trường rỗng", "Thông tin Thể loại", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
