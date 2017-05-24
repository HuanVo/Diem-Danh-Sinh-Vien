using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class HocPhan
    {
        private String maGiangVien;
        public String MaGiangVien
        {
            get { return maGiangVien; }
            set { maGiangVien = value; }
        }
        private int soTinChi;
        public int SoTinChi
        {
            get { return soTinChi; }
            set { soTinChi = value; }
        }
        private String tenHocPhan;
        public String TenHocPhan
        {
            get { return tenHocPhan; }
            set { tenHocPhan = value; }
        }
        private String maHocPhan;
        public String MaHocPhan
        {
            get { return maHocPhan; }
            set { maHocPhan = value; }
        }
        public HocPhan()
        {

        }
        public HocPhan(String mahp, String tenhp, int sotc, String magv)
        {
            this.MaHocPhan = mahp;
            this.TenHocPhan = tenhp;
            this.SoTinChi = sotc;
            this.MaGiangVien = magv;
        }
        public HocPhan(DataRow row)
        {
            this.MaHocPhan = row["MAHOCPHAN"].ToString();
            this.TenHocPhan = row["TENHOCPHAN"].ToString();
            this.SoTinChi = (int)row["SOTINCHI"];
            this.MaGiangVien = row["MAGIANGVIEN"].ToString();
        }

    }
}
