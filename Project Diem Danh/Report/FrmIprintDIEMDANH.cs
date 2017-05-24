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
using Microsoft.Reporting.WinForms;

namespace Project_Diem_Danh.Report
{
    public partial class FrmIprintDIEMDANH : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private int IndexPrint;
        public FrmIprintDIEMDANH(DataTable dt, int index)
        {
            this.dt = dt;
            this.IndexPrint = index;

            InitializeComponent();
        }

        private void FrmIprintDIEMDANH_Load(object sender, EventArgs e)
        {
            switch (IndexPrint)
            {
                case 0:
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project_Diem_Danh.Report.RpPTEMPDIEMDANH.rdlc";
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetTEMPDIEMDANH";
                        rds.Value = dt;
                        reportViewer1.LocalReport.DataSources.Add(rds);

                        this.reportViewer1.RefreshReport();
                    } break;
                case 1:
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project_Diem_Danh.Report.RpDIEMDANH.rdlc";
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetDIEMDANH";
                        rds.Value = dt;
                        reportViewer1.LocalReport.DataSources.Add(rds);

                        this.reportViewer1.RefreshReport();
                    } break;

                default: break;
            }
        }
    }
}