using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Q4TInfra.Data;

namespace DBScriptExecute
{
	public delegate void _changeStatus(string status);

	public class ScriptExecute
	{
		private ScriptFile[]	_files;
		private string			_connString = "";
		private ScriptDbLayer	_dbScript = null;

		public event _changeStatus ChangeStatus;

		public ScriptExecute(string connectionString)
		{
			_connString = connectionString;
			_dbScript = new ScriptDbLayer(_connString);
		}

		public void Dispose()
		{
			if (_dbScript.IsInTransaction())
			{
				SendStatus("Abortando transacción");
				_dbScript.RollBackTransaction();
			}
			_dbScript.Dispose();
		}

		public bool BeginTx(ref string errorLog)
		{
			try
			{
				if (!_dbScript.IsInTransaction())
				{
					SendStatus("Iniciando transacción");
					_dbScript.BeginTransaction();
					SendStatus("Transacción iniciada");
				}
			}
			catch (Exception e)
			{
				if (errorLog != null)
					errorLog = e.Message;
				MessageBox.Show(e.Message, "BeginTransaction error");
				return false;;
			}
			return true;
		}

		public bool CommitTx(ref string errorLog)
		{
			try
			{
				if (_dbScript.IsInTransaction())
				{
					SendStatus("Confirmando transacción");
					_dbScript.CommitTransaction();
					SendStatus("Transacción confirmada");
				}
			}
			catch (Exception e)
			{
				if (errorLog != null)
					errorLog = e.Message;
				MessageBox.Show(e.Message, "CommitTransaction error");
				return false;;
			}
			return true;
		}

		public bool RollbackTx(ref string errorLog)
		{
			try
			{
				if (_dbScript.IsInTransaction())
				{
					SendStatus("Abortando transacción");
					_dbScript.RollBackTransaction();
					SendStatus("Transacción abortada");
				}
			}
			catch (Exception e)
			{
				if (errorLog != null)
					errorLog = e.Message;
				MessageBox.Show(e.Message, "RollbackTransaction error");
				return false;
			}
			return true;
		}

		public bool IsTxOpen()
		{
			return _dbScript.IsInTransaction();
		}
		
		public int ExecuteFiles(ScriptFile[] files, ref string errorLog)
		{
			_files = files;
			ScriptFile tmpScriptFile = null;
			int i = 0;
			
			try
			{
				// reinicio los succeed / error
				SendStatus("Reincializando scripts");
				for (i = 0; i < _files.Length; i++)
					((ScriptFile)_files.GetValue(i)).ResetStatus();

				// ejecuto los archivos
				for (i = 0; i < _files.Length; i++)
				{
					tmpScriptFile = (ScriptFile)_files.GetValue(i);
					tmpScriptFile.Execute(ref _dbScript);
				}

			}
			catch (Exception e)
			{
				if (errorLog != null)
					errorLog = e.Message;
				if (tmpScriptFile != null)
				{
					tmpScriptFile.Status = ScriptFileStatus.ExecFailed;
					if (e.GetType() == typeof(System.Data.SqlClient.SqlException))
					{
						tmpScriptFile.Error = e.Message;
						if (tmpScriptFile.Error.Length > 255)
							tmpScriptFile.Error = tmpScriptFile.Error.Substring(0,255);
					}
					MessageBox.Show(e.Message, "Script error in " + tmpScriptFile.fileInfo.Name);
				}
				else
					MessageBox.Show(e.Message, "Script error");
			}
			return i;
		}

		private void SendStatus(string status)
		{
			if (ChangeStatus != null)
				ChangeStatus(status);
			Application.DoEvents();
		}
	}
}
