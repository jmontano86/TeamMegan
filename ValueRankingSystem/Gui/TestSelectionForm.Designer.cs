namespace Gui
{
    partial class TestSelectionForm
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
            this.testSelectionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.selectLabel = new System.Windows.Forms.Label();
            this.submitButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // testSelectionComboBox
            // 
            this.testSelectionComboBox.FormattingEnabled = true;
            this.testSelectionComboBox.ItemHeight = 23;
            this.testSelectionComboBox.Location = new System.Drawing.Point(146, 180);
            this.testSelectionComboBox.Name = "testSelectionComboBox";
            this.testSelectionComboBox.Size = new System.Drawing.Size(214, 29);
            this.testSelectionComboBox.TabIndex = 0;
            this.testSelectionComboBox.UseSelectable = true;
            this.testSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.testSelectionComboBox_SelectedIndexChanged);
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLabel.Location = new System.Drawing.Point(62, 121);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(383, 24);
            this.selectLabel.TabIndex = 1;
            this.selectLabel.Text = "Please choose the test you would like to take";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(183, 243);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(140, 43);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseSelectable = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // TestSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 325);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.testSelectionComboBox);
            this.Name = "TestSelectionForm";
            this.Text = "TestSelectionForm";
            this.Load += new System.EventHandler(this.TestSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox testSelectionComboBox;
        private System.Windows.Forms.Label selectLabel;
        private MetroFramework.Controls.MetroButton submitButton;
    }
}