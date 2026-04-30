using Microsoft.Win32;
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
            LoadGamesIntoList(); // Replaces the inline data loading block
        }

        private void LoadGamesIntoList()
        {
            listGames.Items.Clear(); // Clear existing items before reloading
            DatabaseHandler databaseHandler = new();
            List<Game> games = databaseHandler.GetGames();
            foreach (var game in games)
            {
                listGames.Items.Add(game);
                editId.Text = game.Id.ToString();
                editName.Text = game.Name;
                gameDescription.Text = game.Description;
                editDesc.Text = game.Description;
                releasedate.Text = game.ReleaseDate.Date.ToString("MM/dd/yyyy");
                editDate.SelectedDate = game.ReleaseDate.Date;
                developer.Text = game.Developer;
                editDev.Text = game.Developer;
                publisher.Text = game.Publisher;
                editPub.Text = game.Publisher;
                editAge.Text = game.AgeRating.ToString();
                agereason1.Text = game.AgeReason1;
                editAgeReason1.Text = game.AgeReason1;
                agereason2.Text = game.AgeReason2;
                editAgeReason2.Text = game.AgeReason2;
                agereason3.Text = game.AgeReason3;
                editAgeReason3.Text = game.AgeReason3;
                byte[] imageData = HexToBytes(game.MainImg);
                thumbnail.Source = LoadImage(imageData);
                editThumbnail.Source = LoadImage(imageData);
                byte[] image1Data = HexToBytes(game.img1);
                img1.Source = LoadImage(image1Data);
                editImg1.Source = LoadImage(image1Data);
                //ImageSelection.Items.Add(image1Data);
                byte[] image2Data = HexToBytes(game.img2);
                img2.Source = LoadImage(image2Data);
                editImg2.Source = LoadImage(image2Data);
                byte[] image3Data = HexToBytes(game.img3);
                img3.Source = LoadImage(image3Data);
                editImg3.Source = LoadImage(image3Data);
                byte[] image4Data = HexToBytes(game.img4);
                img4.Source = LoadImage(image4Data);
                editImg4.Source = LoadImage(image4Data);
                byte[] image5Data = HexToBytes(game.img5);
                img5.Source = LoadImage(image5Data);
                editImg5.Source = LoadImage(image5Data);
                byte[] image6Data = HexToBytes(game.img6);
                img6.Source = LoadImage(image6Data);
                editImg6.Source = LoadImage(image6Data);
                imgMain.Source = img1.Source;
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
                editId.Text = selected.Id.ToString();
                editName.Text = selected.Name;
                gameDescription.Text = selected.Description;
                editDesc.Text = selected.Description;
                releasedate.Text = selected.ReleaseDate.Date.ToString("MM/dd/yyyy");
                editDate.SelectedDate = selected.ReleaseDate.Date;
                //editDate.Text = selected.ReleaseDate.Date.ToString("MM/dd/yyyy");
                developer.Text= selected.Developer;
                editDev.Text = selected.Developer;
                publisher.Text = selected.Publisher;
                editPub.Text = selected.Publisher;
                editAge.Text = selected.AgeRating.ToString();
                agereason1.Text = selected.AgeReason1;
                editAgeReason1.Text = selected.AgeReason1;
                agereason2.Text = selected.AgeReason2;
                editAgeReason2.Text = selected.AgeReason2;
                agereason3.Text = selected.AgeReason3;
                editAgeReason3.Text = selected.AgeReason3;
                byte[] imageData = HexToBytes(selected.MainImg);
                thumbnail.Source = LoadImage(imageData);
                editThumbnail.Source = LoadImage(imageData);
                byte[] image1Data = HexToBytes(selected.img1);
                img1.Source = LoadImage(image1Data);
                editImg1.Source = LoadImage(image1Data);
                byte[] image2Data = HexToBytes(selected.img2);
                img2.Source = LoadImage(image2Data);
                editImg2.Source = LoadImage(image2Data);
                byte[] image3Data = HexToBytes(selected.img3);
                img3.Source = LoadImage(image3Data);
                editImg3.Source = LoadImage(image3Data);
                byte[] image4Data = HexToBytes(selected.img4);
                img4.Source = LoadImage(image4Data);
                editImg4.Source = LoadImage(image4Data);
                byte[] image5Data = HexToBytes(selected.img5);
                img5.Source = LoadImage(image5Data);
                editImg5.Source = LoadImage(image5Data);
                byte[] image6Data = HexToBytes(selected.img6);
                img6.Source = LoadImage(image6Data);
                editImg6.Source = LoadImage(image6Data);
                imgMain.Source = img1.Source;  
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
            Image selected = null;
            if (ImageSelection.SelectedItem != null)
            {
                selected = (Image)ImageSelection.SelectedItem;
                imgMain.Source = selected.Source;
            }
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

        private void thumbnail_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename.Text = filename;
                editThumbnail.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void Img1_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename1.Text = filename;
                editImg1.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void Img2_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename2.Text = filename;
                editImg2.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void Img3_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename3.Text = filename;
                editImg3.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void Img4_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename4.Text = filename;
                editImg4.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void Img5_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename5.Text = filename;
                editImg5.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void Img6_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Downloads"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                editFilename6.Text = filename;
                editImg6.Source = new BitmapImage(new Uri($"{filename}", UriKind.Absolute));
            }
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Game newGame = new Game();
            newGame.Name = editName.Text;
            newGame.Description = editDesc.Text;
            newGame.ReleaseDate = editDate.SelectedDate.Value;
            newGame.Developer = editDev.Text;
            newGame.Publisher = editPub.Text;
            newGame.AgeRating = int.Parse(editAge.Text);
            newGame.AgeReason1 = editAgeReason1.Text;
            newGame.AgeReason2 = editAgeReason2.Text;
            newGame.AgeReason3 = editAgeReason3.Text;
            // half AI! Read an image file from your PC and convert it to hex for your object
            if (File.Exists(editFilename.Text))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(editFilename.Text);
                newGame.MainImg = Convert.ToHexString(fileBytes);
            }

            if (File.Exists(editFilename1.Text))
            {
                byte[] fileBytes1 = System.IO.File.ReadAllBytes(editFilename1.Text);
                newGame.img1 = Convert.ToHexString(fileBytes1);
            }

            if (File.Exists(editFilename2.Text))
            {
                byte[] fileBytes2 = System.IO.File.ReadAllBytes(editFilename2.Text);
                newGame.img2 = Convert.ToHexString(fileBytes2);
            }

            if (File.Exists(editFilename3.Text))
            {
                byte[] fileBytes3 = System.IO.File.ReadAllBytes(editFilename3.Text);
                newGame.img3 = Convert.ToHexString(fileBytes3);
            }

            if (File.Exists(editFilename4.Text))
            {
                byte[] fileBytes4 = System.IO.File.ReadAllBytes(editFilename4.Text);
                newGame.img4 = Convert.ToHexString(fileBytes4);
            }

            if (File.Exists(editFilename5.Text))
            {
                byte[] fileBytes5 = System.IO.File.ReadAllBytes(editFilename5.Text);
                newGame.img5 = Convert.ToHexString(fileBytes5);
            }

            if (File.Exists(editFilename6.Text))
            {
                byte[] fileBytes6 = System.IO.File.ReadAllBytes(editFilename6.Text);
                newGame.img6 = Convert.ToHexString(fileBytes6);
            }

            DatabaseHandler db = new DatabaseHandler();
            db.MakeGame(newGame);

            LoadGamesIntoList();
        }

        private void UpdateGame_Click(object sender, RoutedEventArgs e)
        {
            Game newGame = new Game();
            newGame.Id = int.Parse(editId.Text);
            newGame.Name = editName.Text;
            newGame.Description = editDesc.Text;
            newGame.ReleaseDate = editDate.SelectedDate.Value;
            newGame.Developer = editDev.Text;
            newGame.Publisher = editPub.Text;
            newGame.AgeRating = int.Parse(editAge.Text);
            newGame.AgeReason1 = editAgeReason1.Text;
            newGame.AgeReason2 = editAgeReason2.Text;
            newGame.AgeReason3 = editAgeReason3.Text;
            // half AI! Read an image file from your PC and convert it to hex for your object
            if (File.Exists(editFilename.Text))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(editFilename.Text);
                newGame.MainImg = Convert.ToHexString(fileBytes);
            }
            else if (listGames.SelectedItem is Game g)
            {
                newGame.MainImg = g.MainImg;
            }

            if (File.Exists(editFilename1.Text))
            {
                byte[] fileBytes1 = System.IO.File.ReadAllBytes(editFilename1.Text);
                newGame.img1 = Convert.ToHexString(fileBytes1);
            }
            else if (listGames.SelectedItem is Game g1)
            {
                newGame.img1 = g1.img1;
            }

            if (File.Exists(editFilename2.Text))
            {
                byte[] fileBytes2 = System.IO.File.ReadAllBytes(editFilename2.Text);
                newGame.img2 = Convert.ToHexString(fileBytes2);
            }
            else if (listGames.SelectedItem is Game g2)
            {
                newGame.img2 = g2.img2;
            }

            if (File.Exists(editFilename3.Text))
            {
                byte[] fileBytes3 = System.IO.File.ReadAllBytes(editFilename3.Text);
                newGame.img3 = Convert.ToHexString(fileBytes3);
            }
            else if (listGames.SelectedItem is Game g3)
            {
                newGame.img3 = g3.img3;
            }

            if (File.Exists(editFilename4.Text))
            {
                byte[] fileBytes4 = System.IO.File.ReadAllBytes(editFilename4.Text);
                newGame.img4 = Convert.ToHexString(fileBytes4);
            }
            else if (listGames.SelectedItem is Game g4)
            {
                newGame.img4 = g4.img4;
            }

            if (File.Exists(editFilename5.Text))
            {
                byte[] fileBytes5 = System.IO.File.ReadAllBytes(editFilename5.Text);
                newGame.img5 = Convert.ToHexString(fileBytes5);
            }
            else if (listGames.SelectedItem is Game g5)
            {
                newGame.img5 = g5.img5;
            }

            if (File.Exists(editFilename6.Text))
            {
                byte[] fileBytes6 = System.IO.File.ReadAllBytes(editFilename6.Text);
                newGame.img6 = Convert.ToHexString(fileBytes6);
            }
            else if (listGames.SelectedItem is Game g6)
            {
                newGame.img6 = g6.img6;
            }

            DatabaseHandler db = new DatabaseHandler();
            db.UpdateGame(newGame);

            LoadGamesIntoList();
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