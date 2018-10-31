namespace AdminForm
{
    partial class AdminForm
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
            this.itemsDataGrid = new System.Windows.Forms.DataGridView();
            this.itemNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteItemButton = new MetroFramework.Controls.MetroButton();
            this.addItemButton = new MetroFramework.Controls.MetroButton();
            this.finishButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.addTestButton = new MetroFramework.Controls.MetroButton();
            this.editTestComboBox = new MetroFramework.Controls.MetroComboBox();
            this.testNameLabel = new MetroFramework.Controls.MetroLabel();
            this.deleteTestButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsDataGrid
            // 
            this.itemsDataGrid.AllowUserToAddRows = false;
            this.itemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNumberColumn,
            this.itemNameColumn});
            this.itemsDataGrid.Location = new System.Drawing.Point(170, 75);
            this.itemsDataGrid.Name = "itemsDataGrid";
            this.itemsDataGrid.Size = new System.Drawing.Size(321, 196);
            this.itemsDataGrid.TabIndex = 24;
            this.itemsDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsDataGrid_CellEndEdit);
            // 
            // itemNumberColumn
            // 
            this.itemNumberColumn.HeaderText = "Item number";
            this.itemNumberColumn.Name = "itemNumberColumn";
            this.itemNumberColumn.ReadOnly = true;
            // 
            // itemNameColumn
            // 
            this.itemNameColumn.HeaderText = "Item name";
            this.itemNameColumn.Name = "itemNameColumn";
            this.itemNameColumn.Width = 150;
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Enabled = false;
            this.deleteItemButton.Location = new System.Drawing.Point(336, 309);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(75, 23);
            this.deleteItemButton.TabIndex = 18;
            this.deleteItemButton.Text = "Delete item";
            this.deleteItemButton.UseSelectable = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.Enabled = false;
            this.addItemButton.Location = new System.Drawing.Point(257, 309);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(73, 23);
            this.addItemButton.TabIndex = 19;
            this.addItemButton.Text = "Add item";
            this.addItemButton.UseSelectable = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Enabled = false;
            this.finishButton.Location = new System.Drawing.Point(336, 338);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(74, 23);
            this.finishButton.TabIndex = 20;
            this.finishButton.Text = "Finish";
            this.finishButton.UseSelectable = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(416, 338);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addTestButton
            // 
            this.addTestButton.Location = new System.Drawing.Point(23, 75);
            this.addTestButton.Name = "addTestButton";
            this.addTestButton.Size = new System.Drawing.Size(123, 23);
            this.addTestButton.TabIndex = 22;
            this.addTestButton.Text = "Add a test";
            this.addTestButton.UseSelectable = true;
            this.addTestButton.Click += new System.EventHandler(this.addTestButton_Click);
            // 
            // editTestComboBox
            // 
            this.editTestComboBox.FormattingEnabled = true;
            this.editTestComboBox.ItemHeight = 23;
            this.editTestComboBox.Location = new System.Drawing.Point(24, 105);
            this.editTestComboBox.Name = "editTestComboBox";
            this.editTestComboBox.Size = new System.Drawing.Size(121, 29);
            this.editTestComboBox.TabIndex = 23;
            this.editTestComboBox.UseSelectable = true;
            this.editTestComboBox.SelectionChangeCommitted += new System.EventHandler(this.editTestComboBox_SelectionChangeCommitted);
            // 
            // testNameLabel
            // 
            this.testNameLabel.AutoSize = true;
            this.testNameLabel.Location = new System.Drawing.Point(170, 274);
            this.testNameLabel.Name = "testNameLabel";
            this.testNameLabel.Size = new System.Drawing.Size(81, 19);
            this.testNameLabel.TabIndex = 25;
            this.testNameLabel.Text = "metroLabel1";
            this.testNameLabel.Visible = false;
            // 
            // deleteTestButton
            // 
            this.deleteTestButton.Location = new System.Drawing.Point(418, 309);
            this.deleteTestButton.Name = "deleteTestButton";
            this.deleteTestButton.Size = new System.Drawing.Size(73, 23);
            this.deleteTestButton.TabIndex = 26;
            this.deleteTestButton.Text = "Delete test";
            this.deleteTestButton.UseSelectable = true;
            this.deleteTestButton.Click += new System.EventHandler(this.deleteTestButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 465);
            this.Controls.Add(this.deleteTestButton);
            this.Controls.Add(this.itemsDataGrid);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addTestButton);
            this.Controls.Add(this.editTestComboBox);
            this.Controls.Add(this.testNameLabel);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView itemsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameColumn;
        private MetroFramework.Controls.MetroButton deleteItemButton;
        private MetroFramework.Controls.MetroButton addItemButton;
        private MetroFramework.Controls.MetroButton finishButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroButton addTestButton;
        private MetroFramework.Controls.MetroComboBox editTestComboBox;
        private MetroFramework.Controls.MetroLabel testNameLabel;
        private MetroFramework.Controls.MetroButton deleteTestButton;
    }
}

