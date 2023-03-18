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
        [TestMethod]
        public void PlayerReaction1()
        {
            Form1 form = new Form1();
            form.SetStartTextBox("testMusic");
            form.StartGame();
            form.PlayerReaction(1);
            List<Button> btns = form.GetButtons();
            List<Label> labels = form.GetLabels();
            Assert.AreEqual("0", labels[0].Text);
            Assert.AreEqual("0", labels[1].Text);
            Assert.AreEqual("0", labels[2].Text);
            Assert.AreEqual(false, btns[0].Enabled);
            Assert.AreEqual(true, btns[1].Enabled);
            Assert.AreEqual(false, btns[2].Enabled);
        }
        [TestMethod]
        public void PlayerReaction2()
        {
            Form1 form = new Form1();
            form.SetStartTextBox("testMusic");
            form.StartGame();
            form.PlayerReaction(1);
            form.SetAnswer(1, form.GetAnswer());
            form.PlayerReaction(1);
            form.PlayerReaction(2);
            form.SetAnswer(2, "aaa");
            form.PlayerReaction(2);
            List<Label> labels = form.GetLabels();
            Assert.AreEqual("0", labels[0].Text);
            Assert.AreEqual("1", labels[1].Text);
            Assert.AreEqual("-1", labels[2].Text);
        }
        [TestMethod]
        public void PlayerReaction3()
        {
            Form1 form = new Form1();
            form.SetStartTextBox("testMusic");
            form.StartGame();
            form.PlayerReaction(1);
            form.SetAnswer(1, form.GetAnswer());
            form.PlayerReaction(1);
            form.PlayerReaction(2);
            form.SetAnswer(2, form.GetAnswer());
            form.PlayerReaction(2);
            form.PlayerReaction(1);
            form.SetAnswer(1, form.GetAnswer());
            int a = form.PlayerReaction(1);
            Assert.AreEqual(2, a);
        }
    }
}
