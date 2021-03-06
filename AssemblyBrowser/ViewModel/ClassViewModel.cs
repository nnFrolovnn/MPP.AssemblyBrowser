﻿using AssemblyBrowserLib.Models;
using System.Collections.Generic;

namespace AssemblyBrowser.ViewModel
{
    public class ClassViewModel
    {
        private readonly ClassType classType;

        public string ClassString
        {
            get
            {
                string fullName = "";
                if (classType.IsPublic)
                {
                    fullName += "public ";
                }
                if (classType.IsSealed)
                {
                    fullName += "sealed ";
                }
                if (classType.IsInterface)
                {
                    fullName += "interface ";
                }
                if (classType.IsAbstract && !classType.IsInterface)
                {
                    fullName += "abstract ";
                }
                if (classType.IsClass)
                {
                    fullName += "class ";
                }
                fullName += classType.Name;
                return fullName;
            }
        }

        public IEnumerable<object> Members
        {
            get
            {
                foreach (Field field in classType.Fields)
                {
                    yield return new FieldViewModel(field);
                }
                if (classType.Fields?.Count > 0)
                {
                    yield return " ";
                }
                foreach (Property property in classType.Properties)
                {
                    yield return new PropertyViewModel(property);
                }
                if (classType.Properties?.Count > 0)
                {
                    yield return " ";
                }
                foreach (Method method in classType.Methods)
                {
                    yield return new MethodViewModel(method);
                }
            }
        }

        public ClassViewModel(ClassType type)
        {
            classType = type;
        }
    }
}
