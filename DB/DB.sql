CREATE DATABASE QLNV_OnCuoiKy
GO

USE QLNV_OnCuoiKy
GO

CREATE TABLE NhanVien(
	MaNV INT IDENTITY,
	TenNV NVARCHAR(50),
	Luong DECIMAL,
	MaPB INT,
	MaCV INT,

	PRIMARY KEY(MaNV)
)
GO

CREATE TABLE PhongBan(
	MaPB INT IDENTITY,
	PhongBan NVARCHAR(50),

	PRIMARY KEY(MaPB)
)
GO

CREATE TABLE ChucVu(
	MaCV INT IDENTITY,
	ChucVu NVARCHAR(50),

	PRIMARY KEY(MaCV)
)
GO

ALTER TABLE dbo.NhanVien ADD FOREIGN KEY(MaPB) REFERENCES dbo.PhongBan 
ALTER TABLE dbo.NhanVien ADD FOREIGN KEY(MaCV) REFERENCES dbo.ChucVu 

INSERT INTO dbo.ChucVu
        (  ChucVu )
VALUES  (
          N'Nhân viên'  -- ChucVu - nvarchar(50)
          )
INSERT INTO dbo.ChucVu
        ( ChucVu )
VALUES  ( 
          N'Chuyên viên'  -- ChucVu - nvarchar(50)
          )
INSERT INTO dbo.ChucVu
        (  ChucVu )
VALUES  ( 
          N'Phó phòng'  -- ChucVu - nvarchar(50)
          )
INSERT INTO dbo.ChucVu
        ( ChucVu )
VALUES  ( 
          N'Trưởng phòng'  -- ChucVu - nvarchar(50)
          )

INSERT INTO dbo.PhongBan
        (  PhongBan )
VALUES  ( 
          N'Phòng sản xuất'  -- PhongBan - nvarchar(50)
          )
INSERT INTO dbo.PhongBan
        ( PhongBan )
VALUES  ( 
          N'Phòng kinh doanh'  -- PhongBan - nvarchar(50)
          )
INSERT INTO dbo.PhongBan
        ( PhongBan )
VALUES  ( 
          N'Phòng kế toán'  -- PhongBan - nvarchar(50)
          )
INSERT INTO dbo.PhongBan
        (  PhongBan )
VALUES  ( 
          N'Phòng nhân sự'  -- PhongBan - nvarchar(50)
          )


INSERT INTO dbo.NhanVien
        ( TenNV, Luong, MaPB, MaCV )
VALUES  ( 
          N'Trần B', -- TenNV - nvarchar(50)
          8000000, -- Luong - decimal
          2,
		  1
          )

INSERT INTO dbo.NhanVien
        ( TenNV, Luong, MaPB, MaCV )
VALUES  ( 
          N'Phạm T', -- TenNV - nvarchar(50)
          8000000, -- Luong - decimal
		  1, 3
          )

INSERT INTO dbo.NhanVien
        ( TenNV, Luong, MaPB, MaCV )
VALUES  ( 
          N'Nguyễn C', -- TenNV - nvarchar(50)
          5900000, -- Luong - decimal
			3, 2
          )
		  SELECT * FROM dbo.NhanVien
		  SELECT MaNV, TenNV,PhongBan,ChucVu,Luong FROM dbo.PhongBan,dbo.NhanVien,dbo.ChucVu
		  WHERE ChucVu.MaCV = NhanVien.MaCV
		  AND PhongBan.MaPB = NhanVien.MaPB

		  
		  SELECT * FROM dbo.PhongBan

		  UPDATE dbo.NhanVien SET TenNV= N'fsdgfd', MaPB=5 WHERE MaNV=1

		  SELECT MaNV, TenNV,PhongBan,ChucVu,Luong FROM dbo.PhongBan,dbo.NhanVien,dbo.ChucVu
		  WHERE ChucVu.MaCV = NhanVien.MaCV
		  AND PhongBan.MaPB = NhanVien.MaPB
		  AND TenNV LIKE N'%ph%'