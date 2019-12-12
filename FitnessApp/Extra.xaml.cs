using FitnessApp.Class;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessApp
{
    /// <summary>
    /// <summary>
    /// Interaktionslogik für Extra.xaml
    /// </summary>
    public partial class Extra : UserControl
    {

        JsonDeSerializer json = new JsonDeSerializer();

        public Extra()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            KalorienTracker kt = new KalorienTracker();
            kt.NumberValidationTextBox(sender, e);
        }

        private void BMICalc()
        {
            BMI.Text = (double.Parse(Gewicht.Text) / (double.Parse(Große.Text) / 100 * (double.Parse(Große.Text)) / 100)).ToString("0.0");
        }

       /* private double GroßeUmgerechnet(double GroßeM)
        {

            return GroßeM/100;
        }*/

        private void FFMICalc()
        {
            double FFM = double.Parse(Gewicht.Text) * (100 - (double.Parse(Fettanteil.Text))) / 100;                // Richtig, überprüft
            FFMI.Text =  (FFM / ((double.Parse(Große.Text) / 100) * (double.Parse(Große.Text) /100)) + 6.3 * (1.8 - double.Parse(Große.Text)/100)).ToString("0.00"); // mad af
        }


        private void GG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Gewicht.Text) && !String.IsNullOrEmpty(Große.Text))
            {
                BMICalc();
                if (!String.IsNullOrEmpty(Fettanteil.Text))
                {
                    FFMICalc();
                }
            }
        }

        private void SubmitStats(object sender, RoutedEventArgs e)
        {
            var extras = json.DeserializeExtratab();
            int currentDay = DateTime.Today.Day;

            foreach (var itemDay in extras)
            {
                if (currentDay == itemDay.Day)
                {
                    itemDay.BMI = double.Parse(BMI.Text);
                    itemDay.FFMI = double.Parse(FFMI.Text);
                    json.Serializer(extras);
                    return;
                }
            }
                extras.Add(new Extratab()
                {
                    Day = DateTime.Today.Day,
                    BMI = double.Parse(BMI.Text),
                    FFMI = double.Parse(FFMI.Text)
                });
            json.Serializer(extras);
            return;
        }
    }
}