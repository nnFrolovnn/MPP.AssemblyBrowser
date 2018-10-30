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
        private void Init()
        {
            const string path = @"D:\учеба\5 семестр\СПП\Faker\Faker\bin\Debug\Faker.dll";
            reader = new AssemblyReader();
            namespaces = reader.GetAssembly(path);
        }

        [TestMethod]
        public void TestMethod1()
        {
                Assert.IsNotNull(namespaces);
        }
    }
}
