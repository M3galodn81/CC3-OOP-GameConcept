using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TowerGame {
    public  class MainCharacter{
        // Player Info
        public String player_name = "";

        public int role = 0;
        public String role_name = "";

        // Player Progression
        public int current_floor_level = 0;

        // Player Stats
        public float hp = 123;
        public int hp_limit = 123;
        public int physical_attack = 0;
        public int magic_attack = 0;

        public int defense = 0;
        public int magic_defense = 0;





        public void RoleInitiation(int role_number){
            if (role_number == 1){
                role = 1;
                role_name = "Swordmaster";

                
                hp = 150;
                hp_limit = 150;
                physical_attack = 30;
                defense = 20;

            } else if (role_number == 2){
                role = 2;
                role_name = "Wizard";

                hp = 100;
                hp_limit = 100;
                magic_attack = 30;
                magic_defense = 10;

            } else if (role_number == 3){
                role = 3;
                role_name = "Gunslinger";

                hp = 125;
                hp_limit = 125;
                physical_attack = 25;
                defense = 10;

            }
        }

        public void StatCheck(){
            double hp_display = Math.Floor(hp);

            Console.WriteLine("============================================================");
            Console.WriteLine("| Player Name: " + player_name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| Role: " + role_name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| HP : " + hp_display + "/"+ hp_limit + " |");
            Console.WriteLine("| Attack (Physical): " + physical_attack + " |");
            Console.WriteLine("| Attack (Magic): " + magic_attack + " |");
            Console.WriteLine("| Defense: " + defense + " |");
            Console.WriteLine("| Defense (Magic): " + magic_defense + " |");
            Console.WriteLine("============================================================");
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

        public void LevelUp(){
            current_floor_level += 1;
            switch (role){
                case 1:
                    break;
                
                case 2:
                    break;
                
                case 3:
                    break;
                
            }
        }


        public void UpdateHP(int enemy_damage){
            hp = hp - enemy_damage;

            if (hp <= 0){
                hp = 0;
            }
        }
    }
}