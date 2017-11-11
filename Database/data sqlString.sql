﻿USE [master]
go
if exists(select name from sysdatabases where name='QUANLYSINHVIEN')
	drop Database QUANLYSINHVIEN
go

Create database QUANLYSINHVIEN
GO
USE QUANLYSINHVIEN

GO

CREATE TABLE KHOA(
	MAKHOA VARCHAR(20) PRIMARY KEY NOT NULL,
	TENKHOA NVARCHAR(50) NOT NULL,
	NAMTHANHLAP DATE,
	DIENTHOAI VARCHAR(20)
)
GO

CREATE TABLE LOP(
	MALOP VARCHAR(20) PRIMARY KEY NOT NULL,
	TENLOP NVARCHAR(50) NOT NULL,
	HEDAOTAO NVARCHAR(30),
	NAMNHAPHOC INT,
	MAKHOA VARCHAR(20),
	CONSTRAINT FK_LOP_KHOA_MAKHOA FOREIGN KEY(MAKHOA) REFERENCES KHOA(MAKHOA),	
)
GO

CREATE table SINHVIEN(
	MASINHVIEN VARCHAR(20) PRIMARY KEY  NOT NULL,
	HODEM NVARCHAR(50),
	TENSINHVIEN NVARCHAR(30) NOT NULL,
	NGAYSINH DATETIME DEFAULT(GETDATE()),
	GIOITINH BIT DEFAULT (0),
	NOISINH NVARCHAR(100),
	IMAGES IMAGE,	
	ID VARCHAR(20)UNIQUE NOT NULL,
	MALOP VARCHAR(20),
	CONSTRAINT FK_SINHVIEN_LOP_MALOP FOREIGN KEY(MALOP) REFERENCES LOP(MALOP)
)

GO
CREATE TABLE GIANGVIEN(

	MAGIANGVIEN VARCHAR(20) PRIMARY KEY NOT NULL,
	HODEM NVARCHAR(50),
	TEN NVARCHAR(30) NOT NULL,
	DIACHI NVARCHAR(100),
	SODIENTHOAI VARCHAR(15),
	NGAYSINH DATETIME DEFAULT (GETDATE()),
	EMAIL VARCHAR(30),
	PASSWORD_USER VARCHAR(100),
	MAKHOA VARCHAR(20),
	TYPE_USER BIT DEFAULT (0)
	CONSTRAINT GIANGVIEN_KHOA_MAGIANGVIEN FOREIGN KEY(MAKHOA) REFERENCES KHOA(MAKHOA)
)
GO
CREATE TABLE HOCPHAN(
	MAHOCPHAN VARCHAR(20) PRIMARY KEY NOT NULL,
	TENHOCPHAN NVARCHAR(100) NOT NULL,
	SOTINCHI INT DEFAULT (0),
	MAKHOA VARCHAR(20),
	CONSTRAINT FK_HOCPHAN_KHOA_MAKHOA FOREIGN KEY(MAKHOA) REFERENCES KHOA(MAKHOA)
)
GO
CREATE TABLE NHOM(
	MANHOM VARCHAR(20) PRIMARY KEY NOT NULL,
	TENNHOM NVARCHAR(100) NOT NULL,
	MAGIANGVIEN VARCHAR(20),
	MAHOCPHAN VARCHAR(20),
	SOBUOIHOC INT DEFAULT(0),
	CHECKDIEMDANH int DEFAULT (0),
	CONSTRAINT FK_NHOM_GIANGVIEN_MAGIANGVIEN FOREIGN KEY(MAGIANGVIEN) REFERENCES GIANGVIEN(MAGIANGVIEN),
	CONSTRAINT FK_NHOM_HOCPHAN_MAHOCPHAN FOREIGN KEY(MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN)
)

GO

CREATE TABLE DIEMDANH(
	MASINHVIEN VARCHAR(20) NOT NULL,
	MANHOM VARCHAR(20) NOT NULL,
	LANHOC INT NOT NULL,
	HOCKY VARCHAR(20) ,--defualt: lay nam hien tai
	TUAN_1 NVARCHAR(150) DEFAULT(NULL),
	TUAN_2 NVARCHAR(150) DEFAULT(NULL),
	TUAN_3 NVARCHAR(150) DEFAULT(NULL),
	TUAN_4 NVARCHAR(150) DEFAULT(NULL),
	TUAN_5 NVARCHAR(150) DEFAULT(NULL),
	TUAN_6 NVARCHAR(150) DEFAULT(NULL),
	TUAN_7 NVARCHAR(150) DEFAULT(NULL),
	TUAN_8 NVARCHAR(150) DEFAULT(NULL),
	TUAN_9 NVARCHAR(150) DEFAULT(NULL),
	TUAN_10 NVARCHAR(150) DEFAULT(NULL),
	TUAN_11 NVARCHAR(150) DEFAULT(NULL),
	TUAN_12 NVARCHAR(150) DEFAULT(NULL),
	TUAN_13 NVARCHAR(150) DEFAULT(NULL),
	TUAN_14 NVARCHAR(150) DEFAULT(NULL),
	TUAN_15 NVARCHAR(150) DEFAULT(NULL),
	TUAN_16 NVARCHAR(150) DEFAULT(NULL),
	TUAN_17 NVARCHAR(150) DEFAULT(NULL),
	SOBUOIHOC INT DEFAULT(0),
	SOBUOIPHEP INT DEFAULT(0),
	CONSTRAINT FK_DIEMDANH_SINHVIEN_ID FOREIGN KEY (MASINHVIEN) REFERENCES SINHVIEN(MASINHVIEN),
	CONSTRAINT FK_DIEMDANH_NHOM_MANHOM FOREIGN KEY (MANHOM) REFERENCES NHOM(MANHOM),
	PRIMARY KEY(MASINHVIEN, MANHOM, LANHOC),
)
GO

