namespace CSV_Parser
{
    partial class StatusWindow
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
            this.ctlLogBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerErrorSearching = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ctlLogBox
            // 
            this.ctlLogBox.Location = new System.Drawing.Point(13, 59);
            this.ctlLogBox.Multiline = true;
            this.ctlLogBox.Name = "ctlLogBox";
            this.ctlLogBox.ReadOnly = true;
            this.ctlLogBox.Size = new System.Drawing.Size(356, 269);
            this.ctlLogBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Postęp:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(355, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // backgroundWorkerErrorSearching
            // 
            this.backgroundWorkerErrorSearching.WorkerReportsProgress = true;
            this.backgroundWorkerErrorSearching.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerErrorSearching_DoWork);
            this.backgroundWorkerErrorSearching.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerErrorSearching_ProgressChanged);
            this.backgroundWorkerErrorSearching.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerErrorSearching_RunWorkerCompleted);
            // 
            // StatusWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 340);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlLogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Trwa szukanie...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ctlLogBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerErrorSearching;
    }
}