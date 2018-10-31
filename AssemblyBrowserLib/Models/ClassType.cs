using System;
using System.Collections.Generic;

namespace AssemblyBrowserLib.Models
{
    public class ClassType
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool IsSealed { get; set; }
        public bool IsInterface { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsClass { get; set; }

        public List<Field> Fields { get; set; }
        public List<Property> Properties { get; set; }
        public List<Method> Methods { get; set; }

        public ClassType(Type type)
        {
            Fields = new List<Field>();
            Properties = new List<Property>();
            Methods = new List<Method>();

            Name = type.Name;
            GetFields(type);
            GetProperties(type);
            GetMethods(type);

            SetProperties(type);
        }

        private void SetProperties(Type type)
        {
            IsAbstract = type.IsAbstract;
            IsClass = type.IsClass;
            IsInterface = type.IsInterface;
            IsPublic = type.IsPublic;
            IsSealed = type.IsSealed;
            
        }

        private void GetFields(Type type)
        {           
            var fields = type.GetFields();

            foreach (var field in fields)
            {
                Fields.Add(new Field(field));
            }
        }

        private void GetProperties(Type type)
        {            
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                Properties.Add(new Property(property));
            }
        }

        private void GetMethods(Type type)
        {
            
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                if (!method.IsSpecialName)
                {
                    Methods.Add(new Method(method));
                }
            }
        }
    }

}
