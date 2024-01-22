using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TowerGame
{
    class Program
    {
        public static void BattleInterface(MainCharacter player,Enemy enemy){
            Boolean quitLoop = false;
            do {
                switch (Console.ReadKey(true).Key){

                    case ConsoleKey.D1 :

                        if (player.role != 2){
                            Console.WriteLine(player.player_name + " deals " + player.physical_attack + " to " + enemy.name);
                            enemy.UpdateHP(player.physical_attack - enemy.defense);
                            quitLoop = true;
                            break;
                        } else {
                            Console.WriteLine(player.player_name + " deals " + player.magic_attack + " to " + enemy.name);
                            enemy.UpdateHP(player.magic_attack * (100 - enemy.magic_defense) * 0.01 );
                            quitLoop = true;
                            break;
                        } 
                        

                    case ConsoleKey.D2:

                        if (player.first_skill == null){
                            Console.WriteLine("You don't have a skill yet");
                            
                            break;
                        } else {
                            break;
                        }

                    case ConsoleKey.D3:
                        if (player.first_skill == null){
                            Console.WriteLine("You don't have a ultimate skill yet");
                            
                            break;
                        } else {
                            break;
                        }

                    case ConsoleKey.Q:
                        player.StatCheck();
                        Console.WriteLine("\n");
                        enemy.StatCheck();
                        
                        break;

                    case ConsoleKey.E:
                        if (player.equipped_item == null){
                            Console.WriteLine("You don't have an item yet");
                            
                            break;
                        } else {
                            break;
                        }
                        
                    case ConsoleKey.H:
                        Console.WriteLine("[1] for basic attack   ");
                        Console.WriteLine("[2] for first skill    ");
                        Console.WriteLine("[3] for ultimate skill \n");
                        Console.WriteLine("[Q] for stat check     ");
                        Console.WriteLine("[E] for using the equipped item   ");
                        Console.WriteLine("[H] for help panel   ");
                        break;
                    
                    default:
                        Console.WriteLine("Press [H] if you need help with the controls");
                        break;
                
                
                
                }

            } while (! Console.KeyAvailable && !quitLoop);
        }
       
        static void Main(string[] args)
        {
            #region Start of the Game
            // Beginning Script
            Console.WriteLine("Welcome to the Game of Pure Pain of Suffering");
            Console.WriteLine("Your goal is to make to the last chamber in the 13th floor. GLHF :)");

            // User Input (Name)
            String name = "";
            MainCharacter player = new MainCharacter();
            while (name == "" || name == null){
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
                if (name == "" || name == null){
                    Console.WriteLine("The name can't be empty");
                }
            }
            player.player_name = name;


            // User Input (Role)
            
            int player_role = 0;
            while (true){
                Console.WriteLine("What do you want to be?");
                Console.WriteLine("A [Swordmaster] who can deal a lot of physical damage to the enemies while tanking a lot of damage ,");
                Console.WriteLine("or a [Wizard] who can deal a lot of magic damage to the enemies while being immune to the negative effect status ,");
                Console.WriteLine("or a [Gunslinger] who can deal a lot of physical damage to the enemies without getting attack by strong melee attacks");

                Console.WriteLine("Type");
                Console.WriteLine("[1] for [Swordmaster]");
                Console.WriteLine("[2] for [Wizard]");
                Console.WriteLine("[3] for [Gunslinger]");

                player_role = Convert.ToInt32(Console.ReadLine());
                if (player_role == 1){
                    player.RoleInitiation(1);
                    break;
                } else if (player_role == 2){
                    player.RoleInitiation(2);
                    break;
                } else if (player_role == 3){
                    player.RoleInitiation(3);
                    break;
                } 
            }
            
            player.StatCheck();

            #endregion
            #region Battle Tutorial Phase? ig
            Console.WriteLine("Tutorial Stage");

            Console.WriteLine("As of now , you can only do basic attacks so ye pain. ");
            Console.WriteLine("Anyway, this battle system here is {turn-based} since console app moment. ");
            Console.WriteLine("Usually you will have the first to use the turn then it's the enemy's turn");
            Console.WriteLine("The controls during battle are: \n");

            Console.WriteLine("[1] for basic attack   ");
            Console.WriteLine("[2] for first skill    ");
            Console.WriteLine("[3] for ultimate skill \n");
            Console.WriteLine("[Q] for stat check     ");
            Console.WriteLine("[E] for using the equipped item   ");
            Console.WriteLine("[H] for help panel   ");

            Console.WriteLine("BTW, you don't need to press Enter during the battle, since the developer will suffer just for good user experience LMAO");
            Console.WriteLine("Anyway, before you encounter an enemy later");
            Console.WriteLine("You are only enable to do a basic attack");
            Console.WriteLine("I hope you should remember that");

            Console.WriteLine("SO are you ready to suffer? ");
            Console.WriteLine("Press [Enter] to continue");


            do {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) {
                    break;
            }       
            } while (! Console.KeyAvailable);

            BasicEnemy slime = new BasicEnemy("Slime",30,30,0,5,0,0,"A small gooey and goofy creature. Deals small amount of magic damage.");

            // FIGHT with basic enemy

            Console.WriteLine(player.player_name + " vs " + slime.name);

            // Loop will not end until someone dies
            int turns = 0;
            while (!player.isDead() && !slime.isDead()){
                
                Console.WriteLine("==========================================");
                Console.WriteLine("| " + player.player_name + " | " + player.hp + " / " + player.hp_limit + " |") ;
                Console.WriteLine("==========================================");
                Console.WriteLine("| " + slime.name + " | " + slime.hp + " / " + slime.hp_limit + " |") ;
                Console.WriteLine("==========================================\n");

                BattleInterface(player,slime);
                turns++;
                Console.WriteLine(slime.name + "deals " + slime.magic_attack + " magic damage to " + player.player_name);
                player.UpdateHP(slime.magic_attack * (100 - player.magic_defense) * 0.01 );

            }

            if (player.isDead()){
                Console.WriteLine("That should not supposed to happen but ye, howwwwwwwwwwwwwwwwwwwww?");
            }

            Console.WriteLine("Congrats. You defeat the "+ slime.name + " in " + turns +" turn. Cool.");



            #endregion
        }
    }
}