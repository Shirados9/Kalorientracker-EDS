using FitnessApp.Class;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für GewichtGraph.xaml
    /// </summary>
    public partial class GewichtGraph : UserControl
    {
        JsonDeSerializer json = new JsonDeSerializer();
        public ChartValues<ObservableValue> MyValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }

        public GewichtGraph()
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
            var currentweight = json.DeserializeGewichtTag();

            for (int i = 0; i <= 30; i++)
            {
                //if (currentweight[i].TodaysWeight == 0)
                //{
                //    continue;
                //}

                MyValues.Add(new ObservableValue(currentweight[i].TodaysWeight));

            }
            
        }
    }
}
