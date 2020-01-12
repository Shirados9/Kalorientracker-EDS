using FitnessApp.Class;
using System.Windows;
using System.Windows.Controls;


namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für FirstStartup.xaml
    /// </summary>
    public partial class FirstStartup : UserControl
    {
        public FirstStartup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var json = new JsonDeSerializer();
            var mw = new MainWindow();

            var firstStartup = json.DeserializeFirstStartup();
            firstStartup[0].FirstStartupIsSet = true;
            json.Serializer(firstStartup);

            mw.ListViewMenu.SelectedIndex = 0;
            //mw.ChangeGridMain();
        }

        
        
        private void TextBox_Validation(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var kt = new KalorienTracker();
            kt.NumberValidationTextBox(sender, e);
        }
        //public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^a-zA-Zäö]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
