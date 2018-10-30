using System.Collections.Generic;

namespace AssemblyBrowserLib.Models
{
    public class Namespace
    {
        public string Name { get; set; }
        public List<ClassType> DataTypes { get; set; }

        public Namespace()
        {
            DataTypes = new List<ClassType>();
        }

        public Namespace(string name):this()
        {
            Name = name;
        }

    }
}
