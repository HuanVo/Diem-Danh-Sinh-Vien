using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DAO
{
    public class LopDAO
    {
        private static LopDAO instance;

        public static LopDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopDAO();  
                return LopDAO.instance;
            }
            private set {
                
                instance = value;
            }
        }
        public LopDAO() { }
        public DataTable getAllTableLop(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }


        public String getTenlopByMalop(String Malop)
        {
            String kq = "";
            String sqlString = "EXEC getTenlopByMalop '" + Malop + "'";
            DataTable tbl = DataProvider.Instance.LoadAllTable(sqlString);
            DataRow dr = tbl.Rows[0];
            kq = dr["TENLOP"].ToString();
            return kq;
        }
    }
}
