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
    public class TrangThaiTuanHocDAO
    {
        private static TrangThaiTuanHocDAO instance;

        public static TrangThaiTuanHocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TrangThaiTuanHocDAO(); 
                return TrangThaiTuanHocDAO.instance;
            }
            private set {
                instance = value;
            }
        }

        public TrangThaiTuanHocDAO() { }
        public DataTable getAllTableTrangThaiTuanHoc(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        // Lay ban ghi so tuan hoc hien tai cua mon nao do.
        public TrangThaiTuanHoc getTrangThaiTuanHocByMaHocPhan(String Mamh)
        {
            TrangThaiTuanHoc result;
            String sql = @"EXEC getTrangThaiTuanHocByMaHocPhan '"+Mamh+"'";
            DataTable dt = DataProvider.Instance.LoadAllTable(sql);
            result = new TrangThaiTuanHoc(dt.Rows[0]);
            return result;
        }

        public bool UpdateTrangThaiTuanHoc(String Mahp, int trangthai)
        {
            bool result = false;
            String sqlString = @"EXEC UpdateTrangThaiTuanHoc '"+Mahp+"' , '"+trangthai+"'";
            if (DataProvider.Instance.ExcuteNonQuery(sqlString) > 0)
                result = true;
            return result;
        }

        public bool UpdateCheckDiemDanh(String mahp)
        {
            bool result = false;
            String sqlString = @"EXEC UpdateTrangThaiCheckDiemDanh '" + mahp + "'";
            if (DataProvider.Instance.ExcuteNonQuery(sqlString) > 0)
                result = true;
            return result;
        }
        public int AddNewHocPhan_Trangthaituanhoc(String mahp)
        {
            int kq = 0;
            try
            {
                String sqlString = @"EXEC  AddNewHocPhan_Trangthaituanhoc '" + mahp + "','" + 0 + "','" + 0 + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sqlString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public int AddRowTrangThai(String MaHP, int Sobuoihoc, bool trangthai)
        {
            int kq = 0;
            int k = 0;
            if (trangthai == true)
                k = 1;
            try
            {
                String sqlString = @"EXEC  AddNewHocPhan_Trangthaituanhoc '" + MaHP + "','" + Sobuoihoc + "','" + k + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sqlString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }

        public int DelTrangThaiById(String mahp)
        {
            int kq = 0;
            try
            {
                String sql = "EXEC DelTrangThaiById N'" + mahp + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }

        public bool issetTrangthai(String mahp)
        {
            bool kq = false;
            try
            {
                String sql = "select count(*) from TRANGTHAITUANHOC where MAHOCPHAN ='" + mahp + "'";
                if (DataProvider.Instance.ExcuteScaler(sql) > 0)
                    kq = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public int updateTrangthai(String mahp, int sobuoihoc, bool trangthai)
        {
             int kq = 0;
             int k = 0;
            if(trangthai ==true)
            {
               k = 1;
            }
           
            try
            {
                String sql = "update TRANGTHAITUANHOC set SOBUOIHOC = '" + sobuoihoc + "', CHECKDIEMDANH ='" + k + "' where MAHOCPHAN = '" + mahp + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        /// <summary>
        /// Xóa trạng thái điểm danh
        /// </summary>
        /// <param name="Mahp"></param>
        /// <returns></returns>
        public int xoaTrangthai(String Mahp)
        {
            int kq = 0;
            try
            {
                String sql = "delete from TRANGTHAITUANHOC where MAHOCPHAN ='" + Mahp + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
    }
}