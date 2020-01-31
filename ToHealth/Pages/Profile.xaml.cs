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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToHealth.DB;

namespace ToHealth.Pages
{
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            
            using (DBToHealth db = new DBToHealth())
            {
                UserInfo userInfo = db.UserInfo.FirstOrDefault(p=>p.UserId == MainClass.ID);

                name.Text = userInfo.name;
                email.Text = userInfo.email;
                bday.Text = userInfo.bday.ToShortDateString();
                gender.Text = userInfo.gender;
                height.Text = userInfo.height.ToString();
                weight.Text = userInfo.weight.ToString();
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            MainClass.MW.Close();
        }
    }
}
