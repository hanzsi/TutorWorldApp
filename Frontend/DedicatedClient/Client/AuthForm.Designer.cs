namespace Client
{
    partial class AuthForm
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
            this.lblReg = new System.Windows.Forms.Label();
            this.lblPw1 = new System.Windows.Forms.Label();
            this.tbPw1 = new System.Windows.Forms.TextBox();
            this.lblPw2 = new System.Windows.Forms.Label();
            this.tbPw2 = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.lblChoose = new System.Windows.Forms.Label();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.rbTeacher = new System.Windows.Forms.RadioButton();
            this.regTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.loginEmailBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loginPasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblReg.Location = new System.Drawing.Point(192, 22);
            this.lblReg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(108, 24);
            this.lblReg.TabIndex = 0;
            this.lblReg.Text = "Registration";
            // 
            // lblPw1
            // 
            this.lblPw1.AutoSize = true;
            this.lblPw1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPw1.Location = new System.Drawing.Point(71, 121);
            this.lblPw1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPw1.Name = "lblPw1";
            this.lblPw1.Size = new System.Drawing.Size(84, 20);
            this.lblPw1.TabIndex = 4;
            this.lblPw1.Text = "Password*";
            // 
            // tbPw1
            // 
            this.tbPw1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPw1.Location = new System.Drawing.Point(274, 118);
            this.tbPw1.Margin = new System.Windows.Forms.Padding(2);
            this.tbPw1.Name = "tbPw1";
            this.tbPw1.PasswordChar = '*';
            this.tbPw1.Size = new System.Drawing.Size(163, 26);
            this.tbPw1.TabIndex = 5;
            // 
            // lblPw2
            // 
            this.lblPw2.AutoSize = true;
            this.lblPw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPw2.Location = new System.Drawing.Point(71, 172);
            this.lblPw2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPw2.Name = "lblPw2";
            this.lblPw2.Size = new System.Drawing.Size(178, 20);
            this.lblPw2.TabIndex = 6;
            this.lblPw2.Text = "Password Confirmation*";
            // 
            // tbPw2
            // 
            this.tbPw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPw2.Location = new System.Drawing.Point(274, 166);
            this.tbPw2.Margin = new System.Windows.Forms.Padding(2);
            this.tbPw2.Name = "tbPw2";
            this.tbPw2.PasswordChar = '*';
            this.tbPw2.Size = new System.Drawing.Size(163, 26);
            this.tbPw2.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmail.Location = new System.Drawing.Point(71, 65);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 20);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-mail*";
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbEmail.Location = new System.Drawing.Point(196, 65);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(241, 26);
            this.tbEmail.TabIndex = 9;
            // 
            // btSubmit
            // 
            this.btSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btSubmit.Location = new System.Drawing.Point(195, 278);
            this.btSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(91, 41);
            this.btSubmit.TabIndex = 10;
            this.btSubmit.Text = "Sign up";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblChoose.Location = new System.Drawing.Point(71, 222);
            this.lblChoose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(109, 20);
            this.lblChoose.TabIndex = 11;
            this.lblChoose.Text = "I want to be a:";
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbStudent.Location = new System.Drawing.Point(218, 222);
            this.rbStudent.Margin = new System.Windows.Forms.Padding(2);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(81, 24);
            this.rbStudent.TabIndex = 12;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "student";
            this.rbStudent.UseVisualStyleBackColor = true;
            // 
            // rbTeacher
            // 
            this.rbTeacher.AutoSize = true;
            this.rbTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbTeacher.Location = new System.Drawing.Point(355, 222);
            this.rbTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.rbTeacher.Name = "rbTeacher";
            this.rbTeacher.Size = new System.Drawing.Size(81, 24);
            this.rbTeacher.TabIndex = 13;
            this.rbTeacher.TabStop = true;
            this.rbTeacher.Text = "teacher";
            this.rbTeacher.UseVisualStyleBackColor = true;
            // 
            // regTab
            // 
            this.regTab.Controls.Add(this.tabPage1);
            this.regTab.Controls.Add(this.tabPage2);
            this.regTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.regTab.Location = new System.Drawing.Point(0, 0);
            this.regTab.Name = "regTab";
            this.regTab.SelectedIndex = 0;
            this.regTab.Size = new System.Drawing.Size(516, 383);
            this.regTab.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblReg);
            this.tabPage1.Controls.Add(this.btSubmit);
            this.tabPage1.Controls.Add(this.rbTeacher);
            this.tabPage1.Controls.Add(this.tbEmail);
            this.tabPage1.Controls.Add(this.rbStudent);
            this.tabPage1.Controls.Add(this.lblPw1);
            this.tabPage1.Controls.Add(this.lblChoose);
            this.tabPage1.Controls.Add(this.tbPw1);
            this.tabPage1.Controls.Add(this.lblEmail);
            this.tabPage1.Controls.Add(this.tbPw2);
            this.tabPage1.Controls.Add(this.lblPw2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(508, 357);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Register";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.loginBtn);
            this.tabPage2.Controls.Add(this.loginEmailBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.loginPasswordBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(508, 357);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(191, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Loging in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginBtn.Location = new System.Drawing.Point(195, 276);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(91, 41);
            this.loginBtn.TabIndex = 16;
            this.loginBtn.Text = "Log In";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // loginEmailBox
            // 
            this.loginEmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginEmailBox.Location = new System.Drawing.Point(195, 108);
            this.loginEmailBox.Margin = new System.Windows.Forms.Padding(2);
            this.loginEmailBox.Name = "loginEmailBox";
            this.loginEmailBox.Size = new System.Drawing.Size(241, 26);
            this.loginEmailBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(95, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password*";
            // 
            // loginPasswordBox
            // 
            this.loginPasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginPasswordBox.Location = new System.Drawing.Point(273, 161);
            this.loginPasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.loginPasswordBox.Name = "loginPasswordBox";
            this.loginPasswordBox.PasswordChar = '*';
            this.loginPasswordBox.Size = new System.Drawing.Size(163, 26);
            this.loginPasswordBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(95, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "E-mail*";
            // 
            // RegistrationUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 385);
            this.Controls.Add(this.regTab);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistrationUI";
            this.Text = "Tutor World";
            this.regTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.Label lblPw1;
        private System.Windows.Forms.TextBox tbPw1;
        private System.Windows.Forms.Label lblPw2;
        private System.Windows.Forms.TextBox tbPw2;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.RadioButton rbTeacher;
        private System.Windows.Forms.TabControl regTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox loginEmailBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginPasswordBox;
        private System.Windows.Forms.Label label3;
    }
}

