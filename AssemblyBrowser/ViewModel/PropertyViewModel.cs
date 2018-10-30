using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class PropertyViewModel
    {
        private readonly Property property;

        public string PropertyString
        {
            get
            {
                return property.FullProperty;
            }
        }

        public PropertyViewModel(Property property)
        {
            this.property = property;
        }
    }
}
