using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using BusinessData;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Gui
{
    public partial class ResultsDisplayForm : MetroForm
    {

        int UserID;
        int TestID;
        DateTime CreationDate;

        public ResultsDisplayForm(int inUserID, int inTestID, DateTime inCreationDate)
        {
            InitializeComponent();
            UserID = inUserID;
            TestID = inTestID;
            CreationDate = inCreationDate;
   
        }


        public void ResultsDisplayForm_Load(object sender, EventArgs e)
        {
            // establish and fill datasets for the report

            

            ReportDataSource source = new ReportDataSource("DataSet", BusinessData.Statistics.FillData(UserID, TestID, CreationDate));
            ReportDataSource winssource = new ReportDataSource("WinsDataSet", BusinessData.Statistics.WinsFillData(TestID));
            ReportDataSource percentsource = new ReportDataSource("DataSet1", BusinessData.Statistics.PercentFillData(TestID));
          

            this.reportViewer2.LocalReport.DataSources.Add(source);
            this.reportViewer2.LocalReport.DataSources.Add(winssource);
            this.reportViewer2.LocalReport.DataSources.Add(percentsource);
            this.reportViewer2.RefreshReport();


        }

        private void ResultsDisplayForm_FormClosing(object sender, EventArgs e)
        {

          
        }

    }
}
