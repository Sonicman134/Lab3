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
        int playerAnswering = -1; //-1 - никто не отвечает
        public void StartGame(string path)
        {
            musicPlayer.SetPlayList(path);
            players.Add(new Player());
            players.Add(new Player());
            players.Add(new Player());
            musicPlayer.NextSong();
        }
        public void PlayerAnswering(int pl)
        {
            players[pl].state = 1;
            musicPlayer.Stop();
            playerAnswering = pl;
        }
        public void PlayerAnswered(int pl, string answer)
        {
            if(playerAnswering == pl)
            {
                if (answer == musicPlayer.GetSong())
                {
                    players[pl].score++;
                    players[pl].state = 0;
                    musicPlayer.NextSong();
                }
                else 
                {
                    players[pl].score--;
                    players[pl].state = 0;
                    musicPlayer.Play();
                }
                playerAnswering = -1;
            }
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
