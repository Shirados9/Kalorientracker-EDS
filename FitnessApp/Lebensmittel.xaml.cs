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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Newtonsoft.Json;
using FitnessApp.Class;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Lebensmittel.xaml
    /// </summary>
    public partial class Lebensmittel : UserControl
    {
        JsonDeSerializer json = new JsonDeSerializer();
       
        public Lebensmittel()
        {
            InitializeComponent();
            ReadJson();
        }

        /// <summary>
        /// Ließt Json beim Startup und nachdem ein Item eingetragen wurde
        /// </summary>
        private void ReadJson()
        {
            Lebensmitteltabelle.Items.Clear();
            var lebensmittel = json.Deserializer();
            if (lebensmittel == null) return;

            foreach (var item in lebensmittel)
            {
                var addLebensmittel = new Groceries
                {
                    Name = item.Name,
                    Calories = item.Calories,
                    Carbs = item.Carbs,
                    Fats = item.Fats,
                    Protein = item.Protein
                };
                Lebensmitteltabelle.Items.Add(addLebensmittel);
            }
        }

        /// <summary>
        /// Neuen Eintrag in Json schreiben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGrocery_Click(object sender, RoutedEventArgs e)
        {

            var groceryList = json.Deserializer();
            if (ValidateDataGridInput())
            {
                groceryList.Add(new Groceries()
                {
                    Name = NameBox.Text,
                    Carbs = CarbsBox.Text,
                    Calories = CaloriesBox.Text,
                    Fats = FatBox.Text,
                    Protein = ProteinBox.Text
                });
                json.Serializer(groceryList);
                ResetTextBoxes();
                EntrySuccessful.Text = "Essen erfolgreich eingetragen";
                ReadJson();

            }        
        }

        /// <summary>
        /// Textboxen nach eintragen zurücksetzen
        /// </summary>
        private void ResetTextBoxes()
        {
            NameBox.Text = "";
            CaloriesBox.Text = "";
            CarbsBox.Text = "";
            FatBox.Text = "";
            ProteinBox.Text = "";
            EntrySuccessful.Text = "";
            EntryNotSuccessful.Text = "";
        }

        /// <summary>
        /// Kontrolliert ob kein Name eingeben wurde. Falls andere Boxen leer dann 0
        /// </summary>
        /// <returns></returns>
        private bool ValidateDataGridInput()
        {
            if (String.IsNullOrEmpty(NameBox.Text))
            {
                EntryNotSuccessful.Text = "Bitte Namen eingeben";
                EntrySuccessful.Text = "";
                return false;
            }
            if (String.IsNullOrEmpty(CaloriesBox.Text))
                CaloriesBox.Text = "0";
            if (String.IsNullOrEmpty(CarbsBox.Text))
                CarbsBox.Text = "0";
            if (String.IsNullOrEmpty(FatBox.Text))
                FatBox.Text = "0";
            if (String.IsNullOrEmpty(ProteinBox.Text))
                ProteinBox.Text = "0";
            return true;
        }

        /// <summary>
        /// Alle Boxen bis auf Name nur Buchstaben annehmen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var kt = new KalorienTracker();
            kt.NumberValidationTextBox(null, e);
        }
    }
}
