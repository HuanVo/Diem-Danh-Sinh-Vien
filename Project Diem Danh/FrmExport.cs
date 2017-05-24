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
    public partial class FrmExport : DevExpress.XtraEditors.XtraForm
    {
        public FrmExport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUser.flag = 0;
                Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedItem != null) 
            {
                if (comboBox1.SelectedItem.ToString() == "Danh Sách Điểm Danh Hiện Tại")
                {
                    FrmUser.flag = 1;
                }
                else
                    FrmUser.flag = 2;
                this.Close();
            }

        }

        private void FrmExport_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmExport_Load(object sender, EventArgs e)
        {

        }

       
    }
}