using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SeparateDiffs
{
    public partial class frmProgress : Form
    {
        private FolderProcess _process;
        private Thread _thread = null;
        
        public frmProgress(FolderProcess process)
        {
            _process = process;
            InitializeComponent();
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer1.Start();

            progressBar1.Style = ProgressBarStyle.Marquee;

            _thread = new Thread(new ThreadStart(_process.Run));
            _thread.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_process.Started && !_process.Finished)
            {
                lblFolder.Text = _process.CurrentFolder;
                // progressBar1.Value++;
            }
            else
                lblFolder.Text = "";

            if (_process.Finished)
            {
                if (_thread.IsAlive)
                {
                    _thread.Join(1000);
                    _thread.Abort();
                }
                _thread = null;
                this.Close();
            }
        }
    }
}