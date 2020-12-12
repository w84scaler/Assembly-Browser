using System;
using System.Collections.Generic;
using static AssemblyBrowserLib.HelpClasses.CompilerDodger;

namespace AssemblyBrowserLib.Levels
{
    public class NamespaceLevel
    {
        public string Name { get; }
        public List<ClassLevel> Classes { get; }

        internal NamespaceLevel(string _namespace, List<Type> types)
        {
            Name = _namespace;
            Classes = new List<ClassLevel>();
            foreach (Type type in types)
            {
                if (!CompilerGenerated(type))
                    Classes.Add(new ClassLevel(type));
            }
        }

        public string GetFullName()
        {
            return Name;
        }
    }
}
