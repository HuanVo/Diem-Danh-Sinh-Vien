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
    public class GiangVienDAO
    {
        private static GiangVienDAO instance;
        public static GiangVienDAO Instance
        {
            get
            {
                if(instance == null)
                    instance = new GiangVienDAO();
                return GiangVienDAO.instance; }
            private set { GiangVienDAO.instance = value; }
        }
        public GiangVienDAO()
        {

        }

        public bool CheckLogin(String IDGiangVien, String Password)
        {
            String sqlProcString = @"EXEC UserLogin"+" '"+IDGiangVien+"',"+"'"+Password+"'";
            int result = 0;
            
            result = DataProvider.Instance.ExcuteScaler(sqlProcString);
            if (result > 0)
                return true;
            return false;
        }

        public GiangVien getGiangVienByID(String ID)
        {
            GiangVien GV;
            DataTable dt = new DataTable();
            String sqlString = "EXEC getGiangVienByID " + "'" + ID + "'";
            dt = DataProvider.Instance.LoadAllTable(sqlString);
            GV = new GiangVien(dt.Rows[0]);
            return GV;
        }
        public DataTable getAllTableGiangVien(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

   
        public bool UpdatePassword(String ID, String newpass)
        {
            String sqlString = @"EXEC UpdatePassword '"+ ID + "' , '"+ newpass +"'";
            bool result = false;
            if(DataProvider.Instance.ExcuteNonQuery(sqlString)>0)
                result = true;
            return result;
        }
        public bool issetGiangVien(String MaGV)
        {
            bool kq = false;
            try
            {
                String sql = "select count(*) from giangvien where magiangvien ='" + MaGV + "'";
                if (DataProvider.Instance.ExcuteScaler(sql) > 0)
                    kq = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
    }
}
