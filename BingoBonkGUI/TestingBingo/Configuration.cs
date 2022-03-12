using System.Windows.Media;
using System.IO;
using System;
using System.Windows;
using System.Text;

namespace BionicleHeroesBingoGUI
{
    //This is the biggest placeholder imaginable 
    static class Configuration
    {
        public static SolidColorBrush ButtonDeselectedColor { get; set; }
        public static SolidColorBrush ButtonSelectedColor { get; set; }
        public static SolidColorBrush ButtonFontColor { get; set; }
        public static SolidColorBrush ButtonInvisibleFont = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


        public static void LoadColorConfig()
        {
            var allLines = File.ReadAllLines("config.bonk");

            var RGBData = allLines[0].Split("=")[1].Split(",");
            ButtonDeselectedColor = new SolidColorBrush(Color.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));

            RGBData = allLines[1].Split("=")[1].Split(",");
            ButtonSelectedColor = new SolidColorBrush(Color.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));

            RGBData = allLines[2].Split("=")[1].Split(",");
            ButtonFontColor = new SolidColorBrush(Color.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));
        }
        //I am cheesing this so fucking hard
        //No I wont do it properly, I just want to get it to work rn shut up
        internal static void UpdateBonkFile()
        {
            var text = File.ReadAllLines("config.bonk");
            string[] fileToWrite = new string[3];
            fileToWrite[0] = $"TileColor={ButtonDeselectedColor.Color.R},{ButtonDeselectedColor.Color.G},{ButtonDeselectedColor.Color.B}";
            fileToWrite[1] = $"TileClickedColor={ButtonSelectedColor.Color.R},{ButtonSelectedColor.Color.G},{ButtonSelectedColor.Color.B}";
            fileToWrite[2] = $"FontColor={ButtonFontColor.Color.R},{ButtonFontColor.Color.G},{ButtonFontColor.Color.B}";
            using (StreamWriter sw = new StreamWriter("config.bonk"))
            {
                sw.WriteLine(fileToWrite[0]);
                sw.WriteLine(fileToWrite[1]);
                sw.WriteLine(fileToWrite[2]);
            }    
        }
    }
}
