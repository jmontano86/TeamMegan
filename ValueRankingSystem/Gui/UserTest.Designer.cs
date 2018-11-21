namespace Gui
{
    partial class UserTest
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
            this.userChoiceOne = new MetroFramework.Controls.MetroRadioButton();
            this.userChoiceTwo = new MetroFramework.Controls.MetroRadioButton();
            this.userChoiceThree = new MetroFramework.Controls.MetroRadioButton();
            this.testButton = new MetroFramework.Controls.MetroButton();
            this.directionLabel = new MetroFramework.Controls.MetroLabel();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.finishedLabel = new MetroFramework.Controls.MetroLabel();
            this.itemGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userChoiceOne
            // 
            this.userChoiceOne.AutoSize = true;
            this.userChoiceOne.Location = new System.Drawing.Point(61, 49);
            this.userChoiceOne.Margin = new System.Windows.Forms.Padding(2);
            this.userChoiceOne.Name = "userChoiceOne";
            this.userChoiceOne.Size = new System.Drawing.Size(60, 15);
            this.userChoiceOne.TabIndex = 0;
            this.userChoiceOne.Text = "demo1";
            this.userChoiceOne.UseSelectable = true;
            this.userChoiceOne.CheckedChanged += new System.EventHandler(this.userChoiceOne_CheckedChanged);
            // 
            // userChoiceTwo
            // 
            this.userChoiceTwo.AutoSize = true;
            this.userChoiceTwo.Location = new System.Drawing.Point(165, 49);
            this.userChoiceTwo.Margin = new System.Windows.Forms.Padding(2);
            this.userChoiceTwo.Name = "userChoiceTwo";
            this.userChoiceTwo.Size = new System.Drawing.Size(60, 15);
            this.userChoiceTwo.TabIndex = 1;
            this.userChoiceTwo.Text = "demo2";
            this.userChoiceTwo.UseSelectable = true;
            this.userChoiceTwo.CheckedChanged += new System.EventHandler(this.userChoiceTwo_CheckedChanged);
            // 
            // userChoiceThree
            // 
            this.userChoiceThree.AutoSize = true;
            this.userChoiceThree.Location = new System.Drawing.Point(269, 49);
            this.userChoiceThree.Margin = new System.Windows.Forms.Padding(2);
            this.userChoiceThree.Name = "userChoiceThree";
            this.userChoiceThree.Size = new System.Drawing.Size(115, 15);
            this.userChoiceThree.TabIndex = 2;
            this.userChoiceThree.Text = "demoCantDecide";
            this.userChoiceThree.UseSelectable = true;
            this.userChoiceThree.CheckedChanged += new System.EventHandler(this.userChoiceThree_CheckedChanged);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(214, 275);
            this.testButton.Margin = new System.Windows.Forms.Padding(2);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(170, 54);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "&Next";
            this.testButton.UseSelectable = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(150, 96);
            this.directionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(303, 19);
            this.directionLabel.TabIndex = 4;
            this.directionLabel.Text = "From the choices below, which one do you prefer?";
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.Controls.Add(this.finishedLabel);
            this.itemGroupBox.Controls.Add(this.userChoiceOne);
            this.itemGroupBox.Controls.Add(this.userChoiceTwo);
            this.itemGroupBox.Controls.Add(this.userChoiceThree);
            this.itemGroupBox.Location = new System.Drawing.Point(79, 142);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(440, 100);
            this.itemGroupBox.TabIndex = 5;
            this.itemGroupBox.TabStop = false;
            this.itemGroupBox.Text = "Choices";
            // 
            // finishedLabel
            // 
            this.finishedLabel.AutoSize = true;
            this.finishedLabel.Location = new System.Drawing.Point(54, 44);
            this.finishedLabel.Name = "finishedLabel";
            this.finishedLabel.Size = new System.Drawing.Size(322, 19);
            this.finishedLabel.TabIndex = 3;
            this.finishedLabel.Text = "Thank you for taking the test. Please close this window";
            this.finishedLabel.Visible = false;
            // 
            // UserTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.itemGroupBox);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.testButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserTest";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Text = "User Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.itemGroupBox.ResumeLayout(false);
            this.itemGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroRadioButton userChoiceOne;
        private MetroFramework.Controls.MetroRadioButton userChoiceTwo;
        private MetroFramework.Controls.MetroRadioButton userChoiceThree;
        private MetroFramework.Controls.MetroButton testButton;
        private MetroFramework.Controls.MetroLabel directionLabel;
        private System.Windows.Forms.GroupBox itemGroupBox;
        private MetroFramework.Controls.MetroLabel finishedLabel;
    }
}

