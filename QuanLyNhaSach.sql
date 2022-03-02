CREATE DATABASE QLNS
GO
USE QLNS
GO
-- Co So Du Lieu --
CREATE TABLE DauSach(
MaSach char(6) CONSTRAINT PK_MaSach PRIMARY KEY,
TuaSach nvarchar(100) NOT NULL,
AnhBia image,
NamXB int NOT NULL,
MaNN char(6) ,
MaNCC char(6) ,
MaNXB char(6) ,
MaTL char(6) ,
GiaBan int NOT NULL,
MoTa text
);
GO
CREATE TABLE NgonNgu(
MaNN char (6) PRIMARY KEY,
TenNgonNgu nvarchar(100) NOT NULL
);
GO
CREATE TABLE TacGia(
MaTG char(6) CONSTRAINT PK_MaTG PRIMARY KEY,
TenTacGia nvarchar(100) NOT NULL
);
GO
CREATE TABLE SangTac(
MaTG char(6),
MaSach char(6),
CONSTRAINT PK_SangTac PRIMARY KEY (MaTG,MaSach)
);
GO
CREATE TABLE NhaCungCap (
MaNCC char(6) PRIMARY KEY,
TenNCC nvarchar(100) NOT NULL
);
GO
CREATE TABLE NhaXuatBan (
MaNXB char(6) CONSTRAINT PK_MaNXB PRIMARY KEY,
TenNXB nvarchar(100) NOT NULL,
DiaChi nvarchar(200),
SDT char(20) 
);
GO
CREATE TABLE TheLoai (
MaTL char(6) CONSTRAINT PK_MaTL PRIMARY KEY,
TenTL nvarchar(100) NOT NULL
);
GO
CREATE TABLE Kho (
MaSach char(6) CONSTRAINT PK_MaSachTrongKho PRIMARY KEY,
SoLuong int NOT NULL
);
GO
CREATE TABLE NguoiDung (
	MaNV char(6) PRIMARY KEY,
	Username char(20) NOT NULL,
	Passwd nvarchar(20) NOT NULL,
	HoTen nvarchar(30) NOT NULL,
	Email nvarchar(30) NOT NULL,
	SDT nvarchar(10) NOT NULL,
	HinhAnh image NOT NULL,
	ChucVu nvarchar(20) NOT NULL
);
GO
CREATE TABLE PhieuNhap (
	MaPN char(6) PRIMARY KEY,
	NgayNhap dateTime NOT NULL
);
GO
CREATE TABLE ThongTinPhieuNhap (
	MaPN char(6)  FOREIGN KEY REFERENCES PhieuNhap(MaPN),
	MaSach char(6),
	SoLuong int NOT NULL,
	GiaNhap nvarchar(20) NOT NULL
);
GO
CREATE TABLE HoaDon(
	MaHD char(6) PRIMARY KEY,
	NgayMua datetime NOT NULL,
	GiamGia nvarchar(6),
	TongHoaDon nvarchar(20) NOT NULL
);
GO
CREATE TABLE ThongTinHoaDon(
	MaHD char(6) FOREIGN KEY REFERENCES HoaDon(MaHD),
	MaSach char(6),
	SoLuong int NOT NULL
);
GO
ALTER TABLE DauSach ADD CONSTRAINT FK_MaNN FOREIGN KEY (MaNN) REFERENCES NgonNgu (MaNN)
ON DELETE SET NULL
ON UPDATE CASCADE
GO
ALTER TABLE DauSach ADD CONSTRAINT FK_MaNCC FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
ON DELETE SET NULL
ON UPDATE CASCADE
GO
ALTER TABLE DauSach ADD CONSTRAINT FK_MaNXB FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB)
ON DELETE SET NULL
ON UPDATE CASCADE
GO
ALTER TABLE DauSach ADD CONSTRAINT FK_MaTL FOREIGN KEY (MaTL) REFERENCES TheLoai (MaTL)
ON DELETE SET NULL
ON UPDATE CASCADE
GO
ALTER TABLE DauSach ADD CONSTRAINT kiemTraGia CHECK(GiaBan >= 0)
GO
ALTER TABLE SangTac ADD CONSTRAINT FK_MaTG FOREIGN KEY (MaTG) REFERENCES TacGia(MaTG)
GO
ALTER TABLE SangTac ADD CONSTRAINT FK_DauSach FOREIGN KEY (MaSach) REFERENCES DauSach(MaSach)
GO
ALTER TABLE Kho ADD CONSTRAINT FK_MaSach_Kho FOREIGN KEY (MaSach) REFERENCES DauSach(MaSach)
GO
ALTER TABLE Kho ADD CONSTRAINT kiemTraSL CHECK (SoLuong >=0)
GO
ALTER TABLE ThongTinPhieuNhap ADD CONSTRAINT FK_MaSach_PN FOREIGN KEY (MaSach) REFERENCES DauSach(MaSach)
ON DELETE SET NULL
ON UPDATE CASCADE
GO
ALTER TABLE ThongTinHoaDon ADD CONSTRAINT FK_MaSach_HD FOREIGN KEY (MaSach) REFERENCES DauSach(MaSach)
ON DELETE SET NULL
ON UPDATE CASCADE
GO
-- View --
-- Tạo View hiển thị chi tiết thông tin các đầu sách
CREATE View ChiTietDauSach AS
SELECT  d.MaSach, d.TuaSach, d.AnhBia, d.NamXB, tg.TenTacGia, nn.TenNgonNgu, tl.TenTL, d.GiaBan, nxb.TenNXB, ncc.TenNCC, k.SoLuong, d.MoTa
FROM DauSach d, NgonNgu nn, NhaCungCap ncc, NhaXuatBan nxb, TheLoai tl, TacGia tg, SangTac st,Kho k
WHERE d.MaNN = nn.MaNN AND d.MaNCC = ncc.MaNCC AND d.MaNXB = nxb.MaNXB AND d.MaTL = tl.MaTL AND d.MaSach = st.MaSach AND st.MaTG = tg.MaTG AND d.MaSach=k.MaSach
GO
-- Tạo View hiển thị thông tin doanh thu, sách bán chạy
CREATE VIEW View_Top20SachBanChay AS
SELECT TOP (20) DauSach.MaSach,TuaSach, Sum(SoLuong) as TongSachBanRa
FROM ThongTinHoaDon,DauSach
WHERE ThongTinHoaDon.MaSach=DauSach.MaSach
GROUP BY DauSach.MaSach, TuaSach
ORDER By Sum(SoLuong)
GO
-- Tạo View hiển thị chi tiết thông tin phiếu nhập
CREATE View ChiTietPhieuNhap 
AS
select p.MaPN, p.NgayNhap,t.MaSach, d.TuaSach, t.SoLuong, t.GiaNhap
from PhieuNhap p, ThongTinPhieuNhap t, DauSach d
where p.MaPN = t.MaPN AND t.MaSach = d.MaSach
GO
-- Tạo View hiển thị chi tiết thông tin hóa đơn
CREATE View ChiTietHoaDon AS
SELECT h.MaHD, h.NgayMua, t.MaSach, d.TuaSach, t.SoLuong, d.GiaBan, h.GiamGia, h.TongHoaDon
FROM HoaDon h, ThongTinHoaDon t, DauSach d
WHERE h.MaHD = t.MaHD AND t.MaSach = d.MaSach
GO

