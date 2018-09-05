using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CalendarGUI
{
    /// <summary>
    /// Interaction logic for EventsList.xaml
    /// </summary>
    public partial class EventsList : Window
    {
        public EventsList()
        {
            InitializeComponent();
        }


        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Process viewer = new Process();
            viewer.StartInfo.FileName = @"C:\Users\MZurowsk\Calendar\Calendar\bin\Debug\Calendar.exe";
            viewer.Start();
        }

        private void ListView_ContextMenuOpening(object sender, EventArgs e)
        {
            Day day1 = new Day(DayOfTheWeek.Mon, 1);
            StreamReader reader = new StreamReader(@"C:\Users\MZurowsk\file.txt");
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Event ev = new Event(Convert.ToInt32(line.Split('|')[0]), line.Split('|')[1],
                        Convert.ToDateTime(line.Split('|')[2]));
                    day1.EventList.Add(ev);

                }
            }

            if (day1.EventList.Count != 0)
            {
                foreach (Event ev in day1.EventList)
                {
                    if (ev._date <= DateTime.Now)
                    {
                        var diff = DateTime.Now - ev._date;
                        ListView.
                        ListView.Write("{0} / {1} / {2} / This task is {3} days late", ev._id, ev.Name, ev._date,
                            diff.Days);
                        Console.WriteLine("");
                        Console.Read();
                    }
                }
            }
            else
            {
                Console.WriteLine("The list is empty!");
                Console.ReadKey();
            }
        }
    }
}
