namespace FormsApp
{
    partial class Form1
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
            this.DownloadSync_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Url_txt = new System.Windows.Forms.TextBox();
            this.DownloadAsync_Btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblDuration = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DownloadSync_Btn
            // 
            this.DownloadSync_Btn.Location = new System.Drawing.Point(135, 78);
            this.DownloadSync_Btn.Name = "DownloadSync_Btn";
            this.DownloadSync_Btn.Size = new System.Drawing.Size(300, 34);
            this.DownloadSync_Btn.TabIndex = 0;
            this.DownloadSync_Btn.Text = "Download Sync";
            this.DownloadSync_Btn.UseVisualStyleBackColor = true;
            this.DownloadSync_Btn.Click += new System.EventHandler(this.DownloadSync_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // Url_txt
            // 
            this.Url_txt.Location = new System.Drawing.Point(171, 35);
            this.Url_txt.Name = "Url_txt";
            this.Url_txt.Size = new System.Drawing.Size(264, 22);
            this.Url_txt.TabIndex = 3;
            // 
            // DownloadAsync_Btn
            // 
            this.DownloadAsync_Btn.Location = new System.Drawing.Point(135, 118);
            this.DownloadAsync_Btn.Name = "DownloadAsync_Btn";
            this.DownloadAsync_Btn.Size = new System.Drawing.Size(300, 34);
            this.DownloadAsync_Btn.TabIndex = 4;
            this.DownloadAsync_Btn.Text = "Download Async";
            this.DownloadAsync_Btn.UseVisualStyleBackColor = true;
            this.DownloadAsync_Btn.Click += new System.EventHandler(this.DownloadAsync_Btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Duration:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(199, 154);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(0, 16);
            this.lblDuration.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 585);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DownloadAsync_Btn);
            this.Controls.Add(this.Url_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownloadSync_Btn);
            this.Name = "Form1";
            this.Text = "Forms Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DownloadSync_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Url_txt;
        private System.Windows.Forms.Button DownloadAsync_Btn;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblDuration;
    }
}

