using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LoL_Observer_Tool.UI.Status
{
    /// <summary>
    /// Interaktionslogik für StatusOffline.xaml
    /// </summary>
    public partial class StatusOffline : UserControl
    {
        public StatusOffline()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
