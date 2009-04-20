using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace BinaryExtractor
{
    public partial class frmMain : Form
    {
        XmlDocument config = null;
        string configFilePath = String.Empty;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearchFolder_Click(object sender, EventArgs e)
        {
            Shell32.Folder folder = new Shell32.Shell().BrowseForFolder((int)this.Handle, "Choose folder.", 0, 0);
            if (folder != null)
                txtOutputFolder.Text = (folder as Shell32.Folder3).Self.Path;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            configFilePath = Application.ExecutablePath;
            configFilePath = configFilePath.Substring(0, configFilePath.Length - ".exe".Length) + ".config";

            LoadConfig();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SaveConfig();

            if (Directory.Exists(txtOutputFolder.Text))
            {
                if (Directory.GetFiles(txtOutputFolder.Text).Length > 0 &&
                    MessageBox.Show("Some files in output folder could be overwritten, do you want to continue?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
            }
            else
                Directory.CreateDirectory(txtOutputFolder.Text);

            using (SqlConnection connection = new SqlConnection(txtConnectionString.Text))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = txtQuery.Text;
                    command.Connection = connection;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int nRow = 0;
                        while (reader.Read())
                        {
                            for (int nColumn = 0; nColumn < reader.FieldCount; ++nColumn)
                            {
                                string fieldName = reader.GetName(nColumn);
                                if (String.IsNullOrEmpty(fieldName))
                                    fieldName = "Unnamed";

                                string outputFilePath = Path.Combine(txtOutputFolder.Text, string.Format("{0}_{1}_{2}", nRow.ToString("000"), nColumn.ToString("000"), fieldName));
                                if (File.Exists(outputFilePath))
                                    File.Delete(outputFilePath);

                                byte[] data = null;
                                
                                try { data = reader.GetSqlBinary(nColumn).Value; }
                                catch { }

                                if (data == null)
                                {
                                    data = Encoding.UTF8.GetBytes(reader[nColumn].ToString());
                                    outputFilePath += ".txt";
                                }

                                if (data != null)
                                {
                                    using (FileStream file = File.OpenWrite(outputFilePath))
                                    {
                                        file.Write(data, 0, data.Length);
                                        file.Close();
                                    }
                                }
                            }
                            ++nRow;
                        }
                    }
                }

                MessageBox.Show("Completed");
            }
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    config = new XmlDocument();
                    config.Load(configFilePath);

                    if (config.GetElementsByTagName("lastUserInput").Count > 0)
                    {
                        XmlNode nodeLastUserInput = config.GetElementsByTagName("lastUserInput")[0];
                        if (nodeLastUserInput.Attributes["connectionString"] != null)
                            txtConnectionString.Text = nodeLastUserInput.Attributes["connectionString"].Value;
                        if (nodeLastUserInput.Attributes["query"] != null)
                            txtQuery.Text = nodeLastUserInput.Attributes["query"].Value;
                        if (nodeLastUserInput.Attributes["outputFolder"] != null)
                            txtOutputFolder.Text = nodeLastUserInput.Attributes["outputFolder"].Value;
                    }
                }
            }
            catch
            {
            }
        }

        private void SaveConfig()
        {
            try
            {
                if (config == null)
                    config = new XmlDocument();

                XmlNode nodeLastUserInput = null;
                if (config.GetElementsByTagName("lastUserInput").Count == 0)
                    config.AppendChild(config.CreateNode(XmlNodeType.Element, "lastUserInput", null));
                nodeLastUserInput = config.GetElementsByTagName("lastUserInput")[0];

                if (nodeLastUserInput.Attributes["connectionString"] == null)
                    nodeLastUserInput.Attributes.Append(config.CreateAttribute("connectionString"));
                nodeLastUserInput.Attributes.GetNamedItem("connectionString").Value = txtConnectionString.Text;

                if (nodeLastUserInput.Attributes["query"] == null)
                    nodeLastUserInput.Attributes.Append(config.CreateAttribute("query"));
                nodeLastUserInput.Attributes.GetNamedItem("query").Value = txtQuery.Text;

                if (nodeLastUserInput.Attributes["outputFolder"] == null)
                    nodeLastUserInput.Attributes.Append(config.CreateAttribute("outputFolder"));
                nodeLastUserInput.Attributes.GetNamedItem("outputFolder").Value = txtOutputFolder.Text;

                config.Save(configFilePath);
            }
            catch
            {
            }
        }
    }
}