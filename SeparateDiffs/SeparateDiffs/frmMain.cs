using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SeparateDiffs
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Est� seguro que desea continuar?", "Confirmaci�n", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                FolderProcess process = new FolderProcess(txtFolderA.Text, txtFolderB.Text, chkRenameFilesA.Checked);

                frmProgress dlg = new frmProgress(process);
                try
                {
                    this.Enabled = false;
                    dlg.ShowDialog();
                    while (!process.Finished)
                    {
                        System.Threading.Thread.Sleep(200);
                    }
                }
                finally
                {
                    this.Enabled = true;
                    dlg.Close();
                }
                
                MessageBox.Show("Proceso terminado con �xito");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}