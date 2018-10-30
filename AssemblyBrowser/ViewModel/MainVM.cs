using AssemblyBrowser.Interfaces;
using AssemblyBrowser.Model;
using AssemblyBrowserLib;
using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class MainVM : ViewModelBase
    {
        List<Namespace> assemblyContent;
        private DelegateCommand delegator;
        private FileWorker fileWorker;

        public List<NamespaceViewModel> Namespaces
        {
            get
            {
                List<NamespaceViewModel> nsv = new List<NamespaceViewModel>(); 
                foreach (Namespace ns in assemblyContent)
                {
                    nsv.Add(new NamespaceViewModel(ns));
                }
                return nsv;
            }
        }

        public DelegateCommand LoadAssembly
        {
            get => delegator = new DelegateCommand(obj =>
                {
                    AssemblyReader assemblyReader = new AssemblyReader();

                    if (fileWorker.OpenFileD())
                    {
                        assemblyContent = assemblyReader.GetAssembly(fileWorker.FilePath);                
                        OnPropertyChanged(nameof(Namespaces));
                    }

                });
        }

        public MainVM()
        {
            fileWorker = new FileWorker();
            assemblyContent = new List<Namespace>();
        }


    }
}
