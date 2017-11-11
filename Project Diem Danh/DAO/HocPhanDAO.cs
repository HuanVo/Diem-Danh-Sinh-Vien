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
        /// <summary>
        /// Lấy học phần bởi mã giảng viên, trả về sanh sách HOCPHAN
        /// </summary>
        /// <param name="id">Mã giảng viên</param>
        /// <returns></returns>
        public List<HocPhan> getListHocPhanByIDGiangVien(String id)
        {
            List<HocPhan> result = new List<HocPhan>();

            String sqlString = string.Format(@"EXEC getListNhomHocPhanByIDGiangVien '{0}'", id);
            DataTable dt = DataProvider.Instance.LoadAllTable(sqlString);
            foreach(DataRow i in dt.Rows)
            {
                HocPhan hp = new HocPhan(i);
                result.Add(hp);
            }
            return result;
        }
        /// <summary>
        /// Lấy Học phần bởi mã giảng viên và mã học phần, trả về danh sách HOCPHAN
        /// </summary>
        /// <param name="id">Mã giảng viên</param>
        /// <param name="Mahp">Mã học phần</param>
        /// <returns></returns>
        public List<HocPhan> getListHocPhanByIDGiangVienAndMaHP(String id, String Mahp)
        {
            List<HocPhan> result = new List<HocPhan>();
            String sqlString = @"EXEC getListHocPhanByIDGiangVienAndMaHP '" + id + "', '"+Mahp+"'";
            DataTable dt = DataProvider.Instance.LoadAllTable(sqlString);
            foreach (DataRow i in dt.Rows)
            {
                HocPhan hp = new HocPhan(i);
                result.Add(hp);
            }
            return result;
        }
        /// <summary>
        /// Lấy học phần bởi mã học phần, trả về Kiểu HOCPHAN
        /// </summary>
        /// <param name="ID">Mã học phần</param>
        /// <returns></returns>
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
        /// <summary>
        /// Lấy toàn bộ bảng học phần
        /// </summary>
        /// <param name="sql">Câu lệnh lấy</param>
        /// <returns></returns>
        public DataTable getAllTableHocPhan(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        /// <summary>
        /// Thêm mới một học phần
        /// </summary>
        /// <param name="mahp">Mã học phần</param>
        /// <param name="tenhp">Tên học phần</param>
        /// <param name="sotc">số tín chỉ</param>
        /// <param name="Magv">Mã giảng viên</param>
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
        /// <param name="mahp">Mã học phần</param>
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
        /// <param name="mahp">Mã học phần</param>
        /// <param name="tenhp">tên học phần</param>
        /// <param name="sotc">số tín chỉ</param>
        /// <param name="Magv">Mã giảng viên</param>
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
        /// <summary>
        /// Xóa học phần bởi Mã Học Phần
        /// </summary>
        /// <param name="mahp"></param>
        /// <returns></returns>
        public int DelHocPhanById(String mahp)
        {
            int kq = 0;
            try
            {
                String sql = string.Format("EXEC DelHocPhanById N'{0}'", mahp);
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
