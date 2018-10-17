namespace UserTesting
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
            this.SuspendLayout();
            // 
            // userChoiceOne
            // 
            this.userChoiceOne.AutoSize = true;
            this.userChoiceOne.Location = new System.Drawing.Point(116, 263);
            this.userChoiceOne.Name = "userChoiceOne";
            this.userChoiceOne.Size = new System.Drawing.Size(65, 17);
            this.userChoiceOne.TabIndex = 0;
            this.userChoiceOne.Text = "demo1";
            this.userChoiceOne.UseSelectable = true;
            // 
            // userChoiceTwo
            // 
            this.userChoiceTwo.AutoSize = true;
            this.userChoiceTwo.Location = new System.Drawing.Point(320, 263);
            this.userChoiceTwo.Name = "userChoiceTwo";
            this.userChoiceTwo.Size = new System.Drawing.Size(65, 17);
            this.userChoiceTwo.TabIndex = 1;
            this.userChoiceTwo.Text = "demo2";
            this.userChoiceTwo.UseSelectable = true;
            // 
            // userChoiceThree
            // 
            this.userChoiceThree.AutoSize = true;
            this.userChoiceThree.Location = new System.Drawing.Point(524, 263);
            this.userChoiceThree.Name = "userChoiceThree";
            this.userChoiceThree.Size = new System.Drawing.Size(124, 17);
            this.userChoiceThree.TabIndex = 2;
            this.userChoiceThree.Text = "demoCantDecide";
            this.userChoiceThree.UseSelectable = true;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(285, 339);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(226, 66);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "&Next";
            this.testButton.UseSelectable = true;
            this.testButton.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(227, 123);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(322, 20);
            this.directionLabel.TabIndex = 4;
            this.directionLabel.Text = "From the choices below, which one do you prefer?";
            // 
            // UserTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.userChoiceThree);
            this.Controls.Add(this.userChoiceTwo);
            this.Controls.Add(this.userChoiceOne);
            this.Name = "UserTest";
            this.Text = "User Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroRadioButton userChoiceOne;
        private MetroFramework.Controls.MetroRadioButton userChoiceTwo;
        private MetroFramework.Controls.MetroRadioButton userChoiceThree;
        private MetroFramework.Controls.MetroButton testButton;
        private MetroFramework.Controls.MetroLabel directionLabel;
    }
}

