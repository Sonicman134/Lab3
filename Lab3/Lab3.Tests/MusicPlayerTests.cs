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
            musicPlayer.Play();
            Assert.AreEqual(true, musicPlayer.GetState());
            Assert.AreEqual(Directory.GetCurrentDirectory() + "\\testMusic\\Somnus.mp3", musicPlayer.GetSong());
        }
        [TestMethod]
        public void Stop1()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play();
            musicPlayer.Stop();
            Assert.AreEqual(false, musicPlayer.GetState());
        }
    }
}
