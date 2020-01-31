using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using ToHealth.DB;
using ToHealth.Pages;
using ToHealth.Therapy;

namespace ToHealth.Pages
{
    public partial class Therapy : Page
    {
        Diary d = new Diary();

        public Therapy()
        {
            InitializeComponent();
        }

        private void PageAdd_Click(object sender, RoutedEventArgs e)
        {
            MainClass.MW.frame.NavigationService.Navigate(new Uri("Therapy/Medicament.xaml", UriKind.Relative));
        }

        private void Diary_Click(object sender, RoutedEventArgs e)
        {                     
            d.Show();
        }
    }
}
