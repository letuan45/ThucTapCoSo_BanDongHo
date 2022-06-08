/*
------------BEGIN OF STORE PROCEDURE SESSION------------
*/
GO
CREATE PROC [dbo].[SP_CAPNHAT_DONGHO] @MADONGHO NVARCHAR(10), @TENDONGHO NVARCHAR(50), @GIA MONEY, @MOTA NTEXT, @HINHANH NVARCHAR(128), @MATRANGTHAI NVARCHAR(5), @MALOAI NVARCHAR(10), @MAHANG NVARCHAR(10) AS
BEGIN
	UPDATE DongHo
	SET TenDongHo = @TENDONGHO, Gia = @GIA, MoTa = @MOTA, HinhAnh = @HINHANH, MaTrangThai = @MATRANGTHAI, MaLoai = @MALOAI, MaHang = @MAHANG
	WHERE MaDongHo = @MADONGHO
END

GO
CREATE PROC [dbo].[SP_CHECK_HAS_FULLBACKUP]
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM FN_GET_BACKUP_HISTORY() WHERE LOAI = 'Full')
		RAISERROR(N'Hiện chưa có bản Full Backup gần nhất', 16, 1)
	ELSE SELECT 1
END

GO
CREATE PROC [dbo].[SP_DANGKY_KHACHHANG] @TAIKHOAN NVARCHAR(20), @MATKHAU NVARCHAR(20), @CMND NVARCHAR(10), @HO NVARCHAR(40), @TEN NVARCHAR(10), @GIOITINH NVARCHAR(3), @NGAYSINH DATE, @DIACHI NVARCHAR(128), @SDT NVARCHAR(10), @EMAIL NVARCHAR(128), @MASOTHUE NVARCHAR(20)
AS
BEGIN
	IF EXISTS(SELECT TaiKhoan FROM TaiKhoan WHERE TaiKhoan = @TAIKHOAN)
		RAISERROR('Tài khoản đã tồn tại, vui lòng chọn tài khoản khác', 16, 1);
	ELSE IF EXISTS(SELECT MaKhachHang FROM KhachHang WHERE CMND = @CMND)
		RAISERROR('CMND đã tồn tại', 16, 1);
	ELSE IF EXISTS(SELECT MaKhachHang FROM KhachHang WHERE SDT = @SDT)
		RAISERROR('Số điện thoại đã tồn tại', 16, 1);
	ELSE
	BEGIN
		BEGIN TRAN
			INSERT INTO TaiKhoan(TaiKhoan, MatKhau, Nhom) VALUES(@TAIKHOAN, @MATKHAU, 'khachhang')
			INSERT INTO KhachHang(CMND, Ho, Ten, GioiTinh, NgaySinh, DiaChi, SDT, Email, MaSoThue, TaiKhoan)
			VALUES(@CMND, @HO, @TEN, @GIOITINH, @NGAYSINH, @DIACHI, @SDT, @EMAIL, @MASOTHUE, @TAIKHOAN)
		COMMIT TRAN
	END
END

GO
CREATE PROC [dbo].[SP_DANGNHAP] @TAIKHOAN NVARCHAR(20), @MATKHAU NVARCHAR(20) AS
BEGIN
	IF EXISTS(SELECT TaiKhoan FROM TaiKhoan WHERE TaiKhoan = @TAIKHOAN AND MatKhau = @MATKHAU)
	BEGIN
		DECLARE @NHOM NVARCHAR(10)
		SELECT @NHOM = Nhom
		FROM TaiKhoan
		WHERE TaiKhoan = @TAIKHOAN AND MatKhau = @MATKHAU
		
		IF(@NHOM = 'nhanvien' OR @NHOM = 'quantri')
		BEGIN
			SELECT ID = MaNhanVien, Nhom, HoTen = Ho + ' ' + Ten, TaiKhoan.TaiKhoan, SDT, DiaChi
			FROM TaiKhoan
			INNER JOIN NhanVien
			ON TaiKhoan.TaiKhoan = NhanVien.TaiKhoan
			WHERE TaiKhoan.TaiKhoan = @TAIKHOAN AND TaiKhoan.MatKhau = @MATKHAU 
		END
		ELSE
		BEGIN
			SELECT ID = MaKhachHang, Nhom, HoTen = Ho + ' ' + Ten, TaiKhoan.TaiKhoan, SDT, DiaChi
			FROM TaiKhoan
			INNER JOIN KhachHang
			ON TaiKhoan.TaiKhoan = KhachHang.TaiKhoan
			WHERE TaiKhoan.TaiKhoan = @TAIKHOAN AND TaiKhoan.MatKhau = @MATKHAU 
		END
	END
	ELSE
		RAISERROR('Tài khoản hoặc mật khẩu không chính xác', 16, 1);
