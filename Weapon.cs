namespace TowerGame{
    public class Weapon{

        public int id_number;
        public string name;
        public string description;
        public int attack_type;

        public int attack_amount_buff;
        public double attack_percent_buff;

        public int defense_amount_buff;
        public double defense_percent_buff;

        public int hp_amount_buff;
        public double hp_percent_buff;

        public Weapon(int id){
            switch (id){

                // Melee
                case 1:

                    id_number = 1;
                    name = "Rusty Knife";
                    description = "An old knife in the castle that might indicates that this castle is abandoned for a long period of time";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 2:

                    id_number = 2;
                    name = "Sharp Knife";
                    description = "A knife that might used by another creature.";

                    attack_type = 1;

                    attack_amount_buff = 30;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 3:
                    
                    id_number = 3;
                    name = "Dull Dagger";
                    description = "A old dagger with an old emblem.";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 2.5d;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 4:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 5:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 6:

                    id_number = 1;  
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 7:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 8:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 9:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 10:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;


                // MAgic
                case 11:
                    
                    id_number = 11;
                    name = "Old Page of Ember";
                    description = "This page lets you cast basic magic.";

                    attack_type = 2;

                    attack_amount_buff = 25;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 12:
                    
                    id_number = 12;
                    name = "Blue-Flame Candle";
                    description = "A candle with a bluish flame.";

                    attack_type = 2;

                    attack_amount_buff = 35;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 13:
                    
                    id_number = 1;
                    name = "Cloud Orb";
                    description = "A decent magic weapon with small defense capabilites ";

                    attack_type = 2;

                    attack_amount_buff = 50;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 5;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 14:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 15:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 16:
                    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;
                    
                    break;

                case 17:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 18:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 19:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 20:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                //Range
                case 21:

                    id_number = 21;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 22:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 23:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 24:
    
                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 25:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 26:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 27:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 28:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 29:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;

                case 30:

                    id_number = 1;
                    name = "";
                    description = "";

                    attack_type = 1;

                    attack_amount_buff = 20;
                    attack_percent_buff = 0;

                    defense_amount_buff = 0;
                    defense_percent_buff = 0;

                    hp_amount_buff = 0;
                    hp_percent_buff = 0;

                    break;


            }
        }
    }
}