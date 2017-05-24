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
    public partial class FrmGetTitleToExport : DevExpress.XtraEditors.XtraForm
    {
        public static String Title;
        public FrmGetTitleToExport()
        {
            InitializeComponent();
        }

        private void FrmGetTitleToExport_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txtgetTitle.Text.Trim()!="")
            {
                Title = txtgetTitle.Text.Trim();
                this.Close();
            }
                
            
        }

    }
}