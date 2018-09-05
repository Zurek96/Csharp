using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerCreator pc = new PlayerCreator();
            pc.Show();
        }


        private void AddResult_Click(object sender, RoutedEventArgs e)
        {
            Score sc = new Score();
            sc.Show();
        }

        private void ControlPanel2_Activated(object sender, EventArgs e)
        {
            List<Player> list = new List<Player>();
            list = MainWindow.PlayerList;
            Tb1.Text = "";
            Tb1_Copy.Text = "";
            Tb1_Copy1.Text = "";
            Tb1_Copy2.Text = "";
            TurnTB.Text = "";
            PairingTB.Text = "";
            StatusTB.Text = "";
            ResultTB.Text = "";
            foreach (var elem in list)
            {
                Tb1.Text = Tb1.Text + elem.id + '\n';
                Tb1_Copy.Text = Tb1_Copy.Text + elem.name + '\n';
                Tb1_Copy1.Text = Tb1_Copy1.Text + elem.elo + '\n';
                Tb1_Copy2.Text = Tb1_Copy2.Text + elem.achievementScore + '\n';
            }
            for (int i = 0; i < MainWindow.League.Count; i++)
            {
                for (int j = 0; j < MainWindow.League[i].matchupList.Count; j++)
                {
                    TurnTB.Text = TurnTB.Text + (MainWindow.League[i].id + 1) + '\n';
                    PairingTB.Text = PairingTB.Text + MainWindow.League[i].matchupList[j].player1.name + " - " +
                                     MainWindow.League[i].matchupList[j].player2.name + '\n';
                    StatusTB.Text = StatusTB.Text + MainWindow.League[i].matchupList[j].isFinished + '\n';
                    if (!MainWindow.League[i].matchupList[j].isFinished)
                    {
                        ResultTB.Text = ResultTB.Text + "Not finished" + '\n';
                    }
                    else
                    {
                        ResultTB.Text = ResultTB.Text + MainWindow.League[i].matchupList[j].winner + '\n';
                    }
                }
            }
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerPicker pp = new PlayerPicker();
            pp.Show();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"players.txt", String.Empty);
            MessageBox.Show("Event list cleared!");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter(@"players.txt");
            using (writer)
            {
                foreach (var elem in MainWindow.PlayerList)
                {
                    writer.WriteLine("{0}/{1}/{2}/{3}",elem.id.ToString(),elem.name,elem.elo.ToString(),elem.achievementScore.ToString());
                }
            }
            StreamWriter writer1 = new StreamWriter(@"data.txt", true);
            using (writer1)
            {
                foreach (var elem in MainWindow.League)
                {
                    writer1.WriteLine("{0} : {1} - {2}",elem.id,elem.matchupList[elem.id].player1.name, elem.matchupList[elem.id].player2.name);
                }
            }
            MessageBox.Show("Changes saved");
        }

        private void Pairings_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.PlayerList.Count < 1)
            {
                MessageBox.Show("Not enough players in the league!");
            }
            else
            {
                List<Player> list = MainWindow.PlayerList;
                for (int i = 0; i < list.Count-1; i++)
                {
                    Player value = list[1];
                    list.RemoveAt(1);
                    list.Add(value);
                    for (int j = 0; j < list.Count - 1; j+=2)
                    {
                        Matchup m = new Matchup(list[j], list[j + 1]);
                        if (!MainWindow.League[MainWindow.League.Count - 1].matchupList.Contains(m))
                        {
                            MainWindow.League[MainWindow.League.Count - 1].matchupList.Add(m);
                        }
                    }
                }
                MessageBox.Show("Pairings created");
            }

        }

        private void Turns_Click(object sender, RoutedEventArgs e)
        {
            int count = MainWindow.League.Count;
            Turn t1 = new Turn(count++);
            MainWindow.League.Add(t1);
            MessageBox.Show("Turn "+ count +" added!");
        }

        private void ControlPanel2_Initialized(object sender, EventArgs e)
        {

        }

        private void ControlPanel2_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            List<Player> list = new List<Player>();
            list = MainWindow.PlayerList;
            Tb1.Text = "";
            Tb1_Copy.Text = "";
            Tb1_Copy1.Text = "";
            Tb1_Copy2.Text = "";
            TurnTB.Text = "";
            PairingTB.Text = "";
            StatusTB.Text = "";
            ResultTB.Text = "";
            foreach (var elem in list)
            {
                Tb1.Text = Tb1.Text + elem.id + '\n';
                Tb1_Copy.Text = Tb1_Copy.Text + elem.name + '\n';
                Tb1_Copy1.Text = Tb1_Copy1.Text + elem.elo + '\n';
                Tb1_Copy2.Text = Tb1_Copy2.Text + elem.achievementScore + '\n';
            }
            for (int i = 0; i < MainWindow.League.Count; i++)
            {
                for (int j = 0; j < MainWindow.League[i].matchupList.Count; j++)
                {
                    TurnTB.Text = TurnTB.Text + (MainWindow.League[i].id + 1) + '\n';
                    PairingTB.Text = PairingTB.Text + MainWindow.League[i].matchupList[j].player1.name + " - " +
                                     MainWindow.League[i].matchupList[j].player2.name + '\n';
                    StatusTB.Text = StatusTB.Text + MainWindow.League[i].matchupList[j].isFinished + '\n';
                    if (!MainWindow.League[i].matchupList[j].isFinished)
                    {
                        ResultTB.Text = ResultTB.Text + "Not finished" + '\n';
                    }
                    else
                    {
                        ResultTB.Text = ResultTB.Text + MainWindow.League[i].matchupList[j].winner + '\n';
                    }
                }
            }
        }
    }
}