-- Trigger --
-- Tạo Trigger đảm bảo username không trùng nhau --
CREATE TRIGGER dbo.tr_checkusername
ON dbo.NguoiDung	
FOR INSERT
AS
BEGIN
	DECLARE @username char(20), @temp int
	SELECT @username = ne.Username FROM inserted ne
	SELECT @temp = COUNT(*) FROM NguoiDung WHERE Username = @username 
	if (@temp > 1)
	BEGIN
		PRINT N'Tài khoản đã tồn tại'
		ROLLBACK TRANSACTION
	END
END
GO
-- Tạo Trigger đảm bảo mỗi tác giả đều sáng tác ít nhất 1 đầu sách trong kho.
CREATE TRIGGER dbo.tr_checkauthorbook
ON ChiTietDauSach
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @matg char(6), @masach char(6)
	SELECT DISTINCT @matg = s.MaTG FROM deleted ol, SangTac s WHERE ol.MaSach = s.MaSach
	SELECT @masach = MaSach FROM deleted
	DELETE FROM SangTac WHERE MaSach = @masach
	DELETE FROM DauSach WHERE MaSach = @masach
	IF ((SELECT Count(*) FROM SangTac WHERE MaTG = @matg) <= 0)
	BEGIN
		DELETE FROM TacGia WHERE MaTG = @matg
	END
END
GO
-- Tạo Trigger thêm hóa đơn
CREATE TRIGGER dbo.tr_themhoadon
ON dbo.ChiTietHoaDon
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @mahd char(6), @ngaymua datetime, @masach char(6), @sl int, @giamgia nvarchar(6), @tonghd nvarchar(20), @sl_kho int
	SELECT @mahd = ne.MaHD, @ngaymua = ne.NgayMua, @masach = ne.MaSach, @sl = ne.SoLuong, @giamgia = ne.GiamGia, @tonghd = ne.TongHoaDon
	FROM inserted ne
	SELECT @sl_kho = SoLuong FROM Kho WHERE MaSach = @masach
	IF NOT EXISTS(SELECT * FROM HoaDon h WHERE h.MaHD = @mahd)
	BEGIN
		INSERT INTO HoaDon VALUES (@mahd, @ngaymua, @giamgia, @tonghd)
	END
	INSERT INTO ThongTinHoaDon VALUES (@mahd, @masach, @sl)
	IF (@sl_kho > @sl)
	BEGIN
		UPDATE Kho SET SoLuong = @sl_kho - @sl WHERE MaSach = @masach
	END
	ELSE
	BEGIN
		UPDATE Kho SET SoLuong = 0 WHERE MaSach = @masach
	END
END
GO
-- Tạo Trigger thêm phiếu nhâp
CREATE TRIGGER trg_ThemPhieuNhap_ThemKho 
ON dbo.ChiTietPhieuNhap 
INSTEAD OF INSERT AS 
BEGIN
	DECLARE @mapn char(6), @ngaynhap datetime, @masach char(6), @sl int, @gianhap nvarchar(20), @sl_kho int
	SELECT @mapn = i.MaPN, @ngaynhap = i.NgayNhap, @masach = i.MaSach, @sl = i.SoLuong, @gianhap = i.GiaNhap
	FROM inserted i
	IF NOT EXISTS(SELECT * FROM PhieuNhap WHERE PhieuNhap.MaPN = @mapn)
	BEGIN
		INSERT INTO PhieuNhap VALUES (@mapn, @ngaynhap)
	END
	INSERT INTO ThongTinPhieuNhap VALUES (@mapn, @masach, @sl, @gianhap)
	IF NOT EXISTS(SELECT * FROM Kho WHERE Kho.MaSach = @masach)
	BEGIN
		INSERT INTO Kho VALUES (@masach, @sl)
	END
	ELSE
	BEGIN
		UPDATE Kho SET SoLuong += @sl WHERE MaSach = @masach
	END
