namespace QuanLyNhaSach
{
    partial class ThanhToanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.MaHDTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.GiamGiaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TuaSachComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SoLuongTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GiaBanTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ThanhToanDataGridView = new System.Windows.Forms.DataGridView();
            this.MaSachColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuaSachColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHoaDonTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ThanhToanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ThanhToanDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "THANH TOÁN";
            // 
            // MaHDTextBox
            // 
            this.MaHDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaHDTextBox.Location = new System.Drawing.Point(16, 82);
            this.MaHDTextBox.Name = "MaHDTextBox";
            this.MaHDTextBox.Size = new System.Drawing.Size(170, 32);
            this.MaHDTextBox.TabIndex = 14;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(13, 59);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(101, 20);
            this.UsernameLabel.TabIndex = 13;
            this.UsernameLabel.Text = "Mã hóa đơn:";
            // 
            // GiamGiaTextBox
            // 
            this.GiamGiaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiamGiaTextBox.Location = new System.Drawing.Point(16, 140);
            this.GiamGiaTextBox.Name = "GiamGiaTextBox";
            this.GiamGiaTextBox.Size = new System.Drawing.Size(170, 32);
            this.GiamGiaTextBox.TabIndex = 16;
            this.GiamGiaTextBox.TextChanged += new System.EventHandler(this.GiamGiaTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Giảm giá:";
            // 
            // TuaSachComboBox
            // 
            this.TuaSachComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TuaSachComboBox.FormattingEnabled = true;
            this.TuaSachComboBox.Location = new System.Drawing.Point(17, 203);
            this.TuaSachComboBox.Name = "TuaSachComboBox";
            this.TuaSachComboBox.Size = new System.Drawing.Size(372, 34);
            this.TuaSachComboBox.TabIndex = 17;
            this.TuaSachComboBox.SelectedIndexChanged += new System.EventHandler(this.TuaSachComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tựa Sách:";
            // 
            // SoLuongTextBox
            // 
            this.SoLuongTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoLuongTextBox.Location = new System.Drawing.Point(395, 203);
            this.SoLuongTextBox.Name = "SoLuongTextBox";
            this.SoLuongTextBox.Size = new System.Drawing.Size(127, 32);
            this.SoLuongTextBox.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Số lượng:";
            // 
            // GiaBanTextBox
            // 
            this.GiaBanTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiaBanTextBox.Location = new System.Drawing.Point(528, 203);
            this.GiaBanTextBox.Name = "GiaBanTextBox";
            this.GiaBanTextBox.ReadOnly = true;
            this.GiaBanTextBox.Size = new System.Drawing.Size(182, 32);
            this.GiaBanTextBox.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(528, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Giá bán:";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(716, 203);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(85, 32);
            this.AddButton.TabIndex = 31;
            this.AddButton.Text = "THÊM";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(807, 203);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(85, 32);
            this.DeleteButton.TabIndex = 32;
            this.DeleteButton.Text = "XÓA";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ThanhToanDataGridView
            // 
            this.ThanhToanDataGridView.AllowUserToAddRows = false;
            this.ThanhToanDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ThanhToanDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ThanhToanDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSachColumn,
            this.TuaSachColumn,
            this.SoLuongColumn,
            this.GiaBanColumn});
            this.ThanhToanDataGridView.Location = new System.Drawing.Point(17, 243);
            this.ThanhToanDataGridView.Name = "ThanhToanDataGridView";
            this.ThanhToanDataGridView.RowHeadersWidth = 51;
            this.ThanhToanDataGridView.RowTemplate.Height = 24;
            this.ThanhToanDataGridView.Size = new System.Drawing.Size(875, 292);
            this.ThanhToanDataGridView.TabIndex = 33;
            // 
            // MaSachColumn
            // 
            this.MaSachColumn.HeaderText = "Mã Sách";
            this.MaSachColumn.MinimumWidth = 6;
            this.MaSachColumn.Name = "MaSachColumn";
            // 
            // TuaSachColumn
            // 
            this.TuaSachColumn.HeaderText = "Tựa Sách";
            this.TuaSachColumn.MinimumWidth = 6;
            this.TuaSachColumn.Name = "TuaSachColumn";
            // 
            // SoLuongColumn
            // 
            this.SoLuongColumn.HeaderText = "Số Lượng";
            this.SoLuongColumn.MinimumWidth = 6;
            this.SoLuongColumn.Name = "SoLuongColumn";
            // 
            // GiaBanColumn
            // 
            this.GiaBanColumn.HeaderText = "Giá Bán";
            this.GiaBanColumn.MinimumWidth = 6;
            this.GiaBanColumn.Name = "GiaBanColumn";
            // 
            // TongHoaDonTextBox
            // 
            this.TongHoaDonTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TongHoaDonTextBox.Location = new System.Drawing.Point(722, 541);
            this.TongHoaDonTextBox.Name = "TongHoaDonTextBox";
            this.TongHoaDonTextBox.ReadOnly = true;
            this.TongHoaDonTextBox.Size = new System.Drawing.Size(170, 32);
            this.TongHoaDonTextBox.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(584, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Tổng hóa đơn:";
            // 
            // ThanhToanButton
            // 
            this.ThanhToanButton.Location = new System.Drawing.Point(725, 579);
            this.ThanhToanButton.Name = "ThanhToanButton";
            this.ThanhToanButton.Size = new System.Drawing.Size(167, 32);
            this.ThanhToanButton.TabIndex = 36;
            this.ThanhToanButton.Text = "THANH TOÁN";
            this.ThanhToanButton.UseVisualStyleBackColor = true;
            this.ThanhToanButton.Click += new System.EventHandler(this.ThanhToanButton_Click);
            // 
            // ThanhToanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 622);
            this.Controls.Add(this.ThanhToanButton);
            this.Controls.Add(this.TongHoaDonTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ThanhToanDataGridView);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.GiaBanTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SoLuongTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TuaSachComboBox);
            this.Controls.Add(this.GiamGiaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaHDTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.label1);
            this.Name = "ThanhToanForm";
            this.Text = "ThanhToanForm";
            this.Load += new System.EventHandler(this.ThanhToanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThanhToanDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MaHDTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox GiamGiaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TuaSachComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SoLuongTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GiaBanTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView ThanhToanDataGridView;
        private System.Windows.Forms.TextBox TongHoaDonTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ThanhToanButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSachColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuaSachColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBanColumn;
    }
}