using System;
using System.Drawing;
using System.Collections;
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.TextBox txtToReplace;
		private System.Windows.Forms.TextBox txtReplaceWith;
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
			this.txtToReplace = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtReplaceWith = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chkRecursive = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMask = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtFolder
			// 
			this.txtFolder.Location = new System.Drawing.Point(8, 32);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(280, 20);
			this.txtFolder.TabIndex = 0;
			this.txtFolder.Text = "";
			// 
			// txtToReplace
			// 
			this.txtToReplace.Location = new System.Drawing.Point(8, 144);
			this.txtToReplace.Name = "txtToReplace";
			this.txtToReplace.Size = new System.Drawing.Size(280, 20);
			this.txtToReplace.TabIndex = 1;
			this.txtToReplace.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(176, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 2;
			this.button1.Text = "Go";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtReplaceWith
			// 
			this.txtReplaceWith.Location = new System.Drawing.Point(8, 200);
			this.txtReplaceWith.Name = "txtReplaceWith";
			this.txtReplaceWith.Size = new System.Drawing.Size(280, 20);
			this.txtReplaceWith.TabIndex = 3;
			this.txtReplaceWith.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Carpeta raíz:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Texto a reemplazar:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Texto de reemplazo";
			// 
			// chkRecursive
			// 
			this.chkRecursive.Location = new System.Drawing.Point(200, 8);
			this.chkRecursive.Name = "chkRecursive";
			this.chkRecursive.Size = new System.Drawing.Size(80, 16);
			this.chkRecursive.TabIndex = 7;
			this.chkRecursive.Text = "Recursivo";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Máscara";
			// 
			// txtMask
			// 
			this.txtMask.Location = new System.Drawing.Point(8, 88);
			this.txtMask.Name = "txtMask";
			this.txtMask.Size = new System.Drawing.Size(280, 20);
			this.txtMask.TabIndex = 9;
			this.txtMask.Text = "*.*";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(298, 271);
			this.Controls.Add(this.txtMask);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkRecursive);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtReplaceWith);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtToReplace);
			this.Controls.Add(this.txtFolder);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Replace In Files";
			this.TopMost = true;
			this.ResumeLayout(false);

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
			if (txtToReplace.Text == txtReplaceWith.Text)
			{
				MessageBox.Show("El texto a reemplazar es igual al de reemplazo");
				return;
			}

			if (MessageBox.Show("Está seguro que quiere continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				m_nFileCount = 0;
				m_nReplacedFilesCount = 0;
				ProcessFiles(txtFolder.Text, chkRecursive.Checked, txtMask.Text,  txtToReplace.Text, txtReplaceWith.Text);
				MessageBox.Show("Se modificaron " + m_nReplacedFilesCount.ToString() + " de " + m_nFileCount.ToString());
			}
		}

		private void ProcessFiles(string sRoot, bool bRecursive, string sMask, string sFind, string sReplace)
		{
			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(sRoot);
			if (bRecursive)
			{
				System.IO.DirectoryInfo[] dirs = dirInfo.GetDirectories();
				for (int i = 0; i < dirs.Length; i++)
					ProcessFiles(dirs[i].FullName, bRecursive, sMask, sFind, sReplace);
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

					if (sFileContent.IndexOf(sFind) >= 0)
					{
						m_nReplacedFilesCount++;
						System.IO.StreamWriter bckFile = new System.IO.StreamWriter(files[i].FullName.Substring(0, files[i].FullName.Length - files[i].Extension.Length) + ".replace_bckp" , false, System.Text.Encoding.Default);
						bckFile.Write(sFileContent);
						bckFile.Close();

						while (sFileContent.IndexOf(sFind) >= 0)
							sFileContent = sFileContent.Replace(sFind, sReplace);
						System.IO.StreamWriter outFile = new System.IO.StreamWriter(files[i].FullName , false, System.Text.Encoding.Default);
						outFile.Write(sFileContent);
						outFile.Close();
					}
					m_nFileCount++;
				}
			}
		}
	}
}
