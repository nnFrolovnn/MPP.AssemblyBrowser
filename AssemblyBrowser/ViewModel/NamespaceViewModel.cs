using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class NamespaceViewModel
    {
        private readonly Namespace ns;

        public string Name => ns.Name;
        public List<ClassViewModel> ClassTypes
        {
            get
            {
                List<ClassViewModel> list = new List<ClassViewModel>();

                foreach(var cl in ns.DataTypes)
                {
                    list.Add(new ClassViewModel(cl));
                }
                return list;
            }
        }

        public NamespaceViewModel(Namespace ns)
        {
            this.ns = ns;
        }      
    }
}
