using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Create()
        {
            Game game = new Game();
            Assert.IsNotNull(game);
        }
    }
}
