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
    public class MappingCode_Id
    {
        public static String MappingCodeToID(String Code)
        {
            String ID = "";
            try
            {
                DataTable dt = new DataTable();
                SinhVien sv;
                String sqlString = "EXEC _proc_GetSinhVienByIDTHE '" + Code + "'";
                dt = DataProvider.Instance.LoadAllTable(sqlString);
                if(dt.Rows.Count >0)
                {
                    sv = new SinhVien(dt.Rows[0]);
                    ID = sv.MaSV;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ID;
        }
    }
}
