namespace Gui
{
    partial class ResultsReportingForm
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
            this.patientLabel = new MetroFramework.Controls.MetroLabel();
            this.testLabel = new MetroFramework.Controls.MetroLabel();
            this.dateLabel = new MetroFramework.Controls.MetroLabel();
            this.patientComboBox = new MetroFramework.Controls.MetroComboBox();
            this.testComboBox = new MetroFramework.Controls.MetroComboBox();
            this.dateComboBox = new MetroFramework.Controls.MetroComboBox();
            this.TestItemHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalScoreHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WinsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TiesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LossesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TestScoreListView = new MetroFramework.Controls.MetroListView();
            this.resultsButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.patientLabel.Location = new System.Drawing.Point(63, 107);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(126, 25);
            this.patientLabel.TabIndex = 0;
            this.patientLabel.Text = "Select a Patient";
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.testLabel.Location = new System.Drawing.Point(63, 159);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(102, 25);
            this.testLabel.TabIndex = 1;
            this.testLabel.Text = "Select a Test";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.dateLabel.Location = new System.Drawing.Point(63, 213);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(96, 25);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Select Date";
            // 
            // patientComboBox
            // 
            this.patientComboBox.FormattingEnabled = true;
            this.patientComboBox.ItemHeight = 23;
            this.patientComboBox.Location = new System.Drawing.Point(224, 104);
            this.patientComboBox.Name = "patientComboBox";
            this.patientComboBox.Size = new System.Drawing.Size(162, 29);
            this.patientComboBox.TabIndex = 3;
            this.patientComboBox.UseSelectable = true;
            this.patientComboBox.SelectedIndexChanged += new System.EventHandler(this.patientComboBox_SelectedIndexChanged);
            // 
            // testComboBox
            // 
            this.testComboBox.FormattingEnabled = true;
            this.testComboBox.ItemHeight = 23;
            this.testComboBox.Location = new System.Drawing.Point(224, 159);
            this.testComboBox.Name = "testComboBox";
            this.testComboBox.Size = new System.Drawing.Size(162, 29);
            this.testComboBox.TabIndex = 4;
            this.testComboBox.UseSelectable = true;
            this.testComboBox.SelectedIndexChanged += new System.EventHandler(this.testComboBox_SelectedIndexChanged);
            // 
            // dateComboBox
            // 
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.ItemHeight = 23;
            this.dateComboBox.Location = new System.Drawing.Point(224, 213);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(162, 29);
            this.dateComboBox.TabIndex = 5;
            this.dateComboBox.UseSelectable = true;
            this.dateComboBox.SelectedIndexChanged += new System.EventHandler(this.dateComboBox_SelectedIndexChanged);
            // 
            // TestItemHeader
            // 
            this.TestItemHeader.Text = "Test Item";
            this.TestItemHeader.Width = 83;
            // 
            // TotalScoreHeader
            // 
            this.TotalScoreHeader.Text = "Total Score";
            this.TotalScoreHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TotalScoreHeader.Width = 97;
            // 
            // WinsHeader
            // 
            this.WinsHeader.Text = "Wins";
            this.WinsHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TiesHeader
            // 
            this.TiesHeader.Text = "Ties";
            this.TiesHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LossesHeader
            // 
            this.LossesHeader.Text = "Losses";
            this.LossesHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TestScoreListView
            // 
            this.TestScoreListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TestItemHeader,
            this.TotalScoreHeader,
            this.WinsHeader,
            this.TiesHeader,
            this.LossesHeader});
            this.TestScoreListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TestScoreListView.FullRowSelect = true;
            this.TestScoreListView.Location = new System.Drawing.Point(451, 104);
            this.TestScoreListView.Name = "TestScoreListView";
            this.TestScoreListView.OwnerDraw = true;
            this.TestScoreListView.Size = new System.Drawing.Size(378, 306);
            this.TestScoreListView.TabIndex = 6;
            this.TestScoreListView.UseCompatibleStateImageBehavior = false;
            this.TestScoreListView.UseSelectable = true;
            this.TestScoreListView.View = System.Windows.Forms.View.Details;
            // 
            // resultsButton
            // 
            this.resultsButton.Enabled = false;
            this.resultsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resultsButton.Location = new System.Drawing.Point(451, 436);
            this.resultsButton.Name = "resultsButton";
            this.resultsButton.Size = new System.Drawing.Size(109, 23);
            this.resultsButton.TabIndex = 7;
            this.resultsButton.Text = "Global Results";
            this.resultsButton.UseSelectable = true;
            this.resultsButton.Click += new System.EventHandler(this.resultsButton_Click);
            // 
            // ResultsReportingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 504);
            this.Controls.Add(this.resultsButton);
            this.Controls.Add(this.TestScoreListView);
            this.Controls.Add(this.dateComboBox);
            this.Controls.Add(this.testComboBox);
            this.Controls.Add(this.patientComboBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.patientLabel);
            this.Name = "ResultsReportingForm";
            this.Text = "Assessment Results";
            this.Load += new System.EventHandler(this.ResultsReporting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel patientLabel;
        private MetroFramework.Controls.MetroLabel testLabel;
        private MetroFramework.Controls.MetroLabel dateLabel;
        private MetroFramework.Controls.MetroComboBox patientComboBox;
        private MetroFramework.Controls.MetroComboBox testComboBox;
        private MetroFramework.Controls.MetroComboBox dateComboBox;
        private System.Windows.Forms.ColumnHeader TestItemHeader;
        private System.Windows.Forms.ColumnHeader TotalScoreHeader;
        private System.Windows.Forms.ColumnHeader WinsHeader;
        private System.Windows.Forms.ColumnHeader TiesHeader;
        private System.Windows.Forms.ColumnHeader LossesHeader;
        private MetroFramework.Controls.MetroListView TestScoreListView;
        private MetroFramework.Controls.MetroButton resultsButton;
    }
}

