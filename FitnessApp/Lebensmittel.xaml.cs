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
using System.IO;
using Newtonsoft.Json;
using FitnessApp.Class;
using System.Collections.ObjectModel;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Lebensmittel.xaml
    /// </summary>
    public partial class Lebensmittel : UserControl
    {
        readonly JsonDeSerializer json = new JsonDeSerializer();

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
            var groceryList = json.Deserializer();
            if (groceryList == null) return;

            foreach (var item in groceryList)
            {
                if (item.Name == null) continue;
                var addGrocery = new Groceries
                {
                    Uid = item.Uid,
                    Name = item.Name,
                    Calories = item.Calories,
                    Carbs = item.Carbs,
                    Fats = item.Fats,
                    Protein = item.Protein
                };
                Lebensmitteltabelle.Items.Add(addGrocery);
            }
        }

        #region Manipulate List
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
                foreach(var item in groceryList)
                {
                    if (item.Name == null)
                    {
                        item.Name = NameBox.Text;
                        item.Carbs = double.Parse(CarbsBox.Text);
                        item.Calories = double.Parse(CaloriesBox.Text);
                        item.Fats = double.Parse(FatBox.Text);
                        item.Protein = double.Parse(ProteinBox.Text);
                        json.Serializer(groceryList);
                        ResetTextBoxes();
                        EntrySuccessful.Text = "Essen erfolgreich eingetragen";
                        ReadJson();
                        return;
                    }
                }
                groceryList.Add(new Groceries()
                {
                    Uid = GetFreeUid(groceryList),
                    Name = NameBox.Text,
                    Carbs = double.Parse(CarbsBox.Text),
                    Calories = double.Parse(CaloriesBox.Text),
                    Fats = double.Parse(FatBox.Text),
                    Protein = double.Parse(ProteinBox.Text)
                });
                json.Serializer(groceryList);
                ResetTextBoxes();
                EntrySuccessful.Text = "Essen erfolgreich eingetragen";
                ReadJson();

            }        
        }

        /// <summary>
        /// Löscht Reihe aus der Liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            int uid = int.Parse(((Button)e.Source).Uid);
            var groceryList = json.Deserializer();

            foreach (var item in groceryList)
            {
                if (item.Uid == uid)
                {
                    groceryList.Remove(item);
                    break;
                }
            }

            json.Serializer(groceryList);
            ReadJson();
        }

        /// <summary>
        /// Gibt freie Uid zum erstellen eines Eintrags zurück
        /// </summary>
        /// <param name="groceryList"></param>
        /// <returns></returns>
        private int GetFreeUid(List<Groceries> groceryList)
        {
            int counter = 0;
            foreach (var item in groceryList)
            {
                if (counter != item.Uid) return counter;
                counter++;
            }
            return counter;
        }
        #endregion


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
                EntrySuccessful.Text = "";
                EntryNotSuccessful.Text = "Bitte Namen eingeben";
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
