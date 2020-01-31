using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Reflection;
using Hardcodet.Wpf.TaskbarNotification;
using ToHealth.DB;
using ToHealth.Pages;
using ToHealth.Therapy;

namespace ToHealth
{
    public partial class MainWindow : Window
    {

        DateTime dt = DateTime.Parse(DateTime.Now.ToShortDateString());

        private static Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            MainClass.MW = this;

            frame.NavigationService.Navigate(new Uri("Pages/Today.xaml", UriKind.Relative));

            timer = new System.Timers.Timer();
            timer.Interval = 30000;
            timer.Elapsed += Timer_ElapsedAsync;
            timer.Start();
        }

        private async void Timer_ElapsedAsync(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                using (DBToHealth db = new DBToHealth())
                {

                    var reminders = db.Reminders.Where(p => p.UserId == MainClass.ID && p.fulfillment == 0).OrderBy(p => p.time);
                    reminders.First();

                    foreach (Reminders p in reminders)
                    {
                        if ((DateTime.Parse(p.dateStart.ToShortDateString()) <= dt) && (dt <= DateTime.Parse(p.dateFinish.ToShortDateString())))
                        {
                            DateTime now = DateTime.Parse(DateTime.Now.ToShortTimeString());

                            if (DateTime.Parse(p.time.ToShortTimeString()) == now)
                            {
                                if (MessageBox.Show(p.note, "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                {
                                    var reminder = db.Reminders.Find(p.RemindersId);
                                    reminder.fulfillment = -1;

                                    db.Entry(reminder).State = System.Data.Entity.EntityState.Modified;

                                    MessageBox.Show("Не выполнено!");
                                    
                                    break;
                                }
                                else
                                {
                                    var reminder = db.Reminders.Find(p.RemindersId);
                                    reminder.fulfillment = 1;

                                    db.Entry(reminder).State = System.Data.Entity.EntityState.Modified;

                                    MessageBox.Show("Выполнено!");
                                    
                                    break;                                  
                                }
                            }
                        }
                    }
                    await db.SaveChangesAsync();
                    Timer_ElapsedAsync(sender, e);
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
       
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;  // = sender as Button;

            switch ((string)button.Content)
            {
                case "Сегодня":
                    frame.NavigationService.Navigate(new Uri("Pages/Today.xaml", UriKind.Relative));
                    break;
                case "Лечение":
                    frame.NavigationService.Navigate(new Uri("Pages/Therapy.xaml", UriKind.Relative));
                    break;
                case "Журнал":
                    frame.NavigationService.Navigate(new Uri("Pages/Journal.xaml", UriKind.Relative));
                    break;
                case "Профиль":
                    frame.NavigationService.Navigate(new Uri("Pages/Profile.xaml", UriKind.Relative));
                    break;
                case "О нас":
                    frame.NavigationService.Navigate(new Uri("Pages/AboutUs.xaml", UriKind.Relative));
                    break;
            }
        }
    }
}
