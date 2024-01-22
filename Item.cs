using System.Runtime;

namespace TowerGame{
    public class Item{
        public string name = "";
        public string description = "";
        public int amount = 0;
        public int number_of_turns_in_effect = 0;

    }

    public class HealingPotion : Item {
        public int heal_amount = 0; // raw heal like +50
        public int heal_percentage = 0; // heal is based on max_hp
        public int hp_increase_percentage = 0; 
        public int hp_increase_amount = 0;
    }

    public class AttackPotion : Item {
        public int heal_amount = 0; // raw heal like +50
        public int heal_percentage = 0; // heal is based on max_hp
        public int hp_increase_percentage = 0; 
        public int hp_increase_amount = 0;
    }


}