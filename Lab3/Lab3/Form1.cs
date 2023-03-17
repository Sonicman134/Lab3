using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        Game game = new Game();
        List<Button> buttons = new List<Button>();
        List<TextBox> textBoxes = new List<TextBox>();
        List<Label> labels = new List<Label>();
        public Form1()
        {
            InitializeComponent();
            buttons.Add(Player1Button);
            buttons.Add(Player2Button);
            buttons.Add(Player3Button);
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        public void StartGame()
        {
            game.StartGame(startTextBox.Text);
            foreach (Label x in labels) x.Text = "0";
        }
        public int PlayerReaction(int pl)
        {
            Player player = game.GetPlayers()[pl];
            if (player.state == 0)
            {
                game.PlayerAnswering(pl);
                for (int i = 0; i < 3; i++)
                {
                    if (i != pl) buttons[i].Enabled = false;
                }
                return 0;
            }
            else if (player.state == 1)
            {
                if (game.PlayerAnswered(pl, textBoxes[pl].Text))
                {
                    List<Player> pls = game.GetPlayers();
                    for (int i = 0; i < 3; i++)
                    {
                        labels[i].Text = pls[i].score.ToString();
                        buttons[i].Enabled = true;
                    }
                    return 0;
                }
                else
                {
                    return game.GameEnd() + 1;
                }
            }
            else return 0;
        }
        public void SetStartTextBox(string path)
        {
            startTextBox.Text = path;
        }
        public void SetAnswer(int pl, string answer)
        {
            textBoxes[pl].Text = answer;
        }
        public Button GetStartButton()
        {
            return StartButton;
        }
        public List<Button> GetButtons()
        {
            return buttons;
        }
        public List<Label> GetLabels()
        {
            return labels;
        }

        private void Player1Button_Click(object sender, EventArgs e)
        {
            int a = PlayerReaction(0);
            if (a != 0)
            {
                MessageBox.Show(a + "Игрок победил");
            }
        }

        private void Player2Button_Click(object sender, EventArgs e)
        {
            int a = PlayerReaction(1);
            if (a != 0)
            {
                MessageBox.Show(a + "Игрок победил");
            }
        }

        private void Player3Button_Click(object sender, EventArgs e)
        {
            int a = PlayerReaction(2);
            if (a != 0)
            {
                MessageBox.Show(a + "Игрок победил");
            }
        }
    }
}
