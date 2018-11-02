namespace CreateAccount
{
    partial class CreateAccountForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.nameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.emailTextBox = new MetroFramework.Controls.MetroTextBox();
            this.passwordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.reenterPasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.createButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.myErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(100, 91);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "&Name:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(53, 149);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(95, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "&Email Address:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(82, 207);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(66, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "&Password:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 265);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(125, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "&Re-Enter Password: ";
            // 
            // nameTextBox
            // 
            // 
            // 
            // 
            this.nameTextBox.CustomButton.Image = null;
            this.nameTextBox.CustomButton.Location = new System.Drawing.Point(197, 1);
            this.nameTextBox.CustomButton.Name = "";
            this.nameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameTextBox.CustomButton.TabIndex = 1;
            this.nameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameTextBox.CustomButton.UseSelectable = true;
            this.nameTextBox.CustomButton.Visible = false;
            this.nameTextBox.Lines = new string[0];
            this.nameTextBox.Location = new System.Drawing.Point(155, 86);
            this.nameTextBox.MaxLength = 32767;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PasswordChar = '\0';
            this.nameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameTextBox.SelectedText = "";
            this.nameTextBox.SelectionLength = 0;
            this.nameTextBox.SelectionStart = 0;
            this.nameTextBox.ShortcutsEnabled = true;
            this.nameTextBox.Size = new System.Drawing.Size(219, 23);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.UseSelectable = true;
            this.nameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // emailTextBox
            // 
            // 
            // 
            // 
            this.emailTextBox.CustomButton.Image = null;
            this.emailTextBox.CustomButton.Location = new System.Drawing.Point(197, 1);
            this.emailTextBox.CustomButton.Name = "";
            this.emailTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.emailTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailTextBox.CustomButton.TabIndex = 1;
            this.emailTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailTextBox.CustomButton.UseSelectable = true;
            this.emailTextBox.CustomButton.Visible = false;
            this.emailTextBox.Lines = new string[0];
            this.emailTextBox.Location = new System.Drawing.Point(155, 144);
            this.emailTextBox.MaxLength = 32767;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.PasswordChar = '\0';
            this.emailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextBox.SelectedText = "";
            this.emailTextBox.SelectionLength = 0;
            this.emailTextBox.SelectionStart = 0;
            this.emailTextBox.ShortcutsEnabled = true;
            this.emailTextBox.Size = new System.Drawing.Size(219, 23);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.UseSelectable = true;
            this.emailTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.emailTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.emailTextBox.Leave += new System.EventHandler(this.emailTextBox_Leave);
            // 
            // passwordTextBox
            // 
            // 
            // 
            // 
            this.passwordTextBox.CustomButton.Image = null;
            this.passwordTextBox.CustomButton.Location = new System.Drawing.Point(197, 1);
            this.passwordTextBox.CustomButton.Name = "";
            this.passwordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTextBox.CustomButton.TabIndex = 1;
            this.passwordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTextBox.CustomButton.UseSelectable = true;
            this.passwordTextBox.CustomButton.Visible = false;
            this.passwordTextBox.Lines = new string[0];
            this.passwordTextBox.Location = new System.Drawing.Point(155, 202);
            this.passwordTextBox.MaxLength = 32767;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '●';
            this.passwordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.SelectionLength = 0;
            this.passwordTextBox.SelectionStart = 0;
            this.passwordTextBox.ShortcutsEnabled = true;
            this.passwordTextBox.Size = new System.Drawing.Size(219, 23);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.UseSelectable = true;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // reenterPasswordTextBox
            // 
            // 
            // 
            // 
            this.reenterPasswordTextBox.CustomButton.Image = null;
            this.reenterPasswordTextBox.CustomButton.Location = new System.Drawing.Point(197, 1);
            this.reenterPasswordTextBox.CustomButton.Name = "";
            this.reenterPasswordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.reenterPasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.reenterPasswordTextBox.CustomButton.TabIndex = 1;
            this.reenterPasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.reenterPasswordTextBox.CustomButton.UseSelectable = true;
            this.reenterPasswordTextBox.CustomButton.Visible = false;
            this.reenterPasswordTextBox.Lines = new string[0];
            this.reenterPasswordTextBox.Location = new System.Drawing.Point(155, 261);
            this.reenterPasswordTextBox.MaxLength = 32767;
            this.reenterPasswordTextBox.Name = "reenterPasswordTextBox";
            this.reenterPasswordTextBox.PasswordChar = '●';
            this.reenterPasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.reenterPasswordTextBox.SelectedText = "";
            this.reenterPasswordTextBox.SelectionLength = 0;
            this.reenterPasswordTextBox.SelectionStart = 0;
            this.reenterPasswordTextBox.ShortcutsEnabled = true;
            this.reenterPasswordTextBox.Size = new System.Drawing.Size(219, 23);
            this.reenterPasswordTextBox.TabIndex = 7;
            this.reenterPasswordTextBox.UseSelectable = true;
            this.reenterPasswordTextBox.UseSystemPasswordChar = true;
            this.reenterPasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.reenterPasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.reenterPasswordTextBox.Leave += new System.EventHandler(this.reenterPasswordTextBox_Leave);
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(23, 325);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(107, 23);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "&Create Account";
            this.createButton.UseSelectable = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(267, 325);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(107, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Ca&ncel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // myErrorProvider
            // 
            this.myErrorProvider.ContainerControl = this;
            // 
            // CreateAccountForm
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(397, 380);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.reenterPasswordTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "CreateAccountForm";
            this.Text = "Create an Account";
            this.Load += new System.EventHandler(this.CreateAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox nameTextBox;
        private MetroFramework.Controls.MetroTextBox emailTextBox;
        private MetroFramework.Controls.MetroTextBox passwordTextBox;
        private MetroFramework.Controls.MetroTextBox reenterPasswordTextBox;
        private MetroFramework.Controls.MetroButton createButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private System.Windows.Forms.ErrorProvider myErrorProvider;
    }
}

