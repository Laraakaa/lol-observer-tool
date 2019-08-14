using System.Windows;
using System.Windows.Controls;
using LoL_Observer_Tool.UI.Settings;

namespace LoL_Observer_Tool.UI
{
    /// <summary>
    /// Interaktionslogik für MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow().Show();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void MenuItem_Options_Click(object sender, RoutedEventArgs e)
        {
            new Controller.Controller().ShowDialog();
        }
    }
}
