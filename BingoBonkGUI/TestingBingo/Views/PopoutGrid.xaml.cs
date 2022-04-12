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
    /// Interaction logic for PopoutGrid.xaml
    /// </summary>
    /// 
    //Right now the issue is that the Popout grid generates everything again whilst taking commands from the main application essentially so
    //Maybe I can find a way to just copy over the Grid from the MainWindow
    public partial class PopoutGrid : Window
    {
        private List<WrapButton> Buttons = new List<WrapButton>();
        public bool UseImages { get; set; }
        public bool HideText { get; set; }
        public PopoutGrid()
        {
            InitializeComponent();
            GenerateButtons();
        }
        private void GenerateButtons()
        {
            int count = 0;
            //Add btns to list then apply thingy to them... yk what I mean
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    WrapButton butt = new WrapButton();

                    butt.Text = count.ToString();
                    butt.Name = $"B{count}";

                    Grid.SetColumn(butt, j);
                    Grid.SetRow(butt, i);
                    butt.Click += Button_Click;
                    MainGrid.Children.Add(butt);
                    butt.IsClicked = false;
                    butt.Background = Configuration.ButtonDeselectedColor;
                    butt.Foreground = Configuration.ButtonFontColor;
                    count++;
                    Buttons.Add(butt);
                }

            }
        }
        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            WrapButton? wp = sender as WrapButton;
            int buttonIndex = int.Parse(wp.Name.Remove(0, 1));
            Buttons[buttonIndex].IsClicked = !Buttons[buttonIndex].IsClicked;//Toggle on off
            //Make sure we dont cause a fuckin memory leak lmfao... 
            //OK Fixed, Memory leaks are no more

            if (Buttons[buttonIndex].IsClicked)
            {
                Buttons[buttonIndex].Background = Configuration.ButtonSelectedColor;
                if (UseImages)
                    Buttons[buttonIndex].ButtonImage.Visibility = Visibility.Visible;
            }
            else
            {
                Buttons[buttonIndex].Background = Configuration.ButtonDeselectedColor;
                Buttons[buttonIndex].ButtonImage.Visibility = Visibility.Hidden;
            }
        }
        public void FillBoard(List<string> board)
        {
            //This is what you call ((((Exception Handling)))) 
            if (board.Any())
            {
                for (int i = 0; i < 25; i++)
                {
                    Buttons[i].ButtonImage.Visibility = Visibility.Hidden;
                    Buttons[i].Background = Configuration.ButtonDeselectedColor;
                    Buttons[i].Foreground = Configuration.ButtonFontColor;
                    Buttons[i].Text = board[i];
                }
            }
        }
        public void UpdateButtonColors()
        {
            if (UseImages)
            {
                Buttons.Where(x => x.IsClicked).ToList().ForEach(x => x.ButtonImage.Visibility = Visibility.Visible);

                if (HideText)
                    Buttons.Where(x => x.IsClicked).ToList().ForEach(x => x.Foreground = Configuration.ButtonInvisibleFont);
                else
                    Buttons.Where(x => x.IsClicked).ToList().ForEach(x => x.Foreground = Configuration.ButtonFontColor);
            }

            else
                Buttons.Where(x => x.IsClicked).ToList().ForEach(x =>
                {
                    x.Foreground = Configuration.ButtonFontColor;
                    x.Background = Configuration.ButtonSelectedColor;
                    x.ButtonImage.Visibility = Visibility.Hidden;
                });

        }
    }
}
