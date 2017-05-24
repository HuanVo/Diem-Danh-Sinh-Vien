using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class TrangThaiTuanHoc
    {
        private int trangthai;
        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private String mahocphan;
        public String Mahocphan
        {
            get { return mahocphan; }
            set { mahocphan = value; }
        }

        private int checkDiemDanh;

        public int CheckDiemDanh
        {
            get { return checkDiemDanh; }
            set { checkDiemDanh = value; }
        }
        public TrangThaiTuanHoc() { }
        public TrangThaiTuanHoc(String Mamonhoc, int Trangthai, int checkdd)
        {
            this.mahocphan = Mamonhoc;
            this.trangthai = Trangthai;
            this.CheckDiemDanh = checkdd;
        }

        public TrangThaiTuanHoc(DataRow row)
        {
            this.trangthai = Convert.ToInt32(row["SOBUOIHOC"].ToString());
            this.mahocphan = row["Mahocphan"].ToString();
            this.CheckDiemDanh = (int)row["CHECKDIEMDANH"];
        }
    }
}
