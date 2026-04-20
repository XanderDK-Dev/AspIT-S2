using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

            DatabaseHandler databaseHandler = new();
            List<Game> games = databaseHandler.GetGames();
            foreach (var game in games)
            {
                listGames.Items.Add(game);
                gameDescription.Text = game.Description;
                releasedate.Text = game.ReleaseDate.Date.ToString("MM/dd/yyyy");
                developer.Text = game.Developer;
                publisher.Text = game.Publisher;
                agereason1.Text = game.AgeReason1;
                agereason2.Text = game.AgeReason2;
                agereason3.Text = game.AgeReason3;
            }
        }

        private void listGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selected = null;
            if (listGames.SelectedItem != null)
            {
                selected = (Game)listGames.SelectedItem;
                gameDescription.Text = selected.Description;
                releasedate.Text = selected.ReleaseDate.Date.ToString("MM/dd/yyyy");
                developer.Text= selected.Developer;
                publisher.Text = selected.Publisher;
                agereason1.Text = selected.AgeReason1;
                agereason2.Text = selected.AgeReason2;
                agereason3.Text = selected.AgeReason3;
                int len = selected.MainImg.Length;
                byte[] thumbnailImage = new byte[len];
                for(int i = 0; i < len; i++)
                    thumbnailImage[i] = (byte)i;

                Image thumbnail = Game.ConvertToImage(thumbnailImage);
            }
        }
        

        private void img_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"", UriKind.Absolute));
        }

        private void Img1_Click(object sender, RoutedEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"{img1.Source}", UriKind.Absolute));
        }

        private void Img2_Click(object sender, RoutedEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"{img2.Source}", UriKind.Absolute));
        }
        private void Img3_Click(object sender, RoutedEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"{img3.Source}", UriKind.Absolute));
        }
        private void Img4_Click(object sender, RoutedEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"{img4.Source}", UriKind.Absolute));
        }
        private void Img5_Click(object sender, RoutedEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"{img5.Source}", UriKind.Absolute));
        }
        private void Img6_Click(object sender, RoutedEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"{img6.Source}", UriKind.Absolute));
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