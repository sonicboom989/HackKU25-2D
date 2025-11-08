Get Big, Man (HackKU 2025)

Winner: Best Beginner Project at HackKU 2025!

"Get Big, Man" is a 2D roguelike game developed in 36 hours for the HackKU 2025 hackathon. The theme was "health and well-being," and our game tackles the concept of "gymtimidation"—the fear of going to the gym.

You play as a new gym-goer, initially small and weak. Your goal is to conquer different areas of the gym by fighting enemies modeled after rogue equipment. As you defeat enemies, you collect coins, buy upgrades, and literally evolve from Big_Man to Bigger_Man and finally Biggerer_Man!

Play the live version on Itch.io!

Gameplay & Features

Evolving Character: Progress through three character evolutions (Big_Man, Bigger_Man, Biggerer_Man), each with unique sprites and stats. 

$$cite: `Character Models/Big_Man/BigMan_Idle.ase`, `Character Models/Bigger_Man/BiggerMan_Idle.ase`, `Character Models/Biggerer_Man/BiggererMan_Idle.ase`$$

Gym-Themed Levels: Battle your way through distinct gym zones, including "Push," "Pull," and "Legs." 

$$cite: `Character Models/Misc/Push.png`, `Character Models/Misc/Pull.png`, `Character Models/Misc/Legs.png`$$

Unique Enemies: Fight a variety of custom-pixel-art enemies, from projectile-throwing Dumbell_Enemys to a massive Treadmill_Boss. 

$$cite: `Character Models/Misc/Dumbell_Enemy.ase`, `Character Models/Misc/Treadmill_Boss.ase`$$

Shop & Upgrades: Use coins collected from enemies to buy health and strength upgrades from the Shopkeeper. 

$$cite: `Test/Assets/Scenes/Shop.unity`, `Character Models/Misc/Strength_Upgrade.ase`$$

Original Art & Sound: Features all-original pixel art created in Aseprite and an original soundtrack and SFX (like "GET BIG, MAN!") produced in FL Studio. 

$$cite: `Test/Assets/PreFabs/Sounds/Music Tracks/lvl1_fight(crushed).mp3`, `Test/Assets/PreFabs/Sounds/SFX/GetBigMan.wav`$$

Tech Stack

Game Engine: Unity (version 2022.3.15f1 specified in Test/ProjectSettings/ProjectVersion.txt)

Language: C# 

$$cite: `Test/Assets/PreFabs/Player/Big Guy/Scripts/PlayerMovement.cs`, `Test/Assets/PreFabs/Enemies/Scripts/EnemyAI.cs`, `Test/Assets/PreFabs/Items/HeartStuff/PlayerHealth.cs`$$

Art: Aseprite (for all .ase pixel art files)

Audio: FL Studio (for .mp3 and .wav files)

Version Control: Git & GitHub

How to Run (for Developers)

This is a standard Unity project. The main project folder is Test/.

Clone the repository:

git clone [https://github.com/sonicboom989/HackKU25-2D.git](https://github.com/sonicboom989/HackKU25-2D.git)



Open Unity Hub and "Add project from disk."

Select the Test folder from this repository.

Once the project is open, find the Main Menu scene in Test/Assets/Scenes/ and open it. 

$$cite: `Test/Assets/Scenes/Main Menu.unity`$$

Press the Play button in the Unity Editor.

The Team

Lucas Root (cringey303) - C# Programming, Audio Design

Luke Coffman (sonicboom989) - C# Programming, Version Control Manager

Ziv Cohen (ZivCohen-projects) - C# Programming: Main Game Logic

Noah Short (ShortyMcGee) - Art & Animation