END

GO
CREATE PROC [dbo].[SP_DIFF_BACKUP] @DISKPATH VARCHAR(255)
AS
BEGIN
	BACKUP DATABASE BanDongHo to disk = @DISKPATH WITH INIT,DIFFERENTIAL
END

GO
CREATE PROC [dbo].[SP_DOI_MATKHAU] @TAIKHOAN NVARCHAR(20), @MATKHAUCU NVARCHAR(20), @MATKHAUMOI NVARCHAR(20) AS
BEGIN
	IF NOT EXISTS(SELECT TaiKhoan FROM TaiKhoan WHERE TaiKhoan = @TAIKHOAN AND MatKhau = @MATKHAUCU)
		RAISERROR('Mật khẩu cũ không chính xác', 16, 1);
	ELSE
		UPDATE TaiKhoan
		SET MatKhau = @MATKHAUMOI
		WHERE TaiKhoan = @TAIKHOAN
END

GO
CREATE PROC [dbo].[SP_FULLBACKUP] @DISKPATH VARCHAR(255)
AS
BEGIN
	BACKUP DATABASE BanDongHo to disk = @DISKPATH WITH INIT
END

GO
CREATE PROC [dbo].[SP_GET_1_CT_DONDATHANG] @MADONDATHANG NVARCHAR(20), @MADONGHO NVARCHAR(10) AS
BEGIN
	DECLARE @SLDANHAP INT
	IF EXISTS(SELECT SoLuong FROM CT_PhieuNhap WHERE MaPhieuNhap = @MADONDATHANG AND MaDongHo = @MADONGHO)
		SELECT @SLDANHAP = SUM(SoLuong) FROM CT_PhieuNhap WHERE MaPhieuNhap = @MADONDATHANG AND MaDongHo = @MADONGHO
	ELSE
		SET @SLDANHAP = 0
	SELECT SoLuong = SoLuong - @SLDANHAP, DonGia
	FROM CT_DonDatHang
	WHERE MaDonDatHang = @MADONDATHANG AND MaDongHo = @MADONGHO
END

GO
CREATE PROC [dbo].[SP_GET_CT_DONDATHANG] @MADONDATHANG NVARCHAR(20) AS
BEGIN
	SELECT MaDonDatHang, MaDongHo, SoLuong, DonGia
	FROM CT_DonDatHang
	WHERE MaDonDatHang = @MADONDATHANG
END

GO
CREATE PROC [dbo].[SP_GET_CT_PHIEUNHAP] @MAPHIEUNHAP NVARCHAR(20)
AS
BEGIN
	SELECT MaPhieuNhap, MaDongHo, DonGia, SoLuong
	FROM CT_PhieuNhap
	WHERE MaPhieuNhap = @MAPHIEUNHAP
END

GO
CREATE PROC [dbo].[SP_GET_DONDATHANG] AS
BEGIN
	SELECT MaDonDatHang, NgayDatHang, MaNhanVien, 
		NhaCungCap = (SELECT TenNhaCungCap FROM NhaCungCap WHERE NhaCungCap.MaNhaCungCap = DonDatHang.MaNhaCungCap),
		DaNhapHang = IIF(EXISTS(SELECT MaPhieuNhap FROM PhieuNhap WHERE MaPhieuNhap = MaDonDatHang), 1, 0)
	FROM DonDatHang
