# BonkBingo
A Bingo Board Generator for Bionicle Heroes or any game


This version loads the entire board from the board.kongu



**Original Script by Nordki/Ondrik**

# Feedback / Bugs
Just hit me up on Discord or create an issue, I'll try my best.

# How to use
~~You need [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)~~


The app was packaged into 1 executable including dependencies and runtime (thats why its so huge).


Just download the and run the .exe


Windows only.
![image](https://user-images.githubusercontent.com/43097509/157955219-13a5be59-f1d3-44b0-b56a-40129b9588d2.png)

# How board generation works
All choices and toggles are defined by the board.kongu file.

The file looks like a little something like this:


![grafik](https://user-images.githubusercontent.com/43097509/158371217-5d871db9-065f-4e8a-9404-87a696705231.png)

Based on this file, the GUI generates the toggles and input boxes.

A toggle has a name which is defined with brackets f.i. `[Shop]` and beneath it are the goals that get added to the pool of goals.

Every toggle then generates a checkbox into the GUI.


![grafik](https://user-images.githubusercontent.com/43097509/158371817-d5edfcd9-c97b-4bee-b17d-beafb8c7153c.png)


Out of that pool, 25 random entries get picked (based on a seed).

## Special Flags
There are special flags that are can be used or should not be tampered with. 

### `[Default]`
The `[Default]` flag is **not toggleable** and **has to be the _first_ flag defined in the .kongu file**, the values of this flag always get included.

### `[Always Fill middle Square]`
The `[Always Fill middle Square]` flag **is toggleable** and **has to be the _last_ flag defined in the .kongu file**.

This flag fills the middle/12th square to always be what the flag defined it as. 

That means when this flag is toggled, the middle square will always be the same, regardless of seed.


![grafik](https://user-images.githubusercontent.com/43097509/158372345-94c10d6f-8e9f-422b-8fd7-92cde03dae2f.png)

### RND Flags
It is possible to define flags that generate a random value at runtime (useful for collectibles). 

For instance:


![grafik](https://user-images.githubusercontent.com/43097509/158372445-6fe68993-8ea4-4019-9514-15c3be841fe1.png)

The flag name has to contain a `;RND` (Not shown in GUI) and you can then set the lower and upper bound for the randomly generated value.

**NOTE: THE UPPER BOUND IS NOT INCLUDED, MEANING {2,6} ONLY GENERATES NUMBERS BETWEEN 2 AND 5**

### Value Flags
![grafik](https://user-images.githubusercontent.com/43097509/158373125-dbed99d8-39a4-4175-9b0c-8048e49109a6.png)


The flag name has to contain a `;VALUE` (Not shown in GUI).

These flags generate a input box into the GUI when used, the initial value is the name of the flag.

![grafik](https://user-images.githubusercontent.com/43097509/158373229-815043d1-1690-4177-b986-1e67b1431ddc.png)

Whenever you enter a numeric value (maximum is number of items this flag has) the goals then include as many of the flags as specified. 

For instance if we enter 2 for the vahki flag, "Kill 50 Vahki" and "Kill 250 Vahki" would get added to the goals pool.



# Feature List
- Generate Bingo Boards (As an Input you can use a file)
- Images can be used to mark tiles. (Resources/scream.jpg)
- Pop out the Bingo Board into its seperate window.
- Change the colors of the tiles and Font.


# Quirks
- ~~Duplicate Entries~~ (Fixed)
- ~~Cannot popout board if board hasn't been generated yet.~~ (Fixed)
- ~~Cannot set font color, which makes setting custom colors a bit restrictive at the moment.~~ Implemented.
- Font size cant be changed as of right now
- ~~Gotta look into the seeds and if they are reliable~~ Yup, fixed it.
- Gotta Explain what the settings do 

# To-Do Programming wise
- Properly utilize Application.Resources / Bindings / Other proper practices where I was too cheap to implement them properly
- Don't just wing the stuff, maybe plan it
- Maybe re-do Randomization
- Just clean up the code a whole lot (Right now its on a "It works" basis) 
- Add a dark mode so people can keep using their eyes 
- Fix GitHub Workflow .yml so it zips up the program and creates a release automatically
