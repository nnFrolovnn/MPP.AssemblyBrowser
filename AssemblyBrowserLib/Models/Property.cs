using System.Reflection;

namespace AssemblyBrowserLib.Models
{
    public class Property
    {
        public string Name { get; set; }
        public string PropertyType { get; set; }
        public string FullProperty { get; private set; }


        public Property(PropertyInfo property)
        {
            Name = property.Name;
            PropertyType = property.PropertyType.Name;

            SetFullProperty(property);
        }

        private void SetFullProperty(PropertyInfo property)
        {
            FullProperty = "public ";            

            FullProperty += PropertyType + " " + Name;

            if(property.CanRead)
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
                if(property.CanWrite)
                {
                    FullProperty += "{ set; }";
                }
            }


        }
    }
}
