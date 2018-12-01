namespace Gui
{
    partial class ResultsDisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ResultsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vResultsDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.statisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
         
            this.resultsDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new System.Data.DataSet();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vResultsDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).BeginInit();
           
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultsDataSetBindingSource
            // 
            this.ResultsDataSetBindingSource.DataMember = "vResults";

            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // statisticsBindingSource
            // 
            this.statisticsBindingSource.DataSource = typeof(BusinessData.Statistics);
            // 
            // resultsDataSet1
            // 

            // 
            // resultsDataSet2
            // 
      
            // 
            // resultsDataSetBindingSource1
            // 

            this.resultsDataSetBindingSource1.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // reportViewer2
            // 
            reportDataSource1.Name = "ResultsDataSet";
            reportDataSource1.Value = this.ResultsDataSetBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Gui.Report1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(203, 148);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(396, 246);
            this.reportViewer2.TabIndex = 0;
            // 
            // ResultsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 409);
            this.Controls.Add(this.reportViewer2);
            this.Name = "ResultsDisplayForm";
            this.Text = "resultsDisplayForm";
            this.Load += new System.EventHandler(this.ResultsDisplayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vResultsDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.resultsDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource statisticsBindingSource;
        private System.Windows.Forms.BindingSource vResultsDataTableBindingSource;
        private System.Windows.Forms.BindingSource ResultsDataSetBindingSource;
        
        private System.Windows.Forms.BindingSource resultsDataSetBindingSource1;
        private System.Data.DataSet dataSet1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}