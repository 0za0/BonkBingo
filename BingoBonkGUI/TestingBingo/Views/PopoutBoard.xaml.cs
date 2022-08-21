using BionicleHeroesBingoGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BionicleHeroesBingoGUI.Views
{
    /// <summary>
    /// Interaction logic for PopoutBoard.xaml
    /// </summary>
    public partial class PopoutBoard : Window
    {
        public List<WrapButton> Buttons = new List<WrapButton>();
        private RoutedEventHandler btn;
        public PopoutBoard(RoutedEventHandler btn)
        {
            this.btn = btn;
            InitializeComponent();
            GenerateButtons();
        }
        private void GenerateButtons()
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    WrapButton butt = new WrapButton();

                    butt.Text = count.ToString();
                    butt.Name = $"B{count}";

                    Grid.SetColumn(butt, j);
                    Grid.SetRow(butt, i);

                    butt.Click += btn;
                    MainGrid.Children.Add(butt);
                    butt.IsClicked = false;
                    butt.Background = Configuration.ButtonDeselectedColor;
                    butt.Foreground = Configuration.ButtonFontColor;
                    count++;
                    Buttons.Add(butt);
                }

            }
        }
        public void FillBoard(List<string> board)
        {
            //This is what you call ((((Exception Handling)))) 
            if (board.Any())
            {
                for (int i = 0; i < 25; i++)
                {
                    //Buttons[i].ButtonImage.Visibility = Visibility.Hidden;
                    //Buttons[i].Background = Configuration.ButtonDeselectedColor;
                    //Buttons[i].Foreground = Configuration.ButtonFontColor;
                    Buttons[i].Text = board[i];
                }
            }
        }
    }
}
