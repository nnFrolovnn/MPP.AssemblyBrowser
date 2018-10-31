using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowserLib
{
    public class AssemblyReader
    {
     
        public AssemblyReader()
        {
        }

        public List<Namespace> LoadAssemblyTypes(string path)
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(path);

            return LoadAssemblyContent(assembly);
        }

        private List<Namespace> LoadAssemblyContent(Assembly assembly)
        {
            List<Namespace> namespaces = new List<Namespace>();

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
                else
                {
                    Namespace ns = namespaces.Find(x => x.Name == "Global");
                    if (ns == null)
                    {
                        ns = new Namespace("Global");
                        namespaces.Add(ns);
                    }

                    ns.DataTypes.Add(new ClassType(type));
                }
            }

            return namespaces;
        }

    }
}