END
GO
-- Tạo Trigger xóa phiếu nhập
CREATE TRIGGER trg_XoaPhieuNhap
ON PhieuNhap
INSTEAD OF DELETE 
AS
BEGIN
	DELETE FROM ThongTinPhieuNhap WHERE MaPN IN (SELECT MaPN FROM deleted)
	DELETE FROM PhieuNhap WHERE MaPN IN (SELECT MaPN FROM deleted)
END
GO
-- Tạo Trigger xóa hóa đơn
CREATE TRIGGER tr_xoahoadon
ON ChiTietHoaDon
INSTEAD OF DELETE 
AS
BEGIN
	DELETE FROM ThongTinHoaDon WHERE MaHD IN (SELECT MaHD FROM deleted)
	DELETE FROM HoaDon WHERE MaHD IN (SELECT MaHD FROM deleted)
END
GO
-- Tao Function sinh ma dau sach tu dong
CREATE FUNCTION func_AutoIdSach()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaSach) FROM DauSach) = 0
		SET @ID = '0'
	ELSE
SELECT @ID = MAX(RIGHT(MaSach, 4)) 
FROM DauSach
		SELECT @ID = CASE
WHEN @ID >= 0 and @ID < 9 THEN 'MS000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 9 THEN 'MS00' + 
CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 99 THEN 'MS0' + 
CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 999 THEN 'MS' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-- Tao Function sinh ma tac gia tu dong
CREATE FUNCTION func_AutoIdTacGia()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaTG) FROM TacGia) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaTG, 4)) FROM TacGia
		SELECT @ID = CASE
WHEN @ID >= 0 and @ID < 9 THEN 'TG000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 9 THEN 'TG00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 99 THEN 'TG0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 999 THEN 'TG' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-- Tao Function sinh ma NXB tu dong
CREATE FUNCTION func_AutoIdNXB()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaNXB) FROM NhaXuatBan) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaNXB, 4)) 
FROM NhaXuatBan
		SELECT @ID = CASE
WHEN @ID >= 0 and @ID < 9 THEN 'XB000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 9 THEN 'XB00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 99 THEN 'XB0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 999 THEN 'XB' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-- Tao Function sinh ma NCC tu dong
CREATE FUNCTION func_AutoIdNCC()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaNCC) FROM NhaCungCap) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaNCC, 4)) 
FROM NhaCungCap
		SELECT @ID = CASE
WHEN @ID >= 0 and @ID < 9 THEN 'CC000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 9 THEN 'CC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 99 THEN 'CC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 999 THEN 'CC' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-- Tao Function sinh ma The Loai tu dong
CREATE FUNCTION func_AutoIdTheLoai()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaTL) FROM TheLoai) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaTL, 4))
 FROM TheLoai
		SELECT @ID = CASE
WHEN @ID >= 0 and @ID < 9 THEN 'TL000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 9 THEN 'TL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
	WHEN @ID >= 99 THEN 'TL0' + 
CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 999 THEN 'TL' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-- Tao Function sinh ma Ngon Ngu tu dong
CREATE FUNCTION func_AutoIdNgonNgu()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaNN) 
FROM NgonNgu) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaNN, 4)) FROM NgonNgu
		SELECT @ID = CASE
WHEN @ID >= 0 and @ID < 9 THEN 'NN000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 9 THEN 'NN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 99 THEN 'NN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
WHEN @ID >= 999 THEN 'NN' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
-- Tạo Procedure them tac gia
CREATE PROCEDURE sp_InsertTacGia @Ma char(6) output, @Ten nvarchar(100) AS
BEGIN
	IF (SELECT COUNT(*) FROM TacGia WHERE TenTacGia=@Ten) > 0
			PRINT N'Đã tồn tại'
	ELSE
		BEGIN
			EXEC @Ma = dbo.func_AutoIdTacGia
			INSERT INTO TacGia VALUES (@Ma,@Ten)
		END
	SELECT @Ma = MaTG from TacGia where TenTacGia=@Ten
END
GO
-- Tạo Procedure them NXB
CREATE PROCEDURE sp_InsertNXB @Ma char(6) output,@Ten nvarchar(100),@Diachi nvarchar(200)=NULL,@Sdt char(20) = NULL AS
BEGIN
	IF (SELECT COUNT(*) FROM NhaXuatBan WHERE TenNXB = @Ten) >0
		PRINT N'Đã Tồn Tại'
	ELSE
		BEGIN
			EXEC @Ma = DBO.func_AutoIdNXB
			INSERT INTO NhaXuatBan VALUES (@Ma,@Ten,@Diachi,@Sdt)
		END
	SELECT @Ma = MaNXB FROM NhaXuatBan WHERE TenNXB = @Ten
