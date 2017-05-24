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
    public class HocPhanDAO
    {
        public static int WidthButton = 90;
        public static int HeightButton = 70;
        private static HocPhanDAO instance;
        public static HocPhanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocPhanDAO();
                return HocPhanDAO.instance;
            }
            private set { HocPhanDAO.instance = value; }
        }
        public HocPhanDAO()
        {

        }
        public List<HocPhan> getListHocPhanByIDGiangVien(String id)
        {
            List<HocPhan> result = new List<HocPhan>();
            String sqlString = @"EXEC getListHocPhanByIDGiangVien '"+id+"'";
            DataTable dt = DataProvider.Instance.LoadAllTable(sqlString);
            foreach(DataRow i in dt.Rows)
            {
                HocPhan hp = new HocPhan(i);
                result.Add(hp);
            }
            return result;
        }
        public HocPhan getHocPhanByID(String ID)
        {
            HocPhan hp = new HocPhan();
            String sqlString = "Exec getHocPhanByID " + "'" + ID + "'";
            try
            {
                DataTable dt = DataProvider.Instance.LoadAllTable(sqlString);
                hp = new HocPhan(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return hp;
        }

        public DataTable getAllTableHocPhan(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        /// <summary>
        /// Thêm mới một học phần
        /// </summary>
        /// <param name="mahp"></param>
        /// <param name="tenhp"></param>
        /// <param name="sotc"></param>
        /// <param name="Magv"></param>
        /// <returns></returns>
        public int AddNewHP(String mahp, String tenhp, int sotc, String Magv)
        {
            int kq = 0;
            try
            {
                String sql = "EXEC AddNewHP N'" + mahp + "',N'" + @tenhp + "','" + sotc + "',N'" + Magv + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        /// <summary>
        /// Kiểm tra tồn tại của mã học phần
        /// </summary>
        /// <param name="mahp"></param>
        /// <returns></returns>
        public bool issetHocPhan(String mahp)
        {
            bool kq = false;
            try
            {
                String sql = "select count(*) from hocphan where MAHOCPHAN ='"+mahp+"'";
                if (DataProvider.Instance.ExcuteScaler(sql) > 0)
                    kq = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        /// <summary>
        /// Update học phần
        /// </summary>
        /// <param name="mahp"></param>
        /// <param name="tenhp"></param>
        /// <param name="sotc"></param>
        /// <param name="Magv"></param>
        /// <returns></returns>
        public int UpdateHP(String mahp, String tenhp, int sotc, String Magv)
        {
            int kq = 0;
            try
            {
                String sql = "EXEC UpdateHP N'" + mahp + "',N'" + @tenhp + "','" + sotc + "',N'" + Magv + "'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public int DelHocPhanById(String mahp)
        {
            int kq = 0;
            try
            {
                String sql = "EXEC DelHocPhanById N'" + mahp + "'";
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
