using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.IO;

namespace Project_Diem_Danh
{
    public partial class FrmConfigSetting : DevExpress.XtraEditors.XtraForm
    {
        public FrmConfigSetting()
        {
            InitializeComponent();
        }

        private void FrmConfigSetting_Load(object sender, EventArgs e)
        {
           try
           {
               numDPort.Value = Convert.ToInt32(ConfigurationManager.AppSettings["port"].ToString());
               numdTime.Value = Convert.ToInt32(ConfigurationManager.AppSettings["thoigianhoc"].ToString());
               numTimeCard.Value = Convert.ToInt32(ConfigurationManager.AppSettings["thoiGianHaiLanQuetThe"].ToString());
           }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int checks = 0;
            if(numDPort.Value.ToString() != ConfigurationManager.AppSettings["port"].ToString())
            {
                EditAppSetting("port", numDPort.Value.ToString());
                checks = checks + 1;

            }
            if( numdTime.Value.ToString() != ConfigurationManager.AppSettings["thoigianhoc"].ToString())
            {
                EditAppSetting("thoigianhoc", numdTime.Value.ToString());
                checks = checks + 1;
            }

            if (numTimeCard.Value.ToString() != ConfigurationManager.AppSettings["thoiGianHaiLanQuetThe"].ToString())
            {
                EditAppSetting("thoiGianHaiLanQuetThe", numTimeCard.Value.ToString());
                checks = checks + 1;
            }
            if(checks>0)
            {
                MessageBox.Show("Đã Lưu Thiết Lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void EditAppSetting(string key, string value)
        {
            try
            {
                string configPath = Path.Combine(System.Environment.CurrentDirectory, "Diem Danh.exe");
                Configuration config = ConfigurationManager.OpenExeConfiguration(configPath);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không đủ quyền truy cập file, vui lòng chạy chương trình với quyền cao nhất"+System.Environment.NewLine+ex.Message);
            }
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}