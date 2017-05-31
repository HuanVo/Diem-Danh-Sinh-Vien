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
        /// <summary>
        /// The hien duy nhat cua lop. 
        /// </summary>
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
        /// <summary>
        /// Kiem tra  dang nhap
        /// </summary>
        /// <param name="IDGiangVien"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CheckLogin(String IDGiangVien, String Password)
        {
            String sqlProcString = @"EXEC UserLogin"+" '"+IDGiangVien+"',"+"'"+Password+"'";
            int result = 0;
            result = DataProvider.Instance.ExcuteScaler(sqlProcString);
            if (result > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Lay thong tin giang vien 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public GiangVien getGiangVienByID(String ID)
        {
            GiangVien GV;
            DataTable dt = new DataTable();
            String sqlString = "EXEC getGiangVienByID " + "'" + ID + "'";
            dt = DataProvider.Instance.LoadAllTable(sqlString);
            GV = new GiangVien(dt.Rows[0]);
            return GV;
        }
        /// <summary>
        /// Lay thong tin tat ca giang vien
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getAllTableGiangVien(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        /// <summary>
        /// Cap nhat password
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newpass"></param>
        /// <returns></returns>
        public bool UpdatePassword(String ID, String newpass)
        {
            String sqlString = @"EXEC UpdatePassword '"+ ID + "' , '"+ newpass +"'";
            bool result = false;
            if(DataProvider.Instance.ExcuteNonQuery(sqlString)>0)
                result = true;
            return result;
        }
        /// <summary>
        /// Kiem tra ton tai cua giang vien
        /// </summary>
        /// <param name="MaGV"></param>
        /// <returns></returns>
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
