using System.Runtime;

namespace TowerGame{
    public class Item{

        #region General Description
        public int id_number = 0;
        public string name = "";
        public string description = "";
        public int amount = 1;
        public int number_of_turns_in_effect = 0;

        #endregion
    
        #region HP Buff
        public int heal_amount = 0; 
        public int heal_percentage = 0; 
        public int hp_increase_percentage = 0; 
        public int hp_increase_amount = 0;
   
        #endregion

        #region Attack Buff
        public int attack_amount = 0; 
        public int attack_percentage = 0; 
        public int attack_increase_percentage = 0; 
        public int attack_increase_amount = 0;

        #endregion

        #region Defense Buff
        public int defense_amount = 0; 
        public int defense_percentage = 0; 
        public int defense_increase_percentage = 0; 
        public int defense_increase_amount = 0;

        #endregion

        #region Magic Defense Buff
        public int magic_defense_amount = 0; 
        public int magic_defense_percentage = 0; 
        public int magic_defense_increase_percentage = 0; 
        public int magic_defense_increase_amount = 0;

        #endregion

        public void ItemGeneralSetup(int id_number_input , string name_input, string description_input, int amount_input, int in_effect_input){
            id_number = id_number_input;
            name = name_input;
            description = description_input;
            amount = amount_input;
            number_of_turns_in_effect = in_effect_input;
        }

        public void ItemHPSetup(int heal_amount_input, int heal_percentage_input, int hp_increase_amount_input , int hp_increase_percentage_input){
            heal_amount = heal_amount_input;
            heal_percentage = heal_percentage_input;
            hp_increase_amount = hp_increase_percentage_input;
            hp_increase_percentage = hp_increase_percentage_input;
        }

        public void ItemAttackSetup(int attack_amount_input, int attack_percentage_input, int attack_increase_amount_input , int attack_increase_percentage_input){
            attack_amount = attack_amount_input;
            attack_percentage = attack_percentage_input;
            attack_increase_amount = attack_increase_percentage_input;
            attack_increase_percentage = attack_increase_percentage_input;
        }

        public void ItemDefenseSetup(int defense_amount_input, int defense_percentage_input, int defense_increase_amount_input , int defense_increase_percentage_input){
            defense_amount = defense_amount_input;
            defense_percentage = defense_percentage_input;
            defense_increase_amount = defense_increase_percentage_input;
            defense_increase_percentage = defense_increase_percentage_input;
        }

        public void ItemMagicDefenseSetup(int magic_defense_amount_input, int magic_defense_percentage_input, int magic_defense_increase_amount_input , int magic_defense_increase_percentage_input){
            magic_defense_amount = magic_defense_amount_input;
            magic_defense_percentage = magic_defense_percentage_input;
            magic_defense_increase_amount = magic_defense_increase_percentage_input;
            magic_defense_increase_percentage = magic_defense_increase_percentage_input;
        }

