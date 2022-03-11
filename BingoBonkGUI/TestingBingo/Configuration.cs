using System.Windows.Media;
using System.IO;

namespace BionicleHeroesBingoGUI
{
    //This is the biggest placeholder imaginable 
    static class Configuration
    {
        public static SolidColorBrush ButtonDeselectedColor { get; private set; }
        public static SolidColorBrush ButtonSelectedColor { get; private set; }
        public static SolidColorBrush ButtonFontColor { get; private set; }

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
    }
}