END

GO
CREATE PROC [dbo].[SP_GET_DONGHO] AS
BEGIN
	SELECT MaDongHo, TenDongHo, Gia, SoLuongTon, MoTa, HinhAnh, 
		TrangThai = (SELECT TrangThai FROM TrangThai WHERE TrangThai.MaTrangThai = DongHo.MaTrangThai),
		Loai = (SELECT TenLoai FROM LoaiDongHo WHERE LoaiDongHo.MaLoai = DongHo.MaLoai),
		Hang = (SELECT TenHang FROM HangDongHo WHERE HangDongHo.MaHang = DongHo.MaHang),
		NhaCungCap = (SELECT TenNhaCungCap FROM NhaCungCap WHERE NhaCungCap.MaNhaCungCap = DongHo.MaNhaCungCap)
	FROM DongHo
END

GO
CREATE PROC [dbo].[SP_GET_DONGHO_KH] AS
BEGIN
	SELECT MaDongHo, TenDongHo, Gia, SoLuongTon, MoTa, HinhAnh, 
		TrangThai = (SELECT TrangThai FROM TrangThai WHERE TrangThai.MaTrangThai = DongHo.MaTrangThai),
		Loai = (SELECT TenLoai FROM LoaiDongHo WHERE LoaiDongHo.MaLoai = DongHo.MaLoai),
		Hang = (SELECT TenHang FROM HangDongHo WHERE HangDongHo.MaHang = DongHo.MaHang),
		NhaCungCap = (SELECT TenNhaCungCap FROM NhaCungCap WHERE NhaCungCap.MaNhaCungCap = DongHo.MaNhaCungCap)
	FROM DongHo 
	WHERE DongHo.MaTrangThai != 'NKD' 
	ORDER BY TrangThai
END

GO
CREATE PROC [dbo].[SP_GET_THONG_TIN_KH]
@MaKhachHang INT
AS
BEGIN
	SELECT HOTEN = HO + ' ' + Ten, SDT, DiaChi FROM KhachHang WHERE MaKhachHang = @MaKhachHang
END

GO
CREATE PROC [dbo].[SP_LOG_BACKUP] @DISKPATH VARCHAR(255)
AS
BEGIN
	BACKUP LOG BanDongHo to disk = @DISKPATH WITH INIT, NO_TRUNCATE
END

GO
CREATE PROC [dbo].[SP_SUA_CT_DONDATHANG] @MADONDATHANG NVARCHAR(20), @MADONGHO NVARCHAR(10), @SOLUONG INT, @DONGIA MONEY AS
BEGIN
	UPDATE CT_DonDatHang
	SET SoLuong = @SOLUONG, DonGia = @DONGIA
	WHERE MaDonDatHang = @MADONDATHANG AND MaDongHo = @MADONGHO
END

GO
CREATE PROC [dbo].[SP_SUA_CT_PHIEUNHAP] @MAPHIEUNHAP NVARCHAR(20), @MADONGHO NVARCHAR(10), @DONGIA MONEY, @SOLUONG INT AS
BEGIN
	IF @SOLUONG > (SELECT SoLuong FROM CT_PhieuNhap WHERE MaPhieuNhap = @MAPHIEUNHAP AND MaDongHo = @MADONGHO) -- Sửa TĂNG số lượng nhập hàng
		UPDATE CT_PhieuNhap
		SET SoLuong = @SOLUONG, DonGia = @DONGIA
		WHERE MaPhieuNhap = @MAPHIEUNHAP AND MaDongHo = @MADONGHO
	ELSE
	BEGIN
		DECLARE @SLTON INT
		SELECT @SLTON = SoLuongTon FROM DongHo WHERE MaDongHo = @MADONGHO
		IF @SOLUONG - (SELECT SoLuong FROM CT_PhieuNhap WHERE MaPhieuNhap = @MAPHIEUNHAP AND MaDongHo = @MADONGHO) > @SLTON
			RAISERROR('Số lượng tồn của sản phẩm này hiện không đủ để giảm số lượng nhập', 16, 1);
		ELSE
			UPDATE CT_PhieuNhap
			SET SoLuong = @SOLUONG, DonGia = @DONGIA
			WHERE MaPhieuNhap = @MAPHIEUNHAP AND MaDongHo = @MADONGHO
	END
