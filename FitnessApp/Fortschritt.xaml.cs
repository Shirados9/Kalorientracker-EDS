using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Fortschritt.xaml
    /// </summary>
    public partial class Fortschritt : UserControl
    {
        public Fortschritt()
        {
            InitializeComponent();
            LoadDefault();
        }

        private void LoadDefault()
        {
            GridMain.Children.Add(new GewichtGraph());
            GridCursor.SetValue(Grid.ColumnProperty, 0);
        }
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
                    GridMain.Children.Add(new GewichtGraph());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new KalorienGraph());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
            }
        }
    }
}
