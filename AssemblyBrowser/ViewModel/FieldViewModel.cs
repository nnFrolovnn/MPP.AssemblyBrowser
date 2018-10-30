using AssemblyBrowserLib.Models;

namespace AssemblyBrowser.ViewModel
{
    public class FieldViewModel
    {
        private readonly Field field;

        public string FieldString { get => field.FullField; }

        public FieldViewModel(Field field)
        {
            this.field = field;
        }
    }
}
