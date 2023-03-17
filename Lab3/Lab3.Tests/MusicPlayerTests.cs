﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            musicPlayer.SetSong("aaaaa.jpg");
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
    }
}
