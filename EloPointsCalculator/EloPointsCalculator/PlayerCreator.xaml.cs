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
    /// Interaction logic for PlayerCreator.xaml
    /// </summary>
    public partial class PlayerCreator : Window
    {
        public PlayerCreator()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            PlayerCreator pc = new PlayerCreator();
            int id, elo;
            string name;
            try
            {
                id = int.Parse(IDBox.Text);
                name = NameBox.Text;
                elo = int.Parse(ELOBox.Text);

                Player player = new Player(id, name, elo);
                MainWindow.PlayerList.Add(player);
                MessageBox.Show("Submitted!");
                this.Close();
                pc.Close();
            }
            catch (FormatException EXC)
            {
                MessageBox.Show("Wrong input data type!");
            }
        }
    }
}
