using System;
using System.Collections.Generic;
using System.IO;
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
        public void Play(string song)
        {
            if (".mp3" == song.Substring(song.LastIndexOf('.')) && File.Exists(song))
            {
                player.URL = song;
                player.controls.play();
                state = true;
            }
            else
            {
                player.URL = "";
                state = false;
            }
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
