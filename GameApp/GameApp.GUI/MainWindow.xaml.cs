using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameApp.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // MADE WITH AI!!
        //private const double BaseWidth = 1000.0;
        //private const double BaseHeight = 600.0;
        //
        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    double scaleX = e.NewSize.Width / BaseWidth;
        //    double scaleY = e.NewSize.Height / BaseHeight;
        //
        //    // Use the smaller to keep aspect ratio (nothing gets stretched)
        //    double scale = Math.Min(scaleX, scaleY);
        //
        //    // Only scale UP, never down (clipping handles the small case)
        //    scale = Math.Max(1.0, scale);
        //
        //    MainContent.LayoutTransform = new ScaleTransform(scale, scale);
        //}
    }
}