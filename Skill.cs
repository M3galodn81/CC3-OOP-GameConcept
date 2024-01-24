namespace TowerGame{

    public class Skill {
        public int id = 0;
        public string name = "";
        public string description = "";


        public Boolean isReady;
        public int skill_point_limit = 5;
        public int skill_point = 0;
        public int number_of_turns_in_effect = 0;


        public int heal_amount = 0; 
        public int heal_percentage = 0; 
        public int hp_increase_percentage = 0; 
        public int hp_increase_amount = 0;


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

        public void SkillAttackSetup(int attack_amount_input, int attack_percentage_input, int attack_increase_amount_input , int attack_increase_percentage_input){
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

    }


}