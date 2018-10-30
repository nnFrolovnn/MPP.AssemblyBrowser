using System;
using System.Collections.Generic;
using AssemblyBrowserLib;
using AssemblyBrowserLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowserTest
{
    [TestClass]
    public class AssemblyBrowserTest
    {
        AssemblyReader reader;
        List<Namespace> namespaces;

        [TestInitialize]
        public void Initialize()
        {
            const string path = @"..\..\TestDLL\Faker.dll";
            reader = new AssemblyReader();
            namespaces = reader.GetAssembly(path);
        }

        [TestMethod]
        public void TestNotNull()
        {
            Assert.IsNotNull(namespaces);
        }

        [TestMethod]
        public void TestNamespaceCount()
        {
            if (namespaces?.Count != 1)
            {
                Assert.Fail("count of namespaces  != 1");
            }           
        }

        [TestMethod]
        public void TestNamespaceName()
        {
            if (namespaces?.Count == 1)
            {
                Assert.AreEqual("Faker", namespaces[0].Name);
            }
            else
            {
                Assert.Fail("namespace[0] is not exists");
            }
        }

        [TestMethod]
        public void TestClassesCount()
        {
            if (namespaces[0].DataTypes.Count != 2)
            {
                Assert.Fail("classes count should be 2");
            }
        }

        [TestMethod]
        public void TestClassesName()
        {
            Assert.AreEqual("Faker", namespaces[0].DataTypes[0].Name);
            Assert.AreEqual("<>c__11`1", namespaces[0].DataTypes[1].Name);
        }

        [TestMethod]
        public void TestMethodsExistence()
        {
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods);

            Assert.IsTrue(namespaces[0].DataTypes[0].Methods.Count > 1);
        }

        [TestMethod]
        public void TestFieldsNotExistence()
        {
            Assert.IsTrue(namespaces[0].DataTypes[0].Fields.Count == 0);
        }

        [TestMethod]
        public void TestPropertyExistence()
        {
            Assert.IsNotNull(namespaces[0].DataTypes[0].Properties);
        }
    }
}
