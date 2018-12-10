namespace Gui
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
            this.sizeLabel = new MetroFramework.Controls.MetroLabel();
            this.sizeTextLabel = new MetroFramework.Controls.MetroLabel();
            this.heightLabel = new MetroFramework.Controls.MetroLabel();
            this.heightTextLabel = new MetroFramework.Controls.MetroLabel();
            this.widthLabel = new MetroFramework.Controls.MetroLabel();
            this.widthTextLabel = new MetroFramework.Controls.MetroLabel();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.testTypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.deleteTestButton = new MetroFramework.Controls.MetroButton();
            this.deleteItemButton = new MetroFramework.Controls.MetroButton();
            this.addItemButton = new MetroFramework.Controls.MetroButton();
            this.finishButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.addTestButton = new MetroFramework.Controls.MetroButton();
            this.itemsDataGrid = new System.Windows.Forms.DataGridView();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.editTestComboBox = new MetroFramework.Controls.MetroComboBox();
            this.testNameLabel = new MetroFramework.Controls.MetroLabel();
            this.customTestButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(1027, 478);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(31, 19);
            this.sizeLabel.TabIndex = 55;
            this.sizeLabel.Text = "0KB";
            // 
            // sizeTextLabel
            // 
            this.sizeTextLabel.AutoSize = true;
            this.sizeTextLabel.Location = new System.Drawing.Point(997, 478);
            this.sizeTextLabel.Name = "sizeTextLabel";
            this.sizeTextLabel.Size = new System.Drawing.Size(35, 19);
            this.sizeTextLabel.TabIndex = 54;
            this.sizeTextLabel.Text = "Size:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(930, 478);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(30, 19);
            this.heightLabel.TabIndex = 53;
            this.heightLabel.Text = "0px";
            // 
            // heightTextLabel
            // 
            this.heightTextLabel.AutoSize = true;
            this.heightTextLabel.Location = new System.Drawing.Point(886, 478);
            this.heightTextLabel.Name = "heightTextLabel";
            this.heightTextLabel.Size = new System.Drawing.Size(50, 19);
            this.heightTextLabel.TabIndex = 52;
            this.heightTextLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(825, 478);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(30, 19);
            this.widthLabel.TabIndex = 51;
            this.widthLabel.Text = "0px";
            // 
            // widthTextLabel
            // 
            this.widthTextLabel.AutoSize = true;
            this.widthTextLabel.Location = new System.Drawing.Point(783, 478);
            this.widthTextLabel.Name = "widthTextLabel";
            this.widthTextLabel.Size = new System.Drawing.Size(47, 19);
            this.widthTextLabel.TabIndex = 50;
            this.widthTextLabel.Text = "Width:";
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePictureBox.Location = new System.Drawing.Point(783, 63);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(404, 400);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 49;
            this.imagePictureBox.TabStop = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(21, 177);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 19);
            this.metroLabel2.TabIndex = 48;
            this.metroLabel2.Text = "Test type";
            // 
            // testTypeComboBox
            // 
            this.testTypeComboBox.FormattingEnabled = true;
            this.testTypeComboBox.ItemHeight = 23;
            this.testTypeComboBox.Items.AddRange(new object[] {
            "Text",
            "Image",
            "Text and image"});
            this.testTypeComboBox.Location = new System.Drawing.Point(20, 202);
            this.testTypeComboBox.Name = "testTypeComboBox";
            this.testTypeComboBox.Size = new System.Drawing.Size(210, 29);
            this.testTypeComboBox.TabIndex = 47;
            this.testTypeComboBox.UseSelectable = true;
            this.testTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.testTypeComboBox_SelectionChangeCommitted);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 106);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 46;
            this.metroLabel1.Text = "Edit a test";
            // 
            // deleteTestButton
            // 
            this.deleteTestButton.Enabled = false;
            this.deleteTestButton.Location = new System.Drawing.Point(415, 511);
            this.deleteTestButton.Name = "deleteTestButton";
            this.deleteTestButton.Size = new System.Drawing.Size(77, 23);
            this.deleteTestButton.TabIndex = 45;
            this.deleteTestButton.Text = "Delete test";
            this.deleteTestButton.UseSelectable = true;
            this.deleteTestButton.Click += new System.EventHandler(this.deleteTestButton_Click);
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Enabled = false;
            this.deleteItemButton.Location = new System.Drawing.Point(333, 511);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(79, 23);
            this.deleteItemButton.TabIndex = 37;
            this.deleteItemButton.Text = "Delete item";
            this.deleteItemButton.UseSelectable = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.Enabled = false;
            this.addItemButton.Location = new System.Drawing.Point(254, 511);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(75, 23);
            this.addItemButton.TabIndex = 38;
            this.addItemButton.Text = "Add item";
            this.addItemButton.UseSelectable = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Enabled = false;
            this.finishButton.Location = new System.Drawing.Point(333, 540);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(78, 23);
            this.finishButton.TabIndex = 39;
            this.finishButton.Text = "Finish";
            this.finishButton.UseSelectable = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(413, 540);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(79, 23);
            this.cancelButton.TabIndex = 40;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addTestButton
            // 
            this.addTestButton.Location = new System.Drawing.Point(20, 63);
            this.addTestButton.Name = "addTestButton";
            this.addTestButton.Size = new System.Drawing.Size(212, 23);
            this.addTestButton.TabIndex = 41;
            this.addTestButton.Text = "Add a test";
            this.addTestButton.UseSelectable = true;
            this.addTestButton.Click += new System.EventHandler(this.addTestButton_Click);
            // 
            // itemsDataGrid
            // 
            this.itemsDataGrid.AllowUserToAddRows = false;
            this.itemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNameColumn,
            this.ImageColumn});
            this.itemsDataGrid.Location = new System.Drawing.Point(254, 63);
            this.itemsDataGrid.MultiSelect = false;
            this.itemsDataGrid.Name = "itemsDataGrid";
            this.itemsDataGrid.Size = new System.Drawing.Size(504, 400);
            this.itemsDataGrid.TabIndex = 43;
            this.itemsDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsDataGrid_CellEndEdit);
            this.itemsDataGrid.SelectionChanged += new System.EventHandler(this.itemsDataGrid_SelectionChanged);
            // 
            // itemNameColumn
            // 
            this.itemNameColumn.HeaderText = "Item name";
            this.itemNameColumn.Name = "itemNameColumn";
            this.itemNameColumn.Width = 227;
            // 
            // ImageColumn
            // 
            this.ImageColumn.HeaderText = "Image";
            this.ImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ImageColumn.Name = "ImageColumn";
            this.ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImageColumn.Width = 230;
            // 
            // editTestComboBox
            // 
            this.editTestComboBox.FormattingEnabled = true;
            this.editTestComboBox.ItemHeight = 23;
            this.editTestComboBox.Location = new System.Drawing.Point(20, 128);
            this.editTestComboBox.Name = "editTestComboBox";
            this.editTestComboBox.Size = new System.Drawing.Size(210, 29);
            this.editTestComboBox.TabIndex = 42;
            this.editTestComboBox.UseSelectable = true;
            this.editTestComboBox.SelectionChangeCommitted += new System.EventHandler(this.editTestComboBox_SelectionChangeCommitted);
            // 
            // testNameLabel
            // 
            this.testNameLabel.AutoSize = true;
            this.testNameLabel.Location = new System.Drawing.Point(254, 478);
            this.testNameLabel.Name = "testNameLabel";
            this.testNameLabel.Size = new System.Drawing.Size(81, 19);
            this.testNameLabel.TabIndex = 44;
            this.testNameLabel.Text = "metroLabel1";
            this.testNameLabel.Visible = false;
            // 
            // customTestButton
            // 
            this.customTestButton.Location = new System.Drawing.Point(254, 540);
            this.customTestButton.Name = "customTestButton";
            this.customTestButton.Size = new System.Drawing.Size(75, 23);
            this.customTestButton.TabIndex = 56;
            this.customTestButton.Text = "Custom Test";
            this.customTestButton.UseSelectable = true;
            this.customTestButton.Click += new System.EventHandler(this.customButton_Click);
            // 
            // AdminForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 602);
            this.Controls.Add(this.customTestButton);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.sizeTextLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.heightTextLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.widthTextLabel);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.testTypeComboBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.deleteTestButton);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addTestButton);
            this.Controls.Add(this.itemsDataGrid);
            this.Controls.Add(this.editTestComboBox);
            this.Controls.Add(this.testNameLabel);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AdminForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AdminForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private MetroFramework.Controls.MetroLabel sizeLabel;
        private MetroFramework.Controls.MetroLabel sizeTextLabel;
        private MetroFramework.Controls.MetroLabel heightLabel;
        private MetroFramework.Controls.MetroLabel heightTextLabel;
        private MetroFramework.Controls.MetroLabel widthLabel;
        private MetroFramework.Controls.MetroLabel widthTextLabel;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox testTypeComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton deleteTestButton;
        private MetroFramework.Controls.MetroButton deleteItemButton;
        private MetroFramework.Controls.MetroButton addItemButton;
        private MetroFramework.Controls.MetroButton finishButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroButton addTestButton;
        private System.Windows.Forms.DataGridView itemsDataGrid;
        private MetroFramework.Controls.MetroComboBox editTestComboBox;
        private MetroFramework.Controls.MetroLabel testNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameColumn;
        private System.Windows.Forms.DataGridViewImageColumn ImageColumn;
        private MetroFramework.Controls.MetroButton customTestButton;
    }

}