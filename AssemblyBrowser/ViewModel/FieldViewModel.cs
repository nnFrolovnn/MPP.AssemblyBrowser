using AssemblyBrowserLib.Models;

namespace AssemblyBrowser.ViewModel
{
    public class FieldViewModel
    {
        private readonly Field field;

        public string FieldString
        {
            get
            {
                string fullField = "public ";

                if (field.IsStatic)
                {
                    fullField += "static ";
                }

                fullField += field.FieldType + " " + field.Name;

                return fullField;
            }
        }

        public FieldViewModel(Field field)
        {
            this.field = field;
        }
    }
}
