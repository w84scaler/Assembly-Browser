using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace AssemblyBrowserLib.Levels
{
    public class AssemblyLevel
    {
        public List<NamespaceLevel> Namespaces;
        public AssemblyLevel(string path)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Namespaces = new List<NamespaceLevel>();
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }
            Dictionary<string, List<Type>> namespaceAndItsClasses = GetNCD(types);
            foreach (KeyValuePair<string, List<Type>> pair in namespaceAndItsClasses)
            {
                Namespaces.Add(new NamespaceLevel(pair.Key, pair.Value));
            }
        }

        private Dictionary<string, List<Type>> GetNCD(Type[] types)
        {
            Dictionary<string, List<Type>> NamespacesClassesDictionary = new Dictionary<string, List<Type>>();
            foreach (Type type in types)
            {
                string _namespace;
                if (type.Namespace != null)
                    _namespace = type.Namespace;
                else
                    _namespace = "<>";
                if (!NamespacesClassesDictionary.ContainsKey(_namespace))
                {
                    List<Type> tmp = new List<Type>();
                    NamespacesClassesDictionary.Add(_namespace, tmp);
                }
                NamespacesClassesDictionary.TryGetValue(_namespace, out List<Type> classes);
                classes.Add(type);
            }
            return NamespacesClassesDictionary;
        }
    }
}