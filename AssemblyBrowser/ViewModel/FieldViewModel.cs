using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class FieldViewModel
    {
        private readonly Field field;

        public string FieldString { get => field.FullField; }

        public FieldViewModel(Field field)
        {
            this.field = field;
        }
    }
}
