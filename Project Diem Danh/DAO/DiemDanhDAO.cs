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
    public class DiemDanhDAO
    {
        private static DiemDanhDAO instance;
        public static DiemDanhDAO Instance
        {
            get { if(instance ==null)
                instance = new DiemDanhDAO();
                return DiemDanhDAO.instance;
            }
            private set { DiemDanhDAO.instance = value; }
        }
        public DiemDanhDAO() { }
        // Kiểm tra Sinh viên có tồn tài trong lớp hiện hành hay không.
        public bool CheckIsStudentByID_MaHocPhan(String ID, String MaHocPhan)
        {
            String sqlString = @"EXEC CheckIsStudentByMASINHVIEN_MaHocPhan '" + ID + "'," + "'" + MaHocPhan + "'"; 
            int temp = (int)DataProvider.Instance.ExcuteScaler(sqlString);
            if (temp > 0)
                return true;
            return false;
        }
        //Lấy dah sách sinh viên trong bảng điểm danh- danh sách nà là dữ liệu chuẩn.
        public DataTable getListDiemDanhByMaHocPhan(String mhp)
        {
            DataTable dt = new DataTable();
            String strSqlDuLieuChuan = string.Format(@"SELECT  DIEMDANH.MASINHVIEN, HODEM, TENSINHVIEN, DIEMDANH.MANHOM, LANHOC, HOCKY,DIEMDANH.SOBUOIHOC, DIEMDANH.SOBUOIPHEP, TUAN_1, TUAN_2, TUAN_3, TUAN_4,TUAN_5, TUAN_6, TUAN_7, TUAN_8,TUAN_9,TUAN_10, TUAN_11, TUAN_12, TUAN_13, TUAN_14,TUAN_15, TUAN_16, TUAN_17 FROM DIEMDANH INNER JOIN SINHVIEN ON SINHVIEN.MASINHVIEN = DIEMDANH.MASINHVIEN where DIEMDANH.MANHOM = '{0}'", mhp);
            dt = DataProvider.Instance.LoadAllTable(strSqlDuLieuChuan);
            return dt;
        }
        public DataTable getAllTableDiemDanh(String sql)
        {
            DataTable dt = new DataTable();
            dt =DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        public DiemDanh getTableDIEMDANHByIdMaHocPhan(String id, String mahp)
        {
            DiemDanh result =new DiemDanh();
            DataTable dt = new DataTable();
            String strSqlDuLieuChuan = string.Format(@"EXEC getListDIEMDANHByMASINHVIENMaHocPhan '{0}', '{1}'", id, mahp);
            dt = DataProvider.Instance.LoadAllTable(strSqlDuLieuChuan);
            result = new DiemDanh(dt.Rows[0]);
            return result;
        }
        public int updateDiemDanhAdmin(String MaSV, String Mahp, int lanhoc)
        {
            int kq = 0;
            try
            {
                String sql = "update diemdanh set MAHOCPHAN='"+Mahp+"',lanhoc='"+lanhoc+"'"+ " where masinhvien='"+MaSV+"'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }

        public bool issetdiemdanh(String MaGV, String Mahp, int lanhoc)
        {
            bool kq = false;
            try
            {
                String sql = "select count(*) from diemdanh where masinhvien ='" + MaGV + "' and mahocphan='"+Mahp+"'  and lanhoc='"+lanhoc+"'";
                if (DataProvider.Instance.ExcuteScaler(sql) > 0)
                    kq = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public int DelDiemdanhByMaSV(String MaGV, String Mahp, int lanhoc)
        {
            int kq = 0;
            try
            {
                String sql = "delete from diemdanh where masinhvien ='" + MaGV + "' and mahocphan='"+Mahp+"'  and lanhoc='"+lanhoc+"'";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }

        public int AddNewDiemDanh(String MaSV, String Mahp, int lanhoc, String hk)
        {
            int kq = 0;
            try
            {
                String sql = "insert into diemdanh(MASINHVIEN, MAHOCPHAN, LANHOC, HOCKY) values('" + MaSV+"','"+Mahp+"','"+ lanhoc+"','"+hk+"')";
                kq = DataProvider.Instance.ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public DataTable LoadDulieuThongkeBaocao(String MaHP)
        {
            DataTable dt = new DataTable();
            String sql_cmd = @"EXEC LoadDulieuThongkeBaocao '"+MaHP +"'";
            dt = DataProvider.Instance.LoadAllTable(sql_cmd);
            return dt;
        }
    }
}
