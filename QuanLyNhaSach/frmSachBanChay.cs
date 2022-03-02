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
    public partial class frmSachBanChay : Form
    {
        PhieuNhap form = new PhieuNhap();
        public frmSachBanChay()
        {
            InitializeComponent();
        }

        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.DataSource = form.getTable(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string query;
            if (rdbNgay.Checked)
            {
                string ngay = date.Value.ToString("yyyy-MM-dd");
                query = "select * from dbo.func_SachBanChayTheoNgay('" + ngay + "')";

            }
            else
            {
                string thang = txtmonth.Text;
                query = "select * from dbo.func_SachBanChayTheoThang('" + thang + "')";
            }
            command = new SqlCommand(query);
            fillGrid(command);
        }
    }
}
