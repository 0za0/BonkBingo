using BionicleHeroesBingoGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
namespace BionicleHeroesBingoGUI
{
    internal class WrapButton : Button
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(WrapButton), new PropertyMetadata(string.Empty));
        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }
        public bool IsClicked { get; set; }
        public Image ButtonImage { get; private set; } = new Image();
        public WrapButton()
        {
            var textBlock = new TextBlock { TextAlignment = TextAlignment.Center, TextWrapping = TextWrapping.Wrap };
            textBlock.SetBinding(TextBlock.TextProperty, new Binding { Source = this, Path = new PropertyPath("Text") });
            ButtonImage.Stretch = System.Windows.Media.Stretch.UniformToFill;
            ButtonImage.Source = Configuration.BitmapSource;
            Grid sp = new Grid();
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            sp.Children.Add(textBlock);
            Panel.SetZIndex(textBlock, 10);
            ButtonImage.Visibility = Visibility.Hidden;
            sp.Children.Add(ButtonImage);
            Content = sp;

            if (Configuration.IsGif)
            {
                ButtonImage.Source = null;
                ImageBehavior.SetAnimatedSource(ButtonImage, Configuration.BitmapImage);
            }
            
        }
    }
}
