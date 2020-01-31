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

namespace ToHealth
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();

                user.login = box_nick.Text;
                user.password = box_password.Password;

                UserInfo userInfo = new UserInfo();

                userInfo.name = box_name.Text;
                userInfo.email = box_email.Text;
                userInfo.bday = DateTime.Parse(box_bday.Text);
                userInfo.gender = box_gender.Text;
                userInfo.height = int.Parse(box_height.Text);
                userInfo.weight = int.Parse(box_weight.Text);

                user.userInfo = userInfo;


                using (DBToHealth db = new DBToHealth())
                {
                    db.Users.Add(user);
                    db.UserInfo.Add(userInfo);
                    db.SaveChanges();
                }

                MessageBox.Show("Вы зарегистрированы!");

                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoginHidden(object sender, RoutedEventArgs e)
        {
            if (box_nick.Text == "Логин")
                box_nick.Text = "";
        }

        private void PasswordHidden(object sender, RoutedEventArgs e)
        {
            if (box_password.Password == "Пароль")
                box_password.Password = "";
        }

        private void NameHidden(object sender, RoutedEventArgs e)
        {
            if (box_name.Text == "Имя")
                box_name.Text = "";
        }

        private void EmailHidden(object sender, RoutedEventArgs e)
        {
            if (box_email.Text == "email@gmail.com")
                box_email.Text = "";
        }

        private void BdayHidden(object sender, RoutedEventArgs e)
        {
            if (box_bday.Text == "Дата рождения")
                box_bday.Text = "";
        }

        private void GenderHidden(object sender, RoutedEventArgs e)
        {
            if (box_gender.Text == "Пол")
                box_gender.Text = "";
        }

        private void HeightHidden(object sender, RoutedEventArgs e)
        {
            if (box_height.Text == "Рост")
                box_height.Text = "";
        }

        private void WeightHidden(object sender, RoutedEventArgs e)
        {
            if (box_weight.Text == "Вес")
                box_weight.Text = "";
        }
    }
}
