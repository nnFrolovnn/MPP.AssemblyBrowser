using System.Reflection;

namespace AssemblyBrowserLib.Models
{
    public class Property
    {
        public string Name { get; set; }
        public string PropertyType { get; set; }

        public bool IsPublic { get; set; }
        public bool CanWrite { get; set; }
        public bool CanRead { get; set; }

        public Property(PropertyInfo property)
        {
            Name = property.Name;
            PropertyType = property.PropertyType.Name;

            IsPublic = true;
            CanRead = property.CanRead;
            CanWrite = property.CanWrite;
        }

    }
}
