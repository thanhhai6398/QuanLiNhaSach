namespace QuanLyNhaSach
{
    partial class NhapKhoForm
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
            this.NhapPhieuButton = new System.Windows.Forms.Button();
            this.PhieuNhapDataGridView = new System.Windows.Forms.DataGridView();
            this.MaSachColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuaSachColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.GiaNhapTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SoLuongTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TuaSachComboBox = new System.Windows.Forms.ComboBox();
            this.MaPNTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PhieuNhapDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NhapPhieuButton
            // 
            this.NhapPhieuButton.Location = new System.Drawing.Point(540, 388);
            this.NhapPhieuButton.Margin = new System.Windows.Forms.Padding(2);
            this.NhapPhieuButton.Name = "NhapPhieuButton";
            this.NhapPhieuButton.Size = new System.Drawing.Size(125, 26);
            this.NhapPhieuButton.TabIndex = 53;
            this.NhapPhieuButton.Text = "NHẬP PHIẾU";
            this.NhapPhieuButton.UseVisualStyleBackColor = true;
            this.NhapPhieuButton.Click += new System.EventHandler(this.NhapPhieuButton_Click);
            // 
            // PhieuNhapDataGridView
            // 
            this.PhieuNhapDataGridView.AllowUserToAddRows = false;
            this.PhieuNhapDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PhieuNhapDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhieuNhapDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSachColumn,
            this.TuaSachColumn,
            this.SoLuongColumn,
            this.GiaNhapColumn});
            this.PhieuNhapDataGridView.Location = new System.Drawing.Point(9, 145);
            this.PhieuNhapDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.PhieuNhapDataGridView.Name = "PhieuNhapDataGridView";
            this.PhieuNhapDataGridView.RowHeadersWidth = 51;
            this.PhieuNhapDataGridView.RowTemplate.Height = 24;
            this.PhieuNhapDataGridView.Size = new System.Drawing.Size(656, 237);
            this.PhieuNhapDataGridView.TabIndex = 50;
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
            // GiaNhapColumn
            // 
            this.GiaNhapColumn.HeaderText = "Giá Nhập";
            this.GiaNhapColumn.MinimumWidth = 6;
            this.GiaNhapColumn.Name = "GiaNhapColumn";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(602, 113);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(64, 26);
            this.DeleteButton.TabIndex = 49;
            this.DeleteButton.Text = "XÓA";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(533, 113);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(64, 26);
            this.AddButton.TabIndex = 48;
            this.AddButton.Text = "THÊM";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GiaNhapTextBox
            // 
            this.GiaNhapTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiaNhapTextBox.Location = new System.Drawing.Point(392, 113);
            this.GiaNhapTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GiaNhapTextBox.Name = "GiaNhapTextBox";
            this.GiaNhapTextBox.Size = new System.Drawing.Size(138, 27);
            this.GiaNhapTextBox.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(392, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Giá nhập:";
            // 
            // SoLuongTextBox
            // 
            this.SoLuongTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoLuongTextBox.Location = new System.Drawing.Point(292, 113);
            this.SoLuongTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SoLuongTextBox.Name = "SoLuongTextBox";
            this.SoLuongTextBox.Size = new System.Drawing.Size(96, 27);
            this.SoLuongTextBox.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tựa Sách:";
            // 
            // TuaSachComboBox
            // 
            this.TuaSachComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TuaSachComboBox.FormattingEnabled = true;
            this.TuaSachComboBox.Location = new System.Drawing.Point(9, 113);
            this.TuaSachComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.TuaSachComboBox.Name = "TuaSachComboBox";
            this.TuaSachComboBox.Size = new System.Drawing.Size(280, 26);
            this.TuaSachComboBox.TabIndex = 42;
            // 
            // MaPNTextBox
            // 
            this.MaPNTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaPNTextBox.Location = new System.Drawing.Point(8, 66);
            this.MaPNTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MaPNTextBox.Name = "MaPNTextBox";
            this.MaPNTextBox.Size = new System.Drawing.Size(128, 27);
            this.MaPNTextBox.TabIndex = 39;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(6, 47);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(106, 17);
            this.UsernameLabel.TabIndex = 38;
            this.UsernameLabel.Text = "Mã phiếu nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "PHIẾU NHẬP";
            // 
            // NhapKhoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 417);
            this.Controls.Add(this.NhapPhieuButton);
            this.Controls.Add(this.PhieuNhapDataGridView);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.GiaNhapTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SoLuongTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TuaSachComboBox);
            this.Controls.Add(this.MaPNTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NhapKhoForm";
            this.Text = "NhapKhoForm";
            this.Load += new System.EventHandler(this.NhapKhoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhieuNhapDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NhapPhieuButton;
        private System.Windows.Forms.DataGridView PhieuNhapDataGridView;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox GiaNhapTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SoLuongTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TuaSachComboBox;
        private System.Windows.Forms.TextBox MaPNTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSachColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuaSachColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhapColumn;
    }
}