END
GO
-- Tạo Procedure them NCC
CREATE PROCEDURE sp_InsertNCC @Ma char(6) output,@Ten nvarchar(100) AS
BEGIN
	IF (SELECT COUNT(*) FROM NhaCungCap WHERE TenNCC= @Ten) >0
		PRINT N'Đã Tồn Tại'
	ELSE
		BEGIN
			EXEC @Ma = DBO.func_AutoIdNCC
			INSERT INTO NhaCungCap VALUES (@Ma,@Ten)
		END
	SELECT @Ma = MaNCC FROM NhaCungCap WHERE TenNCC = @Ten
END
GO
-- Tạo Procedure them The Loai
CREATE PROCEDURE sp_InsertTheLoai @Ma char(6) output,@Ten nvarchar(100) AS
BEGIN
	IF (SELECT COUNT(*) FROM TheLoai WHERE TenTL=@Ten)>0
		PRINT N'Đã Tồn Tại'
	ELSE 
		BEGIN
			EXEC @Ma = DBO.func_AutoIdTheLoai
			INSERT INTO TheLoai VALUES (@Ma,@Ten)
		END
	SELECT @Ma = MaTL FROM TheLoai WHERE TenTL = @Ten
END
GO
-- Tao Procedure them Ngon ngu
CREATE PROCEDURE sp_InsertNgonNgu @Ma char(6) output,@Ten nvarchar(100)  AS
BEGIN
	IF (SELECT COUNT(*) FROM NgonNgu WHERE TenNgonNgu = @Ten) > 0
		PRINT N'Đã Tồn Tại'
	ELSE
		BEGIN
			EXEC @Ma = DBO.func_AutoIdNgonNgu
			INSERT INTO NgonNgu VALUES (@Ma,@Ten)
		END
	SELECT @Ma =  MaNN FROM NgonNgu WHERE TenNgonNgu = @Ten
END
GO
-- Tao Procedure them dau sach
CREATE PROCEDURE sp_InsertDauSach (@Ma char(6) output,@TuaSach nvarchar(100),@Anh image = NULL,
@Nam int,@MaNN char(6),@MaNCC char(6),@MaNXB char(6),@MaTL char(6),@Gia int,@Mota text=NULL) AS
BEGIN
	IF (SELECT COUNT(*) FROM DauSach WHERE TuaSach=@TuaSach AND NamXB=@Nam)>0
		PRINT N'Đã Tồn Tại'
	ELSE 
		BEGIN
			EXEC @Ma = dbo.func_AutoIdSach
			INSERT INTO DauSach VALUES(@Ma,@TuaSach,@Anh,@Nam,@MaNN,@MaNCC,@MaNXB,@MaTL,@Gia,@Mota)
		END
	SELECT @Ma = CONVERT(char(6),MaSach) FROM DauSach WHERE TuaSach=@TuaSach AND NamXB=@Nam
END
GO
-- Tao Procedure them sang tac
CREATE PROCEDURE pro_InsertSangTac @maTG char(6),@maSach char(6) AS
BEGIN
	IF (SELECT COUNT(*) FROM SangTac WHERE MaTG = @maTG and MaSach = @maSach) >0
		PRINT N'Đã Tồn Tại'
	ELSE
		INSERT INTO SangTac VALUES (@maTG,@maSach)
END
GO

-- Tạo Trigger thêm sách từ View Chi tiết đầu sách
CREATE TRIGGER trg_InsertViewSach
ON ChiTietDauSach
INSTEAD OF INSERT AS
	DECLARE @TuaSachI nvarchar(100),@TenTG nvarchar(100),@TenTL nvarchar(100),@NamXBI int,@TenNXB nvarchar(100),@TenNCC nvarchar(100),@TenNN nvarchar(100),@GiaI int,@MotaI nvarchar
SELECT @TuaSachI  =inserted.TuaSach,@TenTG=inserted.TenTacGia,@TenTL=inserted.TenTL,@NamXBI=inserted.NamXB,@TenNXB=inserted.TenNXB,
	@TenNCC=inserted.TenNCC,@TenNN=inserted.TenNgonNgu, @GiaI=inserted.GiaBan,@MotaI=inserted.MoTa
	FROM inserted
	DECLARE @MaSach char(6),@MaTGI char(6), @MaNNI char(6), @MaTLI char(6), @MaNXBI char(6), @MaNCCI char(6)
BEGIN
	EXEC dbo.sp_InsertTacGia @Ma = @MaTGI output, @Ten = @TenTG
	EXEC dbo.sp_InsertNXB @Ma = @MaNXBI output, @Ten = @TenNXB
	EXEC dbo.sp_InsertNCC @Ma = @MaNCCI output, @Ten = @TenNCC
	EXEC dbo.sp_InsertTheLoai @Ma = @MaTLI output, @Ten=@TenTL
	EXEC dbo.sp_InsertNgonNgu @Ma = @MaNNI output, @Ten = @TenNN
	EXEC dbo.sp_InsertDauSach @Ma=@MaSach output,
@TuaSach =@TuaSachI,@Anh = NULL, @Nam=@NamXBI,@MaNN=@MaNNI,@MaNCC=@MaNCCI,
	@MaNXB = @MaNXBI,@MaTL = @MaTLI,@Gia=@GiaI,@Mota=@MotaI
	EXEC DBO.pro_InsertSangTac @MaTGI,@MaSach
END
GO

