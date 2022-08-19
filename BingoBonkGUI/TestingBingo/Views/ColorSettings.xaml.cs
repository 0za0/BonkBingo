using System.IO;
using System.Windows;
using System.Windows.Forms;
using BionicleHeroesBingoGUI.Extensions;
using BionicleHeroesBingoGUI.Helpers;

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
            Player2ColorButton.Background = Configuration.ButtonSelectedColorP2;

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
        private void Player2ColorButtonClick(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = ColorConverter.ToDrawingColor(Configuration.ButtonFontColor.Color);
            dlg.ShowDialog();
            Configuration.ButtonSelectedColorP2 = new System.Windows.Media.SolidColorBrush(ColorConverter.ToMediaColor(dlg.Color));
            Player2ColorButton.Background = Configuration.ButtonSelectedColorP2;
            Configuration.UpdateBonkFile();
        }
        private void LoadImageButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog.InitialDirectory = Path.Join(Directory.GetCurrentDirectory(), "Resources");
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Get the path of specified file
                Configuration.ImagePath = Path.GetRelativePath(Directory.GetCurrentDirectory(),openFileDialog.FileName);
                PathText.Text = Configuration.ImagePath;
                Configuration.UpdateBonkFile();
            }
        }
    }
}
