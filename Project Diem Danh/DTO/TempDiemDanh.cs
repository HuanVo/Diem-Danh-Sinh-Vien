using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class TempDiemDanh
    {
        private String id;
        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        private String maHocPhan;
        public String MaHocPhan
        {
            get { return maHocPhan; }
            set { maHocPhan = value; }
        }

        private String thoiGianVao;
        public String ThoiGianVao
        {
            get { return thoiGianVao; }
            set { thoiGianVao = value; }
        }

        private String thoiGianRa;
        public String ThoiGianRa
        {
            get { return thoiGianRa; }
            set { thoiGianRa = value; }
        }

        private String ghiChu;
        public String GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public TempDiemDanh() { }

        public TempDiemDanh(String ID, String MaHocPhan, String TGVao, String TGRa, String GhiChu)
        {
            this.Id = ID;
            this.MaHocPhan = MaHocPhan;
            this.ThoiGianVao = TGVao;
            this.ThoiGianRa = TGRa;
            this.GhiChu = GhiChu;
        }

        public TempDiemDanh(DataRow row)
        {
            this.Id = row["MASINHVIEN"].ToString();
            this.MaHocPhan = row["MAHOCPHAN"].ToString();
            this.ThoiGianVao = row["TG_VAO"].ToString();
            this.ThoiGianRa = row["TG_RA"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
