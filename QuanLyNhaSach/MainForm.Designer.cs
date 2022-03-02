namespace QuanLyNhaSach
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanLyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nguoiDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dauSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngonNguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tacGiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhaXuatBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theLoaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhaCungCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phieuNhapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoaDonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sachBanChayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuNganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhanVienKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhapKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doiMatKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timKiemSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyToolStripMenuItem,
            this.thuNganToolStripMenuItem,
            this.nhanVienKhoToolStripMenuItem,
            this.doiMatKhauToolStripMenuItem,
            this.dangXuatToolStripMenuItem,
            this.timKiemSachToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanLyToolStripMenuItem
            // 
            this.quanLyToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.quanLyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nguoiDungToolStripMenuItem,
            this.sachToolStripMenuItem,
            this.khoToolStripMenuItem,
            this.phieuNhapToolStripMenuItem,
            this.hoaDonToolStripMenuItem,
            this.doanhThuToolStripMenuItem,
            this.sachBanChayToolStripMenuItem});
            this.quanLyToolStripMenuItem.Name = "quanLyToolStripMenuItem";
            this.quanLyToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quanLyToolStripMenuItem.Text = "Quản lý";
            // 
            // nguoiDungToolStripMenuItem
            // 
            this.nguoiDungToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nguoiDungToolStripMenuItem.Name = "nguoiDungToolStripMenuItem";
            this.nguoiDungToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.nguoiDungToolStripMenuItem.Text = "Người Dùng";
            this.nguoiDungToolStripMenuItem.Click += new System.EventHandler(this.nguoiDungToolStripMenuItem_Click);
            // 
            // sachToolStripMenuItem
            // 
            this.sachToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sachToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dauSachToolStripMenuItem,
            this.ngonNguToolStripMenuItem,
            this.tacGiaToolStripMenuItem,
            this.nhaXuatBanToolStripMenuItem,
            this.theLoaiToolStripMenuItem,
            this.nhaCungCapToolStripMenuItem});
            this.sachToolStripMenuItem.Name = "sachToolStripMenuItem";
            this.sachToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.sachToolStripMenuItem.Text = "Sách";
            // 
            // dauSachToolStripMenuItem
            // 
            this.dauSachToolStripMenuItem.Name = "dauSachToolStripMenuItem";
            this.dauSachToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.dauSachToolStripMenuItem.Text = "Đầu Sách";
            this.dauSachToolStripMenuItem.Click += new System.EventHandler(this.dauSachToolStripMenuItem_Click);
            // 
            // ngonNguToolStripMenuItem
            // 
            this.ngonNguToolStripMenuItem.Name = "ngonNguToolStripMenuItem";
            this.ngonNguToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.ngonNguToolStripMenuItem.Text = "Ngôn Ngữ";
            this.ngonNguToolStripMenuItem.Click += new System.EventHandler(this.ngonNguToolStripMenuItem_Click);
            // 
            // tacGiaToolStripMenuItem
            // 
            this.tacGiaToolStripMenuItem.Name = "tacGiaToolStripMenuItem";
            this.tacGiaToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.tacGiaToolStripMenuItem.Text = "Tác Giả";
            this.tacGiaToolStripMenuItem.Click += new System.EventHandler(this.tacGiaToolStripMenuItem_Click);
            // 
            // nhaXuatBanToolStripMenuItem
            // 
            this.nhaXuatBanToolStripMenuItem.Name = "nhaXuatBanToolStripMenuItem";
            this.nhaXuatBanToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.nhaXuatBanToolStripMenuItem.Text = "Nhà Xuất Bản";
            this.nhaXuatBanToolStripMenuItem.Click += new System.EventHandler(this.nhaXuatBanToolStripMenuItem_Click);
            // 
            // theLoaiToolStripMenuItem
            // 
            this.theLoaiToolStripMenuItem.Name = "theLoaiToolStripMenuItem";
            this.theLoaiToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.theLoaiToolStripMenuItem.Text = "Thể Loại";
            this.theLoaiToolStripMenuItem.Click += new System.EventHandler(this.theLoaiToolStripMenuItem_Click);
            // 
            // nhaCungCapToolStripMenuItem
            // 
            this.nhaCungCapToolStripMenuItem.Name = "nhaCungCapToolStripMenuItem";
            this.nhaCungCapToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.nhaCungCapToolStripMenuItem.Text = "Nhà Cung Cấp";
            this.nhaCungCapToolStripMenuItem.Click += new System.EventHandler(this.nhaCungCapToolStripMenuItem_Click);
            // 
            // khoToolStripMenuItem
            // 
            this.khoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.khoToolStripMenuItem.Name = "khoToolStripMenuItem";
            this.khoToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.khoToolStripMenuItem.Text = "Kho";
            this.khoToolStripMenuItem.Click += new System.EventHandler(this.khoToolStripMenuItem_Click);
            // 
            // phieuNhapToolStripMenuItem
            // 
            this.phieuNhapToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.phieuNhapToolStripMenuItem.Name = "phieuNhapToolStripMenuItem";
            this.phieuNhapToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.phieuNhapToolStripMenuItem.Text = "Phiếu Nhập";
            this.phieuNhapToolStripMenuItem.Click += new System.EventHandler(this.phieuNhapToolStripMenuItem_Click);
            // 
            // hoaDonToolStripMenuItem
            // 
            this.hoaDonToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hoaDonToolStripMenuItem.Name = "hoaDonToolStripMenuItem";
            this.hoaDonToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.hoaDonToolStripMenuItem.Text = "Hóa Đơn";
            this.hoaDonToolStripMenuItem.Click += new System.EventHandler(this.hoaDonToolStripMenuItem_Click);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.doanhThuToolStripMenuItem.Text = "Doanh Thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // sachBanChayToolStripMenuItem
            // 
            this.sachBanChayToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sachBanChayToolStripMenuItem.Name = "sachBanChayToolStripMenuItem";
            this.sachBanChayToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.sachBanChayToolStripMenuItem.Text = "Sách Bán Chạy";
            this.sachBanChayToolStripMenuItem.Click += new System.EventHandler(this.sachBanChayToolStripMenuItem_Click);
            // 
            // thuNganToolStripMenuItem
            // 
            this.thuNganToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.thuNganToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhToanToolStripMenuItem});
            this.thuNganToolStripMenuItem.Name = "thuNganToolStripMenuItem";
            this.thuNganToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.thuNganToolStripMenuItem.Text = "Thu Ngân";
            // 
            // thanhToanToolStripMenuItem
            // 
            this.thanhToanToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thanhToanToolStripMenuItem.Name = "thanhToanToolStripMenuItem";
            this.thanhToanToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thanhToanToolStripMenuItem.Text = "Thanh Toán";
            this.thanhToanToolStripMenuItem.Click += new System.EventHandler(this.thanhToanToolStripMenuItem_Click);
            // 
            // nhanVienKhoToolStripMenuItem
            // 
            this.nhanVienKhoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.nhanVienKhoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhapKhoToolStripMenuItem});
            this.nhanVienKhoToolStripMenuItem.Name = "nhanVienKhoToolStripMenuItem";
            this.nhanVienKhoToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.nhanVienKhoToolStripMenuItem.Text = "Nhân Viên Kho";
            // 
            // nhapKhoToolStripMenuItem
            // 
            this.nhapKhoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nhapKhoToolStripMenuItem.Name = "nhapKhoToolStripMenuItem";
            this.nhapKhoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhapKhoToolStripMenuItem.Text = "Nhập Kho";
            this.nhapKhoToolStripMenuItem.Click += new System.EventHandler(this.nhapKhoToolStripMenuItem_Click);
            // 
            // doiMatKhauToolStripMenuItem
            // 
            this.doiMatKhauToolStripMenuItem.Name = "doiMatKhauToolStripMenuItem";
            this.doiMatKhauToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.doiMatKhauToolStripMenuItem.Text = "Đổi Mật Khẩu";
            this.doiMatKhauToolStripMenuItem.Click += new System.EventHandler(this.doiMatKhauToolStripMenuItem_Click);
            // 
            // dangXuatToolStripMenuItem
            // 
            this.dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            this.dangXuatToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.dangXuatToolStripMenuItem.Text = "Đăng Xuất";
            this.dangXuatToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // timKiemSachToolStripMenuItem
            // 
            this.timKiemSachToolStripMenuItem.Name = "timKiemSachToolStripMenuItem";
            this.timKiemSachToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.timKiemSachToolStripMenuItem.Text = "Tìm Kiếm Sách";
            this.timKiemSachToolStripMenuItem.Click += new System.EventHandler(this.timKiemSachToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanLyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nguoiDungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dauSachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngonNguToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tacGiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhaXuatBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theLoaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhaCungCapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phieuNhapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoaDonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sachBanChayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuNganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhanVienKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhapKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doiMatKhauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timKiemSachToolStripMenuItem;
    }
}

