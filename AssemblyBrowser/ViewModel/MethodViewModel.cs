using AssemblyBrowserLib.Models;

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
