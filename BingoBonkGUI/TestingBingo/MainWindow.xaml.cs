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
    /// 

    //Todo:
    //Make code cleaner / Add more (meaningful) comments
    public partial class MainWindow : Window
    {
        private BingoLogic bingoLogic = new BingoLogic();
        private List<WrapButton> Buttons = new List<WrapButton>();
        public static BitmapSource? BMPSource = null;
        private PopoutGrid PopoutGrid = new PopoutGrid();
        private List<string> CurrentBoard = new List<string>();

        public MainWindow()
        {
            //Very quickly hacked in color configuration
            Configuration.LoadColorConfig();

            InitializeComponent();
            CreateButtons();
            System.Drawing.Image image = System.Drawing.Image.FromFile("Resources/scream.jpg");
            Bitmap bitmap = new System.Drawing.Bitmap(image);
            //Create the Bitmap here so we dont have to always re-do it when a button is clicked
            BMPSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                            IntPtr.Zero,
                                                                            Int32Rect.Empty,
                                                                            BitmapSizeOptions.FromEmptyOptions()
            );
            bitmap.Dispose();
        }
        //Best to not ask why I needed to add this, trust me
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
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
                if ((bool)UseImages.IsChecked)
                    Buttons[buttonIndex].Background = new ImageBrush(BMPSource);
                else
                    Buttons[buttonIndex].Background = Configuration.ButtonSelectedColor;
            }
            else
            {
                Buttons[buttonIndex].Background = Configuration.ButtonDeselectedColor;
            }



        }
        private void RegenSeedButtonClicked(object sender, RoutedEventArgs e)
        {
            SeedTextBox.Text = bingoLogic.GenerateSeed().ToString();
        }
        private void PopOutBtnClicked(object sender, RoutedEventArgs e)
        {
            PopoutGrid.FillBoard(CurrentBoard);
            PopoutGrid.Show();
            PopoutBoardButton.IsEnabled = false;
            PopoutGrid.Closed += (obj, e) => { PopoutBoardButton.IsEnabled = true; PopoutGrid = new PopoutGrid(); };
        }
        private void Generate(object sender, RoutedEventArgs e)
        {
            bool createNewBoard = false;
            if (!Buttons.Any(x => x.IsClicked == true))
            {
                createNewBoard = true;
            }
            else
            {
                ConfirmBoardCreation c = new ConfirmBoardCreation();
                c.SetYesButtonEvent((obj, ev) => { createNewBoard = true; c.Close(); });
                c.ShowDialog();
            }


            if (createNewBoard)
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

                //Store goals here
                int mvahki = 0;
                int.TryParse(VahkiTextBox.Text, out mvahki);
                CurrentBoard = bingoLogic.GenerateBoard(flags, int.Parse(SeedTextBox.Text), mvahki);
                PopoutGrid.FillBoard(CurrentBoard);
                FillButtonText(CurrentBoard);

                foreach (var item in Buttons)
                {
                    item.Background = Configuration.ButtonDeselectedColor;
                    item.IsClicked = false;
                }
            }
        }
        void FillButtonText(List<string> bingoboard)
        {
            for (int i = 0; i < bingoboard.Count; i++)
                Buttons[i].Text = bingoboard[i];
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
        private void UseImages_Checked(object sender, RoutedEventArgs e)
        {
            PopoutGrid.UseImages = !PopoutGrid.UseImages;
        }
    }
}