        public void SkillInfo(){
            string effect;
            
        

            if (number_of_turns_in_effect == 0){
                effect = "Instantly in one turn";
            } else {
                effect = "Lasts for " + Convert.ToString(number_of_turns_in_effect + 1) + " turns" ;
            }

             

            Console.WriteLine("============================================================");
            Console.WriteLine(" | Name                  : " + name + " | ");
            Console.WriteLine(" | Description           : " + description + " | ");
            Console.WriteLine(" | Amount              : " + amount + " | ");
            Console.WriteLine(" | Duration              : " + effect + " | ");

            Console.WriteLine("============================================================");


            CheckContent(heal_amount                ,"Heal Amount");
            CheckContent(heal_percentage            ,"Heal Percentage");
            CheckContent(hp_increase_amount         ,"HP Increase Amount");
            CheckContent(hp_increase_percentage     ,"HP Increase Percentage");

            
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


        public void QuickSetup(int id){
            switch (id){

                #region HP Potions

                case 1001:
                    ItemGeneralSetup(1001,"Basic Health Potion","A potion that heals you",1,0);
                    ItemHPSetup(75,0,0,0);
                    break;
                case 1002:
                    ItemGeneralSetup(1002,"Large Health Potion","A potion that heals you",1,0);
                    ItemHPSetup(150,0,0,0);
                    break;
                case 1003:
                    ItemGeneralSetup(1003,"Mega Health Potion","A potion that heals you",1,0);
                    ItemHPSetup(300,0,0,0);
                    break;
                case 1004:
                    ItemGeneralSetup(1004,"Full Health Potion","A potion that heals you",1,0);
                    ItemHPSetup(0,100,0,0);
                    break;

                case 1005:
                    ItemGeneralSetup(1005,"Half Heart Crystal","A potion that heals you",2,0);
                    ItemHPSetup(250,0,250,0);
                    break;
                case 1006:
                    ItemGeneralSetup(1006,"Heart Crystal","A potion that heals you",2,0);
                    ItemHPSetup(500,0,500,0);
                    break;

                case 1007:
                    ItemGeneralSetup(1007,"Basic Regeneration Potion","A potion that heals you",1,10);
                    ItemHPSetup(0,10,0,0);
                    break;
                case 1008:
                    ItemGeneralSetup(1001,"Large Regeneration Potion","A potion that heals you",1,20);
                    ItemHPSetup(0,20,0,0);
                    break;
                #endregion

                #region ATK Potions

                case 2001:
                    ItemGeneralSetup(1001,"Basic Attack Potion","A potion that heals you",1,0);
                    ItemAttackSetup(0,0,15,0);
                    break;
                case 2002:
                    ItemGeneralSetup(1002,"Large Health Potion","A potion that heals you",1,0);
                    ItemAttackSetup(0,0,30,0);
                    break;
                case 2003:
                    ItemGeneralSetup(1003,"Mega Health Potion","A potion that heals you",1,0);
                    ItemAttackSetup(0,0,60,0);
                    break;
                case 2004:
                    ItemGeneralSetup(1004,"Exo Attack Potion","A potion that heals you",1,0);
                    ItemAttackSetup(0,0,240,0);
                    break;

                case 2005:
                    ItemGeneralSetup(1005,"Broken Crystal Ball","A potion that heals you",1,3);
                    ItemAttackSetup(0,100,0,0);
                    break;
                case 2006:
                    ItemGeneralSetup(1006,"Black Crystal Ball","A potion that heals you",1,6);
                    ItemAttackSetup(0,150,0,0);
                    break;

                case 2007:
                    ItemGeneralSetup(1007,"Firefly","A potion that heals you",1,0);
                    ItemAttackSetup(0,0,0,10);
                    break;
                case 2008:
                    ItemGeneralSetup(1001,"Butterfly","A potion that heals you",1,0);
                    ItemAttackSetup(0,0,0,20);
                    break;

                #endregion
            }
        }

        public void UseItem(MainCharacter enemy){
            if (isEmpty() != true){
                int n = number_of_turns_in_effect;
                    
                if (heal_percentage != 0){
                    enemy.hp += Convert.ToInt32(heal_percentage / 100 * enemy.hp_limit);
                }
                enemy.hp += heal_amount;

                if (enemy.hp >= enemy.hp_limit){
                    enemy.hp = enemy.hp_limit; 
                }

                if (hp_increase_percentage != 0){
                        enemy.hp_limit = Convert.ToInt32((hp_increase_percentage / 100 * enemy.hp_limit) + enemy.hp_limit);
                }
                enemy.hp_limit += hp_increase_amount;
                
                if (enemy.hp >= enemy.hp_limit){
                    enemy.hp = enemy.hp_limit; 
                }

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


                amount--;
            } else {
                id_number = -1;
            }
        }
        
        public bool isEmpty(){
            if (amount == 0){
                return true;
            }
            return false;
        }
    }
        
}


