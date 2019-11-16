using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Fortschritt.xaml
    /// </summary>
    public partial class Fortschritt : UserControl
    {
        public Fortschritt()
        {
            InitializeComponent();
        }
        public double GetProteinsZiel()
        {
            return Convert.ToDouble(ProteinsZiel.Text);
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

    }
}
