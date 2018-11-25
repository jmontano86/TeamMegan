namespace Gui
{
    partial class CustomTestForm
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
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.item1ListBox = new System.Windows.Forms.ListBox();
            this.item2ListBox = new System.Windows.Forms.ListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.option1Button = new MetroFramework.Controls.MetroButton();
            this.option2Button = new MetroFramework.Controls.MetroButton();
            this.customErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.shuffleCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.finishButton = new MetroFramework.Controls.MetroButton();
            this.removeOption1Buttn = new MetroFramework.Controls.MetroButton();
            this.removeOption2Button = new MetroFramework.Controls.MetroButton();
            this.customToolTip = new MetroFramework.Components.MetroToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.customErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsListBox
            // 
            this.itemsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.ItemHeight = 16;
            this.itemsListBox.Location = new System.Drawing.Point(23, 119);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(155, 260);
            this.itemsListBox.TabIndex = 1;
            this.customToolTip.SetToolTip(this.itemsListBox, "Select an Item then add it to Option 1 or Option 2");
            this.itemsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.itemsListBox_MouseDown);
            // 
            // item1ListBox
            // 
            this.item1ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.item1ListBox.FormattingEnabled = true;
            this.item1ListBox.ItemHeight = 16;
            this.item1ListBox.Location = new System.Drawing.Point(409, 119);
            this.item1ListBox.Name = "item1ListBox";
            this.item1ListBox.Size = new System.Drawing.Size(155, 260);
            this.item1ListBox.TabIndex = 2;
            this.customToolTip.SetToolTip(this.item1ListBox, "To Reorder, drag and drop items. To Delete, select an item and then either press " +
        "the Delete key.");
            this.item1ListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.item1ListBox_DragDrop);
            this.item1ListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.item1ListBox_DragOver);
            this.item1ListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item1ListBox_KeyUp);
            this.item1ListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item1ListBox_MouseDown);
            // 
            // item2ListBox
            // 
            this.item2ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.item2ListBox.FormattingEnabled = true;
            this.item2ListBox.ItemHeight = 16;
            this.item2ListBox.Location = new System.Drawing.Point(608, 119);
            this.item2ListBox.Name = "item2ListBox";
            this.item2ListBox.Size = new System.Drawing.Size(155, 260);
            this.item2ListBox.TabIndex = 3;
            this.customToolTip.SetToolTip(this.item2ListBox, "To Reorder, drag and drop items. To Delete, select an item and then either press " +
        "the Delete key.");
            this.item2ListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.item2ListBox_DragDrop);
            this.item2ListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.item2ListBox_DragOver);
            this.item2ListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item2ListBox_KeyUp);
            this.item2ListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item2ListBox_MouseDown);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(97, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Available Items";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(409, 94);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Option 1";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(608, 94);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(61, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Option 2";
            // 
            // option1Button
            // 
            this.option1Button.Location = new System.Drawing.Point(240, 165);
            this.option1Button.Name = "option1Button";
            this.option1Button.Size = new System.Drawing.Size(104, 23);
            this.option1Button.TabIndex = 7;
            this.option1Button.Text = "Add to Option &1";
            this.customToolTip.SetToolTip(this.option1Button, "Add selected Available Item to Option 1");
            this.option1Button.UseSelectable = true;
            this.option1Button.Click += new System.EventHandler(this.option1Button_Click);
            // 
            // option2Button
            // 
            this.option2Button.Location = new System.Drawing.Point(240, 221);
            this.option2Button.Name = "option2Button";
            this.option2Button.Size = new System.Drawing.Size(104, 23);
            this.option2Button.TabIndex = 8;
            this.option2Button.Text = "Add to Option &2";
            this.customToolTip.SetToolTip(this.option2Button, "Add selected Available Item to Option 2");
            this.option2Button.UseSelectable = true;
            this.option2Button.Click += new System.EventHandler(this.option2Button_Click);
            // 
            // customErrorProvider
            // 
            this.customErrorProvider.ContainerControl = this;
            // 
            // shuffleCheckBox
            // 
            this.shuffleCheckBox.AutoSize = true;
            this.shuffleCheckBox.Location = new System.Drawing.Point(240, 270);
            this.shuffleCheckBox.Name = "shuffleCheckBox";
            this.shuffleCheckBox.Size = new System.Drawing.Size(98, 15);
            this.shuffleCheckBox.TabIndex = 9;
            this.shuffleCheckBox.Text = "&Shuffle Order?";
            this.shuffleCheckBox.UseSelectable = true;
            this.shuffleCheckBox.CheckedChanged += new System.EventHandler(this.shuffleCheckBox_CheckedChanged);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(240, 356);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(104, 23);
            this.finishButton.TabIndex = 10;
            this.finishButton.Text = "&Finish";
            this.customToolTip.SetToolTip(this.finishButton, "Finish customization and submit changes");
            this.finishButton.UseSelectable = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // removeOption1Buttn
            // 
            this.removeOption1Buttn.Location = new System.Drawing.Point(409, 385);
            this.removeOption1Buttn.Name = "removeOption1Buttn";
            this.removeOption1Buttn.Size = new System.Drawing.Size(155, 23);
            this.removeOption1Buttn.TabIndex = 11;
            this.removeOption1Buttn.Text = "Remove Selected Item";
            this.customToolTip.SetToolTip(this.removeOption1Buttn, "Remove selected item from Option 1");
            this.removeOption1Buttn.UseSelectable = true;
            this.removeOption1Buttn.Click += new System.EventHandler(this.removeOption1Buttn_Click);
            // 
            // removeOption2Button
            // 
            this.removeOption2Button.Location = new System.Drawing.Point(608, 385);
            this.removeOption2Button.Name = "removeOption2Button";
            this.removeOption2Button.Size = new System.Drawing.Size(155, 23);
            this.removeOption2Button.TabIndex = 12;
            this.removeOption2Button.Text = "Remove Selected Item";
            this.customToolTip.SetToolTip(this.removeOption2Button, "Remove selected item from Option 2");
            this.removeOption2Button.UseSelectable = true;
            this.removeOption2Button.Click += new System.EventHandler(this.removeOption2Button_Click);
            // 
            // customToolTip
            // 
            this.customToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.customToolTip.StyleManager = null;
            this.customToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // CustomTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeOption2Button);
            this.Controls.Add(this.removeOption1Buttn);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.shuffleCheckBox);
            this.Controls.Add(this.option2Button);
            this.Controls.Add(this.option1Button);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.item2ListBox);
            this.Controls.Add(this.item1ListBox);
            this.Controls.Add(this.itemsListBox);
            this.Name = "CustomTestForm";
            this.Text = "Customize Your Test";
            this.Load += new System.EventHandler(this.CustomTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.ListBox item1ListBox;
        private System.Windows.Forms.ListBox item2ListBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton option1Button;
        private MetroFramework.Controls.MetroButton option2Button;
        private System.Windows.Forms.ErrorProvider customErrorProvider;
        private MetroFramework.Controls.MetroButton finishButton;
        private MetroFramework.Controls.MetroCheckBox shuffleCheckBox;
        private MetroFramework.Controls.MetroButton removeOption2Button;
        private MetroFramework.Controls.MetroButton removeOption1Buttn;
        private MetroFramework.Components.MetroToolTip customToolTip;
    }
}