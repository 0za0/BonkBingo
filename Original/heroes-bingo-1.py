import random
import sys
import time

mvahki = 0

def balanced(pstr,l):
    buff = l-len(pstr)
    sb = buff//2
    eb = sb + 1 if buff % 2 else sb
    return " "*sb+pstr+" "*eb
    
def print_board(blist):
    for i in range(len(blist)):
        print("["+balanced(blist[i],mlen+3)+"] ",end="")
        if (i+1) % 5 == 0:
          print("\n")

def hscreen():
    print("BIONICLE Heroes bingo board generator")
    print("Coded by Ondrik, with ideas from Footloose")
    print("Usage: heroes-bingo.py [OPTIONS] --seed [SEED]")
    print("Options:")
    print("    --1ks                        Include achievements for killing 1000 enemies")
    print("    --max-vahki-level LEVEL(1-3) Include achievements for killing Vahki, up to the mentioned level (50, 250 and 500 required kills respectively)")
    print("    --hewkii                     Include achievements for killing enemies with Hewkii")
    print("    --matoro                     Include achievements for killing enemies with Matoro")
    print("    --canisters                  Include canister flags")
    print("    --canister-subdivision       Divides between gold and silver canister requirements")
    print("    --shop                       Include flags for buying from the shop")
    print("    --locator                    Add requirement for buying the Canister Locator")
    print("    --playground                 Add requirement for buying and using the Piraka Playground attractions")
    print("    --seed                       Seed for the generator (defaults to system time if blank)")
    print("    --help                       Show this screen")
    print("    --output                     Outputs the bingo card information to a text file (for parsing by the program)")
    print("    --input                      Disregards all other arguments and takes the input from a text file")



args = sys.argv[1:]
if len(sys.argv) >= 2 and "--help" in sys.argv:
    hscreen()
    exit()

# --1ks
# --max-vahki-level [arg]
# --hewkii
# --matoro
# --canisters
# --canister-subdivision
# --bonus (removed)
# --shop [limit?]
# --locator
# --playground
# --seed

# ENSURE PROPER PARSING
for i in range(len(sys.argv)-1):
    if sys.argv[i] == "--max-vahki-level":
        try:
            mvahki = int(sys.argv[i+1])
            if mvahki not in [0, 1, 2, 3]:
                print("Incorrect argument for --max-vahki-level - must be a number between 1 and 3")
                exit()
        except:
            print("Incorrect argument for --max-vahki-level - must be a number between 1 and 3")
            exit()
    if sys.argv[i] == "--seed":
        try:
            seed = sys.argv[i+1]
            print("Seed set to",seed)
        except:
            print("No seed entered. Setting to system time.")
            seed = time.time()
            print("Seed set to",seed)
            
        

if "--seed" not in sys.argv:
    print("The seed has not been entered. Setting seed to system time.")
    seed = time.time()
    print("Seed set to",seed)



random.seed(seed)

piraka_names = ["Vezok", "Reidak", "Thok", "Avak", "Hakann", "Zaktan"]

canisters = ["Collect "+str(random.randint(2,5))+" canisters in "+piraka_names[i] for i in range(6)]

# if canister-subdivision

golds = []

for piraka in piraka_names:
    cans = random.randint(1,2)
    gs = "Collect "+str(cans)+" gold canister"
    if cans == 2:
        gs += "s"
    gs += " in "+piraka
    golds.append(gs)
# print(golds)

silvers = ["Collect "+str(random.randint(2,3))+" silver canisters in "+piraka_names[i] for i in range(6)]

levels = ["Complete Smugglers Cove", "Complete Shattered Wreck", "Complete Vezok's Deluge", "Complete Desert Outpost", "Complete Bleak Refinery", "Complete Ancient Citadel", "Complete Reidak's Bastion", "Complete Flooded Lowlands", "Complete Mountain Path", "Complete Blizzard Peaks", "Complete Thok's Grotto", "Complete Decrepit Dungeons", "Complete Cleansing Plant", "Complete Menacing Keep", "Complete Avak's Dynamo", "Complete Scorched Earth", "Complete Volcanic Trail", "Complete Fiery Mine", "Complete Hakann's Pit", "Complete Logging Post", "Complete Ancient Forest", "Complete Forgotten Shrine", "Complete Zaktan's Chamber", "Complete Vezon's Awakening"]

achievements = ["Kill 100 Visorak", "Kill 500 Visorak", "Kill 100 Bohrok", "Kill 500 Bohrok"]

toakill = ['Kill 100 enemies as Jaller', 'Kill 100 enemies as Kongu',  'Kill 100 enemies as Hahli', 'Kill 250 enemies as Jaller', 'Kill 250 enemies as Kongu',  'Kill 250 enemies as Hahli', 'Kill 50 enemies as Nuparu', 'Kill 150 enemies as Nuparu']

