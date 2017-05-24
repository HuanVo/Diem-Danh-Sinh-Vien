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

namespace Project_Diem_Danh
{
    public partial class FrmInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            //panel1.BackColor = System.Drawing.Color.FromArgb(0, 166, 90);
            //PictureEdit1.BackColor = System.Drawing.Color.FromArgb(0, 166, 90); ;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}