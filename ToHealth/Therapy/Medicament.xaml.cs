using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Data;
using ToHealth.DB;

namespace ToHealth.Therapy
{
    public partial class Medicament : Page
    {
        public Medicament()
        {
            InitializeComponent();

            using (DBToHealth db = new DBToHealth())
            {
                var medicament = db.Medicaments;

                foreach (Medicaments p in medicament)
                {
                    listMed.Items.Add(p.medName);
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainClass.MW.frame.NavigationService.Navigate(new Uri("Pages/Therapy.xaml", UriKind.Relative));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reminders reminder = new Reminders();

                reminder.note = listMed.Text;
                reminder.dateStart = DateTime.Parse(dateStart_box.Text);
                reminder.dateFinish = DateTime.Parse(dateFinish_box.Text);
                reminder.time = DateTime.Parse(time_box.Text);

                reminder.UserId = MainClass.ID;

                using (DBToHealth db = new DBToHealth())
                {
                    db.Reminders.Add(reminder);
                    db.SaveChanges();
                }

                MessageBox.Show("Напоминание сохранено!");

                MainClass.MW.frame.NavigationService.Navigate(new Uri("Pages/Therapy.xaml", UriKind.Relative));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

