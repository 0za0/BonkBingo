using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BionicleHeroesBingoGUI
{
    internal class WrapButton: Button
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(WrapButton), new PropertyMetadata(string.Empty));
        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }
        public bool IsClicked { get; set; }
        public WrapButton()
        {
            var textBlock = new TextBlock { TextAlignment = TextAlignment.Center, TextWrapping = TextWrapping.Wrap };
            textBlock.SetBinding(TextBlock.TextProperty, new Binding { Source = this, Path = new PropertyPath("Text") });
            Content = textBlock;
        }
    }
}
