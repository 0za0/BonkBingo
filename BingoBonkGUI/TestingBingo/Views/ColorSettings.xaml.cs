using System.Windows;
using System.Windows.Forms;
using MColor = System.Windows.Media.Color;
using DColor = System.Drawing.Color;
using BionicleHeroesBingoGUI.Extensions;

namespace BionicleHeroesBingoGUI.Views
{
    /// <summary>
    /// Interaction logic for ColorSettings.xaml
    /// </summary>
    public partial class ColorSettings : Window
    {
        public ColorSettings()
        {
            InitializeComponent();
            ChangeFontColorButton.Background = Configuration.ButtonFontColor;
            TileColorButton.Background = Configuration.ButtonDeselectedColor;
            TileSelectedColorButton.Background = Configuration.ButtonSelectedColor;

        }
        //Please change this at some point I beg you
        private void FontColorButtonClick(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = ColorConverter.ToDrawingColor(Configuration.ButtonFontColor.Color);
            dlg.ShowDialog();
            Configuration.ButtonFontColor = new System.Windows.Media.SolidColorBrush(ColorConverter.ToMediaColor(dlg.Color));
            ChangeFontColorButton.Background = Configuration.ButtonFontColor;
            Configuration.UpdateBonkFile();
        }
        private void TileColorButtonClick(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = ColorConverter.ToDrawingColor(Configuration.ButtonFontColor.Color);
            dlg.ShowDialog();
            Configuration.ButtonDeselectedColor = new System.Windows.Media.SolidColorBrush(ColorConverter.ToMediaColor(dlg.Color));
            TileColorButton.Background = Configuration.ButtonDeselectedColor;
            Configuration.UpdateBonkFile();
        }
        private void TileSelectedColorButtonClick(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = ColorConverter.ToDrawingColor(Configuration.ButtonFontColor.Color);
            dlg.ShowDialog();
            Configuration.ButtonSelectedColor = new System.Windows.Media.SolidColorBrush(ColorConverter.ToMediaColor(dlg.Color));
            TileSelectedColorButton.Background = Configuration.ButtonSelectedColor;
            Configuration.UpdateBonkFile();
        }
    }
}
