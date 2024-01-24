using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TowerGame {
    public  class MainCharacter{
        // Player Info
        public String player_name = "";


        // Player Progression
        public int current_floor_level = 0;
        public int basic_enemy_kills = 0;
        public int elite_enemy_kills = 0;
        public int negotiation_skill_level = 0;

        // Player Stats
        public double hp = 150;
        public int hp_limit = 150;
        public int physical_attack = 30;
        public int magic_attack = 0;

        public int defense = 0;
        public int magic_defense = 0;

        public Item equipped_item = null;

        public Skill first_skill = null;

        
        public void NameAssignment(){
            
            while (true){
                Console.WriteLine("Hello, Type your username");
                String user_input = Console.ReadLine();
                if (user_input == "" || user_input == ""){
                    Console.WriteLine("The username cannot be blank.");
                    continue;
                } else {
                    player_name = user_input;
                    break;
                }
            }
        }

        public void StatCheck(){
            double hp_display = Math.Floor(hp);
            string item_display = "No Item";
            string skill_display = "No Skill Learned";

            if (equipped_item != null){
                item_display = equipped_item.name;
            }

            if (first_skill != null){
                skill_display = first_skill.name ;
            }

            Console.WriteLine("============================================================");
            Console.WriteLine("| Player Name            : " + player_name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| HP                     : " + hp_display + "/"+ hp_limit + " |");
            Console.WriteLine("| Attack (Physical)      : " + physical_attack + " |");
            Console.WriteLine("| Attack (Magic)         : " + magic_attack + " |");
            Console.WriteLine("| Defense                : " + defense + " |");
            Console.WriteLine("| Defense (Magic)        : " + magic_defense + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| Equipped Item          : " + item_display + " |");
            Console.WriteLine("| First Skill            : " + skill_display + " |");
            Console.WriteLine("============================================================\n");


        }
        
        public void pickItem(Item item){
            if (equipped_item == null) {
                equipped_item = item;
            } else if (item.id_number == equipped_item.id_number) {
                equipped_item.amount = equipped_item.amount + item.amount;
            } else {
                // prompts the user to decides if they what to change their equipped item;

                Console.WriteLine("You can only hold 1 kind of an item.");
                Console.WriteLine("You can either keep your " + equipped_item.name + " or pick the " + item.name + ". " ); 
                
                while (true){
                    Console.WriteLine("Type [E] to equipped the " + item.name);
                    Console.WriteLine("Type [X] to keep your " + equipped_item.name);

                    string user_input = Console.ReadLine();
                    switch (user_input){
                        case "E":
                            Console.WriteLine("You equipped " + item.name  +".");
                            break;
                        case "X":
                            Console.WriteLine("You keep your " + equipped_item.name  +".");
                            break;
                        default:
                            Console.WriteLine("Use capital letters. [E] and [X] are the only options here.");
                            continue;
                    }
                    break;
                }
            }
        }

        public Boolean isDead(){
            if (hp <= 0){
                return true;
            } else {
                return false;
            }
        }

        public void hpCheck(){
            // prevent overheal
            if (hp >= hp_limit){
                hp = hp_limit; 
            }
        }

        public void UpdateHP(double enemy_damage){
            hp = hp - enemy_damage;

            if (hp <= 0){
                hp = 0;
            }
        }
    }
}