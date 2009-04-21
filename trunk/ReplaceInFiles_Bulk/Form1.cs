using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ReplaceInFiles
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.TextBox txtReplaceDefsFile;
		private System.Windows.Forms.CheckBox chkRecursive;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int m_nFileCount = 0;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMask;
		private int m_nReplacedFilesCount = 0;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			chkRecursive.Checked = true;
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
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtReplaceDefsFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(15, 27);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(271, 20);
            this.txtFolder.TabIndex = 2;
            // 
            // txtReplaceDefsFile
            // 
            this.txtReplaceDefsFile.Location = new System.Drawing.Point(15, 121);
            this.txtReplaceDefsFile.Name = "txtReplaceDefsFile";
            this.txtReplaceDefsFile.Size = new System.Drawing.Size(271, 20);
            this.txtReplaceDefsFile.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Go";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Carpeta raíz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Definiciones de reemplazo:";
            // 
            // chkRecursive
            // 
            this.chkRecursive.Location = new System.Drawing.Point(206, 3);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(80, 16);
            this.chkRecursive.TabIndex = 1;
            this.chkRecursive.Text = "Recursivo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Máscara";
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(15, 73);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(271, 20);
            this.txtMask.TabIndex = 3;
            this.txtMask.Text = "*.*";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(298, 193);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtReplaceDefsFile);
            this.Controls.Add(this.txtFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace In Files";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (!System.IO.Directory.Exists(txtFolder.Text))
			{
				MessageBox.Show("El directorio especificado no existe");
				return;
			}
            if (!System.IO.File.Exists(txtReplaceDefsFile.Text))
			{
				MessageBox.Show("El archivo de definiciones de reemplazo no existe");
				return;
			}

			if (MessageBox.Show("Está seguro que quiere continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				m_nFileCount = 0;
				m_nReplacedFilesCount = 0;

                Dictionary<string, string> arrReplaceDefs = new Dictionary<string, string>();
                try
                {
                    System.IO.StreamReader defsFile = new System.IO.StreamReader(txtReplaceDefsFile.Text);

                    string[] arrSAux = new string[2];
                    int nIdx = 0;

                    while (defsFile.Peek() >= 0)
                    {
                        arrSAux[nIdx] = defsFile.ReadLine();

                        nIdx++;
                        if (nIdx > 1)
                        {
                            arrReplaceDefs.Add(arrSAux[1], arrSAux[0]);
                            nIdx = 0;
                        }
                    }

                    if (nIdx != 0)
                        throw new Exception();

                    defsFile.Close();
                }
                catch
                {
                    MessageBox.Show("Error leyendo el archivo de definiciones de reemplazo");
                    return;
                }

                ProcessFiles(txtFolder.Text, chkRecursive.Checked, txtMask.Text, arrReplaceDefs);
				
                MessageBox.Show("Se modificaron " + m_nReplacedFilesCount.ToString() + " de " + m_nFileCount.ToString());
			}
		}

		private void ProcessFiles(string sRoot, bool bRecursive, string sMask, Dictionary<string,string> arrReplaceDefs)
		{
			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(sRoot);
			if (bRecursive)
			{
				System.IO.DirectoryInfo[] dirs = dirInfo.GetDirectories();
				for (int i = 0; i < dirs.Length; i++)
                    ProcessFiles(dirs[i].FullName, bRecursive, sMask, arrReplaceDefs);
			}

			string[] arrMask = sMask.Split(';');

			for (int j = 0; j < arrMask.Length; j++)
			{
				System.IO.FileInfo[] files = dirInfo.GetFiles(arrMask[j]);
				for (int i = 0; i < files.Length; i++)
				{
					System.IO.StreamReader file = new System.IO.StreamReader(files[i].FullName, System.Text.Encoding.Default);
					string sFileContent = file.ReadToEnd();
					file.Close();

                    bool bReplaced = false;

                    foreach (string sFind in arrReplaceDefs.Keys)
                    {
                        if (sFileContent.IndexOf(sFind) >= 0)
                        {
                            bReplaced = true;
                            System.IO.StreamWriter bckFile = new System.IO.StreamWriter(files[i].FullName.Substring(0, files[i].FullName.Length - files[i].Extension.Length) + ".replace_bckp", false, System.Text.Encoding.Default);
                            bckFile.Write(sFileContent);
                            bckFile.Close();

                            while (sFileContent.IndexOf(sFind) >= 0)
                                sFileContent = sFileContent.Replace(sFind, arrReplaceDefs[sFind]);
                            System.IO.StreamWriter outFile = new System.IO.StreamWriter(files[i].FullName, false, System.Text.Encoding.Default);
                            outFile.Write(sFileContent);
                            outFile.Close();
                        }
                    }

                    if (bReplaced)
                        m_nReplacedFilesCount++;
					m_nFileCount++;
				}
			}
		}
	}
}
