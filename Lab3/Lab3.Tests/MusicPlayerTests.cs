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
    public class MusicPlayerTests
    {
        [TestMethod]
        public void Create()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            Assert.IsNotNull(musicPlayer);
        }
        [TestMethod]
        public void Play1()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetSong("testMusic\\Somnus.mp3");
            musicPlayer.Play();
            Assert.AreEqual(true, musicPlayer.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\Somnus.mp3", musicPlayer.GetSongURL());
        }
        [TestMethod]
        public void Play2()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetSong("testMusic\\The_Spirits_Converge.mp3");
            musicPlayer.Play();
            Assert.AreEqual(true, musicPlayer.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\The_Spirits_Converge.mp3", musicPlayer.GetSongURL());
        }
        [TestMethod]
        public void Play3()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetSong("testMusic\\aaaaa.jpg");
            musicPlayer.Play();
            Assert.AreEqual(false, musicPlayer.GetState());
            Assert.AreEqual("", musicPlayer.GetSongURL());
        }
        [TestMethod]
        public void Play4()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetSong("notExists.mp3");
            musicPlayer.Play();
            Assert.AreEqual(false, musicPlayer.GetState());
            Assert.AreEqual("", musicPlayer.GetSongURL());
        }
        [TestMethod]
        public void Stop1()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetSong("testMusic\\The_Spirits_Converge.mp3");
            musicPlayer.Play();
            musicPlayer.Stop();
            Assert.AreEqual(false, musicPlayer.GetState());
        }
        [TestMethod]
        public void Stop2()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Stop();
            Assert.AreEqual(false, musicPlayer.GetState());
        }
        [TestMethod]
        public void SetSong1()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetSong("testMusic\\Somnus.mp3");
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\Somnus.mp3", musicPlayer.GetSongURL());
            Assert.AreEqual("Somnus", musicPlayer.GetSong());
        }
        [TestMethod]
        public void PlayList1()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetPlayList("testMusic");
            string s = "testMusic\\";
            List<string> pl = new List<string>();
            pl.Add(s + "Somnus.mp3");
            pl.Add(s + "The_Spirits_Converge.mp3");
            pl.Add(s + "Valse_di_Fantastica.mp3");
            CollectionAssert.AreEqual(pl, musicPlayer.GetPlayList());
        }
        [TestMethod]
        public void PlayList2()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.SetPlayList("testMusic");
            string s = Directory.GetCurrentDirectory() + "\\testMusic\\";
            List<string> songs = new List<string>();
            songs.Add(s + "Somnus.mp3");
            songs.Add(s + "The_Spirits_Converge.mp3");
            songs.Add(s + "Valse_di_Fantastica.mp3");
            musicPlayer.NextSong();
            Assert.AreEqual(true, songs.Exists(x => x == musicPlayer.GetSongURL()));
            Assert.AreEqual(true, musicPlayer.GetState());
            songs.Remove(musicPlayer.GetSongURL());
            musicPlayer.NextSong();
            Assert.AreEqual(true, songs.Exists(x => x == musicPlayer.GetSongURL()));
            Assert.AreEqual(true, musicPlayer.GetState());
            songs.Remove(musicPlayer.GetSongURL());
            musicPlayer.NextSong();
            Assert.AreEqual(true, songs.Exists(x => x == musicPlayer.GetSongURL()));
            Assert.AreEqual(true, musicPlayer.GetState());
            songs.Remove(musicPlayer.GetSongURL());
        }
    }
}
