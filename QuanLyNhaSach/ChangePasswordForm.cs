using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    class ChangePasswordForm : Form
    {
        private TextBox PasswordTextBox;
        private TextBox UsernameTextBox;
        private Label label2;
        private Label UsernameLabel;
        private Label label1;
        private Button ChangePasswordButton;
        private TextBox ConfirmPasswordTextBox;
        private Label label3;

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 136);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 32);
            this.PasswordTextBox.TabIndex = 13;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextBox.Location = new System.Drawing.Point(12, 78);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(273, 32);
            this.UsernameTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "New Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(9, 55);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(91, 20);
            this.UsernameLabel.TabIndex = 10;
            this.UsernameLabel.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.Location = new System.Drawing.Point(12, 239);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(273, 33);
            this.ChangePasswordButton.TabIndex = 7;
            this.ChangePasswordButton.Text = "ĐỔI MẬT KHẨU";
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(12, 194);
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.PasswordChar = '*';
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(273, 32);
            this.ConfirmPasswordTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Confirm Password:";
            // 
            // ChangePasswordForm
            // 
            this.ClientSize = new System.Drawing.Size(298, 288);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangePasswordButton);
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        User userDAO = new User();

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                //try
                //{
                    string uname = UsernameTextBox.Text.Trim();
                    string pwd = PasswordTextBox.Text.Trim();
                    if (userDAO.ChangePassword(uname, pwd))
                    {
                        Global.username = uname;
                        Global.password = pwd;
                        MessageBox.Show("Đổi mật khẩu thành công", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                //}
                //catch
                //{
                  //  MessageBox.Show("Đổi mật khẩu thất bại", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }

        private bool verify()
        {
            if (UsernameTextBox.Text.Trim() == "" || PasswordTextBox.Text.Trim() == "" || ConfirmPasswordTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Trường rỗng", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (PasswordTextBox.Text.Trim() != ConfirmPasswordTextBox.Text.Trim()) 
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (UsernameTextBox.Text != Global.username)
            {
                MessageBox.Show("Tài khoản không khớp", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }    
            return true;
        }
    }
}
