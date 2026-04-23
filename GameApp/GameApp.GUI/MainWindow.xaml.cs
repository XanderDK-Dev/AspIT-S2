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
                byte[] imageData = HexToBytes(game.MainImg);
                thumbnail.Source = LoadImage(imageData);
                byte[] image1Data = HexToBytes(game.img1);
                img1.Source = LoadImage(image1Data);
                ImageSelection.Items.Add(image1Data);
                //byte[] image2Data = HexToBytes(game.img2);
                //img2.Source = LoadImage(image2Data);
                //byte[] image3Data = HexToBytes(game.img3);
                //img3.Source = LoadImage(image3Data);
                //byte[] image4Data = HexToBytes(game.img4);
                //img4.Source = LoadImage(image4Data);
                //byte[] image5Data = HexToBytes(game.img5);
                //img5.Source = LoadImage(image5Data);
                //byte[] image6Data = HexToBytes(game.img6);
                //img6.Source = LoadImage(image6Data);
                //imgMain.Source = img1.Source;
                if (game.AgeRating == 18)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/PEGI_18.svg.png", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (game.AgeRating == 16)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/age-16-black.jpg", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (game.AgeRating == 12)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/PEGI_12.svg.png", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (game.AgeRating == 7)
                {
                    BitmapImage image = new BitmapImage(new Uri("Images/age-7-black.jpg", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (game.AgeRating == 3)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/PEGI_3.svg.png", UriKind.Relative));
                    ageratingimg.Source = image;
                }
            }
        }
        private byte[] HexToBytes(string hexString)
        {
            if (string.IsNullOrWhiteSpace(hexString))
                return Array.Empty<byte>();

            return Convert.FromHexString(hexString);
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
                //byte[] imageData = HexToBytes(selected.MainImg);
                //thumbnail.Source = LoadImage(imageData);
                //byte[] image1Data = HexToBytes(selected.img1);
                //img1.Source = LoadImage(image1Data);
                //byte[] image2Data = HexToBytes(selected.img2);
                //img2.Source = LoadImage(image2Data);
                //byte[] image3Data = HexToBytes(selected.img3);
                //img3.Source = LoadImage(image3Data);
                //byte[] image4Data = HexToBytes(selected.img4);
                //img4.Source = LoadImage(image4Data);
                //byte[] image5Data = HexToBytes(selected.img5);
                //img5.Source = LoadImage(image5Data);
                //byte[] image6Data = HexToBytes(selected.img6);
                //img6.Source = LoadImage(image6Data);
                //imgMain.Source = img1.Source;  
                if (selected.AgeRating == 18)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/PEGI_18.svg.png", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (selected.AgeRating == 16)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/age-16-black.jpg", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (selected.AgeRating == 12)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/age-12-black.jpg", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (selected.AgeRating == 7)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/age-7-black.jpg", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                else if (selected.AgeRating == 3)
                {
                    BitmapImage image = new BitmapImage(new Uri("/Images/PEGI_3.svg.png", UriKind.Relative));
                    ageratingimg.Source = image;
                }
                /*
                int len = selected.MainImg.Length;
                byte[] thumbnailImage = new byte[len];
                for(int i = 0; i < len; i++)
                    thumbnailImage[i] = (byte)i;

                Image thumbnail = Game.ConvertToImage(thumbnailImage);
                */
            }
        }
        private void ImageSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // 2. Convert Byte Array to BitmapImage for WPF
        public BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad; // Important for MemoryStreams
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze(); // Makes it thread-safe and improves performance
            return image;
        }



        private void img_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            imgMain.Source = new BitmapImage(new Uri(@$"", UriKind.Absolute));
        }

        //private void Img1_Click(object sender, RoutedEventArgs e)
        //{
        //    imgMain.Source = img1.Source;
        //}

        //private void Img2_Click(object sender, RoutedEventArgs e)
        //{
        //    imgMain.Source = img2.Source;
        //}
        //private void Img3_Click(object sender, RoutedEventArgs e)
        //{
        //    imgMain.Source = img3.Source;
        //}
        //private void Img4_Click(object sender, RoutedEventArgs e)
        //{
        //    imgMain.Source = img4.Source;
        //}
        //private void Img5_Click(object sender, RoutedEventArgs e)
        //{
        //    imgMain.Source = img5.Source;
        //}
        //private void Img6_Click(object sender, RoutedEventArgs e)
        //{
        //    imgMain.Source = img6.Source;
        //}





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