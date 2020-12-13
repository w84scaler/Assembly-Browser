using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLib.Levels;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AssemblyBrowserLibTests
    {
        AssemblyLevel _assembly;
        NamespaceLevel _namespace;
        ClassLevel _class;

        List<string> namespace_list;
        List<string> class_list;
        List<string> method_list;
        List<string> property_list;
        List<string> field_list;

        [TestInitialize]
        public void Setup()
        {
            namespace_list = new List<string>() { "AssemblyBrowserLib.Levels", "AssemblyBrowserLib.HelpClasses" };
            class_list = new List<string>() { "public AssemblyLevel", "public ClassLevel", "public FieldLevel", "public MethodLevel", "public NamespaceLevel", "public PropertyLevel" };
            method_list = new List<string>() { "private String GetSignature(MethodLevel method)", "public String GetFullName()" };
            property_list = new List<string>() { "String Name { public get; private set; }", "String Type { public get; private set; }", "MethodInfo methodInfo { public get; private set; }" };
            field_list = new List<string>() { "private ParameterInfo[] Parameters" };

            _assembly = new AssemblyLevel("AssemblyBrowserLib.dll");
            _namespace = _assembly.Namespaces.Find(ns => ns.GetFullName() == namespace_list[0]);
            _class = _namespace.Classes.Find(cl => cl.GetFullName() == class_list[3]);
        }

        [TestMethod]
        public void AssemblyTest()
        {
            Assert.AreEqual(_assembly.Namespaces.Count, namespace_list.Count, "wrong namespace count");
            foreach (NamespaceLevel _namespace in _assembly.Namespaces)
            {
                if (namespace_list.Contains(_namespace.GetFullName()))
                {
                    namespace_list.Remove(_namespace.GetFullName());
                }
            }
            Assert.AreEqual(namespace_list.Count, 0, "wrong namespace names");
        }

        [TestMethod]
        public void NamespaseTest()
        {
            Assert.AreEqual(_namespace.Classes.Count, class_list.Count, "wrong class count");
            foreach (ClassLevel _class in _namespace.Classes)
            {
                if (class_list.Contains(_class.GetFullName()))
                {
                    class_list.Remove(_class.GetFullName());
                }
            }
            Assert.AreEqual(class_list.Count, 0, "wrong class names");
        }

        [TestMethod]
        public void ClassFieldTest()
        {
            Assert.AreEqual(_class.Fields.Count, field_list.Count, "wrong field count");
            foreach (FieldLevel _field in _class.Fields)
            {
                if (field_list.Contains(_field.GetFullName()))
                {
                    field_list.Remove(_field.GetFullName());
                }
            }
            Assert.AreEqual(field_list.Count, 0, "wrong field names");
        }

        [TestMethod]
        public void ClassPropertyTest()
        {
            Assert.AreEqual(_class.Properties.Count, property_list.Count, "wrong property count");
            foreach (PropertyLevel _prop in _class.Properties)
            {
                if (property_list.Contains(_prop.GetFullName()))
                {
                    property_list.Remove(_prop.GetFullName());
                }
            }
            Assert.AreEqual(property_list.Count, 0, "wrong property names");
        }

        [TestMethod]
        public void ClassMethodTest()
        {
            Assert.AreEqual(_class.Methods.Count, method_list.Count, "wrong method count");
            foreach (MethodLevel _method in _class.Methods)
            {
                if (method_list.Contains(_method.GetFullName()))
                {
                    method_list.Remove(_method.GetFullName());
                }
            }
            Assert.AreEqual(method_list.Count, 0, "wrong method names");
        }
    }
}