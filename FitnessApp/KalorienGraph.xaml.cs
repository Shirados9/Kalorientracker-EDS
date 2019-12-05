using FitnessApp.Class;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für KalorienGraph.xaml
    /// </summary>
    public partial class KalorienGraph : UserControl
    {
        JsonDeSerializer json = new JsonDeSerializer();
        public ChartValues<ObservableValue> MyValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }

        public KalorienGraph()
        {
            InitializeComponent();

            MyValues = new ChartValues<ObservableValue>
            {
            };

            var lineSeries = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 1,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };
            SeriesCollection = new SeriesCollection { lineSeries };
            DataContext = this;

            Graphplot();
        }

        private void Graphplot()
        {
            var CaloryDays = json.DeserializeKalorienTag();

            for (int i = 0; i <= 30; i++)
            {
                if (CaloryDays[i].CaloriesDay == 0)
                {
                    continue;
                }

                MyValues.Add(new ObservableValue(CaloryDays[i].CaloriesDay));

            }

        }
    }
}
