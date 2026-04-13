using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;
using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace GameApp.GUI
{
    class Game
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
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
        // Source - https://stackoverflow.com/a/8280457
        // Posted by Sasha
        // Retrieved 2026-04-13, License - CC BY-SA 3.0

        public static Image ConvertToImage(Stream stream)
        {
            try
            {
                return Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                throw new Exception("Abe");
            }
        }

    }
}
