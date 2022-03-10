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
    /// Interaction logic for ConfirmBoardCreation.xaml
    /// </summary>
    public partial class ConfirmBoardCreation : Window
    {
        public ConfirmBoardCreation()
        {
            InitializeComponent();
        }

        public void SetYesButtonEvent ( RoutedEventHandler e )
        {
            ConfirmBtn.Click -= e;
            ConfirmBtn.Click += e;
        }

        private void DenyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
