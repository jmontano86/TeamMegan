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

        private int UserID;
        private int TestID;
        private DateTime CreationDate;

        public ResultsDisplayForm(int inUserID, int inTestID, DateTime inCreationDate)
        {
            InitializeComponent();
            UserID = inUserID;
            TestID = inTestID;
            CreationDate = inCreationDate;
   
        }


        public void ResultsDisplayForm_Load(object sender, EventArgs e)
        {
            ReportDataSource source = new ReportDataSource("DataSet", BusinessData.Statistics.FillData(UserID, TestID, CreationDate));
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(source);
            this.reportViewer2.LocalReport.Refresh();
            this.reportViewer2.RefreshReport();
        }

    }
}
