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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using Project_Diem_Danh.DTO;
using Project_Diem_Danh.Report;
using Project_Diem_Danh.DAO;
using System.Globalization;
using System.Collections;


namespace Project_Diem_Danh
{
    public partial class FrmShowDetailSinhVien : DevExpress.XtraEditors.XtraForm
    {
        String MaSV = String.Empty;
        String MaHP = String.Empty;
        public FrmShowDetailSinhVien(String masv, String mahp)
        {
            InitializeComponent();
            MaSV = masv;
            MaHP = mahp;
        }
        public ArrayList addArray(DiemDanh dd)
        {
            ArrayList arl = new ArrayList();
            arl.Add((dd.Tuan_1) != null ? dd.Tuan_1 : "");
            arl.Add((dd.Tuan_2) != null ? dd.Tuan_2 : "");
            arl.Add((dd.Tuan_3) != null ? dd.Tuan_3 : "");
            arl.Add((dd.Tuan_4) != null ? dd.Tuan_4 : "");
            arl.Add((dd.Tuan_5) != null ? dd.Tuan_5 : "");
            arl.Add((dd.Tuan_6) != null ? dd.Tuan_6 : "");
            arl.Add((dd.Tuan_7) != null ? dd.Tuan_7 : "");
            arl.Add((dd.Tuan_8) != null ? dd.Tuan_8 : "");
            arl.Add((dd.Tuan_9) != null ? dd.Tuan_9 : "");
            arl.Add((dd.Tuan_10) != null ? dd.Tuan_10 : "");
            arl.Add((dd.Tuan_11) != null ? dd.Tuan_11 : "");
            arl.Add((dd.Tuan_12) != null ? dd.Tuan_12 : "");
            arl.Add((dd.Tuan_13) != null ? dd.Tuan_13 : "");
            arl.Add((dd.Tuan_14) != null ? dd.Tuan_14 : "");
            arl.Add((dd.Tuan_15) != null ? dd.Tuan_15 : "");
            arl.Add((dd.Tuan_16) != null ? dd.Tuan_16 : "");
            arl.Add((dd.Tuan_17) != null ? dd.Tuan_17 : "");
            return arl;
        }
        private void FrmShowDetailSinhVien_Load(object sender, EventArgs e)
        {
           
            if (MaSV != "" && MaHP != "")
            {
                //hien thi thong tin sinh vien
                ShowInfoHocPhan();
                ShowInFoSinhVien();
                try
                {
                    DiemDanh dd = DiemDanhDAO.Instance.getTableDIEMDANHByIdMaHocPhan(MaSV, MaHP);
                    ArrayList ListTuan = addArray(dd);
                    DataTable dt = new DataTable();
                    txtlanhoc.Text = dd.Lanhoc.ToString();
                    int sobh = getSoBuoiHoc(MaHP);
                    if (sobh != -1)
                    {
                        txtsobuoihoc.Text = string.Format("{0}/{1}", dd.SoBuoiHoc, sobh);
                        txtsobuoiphep.Text = dd.SoBuoiPhep.ToString();
                        txtsobuoivang.Text = string.Format("{0}/{1}", sobh - dd.SoBuoiHoc - dd.SoBuoiPhep, sobh);
                    }else
                    {
                        txtsobuoihoc.Text = dd.SoBuoiHoc.ToString();
                        txtsobuoiphep.Text = dd.SoBuoiPhep.ToString();
                    }
                    
                    txthocky.Text = dd.Hocky.ToString();
                    //Adding columns to datatable
                    dt.Columns.Add("tuan", typeof(int));
                    dt.Columns.Add("ngayhoc", typeof(string));
                    dt.Columns.Add("giovao", typeof(String));
                    dt.Columns.Add("giora", typeof(string));
                    int k = 0;
                    foreach (String i in ListTuan)
                    {
                        DataRow row;
                        row = dt.NewRow();
                        row["tuan"] = k + 1;
                        if (i != "")
                        {
                            String[] chuoi = i.Split('-');
                            if (chuoi.Length == 1)
                            {
                                row["ngayhoc"] = chuoi[0].Trim();
                            }
                            else if (chuoi.Length > 1 && chuoi.Length <= 2)
                            {
                                row["ngayhoc"] = chuoi[0].Trim();
                                row["giovao"] = chuoi[1].Trim();
                            }
                            else if (chuoi.Length > 2)
                            {
                                row["ngayhoc"] = chuoi[0].Trim();
                                row["giovao"] = chuoi[1].Trim();
                                row["giora"] = chuoi[2].Trim();
                            }
                        }
                        else
                        {
                            row["ngayhoc"] = "";
                            row["giovao"] = "";
                            row["giora"] = "";
                        }
                        k++;
                        dt.Rows.Add(row);
                    }
                    gridControl1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
            
        }
        public int getSoBuoiHoc(String Mahp)
        {
            int kq = -1;
            try
            {
                DataRow DT = NhomDAO.Instance.getHocPhanByID(Mahp);
                kq = Convert.ToInt32(DT["SOBUOIHOC"].ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }

        public void ShowInfoHocPhan()
        {
            try
            {
                DataRow hp = NhomDAO.Instance.getHocPhanByID(MaHP);
                txttenhp.Text = hp["TENHOCPHAN"].ToString();
                txtsotc.Text = hp["SOTINCHI"].ToString();
                txtmahp.Text = hp["MAHOCPHAN"].ToString();
                txtNhom.Text = string.Format("{0} - {1}", hp["MANHOM"], hp["TENNHOM"]);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        public void ShowInFoSinhVien()
        {
            try
            {
                SinhVien sv = SinhVienDAO.Instance.getInfoSinhVienByID(MaSV);
                this.Text = string.Format("{0} {1} - {2}", sv.HoDem, sv.Ten, MaHP);
                txtMaSV.Text = sv.MaSV;
                txtID.Text = "";
                txtID.Text = sv.Id;
                txtHoTen.Text = "";
                txtHoTen.Text = string.Format("{0} {1}", sv.HoDem, sv.Ten);
                txtGioiTinh.Text = "";
                txtGioiTinh.Text = sv.GioiTinh.ToString();
                DateTime dt = Convert.ToDateTime(sv.NgaySinh.ToString());
                txtNgaySinh.Text = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                txtLop.Text = "";
                txtLop.Text = LopDAO.Instance.getTenlopByMalop(sv.MaLop);
                txtDiaChi.Text = "";
                txtDiaChi.Text = sv.DiaChi;
                pictureBox1.Controls.Clear();
                if (sv.HinhDaiDien == null)
                {
                    pictureBox1.Image = Image.FromFile(@"Images\no_avatar.png");
                }
                else
                {
                    pictureBox1.Image = ProcessImage.Instance.byteArrayToImage(sv.HinhDaiDien.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check whether the GridControl can be previewed.
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("Không tồn tại dữ liệu");
                return;
            }

            // Open the Preview window.

            gridControl1.ShowPrintPreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}