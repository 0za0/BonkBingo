using BionicleHeroesBingoGUI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BionicleHeroesBingoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BingoLogic bingoLogic = new BingoLogic();
        List<WrapButton> buttons = new List<WrapButton>();
        BitmapSource bmpSource;
        
       
        public MainWindow()
        {

            InitializeComponent();
            CreateButtons();
            System.Drawing.Image image = System.Drawing.Image.FromFile("Resources/scream.jpg");
            Bitmap bitmap = new System.Drawing.Bitmap(image);
            //Create the Bitmap here so we dont have to always re-do it when a button is clicked
            bmpSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                            IntPtr.Zero,
                                                                            Int32Rect.Empty,
                                                                            BitmapSizeOptions.FromEmptyOptions()
            );
            bitmap.Dispose();
        }
        void CreateButtons()
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

                    count++;
                    buttons.Add(butt);
                }

            }
        }
        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            WrapButton? wp = sender as WrapButton;
            int buttonIndex = int.Parse(wp.Name.Remove(0,1));
            //Make sure we dont cause a fuckin memory leak lmfao... 
            //OK Fixed
            if ((bool)UseImages.IsChecked)
                buttons[buttonIndex].Background = new ImageBrush(bmpSource);
            else
                buttons[buttonIndex].Background = new SolidColorBrush(Colors.LightGreen);
            
        }

        private void RegenSeedButtonClicked(object sender, RoutedEventArgs e)
        {
            SeedTextBox.Text = bingoLogic.GenerateSeed().ToString();
        }

        private void Generate(object sender, RoutedEventArgs e)
        {
            bool[] flags = new bool[]
            {
                (bool)Ach1k.IsChecked,
                (bool)Hewkii.IsChecked,
                (bool)Matoro.IsChecked,
                (bool)Canisters.IsChecked,
                (bool)CanisterSubdivision.IsChecked,
                (bool)Shop.IsChecked,
                (bool)Shop2.IsChecked,
                (bool)Playground.IsChecked,
                
            };

            FillButtonText(bingoLogic.GenerateBoard(flags, int.Parse(SeedTextBox.Text)));

            foreach (var item in buttons)
            {
                item.Background = null;
            }
        }
        void FillButtonText(List<string> bingoboard)
        {
            for (int i = 0; i < bingoboard.Count; i++)
                buttons[i].Text = bingoboard[i];
            
        }

        private void HelpMenu(object sender, RoutedEventArgs e)
        {
            HelpMenu h = new HelpMenu();
            h.Show();
        }

        private void AboutMenu(object sender, RoutedEventArgs e)
        {
            AboutMenu a = new AboutMenu();
            a.Show();
        }
    }
}
