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
            List<string> songs = new List<string>();
            songs.Add(s + "Somnus.mp3");
            songs.Add(s + "The_Spirits_Converge.mp3");
            songs.Add(s + "Valse_di_Fantastica.mp3");
            Assert.AreEqual(true, songs.Exists(x => x == music.GetSongURL()));
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
            MusicPlayer music = game.GetMusicPlayer();
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, music.GetSong());
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
            MusicPlayer music = game.GetMusicPlayer();
            string firstSong = music.GetSong();
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, firstSong);
            music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            string s = Directory.GetCurrentDirectory() + "\\testMusic\\";
            List<string> songs = new List<string>();
            songs.Add(s + "Somnus.mp3");
            songs.Add(s + "The_Spirits_Converge.mp3");
            songs.Add(s + "Valse_di_Fantastica.mp3");
            Assert.AreEqual(true, songs.Exists(x => x == music.GetSongURL()));
            Assert.AreNotEqual(firstSong, music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered6()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            MusicPlayer music = game.GetMusicPlayer();
            string url = music.GetSongURL();
            game.PlayerAnswered(0, music.GetSong());
            music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(0, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(url, music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered7()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            MusicPlayer music = game.GetMusicPlayer();
            string firstSong = music.GetSong();
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            game.PlayerAnswering(2);
            game.PlayerAnswered(2, firstSong);
            music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(1, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            string s = Directory.GetCurrentDirectory() + "\\testMusic\\";
            List<string> songs = new List<string>();
            songs.Add(s + "Somnus.mp3");
            songs.Add(s + "The_Spirits_Converge.mp3");
            songs.Add(s + "Valse_di_Fantastica.mp3");
            Assert.AreEqual(true, songs.Exists(x => x == music.GetSongURL()));
            Assert.AreNotEqual(firstSong, music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered8()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            MusicPlayer music = game.GetMusicPlayer();
            string url = music.GetSongURL();
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            game.PlayerAnswered(0, music.GetSong());
            music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(0, pls[1].score);
            Assert.AreEqual(0, pls[2].score);
            Assert.AreEqual(2, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            Assert.AreEqual(url, music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered9()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            MusicPlayer music = game.GetMusicPlayer();
            string firstSong = music.GetSong();
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, "aaa");
            game.PlayerAnswering(2);
            game.PlayerAnswered(2, "aaa");
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, "aaa");
            music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(-1, pls[0].score);
            Assert.AreEqual(-1, pls[1].score);
            Assert.AreEqual(-1, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(true, music.GetState());
            string s = Directory.GetCurrentDirectory() + "\\testMusic\\";
            List<string> songs = new List<string>();
            songs.Add(s + "Somnus.mp3");
            songs.Add(s + "The_Spirits_Converge.mp3");
            songs.Add(s + "Valse_di_Fantastica.mp3");
            Assert.AreEqual(true, songs.Exists(x => x == music.GetSongURL()));
            Assert.AreNotEqual(firstSong, music.GetSongURL());
        }
        [TestMethod]
        public void PlayerAnswered10()
        {
            Game game = new Game();
            game.StartGame("testMusic");
            MusicPlayer music = game.GetMusicPlayer();
            game.PlayerAnswering(0);
            game.PlayerAnswered(0, music.GetSong());
            game.PlayerAnswering(2);
            game.PlayerAnswered(2, "aaa");
            game.PlayerAnswering(1);
            game.PlayerAnswered(1, music.GetSong());
            game.PlayerAnswering(1);
            bool f = game.PlayerAnswered(1, music.GetSong());
            music = game.GetMusicPlayer();
            List<Player> pls = game.GetPlayers();
            Assert.AreEqual(1, pls[0].score);
            Assert.AreEqual(2, pls[1].score);
            Assert.AreEqual(-1, pls[2].score);
            Assert.AreEqual(0, pls[0].state);
            Assert.AreEqual(0, pls[1].state);
            Assert.AreEqual(0, pls[2].state);
            Assert.AreEqual(false, music.GetState());
            Assert.AreEqual(false, f);
            Assert.AreEqual(1, game.GameEnd());
        }
    }
}
