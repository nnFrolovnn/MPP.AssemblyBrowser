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
                string FullProperty = "public ";

                FullProperty += property.PropertyType + " " + property.Name;

                if (property.CanRead)
                {
                    FullProperty += "{ get; ";
                    if (property.CanWrite)
                    {
                        FullProperty += " set; }";
                    }
                    else
                    {
                        FullProperty += "}";
                    }
                }
                else
                {
                    if (property.CanWrite)
                    {
                        FullProperty += "{ set; }";
                    }
                }

                return FullProperty;

            }
        }

        public PropertyViewModel(Property property)
        {
            this.property = property;
        }
    }
}
