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
            this.testButton = new MetroFramework.Controls.MetroButton();
            this.directionLabel = new MetroFramework.Controls.MetroLabel();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.finishedLabel = new MetroFramework.Controls.MetroLabel();
            this.testProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.numeratorLabel = new MetroFramework.Controls.MetroLabel();
            this.slashLabel = new MetroFramework.Controls.MetroLabel();
            this.denominatorLabel = new MetroFramework.Controls.MetroLabel();
            this.userChoiceOne = new System.Windows.Forms.RadioButton();
            this.userChoiceTwo = new System.Windows.Forms.RadioButton();
            this.userChoiceThree = new System.Windows.Forms.RadioButton();
            this.itemGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(499, 516);
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
            this.directionLabel.Location = new System.Drawing.Point(436, 96);
            this.directionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(303, 19);
            this.directionLabel.TabIndex = 4;
            this.directionLabel.Text = "From the choices below, which one do you prefer?";
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.Controls.Add(this.userChoiceThree);
            this.itemGroupBox.Controls.Add(this.userChoiceTwo);
            this.itemGroupBox.Controls.Add(this.userChoiceOne);
            this.itemGroupBox.Controls.Add(this.finishedLabel);
            this.itemGroupBox.Location = new System.Drawing.Point(66, 145);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(1014, 346);
            this.itemGroupBox.TabIndex = 5;
            this.itemGroupBox.TabStop = false;
            this.itemGroupBox.Text = "Choices";
            // 
            // finishedLabel
            // 
            this.finishedLabel.AutoSize = true;
            this.finishedLabel.Location = new System.Drawing.Point(281, 152);
            this.finishedLabel.Name = "finishedLabel";
            this.finishedLabel.Size = new System.Drawing.Size(322, 19);
            this.finishedLabel.TabIndex = 3;
            this.finishedLabel.Text = "Thank you for taking the test. Please close this window";
            this.finishedLabel.Visible = false;
            // 
            // testProgressBar
            // 
            this.testProgressBar.Location = new System.Drawing.Point(483, 613);
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Size = new System.Drawing.Size(203, 23);
            this.testProgressBar.TabIndex = 6;
            // 
            // numeratorLabel
            // 
            this.numeratorLabel.AutoSize = true;
            this.numeratorLabel.Location = new System.Drawing.Point(704, 615);
            this.numeratorLabel.Name = "numeratorLabel";
            this.numeratorLabel.Size = new System.Drawing.Size(15, 19);
            this.numeratorLabel.TabIndex = 7;
            this.numeratorLabel.Text = "x";
            // 
            // slashLabel
            // 
            this.slashLabel.AutoSize = true;
            this.slashLabel.Location = new System.Drawing.Point(721, 615);
            this.slashLabel.Name = "slashLabel";
            this.slashLabel.Size = new System.Drawing.Size(14, 19);
            this.slashLabel.TabIndex = 8;
            this.slashLabel.Text = "/";
            // 
            // denominatorLabel
            // 
            this.denominatorLabel.AutoSize = true;
            this.denominatorLabel.Location = new System.Drawing.Point(737, 615);
            this.denominatorLabel.Name = "denominatorLabel";
            this.denominatorLabel.Size = new System.Drawing.Size(15, 19);
            this.denominatorLabel.TabIndex = 9;
            this.denominatorLabel.Text = "x";
            // 
            // userChoiceOne
            // 
            this.userChoiceOne.AutoSize = true;
            this.userChoiceOne.Location = new System.Drawing.Point(15, 15);
            this.userChoiceOne.Name = "userChoiceOne";
            this.userChoiceOne.Size = new System.Drawing.Size(97, 17);
            this.userChoiceOne.TabIndex = 4;
            this.userChoiceOne.TabStop = true;
            this.userChoiceOne.Text = "userChoiseOne";
            this.userChoiceOne.UseVisualStyleBackColor = true;
            this.userChoiceOne.CheckedChanged += new System.EventHandler(this.userChoiceOne_CheckedChanged);
            // 
            // userChoiceTwo
            // 
            this.userChoiceTwo.AutoSize = true;
            this.userChoiceTwo.Location = new System.Drawing.Point(345, 15);
            this.userChoiceTwo.Name = "userChoiceTwo";
            this.userChoiceTwo.Size = new System.Drawing.Size(98, 17);
            this.userChoiceTwo.TabIndex = 5;
            this.userChoiceTwo.TabStop = true;
            this.userChoiceTwo.Text = "userChoiseTwo";
            this.userChoiceTwo.UseVisualStyleBackColor = true;
            this.userChoiceTwo.CheckedChanged += new System.EventHandler(this.userChoiceTwo_CheckedChanged);
            // 
            // userChoiceThree
            // 
            this.userChoiceThree.AutoSize = true;
            this.userChoiceThree.Location = new System.Drawing.Point(675, 15);
            this.userChoiceThree.Name = "userChoiceThree";
            this.userChoiceThree.Size = new System.Drawing.Size(106, 17);
            this.userChoiceThree.TabIndex = 6;
            this.userChoiceThree.TabStop = true;
            this.userChoiceThree.Text = "userChoiceThree";
            this.userChoiceThree.UseVisualStyleBackColor = true;
            this.userChoiceThree.CheckedChanged += new System.EventHandler(this.userChoiceThree_CheckedChanged);
            // 
            // UserTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 690);
            this.Controls.Add(this.denominatorLabel);
            this.Controls.Add(this.slashLabel);
            this.Controls.Add(this.numeratorLabel);
            this.Controls.Add(this.testProgressBar);
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
        private MetroFramework.Controls.MetroButton testButton;
        private MetroFramework.Controls.MetroLabel directionLabel;
        private System.Windows.Forms.GroupBox itemGroupBox;
        private MetroFramework.Controls.MetroLabel finishedLabel;
        private MetroFramework.Controls.MetroProgressBar testProgressBar;
        private MetroFramework.Controls.MetroLabel numeratorLabel;
        private MetroFramework.Controls.MetroLabel slashLabel;
        private MetroFramework.Controls.MetroLabel denominatorLabel;
        private System.Windows.Forms.RadioButton userChoiceThree;
        private System.Windows.Forms.RadioButton userChoiceTwo;
        private System.Windows.Forms.RadioButton userChoiceOne;
    }
}

