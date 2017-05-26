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
using System.Windows.Media;
using Project_Diem_Danh.DTO;
using Project_Diem_Danh.DAO;
using Project_Diem_Danh.Report;
using System.Configuration;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Project_Diem_Danh
{
    public partial class FrmUser : DevExpress.XtraEditors.XtraForm
    {
        public static int flag = 0;
        private String IDGiangVien;
        public String IDGiangVien1
        {
            get { return IDGiangVien; }
            set { IDGiangVien = value; }
        }

        private String MaHP = String.Empty;
        private String TenHP = String.Empty;

        public FrmUser(String IDGV)
        {
            this.IDGiangVien1 = IDGV;
            InitializeComponent();
        }

        private bool TypeUser = false;

        private void FrmUser_Load(object sender, EventArgs e)
        {
            Flashing fl = new Flashing();
            try
            {
                //chạy flashing
                
                fl.ShowSplash();
                ShowHocPhanByIDGiangVien(IDGiangVien1);

                ShowInfoGiangVienByID(IDGiangVien1);
                //khi form load ta sẽ load mã lớp với mã giảng viên tương ứng vào trong layoutPannal
                setColor();
                if (TypeUser == true)
                {
                    aDMINToolStripMenuItem.Visible = true;
                    ShowAllDataByAdmin();
                }
                else
                    aDMINToolStripMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // EndFlashing 
                fl.CloseSplash();
                this.Activate();
            }
        }
   

        private void ShowAllDataByAdmin()
        {
            String sqlString1 = @"EXEC getAllTableTEMPDIEMDANH";
            String sqlString2 = @"EXEC getAlllistDiemDanhByMaHocPhan";
            try
            {
                DataTable dt1 = TempDiemDanhDAO.Instance.getAllTableTemDiemDanh(sqlString1);
                if (dt1 != null)
                {

                    grdDuLieuTho.DataSource = dt1;
                }
                DataTable dt2 = DiemDanhDAO.Instance.getAllTableDiemDanh(sqlString2);
                if (dt2 != null)
                {

                    grdDuLieuChuan.DataSource = dt2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowInfoGiangVienByID(String IDGiangVien)
        {
            try
            {
                GiangVien GV = GiangVienDAO.Instance.getGiangVienByID(IDGiangVien);
                txtMaKhoa.Text = GV.MaKhoa;
                txtFullName.Text = GV.HoDem + " " + GV.Ten;
                txtPhone.Text = GV.SoDT;
                txtemail.Text = GV.Email;
                txtAddress.Text = GV.DiaChi;
                txtID.Text = GV.MaGiangVien;
                TypeUser = GV.TypeUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowHocPhanByIDGiangVien(String sql)
        {
            List<HocPhan> dshocphan = HocPhanDAO.Instance.getListHocPhanByIDGiangVien(sql);
            foreach (HocPhan i in dshocphan)
            {
                Button btnHocPhan = new Button() { Width = HocPhanDAO.WidthButton, Height = HocPhanDAO.HeightButton };
                btnHocPhan.Text = i.TenHocPhan + System.Environment.NewLine + "(" + i.MaHocPhan + ")";
                btnHocPhan.ForeColor = System.Drawing.Color.White;
                btnHocPhan.FlatStyle = FlatStyle.Flat;
                btnHocPhan.FlatAppearance.BorderSize = 1;
                btnHocPhan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(104, 33, 122);
                btnHocPhan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(104, 33, 122);
                btnHocPhan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(16, 124, 16);
                btnHocPhan.Click += btnHocPhan_Click;
                btnHocPhan.Tag = i;
                pnlLayout_ListClass.Controls.Add(btnHocPhan);
            }
        }

        private void ShowDanhSachLopHocByMaHocPhan(String MaHocPhan)
        {
            try
            {
                DataTable dt1 = TempDiemDanhDAO.Instance.getTableTEMPDIEMDANHByMaHocPhan(MaHocPhan);
                DataTable dt2 = DiemDanhDAO.Instance.getListDiemDanhByMaHocPhan(MaHocPhan);

                grdDuLieuTho.DataSource = dt1;

                grdDuLieuChuan.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            try
            {
                String MaHocPhan = ((sender as Button).Tag as HocPhan).MaHocPhan;
                TenHP = ((sender as Button).Tag as HocPhan).TenHocPhan;
                MaHP = MaHocPhan;
                ShowDanhSachLopHocByMaHocPhan(MaHocPhan);
                HocPhan hp = HocPhanDAO.Instance.getHocPhanByID(MaHocPhan);
                lblTenLop.Text = hp.TenHocPhan.ToString();
                TrangThaiTuanHoc TrangThai = TrangThaiTuanHocDAO.Instance.getTrangThaiTuanHocByMaHocPhan(MaHocPhan);
                lblSoLuong.Text = hp.SoTinChi.ToString();
                txtTotalBuoiHoc.Text = TrangThai.Trangthai.ToString();
                int times = Convert.ToInt32(ConfigurationManager.AppSettings["thoigian1tiet"].ToString()) * Convert.ToInt32(hp.SoTinChi.ToString());
                if (hp.SoTinChi > 1)
                {
                    times = times + (hp.SoTinChi - 1) * 5;
                }
                FrmConfigSetting.EditAppSetting("thoigianhoc", times.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể đáp ứng yêu cầu, Vui lòng liên hệ quản trị để được hổ trợ","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Thiet lap mau nen cho giao dien
        private void setColor()
        {
            btnDiemDanh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            btnExportToExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
        }

        private void DiemDanh()
        {
            if (MaHP == "" || MaHP == String.Empty)
            {
                MessageBox.Show("Mời Chọn Lớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FrmRollCall frmrollcall = new FrmRollCall(MaHP, TenHP) { };

                frmrollcall.ShowDialog();
                ShowDanhSachLopHocByMaHocPhan(MaHP);
            }
        }

        private void Exit()
        {
            DialogResult result = MessageBox.Show("Xác Nhận Thoát?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();

            }
        }

        private void ExportToExcel()
        {
            FrmExport frn = new FrmExport();
            frn.ShowDialog();
            if (flag != 0)
            {
                SaveFileDialog mydialog = new SaveFileDialog();
                mydialog.Filter = "Excel file(*.xls)|*.xls";
                mydialog.Title = "Chọn Nơi Lưu File:";
                mydialog.CheckPathExists = true;

                if (mydialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        if (flag == 1)
                        {
                            grdDuLieuTho.ExportToXls(mydialog.FileName);
                            MessageBox.Show("Đã lưu file thành công vào:" + System.Environment.NewLine + mydialog.FileName, "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (flag == 2)
                        {
                            grdDuLieuChuan.ExportToXls(mydialog.FileName);
                            MessageBox.Show("Đã lưu file thành công vào:" + System.Environment.NewLine + mydialog.FileName, "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lưu file không thành công" + ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Prints()
        {
            FrmExport frn = new FrmExport();
            frn.ShowDialog();
            if (flag != 0)
            {
                try
                {
                    if (flag == 1)
                    {
                        grdDuLieuTho.ShowPrintPreview();
                    }
                    else grdDuLieuChuan.ShowPrintPreview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi In Ân");
                }
            }
        }

        private void điểmDanhToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DiemDanh();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Prints();
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prints();
        }

        private void xuấtFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnExportToExcel_Click_1(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Exit();
        }

        private void thayĐổiMậtKhẩuToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmChangeAccount frmchangacc = new FrmChangeAccount(IDGiangVien);
            frmchangacc.ShowDialog();
        }

        private void thayĐổiMàuNềnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng Xuất?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }

        private void chúngTôiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmInfo frminfo = new FrmInfo();
            frminfo.ShowDialog();
        }

        private void aDMINToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmAdmin frmad = new FrmAdmin();
            frmad.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DiemDanh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Exit();
        }

        private void thiếtLậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfigSetting cofig = new FrmConfigSetting();
            cofig.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ administrator để được trợ giúp!", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DiemDanh();
        }

        private void thiếtLậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConfigSetting cofig = new FrmConfigSetting();
            cofig.ShowDialog();
        }

        private void thoátToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void inDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prints();
        }

        private void xuấtFileExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void hộpThưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Request frmRequest = new Request();
            frmRequest.ShowDialog();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTutorialAppcs tutorial = new FrmTutorialAppcs();
            tutorial.ShowDialog();
        }

        private void gridView2_RowClick(object sender, RowClickEventArgs e)
        {
           try
           {
               int rowHandle = e.RowHandle;
               Object val1 = gridView2.GetRowCellValue(rowHandle, gridView2.Columns[0]);
               Object val2 = gridView2.GetRowCellValue(rowHandle, gridView2.Columns[3]);
               if (val1 != null && val2 !=null)
               {
                   FrmShowDetailSinhVien frm = new FrmShowDetailSinhVien((String)val1, (String)val2);
                   frm.Show();
               }
           }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                int rowHandle = e.RowHandle;
                
                Object val1 = gridView1.GetRowCellValue(rowHandle, gridView1.Columns[0]);
                Object val2 = gridView1.GetRowCellValue(rowHandle, gridView1.Columns[3]);
                if (val1 != null)
                {
                    FrmShowDetailSinhVien frm = new FrmShowDetailSinhVien((String)val1, (String)val2);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTutorialAppcs frm = new FrmTutorialAppcs();
            frm.ShowDialog();
        }
    }
}