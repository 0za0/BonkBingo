# BonkBingo
A Bingo Board Generator for Bionicle Heroes



**Original Script by Nordki/Ondrik**

# Feedback / Bugs
Just hit me up on Discord or create an issue, I'll try my best.

# How to use
~~You need [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)~~


The app was packaged into 1 executable including dependencies and runtime (thats why its so huge).


Just download the and run the .exe


Windows only.
![image](https://user-images.githubusercontent.com/43097509/157955219-13a5be59-f1d3-44b0-b56a-40129b9588d2.png)

# Feature List
- Generate Bingo Boards
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
