using AssemblyBrowserLib.Models;

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
