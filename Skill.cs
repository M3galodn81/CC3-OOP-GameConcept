using Microsoft.VisualBasic;

namespace TowerGame{

    public class Skill {
        public int id = 0;
        public string name = "";
        public string description = "";


        public Boolean isReady;
        public int skill_point_limit = 5;
        public int skill_point = 0;
        public int number_of_turns_in_effect = 0;


        public int skill_type = 1;
        // 1 for heal
        // 2 for hp increase
        // 3 for attack
        // 4 for def
        // 5 for magic res

        public Boolean canBeUltimate = false;


        public int heal_amount = 0; 
        public int heal_percentage = 0; 
        public int hp_increase_percentage = 0; 
        public int hp_increase_amount = 0;

        public int attack_type = 0; // 1 physical , 2 magic , 3 mixed

        public int attack_amount = 0; 
        public int attack_percentage = 0; 
        public int attack_increase_percentage = 0; 
        public int attack_increase_amount = 0;


        public int defense_amount = 0; 
        public int defense_percentage = 0; 
        public int defense_increase_percentage = 0; 
        public int defense_increase_amount = 0;


        public int magic_defense_amount = 0; 
        public int magic_defense_percentage = 0; 
        public int magic_defense_increase_percentage = 0; 
        public int magic_defense_increase_amount = 0;

        public void SkillGeneralSetup(int id_input ,string name_input, string description_input, int skill_point_input,int skill_point_limit_input , int in_effect_input){
            id = id_input;
            name = name_input;
            description = description_input;
            skill_point = skill_point_input;
            skill_point_limit = skill_point_limit_input;

            if (skill_point == skill_point_limit){
                isReady = true;
            } else {
                isReady = false;
            }
            number_of_turns_in_effect = in_effect_input;
        }

        public void SkillHPSetup(int heal_amount_input, int heal_percentage_input, int hp_increase_amount_input , int hp_increase_percentage_input){
            heal_amount = heal_amount_input;
            heal_percentage = heal_percentage_input;
            hp_increase_amount = hp_increase_percentage_input;
            hp_increase_percentage = hp_increase_percentage_input;
        }

        public void SkillAttackSetup(int attack_type_input, int attack_amount_input, int attack_percentage_input, int attack_increase_amount_input , int attack_increase_percentage_input){
            attack_type = attack_type_input;
            attack_amount = attack_amount_input;
            attack_percentage = attack_percentage_input;
            attack_increase_amount = attack_increase_percentage_input;
            attack_increase_percentage = attack_increase_percentage_input;
        }

        public void SkillDefenseSetup(int defense_amount_input, int defense_percentage_input, int defense_increase_amount_input , int defense_increase_percentage_input){
            defense_amount = defense_amount_input;
            defense_percentage = defense_percentage_input;
            defense_increase_amount = defense_increase_percentage_input;
            defense_increase_percentage = defense_increase_percentage_input;
        }

        public void SkillMagicDefenseSetup(int magic_defense_amount_input, int magic_defense_percentage_input, int magic_defense_increase_amount_input , int magic_defense_increase_percentage_input){
            magic_defense_amount = magic_defense_amount_input;
            magic_defense_percentage = magic_defense_percentage_input;
            magic_defense_increase_amount = magic_defense_increase_percentage_input;
            magic_defense_increase_percentage = magic_defense_increase_percentage_input;
        }

