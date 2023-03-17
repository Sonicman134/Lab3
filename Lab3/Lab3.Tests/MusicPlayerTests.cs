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
            musicPlayer.Play("testMusic\\Somnus.mp3");
            Assert.AreEqual(true, musicPlayer.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\Somnus.mp3", musicPlayer.GetSong());
        }
        [TestMethod]
        public void Play2()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play("testMusic\\The_Spirits_Converge.mp3");
            Assert.AreEqual(true, musicPlayer.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\The_Spirits_Converge.mp3", musicPlayer.GetSong());
        }
        [TestMethod]
        public void Play3()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play("aaaaa.jpg");
            Assert.AreEqual(false, musicPlayer.GetState());
            Assert.AreEqual("", musicPlayer.GetSong());
        }
        [TestMethod]
        public void Play4()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play("notExists.mp3");
            Assert.AreEqual(false, musicPlayer.GetState());
            Assert.AreEqual("", musicPlayer.GetSong());
        }
        [TestMethod]
        public void Stop1()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play("testMusic\\The_Spirits_Converge.mp3");
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
    }
}
