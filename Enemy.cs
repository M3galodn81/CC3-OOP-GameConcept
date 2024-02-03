using System.Runtime.ConstrainedExecution;

namespace TowerGame{
    public class Enemy{

        public string name = "Enemy";
        public string description = "";
        public double hp = 123;
        public int hp_limit = 123;
        public int physical_attack = 0;
        public int magic_attack = 0;

        public int defense = 0;
        public int magic_defense = 0;
        public int basic_attack_type = 1;
        

        public Boolean isDead(){
            if (hp <= 0){
                return true;
            } else {
                return false;
            }
        }

        public double UpdateHP(double enemy_damage,int attack_type){
            double after_dmg = 0 ;

            switch (attack_type){
                    case 1:
                        hp = hp - (enemy_damage - defense);
                        after_dmg = enemy_damage - defense;
                        break;
                    case 2:
                        double final_magic_attack = enemy_damage * (1 -(magic_defense * 0.01d));
                        hp = hp - final_magic_attack;
                        after_dmg = final_magic_attack;
                        break;
                    case 3:
                        hp = hp - (enemy_damage - defense);
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

        public void StatCheck(){
            double hp_display = Math.Floor(hp);

            Console.WriteLine("============================================================");
            Console.WriteLine("| Enemy Name             : " + name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| Description            : " + description + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| HP                     : " + hp_display + "/"+ hp_limit + " |");
            Console.WriteLine("| Attack (Physical)      : " + physical_attack + " |");
            Console.WriteLine("| Attack (Magic)         : " + magic_attack + " |");
            Console.WriteLine("| Defense                : " + defense + " |");
            Console.WriteLine("| Defense (Magic)        : " + magic_defense + " |");
            Console.WriteLine("============================================================");
        
        }
    
        public void SetUp(string name_input, string description_input, float hp_input, int hp_limit_input, int physical_attack_input, int magic_attack_input, int defense_input, int magic_defense_input,int basic){
            name = name_input;
            description = description_input;
            hp = hp_input;
            hp_limit = hp_limit_input;
            physical_attack = physical_attack_input;
            magic_attack = magic_attack_input;
            defense = defense_input;
            magic_defense = magic_defense_input; 
            
            basic_attack_type = basic;
        }
    }

    public class EliteEnemy : Enemy{
         public Skill first_skill = null;
    }

    public class BossEnemy : Enemy{

    }
}
