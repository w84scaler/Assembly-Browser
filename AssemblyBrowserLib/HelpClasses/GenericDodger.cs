using System;

namespace AssemblyBrowserLib.HelpClasses
{
    internal class GenericDodger
    {
        internal static string GetName(Type type)
        {
            if (type.IsGenericType)
                return GetGenericName(type);
            return type.Name;
        }

        private static string GetGenericName(Type type)
        {
            string typeName = "";
            string tmp = type.GetGenericTypeDefinition().Name;
            int ind = tmp.LastIndexOf('`');
            typeName += (tmp.Substring(0, ind) + "<");
            Type[] argTypes = type.GetGenericArguments();
            foreach (Type argType in argTypes)
            {
                if (argType.IsGenericType)
                    typeName += (GetName(argType) + ", ");
                else
                    typeName += (argType.Name + ", ");
            }
            typeName = typeName.Substring(0, typeName.Length - 2) + ">";
            return typeName;
        }
    }
}
