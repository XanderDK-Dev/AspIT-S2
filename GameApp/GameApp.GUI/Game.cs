using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GameApp.GUI
{
    public class Game
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Developer { get; set; } = string.Empty;
        public string Publisher {  get; set; } = string.Empty;
        public int AgeRating { get; set; }
        public string AgeReason1 { get; set; } = string.Empty;
        public string AgeReason2 { get; set; } = string.Empty;
        public string AgeReason3 { get; set; } = string.Empty;
        public string MaingImgName {  get; set; } = string.Empty;
        public string MainImg {  get; set; } = string.Empty;
        public string img1name {  get; set; } = string.Empty;
        public string img1 {  get; set; } = string.Empty;
        public string img2name {  get; set; } = string.Empty;
        public string img2 {  get; set; } = string.Empty;
        public string img3name {  get; set; } = string.Empty;
        public string img3 {  get; set; } = string.Empty;
        public string img4name {  get; set; } = string.Empty;
        public string img4 {  get; set; } = string.Empty;
        public string img5name {  get; set; } = string.Empty;
        public string img5 {  get; set; } = string.Empty;
        public string img6name {  get; set; } = string.Empty;
        public string img6 {  get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Name}";
        }
        /* 
    public static Image ConvertToImage(byte[] arr)
    {
        var image = new Image();


        Convert the image (Windows.Controls) Not (Windows.Drawing or System.Drawing or what it's called)
        Load that into image.Source, and wow you got an image, you then return that image, and use it.
        Just like you used that nugget of yours to read this amazing paice of text. right...
        Good luck :D *SEAL.png*

        Use google, and stackoverflow. Trust me, you are gonna get good at converting images... cause it will not be the last time you are going -
        to need it, cause WPF is shit. Just like you, jk.. ahhahahah.

        Now go do code, go be a code-monkey.

                      __
         w  c(..)o   (
          \__(-)    __)
              /\   (
             /(_)___)
             w /|
              | \
    ejm97    m  m


            - Nick, that person that idk kinda coool :D, yes just "Trust me"

        return image ;
    }
        */


        // AI
        // 1. Convert Hex String to Byte Array
        public byte[] HexToBytes(string hex)
        {
            // Remove 0x if present
            if (hex.StartsWith("0x")) hex = hex.Substring(2);

            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
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

    }
}