-- Store Procedure
-- Tao Procedure sua Dau Sach
CREATE PROCEDURE sp_UpdateDauSach(
	@Ma char(6),
	@TuaSach nvarchar(100),
	@AnhBia image = NULL,
	@NamXB int,
	@Gia int,
	@Mota text = NULL
)
AS
BEGIN
	UPDATE DauSach
	SET TuaSach = @TuaSach, AnhBia = @AnhBia, NamXB = @NamXB,GiaBan = @Gia, MoTa = @Mota
	WHERE MaSach = @Ma
END
GO
-- Tao Procedure xoa Dau Sach
CREATE PROCEDURE sp_DeleteDauSach(@MaSach char(100))
AS
DELETE DauSach WHERE MaSach=@MaSach;
GO
-- Tao Procedure sua Tac Gia
CREATE PROCEDURE sp_UpdateTacGia @Ma char(6), @Ten nvarchar(100) AS
BEGIN
	IF (SELECT COUNT(*) FROM TacGia WHERE TenTacGia=@Ten) > 0
			PRINT N'Đã tồn tại'
	ELSE
		BEGIN
			UPDATE TacGia SET TenTacGia = @Ten WHERE MaTG = @Ma
		END
END
GO
-- Tao Procedure xoa Tac Gia
CREATE PROCEDURE sp_DeleteTacGia(@MaTG char(6))
AS
DELETE TacGia WHERE MaTG=@MaTG;
GO
-- Tao Procedure sua The loai
CREATE PROCEDURE sp_UpdateTheLoai @Ma char(6),@Ten nvarchar(100) AS
BEGIN
	IF (SELECT COUNT(*) FROM TheLoai WHERE TenTL=@Ten)>0
		PRINT N'Đã Tồn Tại'
	ELSE 
		BEGIN
			UPDATE TheLoai SET TenTL = @Ten WHERE  MaTL = @Ma
		END
END
GO
-- Tao Procedure xoa The loai
CREATE PROCEDURE sp_DeleteTheLoai(@MaTL char(6))
AS
DELETE TheLoai WHERE MaTL=@MaTL;
GO
-- Tao Procedure sua Ngon Ngu
CREATE PROCEDURE sp_UpdateNgonNgu @Ma char(6),@Ten nvarchar(100)  AS
BEGIN
	IF (SELECT COUNT(*) FROM NgonNgu WHERE TenNgonNgu = @Ten) > 0
		PRINT N'Đã Tồn Tại'
	ELSE
		BEGIN
			UPDATE NgonNgu SET TenNgonNgu = @Ten WHERE MaNN = @Ma
		END
END
GO
-- Tao Procedure xoa Ngon Ngu
CREATE PROCEDURE sp_DeleteNgonNgu(@MaNN char(6))
AS
DELETE NgonNgu WHERE MaNN=@MaNN;
GO
-- Tao Procedure sua Nha xuat ban
CREATE PROCEDURE sp_UpdateNXB @Ma char(6),@Ten nvarchar(100),@Diachi nvarchar(200)=NULL,@Sdt char(20) = NULL AS
BEGIN
	IF (SELECT COUNT(*) FROM NhaXuatBan WHERE TenNXB = @Ten) >0
		PRINT N'Đã Tồn Tại'
	ELSE
		BEGIN
			UPDATE NhaXuatBan SET TenNXB = @Ten, DiaChi = @Diachi, SDT = @Sdt WHERE MaNXB = @Ma
		END
END
GO
-- Tao Procedure xoa Nha xuat ban
CREATE PROCEDURE sp_DeleteNXB(@MaNXB char(6))
AS
DELETE NhaXuatBan WHERE MaNXB=@MaNXB;
GO
-- Tao Procedure sua Nha cung cap
CREATE PROCEDURE sp_UpdateNCC @Ma char(6), @Ten nvarchar(100) AS
BEGIN
	IF (SELECT COUNT(*) FROM NhaCungCap WHERE TenNCC= @Ten) >0
		PRINT N'Đã Tồn Tại'
	ELSE
		BEGIN
			UPDATE NhaCungCap SET TenNCC = @Ten WHERE MaNCC = @Ma
		END
END
GO
-- Tao Procedure xoa Nha cung cap
CREATE PROCEDURE sp_DeleteNCC(@MaNCC char(6))
AS
DELETE NhaCungCap WHERE MaNCC=@MaNCC;
GO
-- Tao Procedure sua Sang Tac
CREATE PROCEDURE pro_UpdateSangTac @maTG char(6),@maSach char(6) AS
BEGIN
	IF (SELECT COUNT(*) FROM SangTac WHERE MaTG = @maTG and MaSach = @maSach) >0
		PRINT N'Đã Tồn Tại'
	ELSE
		UPDATE SangTac SET MaTG = @maTG WHERE MaSach = @maSach
END
GO
-- Tao Procedure xoa Sang Tac
CREATE PROCEDURE sp_DeleteSangTac(@MaTG char(6))
AS
DELETE SangTac WHERE MaTG=@MaTG;
GO
-- Tao Procedure Them Nhan Vien
CREATE PROCEDURE sp_themthongtinnhanvien (
	@manv char(6),
	@username char(20),
	@pwd nvarchar(20),
	@hoten nvarchar(30),
	@email nvarchar(30),
	@sdt nvarchar(10),
	@hinh image,
	@chucvu nvarchar(20)
)
AS
BEGIN
	INSERT INTO NguoiDung VALUES (@manv, @username, @pwd, @hoten, @email, @sdt, @hinh, @chucvu)
