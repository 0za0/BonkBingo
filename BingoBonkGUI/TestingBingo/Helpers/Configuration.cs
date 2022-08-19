using System.Windows.Media;
using System.IO;
using System;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;
using MColor = System.Windows.Media.Color;

namespace BionicleHeroesBingoGUI.Helpers
{
    //This is the biggest placeholder imaginable 
    public static class Configuration
    {
        public static string ImagePath { get; set; }
        public static bool IsGif { get; private set; }
        public static SolidColorBrush ButtonDeselectedColor { get; set; } = new SolidColorBrush(MColor.FromArgb(0, 0, 0, 0));
        public static SolidColorBrush ButtonSelectedColor { get; set; } = new SolidColorBrush(MColor.FromArgb(0, 0, 0, 0));
        public static SolidColorBrush ButtonSelectedColorP2 { get; set; } = new SolidColorBrush(MColor.FromArgb(125, 0, 0, 0));
        public static SolidColorBrush ButtonFontColor { get; set; } = new SolidColorBrush(MColor.FromArgb(0, 0, 0, 0));

        public static SolidColorBrush ButtonInvisibleFont = new SolidColorBrush(MColor.FromArgb(0, 0, 0, 0));
        public static BitmapImage BitmapImage { get; set; } = new BitmapImage();
        public static ImageSource BitmapSource { get; private set; }
        public static LinearGradientBrush TwoPlayerColors =new LinearGradientBrush();

        public static void LoadColorConfig()
        {
            ImagePath = "Test";
            var allLines = File.ReadAllLines("config.bonk");

            var RGBData = allLines[0].Split("=")[1].Split(",");
            ButtonDeselectedColor = new SolidColorBrush(MColor.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));

            RGBData = allLines[1].Split("=")[1].Split(",");
            ButtonSelectedColor = new SolidColorBrush(MColor.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));

            RGBData = allLines[2].Split("=")[1].Split(",");
            ButtonFontColor = new SolidColorBrush(MColor.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));

            RGBData = allLines[3].Split("=")[1].Split(",");
            ButtonSelectedColorP2 = new SolidColorBrush(MColor.FromRgb(byte.Parse(RGBData[0]), byte.Parse(RGBData[1]), byte.Parse(RGBData[2])));

            TwoPlayerColors.StartPoint = new System.Windows.Point(0, 0);
            TwoPlayerColors.EndPoint = new System.Windows.Point(1, 1);
            TwoPlayerColors.GradientStops.Add(new GradientStop(ButtonSelectedColor.Color, 0.49));
            TwoPlayerColors.GradientStops.Add(new GradientStop(Colors.Black, 0.495));
            TwoPlayerColors.GradientStops.Add(new GradientStop(Colors.Black, 0.505));
            TwoPlayerColors.GradientStops.Add(new GradientStop(ButtonSelectedColorP2.Color, 0.505));

        }
        //I am cheesing this so fucking hard
        //No I wont do it properly, I just want to get it to work rn shut up
        internal static void UpdateBonkFile()
        {
            var text = File.ReadAllLines("config.bonk");
            string[] fileToWrite = new string[4];
            fileToWrite[0] = $"TileColor={ButtonDeselectedColor.Color.R},{ButtonDeselectedColor.Color.G},{ButtonDeselectedColor.Color.B}";
            fileToWrite[1] = $"TileClickedColor={ButtonSelectedColor.Color.R},{ButtonSelectedColor.Color.G},{ButtonSelectedColor.Color.B}";
            fileToWrite[2] = $"FontColor={ButtonFontColor.Color.R},{ButtonFontColor.Color.G},{ButtonFontColor.Color.B}";
            fileToWrite[3] = $"Player2Color={ButtonSelectedColorP2.Color.R},{ButtonSelectedColorP2.Color.G},{ButtonSelectedColorP2.Color.B}";
            //I only did it this way because fuckass File.WriteAllLines wasnt fucking working
            using (StreamWriter sw = new StreamWriter("config.bonk"))
            {
                sw.WriteLine(fileToWrite[0]);
                sw.WriteLine(fileToWrite[1]);
                sw.WriteLine(fileToWrite[2]);
                sw.WriteLine(fileToWrite[3]);
            }
            TwoPlayerColors.StartPoint = new System.Windows.Point(0, 0);
            TwoPlayerColors.EndPoint = new System.Windows.Point(1, 1);
            TwoPlayerColors.GradientStops.Add(new GradientStop(ButtonSelectedColor.Color, 0.49));
            TwoPlayerColors.GradientStops.Add(new GradientStop(Colors.Black, 0.495));
            TwoPlayerColors.GradientStops.Add(new GradientStop(Colors.Black, 0.505));
            TwoPlayerColors.GradientStops.Add(new GradientStop(ButtonSelectedColorP2.Color, 0.505));
            //TryGetImage();
        }
        internal static void TryGetImage()
        {
            if (File.Exists(Path.GetFullPath(ImagePath)))
            {
                IsGif = Path.GetExtension(ImagePath) == ".gif";
                if (IsGif)
                {
                    var stream = new MemoryStream(File.ReadAllBytes(ImagePath));
                    BitmapImage = new BitmapImage();
                    BitmapImage.BeginInit();
                    BitmapImage.StreamSource = stream;
                    BitmapImage.EndInit();

                }
                else
                {
                    Image image = Image.FromFile(ImagePath.Replace('\\', '/'));
                    Bitmap bitmap = new Bitmap(image);
                    BitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    bitmap.Dispose();

                }
            }
        }
    }
}
