using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Q4TInfra.Data;

namespace DBScriptExecute
{
	public enum ScriptFileStatus
	{
		New = 1,
		ExecOK,
		ExecFailed,
		NotExec,
		Executing
	}

	public class ScriptFile
	{
		public FileInfo	fileInfo = null;
		public ScriptFileStatus	Status = ScriptFileStatus.New;
		public string Error = "";
		public string ErrorScript = "";

		public event _changeStatus ChangeStatus;

		public override string ToString()
		{
			if (fileInfo != null)
			{
				string str = fileInfo.Name;
				switch (Status)
				{
					case ScriptFileStatus.ExecFailed:
						str += (" (" + Error + ")");
						break;
					case ScriptFileStatus.ExecOK:
						str += " (OK)";
						break;
					case ScriptFileStatus.NotExec:
						str += " (no ejecutado)";
						break;
					case ScriptFileStatus.Executing:
						str += " (ejecutando)";
						break;
				}
				return str;
			}
			return base.ToString ();
		}

		public void ResetStatus()
		{
			ErrorScript = "";
			Error = "";
			Status = ScriptFileStatus.NotExec;
		}

		public bool Execute(ref ScriptDbLayer dbScript)
		{
			Status = ScriptFileStatus.Executing;

			SendStatus(fileInfo.Name + ": Leyendo archivo");

			StreamReader tmpStream = fileInfo.OpenText();
			string batch = tmpStream.ReadToEnd();
			tmpStream.Close();

			SendStatus(fileInfo.Name + ": Generando batchs");
			string[] scripts = GetScripts(batch);
		
			for (int i = 0; i < scripts.Length; i++)
			{
				SendStatus(fileInfo.Name + ": Ejecutando batch " + i);
				dbScript.Execute(scripts[i]);
			}

			Status = ScriptFileStatus.ExecOK;

			return true;
		}

		private string[] GetScripts(string batch)
		{
			ArrayList arrScripts = new ArrayList();
			string lowerBatch = batch.ToLower();

			bool goEnd, goStart;

			int endPos = 0, startPos = 0;
			endPos = lowerBatch.IndexOf("go");
			while (endPos >= 0)
			{
				goEnd = goStart = false;
				if (batch.Length > (endPos+2)) // tengo más caracteres despues del go
				{
					if(	Char.IsControl(batch[endPos+2])	||
						Char.IsSeparator(batch[endPos+2])) // si termina en 'go'	
					{
						goEnd = true; // termina en 'go'
					}
				}
				else
					goEnd = true; // termina en 'go'

				if ((	endPos == 0 ) ||
					(	Char.IsControl(batch[endPos-1])	||
						Char.IsSeparator(batch[endPos-1]))) // si no tiene caracteres antes
				{
					goStart = true; // empieza en 'go'
				}

				if (goStart && goEnd) // encontre una palabra 'go'
				{
					string script = batch.Substring(startPos, endPos-startPos);
					if (script.Trim().Length > 0)
						arrScripts.Add(script); // solo o agrego si tiene algo de contenido util

					startPos = endPos+2;
				}

				if (lowerBatch.Length > (endPos+2))
					endPos = lowerBatch.IndexOf("go", endPos+2);
				else
					endPos = -1;
			}
			if (batch.Length > startPos)
			{
				string script = batch.Substring(startPos);
				if (script.Trim().Length > 0)
					arrScripts.Add(script);
			}

			string[] ret = null;
			if (arrScripts.Count > 0)
			{
				ret = new string[arrScripts.Count];
				for (int i = 0; i < arrScripts.Count; i++)
					ret[i] = (string)arrScripts[i];
			}
			 
			return ret;
		}

		private void SendStatus(string status)
		{
			if (ChangeStatus != null)
				ChangeStatus(status);
			Application.DoEvents();
		}
	}
}

