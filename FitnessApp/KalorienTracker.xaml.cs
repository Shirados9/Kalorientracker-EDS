using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using FitnessApp.Class;
using System.Collections.Generic;
using System.Windows.Data;
using System.ComponentModel;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für KalorienTracker.xaml
    /// </summary>
    public partial class KalorienTracker : UserControl
    {
        readonly JsonDeSerializer json = new JsonDeSerializer();

        public KalorienTracker()
        {
            InitializeComponent();
            ReadJson();
        }

        private void ReadJson()
        {
            KalorienTrackerListe.Items.Clear();
            var groceryList = json.Deserializer();
            if (groceryList == null) return;

            var listAdder = new List<Groceries>();

            foreach (var item in groceryList)
            {
                listAdder.Add(new Groceries() { Name = item.Name, Calories = item.Calories, Carbs = item.Carbs, Fats = item.Fats, Protein = item.Protein, Uid = item.Uid });
            }
            KalorienTrackerListe.ItemsSource = listAdder;

            //Nach Namen sortieren
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(KalorienTrackerListe.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

        }

        private void CalculateCalories_Click(object sender, RoutedEventArgs e)
        {


            this.FalscheEingabe.Visibility = Visibility.Hidden;
            if (AlleLeer())
            {
                ConsumedCalories.Text = Convert.ToString(Math.Round(CalcCalories(), MidpointRounding.AwayFromZero));
                BerechneNaehrstoff(ProteinsToday, ProteinBox, "200", ProteinBar);
                //BerechneNaehrstoff(CarbsToday, CarbBox, CarZbsiel, CarbBar);
                //BerechneNaehrstoff(FatsToday, FatBox, FatsZiel, FatBar);

                ProteinBox.Clear(); 
                CarbBox.Clear();
                FatBox.Clear();
                ManualCaloryBox.Clear();

                MessageBox.Show("Kalorien erfolgreich eingetragen");

                WriteCaloryDayInJson();
            }
            else
            {
                this.FalscheEingabe.Visibility = Visibility.Visible;
            }

        }

        private void WriteCaloryDayInJson()
        {
            var KalorienTag = json.DeserializeKalorienTag();
            int currentDay = DateTime.Today.Day;

            foreach (var itemDay in KalorienTag)
            {
                if (currentDay == itemDay.Day)
                {
                    itemDay.CaloriesDay = double.Parse(ConsumedCalories.Text);
                    json.Serializer(KalorienTag);
                    return;
                }               
            }
                KalorienTag.Add(new KalorienTag()
                {
                    Day = DateTime.Today.Day,
                    CaloriesDay = double.Parse(ConsumedCalories.Text)
                });
            json.Serializer(KalorienTag);
            return;
        }

        /// <summary>
        /// Checkt ob alle Eingaben leer sind.
        /// </summary>
        /// <returns></returns>
        private bool AlleLeer()
        {
            if (String.IsNullOrWhiteSpace(ProteinBox.Text) && String.IsNullOrWhiteSpace(CarbBox.Text) && String.IsNullOrWhiteSpace(FatBox.Text) && String.IsNullOrWhiteSpace(ManualCaloryBox.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gültige Eingabe nur positive Zahlen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Kontrolliert ob einzelne Kästchen leer sind und trägt 0 ein.
        /// </summary>
        private void CheckKästchen()
        {
            if (String.IsNullOrWhiteSpace(ProteinBox.Text))
            {
                ProteinBox.Text = "0";
            }
            if (String.IsNullOrWhiteSpace(CarbBox.Text))
            {
                CarbBox.Text = "0";
            }
            if (String.IsNullOrWhiteSpace(FatBox.Text))
            {
                FatBox.Text = "0";
            }
            if (String.IsNullOrWhiteSpace(ManualCaloryBox.Text))
            {
                ManualCaloryBox.Text = "0";
            }

        }

        /// <summary>
        /// Rechnet Kalorien aus und gibt Kalorien zurück.
        /// </summary>
        /// <returns></returns>
        private double CalcCalories()
        {
            CheckKästchen();
            return Double.Parse(ProteinBox.Text) * (4.1) + Double.Parse(CarbBox.Text) * (4.1) + Double.Parse(FatBox.Text) * (9.3) + Double.Parse(ManualCaloryBox.Text) + Double.Parse(ConsumedCalories.Text);
        }

        /// <summary>
        /// Berechnung der Nährstoffe für jene Klasse.
        /// </summary>
        /// <param name="naehrstoffOutput"></param>
        /// <param name="naehrstoffInput"></param>
        /// <param name="naehrstoffZiel"></param>
        /// <param name="bar"></param>
        private void BerechneNaehrstoff(TextBlock naehrstoffOutput, TextBox naehrstoffInput, string naehrstoffZiel, ProgressBar bar)
        {
            double outputValue = double.Parse(naehrstoffOutput.Text);
            double inputValue = double.Parse(naehrstoffInput.Text);
            double newOutput = outputValue + inputValue;

            naehrstoffOutput.Text = Convert.ToString(newOutput);
            bar.Value = BerechneBarProgress(newOutput, Double.Parse(naehrstoffZiel));
            ProgressBarColor(bar);
        }

        /// <summary>
        /// Berechnung des Fortschritts der Bar.
        /// </summary>
        /// <param name="wert"></param>
        /// <param name="ziel"></param>
        /// <returns></returns> Prozentwert der ProgressBar.
        private double BerechneBarProgress(double wert, double ziel)
        {
            double tmp = wert / ziel;
            tmp *= 100;
            return tmp; ;
        }

        private void ProgressBarColor(ProgressBar bar)
        {
            if (bar.Value < 75)
            {
                bar.Foreground = Brushes.Green;
            }
            else if (bar.Value < 100)
            {
                bar.Foreground = Brushes.Orange;
            }
            else if (bar.Value >= 100)
            {
                bar.Foreground = Brushes.Red;
            }
        }

        /// <summary>
        /// Enter startet CalculateCalories_Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                CalculateCalories_Click(null, null);
            }
        }

        private void KalorienTrackerListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grocery = (Groceries)((ListView)sender).SelectedItem;

            if (grocery != null)
            {
                if (String.IsNullOrEmpty(HowMuchBox.Text))
                    EnterMacroValues(0);
                else
                    EnterMacroValues(double.Parse(HowMuchBox.Text));
            }
        }

        private void HowMuchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(HowMuchBox.Text))
                EnterMacroValues(double.Parse(HowMuchBox.Text));

        }

        private void EnterMacroValues(double howMuch)
        {
            if (KalorienTrackerListe.SelectedIndex >= 0)
            {
                Groceries grocery = (Groceries)KalorienTrackerListe.SelectedItems[0];
                CarbBox.Text = (double.Parse(grocery.Carbs) / 100 * howMuch).ToString();
                ProteinBox.Text = (double.Parse(grocery.Protein) / 100 * howMuch).ToString();
                FatBox.Text = (double.Parse(grocery.Fats) / 100 * howMuch).ToString();
            }
        }
    }
}

