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
        public bool PlayerAnswered(int pl, string answer)
        {
            if (playerAnswering == pl)
            {
                playerAnswering = -1;
                if (answer == musicPlayer.GetSong())
                {
                    players[pl].score++;
                    players[0].state = players[1].state = players[2].state = 0;
                    return musicPlayer.NextSong();
                }
                else
                {
                    players[pl].score--;
                    players[pl].state = 2;
                    if (players[0].state == 2 && players[1].state == 2 && players[2].state == 2)
                    {
                        players[0].state = players[1].state = players[2].state = 0;
                        return musicPlayer.NextSong();
                    }
                    else
                    {
                        musicPlayer.Play();
                        return true;
                    }
                }
            }
            else return true;
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
