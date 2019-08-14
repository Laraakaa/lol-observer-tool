using System.Reflection;
using System.Windows.Controls;

namespace LoL_Observer_Tool.UI
{
    /// <summary>
    /// Interaktionslogik für StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();

            lblVersion.Text = "LoL Observer Tool " + Assembly.GetEntryAssembly().GetName().Version.ToString() + " by Larce";
        }
    }
}
