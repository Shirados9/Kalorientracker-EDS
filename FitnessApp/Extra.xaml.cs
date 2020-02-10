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

        private void KcalCalc()
        {
            Kcal.Text = (955.1 + (9.6 * double.Parse(Gewicht.Text)) + (1.8 * double.Parse(Große.Text)) - (4.7 * (double.Parse(Alter.Text)))).ToString("0");
        }

        private void FFMICalc()
        {
            double FFM = double.Parse(Gewicht.Text) * (100 - (double.Parse(Fettanteil.Text))) / 100;
            FFMI.Text = (FFM / ((double.Parse(Große.Text) / 100) * (double.Parse(Große.Text) / 100)) + 6.3 * (1.8 - double.Parse(Große.Text) / 100)).ToString("0.00");
        }
        private void ProteinCalc()
        {

            Protein.Text = (((double.Parse(Kcal.Text)) * ((double.Parse(Proteingoal.Text)) / 100)) / 4.1).ToString("0.0");
        }
        private void CarbsCalc()
        {

            Carbs.Text = (((double.Parse(Kcal.Text)) * ((double.Parse(Carbsgoal.Text)) / 100)) / 4.1).ToString("0.0");
        }
        private void FatCalc()
        {

            Fat.Text = (((double.Parse(Kcal.Text)) * ((double.Parse(Fatgoal.Text)) / 100)) / 9.3).ToString("0.0");
        }


        private void GG_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Bedingungen abfangen, falls leere Textbox -> Rechnung nicht durchführen wenn leer
            if (!String.IsNullOrEmpty(Alter.Text) && !String.IsNullOrEmpty(Große.Text) && !String.IsNullOrEmpty(Gewicht.Text))
                KcalCalc();
            if (!String.IsNullOrEmpty(Gewicht.Text) && !String.IsNullOrEmpty(Große.Text))
                BMICalc();
            if (!String.IsNullOrEmpty(Große.Text) && !String.IsNullOrEmpty(Gewicht.Text) && !String.IsNullOrEmpty(Fettanteil.Text))
                FFMICalc();
            else
                return;
        }

        private void GG_TextChangedMakros(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(Carbsgoal.Text) || String.IsNullOrEmpty(Proteingoal.Text) || String.IsNullOrEmpty(Fatgoal.Text) || String.IsNullOrEmpty(Kcal.Text))
                return;
            if (CheckPercentage())
            {
                ProteinCalc();
                CarbsCalc();
                FatCalc();
            }
            else return;
        }
        private bool CheckPercentage()
        {
            if ((double.Parse(Proteingoal.Text) + double.Parse(Carbsgoal.Text) + double.Parse(Fatgoal.Text)) == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SubmitWeightAndMakros(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Gewicht.Text) && !String.IsNullOrEmpty(Protein.Text) && !String.IsNullOrEmpty(Carbs.Text) && !String.IsNullOrEmpty(Fat.Text) && !String.IsNullOrEmpty(Kcal.Text))
            {
                WriteWeight();
                WriteMakros();
                EntrySuccessful.Text = "Erfolgreich eingetragen";
                EntryNotSuccessful.Text = "";
            }
            else
            {
                EntrySuccessful.Text = "";
                EntryNotSuccessful.Text = "Bitte Gewicht eingeben";
            }
        }

        private void WriteWeight() 
        {
            var weightList = json.DeserializeGewichtTag();
            int counter = 0;

            foreach (var item in weightList)
            {
                if (item.Day == DateTime.Today.Date)
                {
                    weightList[counter].TodaysWeight = double.Parse(Gewicht.Text);
                    json.Serializer(weightList);
                    return;
                }
                counter++;
            }
            weightList.Add(new GewichtTag()
            {
                Day = DateTime.Today,
                TodaysWeight = double.Parse(Gewicht.Text)
            });
            json.Serializer(weightList);
        }

        private void WriteMakros()
        {
            var makroList = json.DeserializeMakros();

            makroList[0].CalGoal = double.Parse(Kcal.Text);
            makroList[0].ProteinGoal = double.Parse(Protein.Text);
            makroList[0].FatGoal = double.Parse(Fat.Text);
            makroList[0].CarbGoal = double.Parse(Carbs.Text);
            json.Serializer(makroList);
        }

    }
}