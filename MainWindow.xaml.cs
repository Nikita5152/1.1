using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PR1.C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[] Block = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
        private const string name_Button = "GameButton";
        private bool start_game;
        private char Xor0 = 'X';
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = Xor0;
            (sender as Button).IsEnabled = false;
            CheckWin(sender as Button);
            ChengeXor0();
            for (int i = 0; i < 9 && start_game; i++)
            {
                if (Block[i] != 'Х' && Block[i] != '0')
                {
                    Bot();
                    break;
                }
            }
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (start_game)
            {
                start_game = false;
                Text.Text = "ИГРЕ КОНЕЦ";
                (sender as Button).Content = "НАЧАТЬ";
                ClearBlock();
            }
            else
            {
                start_game = true;
                Text.Text = "ВЫ В ИГРЕ";
                (sender as Button).Content = "ЗАВЕРШИТЬ";
                ClearBlock();
            }
        }
        private void Bot()
        {
            Random rand = new Random();
            var button = (Button)FindName(name_Button + rand.Next(8));
            if (button.IsEnabled)
            {
                button.Content = Xor0;
                button.IsEnabled = false;
                CheckWin(button);
                ChengeXor0();
            }
            else
            {
                Bot();
            }
        }
        private void ChengeXor0()
        {
            if (Xor0 == 'X') Xor0 = '0';
            else Xor0 = 'X';
        }
        private void CheckWin(Button button)
        {
            int x = button.Name.Last() - '0';
            Block[x] = Xor0;
            Garizontal(x);
            if (start_game)
            {
                Vertical(x);
                if (start_game)
                {
                    Diagonal(x);
                    if (start_game)
                    {
                        int score = 0;
                        foreach (var element in Block)
                        {
                            if (element != ' ')
                            {
                                score++;
                            }
                            if (score == 9)
                            {
                                StartGame_Click(StartGame, null);
                                Text.Text = "НИЧЬЯ ";
                            }
                        }
                    }
                }
            }
        }
        private void ClearBlock()
        {
            for (int i = 0; i < 9; i++)
            {
                if (start_game)
                {
                    var Button = (Button)FindName(name_Button + i);
                    Button.IsEnabled = true;
                }
                else
                {
                    var Button = (Button)FindName(name_Button + i);
                    Button.IsEnabled = false;
                    Button.Content = null;
                    Block = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
                }
            }
        }
        private void Garizontal(int x)
        {
            if (x <= 2 && x >= 0)
            {
                if (Block[0] == Block[1] && Block[0] == Block[2])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
            else if (x <= 5 && x >= 3)
            {
                if (Block[3] == Block[4] && Block[3] == Block[5])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
            else
            {
                if (Block[8] == Block[7] && Block[6] == Block[8])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
        }
        private void Vertical(int x)
        {
            if (x == 3 || x == 6 || x == 0)
            {
                if (Block[3] == Block[0] && Block[3] == Block[6])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
            else if (x == 1 || x == 4 || x == 7)
            {
                if (Block[1] == Block[4] && Block[1] == Block[7])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
            else
            {
                if (Block[2] == Block[5] && Block[2] == Block[8])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
        }
        private void Diagonal(int x)
        {
            if (x == 0 || x == 4 || x == 8)
            {
                if (Block[0] == Block[4] && Block[0] == Block[8])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
            else if (x == 2 || x == 4 || x == 6)
            {
                if (Block[2] == Block[4] && Block[2] == Block[6])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "ПОБЕДА " + Xor0;
                }
            }
        }
    }
}