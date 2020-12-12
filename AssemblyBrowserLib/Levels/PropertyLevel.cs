using System.Reflection;
using AssemblyBrowserLib.HelpClasses;

namespace AssemblyBrowserLib.Levels
{
    public class PropertyLevel
    {
        public string Type { get; }
        public string Name { get; }
        public PropertyInfo propInfo { get; }

        internal PropertyLevel(PropertyInfo prop)
        {
            Type = GenericDodger.GetName(prop.PropertyType);
            Name = prop.Name;
            propInfo = prop;
        }

        public string GetFullName()
        {
            return Type + " " + Name + " { " + Modificators.GetPropertyGetSetModificators(propInfo) + " }";
        }
    }
}
