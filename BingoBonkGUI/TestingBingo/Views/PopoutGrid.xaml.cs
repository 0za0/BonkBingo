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
               
                if (UseImages)
                    Buttons[buttonIndex].Background = new ImageBrush(MainWindow.BMPSource);
                else
                    Buttons[buttonIndex].Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                Buttons[buttonIndex].Background = null;
            }



        }
        public void FillBoard(List<string> board)
        {
            for (int i = 0; i < 25; i++)
            {
                Buttons[i].Background = null;
                Buttons[i].Text = board[i];
            }
        }
    }
}
