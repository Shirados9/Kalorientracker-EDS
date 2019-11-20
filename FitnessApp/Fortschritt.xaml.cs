using FitnessApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LiveCharts.Wpf;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Fortschritt.xaml
    /// </summary>
    public partial class Fortschritt : UserControl
    {
        JsonDeSerializer json = new JsonDeSerializer();


        public Fortschritt()
        {
            InitializeComponent();
            //LoadDefault();
            //ReadJson();
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 },
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 10
                }
            };

            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"};
            //YFormatter = value => value.ToString("C");
            //modifying any series values will also animate and update the chart
            SeriesCollection[0].Values.Add(5d);
            DataContext = this;
        }

        private void LoadDefault()
        {
            GridMain.Children.Add(new KalorienGraph());
            GridCursor.SetValue(Grid.ColumnProperty, 0);
        }

        /*
        private void ReadJson()
        {
           // Lebensmitteltabelle.Items.Clear();
            var lebensmittel = json.DeserializeKalorienTag();
            if (lebensmittel == null) return;

            foreach (var item in lebensmittel)
            {
                var addLebensmittel = new Groceries
                {
                   
                };
                //Lebensmitteltabelle.Items.Add(addLebensmittel);
            }
        }
        */
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public double GetProteinsZiel()
        {
            return Convert.ToDouble(ProteinsZiel.Text);
        }

        /// <summary>
        /// Gültige Eingabe nur positive Zahlen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new KalorienGraph());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new GewichtGraph());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
            }
        }
    }
}