END

GO
CREATE PROC [dbo].[SP_THEM_CT_DONDATHANG] @MADONDATHANG NVARCHAR(20), @MADONGHO NVARCHAR(10), @SOLUONG INT, @DONGIA MONEY AS
BEGIN
	INSERT INTO CT_DonDatHang(MaDonDatHang, MaDongHo, SoLuong, DonGia)
	VALUES(@MADONDATHANG, @MADONGHO, @SOLUONG, @DONGIA)
END

GO
CREATE PROC [dbo].[SP_THEM_CT_PHIEU_DAT]
@MaPhieuDat INT,
@MaDongHo NVARCHAR(10),
@SoLuong INT,
@DonGia MONEY
AS
BEGIN
	INSERT INTO CT_PhieuDat (MaPhieuDat, MaDongHo, SoLuong, DonGia)
	VALUES (@MaPhieuDat, @MaDongHo, @SoLuong, @DonGia)
END

GO
CREATE PROC [dbo].[SP_THEM_CT_PHIEUNHAP] @MAPHIEUNHAP NVARCHAR(20), @MADONGHO NVARCHAR(10), @DONGIA MONEY, @SOLUONG INT AS
BEGIN
	IF EXISTS(SELECT MaPhieuNhap FROM CT_PhieuNhap WHERE MaPhieuNhap = @MAPHIEUNHAP AND MaDongHo = @MADONGHO AND DonGia = @DONGIA)
		RAISERROR('Không thể thêm chi tiết bởi vì chi tiết nhập hàng đồng hồ với đơn giá này đã tồn tại', 16, 1);
	ELSE
	BEGIN
		INSERT CT_PhieuNhap(MaPhieuNhap, MaDongHo, DonGia, SoLuong)
		VALUES(@MAPHIEUNHAP, @MADONGHO, @DONGIA, @SOLUONG)
	END
END

GO
CREATE PROC [dbo].[SP_THEM_DONDATHANG] @MADONDATHANG NVARCHAR(20), @MANHANVIEN INT, @MANHACUNGCAP NVARCHAR(10) AS
BEGIN
	IF EXISTS(SELECT MaDonDatHang FROM DonDatHang WHERE MaDonDatHang = @MADONDATHANG)
		RAISERROR('Mã đơn đặt hàng đã tồn tại', 16, 1);
	ELSE
		INSERT INTO DonDatHang(MaDonDatHang, NgayDatHang, MaNhanVien, MaNhaCungCap)
		VALUES(@MADONDATHANG, GETDATE(), @MANHANVIEN, @MANHACUNGCAP)
END

GO
CREATE PROC [dbo].[SP_THEM_DONGHO] @MADONGHO NVARCHAR(10), @TENDONGHO NVARCHAR(50), @GIA MONEY, @SOLUONGTON INT, @MOTA NTEXT, @HINHANH NVARCHAR(128), @MATRANGTHAI NVARCHAR(5), @MALOAI NVARCHAR(10), @MAHANG NVARCHAR(10), @MANHACUNGCAP NVARCHAR(10) AS
BEGIN
	INSERT INTO DongHo(MaDongHo, TenDongHo, Gia, SoLuongTon, MoTa, HinhAnh, MaTrangThai, MaLoai, MaHang, MaNhaCungCap)
	VALUES(@MADONGHO, @TENDONGHO, @GIA, @SOLUONGTON, @MOTA, @HINHANH, @MATRANGTHAI, @MALOAI, @MAHANG, @MANHACUNGCAP)
END

