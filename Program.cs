using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;


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
            TextScript textScript = new TextScript();

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            #region Start of the Game
            // Beginning Script
            textScript.PrintTitleScreen();

            // User Input (Name)
            MainCharacter player = new MainCharacter();
            player.NameAssignment();
            player.StatCheck();
            Console.Clear();

            #endregion

            #region Battle Tutorial Phase? ig
            textScript.PrintTutorialText();
            do {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) {
                    break;
            }       
            } while (! Console.KeyAvailable);
            
            Console.Clear();

            Enemy mini_slime = new Enemy();
            mini_slime.SetUp("Small Slime","A small goofy ah creature",40,40,0,7,0,0,2);
            
            if (BattleInterface(player,mini_slime) == false){
                Console.WriteLine("wha uoghhhhhh");
            } else {
                TypeWithDelay("Congrats you beat the tutorial stage");
            }


            #endregion

            #region Start

            for (int i = 1; i < 3; i++)
            {
                textScript.PrintFloorNumber(i);
                Floor current_floor = new Floor(i);
                Console.WriteLine(string.Join(", ", current_floor.floor_rooms));
                current_floor.Explore(player);
            }



           TypeWithDelay("As the player finally reached the inner chamber of the crimson castle, a sense of anticipation and excitement filled the air. In the heart of the castle, the queen awaited, her regal presence commanding respect and admiration.");
            TypeWithDelay("Player: \"Your Majesty, we must leave this place swiftly. The castle is crumbling around us.\"");
            TypeWithDelay("Queen: \"Thank you for coming to my rescue. I trust in your abilities to lead us out safely.\"");
            TypeWithDelay("Together, they navigated through the crumbling corridors and dodged falling debris. The player cleared the path, while the queen followed closely behind.");
            TypeWithDelay("Queen: \"I place my trust in you, brave hero. I know we will make it out together.\"");
            TypeWithDelay("With a final push, they emerged from the castle, the once-imposing structure now reduced to rubble behind them. The queen looked out at the horizon, a sense of relief washing over her.");
            TypeWithDelay("Queen: \"We have escaped the danger, thanks to your bravery. May we never forget this adventure.\"");
            TypeWithDelay("Player: \"It was an honor to assist you, Your Majesty. Let us continue on our journey, for more challenges await us.\"");
            TypeWithDelay("And with that, the player and the queen ventured forth, ready to face whatever adventure awaited them next.");

            TypeWithDelay(@"
                          
 _____        _                            _   _                  
/__   \___   | |__   ___    ___ ___  _ __ | |_(_)_ __  _   _  ___ 
  / /\/ _ \  | '_ \ / _ \  / __/ _ \| '_ \| __| | '_ \| | | |/ _ \
 / / | (_) | | |_) |  __/ | (_| (_) | | | | |_| | | | | |_| |  __/
 \/   \___/  |_.__/ \___|  \___\___/|_| |_|\__|_|_| |_|\__,_|\___|
                                                                  

                          ");
            
            TypeWithDelay(@"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝
                                                      
",5);

            #endregion

        }
    }
}
