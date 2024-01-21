using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace TowerGame
{
    class Program
    {
        static void Main(string[] args)
        {


            // Beginning Script
            Console.WriteLine("Welcome to the Game of Pure Pain of Suffering");
            Console.WriteLine("Your goal is to make to the last chamber in the 13th floor. GLHF :)");

            // User Input (Name)
            String name = "";
            MainCharacter player = new MainCharacter();
            while (name == ""){
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
                if (name == ""){
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


        }
    }
}