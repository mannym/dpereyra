using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace Resource_CPP_Use_Seeker
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		static DataTable table;
		static ArrayList arrSymbols;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			table = new DataTable();
			table.Columns.Add("file", typeof(string));
			table.Columns.Add("symbol", typeof(string));

			arrSymbols = new ArrayList();

			string sfilegroup_base = "SFUI";
			string sRootPath = "C:\\Works\\SFNet Mobile\\" + sfilegroup_base, sMask = "*.cpp";
			string sTXTPath = "C:\\works\\Work Desk\\Unicode\\SFNet String Resources\\" + sfilegroup_base + ".txt";
			string sOutPathSymbol = "C:\\works\\Work Desk\\Unicode\\SFNet String Resources\\[UseBySymbol]" + sfilegroup_base + ".txt";
			string sOutPathFilename = "C:\\works\\Work Desk\\Unicode\\SFNet String Resources\\[UseByFilename]" + sfilegroup_base + ".txt";
			string sOutPathUnused = "C:\\works\\Work Desk\\Unicode\\SFNet String Resources\\[Unused]" + sfilegroup_base + ".txt";

			Console.WriteLine("Looking for symbols...");

			StreamReader rdTxt = new StreamReader(sTXTPath, System.Text.Encoding.Default, false);
			while (rdTxt.Peek() >= 0)
			{
				string sLine = rdTxt.ReadLine();
				if (sLine.Length == 0)
					continue;

				string[] arrStrings = new string[4];
				int nPos = 0;
				
				for (int i = 0; i < 4; i++)
				{
					try
					{
						Debug.Assert(sLine[nPos] == '[');
						int nTagEnd = sLine.IndexOf(']', nPos);
						Debug.Assert(nTagEnd > nPos);

						if (nTagEnd <= nPos)
							break;

						string sLen = sLine.Substring(nPos+1, nTagEnd-nPos-1);
						arrStrings[i] = sLine.Substring(nTagEnd+1, int.Parse(sLen));

						nPos = nTagEnd + int.Parse(sLen) + 1;
					}
					catch
					{ break; }
				}

				arrSymbols.Add(arrStrings[0]);
				Console.WriteLine(arrStrings[0]);
			}
			rdTxt.Close();

			ProcessFolder(sRootPath, sMask);

			{
				Console.WriteLine("Reporte por symbol");
				StreamWriter writer = new StreamWriter(sOutPathSymbol, false, System.Text.Encoding.Default);
				DataView view = new DataView(table);
				view.Sort = "symbol asc, file asc";
				view.RowFilter = "len(symbol) > 0 and len(file) > 0";
				IEnumerator rows = view.GetEnumerator();
				rows.Reset();
				string sLastSymbol = "";
				while (rows.MoveNext())
				{
					DataRowView row_view = (DataRowView)rows.Current;
					string sSymbol = row_view.Row["symbol"].ToString();

					if (sSymbol != sLastSymbol)
					{
						writer.WriteLine(Environment.NewLine + sSymbol);
						sLastSymbol = sSymbol;
					}

					writer.WriteLine(row_view.Row["file"].ToString());
				}
				writer.Close();
			}

			{
				Console.WriteLine("Reporte por archivo");
				StreamWriter writer = new StreamWriter(sOutPathFilename, false, System.Text.Encoding.Default);
				DataView view = new DataView(table);
				view.Sort = "file asc, symbol asc";
				view.RowFilter = "len(symbol) > 0 and len(file) > 0";
				IEnumerator rows = view.GetEnumerator();
				rows.Reset();
				string sLastFilename = "";
				while (rows.MoveNext())
				{
					DataRowView row_view = (DataRowView)rows.Current;
					string sFilename = row_view.Row["file"].ToString();

					if (sFilename != sLastFilename)
					{
						writer.WriteLine(Environment.NewLine + sFilename);
						sLastFilename = sFilename;
					}

					writer.WriteLine(row_view.Row["symbol"].ToString());
				}
				writer.Close();
			}

			{
				Console.WriteLine("Reporte de symbols no utilizados");
				StreamWriter writer = new StreamWriter(sOutPathUnused, false, System.Text.Encoding.Default);

				DataView view = new DataView(table);
				view.Sort = "symbol asc";
				view.RowFilter = "len(symbol) > 0";

				for (int i = 0; i < arrSymbols.Count; i++)
				{
					if (view.Find(arrSymbols[i].ToString()) < 0)
						writer.WriteLine(arrSymbols[i].ToString());
				}
				writer.Close();
			}
		}

		private static void ProcessFolder(string sRootPath, string sMask)
		{
			Console.WriteLine(Environment.NewLine + "Checking folder: " + sRootPath);

			DirectoryInfo oCurrDir = new DirectoryInfo(sRootPath);
			DirectoryInfo[] subdirs = oCurrDir.GetDirectories();
			for (int i = 0; i < subdirs.Length; i++)
				ProcessFolder(subdirs[i].FullName, sMask);

			FileInfo[] files = oCurrDir.GetFiles(sMask);
			for (int i = 0; i < files.Length; i++)
			{
				Console.WriteLine(files[i].FullName);

				StreamReader file_reader = new StreamReader(files[i].FullName, System.Text.Encoding.Default, false);
				string sFileContent = file_reader.ReadToEnd();

				for (int j = 0; j < arrSymbols.Count; j++)
				{
					if (sFileContent.IndexOf(arrSymbols[j].ToString()) >= 0)
					{
						DataRow row = table.NewRow();
						row["file"] = files[i].FullName;
						row["symbol"] = arrSymbols[j].ToString();
						table.Rows.Add(row);
					}
				}

				file_reader.Close();
			}
		}
	}
}
