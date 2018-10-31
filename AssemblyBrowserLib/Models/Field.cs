using System.Reflection;

namespace AssemblyBrowserLib.Models
{
    public class Field
    {
        public string Name { get; set; }
        public string FieldType { get; set; }

        public bool IsPublic { get; set; }
        public bool IsStatic { get; set; }

        public Field(FieldInfo field)
        {
            Name = field.Name;
            FieldType = field.FieldType.Name;

            SetProperties(field);
        }

        private void SetProperties(FieldInfo field)
        {
            IsPublic = field.IsPublic;
            IsStatic = field.IsStatic;
        }
    }
}