GO
CREATE PROC [dbo].[SP_THEM_NHANVIEN] @HO NVARCHAR(40), @TEN NVARCHAR(10), @GIOITINH NVARCHAR(3), @NGAYSINH DATE, @DIACHI NVARCHAR(128), @SDT NVARCHAR(10), @EMAIL NVARCHAR(128), @TAIKHOAN NVARCHAR(20)
AS
BEGIN
	IF EXISTS(SELECT TaiKhoan FROM TaiKhoan WHERE TaiKhoan = @TAIKHOAN)
		RAISERROR('Tài khoản đã tồn tại, hãy thử tài khoản khác', 16, 1);
	ELSE
	BEGIN
		BEGIN TRAN
			INSERT INTO TaiKhoan(TaiKhoan, MatKhau, Nhom)
			VALUES(@TAIKHOAN, '123456', 'nhanvien')
			INSERT INTO NhanVien(Ho, Ten, GioiTinh, NgaySinh, DiaChi, SDT, Email, TaiKhoan) OUTPUT inserted.MaNhanVien
			VALUES(@HO, @TEN, @GIOITINH, @NGAYSINH, @DIACHI, @SDT, @EMAIL, @TAIKHOAN)
		COMMIT TRAN
	END
END

GO
CREATE PROC [dbo].[SP_THEM_PHIEU_DAT]
@HoTenNN NVARCHAR(50),
@DiaChiNN NVARCHAR(128),
@SDTNN NVARCHAR(10),
@MaKhachHang INT
AS
BEGIN
	INSERT INTO PhieuDat (NgayDat, HoTenNN, DiaChiNN, SDTNN, NgayGioGiaoHang, TrangThai, MaKhachHang, MaNhanVien)
	OUTPUT inserted.MaPhieuDat
	VALUES (GETDATE(), @HoTenNN, @DiaChiNN, @SDTNN, NULL, 'DD', @MaKhachHang, 4)

END

GO
CREATE PROC [dbo].[SP_THEM_PHIEUNHAP] @MAPHIEUNHAP NVARCHAR(20), @MANHANVIEN INT AS
BEGIN
	INSERT PhieuNhap(MaPhieuNhap, NgayNhap, MaNhanVien)
	VALUES(@MAPHIEUNHAP, GETDATE(), @MANHANVIEN)
END

GO
CREATE PROC [dbo].[SP_TIM_KIEM_DH]
@MaLoai NVARCHAR(10),
@MaNhaCungCap NVARCHAR(10),
@MaHang NVARCHAR(10)
AS
BEGIN
SELECT MaDongHo, TenDongHo, Gia, SoLuongTon, MoTa, HinhAnh, 
		TrangThai = (SELECT TrangThai FROM TrangThai WHERE TrangThai.MaTrangThai = DongHo.MaTrangThai),
		Loai = (SELECT TenLoai FROM LoaiDongHo WHERE MaLoai = @MaLoai),
		Hang = (SELECT TenHang FROM HangDongHo WHERE MaHang = @MaHang),
		NhaCungCap = (SELECT TenNhaCungCap FROM NhaCungCap WHERE MaNhaCungCap = @MaNhaCungCap)
	FROM DongHo WHERE MaLoai = @MaLoai AND MaHang = @MaHang AND MaNhaCungCap = @MaNhaCungCap AND DongHo.MaTrangThai != 'NKD'
	ORDER BY TrangThai
END

GO
CREATE PROC [dbo].[SP_XOA_CT_DONDATHANG] @MADONDATHANG NVARCHAR(20), @MADONGHO NVARCHAR(10) AS
BEGIN
	DELETE CT_DonDatHang
	WHERE MaDonDatHang = @MADONDATHANG AND MaDongHo = @MADONGHO
END 

GO
CREATE PROC [dbo].[SP_XOA_CT_PHIEUNHAP] @MAPHIEUNHAP NVARCHAR(20), @MADONGHO NVARCHAR(10), @DONGIA MONEY, @SOLUONG INT AS
BEGIN
	IF (SELECT SoLuongTon FROM DongHo WHERE MaDongHo = @MADONGHO) - @SOLUONG < 0
		RAISERROR('Không thể xóa chi tiết phiếu nhập này do số lượng tồn sản phẩm trong kho không đủ', 16, 1);
	ELSE
		DELETE CT_PhieuNhap
		WHERE MaPhieuNhap = @MAPHIEUNHAP AND MaDongHo = @MADONGHO AND DonGia = @DONGIA
