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
using MahApps.Metro.Controls;

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
        }

        private void CalculateCalories_Click(object sender, RoutedEventArgs e)
        {
            this.FalscheEingabe.Visibility = Visibility.Hidden;
            if (CheckEingabe())
            {
                CaloriesToday.Text = Convert.ToString(CalcCalories());
                ProteinBox.Clear();
                CarbBox.Clear();
                FatBox.Clear();

                MessageBox.Show("Kalorien erfolgreich eingetragen");
            }
            else
            {
                this.FalscheEingabe.Visibility = Visibility.Visible;
            }

        }
        
        // Checkt ob Eingabe < 0 oder leer
        private bool CheckEingabe()
        {
            if (String.IsNullOrWhiteSpace(ProteinBox.Text) || String.IsNullOrWhiteSpace(CarbBox.Text) || String.IsNullOrWhiteSpace(FatBox.Text) || String.IsNullOrWhiteSpace(ManualCaloryBox.Text))
            {
                return false;
            }
            else if (Double.Parse(ProteinBox.Text) < 0 || Double.Parse(CarbBox.Text) < 0 || Double.Parse(FatBox.Text) < 0)
            {
                return false;
            }
            return true;
        }

        // Rechnet Kalorien aus
        private double CalcCalories()
        {
            return Double.Parse(ProteinBox.Text) * (4.1) + Double.Parse(CarbBox.Text) * (4.1) + Double.Parse(FatBox.Text) * (9.3) + Double.Parse(ManualCaloryBox.Text) + Double.Parse(CaloriesToday.Text);
        }

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

    }
}
