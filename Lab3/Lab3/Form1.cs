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
            label2.Text = "0";
            foreach (Label x in labels) x.Text = "0";
        }
        public void SetStartTextBox(string path)
        {
            startTextBox.Text = path;
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
    }
}
