using FitnessApp.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Ernährungsplan.xaml
    /// </summary>
    public partial class Ernährungsplan : UserControl
    {
        readonly Meals meals = new Meals();
        public Ernährungsplan()
        {
            InitializeComponent();
            LoadDefault();
        }

        private void Breakfast()
        {
            var items = meals.getBreakfast();
            MealsList.ItemsSource = items;
            MealsList.SelectedItem = 1;
        }

        private void Lunch()
        {
            var items = meals.getLunch();
            MealsList.ItemsSource = items;
            MealsList.SelectedItem = 1;
        }

        private void Dinner()
        {
            var items = meals.getDinner();
            MealsList.ItemsSource = items;
            MealsList.SelectedItem = 1;
        }

        // lädt standard grid der seite
        private void LoadDefault()
        {
            Breakfast();
            GridCursor.SetValue(Grid.ColumnProperty, 0);
        }

        // funktion zum öffnen von links
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        // wechselt zwischen frühstück, mittagessen und abendessen
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    Breakfast();
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                case 1:
                    Lunch();
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                case 2:
                    Dinner();
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                default:
                    break;
            }
        }
        // ???
        private Uri ConvertToUriImage(string path)
        {
            var source = new Uri(@"/FitnessApp;component" + path, UriKind.Relative);
            return source;

        }
        // ???
        private Uri ConvertToUriURL(string link)
        {
            Uri uri = new Uri(link, UriKind.Absolute);
            return uri;
        }
        // zeigt das info fenster zu den einzelnen meals an
        private void MealsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var meal = (Meals)((ListView)sender).SelectedItem;
            //var listAdder = new List<Meals>();

            if (meal != null)
            {
                SelectedMealImage.Source = new BitmapImage(ConvertToUriImage(meal.Path));
                SelectedMealName.Text = meal.Name.ToString();
                SelectedMealCalories.Text = meal.Calories.ToString() + "kcal";

                SelectedMealCarbs.Text = meal.Carbs.ToString() + "g";
                SelectedMealCarbs2.Text = "Kohlenhydrate";
                SelectedMealFats.Text = meal.Fat.ToString() + "g";
                SelectedMealFats2.Text = "Fett";
                SelectedMealProteins.Text = meal.Protein.ToString() + "g";
                SelectedMealProteins2.Text = "Protein";

                LinkToMeal.NavigateUri = ConvertToUriURL(meal.Link);
            }   
        }
    }
}
