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
using Project_Diem_Danh.DAO;
using Project_Diem_Danh.DTO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraLayout;
using Project_Diem_Danh.Report;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
using System.Threading;
using System.Text.RegularExpressions;

namespace Project_Diem_Danh
{
    public partial class FrmAdmin : DevExpress.XtraEditors.XtraForm
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            Flashing fl = new Flashing();
            try
            {
                fl.ShowSplash();
                pnlMenu.BackColor = System.Drawing.Color.FromArgb(0, 166, 90);
                cbbgetTableName.SelectedIndex = 0;
                cbbAllTable.SelectedIndex = 0;
                lstvReport.Columns.Add("Sự Kiện Log", lstvReport.Size.Width - 10);
                lstvReport.View = View.Details;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fl.CloseSplash();
                this.Activate();
            }
            
        }

        private DataTable dt;
        private SqlCommandBuilder scb;
        private SqlDataAdapter sda;

        private void ShowAllTableByComboxSelected(int key)
        {
            try
            {
                switch (key)
                {
                    //EXEC getTableTemDiemDanh
                    case 0:
                        {
                            String sqlString = @"EXEC getTableTemDiemDanh";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._ConnectionString);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    //Exec getTableDiemDanh
                    case 1:
                        {
                            String sqlString = @"Exec getTableDiemDanh";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    //EXEC getTableSinhVien
                    case 2:
                        {
                            String sqlString = @"EXEC getTableSinhVien";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    //EXEC getTableSinhGiangVien
                    case 3:
                        {
                            String sqlString = @"EXEC getTableSinhGiangVien";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    //EXEC getTableKhoa
                    case 4:
                        {
                            String sqlString = @"EXEC getTableKhoa";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    // getTableLop
                    case 5:
                        {
                            String sqlString = @"EXEC getTableLop";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    //EXEC getTableSinhHocPhan
                    case 6:
                        {
                            String sqlString = @"EXEC getTableSinhHocPhan";
                            dt = new DataTable();
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    //EXEC getTableTrangThaiTuanHoc
                    case 7:
                        {
                            dt = new DataTable();
                            String sqlString = @"EXEC getTableTrangThaiTuanHoc";
                            DataProvider.Instance.OpenConnect();
                            sda = new SqlDataAdapter(sqlString, DataProvider.Instance._Connection);
                            sda.Fill(dt);
                            gridcData.Controls.Clear();
                            gridcData.DataSource = null;
                            gridcData.DataSource = dt;
                            DataProvider.Instance.CloseConnect();
                        }
                        break;
                    default: { MessageBox.Show("Tùy Chọn Không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbgetTableName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Flashing fl = new Flashing();

            try
            {
                fl.ShowSplash();
                if (cbbgetTableName.SelectedIndex != -1)
                {
                    if (cbbgetTableName.SelectedIndex >= 2 || cbbgetTableName.SelectedIndex < 0)
                    {
                        txtFilter.Visible = false;
                        btnFilter.Visible = false;
                    }
                    else
                    {
                        txtFilter.Visible = true;
                        btnFilter.Visible = true;
                    }
                    ShowAllTableByComboxSelected(Convert.ToInt32(cbbgetTableName.SelectedIndex.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fl.CloseSplash();
                this.Activate();
            }
        }

        private void checkSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKichThuoc.CheckState == CheckState.Checked)
            {
                gridcData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                gridcData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Title = "Chọn File Excel:";
            myFile.CheckFileExists = true;
            myFile.CheckPathExists = true;
            myFile.Filter = "Excel File(*.xls; *.xlsx)|*.xls; *.xlsx" + "|All File (*.*)|*.*";
            if (myFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = myFile.FileName;
            }
        }

        private void btnEImport_Click(object sender, EventArgs e)
        {
            //Flashing.ShowSplash();
            Flashing fl = new Flashing();
            fl.ShowSplash();
            if (cbbAllTable.SelectedIndex != -1 && txtPath.Text.Trim() != "")
            {
                ShowMessageResult("Đang tiến hành Import, vui lòng chờ......", 1);
                bool check = checkBox.Checked;
                ImportData(cbbAllTable.SelectedIndex, txtPath.Text.Trim(), check);
            }
           fl.CloseSplash();
           this.Activate();
        }

        private void ShowMessageResult(String Title, int NumError)
        {
            ListViewItem liv = new ListViewItem();
            if (NumError == 0)
            {
                liv.ForeColor = Color.Red;
                liv.Text = "[" + DateTime.Now.ToString() + "]      " + Title;
                lstvReport.Items.Add(liv);
            }
            else
            {
                liv.Text = "[" + DateTime.Now.ToString() + "]      " + Title;
                liv.ForeColor = Color.Black;
                lstvReport.Items.Add(liv);
            }
        }

        private void ImportData(int key, String PathExcelFile, bool Checked)
        {
            if (key < -1 || key == 0)
            {
                ShowMessageResult("Bạn không thể Import vào bảng dữ liệu " + cbbAllTable.SelectedItem.ToString(), 0);
                return;
            }
            try
            {
                String Sheet = Importdata.Instance.getNameSheetExcel(PathExcelFile);

                switch (key)
                {
                    case 1:
                        {
                            String ExcelDataQuery = @"select MASINHVIEN, MAHOCPHAN, LANHOC, HOCKY,TUAN_1,TUAN_2,TUAN_3,TUAN_4,TUAN_5,TUAN_6,TUAN_7,TUAN_8,TUAN_9,TUAN_10,TUAN_11,TUAN_12,TUAN_13,TUAN_14,TUAN_15,TUAN_16,TUAN_17,SOBUOIHOC, SOBUOIPHEP FROM " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "DIEMDANH", Checked))
                                    ShowMessageResult("Import thành công -  DIEMDANH", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - DIEMDANH", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    case 2:
                        {
                            String ExcelDataQuery = @"select ID, HODEM, TEN, NGAYSINH, GIOITINH, NOISINH, IMAGES, MASINHVIEN, MALOP FROM " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "SINHVIEN", Checked))
                                    ShowMessageResult("Import thành công -  SINHVIEN", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - SINHVIEN", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    case 3:
                        {
                            String ExcelDataQuery = @"select MAGIANGVIEN, HODEM, TEN, DIACHI, SODIENTHOAI, NGAYSINH, EMAIL, PASSWORD_USER, MAKHOA, TYPE_USER FROM " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "GIANGVIEN", Checked))
                                    ShowMessageResult("Import thành công -  GIANGVIEN!", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - GIANGVIEN", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    case 4:
                        {
                            String ExcelDataQuery = @"select MAKHOA, TENKHOA, NAMTHANHLAP, DIENTHOAI FROM " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "KHOA", Checked))
                                    ShowMessageResult("Import thành công -  KHOA", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - KHOA", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    case 5:
                        {
                            String ExcelDataQuery = @"select MALOP, TENLOP, HEDAOTAO, NAMNHAPHOC, MAKHOA FROM " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "LOP", Checked))
                                    ShowMessageResult("Import thành công -  LOP", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - LOP", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    case 6:
                        {
                            String ExcelDataQuery = @"select MAHOCPHAN, TENHOCPHAN, SOTINCHI, MAGIANGVIEN FROM " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "HOCPHAN", Checked))
                                    ShowMessageResult("Import thành công -  HOCPHAN", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - HOCPHAN", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    case 7:
                        {
                            String ExcelDataQuery = @"select MAHOCPHAN, SOBUOIHOC FROM  " + "[" + Sheet + "$]";
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "TRANGTHAITUANHOC", Checked))
                                    ShowMessageResult("Import thành công -  TRANGTHAITUANHOC", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - TRANGTHAITUANHOC", 0);
                            }
                            catch (Exception ex)
                            {
                                ShowMessageResult(ex.Message, 0);
                            }
                        }
                        break;
                    default: ShowMessageResult("Tùy chọn không có hiệu lực, vui lòng kiểm tra lại!", 0); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbAllTable.SelectedIndex != -1 && txtTitleFile.Text.Trim() != "")
                {
                    ShowMessageResult("Đang tiến hành Export, vui lòng chờ......", 1);
                    ExportData(cbbAllTable.SelectedIndex, txtTitleFile.Text.Trim());
                }
                else
                    ShowMessageResult("Vui Lòng kiểm tra lại tùy chọn danh mục và tiêu đề!", 0);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportData(int key, String Title)
        {
            switch (key)
            {
                //EXEC getTableTemDiemDanh
                case 0:
                    {
                        String sqlString = @"EXEC getTableTemDiemDanh";
                        try
                        {
                            DataTable dt = TempDiemDanhDAO.Instance.getAllTableTemDiemDanh(sqlString);

                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công TEMPDIEMDANH", 1);
                            else
                                ShowMessageResult("Không Thể Export TEMPDIEMDANH", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                //Exec getTableDiemDanh
                case 1:
                    {
                        try
                        {
                            String sqlString = @"Exec getTableDiemDanh";
                            DataTable dt = DiemDanhDAO.Instance.getAllTableDiemDanh(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công DIEMDANH", 1);
                            else
                                ShowMessageResult("Không Thể Export DIEMDANH", 0);
                        }

                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                //EXEC getTableSinhVien
                case 2:
                    {
                        try
                        {
                            String sqlString = @"EXEC GetTableSinhVienToExport";
                            DataTable dt = SinhVienDAO.Instance.getAllTableSinhVien(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công SINHVIEN", 1);
                            else
                                ShowMessageResult("Không Thể Export SINHVIEN", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                //EXEC getTableSinhGiangVien
                case 3:
                    {
                        try
                        {
                            String sqlString = @"EXEC getTableSinhGiangVien";
                            DataTable dt = GiangVienDAO.Instance.getAllTableGiangVien(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công GIANGVIEN", 1);
                            else
                                ShowMessageResult("Không Thể Export GIANGVIEN", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                //EXEC getTableKhoa
                case 4:
                    {
                        try
                        {
                            String sqlString = @"EXEC getTableKhoa";
                            DataTable dt = KhoaDAO.Instance.getAllTableKhoa(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công KHOA", 1);
                            else
                                ShowMessageResult("Không Thể Export KHOA", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                // getTableLop
                case 5:
                    {
                        try
                        {
                            String sqlString = @"EXEC getTableLop";
                            DataTable dt = LopDAO.Instance.getAllTableLop(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công LOP", 1);
                            else
                                ShowMessageResult("Không Thể Export LOP", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                //EXEC getTableSinhHocPhan
                case 6:
                    {
                        try
                        {
                            String sqlString = @"EXEC getTableSinhHocPhan";
                            DataTable dt = HocPhanDAO.Instance.getAllTableHocPhan(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công HOCPHAN", 1);
                            else
                                ShowMessageResult("Không Thể Export HOCPHAN", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                //EXEC getTableTrangThaiTuanHoc
                case 7:
                    {
                        try
                        {
                            String sqlString = @"EXEC getTableTrangThaiTuanHoc";
                            DataTable dt = TrangThaiTuanHocDAO.Instance.getAllTableTrangThaiTuanHoc(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công TRANGTHAITUANHOC", 1);
                            else
                                ShowMessageResult("Không Thể Export TRANGTHAITUANHOC", 0);
                        }
                        catch (Exception d)
                        {
                            ShowMessageResult(d.Message, 0);
                        }
                    }
                    break;
                default: { MessageBox.Show("Tùy Chọn Không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    break;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (f == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbgetTableName.SelectedIndex != -1)
                {
                    scb = new SqlCommandBuilder(sda);
                    sda.Update(dt);
                    dt.AcceptChanges();
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (Exception de)
            {
                MessageBox.Show(de.Message);
            }
            
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbgetTableName.SelectedIndex != -1)
                {
                    foreach (DataGridViewRow row in gridcData.SelectedRows)
                        gridcData.Rows.Remove(row);
                }
            }
            catch (Exception ed)
            { MessageBox.Show(ed.Message); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cbbgetTableName.SelectedIndex != -1)
                ShowAllTableByComboxSelected(cbbgetTableName.SelectedIndex);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            
                FrmGetTitleToExport getTitle = new FrmGetTitleToExport();
                getTitle.ShowDialog();
                String Title = FrmGetTitleToExport.Title;
                if (Title != null)
                {
                    if (Title != "" && cbbgetTableName.SelectedIndex != -1)
                    {
                        try
                        {
                            ExportData(cbbgetTableName.SelectedIndex, Title);
                            MessageBox.Show("Đã Lưu file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            {
                if (result == DialogResult.OK)
                    this.Close();
            }
        }

        private String[] tmp = { };

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog myfile = new OpenFileDialog();
            myfile.CheckFileExists = true;
            myfile.Filter = "(Images File *.png)|*.png";
            myfile.Multiselect = true;
            if (myfile.ShowDialog() == DialogResult.OK)
            {
                tmp = myfile.FileNames;
                foreach (String i in tmp)
                {
                    txtPaths.Text += i + " ";
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtPaths.Text != "")
            {
                Flashing fl = new Flashing();
                try
                {
                    fl.ShowSplash();
                    if (tmp != null)
                    {
                        foreach (String f in tmp)
                        {
                            String masv = System.IO.Path.GetFileNameWithoutExtension(f);
                            ProcessImage.Instance.Save_ImageIntoDB(masv, ProcessImage.Instance.ReadFile(f));
                            ShowMessageResult("Đã upload " + masv, 1);
                        }
                    }
                }
                catch (Exception ee)
                {
                    ShowMessageResult(ee.Message, 0);
                }
                finally
                {
                    // EndFlashing 
                    fl.CloseSplash();
                    this.Activate();
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbgetTableName.SelectedIndex != -1)
                    FilterIndex();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Lỗi Khi lọc dữ liệu" + System.Environment.NewLine + Ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void FilterIndex()
        {
            string filter = "MASINHVIEN='" + txtFilter.Text + "'";
            CheckExist((DataTable)this.gridcData.DataSource, filter);
        }

        //Loc du lieu trong datagridview voi phuong thuc Select(filterExpression)
        private void CheckExist(DataTable tbl, string filterExpression)
        {
            if (filterExpression == "")
            {
                return;
            }
            DataRow[] rows = tbl.Select(filterExpression);
            if (rows.Length <= 0)
            {
                return;
            }
            //Thể hiện dữ liệu tìm được ra dataGridViewCustomer
            tbl = ((DataTable)this.gridcData.DataSource).Clone();
            int k = tbl.Columns.Count;
            for (int i = 0; i < rows.Length; i++)
            {
                //So cot khong du ngay cho nay, can kiem tra lai
                DataRow row = tbl.NewRow();
                for (int j = 0; j < k; j++)
                {
                    row[j] = rows[i].ItemArray[j].ToString();
                }
                tbl.Rows.Add(row);
            }
            gridcData.DataSource = tbl;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbgetTableName.SelectedIndex != -1)
                    PrintData(cbbgetTableName.SelectedIndex);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintData(int key)
        {
            switch (key)
            {
                case 0:
                    {
                        FrmIprintDIEMDANH frmprintdiemdanh = new FrmIprintDIEMDANH(dt, 0);
                        frmprintdiemdanh.ShowDialog();
                    } break;
                case 1:
                    {
                        FrmIprintDIEMDANH frmprintdiemdanh = new FrmIprintDIEMDANH(dt, 1);
                        frmprintdiemdanh.ShowDialog();
                    } break;
                default:
                    {
                        MessageBox.Show("Hệ thống vẫn đang hoàn thiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } break;
            }
        }

        public void LoadtableHocphan()
        {
            String sql = "select * from hocphan";
            gridHocPhanAdmin.DataSource = HocPhanDAO.Instance.getAllTableHocPhan(sql);
        }

        public void LoadtableDiemDanh()
        {
            String sql = "select * from diemdanh";
            gridiemDanhDL.DataSource = HocPhanDAO.Instance.getAllTableHocPhan(sql);
        }
        public void LoadtableTrangThaiTuanHoc()
        {
            String sql = "Select TRANGTHAITUANHOC.MAHOCPHAN, TENHOCPHAN, SOBUOIHOC, CHECKDIEMDANH from TRANGTHAITUANHOC inner join HOCPHAN ON TRANGTHAITUANHOC.MAHOCPHAN = HOCPHAN.MAHOCPHAN";
            gridTrangThaiTuanHoc.DataSource = HocPhanDAO.Instance.getAllTableHocPhan(sql);
        }

        private void backstageViewTabItem5_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

            cbtrangThaiDiemDanh.SelectedIndex = 0;
            txtTrangThaiSua.SelectedIndex = 0;
            String sqlGetTableTrangThai = "Select TRANGTHAITUANHOC.MAHOCPHAN, TENHOCPHAN from TRANGTHAITUANHOC inner join HOCPHAN ON TRANGTHAITUANHOC.MAHOCPHAN = HOCPHAN.MAHOCPHAN";
            String sqlGetTableHocPhan = "SELECT MAHOCPHAN, TENHOCPHAN FROM HOCPHAN";
            getAllTabletoCombox(cbHPTrangThai, sqlGetTableHocPhan, "TENHOCPHAN", "MAHOCPHAN");

            getAllTabletoCombox(cbHPSuaTrangThai, sqlGetTableTrangThai, "TENHOCPHAN", "MAHOCPHAN");

            String sqlGetTableGiangVien = "Select MAGIANGVIEN, (HODEM +' ' + TEN +'('+MAGIANGVIEN+')') AS HOTEN from giangvien";
            getAllTabletoCombox(cbMaGV, sqlGetTableGiangVien, "HOTEN", "MAGIANGVIEN");
            getAllTabletoCombox(txmMaGVedit, sqlGetTableGiangVien, "HOTEN", "MAGIANGVIEN");
            //txmMaGVedit
            LoadtableHocphan();
            LoadtableDiemDanh();
            LoadtableTrangThaiTuanHoc();
        }
        public void getAllTabletoCombox(System.Windows.Forms.ComboBox cbb, String sql, String DisplayMember, String ValueMember)
        {
            DataTable dt = DataProvider.Instance.LoadAllTable(sql);
            cbb.DataSource = dt;
            cbb.DisplayMember = DisplayMember;
            cbb.ValueMember = ValueMember;
        }
        /// <summary>
        /// Thêm Học Phần
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String mahp = txtMaHP.Text.ToString().Trim();
                String tenhp = txtTenHP.Text.ToString().Trim();
                String magv = cbMaGV.SelectedValue.ToString();
                if (mahp != "" && tenhp != "" && txtSoTC.Text.ToString().Trim() != ""  && magv != "")
                {
                    int sotc = Convert.ToInt32(txtSoTC.Text.ToString().Trim());
                    if (!HocPhanDAO.Instance.issetHocPhan(mahp))
                    {
                        AddHocPhan(mahp, tenhp, sotc, magv);
                    }
                    else
                    {
                        lblkq.ForeColor = Color.Red;
                        lblkq.Text = "Học phần " + tenhp + "(" + mahp + ") đã tồn tại";
                    }
                }
                else
                {
                    lblkqedit.ForeColor = Color.Red;
                    lblkqedit.Text = "Các trường dữ liệu không được rỗng!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void AddHocPhan(String mahp, String tenhp, int sotc, String magv)
        {
            if (HocPhanDAO.Instance.AddNewHP(mahp, tenhp, sotc, magv) > 0)
            {

                if (TrangThaiTuanHocDAO.Instance.AddNewHocPhan_Trangthaituanhoc(mahp) > 0)
                {
                    lblkq.ForeColor = Color.Black;
                    lblkq.Text = "Đã thêm thành công học phần " + tenhp + "(" + mahp + ")";
                    LoadtableHocphan();
                }
                else
                {
                    lblkq.ForeColor = Color.Red;
                    lblkq.Text = "Đã có lỗi xãy ra. Không thêm được Học Phần" + tenhp + "(" + mahp + ")";
                }
            }
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtMaHP.Text = "";
            txtSoTC.Text = "";
            txtTenHP.Text = "";
            txtMaHP.Focus();
        }
        /// <summary>
        /// Sửa học phần
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                String mahp = txtMaHPedit.Text.ToString().Trim();
                String tenhp = txtTenHPedit.Text.ToString().Trim();
                int sotc = Convert.ToInt32(txtSoTCedit.Text.ToString().Trim());
                String magv = txmMaGVedit.SelectedValue.ToString();
                if (HocPhanDAO.Instance.issetHocPhan(mahp))
                {
                    if (mahp != "" && tenhp != "" && sotc > 0 && magv != "")
                    {
                        if (GiangVienDAO.Instance.issetGiangVien(magv))
                        {
                            updateHocPhan(mahp, tenhp, sotc, magv);
                        }
                        else
                        {
                            lblkqedit.ForeColor = Color.Red;
                            lblkqedit.Text = "Không có giảng viên phù hợp!";
                        }
                    }
                    else
                    {
                        lblkqedit.ForeColor = Color.Red;
                        lblkqedit.Text = "Các trường dữ liệu không được rỗng!";
                    }
                }
                else
                {
                    lblkqedit.ForeColor = Color.Red;
                    lblkqedit.Text = "Học phần " + tenhp + "(" + mahp + ") Không tồn tại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateHocPhan(String mahp, String tenph, int sotc, String magv)
        {
            if (HocPhanDAO.Instance.UpdateHP(mahp, tenph, sotc, magv) > 0)
            {
                lblkqedit.ForeColor = Color.Black;
                lblkqedit.Text = "Đã sửa thành công học phần " + tenph + "(" + mahp + ")";
                LoadtableHocphan();
            }
            else
            {
                lblkqedit.ForeColor = Color.Red;
                lblkqedit.Text = "Đã có lỗi xãy ra. Không sửa học Phần" + tenph + "(" + mahp + ")";
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaHPedit.Text = gridView1.GetFocusedRowCellDisplayText("MAHOCPHAN").ToString();
            txtTenHPedit.Text = gridView1.GetFocusedRowCellDisplayText("TENHOCPHAN").ToString();
            txtSoTCedit.Text = gridView1.GetFocusedRowCellDisplayText("SOTINCHI").ToString();
            txmMaGVedit.Text = gridView1.GetFocusedRowCellDisplayText("MAGIANGVIEN").ToString();
            txtMaHPdel.Text = gridView1.GetFocusedRowCellDisplayText("MAHOCPHAN").ToString();
        }

        private void btnResetedit_Click(object sender, EventArgs e)
        {
            txtMaHPedit.Text = "";
            txtTenHPedit.Text = "";
            txtSoTCedit.Text = "";
            txmMaGVedit.Text = "";
            txtTenHPedit.Focus();
        }
        /// <summary>
        /// Xóa Học Phần
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            String mahp = txtMaHPdel.Text.ToString().Trim();
            if (HocPhanDAO.Instance.issetHocPhan(mahp))
            {
                DialogResult rs = MessageBox.Show("Bạn Có muốn xóa học phần có mã " + mahp + "?", "Xác Nhận Xóa Học Phần", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DelHocPhan(mahp);
                }
            }
            else
            {
                lblkqxoa.ForeColor = Color.Red;
                lblkqxoa.Text = "Học phần đã chọn không tồn tại, vui lòng kiểm tra lại!";
            }
        }
        
        public void DelHocPhan(String MaHP)
        {
            try
            {
                if (TrangThaiTuanHocDAO.Instance.DelTrangThaiById(MaHP) > 0)
                {
                    if (HocPhanDAO.Instance.DelHocPhanById(MaHP) > 0)
                    {
                        lblkqxoa.ForeColor = Color.Black;
                        lblkqxoa.Text = "Đã xóa học phần có mã: " + MaHP;
                        LoadtableHocphan();
                    }
                    else
                    {
                        lblkqxoa.ForeColor = Color.Red;
                        lblkqxoa.Text = "Không thể xóa học phần có mã: " + MaHP + ", Kiểm tra lại!";
                    }
                }
                else
                {
                    lblkqxoa.ForeColor = Color.Red;
                    lblkqxoa.Text = "Không thể xóa học phần có mã: " + MaHP + ", Kiểm tra lại!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            txtMaSVSdel.Text = gridView2.GetFocusedRowCellDisplayText("MASINHVIEN").ToString();
            txtMaHPSdel.Text = gridView2.GetFocusedRowCellDisplayText("MAHOCPHAN").ToString();
            txtLanHocSdel.Text = gridView2.GetFocusedRowCellDisplayText("LANHOC").ToString();
        }

        public void DelDiemDanhAdmin(String MaSV, String Mahp, int lanhoc)
        {
            if (DiemDanhDAO.Instance.DelDiemdanhByMaSV(MaSV, Mahp, lanhoc) > 0)
            {
                lbldelDD.ForeColor = Color.Black;
                lbldelDD.Text = "Đã Xóa " + MaSV + " ra khỏi danh sách điểm danh";
                LoadtableDiemDanh();
            }
            else
            {
                lbldelDD.ForeColor = Color.Red;
                lbldelDD.Text = "Lỗi! Không thể xóa " + MaSV + "";
            }
        }
        // kiểm tra trường số

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        /// <summary>
        /// Xóa điểm danh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelDD_Click(object sender, EventArgs e)
        {
            try
            {
                String masv = txtMaSVSdel.Text.ToString().Trim();
                String Mahp = txtMaHPSdel.Text.ToString().Trim();
                int lanhoc = 1;
                if (IsNumber(txtLanHocSdel.Text.ToString()) == true)
                {
                    lanhoc = Convert.ToInt32(txtLanHocSdel.Text.ToString());
                }
                if (masv != "" && Mahp != "" && lanhoc > 0)
                {
                    if (SinhVienDAO.Instance.issetSinhVien(masv))
                    {
                        if (HocPhanDAO.Instance.issetHocPhan(Mahp))
                        {
                            if (DiemDanhDAO.Instance.issetdiemdanh(masv, Mahp, lanhoc))
                            {
                                DelDiemDanhAdmin(masv, Mahp, lanhoc);
                            }
                            else
                            {
                                lbldelDD.ForeColor = Color.Red;
                                lbldelDD.Text = "Sinh viên không tồn tại";
                            }
                        }
                        else
                        {
                            lbldelDD.ForeColor = Color.Red;
                            lbldelDD.Text = "Học phần không đúng";
                        }
                    }
                    else
                    {
                        lbldelDD.ForeColor = Color.Red;
                        lbldelDD.Text = "Sinh viên không đúng";
                    }
                }
                else
                {
                    lbldelDD.ForeColor = Color.Red;
                    lbldelDD.Text = "Vui lòng nhập đầy đủ các trường";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Thêm điểm danh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemDiemDanh_Click(object sender, EventArgs e)
        {
            try
            {
                String masv = txtMaSVS.Text.ToString().Trim();
                int lanhoc = 1;
                if (IsNumber(txtLanHocSdel.Text.ToString()) == true)
                {
                    lanhoc = Convert.ToInt32(txtLanHocSdel.Text.ToString());
                }
                String Mahp = txtMaHPS.Text.ToString().Trim();
                String HocKy = txtHocKy.Text.ToString().Trim();
                if (masv != "" && Mahp != "" && lanhoc > 0 && HocKy != "")
                {
                    if (SinhVienDAO.Instance.issetSinhVien(masv))
                    {
                        if (HocPhanDAO.Instance.issetHocPhan(Mahp))
                        {
                            if (!DiemDanhDAO.Instance.issetdiemdanh(masv, Mahp, lanhoc))
                            {
                                AddNewDiemDanh(masv, Mahp, lanhoc, HocKy);
                            }
                            else
                            {
                                label20.ForeColor = Color.Red;
                                label20.Text = "Sinh viên đã tồn tại";
                            }
                        }
                        else
                        {
                            label20.ForeColor = Color.Red;
                            label20.Text = "Học phần không đúng";
                        }
                    }
                    else
                    {
                        label20.ForeColor = Color.Red;
                        label20.Text = "Sinh viên không tồn tại";
                    }
                }
                else
                {
                    label20.ForeColor = Color.Red;
                    label20.Text = "Vui lòng nhập đầy đủ các trường";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddNewDiemDanh(String MaSV, String Mahp, int lanhoc, String hk)
        {
            if (DiemDanhDAO.Instance.AddNewDiemDanh(MaSV, Mahp, lanhoc, hk) > 0)
            {
                label20.ForeColor = Color.Black;
                label20.Text = "Thêm thành công!";
                LoadtableDiemDanh();
            }
            else
            {
                label20.ForeColor = Color.Red;
                label20.Text = "Lỗi. Không thể thêm " + MaSV + " Vào CSDL";
            }
        }
        /// <summary>
        /// Thêm trạng thái tuần học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTrangThai_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkdiemdanh = Convert.ToBoolean(cbtrangThaiDiemDanh.SelectedIndex);

                if (IsNumber(txtTuanHocTrangThai.Text.ToString().Trim()))
                {
                    int sotuandahoc = Convert.ToInt32(txtTuanHocTrangThai.Text.ToString().Trim());
                    String Mahp = cbHPTrangThai.SelectedValue.ToString();

                    if (HocPhanDAO.Instance.issetHocPhan(Mahp) == true && TrangThaiTuanHocDAO.Instance.issetTrangthai(Mahp) == false)
                    {
                        AddNewTrangThaiDiemDanh(Mahp, sotuandahoc, checkdiemdanh);
                    }
                    else
                    {
                        lblThemTrangthai.ForeColor = Color.Red;
                        lblThemTrangthai.Text = "Mã học phần " + "(" + Mahp + ") không tồn tại hoặc đã có trong danh sách";
                    }
                }
                else
                {
                    lblThemTrangthai.ForeColor = Color.Red;
                    lblThemTrangthai.Text = "Trường Số tuần đã học phải là số";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddNewTrangThaiDiemDanh(String MaHP, int Sobuoihoc, bool Trangthai)
        {
            if (TrangThaiTuanHocDAO.Instance.AddRowTrangThai(MaHP, Sobuoihoc, Trangthai) > 0)
            {
                lblThemTrangthai.ForeColor = Color.Black;
                lblThemTrangthai.Text = "Thêm thành công!" + MaHP + " Vào CSDL";
                LoadtableDiemDanh();
            }
            else
            {
                lblThemTrangthai.ForeColor = Color.Red;
                lblThemTrangthai.Text = "Lỗi. Không thể thêm " + MaHP + " Vào CSDL";
            }
        }

        private void btnclearTrangThai_Click(object sender, EventArgs e)
        {
            txtTuanHocTrangThai.Text = "";
        }
        /// <summary>
        /// Sửa Trạng thái tuần học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnXoaTrangThai_Click(object sender, EventArgs e)
        {
            try
            {
                bool TrangThaiSua = Convert.ToBoolean(txtTrangThaiSua.SelectedIndex);

                if (IsNumber(txtTuanHocSuaTrangThai.Text.ToString().Trim()))
                {
                    int sotuandahoc = Convert.ToInt32(txtTuanHocSuaTrangThai.Text.ToString().Trim());
                    String Mahp = cbHPTrangThai.SelectedValue.ToString();

                    if (TrangThaiTuanHocDAO.Instance.issetTrangthai(Mahp) == true)
                    {
                        // sửa chổ này
                        if (TrangThaiTuanHocDAO.Instance.updateTrangthai(Mahp, sotuandahoc, TrangThaiSua) > 0)
                        {
                            LoadtableTrangThaiTuanHoc();
                            lblSuaTrangThai.ForeColor = Color.Black;
                            lblSuaTrangThai.Text = "Sửa thành công";
                        }
                        else
                        {
                            lblSuaTrangThai.ForeColor = Color.Red;
                            lblSuaTrangThai.Text = "Lỗi. Sửa không thành công!";
                        }
                    }
                    else
                    {
                        lblSuaTrangThai.ForeColor = Color.Red;
                        lblSuaTrangThai.Text = "Mã học phần " + "(" + Mahp + ") không tồn tại";
                    }
                }
                else
                {
                    lblSuaTrangThai.ForeColor = Color.Red;
                    lblSuaTrangThai.Text = "Trường Số tuần đã học phải là số";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Xóa trạng thái điểm danh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                String Mahp = txtXoaTrangThai.Text.ToString();
                if (TrangThaiTuanHocDAO.Instance.issetTrangthai(Mahp) == true)
                {
                    // xóa chổ này
                    if (TrangThaiTuanHocDAO.Instance.xoaTrangthai(Mahp) > 0)
                    {
                        lblXoaTrangthai.ForeColor = Color.Black;
                        lblXoaTrangthai.Text = "xóa thành công";
                    }
                    else
                    {
                        lblXoaTrangthai.ForeColor = Color.Red;
                        lblXoaTrangthai.Text = "Lỗi. xóa không thành công!";
                    }
                }
                else
                {
                    lblXoaTrangthai.ForeColor = Color.Red;
                    lblXoaTrangthai.Text = "Mã học phần " + "(" + Mahp + ") không tồn tại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}