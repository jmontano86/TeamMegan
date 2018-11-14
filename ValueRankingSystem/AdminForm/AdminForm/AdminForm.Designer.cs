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
            this.deleteItemButton = new MetroFramework.Controls.MetroButton();
            this.addItemButton = new MetroFramework.Controls.MetroButton();
            this.finishButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.addTestButton = new MetroFramework.Controls.MetroButton();
            this.editTestComboBox = new MetroFramework.Controls.MetroComboBox();
            this.testNameLabel = new MetroFramework.Controls.MetroLabel();
            this.deleteTestButton = new MetroFramework.Controls.MetroButton();
            this.customButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.testTypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsDataGrid
            // 
            this.itemsDataGrid.AllowUserToAddRows = false;
            this.itemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNameColumn,
            this.ImageColumn});
            this.itemsDataGrid.Location = new System.Drawing.Point(177, 75);
            this.itemsDataGrid.MultiSelect = false;
            this.itemsDataGrid.Name = "itemsDataGrid";
            this.itemsDataGrid.Size = new System.Drawing.Size(359, 196);
            this.itemsDataGrid.TabIndex = 24;
            this.itemsDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsDataGrid_CellEndEdit);
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Enabled = false;
            this.deleteItemButton.Location = new System.Drawing.Point(256, 307);
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
            this.addItemButton.Location = new System.Drawing.Point(177, 307);
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
            this.finishButton.Location = new System.Drawing.Point(256, 336);
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
            this.cancelButton.Location = new System.Drawing.Point(336, 336);
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
            this.editTestComboBox.Location = new System.Drawing.Point(23, 140);
            this.editTestComboBox.Name = "editTestComboBox";
            this.editTestComboBox.Size = new System.Drawing.Size(121, 29);
            this.editTestComboBox.TabIndex = 23;
            this.editTestComboBox.UseSelectable = true;
            this.editTestComboBox.SelectionChangeCommitted += new System.EventHandler(this.editTestComboBox_SelectionChangeCommitted);
            // 
            // testNameLabel
            // 
            this.testNameLabel.AutoSize = true;
            this.testNameLabel.Location = new System.Drawing.Point(177, 274);
            this.testNameLabel.Name = "testNameLabel";
            this.testNameLabel.Size = new System.Drawing.Size(81, 19);
            this.testNameLabel.TabIndex = 25;
            this.testNameLabel.Text = "metroLabel1";
            this.testNameLabel.Visible = false;
            // 
            // deleteTestButton
            // 
            this.deleteTestButton.Enabled = false;
            this.deleteTestButton.Location = new System.Drawing.Point(338, 307);
            this.deleteTestButton.Name = "deleteTestButton";
            this.deleteTestButton.Size = new System.Drawing.Size(73, 23);
            this.deleteTestButton.TabIndex = 26;
            this.deleteTestButton.Text = "Delete test";
            this.deleteTestButton.UseSelectable = true;
            this.deleteTestButton.Click += new System.EventHandler(this.deleteTestButton_Click);
            // 
            // customButton
            // 
            this.customButton.Enabled = false;
            this.customButton.Location = new System.Drawing.Point(177, 336);
            this.customButton.Name = "customButton";
            this.customButton.Size = new System.Drawing.Size(73, 23);
            this.customButton.TabIndex = 0;
            this.customButton.Text = "&Custom Test";
            this.customButton.UseSelectable = true;
            this.customButton.Click += new System.EventHandler(this.customButton_Click);

			//
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 118);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "Edit a test";
            // 
            // testTypeComboBox
            // 
            this.testTypeComboBox.FormattingEnabled = true;
            this.testTypeComboBox.ItemHeight = 23;
            this.testTypeComboBox.Items.AddRange(new object[] {
            "Text",
            "Image",
            "Text and image"});
            this.testTypeComboBox.Location = new System.Drawing.Point(23, 214);
            this.testTypeComboBox.Name = "testTypeComboBox";
            this.testTypeComboBox.Size = new System.Drawing.Size(121, 29);
            this.testTypeComboBox.TabIndex = 28;
            this.testTypeComboBox.UseSelectable = true;
            this.testTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.testTypeComboBox_SelectionChangeCommitted);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 189);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 19);
            this.metroLabel2.TabIndex = 29;
            this.metroLabel2.Text = "Test type";
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePictureBox.Location = new System.Drawing.Point(575, 75);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(319, 341);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 30;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.imagePictureBox_DragEnter);
            // 
            // itemNameColumn
            // 
            this.itemNameColumn.HeaderText = "Item name";
            this.itemNameColumn.Name = "itemNameColumn";
            this.itemNameColumn.Width = 150;
            // 
            // ImageColumn
            // 
            this.ImageColumn.HeaderText = "Image";
            this.ImageColumn.Name = "ImageColumn";
            this.ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ImageColumn.Width = 150;
            // 
            // AdminForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customButton);
            this.ClientSize = new System.Drawing.Size(917, 465);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.testTypeComboBox);
            this.Controls.Add(this.metroLabel1);
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
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AdminForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AdminForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView itemsDataGrid;
        private MetroFramework.Controls.MetroButton deleteItemButton;
        private MetroFramework.Controls.MetroButton addItemButton;
        private MetroFramework.Controls.MetroButton finishButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroButton addTestButton;
        private MetroFramework.Controls.MetroComboBox editTestComboBox;
        private MetroFramework.Controls.MetroLabel testNameLabel;
        private MetroFramework.Controls.MetroButton deleteTestButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox testTypeComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameColumn;
        private MetroFramework.Controls.MetroButton customButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageColumn;
    }
}

