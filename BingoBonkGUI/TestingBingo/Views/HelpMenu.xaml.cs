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
    /// Interaction logic for HelpMenu.xaml
    /// </summary>
    public partial class HelpMenu : Window
    {
        public HelpMenu()
        {
            InitializeComponent();
            HelpText.Text = "BIONICLE Heroes bingo board generator\nCoded by Ondrik, with ideas from Footloose.\nGUI Version made by that one guy\nOptions:\n    --1ks                        Include achievements for killing 1000 enemies\n    --max-vahki-level LEVEL(1-3) Include achievements for killing Vahki, up to the mentioned level (50, 250 and 500 required kills respectively)\n    --hewkii                     Include achievements for killing enemies with Hewkii\n    --matoro                     Include achievements for killing enemies with Matoro\n    --canisters                  Include canister flag\n    --canister-subdivision       Divides between gold and silver canister requirements\n    --shop                       Include flags for buying from the shop\n    --locator                    Add requirement for buying the Canister Locator\n    --playground                 Add requirement for buying and using the Piraka Playground attractions\n    --seed                       Seed for the generator (defaults to system time if blank)\n";

        }
    }
}
