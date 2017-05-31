using Microsoft.Win32;
using Project_Diem_Danh.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Diem_Danh
{
    public partial class FrmLogin : Form
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public FrmLogin()
        {
            Flashing fl = new Flashing();
            fl.ShowSplash();
            InitializeComponent();
            rkApp.SetValue("registryDiemDanh", Application.ExecutablePath.ToString());
            fl.CloseSplash();
            this.Activate();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Kiem tra csdl ve du lieu dua vao
            String Username = txtUserName.Text.Trim();
            String Password = txtPass.Text.Trim();
            if (Username == "" && Password == "")   
            {
                MessageBox.Show("Bạn phải nhập đầy đủ UserName và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (GiangVienDAO.Instance.CheckLogin(Username, Encrytion.Instance.md5(Password)))
                    {
                        FrmUser frmuser = new FrmUser(Username);
                        this.Hide();
                        frmuser.ShowDialog();
                        this.Show();
                        txtPass.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Thử lại Password hoặc Username khác", "Đăng Nhập Không Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Text = "";
                        txtUserName.Text = "";
                        txtUserName.Focus();
                    }
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("Không thể kết nối. Vui lòng kiểm tra lại"+System.Environment.NewLine+ex.Message);
                    
                }
            }
        }

        private void tbnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Muốn Dừng Chương Trình?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
                     Application.Exit();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.ToUpper();
        }

        private void FrmLogin_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Liên hệ quản trị viên nếu quên tài khoản!", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
