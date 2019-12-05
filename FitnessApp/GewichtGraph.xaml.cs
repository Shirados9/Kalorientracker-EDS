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
        //private void InsertPointOnClick(object sender, RoutedEventArgs e)
        //{
        //    var r = new Random();
        //    if (MyValues.Count > 3)
        //        MyValues.Insert(2, new ObservableValue(r.Next(-20, 20)));
        //}

        //private void RemovePointOnClick(object sender, RoutedEventArgs e)
        //{
        //    MyValues.RemoveAt(0);
        //}

        //private void AddSeriesOnClick(object sender, RoutedEventArgs e)
        //{
        //    //Yes it also listens for series changes
        //    var r = new Random();

        //    var c = SeriesCollection[0].Values.Count;

        //    var val = new ChartValues<ObservableValue>();

        //    for (int i = 0; i < c; i++)
        //    {
        //        val.Add(new ObservableValue(r.Next(-20, 20)));
        //    }

        //    SeriesCollection.Add(new LineSeries
        //    {
        //        Values = val,
        //        StrokeThickness = 4,
        //        Fill = Brushes.Transparent,
        //        PointGeometrySize = 0
        //    });
        //}

        //private void RemoveSeriesOnClick(object sender, RoutedEventArgs e)
        //{
        //    var s = SeriesCollection.Where(x => x.Values != MyValues).ToList();
        //    if (s.Count > 0) SeriesCollection.RemoveAt(1);
        //}

        //private void MoveAllOnClick(object sender, RoutedEventArgs e)
        //{
        //    var r = new Random();

        //    foreach (var observable in MyValues)
        //    {
        //        observable.Value = r.Next(-20, 20);
        //    }
        //}

        //public string[] labels { get; set; }
        //public func<double, string> yformatter { get; set; }
    }
}
