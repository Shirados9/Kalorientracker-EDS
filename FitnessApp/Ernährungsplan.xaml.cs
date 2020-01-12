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
        public Ernährungsplan()
        {
            InitializeComponent();
            LoadDefault();
        }

        #region Meals
        private void Breakfast()
        {
            //MealsList.Items.Clear();
            List<Meals> items = new List<Meals>
            {
                new Meals() { Name = "Dinkel-Apfel-Müsli-Joghurt", Calories = 270, Path = "/Images/dinkelapfelmueslijoghurtfruehstück.png", Carbs = 52, Fats = 3, Proteins = 8, Link = "https://www.lecker.de/dinkel-apfel-muesli-mit-joghurt-27697.html"},
                new Meals() { Name = "Papaya mit körnigem Frischkäse", Calories = 220, Path = "/Images/papaya-mit-koernigem-frischkaese.png", Carbs = 6, Fats = 9, Proteins = 27, Link = "https://www.lecker.de/papaya-mit-koernigem-frischkaese-14914.html"},
                new Meals() { Name = "Vollkornbrot mit Quark, Bananenscheiben", Calories = 150, Path = "/Images/vollkornbrot-mit-quark-bananenscheiben.png", Carbs = 27, Fats = 1, Proteins = 8, Link = "https://www.lecker.de/vollkornbrot-mit-quark-bananenscheiben-agavendicksaft-und-chiasamen-60929.html"},
                new Meals() { Name = "Obstsalat", Calories = 270, Path = "/Images/obstsalat.png", Carbs = 52, Fats = 6, Proteins = 4, Link = "https://www.lecker.de/der-gesuendeste-obstsalat-der-welt-66961.html"},
                new Meals() { Name = "Beeren-Knusper-Quark", Calories = 220, Path = "/Images/beeren-knusper-quark.png", Carbs = 23, Fats = 5, Proteins = 23, Link = "https://www.lecker.de/beeren-knusper-quark-60219.html"},
                new Meals() { Name = "Cloud-Eggs", Calories = 150, Path = "/Images/cloud-eggs.png", Carbs = 1, Fats = 6, Proteins = 8, Link = "https://www.lecker.de/cloud-eggs-72693.html"},
                new Meals() { Name = "Roggenbrötchen mit Käse, Radieschen und Sprossen", Calories = 270, Path = "/Images/roggenbroetchen-mit-kaese-radieschen-und-sprossen.png", Carbs = 41, Fats = 6, Proteins = 18, Link = "https://www.lecker.de/roggenbroetchen-mit-kaese-radieschen-und-sprossen-7843.html"},
                new Meals() { Name = "Joghurt mit Blaubeeren und Banane", Calories = 220, Path = "/Images/joghurt-mit-blaubeeren-pecannuessen-und-banane.png", Carbs = 9, Fats = 22, Proteins = 17, Link = "https://www.lecker.de/joghurt-mit-blaubeeren-pecannuessen-und-banane-64648.html"},
                new Meals() { Name = "Rühreibagel mit Lachs", Calories = 150, Path = "/Images/ruehreibagel-mit-lachs.png", Carbs = 21, Fats = 9, Proteins = 36, Link = "https://eatsmarter.de/rezepte/ruehreibagel-mit-lachs-0"},
            };
            MealsList.ItemsSource = items;
        }

        private void Lunch()
        {
            //MealsList.Items.Clear();
            List<Meals> items = new List<Meals>
            {
                new Meals() { Name = "Schnitzel im Sauseschritt mit Spitzkohl-Slaw", Calories = 490, Path = "/Images/schnitzel-im-sauseschritt-mit-spitzkohl-slaw.png", Carbs = 33, Fats = 21, Proteins = 39, Link = "https://www.lecker.de/schnitzel-im-sauseschritt-mit-spitzkohl-slaw-77451.html"},
                new Meals() { Name = "Pfanne mit Steak und Brokkoli", Calories = 350, Path = "/Images/Express-Pfanne-mit-Steak-und-Brokkoli.png", Carbs = 8, Fats = 17, Proteins = 38, Link = "https://www.lecker.de/express-pfanne-mit-steak-und-brokkoli-69737.html"},
                new Meals() { Name = "Gemüsepfanne mit Lachs", Calories = 550, Path = "/Images/gemuesepfanne-mit-lachs.png", Carbs = 18, Fats = 35, Proteins = 37, Link = "https://www.lecker.de/gemuesepfanne-mit-lachs-71686.html"},
                new Meals() { Name = "Makkaroni Molto p(r)esto", Calories = 560, Path = "/Images/makkaroni-moltopresto.png", Carbs = 70, Fats = 14, Proteins = 34, Link = "https://www.lecker.de/makkaroni-molto-presto-74135.html"},
                new Meals() { Name = "Hähnchen mit Express-Bratreis", Calories = 670, Path = "/Images/haehnchen-mit-express-bratreis.png", Carbs = 68, Fats = 22, Proteins = 45, Link = "https://www.lecker.de/haehnchen-mit-express-bratreis-72481.html"},
                new Meals() { Name = "Farfalle mit Möhren-Hähnchen-Sugo", Calories = 760, Path = "/Images/farfalle-mit-moehren-haehnchen-sugo.png", Carbs = 83, Fats = 29, Proteins = 41, Link = "https://www.lecker.de/farfalle-mit-moehren-haehnchen-sugo-72146.html"},
                new Meals() { Name = "Putenbrust mit Mango, Kürbis und roten Linsen", Calories = 460, Path = "/Images/putenbrust-mit-mango-kuerbis-roten-linsen.png", Carbs = 35, Fats = 13, Proteins = 50, Link = "https://www.lecker.de/putenbrust-mit-mango-kuerbis-und-roten-linsen-66718.html"},
                new Meals() { Name = "Reisnudeln mit Asia-Hackfleisch", Calories = 740, Path = "/Images/reisnudeln-mit-asia-hackfleisch.png", Carbs = 44, Fats = 47, Proteins = 31, Link = "https://www.lecker.de/reisnudeln-mit-asia-hackfleisch-70378.html"},
                new Meals() { Name = "Süss-Scharfe Reis-Bowl Hawaii", Calories = 560, Path = "/Images/suess-scharfe-reisbowl-hawaii.png", Carbs = 60, Fats = 17, Proteins = 38, Link = "https://www.lecker.de/suess-scharfe-reis-bowl-hawaii-74291.html"},
            };
            MealsList.ItemsSource = items;
        }

        private void Dinner()
        {
            //MealsList.Items.Clear();
            List<Meals> items = new List<Meals>
            {
                new Meals() { Name = "Gnocchi mit ­Spinat und Lachs", Calories = 540, Path = "/Images/gnocchi-mit-spinat-und-lachs.png", Carbs = 45, Fats = 30, Proteins = 18, Link = "https://www.lecker.de/ruck-zuck-gnocchi-mit-spinat-und-lachs-74105.html"},
                new Meals() { Name = "Thainudelsuppe mit Hähnchen", Calories = 440, Path = "/Images/thainudelsuppe-mit-haehnchen.png", Carbs = 37, Fats = 15, Proteins = 37, Link = "https://www.lecker.de/thainudelsuppe-mit-haehnchen-70443.html"},
                new Meals() { Name = "Fladenbrot-Gyrospizza", Calories = 670, Path = "/Images/fladenbrot-gyrospizza.png", Carbs = 60, Fats = 23, Proteins = 51, Link = "https://www.lecker.de/fladenbrot-gyrospizza-71701.html"},
                new Meals() { Name = "Omelett mit Lachs und Fenchelsalat", Calories = 560, Path = "/Images/ommm-omelett-mit-lachs-und-fenchelsalat.png", Carbs = 8, Fats = 44, Proteins = 28, Link = "https://www.lecker.de/ommm-omelett-mit-lachs-und-fenchelsalat-77612.html"},
                new Meals() { Name = "Geschnetzeltes mit Gnocchi und Pestorahm", Calories = 670, Path = "/Images/geschnetzeltzes-mit-gnocchi-und-pestorahm.png", Carbs = 52, Fats = 34, Proteins = 37, Link = "https://www.lecker.de/geschnetzeltes-mit-gnocchi-und-pestorahm-64982.html"},
                new Meals() { Name = "Penne mit Bratwurst-Bolo", Calories = 610, Path = "/Images/express-penne-mit-bratwurst-bolo.png", Carbs = 82, Fats = 19, Proteins = 23, Link = "https://www.lecker.de/express-penne-mit-bratwurst-bolo-8353.html"},
                new Meals() { Name = "Hähnchen-Gemüsepfanne", Calories = 340, Path = "/Images/haehnchen-gemuesepfanne.png", Carbs = 25, Fats = 14, Proteins = 26, Link = "https://www.lecker.de/haehnchen-gemuesepfanne-67018.html" },
                new Meals() { Name = "Feurige Garnelenpfanne", Calories = 190, Path = "/Images/feurige-garnelenpfanne.png", Carbs = 10, Fats = 7, Proteins = 22, Link = "https://www.lecker.de/feurige-garnelenpfanne-60571.html"},
                new Meals() { Name = "Putenpasta in Zitronencreme", Calories = 570, Path = "/Images/putenpasta-in-zitronencreme.png", Carbs = 43, Fats = 26, Proteins = 37, Link = "https://www.lecker.de/putenpasta-zitronencreme-74548.html"},
            };
            MealsList.ItemsSource = items;
        }

        public class Meals
        {
            public string Name { get; set; }

            public int Calories { get; set; }
            public int Carbs { get; set; }
            public int Fats { get; set; }
            public int Proteins { get; set; }

            public string Path { get; set; }
            public string Link { get; set; }
        }
        #endregion

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

            if (meal != null)
            {
                SelectedMealImage.Source = new BitmapImage(ConvertToUriImage(meal.Path));
                SelectedMealName.Text = meal.Name.ToString();
                SelectedMealCalories.Text = meal.Calories.ToString() + "kcal";

                SelectedMealCarbs.Text = meal.Carbs.ToString() + "g";
                SelectedMealCarbs2.Text = "Kohlenhydrate";
                SelectedMealFats.Text = meal.Fats.ToString() + "g";
                SelectedMealFats2.Text = "Fette";
                SelectedMealProteins.Text = meal.Proteins.ToString() + "g";
                SelectedMealProteins2.Text = "Proteine";

                LinkToMeal.NavigateUri = ConvertToUriURL(meal.Link);
            }   
        }
    }
}
