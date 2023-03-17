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
        string songName;
        public void Play()
        {
            if (songName != "")
            {
                player.controls.play();
                state = true;
            }
            else
            {
                state = false;
            }
        }
        public void Stop()
        {
            player.controls.pause();
            state = false;
        }
        public void SetSong(string song)
        {
            if (".mp3" == song.Substring(song.LastIndexOf('.')) && File.Exists(song))
            {
                player.URL = song;
                int a = song.LastIndexOf('\\');
                songName = song.Substring(a + 1, song.LastIndexOf('.') - a - 1);
            }
            else
            {
                player.URL = "";
                songName = "";
            }
        }
        public string GetSongURL()
        {
            return player.URL;
        }
        public string GetSong()
        {
            return songName;
        }
        public bool GetState()
        {
            return state;
        }
    }
}
