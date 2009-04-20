using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SeparateDiffs
{
    public class FolderProcess
    {
        private const string ExactSufix = "_EXACT";

        private bool _started = false;
        private bool _finished = false;
        private string _currentFolder = "";

        private string _startFolderA = "";
        private string _startFolderB = "";
        private bool _renameFilesA = false;

        public FolderProcess(string startFolderA, string startFolderB, bool renameFilesA)
        {
            _startFolderA = startFolderA;
            _startFolderB = startFolderB;
            _renameFilesA = renameFilesA;
        }

        public void Run()
        {
            Started = true;
            DirectoryInfo dirA, dirAExact, dirB, dirBExact;

            PrepareFolder(_startFolderA, out dirA, out dirAExact);
            PrepareFolder(_startFolderB, out dirB, out dirBExact);

            ProcessFolder(dirA, dirAExact, dirB, dirBExact);
            Finished = true;
        }

        public bool Started
        {
            get { lock (this) return _started; }
            private set { lock (this) _started = value; }
        }

        public bool Finished
        {
            get { lock (this) return _finished; }
            private set { lock (this) _finished = value; }
        }

        public string CurrentFolder
        {
            get { lock (this) return _currentFolder; }
            private set { lock (this) _currentFolder = value; }
        }

        private void PrepareFolder(string folder, out DirectoryInfo dir, out DirectoryInfo dirExact)
        {
            dir = new DirectoryInfo(folder);
            string sDirExact = Path.Combine(dir.Parent.FullName, dir.Name + ExactSufix);
            if (Directory.Exists(sDirExact))
                throw new Exception("Path " + sDirExact + " already exists.");
            dirExact = Directory.CreateDirectory(sDirExact);
        }

        private void ProcessFolder(DirectoryInfo dirA, DirectoryInfo dirAExact, DirectoryInfo dirB, DirectoryInfo dirBExact)
        {
            CurrentFolder = dirA.Name;

            foreach (FileInfo fileA in dirA.GetFiles())
            {
                string sFileBPath = Path.Combine(dirB.FullName, fileA.Name);
                if (File.Exists(sFileBPath))
                {
                    FileInfo fileB = new FileInfo(sFileBPath);

                    byte[] fileAData = File.ReadAllBytes(fileA.FullName);
                    byte[] fileBData = File.ReadAllBytes(fileB.FullName);

                    if (EqualData(fileAData, fileBData))
                    {
                        if (!Directory.Exists(dirAExact.FullName))
                            Directory.CreateDirectory(dirAExact.FullName);
                        if (!Directory.Exists(dirBExact.FullName))
                            Directory.CreateDirectory(dirBExact.FullName);

                        if (_renameFilesA)
                            File.Move(fileA.FullName, Path.Combine(dirAExact.FullName, fileA.Name));
                        File.Move(fileB.FullName, Path.Combine(dirBExact.FullName, fileB.Name));
                    }
                }
            }

            foreach (DirectoryInfo subdirA in dirA.GetDirectories())
            {
                DirectoryInfo subdirB = new DirectoryInfo(Path.Combine(dirB.FullName, subdirA.Name));
                if (subdirB.Exists)
                {
                    DirectoryInfo subdirAExact = new DirectoryInfo(Path.Combine(dirAExact.FullName, subdirA.Name));
                    if (!subdirAExact.Exists)
                        subdirAExact.Create();

                    DirectoryInfo subdirBExact = new DirectoryInfo(Path.Combine(dirBExact.FullName, subdirA.Name));
                    if (!subdirBExact.Exists)
                        subdirBExact.Create();

                    ProcessFolder(
                        subdirA,
                        subdirAExact,
                        subdirB,
                        subdirBExact);
                }
            }

            if (dirAExact.GetFiles().Length == 0 && dirAExact.GetDirectories().Length == 0)
                dirAExact.Delete();
            if (dirBExact.GetFiles().Length == 0 && dirBExact.GetDirectories().Length == 0)
                dirBExact.Delete();
        }

        private bool EqualData(byte[] dataA, byte[] dataB)
        {
            if (dataA.Length != dataB.Length)
                return false;

            for (int i = 0; i < dataA.Length; i++)
            {
                if (dataA[i] != dataB[i])
                    return false;
            }

            return true;
        }
    }
}
