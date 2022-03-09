using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionicleHeroesBingoGUI
{
    internal class BingoLogic
    {

        List<string> piraka_names = new List<string> { "Vezok", "Reidak", "Thok", "Avak", "Hakann", "Zaktan" };
        List<string> levels = new List<string> { "Complete Smugglers Cove", "Complete Shattered Wreck", "Complete Vezok's Deluge", "Complete Desert Outpost", "Complete Bleak Refinery", "Complete Ancient Citadel", "Complete Reidak's Bastion", "Complete Flooded Lowlands", "Complete Mountain Path", "Complete Blizzard Peaks", "Complete Thok's Grotto", "Complete Decrepit Dungeons", "Complete Cleansing Plant", "Complete Menacing Keep", "Complete Avak's Dynamo", "Complete Scorched Earth", "Complete Volcanic Trail", "Complete Fiery Mine", "Complete Hakann's Pit", "Complete Logging Post", "Complete Ancient Forest", "Complete Forgotten Shrine", "Complete Zaktan's Chamber", "Complete Vezon's Awakening" };
        List<string> achievments = new List<string> { "Kill 100 Visorak", "Kill 500 Visorak", "Kill 100 Bohrok", "Kill 500 Bohrok" };
        List<string> toakill = new List<string> { "Kill 100 enemies as Jaller", "Kill 100 enemies as Kongu", "Kill 100 enemies as Hahli", "Kill 250 enemies as Jaller", "Kill 250 enemies as Kongu", "Kill 250 enemies as Hahli", "Kill 50 enemies as Nuparu", "Kill 150 enemies as Nuparu" };
        List<string> ach1k = new List<string> { "Kill 1000 Visorak", "Kill 1000 Bohrok" };
        List<string> vahki = new List<string> { "Kill 50 Vahki", "Kill 250 Vahki", "Kill 500 Vahki" };
        List<string> matoro = new List<string> { "Kill 50 enemies as Matoro", "Kill 150 enemies as Matoro" };
        List<string> hewkii = new List<string> { "Kill 100 enemies as Hewkii", "Kill 250 enemies as Hewkii" };
        List<string> piecegoal = new List<string> { "Collect 2.5 million pieces" };
        List<string> bonus = new List<string> { "Complete Bonus Level 1", "Complete Bonus Level 2", "Complete Bonus Level 3" };
        List<string> shop = new List<string> { "Acquire Nuparu's elemental ability", "Acquire Hahli's elemental ability", "Acquire Hewkii's elemental ability", "Acquire Matoro's elemental ability", "Acquire Kongu's elemental ability", "Acquire Jaller's elemental ability", "Upgrade Nuparu's weapon to Tier 2", "Upgrade Hahli's weapon to Tier 2", "Upgrade Hewkii's weapon to Tier 2", "Upgrade Matoro's weapon to Tier 2", "Upgrade Kongu's weapon to Tier 2", "Upgrade Jaller's weapon to Tier 2", "Upgrade Nuparu's weapon to Tier 3", "Upgrade Hahli's weapon to Tier 3", "Upgrade Hewkii's weapon to Tier 3", "Upgrade Matoro's weapon to Tier 3", "Upgrade Kongu's weapon to Tier 3", "Upgrade Jaller's weapon to Tier 3", "Fully upgrade Nuparu's health", "Fully upgrade Hahli's health", "Fully upgrade Hewkii's health", "Fully upgrade Matoro's health", "Fully upgrade Kongu's health", "Fully upgrade Jaller's health", "Purchase the 50% discount" };
        List<string> shop2 = new List<string> { "Purchase the Canister Locator" };
        List<string> playground_objects = new List<string> { "Seesaw", "Pedalo", "Windsurfer", "Shooting gallery", "Sand Castles", "Sun Lounger", "Bucking Bronco", "Fitness Equipment", "Dance Floor", "DJ Booth", "VIP Lounge", "Diving Board" };
        List<string> playground = new List<string> { "Seesaw (Piraka Playground)", "Pedalo (Piraka Playground)", "Windsurfer (Piraka Playground)", "Shooting gallery (Piraka Playground)", "Sand Castles (Piraka Playground)", "Sun Lounger (Piraka Playground)", "Bucking Bronco (Piraka Playground)", "Fitness Equipment (Piraka Playground)", "Dance Floor (Piraka Playground)", "DJ Booth (Piraka Playground)", "VIP Lounge (Piraka Playground)", "Diving Board (Piraka Playground)" };


        static Random rnd = new Random();
        public int Seed { get; private set; }
        List<string> canisters = new List<string>();
        List<string> silvers = new List<string>();
        List<string> golds = new List<string>();
        List<string> goals = new List<string>();

        internal int GenerateSeed()
        {
            Seed = Math.Abs(Guid.NewGuid().GetHashCode());
            rnd = new Random(Seed);
            return rnd.Next(Math.Abs(Guid.NewGuid().GetHashCode()));
        }
        public BingoLogic()
        {
            InitLists();
        }
        public void GenerateBoard(bool[] settings, int vahkiLvl, int seed)
        {

        }
        private void InitLists()
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