ach1k = ["Kill 1000 Visorak", "Kill 1000 Bohrok"]

vahki = ["Kill 50 Vahki", "Kill 250 Vahki", "Kill 500 Vahki"]

matoro = ['Kill 50 enemies as Matoro', 'Kill 150 enemies as Matoro']

hewkii = ['Kill 100 enemies as Hewkii', 'Kill 250 enemies as Hewkii']

piecegoal = ["Collect 2.5 million pieces"]

bonus = ["Complete Bonus Level 1", "Complete Bonus Level 2", "Complete Bonus Level 3"]

shop = ["Acquire Nuparu's elemental ability", "Acquire Hahli's elemental ability", "Acquire Hewkii's elemental ability", "Acquire Matoro's elemental ability", "Acquire Kongu's elemental ability", "Acquire Jaller's elemental ability", "Upgrade Nuparu's weapon to Tier 2", "Upgrade Hahli's weapon to Tier 2", "Upgrade Hewkii's weapon to Tier 2", "Upgrade Matoro's weapon to Tier 2", "Upgrade Kongu's weapon to Tier 2", "Upgrade Jaller's weapon to Tier 2", "Upgrade Nuparu's weapon to Tier 3", "Upgrade Hahli's weapon to Tier 3", "Upgrade Hewkii's weapon to Tier 3", "Upgrade Matoro's weapon to Tier 3", "Upgrade Kongu's weapon to Tier 3", "Upgrade Jaller's weapon to Tier 3", "Fully upgrade Nuparu's health", "Fully upgrade Hahli's health", "Fully upgrade Hewkii's health", "Fully upgrade Matoro's health", "Fully upgrade Kongu's health", "Fully upgrade Jaller's health", "Purchase the 50% discount"]

shop2 = ["Purchase the Canister Locator"]

playground_objects = ["Seesaw", "Pedalo", "Windsurfer", "Shooting gallery", "Sand Castles", "Sun Lounger", "Bucking Bronco", "Fitness Equipment", "Dance Floor", "DJ Booth", "VIP Lounge", "Diving Board"]

# playground = ['Buy the Seesaw attraction in the Piraka Playground', 'Buy the Pedalo attraction in the Piraka Playground', 'Buy the Windsurfer attraction in the Piraka Playground', 'Buy the Shooting gallery attraction in the Piraka Playground', 'Buy the Sand Castles attraction in the Piraka Playground', 'Buy the Sun Lounger attraction in the Piraka Playground', 'Buy the Bucking Bronco attraction in the Piraka Playground', 'Buy the Fitness Equipment attraction in the Piraka Playground', 'Buy the Dance Floor attraction in the Piraka Playground', 'Buy the DJ Booth attraction in the Piraka Playground', 'Buy the VIP Lounge attraction in the Piraka Playground', 'Buy the Diving Board attraction in the Piraka Playground']
playground = ['Seesaw (Piraka Playground)', 'Pedalo (Piraka Playground)', 'Windsurfer (Piraka Playground)', 'Shooting gallery (Piraka Playground)', 'Sand Castles (Piraka Playground)', 'Sun Lounger (Piraka Playground)', 'Bucking Bronco (Piraka Playground)', 'Fitness Equipment (Piraka Playground)', 'Dance Floor (Piraka Playground)', 'DJ Booth (Piraka Playground)', 'VIP Lounge (Piraka Playground)', 'Diving Board (Piraka Playground)']

goals = []

goals.extend(levels)
goals.extend(achievements)
goals.extend(toakill)

included = ""

if "--1ks" in sys.argv:
    included += "1"
    goals.extend(ach1k)
    
goals.extend(vahki[:mvahki])

if "--hewkii" in sys.argv:
    included += "h"
    goals.extend(hewkii)

if "--matoro" in sys.argv:
    included += "m"
    goals.extend(matoro)
    
if "--canisters" in sys.argv:
    included += "c"
    goals.extend(canisters)

if "--canister-subdivision" in sys.argv:
    included += "C"
    goals.extend(golds)
    goals.extend(silvers)

if "--shop" in sys.argv:
    included += "s"
    goals.extend(shop)

if "--locator" in sys.argv:
    included += "l"
    goals.extend(shop2)

if "--playground" in sys.argv:
    included += "p"
    goals.extend(playground)

# GOALS = thing
print(included)
indices = list(range(len(goals)))

if "--output" in sys.argv: 
    with open("boardinfo.txt","w") as the_file:
        the_file.write(included+"\n"+str(indices))


random.shuffle(indices)
print(indices)
b_ind = indices[0:25]
board = []
for i in b_ind:
    board.append(goals[i])

# print(len(board))
board[12] = "Complete Piraka Bluff"
# print(len(board))

mlen = max([len(g) for g in board])

print_board(board)