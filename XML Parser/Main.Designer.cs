namespace CSV_Parser
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctlChbDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ctlArn = new System.Windows.Forms.TextBox();
            this.ctlCheck = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlErrorCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlErrorReason = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data chargebacku";
            // 
            // ctlChbDate
            // 
            this.ctlChbDate.Location = new System.Drawing.Point(108, 16);
            this.ctlChbDate.Name = "ctlChbDate";
            this.ctlChbDate.Size = new System.Drawing.Size(200, 20);
            this.ctlChbDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ARN";
            // 
            // ctlArn
            // 
            this.ctlArn.Location = new System.Drawing.Point(108, 44);
            this.ctlArn.Name = "ctlArn";
            this.ctlArn.Size = new System.Drawing.Size(200, 20);
            this.ctlArn.TabIndex = 8;
            // 
            // ctlCheck
            // 
            this.ctlCheck.Location = new System.Drawing.Point(13, 91);
            this.ctlCheck.Name = "ctlCheck";
            this.ctlCheck.Size = new System.Drawing.Size(75, 23);
            this.ctlCheck.TabIndex = 9;
            this.ctlCheck.Text = "Sprawdź";
            this.ctlCheck.UseVisualStyleBackColor = true;
            this.ctlCheck.Click += new System.EventHandler(this.ctlCheck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctlChbDate);
            this.groupBox1.Controls.Add(this.ctlArn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametry";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ctlErrorCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ctlErrorReason);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 73);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wynik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kod błędu";
            // 
            // ctlErrorCode
            // 
            this.ctlErrorCode.Location = new System.Drawing.Point(109, 45);
            this.ctlErrorCode.Name = "ctlErrorCode";
            this.ctlErrorCode.ReadOnly = true;
            this.ctlErrorCode.Size = new System.Drawing.Size(100, 20);
            this.ctlErrorCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Przyczyna błędu";
            // 
            // ctlErrorReason
            // 
            this.ctlErrorReason.Location = new System.Drawing.Point(109, 19);
            this.ctlErrorReason.Name = "ctlErrorReason";
            this.ctlErrorReason.ReadOnly = true;
            this.ctlErrorReason.Size = new System.Drawing.Size(100, 20);
            this.ctlErrorReason.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 215);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctlCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "MC Error Check";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ctlChbDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ctlArn;
        private System.Windows.Forms.Button ctlCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ctlErrorReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ctlErrorCode;
    }
}

