using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TowerGame.Program;

namespace TowerGame
{
    public class TextScript
    {
        public void PrintTitleScreen()
        {
            Console.WriteLine(@"
 _______  _______ _________ _______  _______  _______  _       
(  ____ \(  ____ )\__   __/(       )(  ____ \(  ___  )( (    /|
| (    \/| (    )|   ) (   | () () || (    \/| (   ) ||  \  ( |
| |      | (____)|   | |   | || || || (_____ | |   | ||   \ | |
| |      |     __)   | |   | |(_)| |(_____  )| |   | || (\ \) |
| |      | (\ (      | |   | |   | |      ) || |   | || | \   |
| (____/\| ) \ \_____) (___| )   ( |/\____) || (___) || )  \  |
(_______/|/   \__/\_______/|/     \|\_______)(_______)|/    )_)
                                                               
         _______  _______  _______ _________ _        _______  
        (  ____ \(  ___  )(  ____ \\__   __/( \      (  ____ \ 
        | (    \/| (   ) || (    \/   ) (   | (      | (    \/ 
        | |      | (___) || (_____    | |   | |      | (__     
        | |      |  ___  |(_____  )   | |   | |      |  __)    
        | |      | (   ) |      ) |   | |   | |      | (       
        | (____/\| )   ( |/\____) |   | |   | (____/\| (____/\ 
        (_______/|/     \|\_______)   )_(   (_______/(_______/ 
");
            TypeWithDelay("Your goal is to escape the castle while rescuing the queen while encountering a lot of enemies . GLHF :)");
            TypeWithDelay("\" A \" \n");
        }

        public void PrintFloorNumber(int num)
        {
            switch (num)
            {
                case 1:
                    Console.WriteLine(@"
 _______  __        ______     ______   .______          __  
|   ____||  |      /  __  \   /  __  \  |   _  \        /_ | 
|  |__   |  |     |  |  |  | |  |  |  | |  |_)  |        | | 
|   __|  |  |     |  |  |  | |  |  |  | |      /         | | 
|  |     |  `----.|  `--'  | |  `--'  | |  |\  \----.    | | 
|__|     |_______| \______/   \______/  | _| `._____|    |_| 
                                                             

");
                    break;

                case 2:
                    Console.WriteLine(@"
 _______  __        ______     ______   .______          ___   
|   ____||  |      /  __  \   /  __  \  |   _  \        |__ \  
|  |__   |  |     |  |  |  | |  |  |  | |  |_)  |          ) | 
|   __|  |  |     |  |  |  | |  |  |  | |      /          / /  
|  |     |  `----.|  `--'  | |  `--'  | |  |\  \----.    / /_  
|__|     |_______| \______/   \______/  | _| `._____|   |____| 
 ");
                    break;

                default:
                    TypeWithDelay(@"
                          
 _____        _                            _   _                  
/__   \___   | |__   ___    ___ ___  _ __ | |_(_)_ __  _   _  ___ 
  / /\/ _ \  | '_ \ / _ \  / __/ _ \| '_ \| __| | '_ \| | | |/ _ \
 / / | (_) | | |_) |  __/ | (_| (_) | | | | |_| | | | | |_| |  __/
 \/   \___/  |_.__/ \___|  \___\___/|_| |_|\__|_|_| |_|\__,_|\___|
                                                                  

                          ");
                    break;
            }
        }

        public void PrintTutorialText()
        {
            TypeWithDelay(" So before we begin, lets have a tutorial about the combat system in this game.");
            TypeWithDelay("Tutorial Stage");

            TypeWithDelay("As of now , you can only do basic attacks so ye pain. ");
            TypeWithDelay("Anyway, this battle system here is {turn-based} since console app moment. ");
            TypeWithDelay("Usually you will have the first to use the turn then it's the enemy's turn");
            TypeWithDelay("The controls during battle are: \n");

            TypeWithDelay("[1] for basic attack   ");
            TypeWithDelay("[2] for first skill    ");
            TypeWithDelay("[3] for ultimate skill \n");
            TypeWithDelay("[Q] for stat check     ");
            TypeWithDelay("[E] for using the equipped item   ");
            TypeWithDelay("[H] for help panel   ");

            TypeWithDelay("BTW, you don't need to press Enter during the battle, since the developer will suffer just for good user experience LMAO");
            TypeWithDelay("Anyway, before you encounter an enemy later");
            TypeWithDelay("You are only enable to do a basic attack");
            TypeWithDelay("I hope you should remember that");

            TypeWithDelay("SO are you ready to suffer? ");
            TypeWithDelay("Press [Enter] to continue");
        }
       
    }
}
