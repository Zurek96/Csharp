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
    /// Interaction logic for PlayerPicker.xaml
    /// </summary>
    public partial class PlayerPicker : Window
    {
        public PlayerPicker()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                id = int.Parse(IdPicker.Text);
                var file = new List<string>(System.IO.File.ReadAllLines(@"players.txt"));
                file.RemoveAt(id - 1);
                File.WriteAllLines(@"players.txt", file.ToArray());
                MessageBox.Show("Player " + id + " deleted!");
                this.Close();
            }
            catch (ArgumentOutOfRangeException exc)
            {

                MessageBox.Show("That player doesn't exist!");
            }
            catch (FormatException exc)
            {
                MessageBox.Show("Wrong input format!");
            }
        }
    }
}
