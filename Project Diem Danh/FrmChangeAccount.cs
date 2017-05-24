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
using Project_Diem_Danh.DTO;
using Project_Diem_Danh.DAO;

namespace Project_Diem_Danh
{
    public partial class FrmChangeAccount : DevExpress.XtraEditors.XtraForm
    {
        private String iD;

        public String ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public FrmChangeAccount(String ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void FrmChangeAccount_Load(object sender, EventArgs e)
        {
            ShowInfoAccount(ID);
            this.Text = "Xin Chào " + ID;
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
        }

        private void ShowInfoAccount(String id)
        {
            try
            {
                GiangVien GV = GiangVienDAO.Instance.getGiangVienByID(id);
                txtMaKhoa.Text = GV.MaKhoa;
                txtFullName.Text = GV.HoDem + " " + GV.Ten;
                txtPhone.Text = GV.SoDT;
                txtemail.Text = GV.Email;
                txtAddress.Text = GV.DiaChi;
                txtID.Text = GV.MaGiangVien;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangePassword()
        {
            if (CheckPassOld(ID, txtpassOld.Text))
            {
                
                if (txtpassNew.Text == txtpassOld.Text)
                {
                    MessageBox.Show("Không có gì để thay đổi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtpassNew.Text.Length < 60 && txtpassNew.Text.Length > 5)
                   {
                       if (GiangVienDAO.Instance.UpdatePassword(ID, Encrytion.Instance.md5(txtpassNew.Text)))
                       {
                           MessageBox.Show("Đổi mật khẩu thành công!, Đăng xuất và đăng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           this.Close();
                       }
                   }
                    else
                   {
                       MessageBox.Show("Mật khẩu phải nhỏ hơn 60 và lớn hơn 6 ký tự", "Mật Khẩu Không Đúng Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu Cũ Không Đúng, Vui Lòng Kiểm Tra Lại!", "Sai Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckPassOld(String id, String pass)
        {
            bool result = false;
            if (GiangVienDAO.Instance.CheckLogin(id, Encrytion.Instance.md5(pass)))
                result = true;
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtpassNew.Text.Trim() == "" && txtpassOld.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else
            {
                ChangePassword();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}