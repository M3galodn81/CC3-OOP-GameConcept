namespace TowerGame{
    public class Enemy{

        public string name = "Basic Enemy";
        public float hp = 123;
        public int hp_limit = 123;
        public int physical_attack = 0;
        public int magic_attack = 0;

        public int defense = 0;
        public int magic_defense = 0;

        public Boolean isDead(){
            if (hp <= 0){
                return true;
            } else {
                return false;
            }
        }
    }

    public class BasicEnemy : Enemy{
        public BasicEnemy(string name_input, float hp_input, int hp_limit_input, int physical_attack_input, int magic_attack_input, int defense_input, int magic_defense_input){
            name = name_input;
            hp = hp_input;
            hp_limit = hp_limit_input;
            physical_attack = physical_attack_input;
            magic_attack = magic_attack_input;
            defense = defense_input;
            magic_defense = magic_defense_input;
        }
    }
}
