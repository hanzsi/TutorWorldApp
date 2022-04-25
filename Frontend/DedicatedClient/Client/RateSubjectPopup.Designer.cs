namespace Client
{
    partial class RateSubjectPopup
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
            this.NameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubjectBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ScoreBox = new System.Windows.Forms.NumericUpDown();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ErrorLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.Location = new System.Drawing.Point(72, 19);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(143, 24);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Teachers name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select subject";
            // 
            // SubjectBox
            // 
            this.SubjectBox.DisplayMember = "SubjectNAme";
            this.SubjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectBox.FormattingEnabled = true;
            this.SubjectBox.Location = new System.Drawing.Point(28, 91);
            this.SubjectBox.Name = "SubjectBox";
            this.SubjectBox.Size = new System.Drawing.Size(199, 21);
            this.SubjectBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rating score(1-5)";
            // 
            // ScoreBox
            // 
            this.ScoreBox.DecimalPlaces = 1;
            this.ScoreBox.Location = new System.Drawing.Point(28, 168);
            this.ScoreBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ScoreBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Size = new System.Drawing.Size(199, 20);
            this.ScoreBox.TabIndex = 4;
            this.ScoreBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(76, 216);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(117, 33);
            this.SubmitBtn.TabIndex = 5;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLbl.Location = new System.Drawing.Point(28, 55);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(87, 13);
            this.ErrorLbl.TabIndex = 6;
            this.ErrorLbl.Text = "Error placeholder";
            this.ErrorLbl.Visible = false;
            // 
            // RateSubjectPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SubjectBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLbl);
            this.Name = "RateSubjectPopup";
            this.Text = "RateSubjectPopup";
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SubjectBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ScoreBox;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label ErrorLbl;
    }
}