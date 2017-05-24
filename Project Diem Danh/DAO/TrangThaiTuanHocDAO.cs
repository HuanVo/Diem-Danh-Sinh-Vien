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
    }
}