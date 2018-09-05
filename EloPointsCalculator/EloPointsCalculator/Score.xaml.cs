using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EloPointsCalculator
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        public Score()
        {
            InitializeComponent();
        }

        private void SubmitScore_Click(object sender, RoutedEventArgs e)
        {
            string winner, loser;
            int k=30;
            winner = Player1.Text;
            loser = Player2.Text;


            for (int i = 0; i < MainWindow.League[MainWindow.League.Count-1].matchupList.Count; i++)
            {
                if (MainWindow.League[MainWindow.League.Count-1].matchupList[i].player1.name == winner &&
                    MainWindow.League[MainWindow.League.Count-1].matchupList[i].player2.name == loser)
                {
                    int elo1 = MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player1.elo;
                    int elo2 = MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player2.elo;

                    double p1 = Math.Pow(10, (elo1 / 400)) / (Math.Pow(10, (elo1 / 400)) + Math.Pow(10, (elo2 / 400)));
                    double p2 = Math.Pow(10, (elo2 / 400)) / (Math.Pow(10, (elo1 / 400)) + Math.Pow(10, (elo1 / 400)));

                    elo1 = (int)Math.Round(elo1 + k * (1 - p1));
                    elo2 = (int)Math.Round(elo2 + k * (0 - p2));

                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player1.elo = elo1;
                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player2.elo = elo2;

                    MainWindow.League[MainWindow.League.Count-1].matchupList[i].setFinished();
                    MainWindow.League[MainWindow.League.Count-1].matchupList[i].winner = winner;

                }

                if (MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player1.name == loser &&
                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player2.name == winner)
                {
                    int elo1 = MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player1.elo;
                    int elo2 = MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player2.elo;

                    double p1 = Math.Pow(10, (elo1 / 400)) / (Math.Pow(10, (elo1 / 400)) + Math.Pow(10, (elo2 / 400)));
                    double p2 = Math.Pow(10, (elo2 / 400)) / (Math.Pow(10, (elo1 / 400)) + Math.Pow(10, (elo1 / 400)));

                    elo1 = (int)Math.Round(elo1 + k * (0 - p1));
                    elo2 = (int)Math.Round(elo2 + k * (1 - p2));

                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player1.elo = elo1;
                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].player2.elo = elo2;

                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].setFinished();
                    MainWindow.League[MainWindow.League.Count - 1].matchupList[i].winner = winner;
                }
            }
            this.Close();
        }
    }
}
