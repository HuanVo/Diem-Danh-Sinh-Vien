using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DAO
{
    public class KhoaDAO
    {
        private static KhoaDAO instance;

        public static KhoaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoaDAO();
                return instance;
            }
            private set {
                
                instance = value;
            }
        }
        public KhoaDAO() { }
        public DataTable getAllTableKhoa(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);

            return dt;
        }
    }
}
