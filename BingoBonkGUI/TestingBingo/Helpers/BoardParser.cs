using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BionicleHeroesBingoGUI.Helpers
{
    internal static class BoardParser
    {

        public static List<BoardConfigItem> boardConfigItems = new List<BoardConfigItem>();
        public static void Parse(string FilePath)
        {
            string currentFlag = "";
            BoardConfigItem currentItem = new BoardConfigItem();
            string[] allLines = File.ReadAllLines(FilePath);
            for (int i = 0; i < allLines.Length; i++)
            {
                string currentLine = allLines[i];
                if (currentLine.Contains('['))
                {
                    if (i > 0)
                        boardConfigItems.Add(currentItem);

                    currentItem = new BoardConfigItem();

                    currentFlag = Regex.Replace(currentLine, @"[\[\]]", "");
                    if (currentFlag.Contains(';'))
                    {
                        string[] splitFlag = currentFlag.Split(";");
                        //Check if need init
                        if (splitFlag[1] == "RND")
                        {
                            currentItem.RequiresInit = true;
                        }
                        //Check if is Value (If so do special thingies)
                        if (splitFlag[1] == "VALUE")
                        {
                            currentItem.IsValue = true;
                        }
                        currentFlag = splitFlag[0];

                    }
                    currentItem.Name = currentFlag;
                }
                else
                {
                    if (currentLine != "")
                        currentItem.BoardItems.Add(currentLine);
                }
            }
        }
        public static void PopulateLists()
        {

        }
    }
}
