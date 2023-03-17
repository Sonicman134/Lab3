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
            Assert.AreEqual(0, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
        }
        [TestMethod]
        public void PlayerAnswering1()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(1);
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(false, music.GetState());
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(1, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
        }
        [TestMethod]
        public void PlayerAnswered1()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, "Somnus");
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(0, pls[0].score);
            Assert.AreEqual(1, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
        }
        [TestMethod]
        public void PlayerAnswered2()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, "aaa");
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(0, pls[0].score);
            Assert.AreEqual(-1, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
        }
        [TestMethod]
        public void PlayerAnswered3()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(1);
            game.PlayerAnswered(2, "aaa");
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(1, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(0, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
        }
    }
}
