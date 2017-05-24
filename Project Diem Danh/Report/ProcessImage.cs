using Project_Diem_Danh.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.Report
{
    public class ProcessImage
    {
        private static ProcessImage instance;

        public static ProcessImage Instance
        {
            get {
                if (instance == null)
                    instance = new ProcessImage();
                    return ProcessImage.instance;
            }
            set { ProcessImage.instance = value; }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image newImage = null;
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            newImage = Image.FromStream(ms, true);
            return newImage;
        }

        public byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        public void Save_ImageIntoDB(String id, byte[] ImageData)
        {
            string qry = "update sinhvien set IMAGES = @ImageData where MASINHVIEN =@id ";

            DataProvider.Instance.OpenConnect();
            SqlCommand SqlCom = new SqlCommand(qry, DataProvider.Instance._Connection);

            SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)ImageData));
            SqlCom.Parameters.Add(new SqlParameter("@id", id));
            int check = (int)SqlCom.ExecuteNonQuery();

            DataProvider.Instance.CloseConnect();
        }
    }
}
