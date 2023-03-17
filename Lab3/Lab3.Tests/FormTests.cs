using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab3.Tests
{
    [TestClass]
    public class FormTests
    {
        [TestMethod]
        public void Create()
        {
            Form1 form = new Form1();
            Assert.IsNotNull(form);
        }
    }
}
