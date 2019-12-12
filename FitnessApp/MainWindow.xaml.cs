using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using FitnessApp.Class;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartDispatchTimer();
            FirstStartUp();
        }

        private void FirstStartUp()
        {
            var json = new JsonDeSerializer();
            string path = json.GetPathJson("First.json");
            if (!File.Exists(path))
            {
                GridMain.Children.Clear();
                GridMain.Children.Add(new FirstStartup());
            }
            else
            {
                GridMain.Children.Clear();
                GridMain.Children.Add(new KalorienTracker());
            }
        }

        /// <summary>
        /// Startet Dispatch Timer für Uhrzeit und Datum
        /// </summary>
        private void StartDispatchTimer()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Aktuallisiert Zeit und Datum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime.Text = DateTime.Now.ToLongTimeString();
            CurrentDate.Text = DateTime.Now.ToString("dddd , dd.MMM.yyyy");
        }

        /// <summary>
        /// Versteckt Zeit/Datum beim eingeklappten Menü - Zeigt beim ausgeklappten
        /// </summary>
        private void ManageDate()
        {
            if (CurrentDate.Visibility == Visibility.Hidden)
            {
                CurrentDate.Visibility = Visibility.Visible;
                CurrentTime.Visibility = Visibility.Visible;
            }
            else
            {
                CurrentTime.Visibility = Visibility.Hidden;
                CurrentDate.Visibility = Visibility.Hidden;
            }
        }

        #region Navigation
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ManageDate();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ManageDate();
        }

        /// <summary>
        /// Wechselt Fenster je nach ausgewähltem ListViewItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new KalorienTracker());
                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Trainingsplan());
                    break;
                case 2:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Ernährungsplan());
                    break;
                case 3:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Fortschritt());
                    break;
                case 4:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Lebensmittel());
                    break;
                case 5:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Extra());
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