END
GO
-- Tao Procedure Sua Nhan Vien
CREATE PROCEDURE sp_suathongtinnhanvien (
	@manv char(6),
	@username char(20),
	@pwd nvarchar(20),
	@hoten nvarchar(30),
	@email nvarchar(30),
	@sdt nvarchar(10),
	@hinh image,
	@chucvu nvarchar(20)
)
AS
BEGIN
	UPDATE NguoiDung SET Username = @username, Passwd = @pwd, HoTen = @hoten, Email = @email, SDT = @sdt, HinhAnh = @hinh, ChucVu = @chucvu WHERE MaNV = @manv
END
GO
-- Tao Procedure Xoa Nhan Vien
CREATE PROCEDURE sp_xoathongtinnhanvien (
	@manv char(6)
)
AS
BEGIN
	DELETE NguoiDung WHERE MaNV = @manv
END
GO
-- Tao Procedure Dang Nhap
CREATE PROCEDURE sp_DangNhap @user char(20),@pwd nvarchar(20) AS		
BEGIN
	SELECT * FROM NguoiDung
		WHERE Username=@user AND Passwd=@pwd
END
GO
-- Tao Procedure Doi Mat Khau
CREATE PROCEDURE sp_DoiMatKhau @maNV char(6),@passwd nvarchar(20) AS
BEGIN
UPDATE NguoiDung SET Passwd=@passwd WHERE MaNV=@maNV
END	
GO
-- Tao Procedure cap nhat kho sach
CREATE PROCEDURE sp_UpdateKho(@MaSach char(100), @SL int)
	AS
	UPDATE Kho SET SoLuong=@SL WHERE MaSach=@MaSach;
GO
-- Tao Procedure xoa kho sach
CREATE PROCEDURE sp_DeleteKho(@MaSach char(100))
	AS
	DELETE Kho WHERE MaSach=@MaSach;
GO
-- Tao Procedure them hoa don
CREATE PROCEDURE sp_ThemHoaDon(
	@mahd char(6), 
	@ngaymua datetime, 
	@masach char(6), 
	@sl int, 
	@giamgia nvarchar(6), 
	@tonghd nvarchar(20)
)
AS
BEGIN
	INSERT INTO dbo.ChiTietHoaDon VALUES (@mahd, @ngaymua, @masach, NULL, @sl, NULL, @giamgia, @tonghd)
END
GO
-- Tao Procedure xoa hoa don
CREATE PROCEDURE sp_XoaHoaDon(
	@mahd char(6)
)
AS
BEGIN
	DELETE FROM dbo.ChiTietHoaDon WHERE MaHD = @mahd
END
GO
-- Tao Procedure them phieu nhap
CREATE PROCEDURE sp_InsertPhieuNhap (@Ma char(6),@Ngay dateTime, @MaS char(6), @sl int,@gia nvarchar(20)) 
AS
BEGIN
	INSERT INTO [dbo].ChiTietPhieuNhap VALUES (@Ma,@Ngay,@MaS,null,@sl ,@gia)
END
GO
-- Tao Procedure xoa phieu nhap
CREATE PROCEDURE sp_DeletePhieuNhap(@Ma char(6))
AS
DELETE PhieuNhap WHERE MaPN=@Ma;
GO

-- Function
-- Tao Function tinh doanh thu theo ngay
CREATE FUNCTION fn_doanhthutheongay()
RETURNS varchar(20)
AS
BEGIN
	DECLARE @dt float
	SELECT @dt = SUM(CAST(TongHoaDon AS float))
	FROM HoaDon 
	WHERE DATEDIFF(day, NgayMua, GETDATE()) = 0
	RETURN CONVERT(varchar(20), CAST(@dt AS money))
END
GO
-- Tao Function tinh doanh thu theo thang
CREATE FUNCTION fn_doanhthutheothang()
RETURNS varchar(20)
AS
BEGIN
	DECLARE @dt float
	SELECT @dt = SUM(CAST(TongHoaDon AS float))
	FROM HoaDon 
	WHERE DATEDIFF(month, NgayMua, GETDATE()) = 0
	RETURN CONVERT(varchar(20), CAST(@dt AS money))
END
GO
-- Tao Function tinh doanh thu theo nam
CREATE FUNCTION fn_doanhthutheonam()
RETURNS varchar(20)
AS
BEGIN
	DECLARE @dt float
	SELECT @dt = SUM(CAST(TongHoaDon AS float))
	FROM HoaDon 
	WHERE DATEDIFF(year, NgayMua, GETDATE()) = 0
	RETURN CONVERT(varchar(20), CAST(@dt AS money))
END
GO
-- Tao Function xuat sach ban chay theo ngay
CREATE FUNCTION func_SachBanChayTheoNgay(@date DATE)
RETURNS TABLE
AS
	RETURN (SELECT TOP (20) b.MaSach,TuaSach, Sum(SoLuong) AS N'Tổng sách bán ra'
	FROM ThongTinHoaDon a,DauSach b,HoaDon c
	WHERE c.NgayMua=@date AND c.MaHD=a.MaHD AND a.MaSach=b.MaSach
	GROUP BY b.MaSach,TuaSach
	ORDER By Sum(SoLuong) ASC
	)
