using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace StoreManagement.UI
{
    public partial class ReportViwer : Form
    {
        #region Veriables
            DataTable Dt = new DataTable();
            ReportClass MyReport = new ReportClass();
        #endregion

        int papersizeID;       

        public ReportViwer()
        {
            InitializeComponent();
        }

        public ReportViwer(DataTable dt, ReportClass myReport):this()
        {
            this.Dt = dt;
            this.MyReport = myReport;            
        }

        public ReportViwer(DataTable dt, ReportClass myReport, int paperID): this()
        {
            this.Dt = dt;
            this.MyReport = myReport;
            papersizeID = paperID;
        }

        private void ReportViwer_Load(object sender, EventArgs e)
        {
            if (Dt!= null && Dt.Rows.Count > 0)
            {
                MyReport.Database.Tables[0].SetDataSource(Dt);
            }
            myCrystalReportViewer.ReportSource = MyReport;
            if (papersizeID > 0)
            {
                ReportDocument oRpt = new ReportDocument();
                //System.Drawing.Printing.PrintDocument MyPrinter = new System.Drawing.Printing.PrintDocument();
                //MyPrinter.PrinterSettings.PrinterName = "Epson LQ-580 ESC/P 2";
                // MyReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)MyPrinter.PrinterSettings.PaperSizes[papersizeID].RawKind;
                //MyReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                //oRpt.PrintToPrinter
                System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
                ps.PrinterName = "Epson LQ-580 ESC/P 2";
                System.Drawing.Printing.PaperSize psize = new System.Drawing.Printing.PaperSize();


            }
        }
    }
}
