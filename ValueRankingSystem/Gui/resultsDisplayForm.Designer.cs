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
            this.DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vResultsDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vResultsDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataSetBindingSource
            // 
            this.DataSetBindingSource.DataMember = "vResults";
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Gui.Report.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(49, 76);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.ShowBackButton = false;
            this.reportViewer2.ShowExportButton = false;
            this.reportViewer2.ShowFindControls = false;
            this.reportViewer2.ShowPageNavigationControls = false;
            this.reportViewer2.ShowStopButton = false;
            this.reportViewer2.ShowZoomControl = false;
            this.reportViewer2.Size = new System.Drawing.Size(690, 604);
            this.reportViewer2.TabIndex = 0;
            // 
            // ResultsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 724);
            this.Controls.Add(this.reportViewer2);
            this.Name = "ResultsDisplayForm";
            this.Text = "Global Statistics";
            this.Load += new System.EventHandler(this.ResultsDisplayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vResultsDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource DataSetBindingSource;
        private System.Windows.Forms.BindingSource vResultsDataTableBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}