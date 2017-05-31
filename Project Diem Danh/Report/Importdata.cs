using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Project_Diem_Danh.DAO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Project_Diem_Danh.Report
{
    public class Importdata
    {

        private static Importdata instance;

        public static Importdata Instance
        {
            get {
                if(instance==null)
                instance = new Importdata();
                return instance;
            }
            private set { instance = value; }
        }
        public Importdata() { }

        /// <summary>
        /// thuc hien import du lieu vao trong csdl
        /// </summary>
        /// <param name="excelFilePath">bien luu duong dan file excel</param>
        /// <param name="myexceldataquery">chuoi de lay cac cot du lieu trong file excel ma ta muon lay. ex: string myexceldataquery = "select student,rollno,course from [Sheet1$]"; </param>
        /// <param name="ssqltable">ten bang du lieu dich</param>
        /// 
        /// 
        public String getNameSheetExcel(String strPath)
        {
            Excel.Application ExcelObj = new Excel.Application();

            Excel.Workbook theWorkbook = null;

            theWorkbook = ExcelObj.Workbooks.Open(strPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            Excel.Sheets sheets = theWorkbook.Worksheets;

            Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);

            String strWorksheetName = worksheet.Name;//Get the name of worksheet.
            return strWorksheetName;

        }
        public bool ImportDataFromExcel(String excelFilePath, String myexceldataquery, String ssqltable, bool DelOldData)
        {
            try
            {

                // Cắt đường dẫn tập tin để kiểm tra xem là xls hay xlsx
                string[] fileParts = excelFilePath.Split('.');

                string connString = "";
                if (excelFilePath.Length > 1 && fileParts[1] == "xls")// sử dụng cho Microsoft Excel 2003
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0";
                }
                else // sử dụng cho Microsoft Excel 2007
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=Excel 12.0";
                }
                      //execute a query to erase any previous data from destination table 
                if(DelOldData == true)
                {
                    string sclearsql = @"delete from " + ssqltable;
                    int temp = DataProvider.Instance.ExcuteNonQuery(sclearsql);
                }
                
                //series of commands to bulk copy data from the excel file into sql table 
                OleDbConnection oledbconn = new OleDbConnection(connString);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                if(dr.FieldCount>0)
                {
                    SqlBulkCopy bulkcopy = new SqlBulkCopy(DataProvider.Instance._ConnectionString);
                    bulkcopy.DestinationTableName = ssqltable;
                    while (dr.Read())
                    {
                        bulkcopy.WriteToServer(dr);
                    }

                    dr.Close();
                    oledbconn.Close();
                    return true;
                }

               
                return false;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            return false;
        }
    }
}
