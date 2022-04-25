namespace Client
{
    partial class StudentProfileCreation
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.lblPic = new System.Windows.Forms.Label();
            this.bChoose = new System.Windows.Forms.Button();
            this.bUpload = new System.Windows.Forms.Button();
            this.lblPicAddress = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.tbBio = new System.Windows.Forms.TextBox();
            this.lblEducation = new System.Windows.Forms.Label();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lblHeadline = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.bSubmit = new System.Windows.Forms.Button();
            this.SkipBtn = new System.Windows.Forms.Button();
            this.LabelSkip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblFirstName.Location = new System.Drawing.Point(80, 91);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(103, 24);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First name:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbFirstName.Location = new System.Drawing.Point(317, 91);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(400, 26);
            this.tbFirstName.TabIndex = 1;
            // 
            // lblPic
            // 
            this.lblPic.AutoSize = true;
            this.lblPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPic.Location = new System.Drawing.Point(80, 397);
            this.lblPic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPic.Name = "lblPic";
            this.lblPic.Size = new System.Drawing.Size(208, 24);
            this.lblPic.TabIndex = 2;
            this.lblPic.Text = "Upload a picture of you:";
            // 
            // bChoose
            // 
            this.bChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bChoose.Location = new System.Drawing.Point(317, 395);
            this.bChoose.Margin = new System.Windows.Forms.Padding(2);
            this.bChoose.Name = "bChoose";
            this.bChoose.Size = new System.Drawing.Size(113, 29);
            this.bChoose.TabIndex = 3;
            this.bChoose.Text = "Choose a file";
            this.bChoose.UseVisualStyleBackColor = true;
            // 
            // bUpload
            // 
            this.bUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bUpload.Location = new System.Drawing.Point(446, 395);
            this.bUpload.Margin = new System.Windows.Forms.Padding(2);
            this.bUpload.Name = "bUpload";
            this.bUpload.Size = new System.Drawing.Size(113, 29);
            this.bUpload.TabIndex = 4;
            this.bUpload.Text = "Upload";
            this.bUpload.UseVisualStyleBackColor = true;
            // 
            // lblPicAddress
            // 
            this.lblPicAddress.AutoSize = true;
            this.lblPicAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPicAddress.Location = new System.Drawing.Point(573, 397);
            this.lblPicAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPicAddress.Name = "lblPicAddress";
            this.lblPicAddress.Size = new System.Drawing.Size(142, 24);
            this.lblPicAddress.TabIndex = 5;
            this.lblPicAddress.Text = "(photo address)";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblBio.Location = new System.Drawing.Point(80, 245);
            this.lblBio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(105, 24);
            this.lblBio.TabIndex = 9;
            this.lblBio.Text = "Write a Bio:";
            // 
            // tbBio
            // 
            this.tbBio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbBio.Location = new System.Drawing.Point(317, 245);
            this.tbBio.Margin = new System.Windows.Forms.Padding(2);
            this.tbBio.Multiline = true;
            this.tbBio.Name = "tbBio";
            this.tbBio.Size = new System.Drawing.Size(400, 109);
            this.tbBio.TabIndex = 10;
            // 
            // lblEducation
            // 
            this.lblEducation.AutoSize = true;
            this.lblEducation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblEducation.Location = new System.Drawing.Point(80, 426);
            this.lblEducation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(0, 24);
            this.lblEducation.TabIndex = 11;
            // 
            // lblNetwork
            // 
            this.lblNetwork.AutoSize = true;
            this.lblNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblNetwork.Location = new System.Drawing.Point(82, 528);
            this.lblNetwork.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(0, 24);
            this.lblNetwork.TabIndex = 13;
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbLastName.Location = new System.Drawing.Point(317, 134);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(400, 26);
            this.tbLastName.TabIndex = 15;
            // 
            // lblHeadline
            // 
            this.lblHeadline.AutoSize = true;
            this.lblHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblHeadline.Location = new System.Drawing.Point(381, 28);
            this.lblHeadline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeadline.Name = "lblHeadline";
            this.lblHeadline.Size = new System.Drawing.Size(190, 26);
            this.lblHeadline.TabIndex = 16;
            this.lblHeadline.Text = "Create your profile";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblLastName.Location = new System.Drawing.Point(80, 134);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(101, 24);
            this.lblLastName.TabIndex = 17;
            this.lblLastName.Text = "Last name:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPhone.Location = new System.Drawing.Point(80, 180);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(142, 24);
            this.lblPhone.TabIndex = 19;
            this.lblPhone.Text = "Phone number:";
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPhone.Location = new System.Drawing.Point(317, 180);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(2);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(400, 26);
            this.tbPhone.TabIndex = 20;
            // 
            // bSubmit
            // 
            this.bSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bSubmit.Location = new System.Drawing.Point(376, 543);
            this.bSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(191, 59);
            this.bSubmit.TabIndex = 23;
            this.bSubmit.Text = "Submit your profile";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // SkipBtn
            // 
            this.SkipBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SkipBtn.Location = new System.Drawing.Point(798, 619);
            this.SkipBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SkipBtn.Name = "SkipBtn";
            this.SkipBtn.Size = new System.Drawing.Size(99, 59);
            this.SkipBtn.TabIndex = 24;
            this.SkipBtn.Text = "Skip this step";
            this.SkipBtn.UseVisualStyleBackColor = true;
            this.SkipBtn.Click += new System.EventHandler(this.SkipBtn_Click);
            // 
            // LabelSkip
            // 
            this.LabelSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LabelSkip.Location = new System.Drawing.Point(754, 560);
            this.LabelSkip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelSkip.Name = "LabelSkip";
            this.LabelSkip.Size = new System.Drawing.Size(191, 57);
            this.LabelSkip.TabIndex = 25;
            this.LabelSkip.Text = "You can always edit your profile later";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(260, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "(+45)";
            // 
            // StudentProfileCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 708);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelSkip);
            this.Controls.Add(this.SkipBtn);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblHeadline);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.lblEducation);
            this.Controls.Add(this.tbBio);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.lblPicAddress);
            this.Controls.Add(this.bUpload);
            this.Controls.Add(this.bChoose);
            this.Controls.Add(this.lblPic);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentProfileCreation";
            this.Text = "Create your student profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label lblPic;
        private System.Windows.Forms.Button bChoose;
        private System.Windows.Forms.Button bUpload;
        private System.Windows.Forms.Label lblPicAddress;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.TextBox tbBio;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.Label lblNetwork;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lblHeadline;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.Button SkipBtn;
        private System.Windows.Forms.Label LabelSkip;
        private System.Windows.Forms.Label label1;
    }
}