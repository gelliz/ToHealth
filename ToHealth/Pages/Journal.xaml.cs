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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace ToHealth.Pages
{
    public partial class Journal : Page
    {
        public Journal()
        {
            InitializeComponent();
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            using (DBToHealth db = new DBToHealth())
            {
                var dones = db.Reminders.Where(p => p.UserId == MainClass.ID && p.fulfillment == 1).Select(p => p);
                var skipp = db.Reminders.Where(p => p.UserId == MainClass.ID && p.fulfillment == -1).Select(p => p);
                done.Values = new ChartValues<int>(new List<int> { dones.Count() });
                skipped.Values = new ChartValues<int>(new List<int> { skipp.Count() });
            }
            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
