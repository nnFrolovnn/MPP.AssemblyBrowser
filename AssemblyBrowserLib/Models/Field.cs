using System.Reflection;

namespace AssemblyBrowserLib.Models
{
    public class Field
    {
        public string Name { get; set; }

        public string FieldType { get; set; }

        public string FullField { get; private set; }

        public Field(FieldInfo field)
        {
            Name = field.Name;
            FieldType = field.FieldType.Name;

            SetFullField(field);
        }

        private void SetFullField(FieldInfo field)
        {
            FullField += "public ";

            if (field.IsStatic)
            {
                FullField += "static ";
            }

            FullField += FieldType + " " + Name;

        }
    }
}
