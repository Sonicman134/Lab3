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
        List<string> playlist;
        Random rand = new Random();
        public void SetPlayList(string path)
        {
            playlist = Directory.GetFiles(path).ToList();
            for (int i = 0; i < playlist.Count; i++)
            {
                if (".mp3" != playlist[i].Substring(playlist[i].LastIndexOf('.')))
                {
                    playlist.RemoveAt(i);
                    i--;
                }
            }
        }
        public bool NextSong()
        {
            if (playlist.Count > 0)
            {
                int a = rand.Next(playlist.Count);
                SetSong(playlist[a]);
                playlist.RemoveAt(a);
                Play();
                return true;
            }
            else return false;
        }
        public List<string> GetPlayList()
        {
            return new List<string>(playlist);
        }
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
