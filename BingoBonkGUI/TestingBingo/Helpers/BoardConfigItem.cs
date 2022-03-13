using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionicleHeroesBingoGUI.Helpers
{
    internal class BoardConfigItem
    {
        public string Name { get; set; }
        public List<string> BoardItems { get; set; }
        public List<string> ActualValues { get; set; } // Oh boy oh fuck
        public bool IsValue { get; set; }
        public bool RequiresInit { get; set; }

        public BoardConfigItem()
        {
            BoardItems = new List<string>();
            ActualValues = new List<string>();
        }
    }
}
