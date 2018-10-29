using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLib
{
    public class AssemblyReader
    {
        private readonly List<Namespace> namespaces;
        Assembly assembly;

        public AssemblyReader()
        {
            namespaces = new List<Namespace>();
        }

        public List<Namespace> GetAssembly()
        {



            return namespaces;
        }


        private void GetClasses()
        {

        }

        private void GetNamespaces()
        {

        }

    }
}
