using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace SqlBinaryUploader
{
    public partial class frmMain : Form
    {
        XmlDocument config = null;
        string configFilePath = String.Empty;

        public frmMain()
        {
            InitializeComponent();
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

            if (!File.Exists(txtFile.Text))
                return;

            using (SqlConnection connection = new SqlConnection(txtConnectionString.Text))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = txtQuery.Text;

                    byte[] data = new byte[0];
                    using (FileStream file = File.OpenRead(txtFile.Text))
                    {
                        data = new byte[file.Length];
                        file.Read(data, 0, data.Length);
                        file.Close();
                    }

                    command.Parameters.Add(new SqlParameter(txtParameter.Text, data));
                    command.ExecuteNonQuery();
                }
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
                        if (nodeLastUserInput.Attributes["file"] != null)
                            txtFile.Text = nodeLastUserInput.Attributes["file"].Value;
                        if (nodeLastUserInput.Attributes["parameter"] != null)
                            txtParameter.Text = nodeLastUserInput.Attributes["parameter"].Value;
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

                if (nodeLastUserInput.Attributes["file"] == null)
                    nodeLastUserInput.Attributes.Append(config.CreateAttribute("file"));
                nodeLastUserInput.Attributes.GetNamedItem("file").Value = txtFile.Text;

                if (nodeLastUserInput.Attributes["parameter"] == null)
                    nodeLastUserInput.Attributes.Append(config.CreateAttribute("parameter"));
                nodeLastUserInput.Attributes.GetNamedItem("parameter").Value = txtParameter.Text;

                config.Save(configFilePath);
            }
            catch
            {
            }
        }

        private void btnSearchFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
                txtFile.Text = dlg.FileName;
        }
    }
}