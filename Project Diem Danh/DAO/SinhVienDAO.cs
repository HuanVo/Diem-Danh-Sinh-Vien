﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Project_Diem_Danh.DAO;
using System.Windows.Forms;

namespace Project_Diem_Danh.DTO
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;

        public static SinhVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SinhVienDAO();
                return instance;
            }
            private set { instance = value; }
        }
        public SinhVienDAO() { }
        public DataTable getAllTableSinhVien(String sql)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.LoadAllTable(sql);
            return dt;
        }

        public SinhVien getInfoSinhVienByID(String ID)
        {
            SinhVien sv = new SinhVien();
            DataTable dt = new DataTable();
            DataRow row;
            String sqlString = "EXEC _proc_GetSinhVienByMASINHVIEN '" + ID + "'";
            dt = DataProvider.Instance.LoadAllTable(sqlString);
            try
            {
                row = dt.Rows[0];
                sv = new SinhVien(row);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            return sv;
        }
        

       
        public bool checkIsStudents(String ID)
        {
            bool result = false;
            String sqlStringProc = @"EXEC checkStudentSV '" + ID + "'";
            if (DataProvider.Instance.ExcuteScaler(sqlStringProc) > 0)
                result = true;
            return result;
        }

        public DataTable getTableInfoSinhVienByID(String ID)
        {
            DataTable dt = new DataTable();
            String sqlString = "EXEC _proc_GetSinhVienByMASINHVIEN '" + ID + "'";
            dt = DataProvider.Instance.LoadAllTable(sqlString);
            return dt;
        }
        public bool issetSinhVien(String MaGV)
        {
            bool kq = false;
            try
            {
                String sql = "select count(*) from sinhvien where masinhvien ='" + MaGV + "'";
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

