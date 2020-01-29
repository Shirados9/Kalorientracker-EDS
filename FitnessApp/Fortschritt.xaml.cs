using FitnessApp.Class;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Text.RegularExpressions;
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
        JsonDeSerializer json = new JsonDeSerializer();
        public ChartValues<ObservableValue> MyValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Days { get; set; }


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
            Days = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                           "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28","29","30"};
            DataContext = this;

            LoadDefault();
        }

        private void LoadDefault()
        {
            createWeightGraph(7);
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
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            int selectedDays = Convert.ToInt16(GridCursorDays.GetValue(Grid.ColumnProperty));

            switch (index)
            {
                case 0:
                    if (Convert.ToInt16(GridCursorType.GetValue(Grid.ColumnProperty)) == index)
                        return;
                    GridCursorType.SetValue(Grid.ColumnProperty, index);
                    if (selectedDays == 2)
                        createWeightGraph(7);
                    if (selectedDays == 3)
                        createWeightGraph(14);
                    if (selectedDays == 4)
                        createWeightGraph(30);
                    break;

                case 1:
                    if (Convert.ToInt16(GridCursorType.GetValue(Grid.ColumnProperty)) == index)
                        return;
                    GridCursorType.SetValue(Grid.ColumnProperty, index);
                    if (selectedDays == 2)
                        createCaloriesGraph(7);
                    if (selectedDays == 3)
                        createCaloriesGraph(14);
                    if (selectedDays == 4)
                        createCaloriesGraph(30);
                    break;
            }
        }


        #region Graphen
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            int numberOfDays = int.Parse(((Button)e.Source).Uid);

            switch (numberOfDays)
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

            if (Convert.ToInt16(GridCursorType.GetValue(Grid.ColumnProperty)) == 1)
                createCaloriesGraph(numberOfDays);
            else
                createWeightGraph(numberOfDays);
        }

        private void createWeightGraph(int numberOfDays)
        {
            MyValues.Clear();
            TypeOfGraph.Title = "Gewicht";
            var weight = json.DeserializeGewichtTag();
            for (int i = 0; i <= numberOfDays - 1; i++)
            {
                if (weight[i].TodaysWeight == 0)
                {
                    continue;
                }
                MyValues.Add(new ObservableValue(weight[i].TodaysWeight));
            }
        }

        private void createCaloriesGraph(int numberOfDays)
        {
            MyValues.Clear();
            TypeOfGraph.Title = "Kalorien";
            var calories = json.DeserializeKalorienTag();
            for (int i = 0; i <= numberOfDays - 1; i++)
            {
                if (calories[i].CaloriesDay == 0)
                {
                    continue;
                }
                MyValues.Add(new ObservableValue(calories[i].CaloriesDay));
            }
        }
        #endregion
    }
}
