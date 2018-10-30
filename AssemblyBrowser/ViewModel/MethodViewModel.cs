using AssemblyBrowserLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class MethodViewModel
    {
        private readonly Method method;

        public string MethodString
        {
            get
            {
                return method.Signature;
            }
        }

        public MethodViewModel(Method method)
        {
            this.method = method;
        }
    }
}
