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

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für Trainingsplan.xaml
    /// </summary>
    public partial class Trainingsplan : UserControl
    {
        public Trainingsplan()
        {
            InitializeComponent();
            LoadDefault();
        }

        private void LoadDefault()
        {
            GridMain.Children.Add(new BeginnerWorkout());
            GridCursor.SetValue(Grid.ColumnProperty, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new BeginnerWorkout());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new AdvancedWorkout());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                case 2:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new ExpertWorkout());
                    GridCursor.SetValue(Grid.ColumnProperty, index);
                    break;
                default:
                    break;
            }
        }
    }
}
