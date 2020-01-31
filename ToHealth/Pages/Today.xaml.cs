using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
    public partial class Today : Page
    {
        DateTime dt = DateTime.Parse(DateTime.Now.ToShortDateString());
        public Today()
        {
            InitializeComponent();

            List<Reminders> rp = new List<Reminders>();
            using (DBToHealth db = new DBToHealth())
            {
                var r = db.Reminders.Where(p => p.UserId == MainClass.ID && p.dateStart <= dt && dt <= p.dateFinish);

                foreach (Reminders u in r)
                {
                    rp.Add(u);
                }
            }
            noteGrid.ItemsSource = rp;
        }
    }
}
