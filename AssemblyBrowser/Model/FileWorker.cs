using AssemblyBrowser.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssemblyBrowser.Model
{
    class FileWorker : IFileWorker
    {
        public string FilePath { get; set; }

        public FileWorker()
        {
            FilePath = null;
        }


        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool OpenFileD()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }

            return false;
        }

        public bool SaveFileD()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }

            return false;
        }
    }
}
