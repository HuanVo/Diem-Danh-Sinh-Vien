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
    public partial class FrmTutorialAppcs : DevExpress.XtraEditors.XtraForm
    {
        public FrmTutorialAppcs()
        {
            InitializeComponent();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void FrmTutorialAppcs_Load(object sender, EventArgs e)
        {
            
        }

        private void backstageViewButtonItem1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Usingsetting rep = new Usingsetting();
            rep.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(rep);
        }

        private void backstageViewButtonItem3_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
          UsingDiemDanh frmUSingDD = new UsingDiemDanh();
            frmUSingDD.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(frmUSingDD);
        }

        private void backstageViewTabItem1_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            
        }

        private void backstageViewButtonItem2_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            UsingReport rep = new UsingReport();
            rep.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(rep);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backstageViewTabItem2_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Quanlihocphan rep = new Quanlihocphan();
            rep.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(rep);
        }

        private void backstageViewTabItem2_SelectedChanged_1(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void backstageViewButtonItem4_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Quanlihocphan rep = new Quanlihocphan();
            rep.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(rep);
        }
    }
}
