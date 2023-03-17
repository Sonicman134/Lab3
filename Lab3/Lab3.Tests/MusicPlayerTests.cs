using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass]
    public class MusicPlayerTests
    {
        [TestMethod]
        public void Create()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            Assert.IsNotNull(musicPlayer);
        }
    }
}
