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
using System.Reflection;
using ToHealth.DB;

namespace ToHealth
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string logins = Log.Text;
                string passwords = Password.Password;

                using (DBToHealth db = new DBToHealth())
                {
                    User user = db.Users.FirstOrDefault(p => p.login == logins);

                    if (user == null)
                    {
                        MessageBox.Show("");
                        return;
                    }
                    if (user.password == passwords)
                    {
                        User person = db.Users.FirstOrDefault(p => p.login == logins);

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        MainClass.ID = person.UserId;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void regisButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void LoginHidden(object sender, RoutedEventArgs e)
        {
            if (Log.Text == "Логин")
                Log.Text = "";
        }

        private void PasswordHidden(object sender, RoutedEventArgs e)
        { 
            if (Password.Password == "Пароль")
                Password.Password = "";
        }
    }
}
