using AssemblyBrowserLib.HelpClasses;
using System.Reflection;

namespace AssemblyBrowserLib.Levels
{
    public class FieldLevel
    {
        public string Type { get; }
        public string Name { get; }
        public FieldInfo fieldInfo { get; }

        internal FieldLevel(FieldInfo field)
        {
            Type = GenericDodger.GetName(field.FieldType);
            Name = field.Name;
        }

        public string GetFullName()
        {
            return Modificators.GetFieldModificators(fieldInfo) + " " + Type + " " + Name;
        }
    }
}
