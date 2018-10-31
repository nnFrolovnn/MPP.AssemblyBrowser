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
                string fullMethod = "public ";

                if (method.IsStatic)
                {
                    fullMethod += "static ";
                }
                else if (method.IsVirtual && !method.IsFinal)
                {
                    fullMethod += "virtual ";
                }

                fullMethod += method.Signature + ";";

                return fullMethod;
            }
        }

        public MethodViewModel(Method method)
        {
            this.method = method;
        }
    }
}