END

GO
CREATE PROC [dbo].[SP_XOA_DONDATHANG] @MADONDATHANG NVARCHAR(20) AS
BEGIN
	IF EXISTS(SELECT MaPhieuNhap FROM PhieuNhap WHERE MaPhieuNhap = @MADONDATHANG)
		RAISERROR('Không thể xóa đơn đặt hàng đã nhập hàng', 16, 1);
	ELSE
	BEGIN
		BEGIN TRAN
			DELETE CT_DonDatHang WHERE MaDonDatHang = @MADONDATHANG
			DELETE DonDatHang WHERE MaDonDatHang = @MADONDATHANG
		COMMIT TRAN
	END
END

GO
CREATE PROC [dbo].[SP_XOA_DONGHO] @MADONGHO NVARCHAR(10) AS
BEGIN
	IF
	EXISTS(SELECT MaPhieuNhap FROM CT_PhieuNhap WHERE MaDongHo = @MADONGHO) OR
	EXISTS(SELECT MaDonDatHang FROM CT_DonDatHang WHERE MaDongHo = @MADONGHO) OR
	EXISTS(SELECT MaDotKM FROM ApDungKM WHERE MaDongHo = @MADONGHO) OR
	EXISTS(SELECT MaDongHo FROM DoiGia WHERE MaDongHo = @MADONGHO) OR
	EXISTS(SELECT MaPhieuDat FROM CT_PhieuDat WHERE MaDongHo = @MADONGHO)
		RAISERROR('Đồng hồ đã được sử dụng nên không thể xóa.', 16, 1);
	ELSE
		DELETE DongHo
		WHERE MaDongHo = @MADONGHO
END

GO
CREATE PROC [dbo].[SP_XOA_PHIEUNHAP] @MAPHIEUNHAP NVARCHAR(20) AS
BEGIN
	DELETE PhieuNhap
	WHERE MaPhieuNhap = @MAPHIEUNHAP
END
/*
------------END OF STORE PROCEDURE SESSION------------
*/

/*
------------BEGIN OF VIEWS SESSION------------
*/
GO
CREATE VIEW [dbo].[V_GET_NHANVIEN] AS
SELECT *
FROM NhanVien

GO
CREATE VIEW [dbo].[V_GET_PHIEUNHAP] 
AS
SELECT MaPhieuNhap, NgayNhap, MaNhanVien
FROM PhieuNhap
/*
------------END OF VIEWS SESSION------------
*/

/*
------------BEGIN OF FUNCTION SESSION------------
*/
GO
CREATE FUNCTION [dbo].[FN_GET_BACKUP_HISTORY] ()
RETURNS TABLE
AS
RETURN
( 
	SELECT bs.database_name, BackupBatDau = bs.backup_start_date, BackupXong = bs.backup_finish_date, 
	Loai = IIF(bs.type = 'D', 'Full', IIF(bs.type = 'I', 'Differential', 'Transaction Log'))
	FROM msdb.dbo.backupset AS bs
	INNER JOIN msdb.dbo.backupmediafamily AS bm on bs.media_set_id = bm.media_set_id
	WHERE bs.database_name = 'BanDongHo'
)

GO
CREATE FUNCTION [dbo].[FN_GET_DONGHO_NCC](@MADONDATHANG NVARCHAR(20)) RETURNS TABLE AS
RETURN 
(
	SELECT MaDongHo, TenDongHo = MaDongHo + ' - ' + TenDongHo 
	FROM DongHo 
	WHERE 
		MaNhaCungCap = (SELECT MaNhaCungCap FROM DonDatHang WHERE MaDonDatHang = @MADONDATHANG) AND -- MÃ NCC GIỐNG VỚI CỦA ĐƠN ĐẶT HÀNG
		MaDongHo NOT IN (SELECT MaDongHo FROM CT_DonDatHang WHERE MaDonDatHang = @MADONDATHANG) -- LOẠI NHỮNG ĐỒNG HỒ ĐÃ CÓ TRONG CT ĐƠN ĐẶT KHÁC
);

