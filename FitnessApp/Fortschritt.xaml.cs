using FitnessApp.Class;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Fortschritt.xaml
    /// </summary>
    public partial class Fortschritt : UserControl
    {
        readonly JsonDeSerializer json = new JsonDeSerializer();
        public ChartValues<ObservableValue> MyValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Entries { get; set; }


        public Fortschritt()
        {
            InitializeComponent();
            MyValues = new ChartValues<ObservableValue>();

            //Farbe für Columns
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF5C99D6");

            var columnSeries = new ColumnSeries
            {
                Values = MyValues,
                StrokeThickness = 1,
                Fill = brush,
                DataLabels = true
            };
            SeriesCollection = new SeriesCollection { columnSeries };
            Entries = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                           "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28","29","30"};
            DataContext = this;
            Chart.Hoverable = false;


            LoadDefault();
        }

        private void LoadDefault()
        {
            CreateWeightGraph(7);
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <returns></returns>
        public string GetProteinZiel()
        {
            return ProteinZiel.Text;
        }
        public string GetCarbsZiel()
        {
            return CarbsZiel.Text;
        }
        public string GetFatZiel()
        {
            return FatZiel.Text;
        }
        public string GetCaloriesZiel()
        {
            return CaloriesZiel.Text;
        }

        /// <summary>
        /// Gültige Eingabe nur positive Zahlen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            KalorienTracker kt = new KalorienTracker();
            kt.NumberValidationTextBox(sender, e);
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            int selcetedEntries = Convert.ToInt16(GridCursorDays.GetValue(Grid.ColumnProperty));

            switch (index)
            {
                case 0:
                    if (Convert.ToInt16(GridCursorType.GetValue(Grid.ColumnProperty)) == index)
                        return;
                    GridCursorType.SetValue(Grid.ColumnProperty, index);
                    if (selcetedEntries == 2)
                        CreateWeightGraph(7);
                    if (selcetedEntries == 3)
                        CreateWeightGraph(14);
                    if (selcetedEntries == 4)
                        CreateWeightGraph(30);
                    break;

                case 1:
                    if (Convert.ToInt16(GridCursorType.GetValue(Grid.ColumnProperty)) == index)
                        return;
                    GridCursorType.SetValue(Grid.ColumnProperty, index);
                    if (selcetedEntries == 2)
                        CreateCaloriesGraph(7);
                    if (selcetedEntries == 3)
                        CreateCaloriesGraph(14);
                    if (selcetedEntries == 4)
                        CreateCaloriesGraph(30);
                    break;
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            int numberOfEntries = int.Parse(((Button)e.Source).Uid);

            switch (numberOfEntries)
            {
                case 7:
                    if (Convert.ToInt16(GridCursorDays.GetValue(Grid.ColumnProperty)) == 2)
                        return;
                    GridCursorDays.SetValue(Grid.ColumnProperty, 2);
                    break;
                case 14:
                    if (Convert.ToInt16(GridCursorDays.GetValue(Grid.ColumnProperty)) == 3)
                        return;
                    GridCursorDays.SetValue(Grid.ColumnProperty, 3);
                    break;
                case 30:
                    if (Convert.ToInt16(GridCursorDays.GetValue(Grid.ColumnProperty)) == 4)
                        return;
                    GridCursorDays.SetValue(Grid.ColumnProperty, 4);
                    break;
            }

            //Rausfinden ob Kalorien oder Gewicht ausgewählt ist
            if (Convert.ToInt16(GridCursorType.GetValue(Grid.ColumnProperty)) == 1)
                CreateCaloriesGraph(numberOfEntries);
            else
                CreateWeightGraph(numberOfEntries);
        }

        private void CreateWeightGraph(int numberOfEntries)
        {
            var weight = json.DeserializeGewichtTag();
            var jsonLenght = weight.Count;
            MyValues.Clear();
            TypeOfGraph.Title = "Gewicht";

            if (jsonLenght == 0)
                return;

            for (int i = 0; i <= numberOfEntries - 1; i++)
            {
                if (i >= jsonLenght)
                    break;

                if (jsonLenght <= numberOfEntries)
                    MyValues.Add(new ObservableValue(weight[i].TodaysWeight));
                else
                    MyValues.Add(new ObservableValue(weight[jsonLenght-numberOfEntries-i].TodaysWeight));
            }
        }

        private void CreateCaloriesGraph(int numberOfEntries)
        {
            var calories = json.DeserializeKalorienTag();
            var jsonLenght = calories.Count;
            MyValues.Clear();
            TypeOfGraph.Title = "Kalorien";


            if (calories.Count == 0)
                return;

            for (int i = 0; i <= numberOfEntries - 1; i++)
            {
                if (i >= jsonLenght)
                    break;

                if (jsonLenght <= numberOfEntries)
                    MyValues.Add(new ObservableValue(calories[i].CaloriesDay));
                else
                    MyValues.Add(new ObservableValue(calories[jsonLenght - numberOfEntries - i].CaloriesDay));
            }
        }
    }
}
