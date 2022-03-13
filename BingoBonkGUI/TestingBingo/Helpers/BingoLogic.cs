using BionicleHeroesBingoGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace BionicleHeroesBingoGUI
{
    internal class BingoLogic
    {
        private Random rnd = new Random();
        public int Seed { get; private set; }
        private List<string> goals = new List<string>();
        internal int GenerateSeed()
        {
            Seed = Math.Abs(Guid.NewGuid().GetHashCode());
            rnd = new Random(Seed);
            return rnd.Next(Math.Abs(Guid.NewGuid().GetHashCode()));
        }
        public List<Control> GenerateControlsNeeded()
        {
            BoardParser.Parse("board.kongu");
            List<Control> controls = new List<Control>();

            foreach (var item in BoardParser.boardConfigItems.Skip(1).ToList())//We can always skip 1 because its the [DEFAULT]
            {
                if (item.IsValue)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = $"{item.Name}";
                    //Figure this out pls
                    textBox.Width = Double.NaN;
                    controls.Add(textBox);
                }
                else
                {
                    CheckBox cb = new CheckBox();
                    cb.Content = item.Name;
                    controls.Add(cb);
                }
            }
            return controls;
        }
        public List<string> GenerateBoard(List<bool?> settings, int seed, List<string> valueFlags)
        {
            goals.Clear();
            if (seed == -1)
                GenerateSeed();
            else
                Seed = seed;

            rnd = new Random(Seed);
            InitLists();
            goals.AddRange(BoardParser.boardConfigItems[0].BoardItems);
            for (int i = 0; i < settings.Count; i++)
            {
                //It literally says workaround, please consider redoing the entire thing here
                var workaround = BoardParser.boardConfigItems.Skip(1).Where(item => !item.IsValue).ToList();
                if (settings[i] == true)
                {
                    if (workaround[i].RequiresInit)
                        goals.AddRange(workaround[i].RuntimeGeneratedValues);
                    else
                        goals.AddRange(workaround[i].BoardItems);
                }
            }
            
            //Get which flags are values
            List<BoardConfigItem> onlyValues = BoardParser.boardConfigItems.Where(x => x.IsValue).ToList();
            for (int i = 0; i < onlyValues.Count(); i++)
            {
                int val = 0;
                // getting the currentItem
                BoardConfigItem currentItem = onlyValues[i];
                //Check if we can get a value out
                int.TryParse(valueFlags[i],out val);
                //Take as many goals as stated in the textbox
                goals.AddRange(currentItem.BoardItems.Take(val));
            }
            List<string> board = goals.OrderBy(x => rnd.Next(0, 1000)).Take(25).ToList();
            board[12] = "Play Piraka Bluff"; //TODO: Define this in the file
            return board;
        }
        private void InitLists()
        {
            //Clear them otherwise we get dupes
            foreach (var item in BoardParser.boardConfigItems.Where(x => x.RequiresInit))
                item.RuntimeGeneratedValues.Clear();

            //Initialize all the bois that need initialization :)
            foreach (var AllBoardItems in BoardParser.boardConfigItems.Where(x => x.RequiresInit))
            {
                for (int i = 0; i < AllBoardItems.BoardItems.Count(); i++)
                {
                    string IndividualItem = AllBoardItems.BoardItems[i];
                    //Figure out where to go and then put in a random number
                    //Please ignore the mess below, thanks
                    int startIndex = IndividualItem.IndexOf("{");
                    int endIndex = IndividualItem.IndexOf("}");
                    string randomRange = IndividualItem[new Range(startIndex, endIndex)];
                    IndividualItem = IndividualItem.Remove(startIndex, (endIndex - startIndex + 1));
                    randomRange = Regex.Replace(randomRange, @"[{}]", "");
                    int minRand = 0, maxRand = 0;
                    minRand = int.Parse(randomRange.Split(",")[0]);
                    maxRand = int.Parse(randomRange.Split(",")[1]);

                    //Putting in the random Number       
                    AllBoardItems.RuntimeGeneratedValues.Add(IndividualItem.Insert(startIndex, $"{rnd.Next(minRand, maxRand)}"));
                }
            }
        }
    }
}