GO
CREATE FUNCTION [dbo].[FN_GET_DONGHO_TRONG_DONDAT](@MADONDATHANG NVARCHAR(20)) RETURNS TABLE AS
RETURN
(
	SELECT CT_DonDatHang.MaDongHo, TenDongHo = DongHo.MaDongHo + ' - ' + DongHo.TenDongHo 
	FROM CT_DonDatHang
	INNER JOIN DongHo
	ON CT_DonDatHang.MaDongHo = DongHo.MaDongHo
	WHERE MaDonDatHang = @MADONDATHANG
)
/*
------------END OF FUNCTION SESSION------------
*/

/*
------------BEGIN OF TRIGGERS SESSION------------
*/
GO
CREATE TRIGGER [dbo].[DBO.TR_AfterUpdate_DongHo] ON [BanDongHo].[dbo].[DongHo] AFTER UPDATE
AS
BEGIN
	DECLARE @MaDongHo Nvarchar(10)
	IF(EXISTS (SELECT MaDongHo FROM inserted)) SET @MaDongHo = (SELECT MaDongHo FROM inserted) 
	IF(EXISTS (SELECT MaDongHo FROM deleted)) SET @MaDongHo = (SELECT MaDongHo FROM deleted) 

	IF(UPDATE(SoLuongTon))
	BEGIN
		IF ((SELECT SoLuongTon FROM DongHo WHERE MaDongHo = @MaDongHo) = 0)
		UPDATE DongHo SET MaTrangThai = 'THH' WHERE MaDongHo = @MaDongHo
		IF ((SELECT SoLuongTon FROM DongHo WHERE MaDongHo = @MaDongHo) > 0 AND 
		(SELECT MaTrangThai FROM DongHo WHERE MaDongHo = @MaDongHo) = 'THH')
		UPDATE DongHo SET MaTrangThai = 'CH' WHERE MaDongHo = @MaDongHo	
	END
END

GO
CREATE TRIGGER [dbo].[DBO.TR_AfterDelete_CTPN] ON [BanDongHo].[dbo].[CT_PhieuNhap] AFTER DELETE
AS
BEGIN
	UPDATE DongHo
		SET SoLuongTon = SoLuongTon - (SELECT SoLuong FROM deleted) 
		WHERE MaDongHo = (SELECT MaDongHo FROM deleted) 
END

GO
CREATE TRIGGER [dbo].[DBO.TR_AfterInsert_CTPN] ON [BanDongHo].[dbo].[CT_PhieuNhap] AFTER INSERT
AS
BEGIN
	UPDATE DongHo
		SET SoLuongTon = SoLuongTon + (SELECT SoLuong FROM inserted) 
		WHERE MaDongHo = (SELECT MaDongHo FROM inserted)
END

GO
CREATE TRIGGER [dbo].[DBO.TR_AfterUpdate_CTPN] ON [BanDongHo].[dbo].[CT_PhieuNhap] AFTER UPDATE
AS
BEGIN
	IF(UPDATE(SoLuong))
	BEGIN
		UPDATE DongHo
		SET SoLuongTon = SoLuongTon - (SELECT SoLuong FROM deleted) + (SELECT SoLuong FROM inserted)
		WHERE DongHo.MaDongHo = (SELECT MaDongHo FROM inserted) OR DongHo.MaDongHo = (SELECT MaDongHo FROM deleted)
	END
END

GO
CREATE TRIGGER [dbo].[DBO.TR_AfterInsert_CTPD] ON [BanDongHo].[dbo].[CT_PhieuDat] AFTER INSERT
AS
BEGIN
	UPDATE DongHo
		SET SoLuongTon = SoLuongTon - (SELECT SoLuong FROM inserted) 
		WHERE MaDongHo = (SELECT MaDongHo FROM inserted)
END
/*
------------END OF TRIGGERS SESSION------------
*/