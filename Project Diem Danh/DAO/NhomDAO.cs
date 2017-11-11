using Project_Diem_Danh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Diem_Danh.DAO
{
    public class NhomDAO
    {
        private static NhomDAO instance;

        public static NhomDAO Instance
        {
            get {
                if(instance == null)
                {
                    instance = new NhomDAO();
                }
                   return NhomDAO.instance; }
            private set { NhomDAO.instance = value; }
        }

        private NhomDAO()
        {}
        public DataTable getListNhomHocPhanByIDGiangVien(String ID)
        {
            DataTable result = null;

            String sqlString = string.Format(@"SELECT dbo.NHOM.TENNHOM, dbo.NHOM.MANHOM, dbo.NHOM.MAHOCPHAN, dbo.HOCPHAN.TENHOCPHAN, dbo.HOCPHAN.SOTINCHI, dbo.NHOM.SOBUOIHOC FROM dbo.NHOM INNER JOIN dbo.HOCPHAN ON HOCPHAN.MAHOCPHAN = NHOM.MAHOCPHAN WHERE dbo.NHOM.MAGIANGVIEN = '{0}'", ID);//string.Format(@"EXEC getListNhomHocPhanByIDGiangVien '{0}'", ID);
            result = DataProvider.Instance.LoadAllTable(sqlString);
            return result;
        }

        public DataTable getListNhomHocPhanByIDGiangVienAndMHP(String ID, String mhp)
        {
            DataTable result = null;

            String sqlString = string.Format(@"SELECT dbo.NHOM.TENNHOM, dbo.NHOM.MANHOM, dbo.NHOM.MAHOCPHAN, dbo.HOCPHAN.TENHOCPHAN, dbo.HOCPHAN.SOTINCHI, dbo.NHOM.SOBUOIHOC FROM dbo.NHOM INNER JOIN dbo.HOCPHAN ON HOCPHAN.MAHOCPHAN = NHOM.MAHOCPHAN WHERE dbo.NHOM.MAGIANGVIEN = '{0}' and dbo.NHOM.MANHOM = '{1}'", ID, mhp);//string.Format(@"EXEC getListNhomHocPhanByIDGiangVien '{0}'", ID);
            result = DataProvider.Instance.LoadAllTable(sqlString);
            return result;
        }

        public DataRow getHocPhanByID(String ID)
        {
            DataRow hp = null;
            String sqlString = string.Format(@"SELECT dbo.NHOM.TENNHOM, dbo.NHOM.MANHOM, dbo.NHOM.MAHOCPHAN, dbo.HOCPHAN.TENHOCPHAN, dbo.HOCPHAN.SOTINCHI, dbo.NHOM.SOBUOIHOC FROM dbo.NHOM INNER JOIN dbo.HOCPHAN ON HOCPHAN.MAHOCPHAN = NHOM.MAHOCPHAN WHERE dbo.NHOM.MANHOM = '{0}'", ID);
            try
            {
                DataTable dt = DataProvider.Instance.LoadAllTable(sqlString);
                hp = dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return hp;
        }
    }
}