GO
CREATE TABLE TEMPDIEMDANH(
	MASINHVIEN VARCHAR(20),
	MANHOM VARCHAR(20),
	TG_VAO NVARCHAR (50),
	TG_RA  NVARCHAR (50),
	GHICHU NVARCHAR(255),
	PRIMARY KEY(MASINHVIEN, MANHOM),
	CONSTRAINT FK_TEMPDIEMDANH_HOCPHAN_ID FOREIGN KEY(MASINHVIEN) REFERENCES SINHVIEN(MASINHVIEN),	
)

/*******************************************
* NHAP DU LIEU CHO BANG KHOA
 *******************************************/--

 SET DATEFORMAT DMY
 GO
 Insert into KHOA(MAKHOA,TENKHOA, NAMTHANHLAP, DIENTHOAI)
	values('CNTT',N'Công Nghệ Thông Tin', '1/1/2008','0511789789')
Insert into KHOA(MAKHOA,TENKHOA, NAMTHANHLAP, DIENTHOAI)
	values('TKDH',N'Đồ Họa','20/10/2008','0511123123')
Insert into KHOA(MAKHOA,TENKHOA, NAMTHANHLAP, DIENTHOAI)
	values('CB',N'Cơ Bản', '20/11/2008','0511456456')
Insert into KHOA(MAKHOA,TENKHOA, NAMTHANHLAP, DIENTHOAI)
	values('DTVT',N'Điện Tử Viễn Thông','3/7/2009','0511369369')

GO

/*******************************************
 * NHAP DU LIEU BANG LOP
 * MALOP VARCHAR(20) PRIMARY KEY NOT NULL,
	TENLOP NVARCHAR(50) NOT NULL,
	KHOAHOC INT CHECK(KHOAHOC >0),
	HEDAOTAO NVARCHAR(30),
	NAMNHAPHOC INT,
	MAKHOA VARCHAR(20),
 *******************************************/
 Insert into LOP(MALOP, TENLOP,HEDAOTAO,NAMNHAPHOC,MAKHOA)
 VALUES('CCCT15A',N'Công Nghệ Thông Tin 2015 A',N'Cao Đẳng','2015','CNTT')
  Insert into LOP(MALOP, TENLOP,HEDAOTAO,NAMNHAPHOC,MAKHOA)
 VALUES('CCCT15B',N'Công Nghệ Thông Tin 2015 B',N'Cao Đẳng','2015','CNTT')
  Insert into LOP(MALOP, TENLOP,HEDAOTAO,NAMNHAPHOC,MAKHOA)
 VALUES('CDH15',N'Đồ Họa 2015',N'Cao Đẳng','2015','TKDH')
  Insert into LOP(MALOP, TENLOP,HEDAOTAO,NAMNHAPHOC,MAKHOA)
 VALUES('CVT16',N'Công Nghệ Điện Tử Viễn Thông 2016',N'Cao Đẳng','2016','DTVT')

/*******************************************
 * NHAP DU LIEU BANG SINH VIEN 4BBB576CCB  4FED556C9F
 *******************************************/
 SET DATEFORMAT DMY
GO
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CCCT15B001',N'Nguyễn Thị',N'Hải','23/02/1990','0',N'Hà Nội',NULL,'26338D58C','CCCT15B')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CCCT15A005',N'Trần Văn',N'Chính','24/12/1992','1',N'Bình Định',NULL,'4BBB576CCB','CCCT15A')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CDH150044',N'Lê Thu Bạch',N'Yến','21/02/1990','0',N'TP Hồ Chí Minh',NULL,'9DA238D5D22','CDH15')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CDH15009',N'Trần Anh',N'Tuấn','20/12/1990','1',N'Hà Nội',NULL,'9DA238D5D4','CDH15')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CVT16003',N'Trần Thanh',N'Mai','12/08/1991','0',N'Hải Phòng',NULL,'668FFA3023','CVT16')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CVT16015',N'Trần Thị Thu',N'Thủy','02/01/1991','0',N'TP Hồ Chí Minh',NULL,'668FFA3028','CVT16')
	Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CCCT15B009',N'Lê Văn',N'Hòa','21/07/1990','1',N'Quảng Ngãi',NULL,'26338D59C','CCCT15B')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CCCT15A020',N'Trần Ngọc',N'Diệp','2/12/1994','0',N'Phú Yên',NULL,'4BBB576CCBB','CCCT15A')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CDH15014',N'Lê Hồng',N'Đức','2/12/1993','1',N'TP Hồ Chí Minh',NULL,'9DA238D5k2','CDH15')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CDH15017',N'Trần Việt',N'Hùng','20/1/1992','1',N'Đà Nẵng',NULL,'9DA238T5D4','CDH15')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CVT16007',N'Trần Thanh',N'Hùng','12/03/1995','1',N'Quảng Trị',NULL,'668FFA3053','CVT16')
Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
	values('CVT16012',N'Nguyễn Nhật',N'Cường','02/02/1992','1',N'TP Hồ Chí Minh',NULL,'668FFS3028','CVT16')
	Insert into SINHVIEN(MASINHVIEN,HODEM,TENSINHVIEN,NGAYSINH,GIOITINH,NOISINH,IMAGES,ID,MALOP)
