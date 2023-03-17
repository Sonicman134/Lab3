using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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
        [TestMethod]
        public void StartGame1()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            string s = Directory.GetCurrentDirectory() + "\\testMusic\\";
            Assert.AreEqual(s + "Somnus.mp3", music.GetSongURL());
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(0, pls[0].GetScore());
            Assert.AreEqual(0, pls[1].GetScore());
            Assert.AreEqual(0, pls[2].GetScore());
        }
    }
}