GO
-- Tao Function xuat sach ban chay theo thang
CREATE FUNCTION func_SachBanChayTheoThang(@month int)
RETURNS TABLE
AS
	RETURN (SELECT TOP (20) b.MaSach,TuaSach, Sum(SoLuong) as N'Tổng sách bán ra'
	FROM ThongTinHoaDon a,DauSach b,HoaDon c
	WHERE Month(c.NgayMua)=@month AND c.MaHD=a.MaHD AND a.MaSach=b.MaSach
	GROUP BY b.MaSach,TuaSach
	ORDER By Sum(SoLuong) ASC
	)
GO
-- Tao Function tim kiem theo sach, ngon ngu, the loai, tac gia
CREATE FUNCTION fu_TimKiemSach(
    	@Ten NVARCHAR(100),
    	@NgonNgu NVARCHAR(100),
    	@TheLoai NVARCHAR(100),
    	@TacGia NVARCHAR(100))
RETURNS TABLE
AS
RETURN SELECT d.MaSach, d.TuaSach, d.GiaBan, n.TenNgonNgu, t.TenTL, tg.TenTacGia, k.SoLuong
FROM DauSach d, NgonNgu n, TheLoai t, SangTac s, TacGia tg, Kho k
WHERE d.MaNN = n.MaNN AND d.MaTL= t.MaTL AND d.MaSach = s.MaSach AND s.MaTG = tg.MaTG AND d.MaSach = k.MaSach
AND (@Ten IS NULL OR d.TuaSach like N'%'+@Ten+'%')
AND (@NgonNgu IS NULL OR n.TenNgonNgu like N'%'+@NgonNgu+'%')
AND (@TheLoai IS NULL OR t.TenTL like N'%'+@TheLoai+'%')
AND (@TacGia IS NULL OR tg.TenTacGia like N'%'+@TacGia+'%')
GO
-- Tao Function lấy ma sach moi them vao
CREATE FUNCTION func_NewIdSach()
RETURNS CHAR(6) AS
BEGIN
	DECLARE @id CHAR(6)
	SELECT TOP 1 @id = MaSach FROM DauSach
	ORDER BY MaSach DESC
	RETURN @id
END
GO
-- Tao Function lấy danh sách đầu sách của một tác giả
CREATE FUNCTION [dbo].[func_getListBookByAuthor](@TenTG nvarchar(30))
RETURNS TABLE 
RETURN (SELECT MaSach,TuaSach,NamXB,TenNgonNgu,TenTL
FROM ChiTietDauSach WHERE TenTacGia=@TenTG)
GO
-- Tao Function lay thong tin sach
CREATE FUNCTION	fu_getViewSach ()
RETURNS TABLE
AS
RETURN SELECT d.MaSach, d.TuaSach, d.GiaBan, n.TenNgonNgu, t.TenTL, tg.TenTacGia, k.SoLuong
		FROM DauSach d, NgonNgu n, TheLoai t, SangTac s, TacGia tg, Kho k
		WHERE d.MaNN = n.MaNN AND d.MaTL= t.MaTL AND d.MaSach = s.MaSach AND s.MaTG = tg.MaTG AND d.MaSach = k.MaSach

GO
-- Tạo Phân Quyền
-- Tao User
CREATE PROCEDURE sp_TaoUser (
	@username char(20),
	@password nvarchar(20),
	@chucvu nvarchar(20)
)
AS
BEGIN
	DECLARE @statement NVARCHAR(MAX)
	IF IS_ROLEMEMBER ( 'db_owner' , @username ) = 1
	BEGIN
		EXEC sp_droprolemember 'db_owner', @username;
	END
	IF IS_SRVROLEMEMBER ( 'securityadmin' , @username ) = 1
	BEGIN
		exec sp_dropsrvrolemember @username, N'securityadmin'
	END
	SET @statement = 'DROP USER IF EXISTS ' + @username;
	exec (@statement)
	SET @statement = 'CREATE USER ' + @username + ' FOR LOGIN ' + @username;
	exec (@statement)
	IF @chucvu = 'Quan Ly'
	BEGIN
		exec sp_addrolemember N'db_owner', @username
		exec sp_addsrvrolemember @username, N'securityadmin'
	END
	ELSE 
	BEGIN
		IF @chucvu = 'Nhan Vien Kho'
		BEGIN
			SET @statement = 'GRANT EXECUTE ON sp_InsertPhieuNhap TO ' + @username;
			exec (@statement)
			SET @statement = 'GRANT SELECT ON PhieuNhap TO ' + @username;
			exec (@statement)
		END
		IF @chucvu = 'Thu Ngan'
		BEGIN
			SET @statement = 'GRANT EXECUTE ON sp_ThemHoaDon TO ' + @username;
			exec (@statement)
			SET @statement = 'GRANT SELECT ON HoaDon TO ' + @username;
			exec (@statement)
		END
		SET @statement = 'GRANT SELECT ON NguoiDung TO ' + @username;
		exec (@statement)
		SET @statement = 'GRANT SELECT ON fu_TimKiemSach TO ' + @username;
		exec (@statement)
		SET @statement = 'GRANT SELECT ON fu_getViewSach TO ' + @username;
		exec (@statement)
		SET @statement = 'GRANT SELECT ON DauSach TO ' + @username;
		exec (@statement)
		SET @statement = 'GRANT EXECUTE ON sp_DangNhap TO ' + @username;
		exec (@statement)
		SET @statement = 'GRANT EXECUTE ON sp_DoiMatKhau  TO ' + @username;
		exec (@statement)
		SET @statement = 'GRANT EXECUTE ON sp_DoiMatKhauLogin TO ' + @username;
		exec (@statement)
	END
