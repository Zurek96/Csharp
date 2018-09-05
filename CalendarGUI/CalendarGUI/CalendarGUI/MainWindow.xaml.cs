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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum DayOfTheWeek
    {
        Mon = 1,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat,
        Sun
    };

    enum MonthOfTheYear
    {
        Jan = 1,
        Feb,
        Mar,
        Apr,
        May,
        June,
        Jul,
        Aug,
        Sep,
        Oct,
        Nov,
        Dec
    }

    class Event
    {
        public int _id;
        public string Name;
        public DateTime _date;

        public Event(int id, string name, DateTime date)
        {
            _id = id;
            Name = name;
            _date = date;

        }

        public int GetId(Event ev)
        {
            return ev._id;
        }

        public void Print()
        {
            Console.Write("{0}---{1}---{2}", _id, Name, _date);
        }
    };

    class Day
    {
        public List<Event> EventList = new List<Event>();
        public DayOfTheWeek dayName;
        public int dayNumber;

        public Day(DayOfTheWeek name, int number)
        {
            dayName = name;
            dayNumber = number;
        }


        public void ShowDay(Day mDay)
        {
            Console.WriteLine(dayName);
            if (mDay.EventList.Count == 0) Console.Write("List is empty!");
            else
            {
                foreach (Event arg in mDay.EventList)
                {

                    Console.WriteLine(arg.GetId(arg) + " " + arg.Name);
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("");
        }
    }

    class Month
    {
        public List<Day> Days = new List<Day>();
        public MonthOfTheYear Name;
        public Day firstDay;
        public Day lastDay;

        public Month(MonthOfTheYear name)
        {
            Name = name;
            if (Name == MonthOfTheYear.Jan
                || Name == MonthOfTheYear.Mar
                || Name == MonthOfTheYear.May
                || Name == MonthOfTheYear.Jul
                || Name == MonthOfTheYear.Aug
                || Name == MonthOfTheYear.Oct
                || Name == MonthOfTheYear.Dec)
            {
                for (int i = 1; i <= 31; i++)
                {
                    if (i % 7 == 1) Days.Add(new Day(DayOfTheWeek.Mon, i));
                    if (i % 7 == 2) Days.Add(new Day(DayOfTheWeek.Tue, i));
                    if (i % 7 == 3) Days.Add(new Day(DayOfTheWeek.Wed, i));
                    if (i % 7 == 4) Days.Add(new Day(DayOfTheWeek.Thu, i));
                    if (i % 7 == 5) Days.Add(new Day(DayOfTheWeek.Fri, i));
                    if (i % 7 == 6) Days.Add(new Day(DayOfTheWeek.Sat, i));
                    if (i % 7 == 0) Days.Add(new Day(DayOfTheWeek.Sun, i));
                }

            }
            else
            {
                if (Name == MonthOfTheYear.Apr
                    || Name == MonthOfTheYear.June
                    || Name == MonthOfTheYear.Sep
                    || Name == MonthOfTheYear.Nov)
                {
                    for (int i = 1; i <= 30; i++)
                    {
                        if (i % 7 == 1) Days.Add(new Day(DayOfTheWeek.Mon, i));
                        if (i % 7 == 2) Days.Add(new Day(DayOfTheWeek.Tue, i));
                        if (i % 7 == 3) Days.Add(new Day(DayOfTheWeek.Wed, i));
                        if (i % 7 == 4) Days.Add(new Day(DayOfTheWeek.Thu, i));
                        if (i % 7 == 5) Days.Add(new Day(DayOfTheWeek.Fri, i));
                        if (i % 7 == 6) Days.Add(new Day(DayOfTheWeek.Sat, i));
                        if (i % 7 == 0) Days.Add(new Day(DayOfTheWeek.Sun, i));
                    }
                }
                else

                {
                    for (int i = 1; i <= 28; i++)
                    {
                        if (i % 7 == 1) Days.Add(new Day(DayOfTheWeek.Mon, i));
                        if (i % 7 == 2) Days.Add(new Day(DayOfTheWeek.Tue, i));
                        if (i % 7 == 3) Days.Add(new Day(DayOfTheWeek.Wed, i));
                        if (i % 7 == 4) Days.Add(new Day(DayOfTheWeek.Thu, i));
                        if (i % 7 == 5) Days.Add(new Day(DayOfTheWeek.Fri, i));
                        if (i % 7 == 6) Days.Add(new Day(DayOfTheWeek.Sat, i));
                        if (i % 7 == 0) Days.Add(new Day(DayOfTheWeek.Sun, i));
                    }

                }
            }

            firstDay = Days[0];
            lastDay = Days[Days.Count - 1];
        }

        public void PrintList(List<Day> list)
        {
            foreach (Day day in list)
            {
                Console.Write(day);
                Console.Write(" ");

            }
        }

        public void ShowMonth()
        {
            int flag = 0;
            List<Day> Monday = new List<Day>();
            List<Day> Tuesday = new List<Day>();
            List<Day> Wednesday = new List<Day>();
            List<Day> Thursday = new List<Day>();
            List<Day> Friday = new List<Day>();
            List<Day> Saturday = new List<Day>();
            List<Day> Sunday = new List<Day>();
            int iter = 0;
            Object[,] x = new Object[5, 7];
            Dictionary<string, List<Day>> Dict = new Dictionary<string, List<Day>>();
            for (int i = 0; i < Days.Count; i++)
            {
                if (Days[i].dayName == DayOfTheWeek.Mon) Monday.Add(Days[i]);
                if (Days[i].dayName == DayOfTheWeek.Tue) Tuesday.Add(Days[i]);
                if (Days[i].dayName == DayOfTheWeek.Wed) Wednesday.Add(Days[i]);
                if (Days[i].dayName == DayOfTheWeek.Thu) Thursday.Add(Days[i]);
                if (Days[i].dayName == DayOfTheWeek.Fri) Friday.Add(Days[i]);
                if (Days[i].dayName == DayOfTheWeek.Sat) Saturday.Add(Days[i]);
                if (Days[i].dayName == DayOfTheWeek.Sun) Sunday.Add(Days[i]);
            }

            Dict.Add("MON", Monday);
            Dict.Add("TUE", Tuesday);
            Dict.Add("WED", Wednesday);
            Dict.Add("THU", Thursday);
            Dict.Add("FRI", Friday);
            Dict.Add("SAT", Saturday);
            Dict.Add("SUN", Sunday);
            Console.WriteLine("----------");
            Console.WriteLine("| {0}", Name);
            foreach (KeyValuePair<string, List<Day>> kvp in Dict)
            {
                foreach (Day day in kvp.Value)
                {
                    if (flag == 0)
                    {
                        Console.Write("{0}  ", kvp.Key);
                        flag = 1;
                    }
                }

                flag = 0;
            }

            Console.WriteLine("----------");

        }

        public void AdjustMonth(DayOfTheWeek delayDay)
        {
            for (int i = 0; i < Days.Count; i++)
            {
                Days[i].dayName = (Days[i].dayName + Convert.ToInt32(delayDay));
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 0) Days[i].dayName = DayOfTheWeek.Sun;
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 1) Days[i].dayName = DayOfTheWeek.Mon;
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 2) Days[i].dayName = DayOfTheWeek.Tue;
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 3) Days[i].dayName = DayOfTheWeek.Wed;
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 4) Days[i].dayName = DayOfTheWeek.Thu;
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 5) Days[i].dayName = DayOfTheWeek.Fri;
                if ((Convert.ToInt32(Days[i].dayName) % 7) == 6) Days[i].dayName = DayOfTheWeek.Sat;
            }
        }

        public void AdjustMonth(Day delayDay)
        {
            for (int i = 0; i < Days.Count; i++)
            {
                var diff = Days[i].dayNumber - delayDay.dayNumber;
                if ((diff % 7) == 0) Days[i].dayName = delayDay.dayName;
                if ((diff % 7) == 1) Days[i].dayName = delayDay.dayName + 1;
                if ((diff % 7) == 2) Days[i].dayName = delayDay.dayName + 2;
                if ((diff % 7) == 3) Days[i].dayName = delayDay.dayName + 3;
                if ((diff % 7) == 4) Days[i].dayName = delayDay.dayName + 4;
                if ((diff % 7) == 5) Days[i].dayName = delayDay.dayName + 5;
                if ((diff % 7) == 6) Days[i].dayName = delayDay.dayName + 6;
            }
        }
    }

    class Year
    {
        public int Number;
        public List<Month> MonthList = new List<Month>();

        public Year(int number)
        {
            Number = number;
            MonthList.Add(new Month(MonthOfTheYear.Jan));
            MonthList.Add(new Month(MonthOfTheYear.Feb));
            MonthList.Add(new Month(MonthOfTheYear.Mar));
            MonthList.Add(new Month(MonthOfTheYear.Apr));
            MonthList.Add(new Month(MonthOfTheYear.May));
            MonthList.Add(new Month(MonthOfTheYear.June));
            MonthList.Add(new Month(MonthOfTheYear.Jul));
            MonthList.Add(new Month(MonthOfTheYear.Aug));
            MonthList.Add(new Month(MonthOfTheYear.Sep));
            MonthList.Add(new Month(MonthOfTheYear.Oct));
            MonthList.Add(new Month(MonthOfTheYear.Nov));
            MonthList.Add(new Month(MonthOfTheYear.Dec));
        }

        public void ShowYear()
        {

            for (int i = 0; i < MonthList.Count; i++)
            {
                MonthList[i].ShowMonth();
            }

        }
    }

    /*class Program
    {
        static void Main(string[] args)
        {
            int sendMail = 0;
            Day day = new Day(DayOfTheWeek.Tue, 1);
            Year year = new Year(2018);

            year.MonthList[0].AdjustMonth(day);

            for (int i = 1; i < year.MonthList.Count; i++)
            {
                year.MonthList[i].AdjustMonth(year.MonthList[i - 1].lastDay.dayName);
            }

            DateTime date = new DateTime(2018, 8, 1);
            Day day1 = new Day(DayOfTheWeek.Mon, 1);
            for (int i = 0; i < 20; i++)
            {
                Event ev = new Event(i, "event " + i, date.AddDays(i));
                day1.EventList.Add(ev);
            }

            day1.EventList.Clear();
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

                        Console.Write("{0} / {1} / {2} / This task is {3} days late", ev._id, ev.Name, ev._date,
                            diff.Days);
                        Console.WriteLine("");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("The list is empty!");
                Console.ReadKey();
            }

            /*if (sendMail == 1)
            {
                MailMessage mail = new MailMessage("mikolajzurowski@gmail.com", "mikolajzurowski@gmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("mikolajzurowski@gmail.com", "idfifgqqquemljps");
                client.Host = "smtp.gmail.com";
                mail.Subject = "test mail";
                mail.Body = "test mail";
                client.EnableSsl = true;

                client.Send(mail);
            }*/
        
    



public partial class MainWindow : Window
    {
        private int _id;
        private string name;
        private string date;
        public MainWindow()
        {
            InitializeComponent();
            pnlMainGrid.MouseUp += new MouseButtonEventHandler(pnlMainGrid_MouseUp);
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void button_submit(object sender, RoutedEventArgs e)
        {
            _id = int.Parse(TXB_1.Text);
            name = TXB_2.Text;
            date = TXB_3.Text;
            StreamWriter writer = new StreamWriter(@"C:\Users\MZurowsk\file.txt", true);
            using (writer)
            {
                writer.WriteLine("{0}|{1}|{2}", _id, name, date);
            }

            MessageBox.Show("Event submitted!");
        }

        private void Show_click(object sender, RoutedEventArgs e)
        {
            EventsList win2 = new EventsList();
            win2.Show();
            
        }

        private void Clear_click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"C:\Users\MZurowsk\file.txt", String.Empty);
            MessageBox.Show("Event list cleared!");
        }
    }
}
