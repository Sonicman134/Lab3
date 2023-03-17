using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Lab3
{
    public class MusicPlayer
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        bool state = false; //Музыка играет - true, иначе - false
        public void Play()
        {
            player.URL = "testMusic\\Somnus.mp3";
            player.controls.play();
            state = true;
        }
        public void Stop()
        {
            player.controls.pause();
            state = false;
        }
        public string GetSong()
        {
            return player.URL;
        }
        public bool GetState()
        {
            return state;
        }
    }
}
