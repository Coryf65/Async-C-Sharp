using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Url_txt.Text = "https://twitch.tv";
        }

        private DateTime _startTime = DateTime.MaxValue;

        private void DownloadSync_Btn_Click(object sender, EventArgs e)
        {
            DisableDownloadButtons();
            StartTimer();

            using (var downloader = new System.Net.WebClient())
            {
                var page = downloader.DownloadString(Url_txt.Text);
            }

            StopTimer();
            EnableDownloadButtons();
        }

        private void DownloadAsync_Btn_Click(object sender, EventArgs e)
        {
            DisableDownloadButtons();
            StartTimer();
            backgroundWorker1.RunWorkerAsync();
        }

        private void StartTimer()
        {
            _startTime = DateTime.UtcNow;
            ShowDuration();
            timer.Enabled = true;
        }        

        private void StopTimer()
        {
            timer.Enabled = false;
            ShowDuration();
        }

        private void EnableDownloadButtons()
        {
            DownloadAsync_Btn.Enabled = true;
            DownloadAsync_Btn.Enabled = true;
        }

        private void DisableDownloadButtons()
        {
            DownloadAsync_Btn.Enabled = false;
            DownloadAsync_Btn.Enabled = false;
        }

        private void ShowDuration()
        {
            lblDuration.Text = "Duration: " + (DateTime.UtcNow - _startTime).TotalMilliseconds.ToString() + "ms";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Never modify the UI from this method

            using (var downloader = new WebClient())
            {
                var page = downloader.DownloadString(Url_txt.Text);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StopTimer();
            EnableDownloadButtons();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowDuration();
        }
    }
}
