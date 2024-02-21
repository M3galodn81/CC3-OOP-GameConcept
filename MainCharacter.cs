using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace TowerGame {
    public  class MainCharacter{
        // Player Info
        public String player_name = "";


        // Player Progression
        public int current_floor_level = 0;
        public int basic_enemy_kills = 0;
        public int elite_enemy_kills = 0;
        public int boss_enemy_kills = 0;
        public int negotiation_skill_level = 0;

        // Player Stats
        public double hp = 150;
        public int hp_limit = 150;
        public int physical_attack = 20;
        public int magic_attack = 0;

        public int defense = 20;
        public int magic_defense = 20;

        public int basic_damage_type = 1; // 1 for phys ,2  for magic
        public Item equipped_item = new Item();
        public Weapon equipped_weapon = null;

        public Skill first_skill = null;
        public Skill second_skill = null;
        public Skill ultimate_skill = null;

        public void NameAssignment(){
            
            while (true){
                Program.TypeWithDelay("Hello, Type your username");
                String user_input = Console.ReadLine();
                if (user_input == "" || user_input == ""){
                    Program.TypeWithDelay("The username cannot be blank.");
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
            string weapon_display = "No Weapon";
            string skill_display = "No Skill Learned";

            if (equipped_item != null){
                item_display = equipped_item.name;
            }

            if (equipped_weapon != null){
                item_display = equipped_weapon.name;
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
            Console.WriteLine("| Equipped Weapon        : " + weapon_display + " |");
            
            Console.WriteLine("| First Skill            : " + skill_display + " |");
            Console.WriteLine("============================================================\n");


        }
        
        public void pickItem(Item item){
            if (item.id_number == -1){
                
            } else if (equipped_item.id_number == 0) {
                equipped_item = item;
                Program.TypeWithDelay("You found a " + equipped_item.name + " ["+ equipped_item.amount + "] " + ".");
            } else if (item.id_number == equipped_item.id_number) {
                equipped_item.amount = equipped_item.amount + item.amount;
                Program.TypeWithDelay("You found " + equipped_item.amount + "of "+ equipped_item.name +  ".");
            } else {
                // prompts the user to decides if they what to change their equipped item;

                Program.TypeWithDelay("You can only hold 1 kind of an item.");
                Program.TypeWithDelay("You can either keep your " + equipped_item.name +"[" + equipped_item.amount +"]" +" or pick the " + item.name  +"[" + item.amount +"]. " ); 
                
                while (true){
                    Program.TypeWithDelay("Type [E] to equipped the " + item.name);
                    Program.TypeWithDelay("Type [X] to keep your " + equipped_item.name);

                    string user_input = Console.ReadLine();
                    switch (user_input){
                        case "E":
                            Program.TypeWithDelay("You equipped " + item.name  +".");
                            equipped_item = item;
                            break;
                        case "X":
                            Program.TypeWithDelay("You keep your " + equipped_item.name  +".");
                            break;
                        default:
                            Console.WriteLine("Use capital letters. [E] and [X] are the only options here.");
                            continue;
                    }
                    break;
                }
            }
        }


        public void pickWeapon(Weapon weapon){
            if (equipped_weapon == null) {
                equipped_weapon = weapon;

                basic_damage_type = equipped_weapon.attack_type;

                magic_attack    += equipped_weapon.attack_amount_buff;
                physical_attack += equipped_weapon.attack_amount_buff;

                magic_attack = magic_attack * Convert.ToInt32(1 + equipped_weapon.attack_percent_buff);
                physical_attack = physical_attack * Convert.ToInt32(1 + equipped_weapon.attack_percent_buff);

                magic_defense    += equipped_weapon.defense_amount_buff;
                defense += equipped_weapon.defense_amount_buff;

                magic_defense = magic_defense * Convert.ToInt32(1 + equipped_weapon.defense_percent_buff);
                defense = defense * Convert.ToInt32(1 + equipped_weapon.defense_percent_buff);

                hp_limit += equipped_weapon.hp_amount_buff;
                hp += equipped_weapon.hp_amount_buff;
                

                hp_limit = hp_limit * Convert.ToInt32(1 + equipped_weapon.hp_percent_buff);

                hpCheck();
            }  else {
                // prompts the user to decides if they what to change their equipped weapon;

                Console.WriteLine("You can only hold 1 weapon.");
                Program.TypeWithDelay("You can either keep your " + equipped_weapon.name + " or pick the " + weapon.name + ". " ); 
                
                while (true){
                    Program.TypeWithDelay("Type [E] to equipped the " + weapon.name);
                    Program.TypeWithDelay("Type [X] to keep your " + equipped_weapon.name);

                    string user_input = Console.ReadLine();
                    switch (user_input){
                        case "E":
                            Program.TypeWithDelay("You equipped " + weapon.name  +".");

                            basic_damage_type = equipped_weapon.attack_type;

                            magic_attack    -= equipped_weapon.attack_amount_buff;
                            physical_attack -= equipped_weapon.attack_amount_buff;

                            magic_attack = magic_attack / Convert.ToInt32(1 + equipped_weapon.attack_percent_buff);
                            physical_attack = physical_attack / Convert.ToInt32(1 + equipped_weapon.attack_percent_buff);

                            magic_defense    -= equipped_weapon.defense_amount_buff;
                            defense -= equipped_weapon.defense_amount_buff;

                            magic_defense = magic_defense / Convert.ToInt32(1 + equipped_weapon.defense_percent_buff);
                            defense = defense / Convert.ToInt32(1 + equipped_weapon.defense_percent_buff);

                            hp_limit -= equipped_weapon.hp_amount_buff;
                            hp -= equipped_weapon.hp_amount_buff;
                            

                            hp_limit = hp_limit * Convert.ToInt32(1 + equipped_weapon.hp_percent_buff);


                                equipped_weapon = weapon;

                            basic_damage_type = equipped_weapon.attack_type;

                            magic_attack    += equipped_weapon.attack_amount_buff;
                            physical_attack += equipped_weapon.attack_amount_buff;

                            magic_attack = magic_attack * Convert.ToInt32(1 + equipped_weapon.attack_percent_buff);
                            physical_attack = physical_attack * Convert.ToInt32(1 + equipped_weapon.attack_percent_buff);

                            magic_defense    += equipped_weapon.defense_amount_buff;
                            defense += equipped_weapon.defense_amount_buff;

                            magic_defense = magic_defense * Convert.ToInt32(1 + equipped_weapon.defense_percent_buff);
                            defense = defense * Convert.ToInt32(1 + equipped_weapon.defense_percent_buff);

                            hp_limit += equipped_weapon.hp_amount_buff;
                            hp += equipped_weapon.hp_amount_buff;
                            

                            hp_limit = hp_limit * Convert.ToInt32(1 + equipped_weapon.hp_percent_buff);

                            hpCheck();


                            break;
                        case "X":
                            Program.TypeWithDelay("You keep your " + equipped_weapon.name  +".");
                            break;
                        default:
                            Console.WriteLine("Use capital letters. [E] and [X] are the only options here.");
                            continue;
                    }
                    break;
                }
            }
        }

        public void learnSkill(Skill skill){
            if (first_skill == null && skill.canBeUltimate == false){
                first_skill = skill;
                Program.TypeWithDelay("You learn " + skill.name  +".");

            } else if (second_skill == null && skill.canBeUltimate == false){
                Program.TypeWithDelay("You learn " + skill.name  +".");
                second_skill = skill;

            } else {
                Program.TypeWithDelay("You can only have 2 skills pnly");
                Program.TypeWithDelay(String.Format("You can replace {0} or {1} with {2} or",first_skill.name ,second_skill.name , skill.name));
                Program.TypeWithDelay(String.Format("don't learn {0}",skill));

                while (true){
                    Program.TypeWithDelay("Press [1] if you want to replace " + first_skill.name + " with " + skill.name + ".");
                    Program.TypeWithDelay("Press [2] if you want to replace " + second_skill.name + " with " + skill.name + ".");
                    Program.TypeWithDelay("Press [X] if you want to keep your skills.");

                    string user_input = Console.ReadLine();
                    switch (user_input){
                        case "1":
                            Program.TypeWithDelay("You learn " + skill.name  +" replacing "+ first_skill.name +".");
                            break;
                        case "2":
                            Program.TypeWithDelay("You learn " + skill.name  +" replacing "+ second_skill.name +".");
                            break;
                        default:
                            Program.TypeWithDelay("Use capital letters. [1], [2] and [X] are the only options here.");
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

        public double UpdateHP(double enemy_damage,int attack_type){
            double after_dmg = 0 ;

            switch (attack_type){
                    case 1:
                        if (enemy_damage >= defense){
                            hp = hp - (enemy_damage - defense);
                            after_dmg = enemy_damage - defense;
                        }
                        after_dmg = 0;
                        break;
                    case 2:
                        double final_magic_attack = enemy_damage * (1 -(magic_defense * 0.01d));
                        hp = hp - final_magic_attack;
                        after_dmg = final_magic_attack;
                        break;
                    case 3:
                        if (enemy_damage >= defense){
                            hp = hp - (enemy_damage - defense);
                        }
                        hp = hp - (enemy_damage * (1 -(magic_defense * 0.01d)));
                        after_dmg = (enemy_damage - defense) + (enemy_damage * (1 -(magic_defense * 0.01d)));
                        break;
                    case 4:
                        hp = hp - enemy_damage;
                        after_dmg = enemy_damage;
                        break;
                }
            

            if (hp <= 0){
                hp = 0;
            }

            return after_dmg;
        }
    }
}