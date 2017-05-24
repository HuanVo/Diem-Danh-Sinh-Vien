using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class SinhVien
    {
        private String ten;

        public String Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private String gioiTinh;

        public String GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        private Byte[] hinhDaiDien;

        public Byte[] HinhDaiDien
        {
            get { return hinhDaiDien; }
            set { hinhDaiDien = value; }
        }
        private DateTime? ngaySinh;

        public DateTime? NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        private String malop;

        public String MaLop
        {
            get { return malop; }
            set { malop = value; }
        }
        private String diaChi;

        public String DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private String hoDem;

        public String HoDem
        {
            get { return hoDem; }
            set { hoDem = value; }
        }
        private String maSV;


        public String MaSV
        {
            get { return maSV; }
            set { maSV = value; }
        }
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public SinhVien() { }
        public SinhVien(String id, String ma, String hoten, String gioitinh, DateTime? ngaysinh, String diachi, Byte[] hinhdaiden, String malop)
        {
            this.Id = id;
            this.MaSV = ma;
            this.HoDem = hoten;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.HinhDaiDien = hinhdaiden;
            this.MaLop = malop;
        }
        public SinhVien(DataRow row)
        {
            this.Id = row["ID"].ToString();
            this.MaSV = row["MASINHVIEN"].ToString();
            this.HoDem = row["HODEM"].ToString();
            this.Ten = row["TENSINHVIEN"].ToString();
            this.GioiTinh = row["GIOITINH1"].ToString();
            this.NgaySinh = Convert.ToDateTime(row["NGAYSINH"].ToString());
            this.DiaChi = row["NOISINH"].ToString();
            if (row["IMAGES"] != System.DBNull.Value)
                this.HinhDaiDien = (byte[])row["IMAGES"];
            else
                this.hinhDaiDien = null;
            this.MaLop = row["MALOP"].ToString();
        }
    }
}
