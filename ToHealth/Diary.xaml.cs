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
using ToHealth.DB;
using ToHealth.Therapy;

namespace ToHealth
{
    public partial class Diary : Window
    {
        public Diary()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DBToHealth db = new DBToHealth())
            {
                var userInfo = db.UserInfo.FirstOrDefault(p => p.UserId == MainClass.ID);
                userInfo.weight = int.Parse(Weight.Text);
                db.Entry(userInfo);
                db.SaveChanges();
            }

            MainClass.MW.frame.NavigationService.Navigate(new Uri("Therapy.xaml", UriKind.Relative));
            this.Close();
        }
    }
}