values('CCCT15004',N'Lê Thu Bạch',N'Yến','21/02/1990','0',N'TP Hồ Chí Minh',NULL,'9DA238D5D2','CCCT15B')

	
GO
/*******************************************
 * nhap du lieu bang giang vien
 *******************************************/
  SET DATEFORMAT DMY
  GO
  
  Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2015IT',N'Lê Việt',N'Hà',N'Đà Nẵng','01693148839','20/10/1970','halv@gmail.com','d41d8cd98f00b204e9800998ecf8427e','CNTT','1')
   Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2006VT',N'Tạ Quang',N'Đạt',N'Quảng Ngãi','0914785821','10/02/1979','dattq@gmail.com','e10adc3949ba59abbe56e057f20f883e','DTVT','0')
  Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2074DH',N'Nguyễn Thị',N'Bình',N'Thanh Hóa','0964585358','8/8/1985','binhnt@gmail.com','e10adc3949ba59abbe56e057f20f883e','TKDH','0')
  Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2016CB',N'Võ Huy',N'Toàn',N'Bình Định','0121236589','2/1/1978','toanvh@gmail.com','e10adc3949ba59abbe56e057f20f883e','CB','0')
  
   Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2010IT',N'Đặng Văn',N'Hùng',N'Huế','097852369','15/12/1977','hungdv@gmail.com','e10adc3949ba59abbe56e057f20f883e','CNTT','0')  
   Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV26VT',N'Phạm Bình',N'Minh',N'Đồng Nai','016969689','22/12/1971','minhpb@gmail.com','e10adc3949ba59abbe56e057f20f883e','DTVT','0')
  Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV24DH',N'Lê Quốc',N'Bảo',N'Nghệ An','0964582478','18/5/1990','baolq@gmail.com','e10adc3949ba59abbe56e057f20f883e','TKDH','0')
  Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2015CB',N'Lương Cao',N'Công',N'Hà Nội','09878542','21/11/1988','conglc@gmail.com','e10adc3949ba59abbe56e057f20f883e','CB','0')
 

 Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2017IT',N'Đỗ Nam',N'Trung',N'Cao Bằng','078787853','15/12/1971','trungdn@gmail.com','e10adc3949ba59abbe56e057f20f883e','CNTT','0')  
  GO
    Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2017DH',N'Trần Đình',N'Trọng',N'Bình Định','0168878957','18/5/1990','trongtd@gmail.com','e10adc3949ba59abbe56e057f20f883e','TKDH','0')
     Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2017VT',N'Chế Công',N'Bình',N'Bình Thuận','01227963962','22/12/1971','binhcc@gmail.com','e10adc3949ba59abbe56e057f20f883e','DTVT','0')
    Insert into GIANGVIEN(MAGIANGVIEN,HODEM,TEN,DIACHI,SODIENTHOAI,NGAYSINH,EMAIL,PASSWORD_USER,MAKHOA,TYPE_USER)
  VALUES('GV2017CB',N'Lê Kim',N'Long',N'Quảng Bình','01678456123','21/11/1981','longlk@gmail.com','e10adc3949ba59abbe56e057f20f883e','CB','0')

  /*******************************************
   *  Nhap du lieu bang hoc phần
   *******************************************/
   
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('CSDL',N'Cơ Sở Dữ Liệu',3)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TTNT',N'Trí Tuệ Nhân Tạo',3)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TT',N'Truyền Tin',3)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('PHP',N'Lập Trình PHP',4)

Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('DH',N'Đồ Họa',4)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('XLA',N'Xữ lý ảnh',4)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('DP3D',N'Kỹ Thuật Dựng Phim',4)	
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('GIAIPHAU',N'Giải Phẩu',3)

Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TKVM',N'Thiết kế vi mạch',4)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('CNN',N'Công nghệ Nhúng',3)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('NMDT',N'Nhập Môn Điện Tử',4)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TBNV',N'Thiết Bị Ngoại Vi',3)

Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TA3',N'Tiếng Anh 3',3)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TA2',N'Tiếng Anh 2',3)
Insert into HOCPHAN(MAHOCPHAN,TENHOCPHAN,SOTINCHI)
	values('TCC1',N'Toán Cao Cấp 1',3)
	GO

	/*
	MANHOM VARCHAR(20) PRIMARY KEY NOT NULL,
	TENNHOM NVARCHAR(100) NOT NULL,
	MAGIANGVIEN VARCHAR(20),
	MAHOCPHAN VARCHAR(20),
	SOBUOIHOC INT DEFAULT(0),
	CHECKDIEMDANH int DEFAULT (0),
	
	*/

