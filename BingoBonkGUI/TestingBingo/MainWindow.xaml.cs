using BionicleHeroesBingoGUI.Helpers;
using BionicleHeroesBingoGUI.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;


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
        private PopoutGrid PopoutGrid;
        private List<string> CurrentBoard = new List<string>();

        //I really wish I had more than 5 IQ 
        private List<CheckBox> flags = new List<CheckBox>();
        private List<TextBox> valueFlags = new List<TextBox>();

        public MainWindow()
        {
            //Very quickly hacked in color configuration
            Configuration.LoadColorConfig();

            InitializeComponent();
            CreateButtons();
            PopoutGrid = new PopoutGrid();
            GenerateFlags();

            if (Configuration.BitmapImage == null)
                UseImages.IsEnabled = false;
        }
        private void GenerateFlags()
        {
            foreach (var item in bingoLogic.GenerateControlsNeeded())
            {
                //Number flags get added here
                if (item.GetType() == typeof(TextBox))
                {
                    FlagsStack.Children.Add(item);
                    valueFlags.Add((TextBox)item);
                }
                else
                {
                    flags.Add((CheckBox)item);
                    FlagsStack.Children.Add(item);
                }
            }
        }
        //Best to not ask why I needed to add this, trust me
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            System.Windows.Application.Current.Shutdown();
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
                //To avoid the warning I do ==true
                if (UseImages.IsChecked == true)
                {

                    Buttons[buttonIndex].ButtonImage.Visibility = Visibility.Visible;
                    Buttons[buttonIndex].Background = Configuration.ButtonSelectedColor;
                    if (HideText.IsChecked == true)
                    {
                        Buttons[buttonIndex].Foreground = Configuration.ButtonInvisibleFont;
                    }
                }

                else
                    Buttons[buttonIndex].Background = Configuration.ButtonSelectedColor;
            }
            else
            {
                Buttons[buttonIndex].ButtonImage.Visibility = Visibility.Hidden;
                Buttons[buttonIndex].Background = Configuration.ButtonDeselectedColor;
                Buttons[buttonIndex].Foreground = Configuration.ButtonFontColor;
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
                createNewBoard = true;

            else
            {
                ConfirmBoardCreation c = new ConfirmBoardCreation();
                c.SetYesButtonEvent((obj, ev) => { createNewBoard = true; c.Close(); });
                c.ShowDialog();
            }
            if (createNewBoard)
            {
                //Cursed
                List<bool?> flagsInOrder = flags.Select(x => x.IsChecked).ToList();
                List<string> flagsValue = valueFlags.Select(x => x.Text).ToList();
                if (!int.TryParse(SeedTextBox.Text, out int seed))
                    seed = -1;

                CurrentBoard = bingoLogic.GenerateBoard(flagsInOrder, seed, flagsValue);
                PopoutGrid.FillBoard(CurrentBoard);
                FillButtonText(CurrentBoard);

                foreach (var item in Buttons)
                {
                    item.ButtonImage.Visibility = Visibility.Hidden;
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
        private void OpenHelpMenu(object sender, RoutedEventArgs e)
        {
            HelpMenu h = new HelpMenu();
            h.Show();
        }
        private void AboutMenu(object sender, RoutedEventArgs e)
        {
            AboutMenu a = new AboutMenu();
            a.Show();
        }
        //Sum checked and unchecked into 1 event, its possible I am tired tho
        private void UseImages_Checked(object sender, RoutedEventArgs e)
        {
            PopoutGrid.UseImages = !PopoutGrid.UseImages;
            Buttons.Where(x => x.IsClicked).ToList().ForEach(x => x.ButtonImage.Visibility = Visibility.Visible);
            PopoutGrid.UpdateButtonColors();
        }
        private void UseImages_Unchecked(object sender, RoutedEventArgs e)
        {
            PopoutGrid.UseImages = !PopoutGrid.UseImages;
            Buttons.Where(x => x.IsClicked).ToList().ForEach(x =>
            {
                x.Background = Configuration.ButtonSelectedColor;
                x.ButtonImage.Visibility = Visibility.Hidden;
            });
            PopoutGrid.UpdateButtonColors();
        }
        //Apply to PopoutBoard
        private void HideText_Checked(object sender, RoutedEventArgs e)
        {
            if (UseImages.IsChecked == true && HideText.IsChecked == true)
            {
                foreach (var item in Buttons.Where(btn => btn.IsClicked))
                    item.Foreground = Configuration.ButtonInvisibleFont;

                PopoutGrid.HideText = !PopoutGrid.HideText;
                PopoutGrid.UpdateButtonColors();

            }
        }
        private void HideText_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in Buttons.Where(btn => btn.IsClicked))
                item.Foreground = Configuration.ButtonFontColor;

            PopoutGrid.HideText = !PopoutGrid.HideText;
            PopoutGrid.UpdateButtonColors();
        }
        private void SettingsMenu(object sender, RoutedEventArgs e)
        {
            ColorSettings s = new ColorSettings();
            s.Show();
            s.Closed += (obj, e) =>
            {
                if (Configuration.BitmapImage == null)
                    UseImages.IsEnabled = false;
                else
                    UseImages.IsEnabled = true;


                Buttons.Clear();
                CreateButtons();
                FillButtonText(CurrentBoard);
                ApplyNewColorToButtons();
            };

        }

        private void ApplyNewColorToButtons()
        {
            foreach (var item in Buttons)
            {
                item.Foreground = Configuration.ButtonFontColor;
                if (item.IsClicked)
                    item.Background = Configuration.ButtonSelectedColor;
                else
                    item.Background = Configuration.ButtonDeselectedColor;

            }
        }

        private void OpenBoardFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bingo Boards (.kongu)|*.kongu";
            openFileDialog.ShowDialog();
        }
        private void SaveFileAsPNGClicked(object sender, RoutedEventArgs e)
        {
            using (var fileStream = File.Create($"./Saved Boards/{((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()}--{bingoLogic.Seed}.png"))
            {
                ImageHelpers.SaveAsPng(ImageHelpers.GetImage(MainGrid), fileStream);
            }
        }
    }
}