using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.Interfaces
{
    interface IFileWorker
    {
        void ShowMessage(string message);
        string FilePath { get; set; }
        bool OpenFileD();
        bool SaveFileD();
    }
}
