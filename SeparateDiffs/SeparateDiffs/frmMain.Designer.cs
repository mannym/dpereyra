namespace SeparateDiffs
{
    partial class frmMain
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
            this.txtFolderA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolderB = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.chkRenameFilesA = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carpeta A:";
            // 
            // txtFolderA
            // 
            this.txtFolderA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderA.Location = new System.Drawing.Point(75, 9);
            this.txtFolderA.Name = "txtFolderA";
            this.txtFolderA.Size = new System.Drawing.Size(340, 20);
            this.txtFolderA.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Carpeta B:";
            // 
            // txtFolderB
            // 
            this.txtFolderB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderB.Location = new System.Drawing.Point(75, 35);
            this.txtFolderB.Name = "txtFolderB";
            this.txtFolderB.Size = new System.Drawing.Size(340, 20);
            this.txtFolderB.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(340, 61);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 24);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // chkRenameFilesA
            // 
            this.chkRenameFilesA.AutoSize = true;
            this.chkRenameFilesA.Location = new System.Drawing.Point(15, 66);
            this.chkRenameFilesA.Name = "chkRenameFilesA";
            this.chkRenameFilesA.Size = new System.Drawing.Size(131, 17);
            this.chkRenameFilesA.TabIndex = 4;
            this.chkRenameFilesA.Text = "Renombrar archivos A";
            this.chkRenameFilesA.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 97);
            this.Controls.Add(this.chkRenameFilesA);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtFolderB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFolderA);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 125);
            this.MinimumSize = new System.Drawing.Size(250, 125);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeparateDiffs";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolderB;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox chkRenameFilesA;
    }
}

