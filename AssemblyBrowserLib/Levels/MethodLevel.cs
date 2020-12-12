using System.Reflection;
using AssemblyBrowserLib.HelpClasses;

namespace AssemblyBrowserLib.Levels
{
    public class MethodLevel
    {
        private ParameterInfo[] Parameters;
        public string Name { get; }
        public string Type { get; }
        public MethodInfo methodInfo { get; }

        internal MethodLevel(MethodInfo method)
        {
            methodInfo = method;
            Name = method.Name;
            Type = GenericDodger.GetName(method.ReturnType);
            Parameters = method.GetParameters();
        }

        private string GetSignature(MethodLevel method)
        {
            string signature = "";
            signature += (method.Type + " " + method.Name + "(");
            if (method.Parameters.Length == 0)
                return signature + ")";
            foreach (ParameterInfo p in method.Parameters)
            {
                if (p.IsOut)
                    signature += "out ";
                signature += (GenericDodger.GetName(p.ParameterType) + " " + p.Name + ", ");
            }
            while (signature.IndexOf('&') != -1)
            {
                signature = signature.Replace('&', ' ');
            }
            return signature.Substring(0, signature.Length - 2) + ")";
        }

        public string GetFullName()
        {
            return Modificators.GetMethodModificators(methodInfo) + GetSignature(this); ;
        }
    }
}
