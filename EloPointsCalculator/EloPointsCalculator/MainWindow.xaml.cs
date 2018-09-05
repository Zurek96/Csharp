using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EloPointsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Matchup
    {
        public Player player1;
        public Player player2;
        public bool isFinished;
        public string winner;

        public Matchup(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            isFinished = false;
        }

        public void setFinished()
        {
            isFinished = true;
        }
    }

    public class Turn
    {
        public int id;
        public List<Matchup> matchupList = new List<Matchup>();

        public Turn(int i)
        {
            id = i;
            if (matchupList.Count != 0)
            {
                matchupList.Clear();
            }
        }
    }
       

    public class Player
    {
        public int id;
        public string name;
        public int elo;
        public int achievementScore;
        public List<Player> matchList = new List<Player>();

        public Player(int i, string n, int e)
        {
            id = i;
            name = n;
            elo = e;
            achievementScore = 0;
        }

        public void AddMatchup(Player p)
        {
            matchList.Add(p);
        }
    }

    



    public partial class MainWindow : Window
    {
        public static List<Player> PlayerList = new List<Player>();
        public static List<Turn> League = new List<Turn>();
        public MainWindow()
        {
            InitializeComponent();
            string line;

            StreamReader reader = new StreamReader(@"players.txt");
            using (reader)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Player player = new Player(Convert.ToInt32(line.Split('/')[0]),line.Split('/')[1], Convert.ToInt32(line.Split('/')[2]));
                    PlayerList.Add(player);
                }
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int elo1, elo2,k;
            double p1, p2;
            System.FormatException comp = new FormatException();

            try
            {
                elo1 = int.Parse(Rating1.Text);
                elo2 = int.Parse(Rating2.Text);
                k = int.Parse(K.Text);

                p1 = Math.Pow(10, (elo1 / 400)) / (Math.Pow(10, (elo1 / 400)) + Math.Pow(10, (elo2 / 400)));
                p2 = Math.Pow(10, (elo2 / 400)) / (Math.Pow(10, (elo1 / 400)) + Math.Pow(10, (elo1 / 400)));

                if (Player1.IsChecked.Equals(true))
                {
                    elo1 = (int) Math.Round(elo1 + k * (1 - p1));
                    elo2 = (int) Math.Round(elo2 + k * (0 - p2));

                    MessageBox.Show("If player1 wins, the stats will be " + elo1 + " for player 1 and " + elo2 +
                                " for player 2");
                }
                else
                {
                    elo1 = (int)Math.Round(elo1 + k * (0 - p1));
                    elo2 = (int)Math.Round(elo2 + k * (1 - p2));

                    MessageBox.Show("If player2 wins, the stats will be " + elo1 + " for player 1 and " + elo2 +
                                " for player 2");
                }
            }
            catch (FormatException EXC)
            {
                    MessageBox.Show("Wrong input data type!");
            }
        }

        private void ControlPanel_Click(object sender, RoutedEventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.Show();
            this.Close();
        }
    }
}
