using System;
using System.Collections.Generic;

namespace AssemblyBrowserLib.Models
{
    public class ClassType
    {
        public string Name { get; set; }
        public string FullName { get; private set; }

        public List<Field> Fields { get; set; }
        public List<Property> Properties { get; set; }
        public List<Method> Methods { get; set; }

        public ClassType(Type type)
        {
            Fields = new List<Field>();
            Properties = new List<Property>();
            Methods = new List<Method>();

            Name = type.Name;
            GetFields(ref type);
            GetProperties(ref type);
            GetMethods(ref type);

            SetFullName(type);
        }

        private void SetFullName(Type type)
        {
            FullName = "";
            if(type.IsPublic)
            {
                FullName += "public ";
            }
            if(type.IsSealed)
            {
                FullName += "sealed ";
            }
            if(type.IsInterface)
            {
                FullName += "interface ";
            }
            if(type.IsAbstract && !type.IsInterface)
            {
                FullName += "abstract ";
            }
            if(type.IsClass)
            {
                FullName += "class ";
            }
            FullName += Name;
        }

        private void GetFields(ref Type type)
        {           
            var fields = type.GetFields();

            foreach (var field in fields)
            {
                Fields.Add(new Field(field));
            }
        }

        private void GetProperties(ref Type type)
        {            
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                Properties.Add(new Property(property));
            }
        }

        private void GetMethods(ref Type type)
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
