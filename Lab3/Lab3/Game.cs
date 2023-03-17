using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Game
    {
        List<Player> players = new List<Player>();
        MusicPlayer musicPlayer = new MusicPlayer();
        public void StartGame(string path)
        {
            musicPlayer.SetPlayList(path);
            players.Add(new Player());
            players.Add(new Player());
            players.Add(new Player());
            musicPlayer.NextSong();
        }
        public MusicPlayer GetMusicPlayer()
        {
            return musicPlayer;
        }
        public List<Player> GetPlayers()
        {
            return new List<Player>(players);
        }
    }
}