-- LT
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('CSDL1',N'Nhóm 1','GV2015IT', 'CSDL',0, 0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('CSDL2',N'Nhóm 2','GV2015IT', 'CSDL',0, 0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TTNT1',N'Nhóm 1','GV2010IT', 'TTNT',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TTNT2',N'Nhóm 2','GV2010IT', 'TTNT',0,0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TT1',N'Nhóm 1','GV2017IT', 'TT',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TT2',N'Nhóm 2','GV2017IT', 'TT',0,0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('PHP1',N'Nhóm 2','GV2010IT', 'PHP',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('PHP2',N'Nhóm 1','GV2015IT', 'PHP',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('PHP3',N'Nhóm 2','GV2017IT', 'PHP',0,0)

-- DH
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('DH1',N'Nhóm 1','GV2074DH', 'DH',0, 0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('DH2',N'Nhóm 2','GV2074DH', 'DH',0, 0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('XLA1',N'Nhóm 1','GV24DH', 'XLA',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('XLA2',N'Nhóm 2','GV24DH', 'XLA',0,0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('DP3D1',N'Nhóm 1','GV2017DH', 'DP3D',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('DP3D2',N'Nhóm 2','GV2017DH', 'DP3D',0,0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('GIAIPHAU1',N'Nhóm 2','GV2074DH', 'GIAIPHAU',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('GIAIPHAU2',N'Nhóm 1','GV24DH', 'GIAIPHAU',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('GIAIPHAU3',N'Nhóm 3','GV2017IT', 'GIAIPHAU',0,0)

-- DTVT
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TKVM1',N'Nhóm 1','GV26VT', 'TKVM',0, 0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TKVM2',N'Nhóm 2','GV26VT', 'TKVM',0, 0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('CNN1',N'Nhóm 1','GV2017VT', 'CNN',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('CNN2',N'Nhóm 2','GV2017VT', 'CNN',0,0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('NMDT1',N'Nhóm 1','GV2006VT', 'NMDT',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('NMDT2',N'Nhóm 2','GV2006VT', 'NMDT',0,0)

Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TBNV1',N'Nhóm 2','GV26VT', 'TBNV',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TBNV2',N'Nhóm 1','GV2017VT', 'TBNV',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TBNV3',N'Nhóm 3','GV2006VT', 'TBNV',0,0)


Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TA31',N'Nhóm 1','GV2016CB', 'TA3',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TA21',N'Nhóm 1','GV2017CB', 'TA2',0,0)
Insert into NHOM(MANHOM,TENNHOM,MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH)
	values('TCC11',N'Nhóm 1','GV2015CB', 'TCC1',0,0)


	/*******************************************
	 * CAC THU TUC DUNG TRONG PHAN MEM
	*******************************************/
	  
/*******************************************
 * Proc Login
 *******************************************/	  
Create procedure UserLogin(@Usename Varchar (30),@password varchar (100))
as
	Begin
		Select COUNT(*)from GIANGVIEN where MAGIANGVIEN=@Usename and PASSWORD_USER=@password
	END
	
GO

--EXEC UserLogin GV2015IT, 123456


/*******************************************
 *  Proc get Sinhvien By ID     1 -------------
 *******************************************/
 Create procedure _proc_GetSinhVienByMASINHVIEN(@MASINHVIEN Varchar (30))
 AS
	BEGIN
 		SELECT
		MASINHVIEN,
		HODEM,
		TENSINHVIEN,
		NGAYSINH,
		[GIOITINH1]=
		case GIOITINH when 'true' then N'Nam'
		when 'false' then N'Nữ'
		end
		,NOISINH,
		IMAGES,
		ID,
		MALOP
	FROM
		SINHVIEN  where MASINHVIEN = @MASINHVIEN
	END
	
GO
/*
Lấy tên lớp qua mã lớp
*/
CREATE PROC getTenlopByMalop(@malop varchar(50))
as
BEGIN
SELECT TENLOP FROM LOP WHERE MALOP=@malop
end
go

/*
Lay ma the chuyn qua ma sinh vien
*/

CREATE PROC _proc_GetSinhVienByIDTHE(@ID VARCHAR(30))
AS
BEGIN
	SELECT
		MASINHVIEN,
		HODEM,
		TENSINHVIEN,
		NGAYSINH,
		[GIOITINH] as GIOITINH1,
		NOISINH,
		IMAGES,
		ID,
		MALOP
	FROM
		SINHVIEN  where ID = @ID
END
GO

/*******************************************
 * PROC CHECK TINH HOP LE CUA SINH VIEN  1
 *******************************************/
CREATE PROC CheckIsStudentByMASINHVIEN_MaHocPhan(@MASINHVIEN VARCHAR(30), @mhp VARCHAR(30))
AS
	BEGIN
		select count(*) from DIEMDANH where MASINHVIEN =@MASINHVIEN AND MAHOCPHAN = @mhp
	END
	GO
	
	/*******************************************
	 * PROC LAY DANH SACH BANG TEMPDIEMDANH BOI ID VA HOC PHAN 1
	 *******************************************/
CREATE PROC getListTempDiemDanhByMASINHVIEN_MaHocPhan(@MASINHVIEN VARCHAR(30), @mhp VARCHAR(30))
AS
	BEGIN
		SELECT MASINHVIEN, MAHOCPHAN,TG_VAO,TG_RA,GHICHU
	  FROM TEMPDIEMDANH where MASINHVIEN =@MASINHVIEN AND MAHOCPHAN = @mhp
	END
	GO
	/*******************************************
	 * PROC LAY DANH SACH NHOM HOC PHAN THEO ID GIANG VIEN
	 *******************************************/
	CREATE PROC getListNhomHocPhanByIDGiangVien(@IDGV VARCHAR(20))
	AS
	BEGIN
		select MAHOCPHAN,
		TENHOCPHAN,
		SOTINCHI,
		MANHOM,
		TENNHOM,

		MAGIANGVIEN from HocPhan where MaGiangVien=@IDGV
	END
	
GO


--Select *from TEMPDIEMDANH WHERE MAHOCPHAN='" + MaHocPhan + "'";

/*******************************************
 * PROC LAY DANH SACH TEMDIEMDANH BOI MAHOCPHAN
 *******************************************/


CREATE PROC getListTempDiemDanhByMaHocPhan(@mhp VARCHAR(30))
AS
BEGIN
	SELECT  dbo.SINHVIEN.MASINHVIEN, dbo.SINHVIEN.HODEM, dbo.SINHVIEN.TENSINHVIEN,  MAHOCPHAN, TG_VAO, TG_RA, GHICHU
  FROM dbo.TEMPDIEMDANH INNER JOIN dbo.SINHVIEN ON dbo.SINHVIEN.MASINHVIEN = dbo.TEMPDIEMDANH.MASINHVIEN WHERE MAHOCPHAN=@mhp
	/*
	 SELECT ID, MAHOCPHAN,TG_VAO,TG_RA,GHICHU
	  FROM TEMPDIEMDANH WHERE MAHOCPHAN=@mhp
	  */
END
GO
--EXEC getListTempDiemDanhByMaHocPhan cnn
/*******************************************
 * PROC LAY DANH SACH DIEMDANH BOI HOC PHAN
 *******************************************/




CREATE PROC getListDiemDanhByMaHocPhan(@mahp VARCHAR(30))
AS
BEGIN
	SELECT  DIEMDANH.MASINHVIEN, HODEM, TENSINHVIEN, MAHOCPHAN, LANHOC, HOCKY,DIEMDANH.SOBUOIHOC, DIEMDANH.SOBUOIPHEP, TUAN_1, TUAN_2, TUAN_3, TUAN_4,TUAN_5, TUAN_6, TUAN_7, TUAN_8,TUAN_9,TUAN_10,
	TUAN_11, TUAN_12, TUAN_13, TUAN_14,TUAN_15, TUAN_16, TUAN_17 FROM DIEMDANH INNER JOIN SINHVIEN ON SINHVIEN.MASINHVIEN = DIEMDANH.MASINHVIEN
	   where MAHOCPHAN = @mahp
END
--EXEC getListDiemDanhByMaHocPhan ......
GO


/*******************************************
 * lay row co id va maph tuong ung; --------
 *******************************************/
 CREATE PROC getListDIEMDANHByMASINHVIENMaHocPhan(@MASV VARCHAR(30), @ma VARCHAR(30))
AS
BEGIN
	SELECT MASINHVIEN, MANHOM, LANHOC, HOCKY,TUAN_1, TUAN_2, TUAN_3, TUAN_4,TUAN_5, TUAN_6, TUAN_7, TUAN_8,TUAN_9,TUAN_10,
	TUAN_11, TUAN_12, TUAN_13, TUAN_14,TUAN_15, TUAN_16, TUAN_17, SOBUOIHOC, SOBUOIPHEP
	 FROM DIEMDANH WHERE MASINHVIEN = @MASV AND MANHOM = @ma
END
/*******************************************
 * PROC UPDATE DU LIEU VAP TEMDIEMDANH VOI ID, MAHOCPHAN, GHICHU
 *******************************************/
 GO
CREATE PROC insertDataIntoTempDiemDanh(@MASV VARCHAR(30), @mmh VARCHAR(30), @ghichu NVARCHAR(255))
AS
BEGIN
	insert into TEMPDIEMDANH(MASINHVIEN,MaHocPhan,GHICHU) values(@MASV, @mmh, @ghichu)
	
END

--EXEC insertDataIntoTempDiemDanh ..., ..., ...
/*******************************************
 * PROC UPDATE TEMPDIEMDANH VOI THOI GIAN RA
 *******************************************/
GO
CREATE PROC updateTimeStopByMASINHVIEN(@MASV VARCHAR(30),@tg_ra VARCHAR(30))
AS
BEGIN
	update TEMPDIEMDANH
	SET TG_RA = @tg_ra
	where MASINHVIEN=@MASV
END
GO
-- Exec updateTimeStopByID ---, ---
/*******************************************
 * UPDATE VAO TEMDIEMDANH VOI ID, MAHOCPHAN,TG_VAO 1
 *******************************************/

CREATE PROC insertDataIntoTempDiemDanh_TG_VAO(@MASINHVIEN VARCHAR(30), @mmh VARCHAR(30), @tg_vao VARCHAR(30))
AS
BEGIN
	insert into TEMPDIEMDANH(MASINHVIEN,MaHocPhan,TG_VAO) values(@MASINHVIEN, @mmh, @tg_vao)	
END
GO
--EXEC insertDataIntoTempDiemDanh_TG_VAO

/*******************************************
 * LAY THONG TIN GIANG VIEN BOI ID ----------
 *******************************************/
CREATE PROC getGiangVienByID(@ID VARCHAR(30))
AS
BEGIN
	SELECT MAGIANGVIEN,
		HODEM,
		TEN,
		DIACHI,
		SODIENTHOAI,
		NGAYSINH,
		EMAIL[Email],
		PASSWORD_USER,
		MAKHOA,
		TYPE_USER FROM GIANGVIEN WHERE MaGiangVien =@ID
END
GO
--EXEC getGiangVienByID 'GV1415CB'

/*******************************************
 * LAY HOC PHAN BOI MAHOCPHAN
 *******************************************/

CREATE PROC getHocPhanByID( @id VARCHAR(30))
AS
BEGIN
	SELECT  MAHOCPHAN,
		TENHOCPHAN,
		SOTINCHI,
		MAGIANGVIEN FROM HOCPHAN WHERE MAHOCPHAN = @id
END

---EXEC getHocPhanByID 
GO
--EXEC getGiangVienByID 'GV1415CB'

/*******************************************
 * LAY THONG TIN HOC PHAN BOI MAHOCPHAN
 *******************************************/

create PROC getInfoHocPhanByMaHP( @MaHP VARCHAR(30))
AS
BEGIN
	SELECT TENHOCPHAN + ' ('+ HOCPHAN.MAHOCPHAN+')' as HOCPHAN,
		SOTINCHI,
		HODEM+' '+ TEN +' ('+HOCPHAN.MAGIANGVIEN+')' AS HOTEN 
		FROM HOCPHAN INNER JOIN GIANGVIEN ON HOCPHAN.MAGIANGVIEN = GIANGVIEN.MAGIANGVIEN WHERE HOCPHAN.MAHOCPHAN = @MaHP
END

GO
--EXEC getInfoHocPhanByMaHP 'TT'
/*******************************************
 * LAY DU LIEU TEMDIEMDANH --------------
 *******************************************/
create PROC getTableTemDiemDanh
AS
BEGIN
	SELECT MASINHVIEN AS [Mã Sinh Viên], MANHOM As [Mã Học Phần],TG_VAO as [Thời Gian Vào],TG_RA as [Thời Gian Ra],GHICHU as [Ghi Chú]
	  FROM TEMPDIEMDANH
END
GO

--EXEC getTableTemDiemDanh

/*******************************************
 * LAY DU LIEU DIEM DANH =----------------
 *******************************************/
CREATE PROC getTableDiemDanh
AS
BEGIN
	SELECT MASINHVIEN AS [Mã Sinh Viên], MANHOM as [Mã Học Phần], LANHOC as [Lần Học], HOCKY as [Học Kỳ], SOBUOIHOC as [Số Buổi Học], SOBUOIPHEP as [Số Buổi Phép], TUAN_1 as [Tuần 1], TUAN_2 as [Tuần 2], TUAN_3 as [Tuần 3], TUAN_4 as [Tuần 4],TUAN_5 as [Tuần 5], TUAN_6 as [Tuần 6], TUAN_7 as [Tuần 7], TUAN_8 as [Tuần 8],TUAN_9 as [Tuần 9],TUAN_10 as [Tuần 10],
	TUAN_11 as [Tuần 11], TUAN_12 as [Tuần 12], TUAN_13 as [Tuần 13], TUAN_14 as [Tuần 14],TUAN_15 as [Tuần 15], TUAN_16 as [Tuần 16], TUAN_17 as [Tuần 17]
	  FROM DIEMDANH
END
GO
--Exec getTableDiemDanh
/*******************************************
 * LAY DU LIEU SINH VIEN -------------
 *******************************************/
CREATE PROC getTableSinhVien
AS
BEGIN
	SELECT
		MASINHVIEN as [Mã Sinh Viên],
		HODEM as [Họ Đệm],
		TENSINHVIEN as [Tên Sinh Viên],
		NGAYSINH as [Ngày Sinh],
		GIOITINH as [Giới Tính],
		NOISINH AS [Ngày Sinh],
		IMAGES as [Ảnh Thẻ],
		ID as [ID Thẻ],
		MALOP as [Mã Lớp]
	FROM
		SINHVIEN
END
GO


/*******************************************
 * GetTableSinhVienToExport
 *******************************************/
 
 CREATE PROC GetTableSinhVienToExport
AS
BEGIN
	SELECT
		ID,
		MASINHVIEN,
		HODEM,
		TENSINHVIEN,
		NGAYSINH,
		GIOITINH,
		NOISINH,
		MALOP
	FROM
		SINHVIEN
END
GO
--EXEC getTableSinhVien

/*******************************************
 * LAY DU LIEU HOCPHAN
 *******************************************/

CREATE PROC getTableSinhHocPhan
AS
BEGIN
	SELECT
		MAHOCPHAN AS [Mã Học Phần],
		TENHOCPHAN as [Tên Học Phần],
		SOTINCHI as [Số Tín Chỉ]
	FROM
		HOCPHAN
END
GO
--EXEC getTableSinhHocPhan

/*******************************************
 * LAY DU LIEU GIANGVIEN ------------
 *******************************************/
CREATE PROC getTableSinhGiangVien
AS
BEGIN
	SELECT
		MAGIANGVIEN as [Mã Giảng Viên],
		HODEM as [Họ Đệm],
		TEN as [Tên],
		DIACHI as [Địa Chỉ],
		SODIENTHOAI as [Số ĐT],
		NGAYSINH as [Ngày Sinh],
		EMAIL as email,
		PASSWORD_USER as [Mật Khẩu],
		MAKHOA as [Mã Khoa],
		TYPE_USER as [Kiểu Tài Khoản]
	FROM
		GIANGVIEN
END
GO
--EXEC getTableSinhGiangVien

/*******************************************
 * LAY DU LIEU TRANG THAI TUAN HOC
 *******************************************/
CREATE PROC getTableTrangThaiTuanHoc
AS
BEGIN
	SELECT
		MAHOCPHAN AS[Mã Học Phần],
		SOBUOIHOC As [Số Buổi Học], 
		CHECKDIEMDANH [Tình trạng Điểm Danh]
	FROM
		TRANGTHAITUANHOC
END

GO
--EXEC getTableTrangThaiTuanHoc

/*******************************************
 * LAY DU LIEU KHOA -------------
 *******************************************/
CREATE PROC getTableKhoa
AS
BEGIN	
	SELECT
		MAKHOA AS [Mã Khoa],
		TENKHOA as [Tên Khoa],
		NAMTHANHLAP [Năm Thành Lập],
		DIENTHOAI [Số Điện Thoại]
	FROM
		KHOA
END
--EXEC getTableKhoa

 --EXEC getTableKhoa

GO
/*******************************************
 * LAY DU LIEU LOP -------------------
 *******************************************/
CREATE PROC getTableLop
AS
BEGIN
	SELECT
		MALOP as [Mã Lớp],
		TENLOP as [Tên Lớp],
		HEDAOTAO as [Hệ Đào Tạo],
		NAMNHAPHOC as [Năm Nhập Học],
		MAKHOA as [Mã Khoa]
	FROM
		LOP
END
GO
--EXEC getTableLop

/*******************************************
 * Insert sinh vien khong mang card vao bang tam
 *******************************************/
 
 create PROC insertDataIntoTempDiemDanh_NoCard(@MASINHVIEN VARCHAR(25), @mahp VARCHAR(25))
 AS
 BEGIN
 	INSERT INTO TEMPDIEMDANH
 	(
 		MASINHVIEN,
 		MAHOCPHAN,
 		TG_VAO,
 		TG_RA
 	)
 	VALUES
 	(
 		@MASINHVIEN, @mahp, N'Quên Thẻ',  N'Quên Thẻ'
 	)
 END

 GO
 
 /*******************************************
  * Get trang thai tuan hoc by ma hoc phan
  *******************************************/
  CREATE PROC getTrangThaiTuanHocByMaHocPhan(@mahp VARCHAR(30))
  AS
  BEGIN
  	SELECT * FROM TRANGTHAITUANHOC WHERE MAHOCPHAN = @mahp
  END
  
  GO
  /*******************************************
   * Cap Nhat trangthai tuan hoc
   *******************************************/
   CREATE PROC UpdateTrangThaiTuanHoc(@Mahp VARCHAR(30), @trangthai INT)
   AS
   BEGIN
   	UPDATE TRANGTHAITUANHOC
   	SET
   		SOBUOIHOC = @trangthai
   	WHERE MAHOCPHAN = @Mahp
   END
   GO
   
   /*******************************************
    * Cap Nhat checkDiemDanh
    *******************************************/
   CREATE PROC UpdateTrangThaiCheckDiemDanh(@Mahp VARCHAR(30))
   AS
   BEGIN
   	UPDATE TRANGTHAITUANHOC
   	SET
   		CHECKDIEMDANH = 1
   	WHERE MAHOCPHAN = @Mahp
   END
   GO
   /*******************************************
    * Xoa Dòng dữ liệu với id và mã học phần tương ứng
    *******************************************/
    CREATE PROC DeleteItemFromTEMPDIEMDANHByMASINHVIENMaHocPhan( @MASINHVIEN VARCHAR(30), @mahp VARCHAR(30))
    AS
    BEGIN
    	DELETE FROM TEMPDIEMDANH WHERE MASINHVIEN = @MASINHVIEN AND MAHOCPHAN = @mahp
    END
    GO
    
    /*******************************************
     * -----------------------
     *******************************************/
CREATE PROC getAlllistDiemDanhByMaHocPhan
AS
BEGIN
	SELECT DIEMDANH.MASINHVIEN, HODEM, TENSINHVIEN, MANHOM, LANHOC, HOCKY,DIEMDANH.SOBUOIHOC, DIEMDANH.SOBUOIPHEP, TUAN_1, TUAN_2, TUAN_3, TUAN_4,TUAN_5, TUAN_6, TUAN_7, TUAN_8,TUAN_9,TUAN_10,
	TUAN_11, TUAN_12, TUAN_13, TUAN_14,TUAN_15, TUAN_16, TUAN_17 FROM DIEMDANH INNER JOIN SINHVIEN ON SINHVIEN.MASINHVIEN = DIEMDANH.MASINHVIEN
END

GO
/*******************************************
 * Lay getAllTableTEMPDIEMDANH -----------
 *******************************************/
CREATE PROC getAllTableTEMPDIEMDANH
AS
BEGIN
	SELECT dbo.SINHVIEN.MASINHVIEN, dbo.SINHVIEN.HODEM, dbo.SINHVIEN.TENSINHVIEN,   MANHOM, TG_VAO, TG_RA, GHICHU
  FROM dbo.TEMPDIEMDANH INNER JOIN dbo.SINHVIEN ON dbo.SINHVIEN.MASINHVIEN = dbo.TEMPDIEMDANH.MASINHVIEN
	
END
GO
/*******************************************
 * Cap Nhat password moi
 *******************************************/
 CREATE PROC UpdatePassword(@ID VARCHAR(25), @newpass VARCHAR(100))
 AS
 BEGIN
 	UPDATE GIANGVIEN
 	SET
 		PASSWORD_USER =@newpass
 	WHERE MAGIANGVIEN = @ID
 END
 GO
 /*******************************************
  * Kiem tra sinh vien co ton tai **********
  *******************************************/
 CREATE PROC checkStudentSV(@MASINHVIEN VARCHAR(25))
 AS BEGIN
    	SELECT COUNT(*) FROM SINHVIEN WHERE MASINHVIEN = @MASINHVIEN
 END
/*
*  Delete data from tempdiemdanh
*/ 
go
 CREATE PROC delTEMPDIEMDANHbyID(@MASINHVIEN VARCHAR(25))
 AS BEGIN
    	delete FROM TEMPDIEMDANH WHERE MASINHVIEN = @MASINHVIEN
 END
 GO
 /*
 Thêm Học Phần --------------------
  */
 CREATE PROC AddNewHP(@mahp varchar(30), @tenhp nvarchar(100), @sotc integer, @magv varchar(30))
 AS BEGIN
  INSERT INTO HOCPHAN VALUES(@mahp, @tenhp, @sotc, @magv)
 END
 GO
 /*
 Thêm Trạng thái tuần học
  */
 CREATE PROC AddNewHocPhan_Trangthaituanhoc(@mahp varchar(30), @sobuoihoc int, @checkdiemdanh int)
 AS BEGIN
  INSERT INTO TRANGTHAITUANHOC VALUES(@mahp, @sobuoihoc, @checkdiemdanh)
 END
 GO
  -------------------------------
 CREATE PROC UpdateHP(@mahp varchar(30), @tenhp nvarchar(100), @sotc integer, @magv varchar(30))
 AS BEGIN
 UPDATE HOCPHAN
SET TENHOCPHAN = @tenhp, SOTINCHI= @sotc, MAKHOA = @magv
WHERE MAHOCPHAN = @mahp;
 END
 GO
  ------------------------
 CREATE PROC DelHocPhanById(@MaHP varchar(30))
 AS BEGIN
 DELETE FROM HOCPHAN WHERE MAHOCPHAN = @MaHP
  END

 GO
 CREATE PROC DelTrangThaiById(@MaHP varchar(30))
 AS BEGIN
 DELETE FROM TRANGTHAITUANHOC WHERE MAHOCPHAN = @MaHP
  END
 GO
 /*
 Load du lieu de bao cao thong ke
 */
 Create PROC LoadDulieuThongkeBaocao(@MaHP varchar(30))
 AS BEGIN
 select SINHVIEN.MASINHVIEN, HODEM + ' ' + TENSINHVIEN AS HOTEN, LANHOC, HOCKY, SOBUOIHOC, SOBUOIPHEP, HOCPHAN.MAHOCPHAN, TENHOCPHAN, SOTINCHI 
FROM SINHVIEN INNER JOIN DIEMDANH ON SINHVIEN.MASINHVIEN = DIEMDANH.MASINHVIEN INNER JOIN HOCPHAN ON HOCPHAN.MAHOCPHAN = DIEMDANH.MAHOCPHAN
WHERE DIEMDANH.MAHOCPHAN = @MaHP
END 
GO



SELECT dbo.NHOM.TENNHOM, dbo.NHOM.MANHOM, dbo.NHOM.MAHOCPHAN, dbo.HOCPHAN.TENHOCPHAN FROM dbo.NHOM INNER JOIN dbo.HOCPHAN ON HOCPHAN.MAHOCPHAN = NHOM.MAHOCPHAN WHERE dbo.NHOM.MANHOM = ''