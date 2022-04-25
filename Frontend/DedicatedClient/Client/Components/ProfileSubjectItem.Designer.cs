namespace Client.Components
{
    partial class ProfileSubjectItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SubjectLbl = new System.Windows.Forms.Label();
            this.RatingLbl = new System.Windows.Forms.Label();
            this.SkillsLbl = new System.Windows.Forms.Label();
            this.SkillsToTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // SubjectLbl
            // 
            this.SubjectLbl.AutoEllipsis = true;
            this.SubjectLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectLbl.Location = new System.Drawing.Point(-3, 0);
            this.SubjectLbl.Name = "SubjectLbl";
            this.SubjectLbl.Size = new System.Drawing.Size(185, 17);
            this.SubjectLbl.TabIndex = 0;
            this.SubjectLbl.Text = "Subject name";
            // 
            // RatingLbl
            // 
            this.RatingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RatingLbl.Location = new System.Drawing.Point(188, 0);
            this.RatingLbl.Name = "RatingLbl";
            this.RatingLbl.Size = new System.Drawing.Size(38, 17);
            this.RatingLbl.TabIndex = 1;
            this.RatingLbl.Text = "#.#";
            // 
            // SkillsLbl
            // 
            this.SkillsLbl.AutoEllipsis = true;
            this.SkillsLbl.AutoSize = true;
            this.SkillsLbl.Location = new System.Drawing.Point(0, 17);
            this.SkillsLbl.Name = "SkillsLbl";
            this.SkillsLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SkillsLbl.Size = new System.Drawing.Size(45, 13);
            this.SkillsLbl.TabIndex = 2;
            this.SkillsLbl.Text = "label1";
            // 
            // ProfileSubjectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SkillsLbl);
            this.Controls.Add(this.RatingLbl);
            this.Controls.Add(this.SubjectLbl);
            this.Name = "ProfileSubjectItem";
            this.Size = new System.Drawing.Size(229, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SubjectLbl;
        private System.Windows.Forms.Label RatingLbl;
        private System.Windows.Forms.Label SkillsLbl;
        private System.Windows.Forms.ToolTip SkillsToTip;
    }
}
