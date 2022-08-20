using BionicleHeroesBingoGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;
namespace BionicleHeroesBingoGUI
{
    public class WrapButton : Button
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(WrapButton), new PropertyMetadata(string.Empty));
        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }
        public bool IsClicked { get; set; }
        public bool P2Clicked { get; set; }
        public Image ButtonImage { get; private set; } = new Image();
        public WrapButton()
        {
            var textBlock = new TextBlock { TextAlignment = TextAlignment.Center, TextWrapping = TextWrapping.Wrap };
            textBlock.SetBinding(TextBlock.TextProperty, new Binding { Source = this, Path = new PropertyPath("Text") });
            ButtonImage.Stretch = System.Windows.Media.Stretch.UniformToFill;
            ButtonImage.Source = Configuration.BitmapSource;
            Grid g = new Grid();          

            

            textBlock.VerticalAlignment = VerticalAlignment.Center;
            //Grid.SetRow(textBlock, 0);
            ButtonImage.Visibility = Visibility.Hidden;
            g.Children.Add(textBlock);
            g.Children.Add(ButtonImage);
    
            Panel.SetZIndex(textBlock, 10);



            Background = Configuration.TwoPlayerColors;
            Content = g;
            

            if (Configuration.IsGif)
            {
                ButtonImage.Source = null;
                ImageBehavior.SetAnimatedSource(ButtonImage, Configuration.BitmapImage);
            }
            
        }
    }
}
