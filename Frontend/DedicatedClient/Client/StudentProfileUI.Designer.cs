namespace Client
{
    partial class StudentProfileUI
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
            this.lblFNameDB = new System.Windows.Forms.Label();
            this.lblLNameDB = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.lblBioText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bFacebook = new System.Windows.Forms.Button();
            this.bEmail = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPhoneDB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFNameDB
            // 
            this.lblFNameDB.AutoSize = true;
            this.lblFNameDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblFNameDB.Location = new System.Drawing.Point(610, 71);
            this.lblFNameDB.Name = "lblFNameDB";
            this.lblFNameDB.Size = new System.Drawing.Size(148, 32);
            this.lblFNameDB.TabIndex = 0;
            this.lblFNameDB.Text = "First name";
            // 
            // lblLNameDB
            // 
            this.lblLNameDB.AutoSize = true;
            this.lblLNameDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblLNameDB.Location = new System.Drawing.Point(798, 71);
            this.lblLNameDB.Name = "lblLNameDB";
            this.lblLNameDB.Size = new System.Drawing.Size(147, 32);
            this.lblLNameDB.TabIndex = 1;
            this.lblLNameDB.Text = "Last name";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblBio.Location = new System.Drawing.Point(811, 241);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(57, 32);
            this.lblBio.TabIndex = 2;
            this.lblBio.Text = "Bio";
            // 
            // lblBioText
            // 
            this.lblBioText.AutoSize = true;
            this.lblBioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBioText.Location = new System.Drawing.Point(812, 304);
            this.lblBioText.Name = "lblBioText";
            this.lblBioText.Size = new System.Drawing.Size(299, 29);
            this.lblBioText.TabIndex = 3;
            this.lblBioText.Text = "Student\'s bio text blablabla";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(209, 241);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 280);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // bFacebook
            // 
            this.bFacebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bFacebook.Location = new System.Drawing.Point(209, 550);
            this.bFacebook.Name = "bFacebook";
            this.bFacebook.Size = new System.Drawing.Size(68, 61);
            this.bFacebook.TabIndex = 8;
            this.bFacebook.Text = "FB";
            this.bFacebook.UseVisualStyleBackColor = true;
            // 
            // bEmail
            // 
            this.bEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bEmail.Location = new System.Drawing.Point(309, 550);
            this.bEmail.Name = "bEmail";
            this.bEmail.Size = new System.Drawing.Size(68, 61);
            this.bEmail.TabIndex = 9;
            this.bEmail.Text = "Email";
            this.bEmail.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(403, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "LinkedIn";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPhone.Location = new System.Drawing.Point(817, 469);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(201, 32);
            this.lblPhone.TabIndex = 17;
            this.lblPhone.Text = "Phone number";
            // 
            // lblPhoneDB
            // 
            this.lblPhoneDB.AutoSize = true;
            this.lblPhoneDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPhoneDB.Location = new System.Drawing.Point(818, 516);
            this.lblPhoneDB.Name = "lblPhoneDB";
            this.lblPhoneDB.Size = new System.Drawing.Size(264, 29);
            this.lblPhoneDB.TabIndex = 18;
            this.lblPhoneDB.Text = "Phone number from DB";
            // 
            // StudentProfileUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 1185);
            this.Controls.Add(this.lblPhoneDB);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bEmail);
            this.Controls.Add(this.bFacebook);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBioText);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.lblLNameDB);
            this.Controls.Add(this.lblFNameDB);
            this.Name = "StudentProfileUI";
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFNameDB;
        private System.Windows.Forms.Label lblLNameDB;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.Label lblBioText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bFacebook;
        private System.Windows.Forms.Button bEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPhoneDB;
    }
}