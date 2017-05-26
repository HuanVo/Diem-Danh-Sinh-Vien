using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Forms;
namespace Project_Diem_Danh.DAO
{
    public class DataProvider
    {
        // Chuoi ket noi den CSDL
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
          private set { instance = value; }
        }

        private SqlDataAdapter da;

        public SqlDataAdapter Da
        {
            get { return da; }
            set { da = value; }
        }
        #region cac thuoc tinh cua lop
        private String ConnectionString = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

        public String _ConnectionString
        {
            get { return ConnectionString; }
            set { ConnectionString = value; }
        }
        private SqlConnection Connection;

        public SqlConnection _Connection
        {
            get { return Connection; }
            set { Connection = value; }
        }
        #endregion

        #region cac phuong thuc cua lop
        // phuong thuc ket noi den csdl
        public void OpenConnect()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                if (Connection.State == ConnectionState.Broken || Connection.State == ConnectionState.Closed)
                        Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến server. Vui lòng kiểm tra lại", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Phuong thuc dong ket noi den csdl
        public void CloseConnect()
        {
            try
            {
                if(Connection.State==ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // lay du lieu tren mot bang
        public DataTable LoadAllTable(String CommandString)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnect();
                Da = new SqlDataAdapter(CommandString, Connection);
                Da.Fill(dt);             
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnect();
            return dt;
        }

        //phuong thuc update, insert, del du lieu
        public int ExcuteNonQuery(String str_Proc)
        {
            int kq = 0;
            OpenConnect();
            SqlCommand cmd = new SqlCommand(str_Proc, Connection);
            kq = cmd.ExecuteNonQuery();
            return kq;
        }

        public int ExcuteScaler(String str)
        {
            int kq = 0;
            try
            {
                OpenConnect();
                SqlCommand cmd = new SqlCommand(str, Connection);
                kq = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực thi yêu cầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnect();
            return kq;
        }
       
    }
        #endregion
}