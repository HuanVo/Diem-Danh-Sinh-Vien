using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class GiangVien
    {
        private String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime? ngaySinh;
        public DateTime? NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        
        private String soDT;
        public String SoDT
        {
            get { return soDT; }
            set { soDT = value; }
        }

        private String diaChi;
        public String DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private String ten;
        public String Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private String hoDem;
        public String HoDem
        {
            get { return hoDem; }
            set { hoDem = value; }
        }
        
        private String maGiangVien;
        public String MaGiangVien
        {
            get { return maGiangVien; }
            set { maGiangVien = value; }
        }

        private String maKhoa;

        public String MaKhoa
        {
            get { return maKhoa; }
            set { maKhoa = value; }
        }
        private bool typeUser;

        public bool TypeUser
        {
            get { return typeUser; }
            set { typeUser = value; }
        }
        public GiangVien() { }
        public GiangVien(String magiangvien, String hodem, String ten, String diachi, String sodt, DateTime ngaysinh, String email, String makhoa, bool TypeUser)
        {
            this.MaGiangVien = magiangvien;
            this.HoDem = hodem;
            this.Ten = ten;
            this.DiaChi = diachi;
            this.SoDT = sodt;
            this.NgaySinh = ngaysinh;
            this.Email = email;
            this.MaKhoa = makhoa;
            this.TypeUser = TypeUser;

        }
        public GiangVien(DataRow row)
        {
            this.MaGiangVien = row["MAGIANGVIEN"].ToString();
            this.HoDem = row["HODEM"].ToString();
            this.Ten = row["TEN"].ToString();
            this.DiaChi = row["DIACHI"].ToString();
            this.SoDT = row["SODIENTHOAI"].ToString();
            this.NgaySinh = Convert.ToDateTime(row["NGAYSINH"]);
            this.Email = row["EMAIL"].ToString();
            this.MaKhoa = row["MAKHOA"].ToString();
            this.TypeUser = (bool)row["TYPE_USER"];
        }
    }
}
