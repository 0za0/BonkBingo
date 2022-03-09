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
        public MainWindow()
        {

            InitializeComponent();
            int count = 1;
            //Add btns to list then apply thing to them
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button MyControl1 = new Button();
                    MyControl1.Content = count.ToString();
                    MyControl1.Name = count.ToString();

                    Grid.SetColumn(MyControl1, j);
                    Grid.SetRow(MyControl1, i);
                    MainGrid.Children.Add(MyControl1);

                    count++;
                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

            bingoLogic.GenerateBoard(flags,0,int.Parse(SeedTextBox.Text));

        }
    }
}
