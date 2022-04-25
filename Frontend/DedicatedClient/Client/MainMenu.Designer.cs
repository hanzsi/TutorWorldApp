using System.Drawing;

namespace Client
{
    partial class MainMenu
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
            this.lbEmail = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnTeacherList = new System.Windows.Forms.Button();
            this.btnSkills = new System.Windows.Forms.Button();
            this.btMyProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbEmail
            // 
            this.lbEmail.Location = new System.Drawing.Point(197, 17);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbEmail.Size = new System.Drawing.Size(141, 18);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email";
            this.lbEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(344, 15);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 23);
            this.logoutBtn.TabIndex = 1;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(161, 137);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(127, 32);
            this.btnTimetable.TabIndex = 2;
            this.btnTimetable.Text = "Create Timetable";
            this.btnTimetable.UseVisualStyleBackColor = true;
            this.btnTimetable.Visible = false;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(161, 192);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(127, 32);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.Text = "Edit Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnTeacherList
            // 
            this.btnTeacherList.Location = new System.Drawing.Point(161, 137);
            this.btnTeacherList.Name = "btnTeacherList";
            this.btnTeacherList.Size = new System.Drawing.Size(127, 32);
            this.btnTeacherList.TabIndex = 4;
            this.btnTeacherList.Text = "Browse Tutors";
            this.btnTeacherList.UseVisualStyleBackColor = true;
            this.btnTeacherList.Visible = false;
            this.btnTeacherList.Click += new System.EventHandler(this.btnTeacherList_Click);
            // 
            // btnSkills
            // 
            this.btnSkills.Location = new System.Drawing.Point(161, 288);
            this.btnSkills.Name = "btnSkills";
            this.btnSkills.Size = new System.Drawing.Size(127, 32);
            this.btnSkills.TabIndex = 5;
            this.btnSkills.Text = "Edit Skills";
            this.btnSkills.UseVisualStyleBackColor = true;
            this.btnSkills.Visible = false;
            this.btnSkills.Click += new System.EventHandler(this.btnSkills_Click);
            // 
            // btMyProfile
            // 
            this.btMyProfile.Location = new System.Drawing.Point(161, 243);
            this.btMyProfile.Name = "btMyProfile";
            this.btMyProfile.Size = new System.Drawing.Size(127, 23);
            this.btMyProfile.TabIndex = 6;
            this.btMyProfile.Text = "My profile";
            this.btMyProfile.UseVisualStyleBackColor = true;
            this.btMyProfile.Click += new System.EventHandler(this.btMyProfile_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 416);
            this.Controls.Add(this.btMyProfile);
            this.Controls.Add(this.btnSkills);
            this.Controls.Add(this.btnTeacherList);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnTimetable);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.lbEmail);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnTeacherList;
        private System.Windows.Forms.Button btnSkills;
        private System.Windows.Forms.Button btMyProfile;
    }
}