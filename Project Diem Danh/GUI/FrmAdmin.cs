using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Project_Diem_Danh.DAO;
using Project_Diem_Danh.DTO;
using Project_Diem_Danh.Report;
using System.Data.SqlClient;
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
            try
            {
                pnlMenu.BackColor = System.Drawing.Color.FromArgb(0, 166, 90);
                cbbgetTableName.SelectedIndex = 0;
                cbbAllTable.SelectedIndex = 0;
                lstvReport.Columns.Add("Sự Kiện Log", lstvReport.Size.Width - 10);
                lstvReport.View = View.Details;
                String sqlGetTableHocPhan = "SELECT MAHOCPHAN, TENHOCPHAN + ' ('+MAHOCPHAN +')' AS TENHOCPHAN FROM HOCPHAN";
                getAllTabletoCombox(cbbhpselect, sqlGetTableHocPhan, "TENHOCPHAN", "MAHOCPHAN");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                            String sqlString = @"SELECT * FROM NHOM";
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
            try
            {
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
            try
            {
                if (cbbAllTable.SelectedIndex != -1 && txtPath.Text.Trim() != "")
                {
                    ShowMessageResult("Đang tiến hành Import, vui lòng chờ......", 1);
                    bool check = checkBox.Checked;
                    ImportData(cbbAllTable.SelectedIndex, txtPath.Text.Trim(), check);
                }
            }
            catch
            {
                MessageBox.Show("Chao Moi nguoi");
            }
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
                            String ExcelDataQuery = string.Format(@"select MASINHVIEN, MANHOM, LANHOC, HOCKY,TUAN_1,TUAN_2,TUAN_3,TUAN_4,TUAN_5,TUAN_6,TUAN_7,TUAN_8,TUAN_9,TUAN_10,TUAN_11,TUAN_12,TUAN_13,TUAN_14,TUAN_15,TUAN_16,TUAN_17,SOBUOIHOC, SOBUOIPHEP FROM [{0}$]", Sheet);
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
                            String ExcelDataQuery = string.Format(@"select ID, HODEM, TEN, NGAYSINH, GIOITINH, NOISINH, IMAGES, MASINHVIEN, MALOP FROM [{0}$]", Sheet);
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
                            String ExcelDataQuery = string.Format(@"select MAGIANGVIEN, HODEM, TEN, DIACHI, SODIENTHOAI, NGAYSINH, EMAIL, PASSWORD_USER, MAKHOA, TYPE_USER FROM [{0}$]", Sheet);
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
                            String ExcelDataQuery = string.Format(@"select MAKHOA, TENKHOA, NAMTHANHLAP, DIENTHOAI FROM [{0}$]", Sheet);
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
                            String ExcelDataQuery = string.Format(@"select MALOP, TENLOP, HEDAOTAO, NAMNHAPHOC, MAKHOA FROM [{0}$]", Sheet);
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
                            String ExcelDataQuery = string.Format(@"select MAHOCPHAN, TENHOCPHAN, SOTINCHI FROM [{0}$]", Sheet);
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
                            String ExcelDataQuery = string.Format(@"select MANHOM, TENNHOM, MAGIANGVIEN, MAHOCPHAN, SOBUOIHOC, CHECKDIEMDANH FROM [{0}$]", Sheet);
                            try
                            {
                                if (Importdata.Instance.ImportDataFromExcel(PathExcelFile, ExcelDataQuery, "NHOM", Checked))
                                    ShowMessageResult("Import thành công -  NHOM", 1);
                                else ShowMessageResult("LỖI Import không thành công, vui lòng thử lại - NHOM", 0);
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
                            String sqlString = @"EXEC SELECT * FROM NHOM";
                            DataTable dt = TrangThaiTuanHocDAO.Instance.getAllTableTrangThaiTuanHoc(sqlString);
                            if (Exportdata.exportDataToExcel(Title, dt))
                                ShowMessageResult("Đã Export thành công Nhóm học phần", 1);
                            else
                                ShowMessageResult("Không Thể Export Nhóm học phần", 0);
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
                try
                {
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
            //String sqlGetTableTrangThai = "Select TRANGTHAITUANHOC.MAHOCPHAN, TENHOCPHAN from TRANGTHAITUANHOC inner join HOCPHAN ON TRANGTHAITUANHOC.MAHOCPHAN = HOCPHAN.MAHOCPHAN";
            //String sqlGetTableHocPhan = "SELECT MAHOCPHAN, TENHOCPHAN FROM HOCPHAN";
            //getAllTabletoCombox(cbHPTrangThai, sqlGetTableHocPhan, "TENHOCPHAN", "MAHOCPHAN");

            //getAllTabletoCombox(cbHPSuaTrangThai, sqlGetTableTrangThai, "TENHOCPHAN", "MAHOCPHAN");

            String sqlGetTableGiangVien = "Select MAKHOA, TENKHOA from KHOA";
            getAllTabletoCombox(cbMaGV, sqlGetTableGiangVien, "TENKHOA", "MAKHOA");
            getAllTabletoCombox(txmMaGVedit, sqlGetTableGiangVien, "TENKHOA", "MAKHOA");
            //txmMaGVedit
            LoadtableHocphan();
            LoadtableDiemDanh();
            //LoadtableTrangThaiTuanHoc();
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
                String makhoa = cbMaGV.SelectedValue.ToString();
                if (mahp != "" && tenhp != "" && txtSoTC.Text.ToString().Trim() != ""  && makhoa != "")
                {
                    int sotc = Convert.ToInt32(txtSoTC.Text.ToString().Trim());
                    if (!HocPhanDAO.Instance.issetHocPhan(mahp))
                    {
                        AddHocPhan(mahp, tenhp, sotc, makhoa);
                    }
                    else
                    {
                        lblkq.ForeColor = Color.Red;
                        lblkq.Text = string.Format("Học phần {0}({1}) đã tồn tại", tenhp, mahp);
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

        public void AddHocPhan(String mahp, String tenhp, int sotc, String MAKHOA)
        {
            if (HocPhanDAO.Instance.AddNewHP(mahp, tenhp, sotc, MAKHOA) > 0)
            {
                    lblkq.ForeColor = Color.Black;
                    lblkq.Text = string.Format("Đã thêm thành công học phần {0}({1})", tenhp, mahp);
                    LoadtableHocphan();
                }
            else
                {
                    lblkq.ForeColor = Color.Red;
                    lblkq.Text = string.Format("Đã có lỗi xãy ra. Không thêm được Học Phần{0}({1})", tenhp, mahp);
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
                String mahp = txtMaHPedit.Text.Trim();
                String tenhp = txtTenHPedit.Text.Trim();
                int sotc = Convert.ToInt32(txtSoTCedit.Text.Trim());
                String MAKHOA = txmMaGVedit.SelectedValue.ToString();
                if (HocPhanDAO.Instance.issetHocPhan(mahp))
                {
                    if (mahp != "" && tenhp != "" && sotc > 0 && MAKHOA != "")
                    {
                            updateHocPhan(mahp, tenhp, sotc, MAKHOA);

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
                    lblkqedit.Text = string.Format("Học phần {0}({1}) Không tồn tại", tenhp, mahp);
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
                lblkqedit.Text = string.Format("Đã sửa thành công học phần {0}({1})", tenph, mahp);
                LoadtableHocphan();
            }
            else
            {
                lblkqedit.ForeColor = Color.Red;
                lblkqedit.Text = string.Format("Đã có lỗi xãy ra. Không sửa học Phần{0}({1})", tenph, mahp);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaHPedit.Text = gridView1.GetFocusedRowCellDisplayText("MAHOCPHAN").ToString();
            txtTenHPedit.Text = gridView1.GetFocusedRowCellDisplayText("TENHOCPHAN").ToString();
            txtSoTCedit.Text = gridView1.GetFocusedRowCellDisplayText("SOTINCHI").ToString();
            //txmMaGVedit.SelectedValue = gridView1.GetFocusedRowCellDisplayText("KHOA");
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
            String mahp = txtMaHPdel.Text.Trim();
            if (HocPhanDAO.Instance.issetHocPhan(mahp))
            {
                DialogResult rs = MessageBox.Show(string.Format("Bạn Có muốn xóa học phần có mã {0}?", mahp), "Xác Nhận Xóa Học Phần", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                    if (HocPhanDAO.Instance.DelHocPhanById(MaHP) > 0)
                    {
                        lblkqxoa.ForeColor = Color.Black;
                        lblkqxoa.Text = "Đã xóa học phần có mã: " + MaHP;
                        LoadtableHocphan();
                    }
                    else
                    {
                        lblkqxoa.ForeColor = Color.Red;
                        lblkqxoa.Text = string.Format("Không thể xóa học phần có mã: {0}, Kiểm tra lại!", MaHP);
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
                lbldelDD.Text = string.Format("Đã Xóa {0} ra khỏi danh sách điểm danh", MaSV);
                LoadtableDiemDanh();
            }
            else
            {
                lbldelDD.ForeColor = Color.Red;
                lbldelDD.Text = string.Format("Lỗi! Không thể xóa {0}", MaSV);
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
                label20.Text = string.Format("Lỗi. Không thể thêm {0} Vào CSDL", MaSV);
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
                        lblThemTrangthai.Text = string.Format("Mã học phần ({0}) không tồn tại hoặc đã có trong danh sách", Mahp);
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
                lblThemTrangthai.Text = string.Format("Thêm thành công!{0} Vào CSDL", MaHP);
                LoadtableDiemDanh();
            }
            else
            {
                lblThemTrangthai.ForeColor = Color.Red;
                lblThemTrangthai.Text = string.Format("Lỗi. Không thể thêm {0} Vào CSDL", MaHP);
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
                            //LoadtableTrangThaiTuanHoc();
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
                        lblSuaTrangThai.Text = string.Format("Mã học phần ({0}) không tồn tại", Mahp);
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
                    lblXoaTrangthai.Text = string.Format("Mã học phần ({0}) không tồn tại", Mahp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /*
        * Phần báo cáo thống kê
        * 
        */

        private void cbbhpselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbhpselect.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                String MaHP = cbbhpselect.SelectedValue.ToString();
                ShowListHocPhanByMaHP(MaHP);
                ShowInfoHocPhanByMaHocPhan(MaHP);
            }
        }

        /// <summary>
        /// Hiển thị thông tin học phần bởi học được chọn trong list học phần
        /// </summary>
        /// <param name="MaHocPhan">Mã học phần</param>
        private void ShowInfoHocPhanByMaHocPhan(String MaHocPhan)
        {
            String sql = string.Format("EXEC getInfoHocPhanByMaHP '{0}'", MaHocPhan);
            DataTable dt = HocPhanDAO.Instance.getAllTableHocPhan(sql);
            foreach(DataRow row in dt.Rows)
            {
                txthpReport.Text = row["HOCPHAN"].ToString();
                txtstcReport.Text = row["SOTINCHI"].ToString();
                txtthReport.Text = TrangThaiTuanHocDAO.Instance.getTuanHoc(MaHocPhan).ToString();
                txtgvqlReport.Text = row["HOTEN"].ToString();
            }
        }

        /// <summary>
        /// Hiển thị danh sách điểm danh sinh viên của học phần bởi mã học phần
        /// </summary>
        /// <param name="MaHocPhan"></param>
        private void ShowListHocPhanByMaHP(String MaHocPhan)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSinhVien", typeof(String));
            dt.Columns.Add("HoTenSinhVien", typeof(String));
            dt.Columns.Add("MaHocPhan", typeof(String));
            dt.Columns.Add("TenHocPhan", typeof(String));
            dt.Columns.Add("SoTinChi", typeof(String));
            dt.Columns.Add("LanHoc", typeof(String));
            dt.Columns.Add("HocKy", typeof(String));

            dt.Columns.Add("BuoiHoc", typeof(int));
            dt.Columns.Add("BuoiVang", typeof(int));
            dt.Columns.Add("VangCoPhep", typeof(int));
            dt.Columns.Add("GhiChu", typeof(String));

            try
            {
                DataTable SourceData = DiemDanhDAO.Instance.LoadDulieuThongkeBaocao(MaHocPhan);
                int Tongsotuandahoc = TrangThaiTuanHocDAO.Instance.getTuanHoc(MaHocPhan);
                foreach (DataRow row in SourceData.Rows)
                {
                    DataRow rows;
                    rows = dt.NewRow();
                    rows["MaSinhVien"] = row["MASINHVIEN"];
                    rows["HoTenSinhVien"] = row["HOTEN"];
                    rows["MaHocPhan"] = row["MAHOCPHAN"];
                    rows["TenHocPhan"] = row["TENHOCPHAN"];
                    rows["SoTinChi"] = Convert.ToInt32(row["SOTINCHI"]);
                    rows["LanHoc"] = row["LANHOC"];
                    rows["HocKy"] = row["HOCKY"];
                    rows["BuoiHoc"] = Convert.ToInt32(row["SOBUOIHOC"]);
                    rows["VangCoPhep"] = Convert.ToInt32(row["SOBUOIPHEP"]);
                    // [So buoi vang] = [tong so buoi da hoc] - [so buoi hoc] + [so buoi phep]
                    rows["BuoiVang"] = Tongsotuandahoc - Convert.ToInt32(row["SOBUOIHOC"]) - Convert.ToInt32(row["SOBUOIPHEP"]);
                    rows["GhiChu"] = CreateNoteInReport(Convert.ToInt32(row["SOTINCHI"]), Convert.ToInt32(row["SOBUOIHOC"]), Tongsotuandahoc);
                    dt.Rows.Add(rows);
                }
                gridReport.DataSource = dt;
            }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message,"Thông báo");
           }
        }
        /// <summary>
        /// Tạo Ghi chú kết quả cấm thi/được phép thi trong ADMIN [báo cáo thống kê]
        /// </summary>
        /// <returns></returns>
        private String CreateNoteInReport(int sotc, int sobuoihoc, int tongtuanhoc)
        {
            String resualt = "";
            if(tongtuanhoc>0 && sotc>0)
            {
                if (((tongtuanhoc - sobuoihoc) * 100) / (sotc * tongtuanhoc) > 20)
                    resualt = "Cấm thi";
            }
           
            return resualt;
        }

        private void gridView6_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int rowHandle = e.RowHandle;

                Object val1 = gridView6.GetRowCellValue(rowHandle, gridView6.Columns[0]);
                Object val2 = gridView6.GetRowCellValue(rowHandle, gridView6.Columns[2]);
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

        private void btnprintbcReport_Click(object sender, EventArgs e)
        {
            // Check whether the GridControl can be previewed.
            if (!gridReport.IsPrintingAvailable)
            {
                MessageBox.Show("Không tồn tại dữ liệu");
                return;
            }
            // Open the Preview window.
            gridReport.ShowPrintPreview();
        }
    }
}