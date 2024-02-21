using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TowerGame
{
    class Program
    {
        // TODO 
        // Item Application
        // Skill 
        // Elite and Boss
        public static Boolean BattleInterface(MainCharacter player,Enemy enemy){
            int turns = 0;

            // display
            while (!player.isDead() && !enemy.isDead()){
                
                Console.WriteLine("==========================================");
                Console.WriteLine("| " + player.player_name + " | " + Convert.ToInt32(player.hp) + " / " + player.hp_limit + " |") ;
                Console.WriteLine("==========================================");
                Console.WriteLine("| " + enemy.name + " | " + Convert.ToInt32(enemy.hp) + " / " + enemy.hp_limit + " |") ;
                Console.WriteLine("==========================================\n");


            // player's turn
            Boolean quitLoop = false;
            do {
                switch (Console.ReadKey(true).Key){

                    case ConsoleKey.D1 :
                        if (player.basic_damage_type == 1) {
                            Console.WriteLine(player.player_name + " deals " + enemy.UpdateHP(player.physical_attack,1) + " to " + enemy.name);
                            
                            quitLoop = true;
                        } else if (player.basic_damage_type == 2) {
                            Console.WriteLine(player.player_name + " deals " + enemy.UpdateHP(player.magic_attack,2) + " to " + enemy.name);
                            
                            quitLoop = true;
                        }
                        break;  

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
                            player.equipped_item.UseItem(player);
                            Console.WriteLine(player.player_name + " used a " + player.equipped_item);
                            if (player.equipped_item.isEmpty() == true){
                                Console.WriteLine(player.player_name + " used their last " + player.equipped_item);
                                player.equipped_item.id_number = -1;
                            }
                            quitLoop = true;
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

            // enemy's turn

            if (!enemy.isDead()){
                if (enemy.GetType() == typeof(Enemy)){
                    switch (enemy.basic_attack_type){
                        case 1:
                            player.UpdateHP(enemy.physical_attack,1);
                            Console.WriteLine(String.Format("{0} deals {1} damage to {2}",enemy.name,    Convert.ToInt32(player.UpdateHP(enemy.physical_attack,1)),player.player_name));
                            break;
                        case 2:
                            player.UpdateHP(enemy.magic_attack,2);
                            Console.WriteLine(String.Format("{0} deals {1} damage to {2}",enemy.name,    Convert.ToInt32(player.UpdateHP(enemy.magic_attack,2)),player.player_name));
                            break;
                        case 3:
                            player.UpdateHP((enemy.physical_attack + enemy.magic_attack)/1.5,3);
                            Console.WriteLine(String.Format("{0} deals {1} damage to {2}",enemy.name,    Convert.ToInt32(player.UpdateHP((enemy.physical_attack + enemy.magic_attack)/1.5,3)),player.player_name));
                            break;
                        case 4:
                            player.UpdateHP(enemy.physical_attack + enemy.magic_attack,4);
                            Console.WriteLine(String.Format("{0} deals {1} damage to {2}",enemy.name,    Convert.ToInt32(player.UpdateHP(enemy.physical_attack + enemy.magic_attack,4)),player.player_name));
                            break;
                    }
                } 
                else if (enemy.GetType() == typeof(EliteEnemy)){
                    var elite = enemy as EliteEnemy;
                    if (elite != null){
                        if (elite.first_skill.isReady == true){
                            elite.first_skill.UseSkill(enemy);
                        } else {
                            // basic attack
                            elite.first_skill.skill_point++; // add sp


                            switch (elite.basic_attack_type){
                                case 1:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",elite.name,   Convert.ToInt32(player.UpdateHP(elite.physical_attack,1)),player.player_name));
                                    break;
                                case 2:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",elite.name,   Convert.ToInt32(player.UpdateHP(elite.magic_attack,2)),player.player_name));
                                    break;
                                case 3:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",elite.name,   Convert.ToInt32(player.UpdateHP((elite.physical_attack + elite.magic_attack)/1.5,3)),player.player_name));
                                    break;
                                case 4:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",elite.name,   Convert.ToInt32(player.UpdateHP(elite.physical_attack + elite.magic_attack,4)),player.player_name));
                                    break;
                            }
                        }
                    } else {
                        Console.WriteLine("Something is Wrong :( ");
                    }

                } else {
                    var boss = enemy as BossEnemy;
                    if (boss != null){
                        if (boss.first_skill.isReady == true){
                            boss.first_skill.UseSkill(enemy);
                        } else if (boss.ultimate.isReady == true){
                            boss.first_skill.UseSkill(enemy);
                        } else {
                            // basic attack
                            boss.first_skill.skill_point++; // add sp


                            switch (boss.basic_attack_type){
                                case 1:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",boss.name,   Convert.ToInt32(player.UpdateHP(boss.physical_attack,1)),player.player_name));
                                    break;
                                case 2:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",boss.name,   Convert.ToInt32(player.UpdateHP(boss.magic_attack,2)),player.player_name));
                                    break;
                                case 3:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",boss.name,   Convert.ToInt32(player.UpdateHP((boss.physical_attack + boss.magic_attack)/1.5,3)),player.player_name));
                                    break;
                                case 4:
                                    Console.WriteLine(String.Format("{0} deals {1} damage to {2}",boss.name,   Convert.ToInt32(player.UpdateHP(boss.physical_attack + boss.magic_attack,4)),player.player_name));
                                    break;
                            }
                        }
                    } else {
                        Console.WriteLine("Something is Wrong :( ");
                    }

                }
            }
            turns++;
            }

            Thread.Sleep(1000);
            Console.Clear();
            // end battle and reward player
            if (enemy.isDead() == true){
                if (enemy.GetType() == typeof(Enemy)){
                    player.basic_enemy_kills ++;
                    player.pickItem(enemy.loot);
                } else if(enemy.GetType() == typeof(EliteEnemy)){
                    player.elite_enemy_kills ++;
                    player.pickItem(enemy.loot);

                } else if(enemy.GetType() == typeof(BossEnemy)){
                    player.boss_enemy_kills ++;
                    player.pickItem(enemy.loot);

                } 
                return true;
            } else {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(@"
 ██████   █████  ███    ███ ███████      ██████  ██    ██ ███████ ██████  
██       ██   ██ ████  ████ ██          ██    ██ ██    ██ ██      ██   ██ 
██   ███ ███████ ██ ████ ██ █████       ██    ██ ██    ██ █████   ██████  
██    ██ ██   ██ ██  ██  ██ ██          ██    ██  ██  ██  ██      ██   ██ 
 ██████  ██   ██ ██      ██ ███████      ██████    ████   ███████ ██   ██ 
                                                                          
                                                                          
");
                Thread.Sleep(1000);
                Environment.Exit(0);

                return false;
            }
        }
        public static void TypeWithDelay(string text, int delayMilliseconds = 10)
            {   
                text = text.Replace("\\n", Environment.NewLine);
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(delayMilliseconds);
                }
                Console.Write("\n");
            }
        static void Main(string[] args)
        {
        //     #region Class Declaration for CC3 checking

        //     // MainCharacter player = new MainCharacter();
        //     // player.NameAssignment();
        //     // player.StatCheck();

        //     // Item basic_health_potion = new Item();
        //     // basic_health_potion.ItemGeneralSetup(1, "Basic Health Potion", "A potion that can heal small amount of HP", 1, 0);
        //     // basic_health_potion.ItemHPSetup(25,0,0,0);

        //     // player.pickItem(basic_health_potion);
        //     // player.StatCheck();

        //     // Skill fireball = new Skill();
        //     // fireball.SkillGeneralSetup(1,"Fireball", "Shoot a fireball to the enemy to deal magic damage",0,2,0);
        //     // fireball.SkillAttackSetup(2,50,0,0,0);

        //     // player.first_skill = fireball;

        //     // player.StatCheck();

        //     // fireball.SkillInfo();

        //     // Enemy slime = new Enemy();
        //     // slime.SetUp("Slime","A small creature",30,30,20,20,0,0);

        //     // slime.StatCheck();

        //     // BattleInterface(player,slime);

        //     #endregion

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            #region Start of the Game
            // Beginning Script
            Console.WriteLine(@"
__________                       __________        .__                            .___   _________       _____  _____            .__                
\______   \__ _________   ____   \______   \_____  |__| ____   _____    ____    __| _/  /   _____/__ ___/ ____\/ ____\___________|__| ____    ____  
 |     ___/  |  \_  __ \_/ __ \   |     ___/\__  \ |  |/    \  \__  \  /    \  / __ |   \_____  \|  |  \   __\\   __\/ __ \_  __ \  |/    \  / ___\ 
 |    |   |  |  /|  | \/\  ___/   |    |     / __ \|  |   |  \  / __ \|   |  \/ /_/ |   /        \  |  /|  |   |  | \  ___/|  | \/  |   |  \/ /_/  >
 |____|   |____/ |__|    \___  >  |____|    (____  /__|___|  / (____  /___|  /\____ |  /_______  /____/ |__|   |__|  \___  >__|  |__|___|  /\___  / 
                             \/                  \/        \/       \/     \/      \/          \/                        \/              \//_____/  
");
            TypeWithDelay("Your goal is to escape the castle while rescuing the queen while encountering a lot of enemies . GLHF :)");
            TypeWithDelay("\" A \" \n");


            // User Input (Name)
            MainCharacter player = new MainCharacter();
            player.NameAssignment();
            player.StatCheck();
            Console.Clear();
            TypeWithDelay(" So before we begin, lets have a tutorial about the combat system in this game.");

            #endregion

            #region Battle Tutorial Phase? ig
        
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


            do {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) {
                    break;
            }       
            } while (! Console.KeyAvailable);
            
            Console.Clear();

            Enemy mini_slime = new Enemy();
            mini_slime.SetUp("Small Slime","A small goofy ah creature",40,40,0,7,0,0,2);
            
            if(BattleInterface(player,mini_slime) == false){
                Console.WriteLine("wha uoghhhhhh");
            } else {
                TypeWithDelay("Congrats you beat the tutorial stage");
            }

            
            #endregion

            #region Start

            Console.WriteLine(@"
 _______  __        ______     ______   .______          __  
|   ____||  |      /  __  \   /  __  \  |   _  \        /_ | 
|  |__   |  |     |  |  |  | |  |  |  | |  |_)  |        | | 
|   __|  |  |     |  |  |  | |  |  |  | |      /         | | 
|  |     |  `----.|  `--'  | |  `--'  | |  |\  \----.    | | 
|__|     |_______| \______/   \______/  | _| `._____|    |_| 
                                                             

");

            Floor floor1 = new Floor(1);
            player.hp = player.hp_limit;
            Console.WriteLine(string.Join(", ", floor1.floor_rooms));
            floor1.Explore(player);


            Console.WriteLine(@"
 _______  __        ______     ______   .______          ___   
|   ____||  |      /  __  \   /  __  \  |   _  \        |__ \  
|  |__   |  |     |  |  |  | |  |  |  | |  |_)  |          ) | 
|   __|  |  |     |  |  |  | |  |  |  | |      /          / /  
|  |     |  `----.|  `--'  | |  `--'  | |  |\  \----.    / /_  
|__|     |_______| \______/   \______/  | _| `._____|   |____| 
 ");                                                              

            Floor floor2 = new Floor(2);
            player.hp = player.hp_limit;
            floor2.Explore(player);

            Console.WriteLine(@"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝
                                                      
");

            #endregion

        }
    }
}
