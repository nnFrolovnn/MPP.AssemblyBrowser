using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class ClassViewModel
    {
        private readonly ClassType classType;

        public string ClassString => classType.FullName;

        public IEnumerable<object> Members
        {
            get
            {
                foreach (Field field in classType.Fields)
                {
                    yield return new FieldViewModel(field);
                }
                if (classType.Fields?.Count > 0)
                {
                    yield return " ";
                }
                foreach (Property property in classType.Properties)
                {
                    yield return new PropertyViewModel(property);
                }
                if (classType.Properties?.Count > 0)
                {
                    yield return " ";
                }
                foreach (Method method in classType.Methods)
                {
                    yield return new MethodViewModel(method);
                }
            }
        }

        public ClassViewModel(ClassType type)
        {
            classType = type;
        }
    }
}
