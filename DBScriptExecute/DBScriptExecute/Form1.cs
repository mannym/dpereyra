using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace DBScriptExecute
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Panel pnlMain;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.TextBox txtCnn;
		private System.Windows.Forms.Label lblCnn;
		private System.Windows.Forms.GroupBox grpTx;
		private System.Windows.Forms.Button btnAbortTx;
		private System.Windows.Forms.Button btnCommitTx;
		private System.Windows.Forms.Button btnBeginTx;

		private ScriptExecute scriptExec = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckedListBox lstFiles;
		private System.Windows.Forms.Button btnAddFolder;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnSelectAll;
		private System.Windows.Forms.Button btnAddFiles;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.TextBox txtStatus;
		private ImageList imgList = new ImageList();

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.pnlTop = new System.Windows.Forms.Panel();
			this.btnAddFolder = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.btnAddFiles = new System.Windows.Forms.Button();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.btnExecute = new System.Windows.Forms.Button();
			this.txtCnn = new System.Windows.Forms.TextBox();
			this.lblCnn = new System.Windows.Forms.Label();
			this.grpTx = new System.Windows.Forms.GroupBox();
			this.btnAbortTx = new System.Windows.Forms.Button();
			this.btnCommitTx = new System.Windows.Forms.Button();
			this.btnBeginTx = new System.Windows.Forms.Button();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lstFiles = new System.Windows.Forms.CheckedListBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblStatus = new System.Windows.Forms.Label();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.pnlTop.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.grpTx.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.btnAddFolder);
			this.pnlTop.Controls.Add(this.btnRemove);
			this.pnlTop.Controls.Add(this.btnSelectAll);
			this.pnlTop.Controls.Add(this.btnAddFiles);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(488, 40);
			this.pnlTop.TabIndex = 0;
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFolder.Image")));
			this.btnAddFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddFolder.Location = new System.Drawing.Point(112, 8);
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Size = new System.Drawing.Size(96, 24);
			this.btnAddFolder.TabIndex = 2;
			this.btnAddFolder.Text = "Carpeta...";
			this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
			this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRemove.Location = new System.Drawing.Point(216, 8);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(120, 24);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.Text = "Quitar acrhivos";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
			this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSelectAll.Location = new System.Drawing.Point(352, 8);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(128, 24);
			this.btnSelectAll.TabIndex = 4;
			this.btnSelectAll.Text = "Seleccionar Todos";
			this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// btnAddFiles
			// 
			this.btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFiles.Image")));
			this.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddFiles.Location = new System.Drawing.Point(8, 8);
			this.btnAddFiles.Name = "btnAddFiles";
			this.btnAddFiles.Size = new System.Drawing.Size(96, 24);
			this.btnAddFiles.TabIndex = 1;
			this.btnAddFiles.Text = "Archivo...";
			this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.txtStatus);
			this.pnlBottom.Controls.Add(this.lblStatus);
			this.pnlBottom.Controls.Add(this.btnExecute);
			this.pnlBottom.Controls.Add(this.txtCnn);
			this.pnlBottom.Controls.Add(this.lblCnn);
			this.pnlBottom.Controls.Add(this.grpTx);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 413);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(488, 168);
			this.pnlBottom.TabIndex = 1;
			// 
			// btnExecute
			// 
			this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
			this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnExecute.Location = new System.Drawing.Point(312, 128);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(168, 32);
			this.btnExecute.TabIndex = 8;
			this.btnExecute.Text = "Ejecutar Scripts";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// txtCnn
			// 
			this.txtCnn.Location = new System.Drawing.Point(104, 48);
			this.txtCnn.Multiline = true;
			this.txtCnn.Name = "txtCnn";
			this.txtCnn.Size = new System.Drawing.Size(376, 48);
			this.txtCnn.TabIndex = 9;
			this.txtCnn.Text = "";
			// 
			// lblCnn
			// 
			this.lblCnn.AutoSize = true;
			this.lblCnn.Location = new System.Drawing.Point(8, 48);
			this.lblCnn.Name = "lblCnn";
			this.lblCnn.TabIndex = 6;
			this.lblCnn.Text = "Connection String: ";
			// 
			// grpTx
			// 
			this.grpTx.Controls.Add(this.btnAbortTx);
			this.grpTx.Controls.Add(this.btnCommitTx);
			this.grpTx.Controls.Add(this.btnBeginTx);
			this.grpTx.Location = new System.Drawing.Point(8, 104);
			this.grpTx.Name = "grpTx";
			this.grpTx.Size = new System.Drawing.Size(296, 56);
			this.grpTx.TabIndex = 5;
			this.grpTx.TabStop = false;
			this.grpTx.Text = "Transacción";
			// 
			// btnAbortTx
			// 
			this.btnAbortTx.Enabled = false;
			this.btnAbortTx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAbortTx.Image = ((System.Drawing.Image)(resources.GetObject("btnAbortTx.Image")));
			this.btnAbortTx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAbortTx.Location = new System.Drawing.Point(200, 24);
			this.btnAbortTx.Name = "btnAbortTx";
			this.btnAbortTx.Size = new System.Drawing.Size(88, 24);
			this.btnAbortTx.TabIndex = 7;
			this.btnAbortTx.Text = "Abort";
			this.btnAbortTx.Click += new System.EventHandler(this.btnAbortTx_Click);
			// 
			// btnCommitTx
			// 
			this.btnCommitTx.Enabled = false;
			this.btnCommitTx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCommitTx.Image = ((System.Drawing.Image)(resources.GetObject("btnCommitTx.Image")));
			this.btnCommitTx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCommitTx.Location = new System.Drawing.Point(104, 24);
			this.btnCommitTx.Name = "btnCommitTx";
			this.btnCommitTx.Size = new System.Drawing.Size(88, 24);
			this.btnCommitTx.TabIndex = 6;
			this.btnCommitTx.Text = "Commit";
			this.btnCommitTx.Click += new System.EventHandler(this.btnCommitTx_Click);
			// 
			// btnBeginTx
			// 
			this.btnBeginTx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBeginTx.Image = ((System.Drawing.Image)(resources.GetObject("btnBeginTx.Image")));
			this.btnBeginTx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBeginTx.Location = new System.Drawing.Point(8, 24);
			this.btnBeginTx.Name = "btnBeginTx";
			this.btnBeginTx.Size = new System.Drawing.Size(88, 24);
			this.btnBeginTx.TabIndex = 5;
			this.btnBeginTx.Text = "Begin";
			this.btnBeginTx.Click += new System.EventHandler(this.btnBeginTx_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.panel2);
			this.pnlMain.Controls.Add(this.splitter1);
			this.pnlMain.Controls.Add(this.panel1);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 40);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(488, 373);
			this.pnlMain.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lstFiles);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(488, 282);
			this.panel2.TabIndex = 2;
			// 
			// lstFiles
			// 
			this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstFiles.IntegralHeight = false;
			this.lstFiles.Location = new System.Drawing.Point(0, 0);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(488, 282);
			this.lstFiles.Sorted = true;
			this.lstFiles.TabIndex = 10;
			this.lstFiles.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 282);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(488, 3);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtLog);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 285);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(488, 88);
			this.panel1.TabIndex = 0;
			// 
			// txtLog
			// 
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(0, 0);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(488, 88);
			this.txtLog.TabIndex = 10;
			this.txtLog.TabStop = false;
			this.txtLog.Text = "";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(8, 16);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(39, 16);
			this.lblStatus.TabIndex = 10;
			this.lblStatus.Text = "Status:";
			// 
			// txtStatus
			// 
			this.txtStatus.Location = new System.Drawing.Point(56, 16);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ReadOnly = true;
			this.txtStatus.Size = new System.Drawing.Size(424, 20);
			this.txtStatus.TabIndex = 11;
			this.txtStatus.TabStop = false;
			this.txtStatus.Text = "";
			// 
			// frmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 581);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlBottom);
			this.Controls.Add(this.pnlTop);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DB Script Execute";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
			this.pnlTop.ResumeLayout(false);
			this.pnlBottom.ResumeLayout(false);
			this.grpTx.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnAddFiles_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			
			dlg.CheckFileExists = true;
			dlg.CheckPathExists = true;
			dlg.Multiselect		= true;
			dlg.ShowReadOnly	= false;
			dlg.Title			= "Agregar archivos";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ScriptFile tmpFile = null;
				for (int i = 0; i <= dlg.FileNames.GetUpperBound(0); i++)
				{
					if (File.Exists(dlg.FileNames.GetValue(i).ToString()))
					{
						tmpFile = new ScriptFile();
						tmpFile.fileInfo = new FileInfo(dlg.FileNames.GetValue(i).ToString());
						tmpFile.Status = ScriptFileStatus.New;
						tmpFile.ChangeStatus += new _changeStatus(statusChanged);

						lstFiles.Items.Add(tmpFile, false);
					}
				}
			}

			dlg.Dispose();
		}

		private void btnExecute_Click(object sender, System.EventArgs e)
		{
			if (scriptExec == null)
				if (MessageBox.Show("No se ha iniciado una transacción, desea continuar?", "No se inició transacción",MessageBoxButtons.YesNo) == DialogResult.No)
					return;

			txtStatus.Text = string.Empty;

			btnExecute.Enabled = false;
			btnBeginTx.Enabled = false;

			if (scriptExec == null)
			{
				scriptExec = new ScriptExecute(txtCnn.Text.Trim());
				scriptExec.ChangeStatus += new _changeStatus(statusChanged);
			}

			ScriptFile[] files = new ScriptFile[lstFiles.CheckedItems.Count];
			
			IEnumerator selItems = lstFiles.CheckedItems.GetEnumerator();
			selItems.Reset();

			int i = 0;
			while (selItems.MoveNext())
			{
				files[i] = (ScriptFile)selItems.Current;
				i++;
			}

			string errLog = "";	
			if (scriptExec.ExecuteFiles(files, ref errLog) == files.Length)
				MessageBox.Show("Los scripts fueron ejecutados correctamente", "Fin de ejecución");
			else
				txtLog.Text = "[" + DateTime.Now.ToString() + "] " +errLog + Environment.NewLine + Environment.NewLine + txtLog.Text;
			
			if (!scriptExec.IsTxOpen())
			{
				scriptExec.Dispose();
				scriptExec = null;
				btnBeginTx.Enabled = true;
			}
			btnExecute.Enabled = true;

			RefreshItems();

			txtStatus.Text = string.Empty;
		}

		private void RefreshItems()
		{
			for (int i = 0; i < lstFiles.Items.Count; i++)
			{
				if (((ScriptFile)lstFiles.Items[i]).Status == ScriptFileStatus.ExecOK)
					lstFiles.SetItemChecked(i, false);
			}

			lstFiles.Refresh();
		}

		private void btnBeginTx_Click(object sender, System.EventArgs e)
		{
			if (scriptExec == null)
			{
				scriptExec = new ScriptExecute(txtCnn.Text.Trim());
				scriptExec.ChangeStatus += new _changeStatus(statusChanged);
			}
			
			string errLog = "";
			if (scriptExec.BeginTx(ref errLog))
			{
				txtCnn.Enabled = false;
				btnBeginTx.Enabled = false;
				btnCommitTx.Enabled = true;
				btnAbortTx.Enabled = true;
			}
			else
			{
				txtLog.Text = "[" + DateTime.Now.ToString() + "] " +errLog + Environment.NewLine + Environment.NewLine + txtLog.Text;
				scriptExec = null;
			}
		}

		private void btnCommitTx_Click(object sender, System.EventArgs e)
		{
			if (scriptExec != null)
			{
				string errLog = "";
				if (scriptExec.CommitTx(ref errLog))
				{
					txtCnn.Enabled = true;
					btnBeginTx.Enabled = true;
					btnCommitTx.Enabled = false;
					btnAbortTx.Enabled = false;

					scriptExec = null;
				}
				else
					txtLog.Text = "[" + DateTime.Now.ToString() + "] " +errLog + Environment.NewLine + Environment.NewLine + txtLog.Text;
			}
		}

		private void btnAbortTx_Click(object sender, System.EventArgs e)
		{
			if (scriptExec != null)
			{
				string errLog = "";
				if (scriptExec.RollbackTx(ref errLog))
				{		
					txtCnn.Enabled = true;
					btnBeginTx.Enabled = true;
					btnCommitTx.Enabled = false;
					btnAbortTx.Enabled = false;

					scriptExec = null;
				}
				else
					txtLog.Text = "[" + DateTime.Now.ToString() + "] " +errLog + Environment.NewLine + Environment.NewLine + txtLog.Text;
			}
		}

		private void btnSelectAll_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < lstFiles.Items.Count; i++)
				lstFiles.SetItemChecked(i, true);
			lstFiles.Refresh();
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			object[] checkedItems = new object[lstFiles.CheckedItems.Count];
			for (int i = 0; i < lstFiles.CheckedItems.Count; i++)
                checkedItems[i] = lstFiles.CheckedItems[i];

			for (int i = 0; i < checkedItems.Length; i++)
				lstFiles.Items.Remove(checkedItems[i]);

			lstFiles.Refresh();
		}

		private void btnAddFolder_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.ShowNewFolderButton = false;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ScriptFile tmpFile = null;
				DirectoryInfo dir = new DirectoryInfo(dlg.SelectedPath);

				FileInfo[] files = dir.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					tmpFile = new ScriptFile();
					tmpFile.fileInfo = files[i];
					tmpFile.Status = ScriptFileStatus.New;

					lstFiles.Items.Add(tmpFile, false);
				}
			}
			dlg.Dispose();
		}

		private void frmMain_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				ScriptFile tmpFile = null;
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

				for (int i = 0; i < files.Length; i++)
				{
					tmpFile = new ScriptFile();
					tmpFile.fileInfo = new FileInfo(files[i]);
					tmpFile.Status = ScriptFileStatus.New;

					lstFiles.Items.Add(tmpFile, false);
				}
			}
		
		}

		private void frmMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop) ) 
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void statusChanged(string status)
		{
			this.txtStatus.Text = status;
		}
	}
}
