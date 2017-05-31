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
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace Project_Diem_Danh
{
    public partial class Request : DevExpress.XtraEditors.XtraForm
    {
        public Request()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text.Trim() != "")
            {
                try
                {
                    Thread sendmail = new Thread(() =>
                    {
                        String kq = Send_Email(txtFrom.Text, txtTo.Text, txtSubject.Text, txtBody.Text);
                        MessageBox.Show(kq, "Trạng Thái", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    sendmail.Start();
                }
                catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            }
        }

        public String Send_Email(string SendFrom, string SendTo, string Subject, string Body)
        {
            
            try
            {
                
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                bool result = regex.IsMatch(SendFrom);
               
                if (result == false)
                {
                    return "Địa chỉ email không hợp lệ.";
                }
                else
                {
                    
                    SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                    mailclient.EnableSsl = true;
                    mailclient.Credentials = new NetworkCredential(SendFrom, txtPass.Text);
                    MailMessage message = new MailMessage(SendFrom, SendTo);
                    message.Subject = Subject;
                    message.Body = Body;
                    mailclient.Send(message);
                   
                    return "Cám ơn "+ txtFrom.Text+ " đã góp ý! chúng tôi sẽ phản hồi sớm nhất có thể.";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
                //fl.CloseSplash();
            }
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBody.Text = "";
            txtFrom.Text = "";
            txtPass.Text = "";
            txtSubject.Text = "";
            txtFrom.Focus();
        }
    }
}