        public void UseSkill(Enemy enemy){
            // 1 for heal
            // 2 for hp increase
            // 3 for attack
            // 4 for def
            // 5 for magic res
            int n = number_of_turns_in_effect;
            
                switch (skill_type){
                    case 1:
                        
                        if (heal_percentage != 0){
                            enemy.hp += Convert.ToInt32(heal_percentage / 100 * enemy.hp_limit);
                        }
                        enemy.hp += hp_increase_amount;

                        if (enemy.hp >= enemy.hp_limit){
                            enemy.hp = enemy.hp_limit; 
                        }

                        break;

                    case 2:
                        if (hp_increase_percentage != 0){
                                enemy.hp_limit = Convert.ToInt32((hp_increase_percentage / 100 * enemy.hp_limit) + enemy.hp_limit);
                        }
                        enemy.hp_limit += hp_increase_amount;
                        
                        if (enemy.hp >= enemy.hp_limit){
                            enemy.hp = enemy.hp_limit; 
                        }
                        break;

                    case 3:
                        enemy.basic_attack_type = attack_type;

                        if (attack_increase_percentage != 0){
                                    enemy.physical_attack = Convert.ToInt32((attack_increase_percentage / 100 * enemy.physical_attack) + enemy.physical_attack);
                            }
                        enemy.physical_attack += attack_increase_amount;

                        if (attack_increase_percentage != 0){
                                    enemy.magic_attack = Convert.ToInt32((attack_increase_percentage / 100 * enemy.magic_attack) + enemy.magic_attack);
                            }
                        enemy.magic_attack += attack_increase_amount;

                        if (attack_percentage != 0){
                            enemy.physical_attack = (attack_percentage / 100 * enemy.physical_attack) + enemy.physical_attack;
                        }
                        enemy.physical_attack += attack_amount;

                        if (attack_percentage != 0){
                            enemy.magic_attack = (attack_percentage / 100 * enemy.magic_attack) + enemy.magic_attack;
                        }
                        enemy.magic_attack += attack_amount;

                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            
        }

        public void UseSkill(MainCharacter enemy){
            // 1 for heal
            // 2 for hp increase
            // 3 for attack
            // 4 for def
            // 5 for magic res
            int n = number_of_turns_in_effect;
            
                switch (skill_type){
                    case 1:
                        
                        if (heal_percentage != 0){
                            enemy.hp += Convert.ToInt32(heal_percentage / 100 * enemy.hp_limit);
                        }
                        enemy.hp += hp_increase_amount;

                        if (enemy.hp >= enemy.hp_limit){
                            enemy.hp = enemy.hp_limit; 
                        }

                        break;

                    case 2:
                        if (hp_increase_percentage != 0){
                                enemy.hp_limit = Convert.ToInt32((hp_increase_percentage / 100 * enemy.hp_limit) + enemy.hp_limit);
                        }
                        enemy.hp_limit += hp_increase_amount;
                        
                        if (enemy.hp >= enemy.hp_limit){
                            enemy.hp = enemy.hp_limit; 
                        }
                        break;

                    case 3:
                        enemy.basic_damage_type = attack_type;

                        if (attack_increase_percentage != 0){
                                    enemy.physical_attack = Convert.ToInt32((attack_increase_percentage / 100 * enemy.physical_attack) + enemy.physical_attack);
                            }
                        enemy.physical_attack += attack_increase_amount;

                        if (attack_increase_percentage != 0){
                                    enemy.magic_attack = Convert.ToInt32((attack_increase_percentage / 100 * enemy.magic_attack) + enemy.magic_attack);
                            }
                        enemy.magic_attack += attack_increase_amount;

                        if (attack_percentage != 0){
                            enemy.physical_attack = (attack_percentage / 100 * enemy.physical_attack) + enemy.physical_attack;
                        }
                        enemy.physical_attack += attack_amount;

                        if (attack_percentage != 0){
                            enemy.magic_attack = (attack_percentage / 100 * enemy.magic_attack) + enemy.magic_attack;
                        }
                        enemy.magic_attack += attack_amount;

                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            
        }

        public void SkillInfo(){
            string effect;
            string status;
            string a_type;
            
            if (isReady == true){
                status = "Skill is ready to use";
            } else {
                status = "Needs to be charged";
            }

            if (number_of_turns_in_effect == 0){
                effect = "Instantly in one turn";
            } else {
                effect = "Lasts for " + Convert.ToString(number_of_turns_in_effect + 1) + " turns" ;
            }

             

            Console.WriteLine("============================================================");
            Console.WriteLine(" | Name                  : " + name + " | ");
            Console.WriteLine(" | Description           : " + description + " | ");
            Console.WriteLine(" | Duration              : " + effect + " | ");
            Console.WriteLine("============================================================");
            Console.WriteLine(" | Status                : " + status + " | ");
            Console.WriteLine(" | Skill Points          : " + skill_point + " / " + skill_point_limit + " | ");
            Console.WriteLine("============================================================");
            CheckContent(heal_amount                ,"Heal Amount");
            CheckContent(heal_percentage            ,"Heal Percentage");
            CheckContent(hp_increase_amount         ,"HP Increase Amount");
            CheckContent(hp_increase_percentage     ,"HP Increase Percentage");

            if (attack_type != 0){
                switch (attack_type){
                    case 1:
                        a_type = "Physical Damage"; 
                        Console.WriteLine(" | Attack Type : " + a_type + " | " );
                        break;
                    case 2:
                        a_type = "Magic Damage"; 
                        Console.WriteLine(" | Attack Type : " + a_type + " | " );
                        break;
                    case 3:
                        a_type = "Mixed Damage";
                        Console.WriteLine(" | Attack Type : " + a_type + " | " ); 
                        break;
                    case 4:
                        a_type = "True Damage"; 
                        Console.WriteLine(" | Attack Type : " + a_type + " | " );
                        break;
                }
                
            }  
            
            CheckContent(attack_amount                  ,"Attack Amount");
            CheckContent(attack_percentage              ,"Attack Percentage");
            CheckContent(attack_increase_amount         ,"Attack Increase Amount");
            CheckContent(attack_increase_percentage     ,"Attack Increase Percentage");

            CheckContent(defense_amount                  ,"Defense Amount");
            CheckContent(defense_percentage              ,"Defense Percentage");
            CheckContent(defense_increase_amount         ,"Defense Increase Amount");
            CheckContent(defense_increase_percentage     ,"Defense Increase Percentage");

            CheckContent(magic_defense_amount                  ,"Magic Defense Amount");
            CheckContent(magic_defense_percentage              ,"Magic Defense Percentage");
            CheckContent(magic_defense_increase_amount         ,"Magic Defense Increase Amount");
            CheckContent(magic_defense_increase_percentage     ,"Magic Defense Increase Percentage");

            Console.WriteLine("============================================================");
        }

        void CheckContent(int stat, string stat_name){
            if (stat != 0){
                Console.WriteLine(" | " + stat_name + " : " + stat +  " | ");
            }
        } 
    }


}