END
GO
-- Procedure Tao Login
CREATE PROCEDURE sp_TaoLogin(
	@username char(20),
	@password nvarchar(20),
	@chucvu nvarchar(20)
)
AS
BEGIN
	DECLARE @statement NVARCHAR(MAX)
	SET @statement = 'CREATE LOGIN ' + @username + ' WITH PASSWORD = '''+ @password + ''', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF ;'
	exec (@statement)
	exec dbo.sp_TaoUser @username, @password, @chucvu
END
GO
-- Xoa Login
CREATE PROCEDURE sp_XoaLogin(
	@username char(20)
)
AS
BEGIN
	DECLARE @sid char(20)
	DECLARE @statement NVARCHAR(MAX)
	SET @sid = (SELECT TOP 1 session_id FROM sys.dm_exec_sessions WHERE login_name = @username)
	WHILE @sid IS NOT NULL
	BEGIN
		SET @statement = 'KILL ' + @sid; 
		EXEC (@statement)
		SET @sid = (SELECT TOP 1 session_id FROM sys.dm_exec_sessions WHERE login_name = @username)
	END
	IF IS_ROLEMEMBER ( 'db_owner' , @username ) = 1
	BEGIN
		EXEC sp_droprolemember 'db_owner', @username;
	END
	IF IS_SRVROLEMEMBER ( 'securityadmin' , @username ) = 1
	BEGIN
		exec sp_dropsrvrolemember @username, N'securityadmin'
	END
	SET @statement = 'DROP USER IF EXISTS ' + @username;
	exec (@statement)
	SET @statement = 'DROP LOGIN ' + @username; 
	EXEC (@statement)
END
GO
-- Doi mat khau Login
CREATE PROCEDURE sp_DoiMatKhauLogin(
	@username char(20),
	@password nvarchar(20),
	@oldpassword nvarchar(20)
)
AS
BEGIN
	DECLARE @statement NVARCHAR(MAX)
	SET @statement = 'ALTER LOGIN ' + @username + ' WITH PASSWORD= ''' + @password + ''' OLD_PASSWORD= ''' + @oldpassword + ''' ;'
	EXEC (@statement)
END

EXEC dbo.sp_XoaLogin 'kq1'
EXEC dbo.sp_TaoLogin 'kq1', '1234567', 'Quan Ly'
EXEC dbo.sp_TaoLogin 'kq2', '1234567', 'Nhan Vien Kho'
EXEC dbo.sp_TaoLogin 'kq4', '123456', 'Thu Ngan'
EXEC dbo.sp_XoaLogin 'kq3'
EXEC dbo.sp_XoaLogin 'kq4'
EXEC dbo.sp_XoaLogin 'kq2'

-- Nhap du lieu
GO
INSERT INTO NgonNgu VALUES (1, 'Tieng Viet')
GO
INSERT INTO NhaCungCap VALUES (1, 'Nha Nam')
INSERT INTO NhaCungCap VALUES (2, 'First News')
GO
INSERT INTO NhaXuatBan VALUES (1, 'The Gioi', 'Sai Gon', '0111111111')
INSERT INTO NhaXuatBan VALUES (2, 'Hoi Nha Van', 'Sai Gon', '0222222222')
GO
INSERT INTO TheLoai VALUES (1, 'Tieu Thuyet')
INSERT INTO TheLoai VALUES (2, 'Hoi Ky')
GO
INSERT INTO TacGia VALUES (1, 'Paulo Coello')
INSERT INTO TacGia VALUES (2, 'Nguyen Phong')
GO
INSERT INTO DauSach VALUES (1, 'Nha Gia Kim', NULL, 2020, 1, 1, 1, 1, 68000, 'Sach hay')
INSERT INTO DauSach VALUES (2, 'Hanh Trinh Ve Phuong Dong', NULL, 2020, 1, 2, 2, 2, 97000, 'Sach hay')
GO
INSERT INTO SangTac VALUES (1, 1)
INSERT INTO SangTac VALUES (2, 2)
GO
INSERT INTO Kho VALUES (1, 10)
INSERT INTO Kho VALUES (2, 10)
GO
SELECT IS_SRVROLEMEMBER ( 'securityadmin' , 'kq4' )
exec sp_addsrvrolemember 'kq1', N'securityadmin'
select * from ChiTietDauSach

SELECT  d.MaSach, d.TuaSach, d.AnhBia, d.NamXB, tg.TenTacGia, nn.TenNgonNgu, tl.TenTL, d.GiaBan, nxb.TenNXB, ncc.TenNCC, k.SoLuong, d.MoTa
FROM DauSach d, NgonNgu nn, NhaCungCap ncc, NhaXuatBan nxb, TheLoai tl, TacGia tg, SangTac st,Kho k
WHERE d.MaNN = nn.MaNN AND d.MaNCC = ncc.MaNCC AND d.MaNXB = nxb.MaNXB AND d.MaTL = tl.MaTL AND d.MaSach = st.MaSach AND st.MaTG = tg.MaTG AND d.MaSach=k.MaSach

SELECT fn_doanhthutheongay()






