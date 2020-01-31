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
using System.Reflection;
using ToHealth.DB;

namespace ToHealth.Pages
{
    public partial class AboutUs : Page
    {
        string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public AboutUs()
        {
            InitializeComponent();

            versionBlock.Text = version;
        } 
    }
}
