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
        [TestMethod]
        public void PlayerAnswered4()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
        }
        [TestMethod]
        public void PlayerAnswered5()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "Somnus");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\The_Spirits_Converge.mp3", music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered6()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswered(0, "Somnus");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(0, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\Somnus.mp3", music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered7()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            game.PlayerAnswering(2);
            game.PlayerAnswered(2, "Somnus");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(1, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\The_Spirits_Converge.mp3", music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered8()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            game.PlayerAnswered(0, "Somnus");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
            Assert.AreEqual(2, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\Somnus.mp3", music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered9()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            game.PlayerAnswering(2);
            game.PlayerAnswered(2, "aaa");
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, "aaa");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(-1, pls[1].score);
            Assert.AreEqual(-1, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\The_Spirits_Converge.mp3", music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered10()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "Somnus");
            game.PlayerAnswering(2);
            game.PlayerAnswered(2, "aaa");
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, "The_Spirits_Converge");
            game.PlayerAnswering(1);
            bool f = game.PlayerAnswered(1, "Valse_di_Fantastica");
            MusicPlayer music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(1, pls[0].score);
            Assert.AreEqual(2, pls[1].score);
            Assert.AreEqual(-1, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(false, music.GetState());
            Assert.AreEqual(false, f);
        }
    }
}
