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
     
        public AssemblyReader()
        {
            namespaces = new List<Namespace>();
        }

        public List<Namespace> GetAssembly(string path)
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(path);

            GetAssemblyContent(assembly);

            return namespaces;
        }

        private void GetAssemblyContent(Assembly assembly)
        {
            foreach(Type type in assembly.DefinedTypes)
            {
                if (type.Namespace != null)
                {
                    Namespace ns = namespaces.Find(x => x.Name == type.Namespace);
                    if (ns == null)
                    {
                        ns = new Namespace(type.Namespace);
                        ns.DataTypes.Add(new ClassType(type));
                        namespaces.Add(ns);
                    }
                    else
                    {
                        ns.DataTypes.Add(new ClassType(type));
                    }
                }
            }
        }

    }
}
