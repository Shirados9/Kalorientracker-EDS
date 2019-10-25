using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;

namespace FitnessPal
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            HighlightTodaysDay();
        }
            

        // ********************************KalorienTracker Code***********************************

        private void CalculateCalories_Click(object sender, RoutedEventArgs e)
        {
            

            this.FalscheEingabe.Visibility = Visibility.Hidden;
            if (AlleLeer())
            {
                CaloriesToday.Text = Convert.ToString(Math.Round(CalcCalories(), MidpointRounding.AwayFromZero));
                BerechneNaehrstoff(ProteinsToday, ProteinBox, ProteinsZiel, ProteinBar);
                BerechneNaehrstoff(CarbsToday, CarbBox, CarbsZiel, CarbBar);
                BerechneNaehrstoff(FatsToday, FatBox, FatsZiel, FatBar);

                ProteinBox.Clear();
                CarbBox.Clear();
                FatBox.Clear();
                ManualCaloryBox.Clear();

                MessageBox.Show("Kalorien erfolgreich eingetragen");
            }
            else
            {
                this.FalscheEingabe.Visibility = Visibility.Visible;
            }

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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
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
            return Double.Parse(ProteinBox.Text) * (4.1) + Double.Parse(CarbBox.Text) * (4.1) + Double.Parse(FatBox.Text) * (9.3) + Double.Parse(ManualCaloryBox.Text) + Double.Parse(CaloriesToday.Text);
        }

        /// <summary>
        /// Berechnung der Nährstoffe für jene Klasse.
        /// </summary>
        /// <param name="naehrstoffOutput"></param>
        /// <param name="naehrstoffInput"></param>
        /// <param name="naehrstoffZiel"></param>
        /// <param name="bar"></param>
        private void BerechneNaehrstoff(TextBlock naehrstoffOutput, TextBox naehrstoffInput, TextBox naehrstoffZiel, ProgressBar bar)
        {
            double outputValue = double.Parse(naehrstoffOutput.Text);
            double inputValue =  double.Parse(naehrstoffInput.Text);
            double newOutput = outputValue + inputValue;

            naehrstoffOutput.Text = Convert.ToString(newOutput);
            bar.Value = BerechneBarProgress(newOutput, Double.Parse(naehrstoffZiel.Text));
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
                bar.Background = Brushes.Green;
            }
            else if (bar.Value < 100)
            {
                bar.Background = Brushes.Orange;
            }
            else if (bar.Value >= 100)
            {
                bar.Background = Brushes.Red;
            }
        }
        // Trägt Kalorien in heutigen Tag oben ein
        private void SubmitCaloriesToCurrentDay_Click(object sender, RoutedEventArgs e)
        {
            double CaloriesMonday, CaloriesTuesday, CaloriesWednesday, CaloriesThursday, CaloriesFriday, CaloriesSaturday, CaloriesSunday;

            DayOfWeek dow = DateTime.Now.DayOfWeek;

            switch (dow)
            {
                case DayOfWeek.Monday:
                    {
                        CaloriesMonday = Double.Parse(CaloriesToday.Text);

                        MondayCalories.Text = Convert.ToString(CaloriesMonday);

                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        CaloriesTuesday = Double.Parse(CaloriesToday.Text);

                        TuesdayCalories.Text = Convert.ToString(CaloriesTuesday);

                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        CaloriesWednesday = Double.Parse(CaloriesToday.Text);

                        WednesdayCalories.Text = Convert.ToString(CaloriesWednesday);

                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        CaloriesThursday = Double.Parse(CaloriesToday.Text);

                        ThursdayCalories.Text = Convert.ToString(CaloriesThursday);

                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        CaloriesFriday = Double.Parse(CaloriesToday.Text);

                        FridayCalories.Text = Convert.ToString(CaloriesFriday);

                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        CaloriesSaturday = Double.Parse(CaloriesToday.Text);

                        SaturdayCalories.Text = Convert.ToString(CaloriesSaturday);

                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        CaloriesSunday = Double.Parse(CaloriesToday.Text);

                        SundayCalories.Text = Convert.ToString(CaloriesSunday);

                        break;
                    }
            }
        }

        // Highlighted heutigen Tag
        private void HighlightTodaysDay()
        {
            DayOfWeek dow = DateTime.Now.DayOfWeek;

            switch (dow)
            {
                case DayOfWeek.Monday:
                    {
                        Montag.Foreground = Brushes.Blue;
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        Dienstag.Foreground = Brushes.Blue;
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        Mittwoch.Foreground = Brushes.Blue;
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        Donnerstag.Foreground = Brushes.Blue;
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        Freitag.Foreground = Brushes.Blue;
                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        Samstag.Foreground = Brushes.Blue;
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        Sonntag.Foreground = Brushes.Blue;
                        break;
                    }
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


        // ********************************Trainingsplan Code***********************************

        /// <summary>
        /// Navigation von URLs in den Browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }


        // ********************************Fortschritt***********************************

    }
}
