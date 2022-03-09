namespace BionicleBingoGenerator
{
    class Program
    {
        #region Data
        static string helpScreen = "BIONICLE Heroes bingo board generator\nCoded by Ondrik, with ideas from Footloose\nUsage: heroes-bingo.py [OPTIONS] --seed [SEED]\nOptions:\n    --1ks                        Include achievements for killing 1000 enemies\n    --max-vahki-level LEVEL(1-3) Include achievements for killing Vahki, up to the mentioned level (50, 250 and 500 required kills respectively)\n    --hewkii                     Include achievements for killing enemies with Hewkii\n    --matoro                     Include achievements for killing enemies with Matoro\n    --canisters                  Include canister flag\n    --canister-subdivision       Divides between gold and silver canister requirements\n    --shop                       Include flags for buying from the shop\n    --locator                    Add requirement for buying the Canister Locator\n    --playground                 Add requirement for buying and using the Piraka Playground attractions\n    --seed                       Seed for the generator (defaults to system time if blank)\n    --help                       Show this screen\n    --output                     Outputs the bingo card information to a text file (for parsing by the program)\n    --input                      Disregards all other arguments and takes the input from a text file";
        static List<string> piraka_names = new List<string> { "Vezok", "Reidak", "Thok", "Avak", "Hakann", "Zaktan" };
        static List<string> levels = new List<string> { "Complete Smugglers Cove", "Complete Shattered Wreck", "Complete Vezok's Deluge", "Complete Desert Outpost", "Complete Bleak Refinery", "Complete Ancient Citadel", "Complete Reidak's Bastion", "Complete Flooded Lowlands", "Complete Mountain Path", "Complete Blizzard Peaks", "Complete Thok's Grotto", "Complete Decrepit Dungeons", "Complete Cleansing Plant", "Complete Menacing Keep", "Complete Avak's Dynamo", "Complete Scorched Earth", "Complete Volcanic Trail", "Complete Fiery Mine", "Complete Hakann's Pit", "Complete Logging Post", "Complete Ancient Forest", "Complete Forgotten Shrine", "Complete Zaktan's Chamber", "Complete Vezon's Awakening" };
        static List<string> achievments = new List<string> { "Kill 100 Visorak", "Kill 500 Visorak", "Kill 100 Bohrok", "Kill 500 Bohrok" };
        static List<string> toakill = new List<string> { "Kill 100 enemies as Jaller", "Kill 100 enemies as Kongu", "Kill 100 enemies as Hahli", "Kill 250 enemies as Jaller", "Kill 250 enemies as Kongu", "Kill 250 enemies as Hahli", "Kill 50 enemies as Nuparu", "Kill 150 enemies as Nuparu" };
        static List<string> ach1k = new List<string> { "Kill 1000 Visorak", "Kill 1000 Bohrok" };
        static List<string> vahki = new List<string> { "Kill 50 Vahki", "Kill 250 Vahki", "Kill 500 Vahki" };
        static List<string> matoro = new List<string> { "Kill 50 enemies as Matoro", "Kill 150 enemies as Matoro" };
        static List<string> hewkii = new List<string> { "Kill 100 enemies as Hewkii", "Kill 250 enemies as Hewkii" };
        static List<string> piecegoal = new List<string> { "Collect 2.5 million pieces" };
        static List<string> bonus = new List<string> { "Complete Bonus Level 1", "Complete Bonus Level 2", "Complete Bonus Level 3" };
        static List<string> shop = new List<string> { "Acquire Nuparu's elemental ability", "Acquire Hahli's elemental ability", "Acquire Hewkii's elemental ability", "Acquire Matoro's elemental ability", "Acquire Kongu's elemental ability", "Acquire Jaller's elemental ability", "Upgrade Nuparu's weapon to Tier 2", "Upgrade Hahli's weapon to Tier 2", "Upgrade Hewkii's weapon to Tier 2", "Upgrade Matoro's weapon to Tier 2", "Upgrade Kongu's weapon to Tier 2", "Upgrade Jaller's weapon to Tier 2", "Upgrade Nuparu's weapon to Tier 3", "Upgrade Hahli's weapon to Tier 3", "Upgrade Hewkii's weapon to Tier 3", "Upgrade Matoro's weapon to Tier 3", "Upgrade Kongu's weapon to Tier 3", "Upgrade Jaller's weapon to Tier 3", "Fully upgrade Nuparu's health", "Fully upgrade Hahli's health", "Fully upgrade Hewkii's health", "Fully upgrade Matoro's health", "Fully upgrade Kongu's health", "Fully upgrade Jaller's health", "Purchase the 50% discount" };
        static List<string> shop2 = new List<string> { "Purchase the Canister Locator" };
        static List<string> playground_objects = new List<string> { "Seesaw", "Pedalo", "Windsurfer", "Shooting gallery", "Sand Castles", "Sun Lounger", "Bucking Bronco", "Fitness Equipment", "Dance Floor", "DJ Booth", "VIP Lounge", "Diving Board" };
        static List<string> playground = new List<string> { "Seesaw (Piraka Playground)", "Pedalo (Piraka Playground)", "Windsurfer (Piraka Playground)", "Shooting gallery (Piraka Playground)", "Sand Castles (Piraka Playground)", "Sun Lounger (Piraka Playground)", "Bucking Bronco (Piraka Playground)", "Fitness Equipment (Piraka Playground)", "Dance Floor (Piraka Playground)", "DJ Booth (Piraka Playground)", "VIP Lounge (Piraka Playground)", "Diving Board (Piraka Playground)" };


        static Random rnd = new Random();

        static List<string> canisters = new List<string>();
        static List<string> silvers = new List<string>();
        static List<string> golds = new List<string>();
        static List<string> goals = new List<string>();
        static int mvaki = 0;
        static int seed = 0;
        #endregion

        public static void Main(string[] args)
        {
            InitLists();
            if (args.Length != 0 && args.Contains("--help") || args.Length == 0)
                Console.WriteLine(helpScreen);

            if (args.Contains("--max-vahki-level"))
            {
                int index = Array.IndexOf(args, "--max-vahki-level") + 1;

                mvaki = int.Parse(args[index]);
                if (mvaki > 3 || mvaki < 0)
                {
                    Console.WriteLine("Incorrect argument for --max-vahki-level - must be a number between 1 and 3");
                    Environment.Exit(-1);
                }
                Console.WriteLine($"mvaki = {args[index]}");
            }
            if (args.Contains("--seed"))
            {
                int index = Array.IndexOf(args, "--seed") + 1;
                if (!int.TryParse(args[index], out seed))
                {
                    Console.WriteLine("Invalid Seed using Random GUID");
                    rnd = new Random(Guid.NewGuid().GetHashCode());
                }
                else
                {
                    rnd = new Random(seed);
                    Console.WriteLine($"Seed set to {seed}");
                }
            }

            if (args.Contains("--1ks"))
                goals.AddRange(ach1k);
            if (args.Contains("--hewkii"))
                goals.AddRange(hewkii);
            if (args.Contains("--matoro"))
                goals.AddRange(matoro);
            if (args.Contains("--canisters"))
                goals.AddRange(canisters);
            if (args.Contains("--canister-subdivision"))
            {
                goals.AddRange(golds);
                goals.AddRange(silvers);
            }
            if (args.Contains("--shop"))
                goals.AddRange(shop);
            if (args.Contains("--locator"))
                goals.AddRange(shop2);
            if (args.Contains("--playground"))
                goals.AddRange(playground);

            var board = goals.OrderBy(x=> rnd.Next()).Take(25).ToList();
            board[rnd.Next(0, 26)] = "Play Piraka Bluff";

            foreach (var item in board)
            {
                Console.WriteLine(item);
            }
        }

        private static void InitLists()
        {
            foreach (var name in piraka_names)
            {
                canisters.Add($"Collect {rnd.Next(2, 6)} canisters in {name}");
                silvers.Add($"Collect {rnd.Next(2, 4)} silver canisters in {name}");
                int goldCans = rnd.Next(1, 3);
                string cans = goldCans == 2 ? "canisters" : "canister";
                golds.Add($"Collect {goldCans} gold {cans} in {name}");
            }
            goals.AddRange(levels);
            goals.AddRange(achievments);
            goals.AddRange(toakill);

        }
    }
}