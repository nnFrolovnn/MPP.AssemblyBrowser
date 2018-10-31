using System.Reflection;

namespace AssemblyBrowserLib.Models
{
    public class Method
    {
        public string Name { get; set; }
        public string Signature { get; set; }

        public bool IsPublic { get; set; }
        public bool IsStatic { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsFinal { get; set; }

        public Method(MethodInfo method)
        {
            Name = method.Name;

            IsStatic = method.IsStatic;
            IsVirtual = method.IsVirtual;
            IsFinal = method.IsFinal;
            IsPublic = method.IsPublic;

            Signature = method.ToString();
        }
    }
}

