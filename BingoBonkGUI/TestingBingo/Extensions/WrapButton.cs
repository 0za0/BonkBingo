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
            Grid g = new Grid();
            UniformGrid sp = new UniformGrid();
            //RowDefinition x = new RowDefinition();
            //x.Height = new GridLength(0, GridUnitType.Star);
            //RowDefinition y = new RowDefinition();
            //y.Height = new GridLength(0, GridUnitType.Star);

            

            textBlock.VerticalAlignment = VerticalAlignment.Center;
            //Grid.SetRow(textBlock, 0);
            g.Children.Add(textBlock);
            g.Children.Add(sp);
    
            Panel.SetZIndex(textBlock, 10);



            //Rectangle r = new Rectangle();
            //r.Height = 100;
            //r.Width=100;
            //r.HorizontalAlignment = HorizontalAlignment.Stretch;
            //r.Stretch = System.Windows.Media.Stretch.Uniform;
            //r.Fill = System.Windows.Media.Brushes.SkyBlue;


            //Rectangle r2 = new Rectangle();
            //r2.Height = 100;
            //r2.Width = 100;
            //r2.HorizontalAlignment = HorizontalAlignment.Stretch;
            //r2.Stretch = System.Windows.Media.Stretch.Uniform;
            //r2.Fill = System.Windows.Media.Brushes.Red;

            //Rectangle r3 = new Rectangle();
            //r3.Height = 100;
            //r3.Width = 100;
            //r3.HorizontalAlignment = HorizontalAlignment.Stretch;
            //r3.Stretch = System.Windows.Media.Stretch.Uniform;
            //r3.Fill = System.Windows.Media.Brushes.Black;
            ////ButtonImage.Visibility = Visibility.Hidden;
            ////Grid.SetRow(r, 1);

            //sp.Children.Add(r);
            //sp.Children.Add(r2);
            //sp.Children.Add(r3);
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
