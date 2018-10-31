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
            namespaces = reader.LoadAssemblyTypes(path);
        }

        [TestMethod]
        public void TestNotNull()
        {
            Assert.IsNotNull(namespaces);
        }

        #region TestNamespaces

        [TestMethod]
        public void TestNamespaceCount()
        {
            Assert.AreEqual(namespaces?.Count, 1);
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

        #endregion

        #region TestClasses

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
        public void TestClassesProperties()
        {
            //Faker
            Assert.IsTrue(namespaces[0].DataTypes[0].IsPublic);
            Assert.IsFalse(namespaces[0].DataTypes[0].IsSealed);
            Assert.IsFalse(namespaces[0].DataTypes[0].IsInterface);
            Assert.IsTrue(namespaces[0].DataTypes[0].IsClass);
            Assert.IsFalse(namespaces[0].DataTypes[0].IsAbstract);

            //<>c__11`1
            Assert.IsFalse(namespaces[0].DataTypes[1].IsPublic);
            Assert.IsTrue(namespaces[0].DataTypes[1].IsSealed);
            Assert.IsFalse(namespaces[0].DataTypes[1].IsInterface);
            Assert.IsTrue(namespaces[0].DataTypes[1].IsClass);
            Assert.IsFalse(namespaces[0].DataTypes[1].IsAbstract);
        }

        #endregion

        #region TestMethods

        [TestMethod]
        public void TestMethodsExistence()
        {
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods);
            Assert.IsTrue(namespaces[0].DataTypes[0].Methods.Count > 1);

            Assert.IsNotNull(namespaces[0].DataTypes[1].Methods);
            Assert.IsTrue(namespaces[0].DataTypes[1].Methods.Count > 1);
        }

        [TestMethod]
        public void TestMethodsName()
        {
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "HaveToCreate"));
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "Create"));
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "AddToDict"));
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "RetrieveFromDict"));
            Assert.IsNotNull(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "ToString"));
        }

        [TestMethod]
        public void TestMethodsProperties()
        {
            Assert.IsFalse(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "HaveToCreate").IsFinal);
            Assert.IsTrue(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "HaveToCreate").IsPublic);
            Assert.IsFalse(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "HaveToCreate").IsStatic);
            Assert.IsFalse(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "HaveToCreate").IsVirtual);

            Assert.IsFalse(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "Create").IsFinal);
            Assert.IsTrue(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "Create").IsPublic);
            Assert.IsFalse(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "Create").IsStatic);
            Assert.IsFalse(namespaces[0].DataTypes[0].Methods.Find(x => x.Name == "Create").IsVirtual);
        }

        #endregion

        #region TestFields

        [TestMethod]
        public void TestFieldsNotExistence()
        {
            Assert.AreEqual(0, namespaces[0].DataTypes[0].Fields?.Count);
            Assert.AreEqual(2, namespaces[0].DataTypes[1].Fields?.Count);
        }

        #endregion

        #region TestProperties

        [TestMethod]
        public void TestPropertiesExistence()
        {
            Assert.IsNotNull(namespaces[0].DataTypes[0].Properties);
        }

        [TestMethod]
        public void TestPropertiesCount()
        {
            Assert.AreEqual(1, namespaces[0].DataTypes[0].Properties.Count);
            Assert.AreEqual(0, namespaces[0].DataTypes[1].Properties.Count);
        }

        [TestMethod]
        public void TestPropertiesName()
        {
            Assert.IsNotNull(namespaces[0].DataTypes[0].Properties.Find(x => x.Name == "maxRecursionLevel"));
        }

        [TestMethod]
        public void TestPropertiesProperties()
        {
            Assert.IsTrue(namespaces[0].DataTypes[0].Properties.Find(x => x.Name == "maxRecursionLevel").IsPublic);
            Assert.IsTrue(namespaces[0].DataTypes[0].Properties.Find(x => x.Name == "maxRecursionLevel").CanWrite);
            Assert.IsTrue(namespaces[0].DataTypes[0].Properties.Find(x => x.Name == "maxRecursionLevel").CanRead);
        }

        #endregion
    }
}
