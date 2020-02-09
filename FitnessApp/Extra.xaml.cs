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

        readonly JsonDeSerializer json = new JsonDeSerializer();

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

        private void KcalCalc()
        {
            Kcal.Text = (955.1 + (9.6 * double.Parse(Gewicht.Text)) + (1.8 * double.Parse(Große.Text)) - (4.7 * (double.Parse(Alter.Text)))).ToString("0");
        }

        private void FFMICalc()
        {
            double FFM = double.Parse(Gewicht.Text) * (100 - (double.Parse(Fettanteil.Text))) / 100;
            FFMI.Text = (FFM / ((double.Parse(Große.Text) / 100) * (double.Parse(Große.Text) / 100)) + 6.3 * (1.8 - double.Parse(Große.Text) / 100)).ToString("0.00");
        }


        private void GG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Gewicht.Text) && !String.IsNullOrEmpty(Große.Text))
            {
                BMICalc();
                if (String.IsNullOrEmpty(Fettanteil.Text))
                    Fettanteil.Text = "0";
                {
                    FFMICalc();
                    if (!String.IsNullOrEmpty(Alter.Text) && !String.IsNullOrEmpty(Große.Text) && !String.IsNullOrEmpty(Gewicht.Text))
                    {
                        KcalCalc();
                    }
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

        private bool ValidateDataGridInput()
        {
            if (String.IsNullOrEmpty(Gewicht.Text))
            {
                EntrySuccessful.Text = "";
                EntryNotSuccessful.Text = "Bitte Gewicht eingeben";
                return false;
            }
            else
            {
                return true;
            }
        }

        //private void AddWeight_Click(object sender, RoutedEventArgs e)
        //{

        //    var weightList = json.Deserializer();
        //    if (ValidateDataGridInput())
        //    {
        //        weightList.Add(new GewichtTag()
                
        //            TodaysWeight = Gewicht.Text
        //        );
        //        json.Serializer(weightList);
        //        ResetTextBoxes();
        //        EntrySuccessful.Text = "Gewicht erfolgreich eingetragen";
        //        ReadJson();

        //    }
        //}
        //private int GetFreeUid(List<GewichtTag>)
        //{
        //    int counter = 0;
        //    foreach (var item in groceryList)
        //    {
        //        if (counter != item.Uid) return counter;
        //        counter++;
        //    }
        //    return counter;
        //}
    }
}