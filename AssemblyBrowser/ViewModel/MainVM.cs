using AssemblyBrowser.Model;
using AssemblyBrowserLib;
using AssemblyBrowserLib.Models;
using System.Collections.Generic;

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
                        assemblyContent = assemblyReader.LoadAssemblyTypes(fileWorker.FilePath);                
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
