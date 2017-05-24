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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;
using Project_Diem_Danh.DAO;
using Project_Diem_Danh.DTO;
using System.IO;
using Project_Diem_Danh.Report;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Project_Diem_Danh
{
    public partial class FrmRollCall : DevExpress.XtraEditors.XtraForm
    {
        private Image deltailImage;
        private String nname="";
        private String tenHocPhan;
        public String TenHocPhan
        {
            get { return tenHocPhan; }
            set { tenHocPhan = value; }
        }

        private String maHP;

        public String MaHP
        {
            get { return maHP; }
            set { maHP = value; }
        }

        int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"].ToString());

        String Data = String.Empty;
        String Temp = String.Empty;
        String Time = "00:00:00";
        String ID = "";
        private List<Socket> Clientlist;

        private IPEndPoint IP;
        private Socket Server;

        #region Các Sự Kiện

        public FrmRollCall(String ma, String ten)
        {
            this.MaHP = ma;
            this.TenHocPhan = ten;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
       
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if(txtIdCoPhep.Text.Trim() !="" || txtNoCard.Text.Trim()!="")
            {
                MessageBox.Show("Vui Lòng Lưu sinh viên Không mang thẻ và vắng học có phép trước khi lưu toàn bộ dữ liệu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(MessageBox.Show("Chú Ý:"+System.Environment.NewLine +"Sau khi lưu dữ liệu, Bạn không thể tiếp tục điểm danh cho buổi học này."+System.Environment.NewLine + "BẠN CÓ MUỐN LƯU?", "Thông Báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Information)==DialogResult.OK)
                {
                    try
                    {
                        TrangThaiTuanHoc TrangThai = TrangThaiTuanHocDAO.Instance.getTrangThaiTuanHocByMaHocPhan(MaHP);
                        UpdateDataToDiemDanh(MaHP, TrangThai.Trangthai + 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void RollCall_Load(object sender, EventArgs e)
        {
            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra và thay đổi lại cổng port kết nối trong file cấu hình hệ thống hoặc khởi động lại phần mềm và thiết bị!" + System.Environment.NewLine + ex.Message, "Xung đột port");
            }
            pnl_footer.BackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            btnSaveNoCard_Sabbatical.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            this.Text = "Điểm danh học phần: "+TenHocPhan + " - " + MaHP;
            lbxLogCurent.Columns.Add("Sự Kiện Log", lbxLogCurent.Size.Width - 10);
            lbxLogCurent.View = View.Details;
        }

        private void btnSaveNoCard_Sabbatical_Click_1(object sender, EventArgs e)
        {
            SaveNoCar_Sabb();
        }

        private void FrmRollCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Clientlist != null || Clientlist.Count > 0)
                foreach (Socket sk in Clientlist)
                {
                    sk.Close();
                }
            Server.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            Deltail_Imagecs daa = new Deltail_Imagecs(deltailImage, nname);
            daa.ShowDialog();
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            Deltail_Imagecs daa = new Deltail_Imagecs(deltailImage, nname);
        }

        private void btnchitiet_Click(object sender, EventArgs e)
        {
            FrmTutorialAppcs huongdan = new FrmTutorialAppcs();
            huongdan.ShowDialog();
        }

        #endregion

        #region Các Phương Thức
        /// <summary>
        /// Kết nối và thực thực hiện gửi nhận dữ lệu
        /// </summary      
        void Connect()
        {
            progressPanel1.Show();
            Clientlist = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, port);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Server.Bind(IP);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Server.Listen(1);                        
                        Socket client = Server.Accept();
                        Clientlist.Add(client);
                        progressPanel1.Visible = false;
                        toolStripStatus_lbl.Text = "Đã Kết Nối Đến Thiết Bị: " + ((IPEndPoint)client.RemoteEndPoint).Address.ToString();                    
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, port);
                    Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }
        /// <summary>
        /// Nhận Dữ Liệu Từ Phần Cứng
        /// </summary>
        /// <param name="obj">Nhận Dữ Liệu Từ Phần Cứng</param>
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int rec = client.Receive(data);
                    if (rec < data.Length)
                        Array.Resize<byte>(ref data, rec);
                    Data = Encoding.UTF8.GetString(data).ToUpper();
                    ID = Data;
                    //Xử lí chổ này
                    if(Data!=Temp)
                    {
                        lblID.Text = Data;
                        Data = MappingCode_Id.MappingCodeToID(Data);
                        if(Data!="")
                        {
                            ShowInfoSinhVienByID(Data);
                            WriteData(Data, MaHP);
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtFullName.Text = "";
                            txtSex.Text = "";
                            txtClass.Text = "";
                            txtAddress.Text = "";
                            String path = Application.StartupPath + @"\no_avatar.png";
                            picImage.Image = Image.FromFile(path);
                           ShowMessageResult("Thẻ không tồn tại, vui lòng kiểm tra lại", 0);
                        }
                        Temp = ID;
                        Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                    }
                    else
                    {
                        int timetemp = Convert.ToInt32(ConfigurationManager.AppSettings["thoiGianHaiLanQuetThe"].ToString());
                        int t = (ConverTotMinute(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString())-ConverTotMinute(Time));
                        if (t > timetemp)
                        {
                            lblID.Text = Data;
                            Data = MappingCode_Id.MappingCodeToID(Data);
                            if (Data != "")
                            {
                                ShowInfoSinhVienByID(Data);
                                WriteData(Data, MaHP);
                            }
                            else
                            {
                                txtCode.Text = "";
                                txtFullName.Text = "";
                                txtSex.Text = "";
                                txtClass.Text = "";
                                txtAddress.Text = "";
                                String path = Application.StartupPath + @"\no_avatar.png";
                                picImage.Image = Image.FromFile(path);
                                ShowMessageResult("Thẻ không tồn tại, vui lòng kiểm tra lại", 0);
                            }
                            Temp = ID;
                            Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();                   
                        }
                    }
                }
            }
            catch
            {
                Clientlist.Remove(client);
                client.Close();
                //MessageBox.Show("Kết Nối bị lỗi, Vui lòng reset kết nối", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //progressPanel1.Show();
                //toolStripStatus_lbl.Text = "Đã Kết Đóng Nối Với Thiết Bị...";
            }
        }

        /// <summary>
        /// Ghi Dữ Liệu Nhận Được Từ Phần Cứng
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Mahocphansv"></param>
        private void WriteData(String ID, String Mahocphansv)
        {
            TempDiemDanh record = new TempDiemDanh();
            //Kiem tra sinh vien da điểm danh lần nào chưa
            List<TempDiemDanh> temm = TempDiemDanhDAO.Instance.getListTempDiemDanhByID_MaHocPhan(ID, Mahocphansv);
            if (temm == null||temm.Count==0)
            {
                //Kiểm tra tính hợp lệ của sinh viên
                    if (DiemDanhDAO.Instance.CheckIsStudentByID_MaHocPhan(ID, Mahocphansv))
                    {
                        String tg_vao = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                        //ghi ma lop va thoi gian vao csdl
                        try
                        {
                            int result = TempDiemDanhDAO.Instance.insertDataIntoTemDiemDanh_GT_VAO(ID, Mahocphansv, tg_vao);
                            if (result > 0)
                            {
                                String info = ID + " Đã vào lớp " + tg_vao;
                                ShowMessageResult(info, 1);
                            }
                            else
                            {
                                ShowMessageResult("Lỗi hệ thống, vui lòng kiểm tra lại!", 0);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Lỗi ghi thẻ");
                        }
                    }
                    else
                    {
                        ShowMessageResult(ID+ " không đăng ký môn học này!", 0);
                        
                    }
            }
            else
            {
                if (temm.Count > 0)
                {
                    //kiem tra thoi gian vao va thoi gian hien tai de luu thoi gian ra: thoi gian hien tai - thoi gian vao > muc thoi gian quy dinh
                    record = temm[0];
                    //Xu li truong hop trung du lieu           
                    if (record.ThoiGianRa == "" && record.GhiChu =="")
                    {
                        int ThoiGianHoc = Convert.ToInt32(ConfigurationManager.AppSettings["thoigianhoc"].ToString());
                        String tg_vao = record.ThoiGianVao.ToString();
                        String tg_ra = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                        if (ConverTotMinute(tg_ra) - ConverTotMinute(tg_vao) > ThoiGianHoc)
                        {
                            // Cập nhật thời gian ra chổ này
                            try
                            {
                                if (TempDiemDanhDAO.Instance.updateTimeStopByID(ID, tg_ra) > 0)
                                {
                                    ShowMessageResult(ID.ToString() + " Đã rời lớp "+tg_ra.ToString(), 1);
                                }
                                else
                                {
                                    ShowMessageResult("Lưu không thành công, Vui lòng kiểm tra và thử lại.", 0);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Lỗi Khi Ghi Thời Gian Kết Thúc");
                            }
                        }
                        else
                        {
                            String info = ID+" Ra trước giờ quy định " + (ConverTotMinute(tg_ra) - ConverTotMinute(tg_vao)).ToString() + " Phút";
                            ShowMessageResult(info, 0);
                        }
                    }
                    else
                    {
                        ShowMessageResult("Thời gian rời lớp đã được ghi trước đó.", 2);
                    }
                }
            }
        }

       /// <summary>
       /// Hiển Thị Thông Tin Sinh Viên Với Ma Sinh Vien Tương Ứng
       /// </summary>
       /// <param name="ID"></param> 
        private void  ShowInfoSinhVienByID(Object ID)
        {
           try
           {
               if (SinhVienDAO.Instance.checkIsStudents((String)ID))
               {
                   SinhVien sv = SinhVienDAO.Instance.getInfoSinhVienByID(ID as String);
                   txtCode.Text = "";
                   txtCode.Text = sv.MaSV;
                   txtFullName.Text = "";
                   txtFullName.Text = sv.HoDem + " " + sv.Ten;
                   nname = sv.HoDem + " " + sv.Ten;
                   txtSex.Text = "";
                   txtSex.Text = sv.GioiTinh.ToString();
                   txtBithday.Text = sv.NgaySinh.ToString();
                   txtClass.Text = "";
                   txtClass.Text = sv.MaLop;
                   txtAddress.Text = "";
                   txtAddress.Text = sv.DiaChi;
                   picImage.Controls.Clear();

                   if (sv.HinhDaiDien == null)
                   {
                       picImage.Image = Image.FromFile(@"Images\no_avatar.png");
                       deltailImage = Image.FromFile(@"Images\no_avatar.png");
                   }
                   else
                   {
                       picImage.Image = ProcessImage.Instance.byteArrayToImage(sv.HinhDaiDien.ToArray());
                       deltailImage = ProcessImage.Instance.byteArrayToImage(sv.HinhDaiDien.ToArray());
                   }
                   String sms = convertToUnSign(sv.HoDem+" "+sv.Ten+"-"+sv.MaSV);

                   String Container = sms.ToUpper();

                   foreach (Socket client in Clientlist)
                   {
                       client.Send(Encoding.UTF8.GetBytes(Container));
                   }
               }
           }
            catch(Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
        }

        /// <summary>
        /// Chuyển Đổi Thời Gian Sang Phút
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public int ConverTotMinute(String Time)
        {
            int Minute = 0;
            try
            {
                DateTime temmp = Convert.ToDateTime(Time);
                Minute = temmp.Hour * 60 + temmp.Minute + temmp.Second/60;
            }
            catch (Exception ex)
            {
                ShowMessageResult("Chuyển đổi thời gian bị lỗi!" + System.Environment.NewLine + ex.Message, 0);
            }
            return Minute;
        }
      
        /// <summary>
        /// Xu li sinh vien khong mang the
        /// </summary>
        /// 
        private void XuLySinhVienKhongMangThe()
        {
            String str = txtNoCard.Text.ToString().Trim();
                if (!str.Equals(""))
                {
                    String[] IdNoCard = str.Split(';');
                        foreach (String i in IdNoCard)
                        {
                            //Kiem tra sinh vien co ton tai trong lop hoc hay khong
                            if (DiemDanhDAO.Instance.CheckIsStudentByID_MaHocPhan(i.Trim(), MaHP))
                            {
                                //Kiem tra sinh vien da co trong bảng tạm hay chưa
                                List<TempDiemDanh> temm = TempDiemDanhDAO.Instance.getListTempDiemDanhByID_MaHocPhan(i.Trim(), MaHP);
                                if (temm.Count <= 0)
                                {
                                    try
                                    {
                                        if( TempDiemDanhDAO.Instance.insertDataToTEMPDIEMDANH_NoCard(i.Trim(), MaHP)>0)
                                        {
                                            ShowMessageResult("Đã ghi " + i.Trim() + " thành công", 1);
                                        }
                                        else
                                        {
                                            ShowMessageResult("lỗi, Ghi Thẻ " + i.Trim() + " không thành công", 0);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    String info = "Mã thẻ: " + i.Trim() + " đã được ghi trước đó, vui lòng kiểm tra lại";
                                    ShowMessageResult(info, 0);
                                }
                            }
                            else
                            {
                                String info = "Mã thẻ: " + i.Trim() + " Không tồn tại!";
                                ShowMessageResult(info, 0);
                            }
                        }
                        txtNoCard.Text = "";
                    }                   
        }

        /// <summary>
        /// Xu li sinh vien vang hoc co phep
        /// </summary>
        private void XuLySinhVinhVienCoPhep()
        {
            {
                String str = txtIdCoPhep.Text.ToString().Trim();
                if (!str.Equals(""))
                {

                    String[] IdCoPhep = str.Split(';');
                        foreach (String i in IdCoPhep)
                        {
                            //Lấy mã sinh viên và lí do nghỉ học
                            String[] sv = i.Split('-');
                            String masv = sv[0].Trim();
                            String lido = string.Compare(sv[1],"")!=0?sv[1].Trim().ToString():"";
                            //Kiem tra sinh vien co ton tai trong lop hoc hay khong
                            if (DiemDanhDAO.Instance.CheckIsStudentByID_MaHocPhan(masv, MaHP))
                            {
                            do_again:
                                List<TempDiemDanh> temm = TempDiemDanhDAO.Instance.getListTempDiemDanhByID_MaHocPhan(masv, MaHP);
                                if (temm.Count <= 0)
                                {
                                    try
                                    {
                                        if (TempDiemDanhDAO.Instance.insertDataIntoTemDiemDanh_NghiPhep(masv, MaHP, lido) > 0)
                                        {
                                            ShowMessageResult("Ghi phép " + masv + " thành công", 1);
                                        }
                                        else
                                        {
                                            
                                            ShowMessageResult("Lỗi, Ghi phép " + masv + " không thành công", 0);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                { 
                                     //Xoa Du lieu cu va ghi du lieu moi
                                    try
                                    {
                                        if (TempDiemDanhDAO.Instance.delTEMPDIEMDANHbyID(masv) > 0)
                                            goto do_again;
                                        else
                                        {
                                            String info = "Mã thẻ: " + masv + " Không thể ghi phép, vui lòng kiểm tra lại!";
                                            ShowMessageResult(info, 0);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                                    }
                                }
                            }
                            else
                            {
                                String info = "Mã Thẻ: " + masv + " Không tồn tại!";
                                ShowMessageResult(info, 0);
                            }
                        }
                        txtIdCoPhep.Text = "";
                    }
            }
        }
        
        /// <summary>
        /// Cập nhật dữ liệu tạm vào bản DIEMDANH ----- Bien tuan = tuan + 1
        /// </summary>
        private void UpdateDataToDiemDanh(String Mahocphan, int tuan)
        {
            TrangThaiTuanHoc TrangThai = TrangThaiTuanHocDAO.Instance.getTrangThaiTuanHocByMaHocPhan(Mahocphan);
            if (TrangThai.CheckDiemDanh <= 0)
            {
                //Kiem tra ngay hom nay da diem danh hay chua
                if (tuan < 18)
                {
                    //Doi tuong luu gia tri so lan hoc va so lan vang phep
                    DiemDanh TableDD;
                    DataTable dt = new DataTable();
                    try
                    {
                        // check: kiem tuan hoc de cap nhat tuan hoc
                        int check = 0;
                        // lay tat ca cac dong du lieu voi ma hoc phan tuong ung
                        dt = TempDiemDanhDAO.Instance.getTableTEMPDIEMDANHByMaHocPhan(Mahocphan);
                        if (dt.Rows.Count > 0)
                        {
                            // quet qua tung dong de luu du lieu vao bang diemdanh
                            foreach (DataRow row in dt.Rows)
                            {
                                //Update = new ImportData(row);
                                TableDD = DiemDanhDAO.Instance.getTableDIEMDANHByIdMaHocPhan(row["MASINHVIEN"].ToString(), Mahocphan);
                                //Kiểm tra nếu có dũ liệu trong GhiChu và ThoiGian khac rong thì ghi vào
                                //if (Update.GhiChu == "" && Update.ThoiGian.Length > 22)
                                //{
                                    String ThoiGian;
                                    if (row["TG_VAO"].ToString() != "" && row["TG_RA"].ToString() != "")
                                    {
                                        if (row["TG_VAO"].ToString() == "Quên Thẻ")
                                        {
                                            ThoiGian = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + row["TG_VAO"].ToString();
                                        }
                                        else
                                        {
                                            ThoiGian = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + row["TG_VAO"].ToString() + " " + row["TG_RA"].ToString();
                                        }

                                    
                                    //Quên thẻ rơi vào trường hợp này
                                    //goi cau lenh update thoi gian hoc vao cho nay
                                        String sql = @"update DIEMDANH set TUAN_" + tuan + "=N'" + ThoiGian.ToString() + "', SOBUOIHOC ='" + (TableDD.SoBuoiHoc + 1).ToString() + "'" + " WHERE MASINHVIEN = '" + row["MASINHVIEN"] + "' AND MAHOCPHAN ='" + Mahocphan + "'";
                                    if (DataProvider.Instance.ExcuteNonQuery(sql) > 0)
                                    {
                                        check = check + 1;
                                        ShowMessageResult("Đã Lưu " + row["MASINHVIEN"].ToString(), 1);
                                    }
                                }
                                 //kiem tra neu ghi chu khac rong = sinh vien nghi co phep -> cap nhat so buoi phep



                                if (row["GHICHU"].ToString() != "")
                                {
                                    //goi cau lenh cap nhat so buoi nghi co phep
                                    ThoiGian = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + row["GHICHU"].ToString();
                                    String sql = @"update DIEMDANH set TUAN_" + tuan + "=N'" + ThoiGian.ToString() + "', SOBUOIPHEP ='" + (TableDD.SoBuoiPhep + 1).ToString() + "'" + " WHERE MASINHVIEN = '" + row["MASINHVIEN"].ToString() + "' AND MAHOCPHAN ='" + Mahocphan + "'";
                                    if (DataProvider.Instance.ExcuteNonQuery(sql) > 0)
                                    {
                                        check = check + 1;
                                        ShowMessageResult("Đã Lưu " + row["MASINHVIEN"].ToString(), 1);
                                    }
                                }
                                //Kiểm tra Thoigian va ghichu
                                if (row["GHICHU"].ToString() == "" && row["TG_RA"].ToString() == "")
                                {
                                    ThoiGian = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + row["TG_VAO"].ToString();
                                    String sql = @"update DIEMDANH set TUAN_" + tuan + "='" + ThoiGian.ToString() + "'" + " WHERE MASINHVIEN = '" + row["MASINHVIEN"].ToString() + "' AND MAHOCPHAN ='" + Mahocphan + "'";
                                    if (DataProvider.Instance.ExcuteNonQuery(sql) > 0)
                                    {
                                        check = check + 1;
                                        ShowMessageResult("Đã Lưu " + row["MASINHVIEN"].ToString(), 2);
                                    }
                                }
                            }
                            if (check > 0)
                            {
                                ShowMessageResult("Số Sinh Viên Đến Lớp Hôm Nay: " + check.ToString(), 1);
                                //Cap Nhat Trang thai tuan da hoc
                                String sql = @"update TrangThaiTuanHoc set TrangThai ='" + (TrangThai.Trangthai + 1).ToString() + "' where MaHocPhan ='" + Mahocphan + "'";
                                //Cap Nhat so tuan da hoc
                                TrangThaiTuanHocDAO.Instance.UpdateTrangThaiTuanHoc(Mahocphan, (TrangThai.Trangthai + 1));
                                //Cap nhat trang thai checkdiemdanh
                                TrangThaiTuanHocDAO.Instance.UpdateCheckDiemDanh(Mahocphan);
                            }
                        }
                        else
                        {
                            ShowMessageResult("Không có dữ liệu để lưu", 0);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Số tuần đã vượt quá giới hạn, không thể ghi thêm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
            }
            else
            {
                MessageBox.Show("Hôm Nay Bạn đã điểm danh! và không thể tiếp tục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Hiển Thị Thông Báo.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="NumError"></param>
        private void ShowMessageResult(String Title, int NumError)
        {
            ListViewItem liv = new ListViewItem();
            switch (NumError)
            {
                case 0:
                    {
                        liv.ForeColor = Color.Red;
                        liv.Text = "[" + DateTime.Now.ToString() + "]      " + Title;
                        lbxLogCurent.Items.Insert(0, liv);
                    }
                    break;
                case 1:
                    {
                        liv.Text = "[" + DateTime.Now.ToString() + "]      " + Title;
                        liv.ForeColor = Color.Black;
                        lbxLogCurent.Items.Insert(0, liv);

                    } break;
                case 2:
                    {
                        liv.Text = "[" + DateTime.Now.ToString() + "]      " + Title;
                        liv.ForeColor = Color.YellowGreen;
                        lbxLogCurent.Items.Insert(0, liv);
                    } break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Lưu sinh viên không mang thẻ và có phép
        /// </summary>
        private void SaveNoCar_Sabb()
        {
            if (txtNoCard.Text.Trim() != "")
            {
                try
                {
                    XuLySinhVienKhongMangThe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (txtIdCoPhep.Text.Trim() != "")
            {
                try
                {
                    XuLySinhVinhVienCoPhep();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// chuyen chuoi co dau thanh khong dau
        /// </summary>
        /// <param name="ConverTotMinute">Convert from time</param>
        /// <returns></returns>
        private string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        } 
        #endregion

    }
}
