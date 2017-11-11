
using Project_Diem_Danh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project_Diem_Danh.DAO
{
    public class TempDiemDanhDAO
    {
        private static TempDiemDanhDAO instance;
        public static TempDiemDanhDAO Instance
        {
            get
            {
                if (instance == null) instance = new TempDiemDanhDAO();
                    return TempDiemDanhDAO.instance;
            }
            private set { instance = value; }
        }
        private TempDiemDanhDAO() { }

        public DataTable getAllTableTemDiemDanh(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        // lấy bản ghi trên table TEMPDIEMDANH với ID và Mã học phần.
        public List<TempDiemDanh> getListTempDiemDanhByID_MaHocPhan(String ID, String MaHocPhan)
        {
            String sqlString = string.Format(@"EXEC getListTempDiemDanhByMASINHVIEN_MaHocPhan '{0}', '{1}'", ID, MaHocPhan);
            DataTable dt = DataProvider.Instance.LoadAllTable(sqlString);
            List<TempDiemDanh> listtemp = new List<TempDiemDanh>();
            foreach (DataRow row in dt.Rows)
            {
                TempDiemDanh tdiemdanh = new TempDiemDanh(row);
                listtemp.Add(tdiemdanh);
            }
            return listtemp;
        }

        public DataTable getTableTEMPDIEMDANHByMaHocPhan(String mhp)
        {
            DataTable dt = new DataTable();

            String strSqlDuLieuTho = string.Format(@"SELECT  dbo.SINHVIEN.MASINHVIEN, dbo.SINHVIEN.HODEM, dbo.SINHVIEN.TENSINHVIEN,  MANHOM, TG_VAO, TG_RA, GHICHU FROM dbo.TEMPDIEMDANH INNER JOIN dbo.SINHVIEN ON dbo.SINHVIEN.MASINHVIEN = dbo.TEMPDIEMDANH.MASINHVIEN WHERE MANHOM = '{0}'", mhp);
            dt = DataProvider.Instance.LoadAllTable(strSqlDuLieuTho);
            return dt;
        }
        //Kiem tra nghi co phep hay k
        public int insertDataIntoTemDiemDanh_NghiPhep(String id, String mamh, String lido)
        {
            int result = 0;
            String sqlString = string.Format(@"EXEC insertDataIntoTempDiemDanh '{0}', '{1}', N'P: {2}'", id, mamh, lido);
            result = DataProvider.Instance.ExcuteNonQuery(sqlString);
            return result;
        }

        public int insertDataToTEMPDIEMDANH_NoCard(String id, String mamh)
        {
            int result = 0;
            String sqlString = string.Format(@"EXEC insertDataIntoTempDiemDanh_NoCard '{0}', '{1}'", id, mamh);
            result = DataProvider.Instance.ExcuteNonQuery(sqlString);
            return result;
        }
        public int delTEMPDIEMDANHbyID(String id)
        {
            int result = 0;
            String sqlString = string.Format(@"EXEC delTEMPDIEMDANHbyID '{0}'", id);
            result = DataProvider.Instance.ExcuteNonQuery(sqlString);
            return result;
        }

        public int updateTimeStopByID(String id, String tg_ra)
        {
            int result = 0;
            String sqlString = string.Format(@"EXEC updateTimeStopByMASINHVIEN  '{0}', '{1}'", id, tg_ra);
            result = DataProvider.Instance.ExcuteNonQuery(sqlString);
            return result;
        }

        public int insertDataIntoTemDiemDanh_GT_VAO(String id, String Mahocphansv, String tg_vao)
        {
            int result = 0;
           try
           {
               String sqlString = string.Format(@"EXEC insertDataIntoTempDiemDanh_TG_VAO '{0}','{1}','{2}'", id, Mahocphansv, tg_vao);
               result = DataProvider.Instance.ExcuteNonQuery(sqlString);
           }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
             return result;
        }
        public bool DeleteItemInTEMPDIEMDANH(string id, String mahp)
        {
            bool result = false;
            try
            {
                String sqlString = string.Format(@"EXEC DeleteItemFromTEMPDIEMDANHByMASINHVIENMaHocPhan '{0}', '{1}'", id, mahp);
                if (DataProvider.Instance.ExcuteNonQuery(sqlString) > 0)
                    result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
    }
}
