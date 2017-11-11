using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class DiemDanh
    {
        #region KhaiBao
        private String tuan_17;
        public String Tuan_17
        {
            get { return tuan_17; }
            set { tuan_17 = value; }
        }
        private String tuan_16;
        public String Tuan_16
        {
            get { return tuan_16; }
            set { tuan_16 = value; }
        }
        private String tuan_15;
        public String Tuan_15
        {
            get { return tuan_15; }
            set { tuan_15 = value; }
        }
        private String tuan_14;
        public String Tuan_14
        {
            get { return tuan_14; }
            set { tuan_14 = value; }
        }
        private String tuan_13;
        public String Tuan_13
        {
            get { return tuan_13; }
            set { tuan_13 = value; }
        }
        private String tuan_12;
        public String Tuan_12
        {
            get { return tuan_12; }
            set { tuan_12 = value; }
        }
        private String tuan_11;
        public String Tuan_11
        {
            get { return tuan_11; }
            set { tuan_11 = value; }
        }
        private String tuan_10;
        public String Tuan_10
        {
            get { return tuan_10; }
            set { tuan_10 = value; }
        }
        private String tuan_9;
        public String Tuan_9
        {
            get { return tuan_9; }
            set { tuan_9 = value; }
        }
        private String tuan_8;
        public String Tuan_8
        {
            get { return tuan_8; }
            set { tuan_8 = value; }
        }
        private String tuan_7;
        public String Tuan_7
        {
            get { return tuan_7; }
            set { tuan_7 = value; }
        }
        private String tuan_6;
        public String Tuan_6
        {
            get { return tuan_6; }
            set { tuan_6 = value; }
        }
        private String tuan_5;
        public String Tuan_5
        {
            get { return tuan_5; }
            set { tuan_5 = value; }
        }
        private String tuan_4;
        public String Tuan_4
        {
            get { return tuan_4; }
            set { tuan_4 = value; }
        }
        private String tuan_3;
        public String Tuan_3
        {
            get { return tuan_3; }
            set { tuan_3 = value; }
        }
        private String tuan_2;
        public String Tuan_2
        {
            get { return tuan_2; }
            set { tuan_2 = value; }
        }
        private String tuan_1;
        public String Tuan_1
        {
            get { return tuan_1; }
            set { tuan_1 = value; }
        }
        private String hocky;
        public String Hocky
        {
            get { return hocky; }
            set { hocky = value; }
        }
        private int lanhoc;
        public int Lanhoc
        {
            get { return lanhoc; }
            set { lanhoc = value; }
        }
        private String mamonhoc;
        public String Mamonhoc
        {
            get { return mamonhoc; }
            set { mamonhoc = value; }
        }
        private String id;
        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private int soBuoiHoc;

        public int SoBuoiHoc
        {
            get { return soBuoiHoc; }
            set { soBuoiHoc = value; }
        }
        private int soBuoiPhep;

        public int SoBuoiPhep
        {
            get { return soBuoiPhep; }
            set { soBuoiPhep = value; }
        }
        #endregion

        #region Khoitao
        public DiemDanh()
        {

        }
        public DiemDanh(DataRow row)
        {
            this.mamonhoc = row["MANHOM"].ToString();
            this.Id = row["MASINHVIEN"].ToString();
            this.lanhoc = Convert.ToInt32(row["lanhoc"].ToString());
            this.hocky = row["hocky"].ToString();

            this.tuan_1 = row["Tuan_1"].ToString();
            this.tuan_2 = row["Tuan_2"].ToString();
            this.tuan_3 = row["Tuan_3"].ToString();
            this.tuan_4 = row["Tuan_4"].ToString();
            this.tuan_5 = row["Tuan_5"].ToString();
            this.tuan_6 = row["Tuan_6"].ToString();
            this.tuan_7 = row["Tuan_7"].ToString();
            this.tuan_8 = row["Tuan_8"].ToString();
            this.tuan_9 = row["Tuan_9"].ToString();

            this.tuan_10 = row["Tuan_10"].ToString();
            this.tuan_11 = row["Tuan_11"].ToString();
            this.tuan_12 = row["Tuan_12"].ToString();
            this.tuan_13 = row["Tuan_13"].ToString();
            this.tuan_14 = row["Tuan_14"].ToString();
            this.tuan_15 = row["Tuan_15"].ToString();
            this.tuan_16 = row["Tuan_16"].ToString();
            this.tuan_17 = row["Tuan_17"].ToString();
            this.SoBuoiHoc =(int) row["sobuoihoc"];
            this.SoBuoiPhep = (int)row["sobuoiphep"];
        }

        #endregion
    }
}
