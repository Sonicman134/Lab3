using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        [TestMethod]
        public void StartButton1()
        {
            Form1 form = new Form1();
            form.SetStartTextBox("testMusic");
            form.StartGame();
            List<Label> labels = form.GetLabels();
            Assert.AreEqual("0", labels[0].Text);
            Assert.AreEqual("0", labels[1].Text);
            Assert.AreEqual("0", labels[2].Text);
        }
    }
}
