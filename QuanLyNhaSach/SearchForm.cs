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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        search searchDAO = new search();

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Trim() != "" && searchComboBox.Text.Trim() != "")
            {
                string s = SearchTextBox.Text;
                string type = searchComboBox.Text;
                DataTable table = searchDAO.searchBooks(s, type);
                fillGrid(table);
            }   
            else
            {
                MessageBox.Show("Trường rỗng", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DataTable table = searchDAO.getAllBooks();
            fillGrid(table);
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            DataTable table = searchDAO.getAllBooks();
            fillGrid(table);
        }

        private void fillGrid(DataTable table)
        {
            BookDataGridView.ReadOnly = true;
            BookDataGridView.RowTemplate.Height = 80;
            this.BookDataGridView.DataSource = table;
            BookDataGridView.AllowUserToAddRows = false;
        }
    }
}
