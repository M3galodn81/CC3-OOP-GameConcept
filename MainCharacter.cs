using System.Runtime.Serialization;

namespace TowerGame {
    public  class MainCharacter{

        public String player_name = "";

        public int role = 0;
        public String role_name = "";

        public float hp = 123;

        public int physical_attack = 0;
        public int magic_attack = 0;

        public int defense = 0;
        public int magic_defense = 0;

        public void RoleInitiation(int role_number){
            if (role_number == 1){
                role = 1;
                role_name = "Swordmaster";

                
                hp = 150;
                physical_attack = 30;
                defense = 20;

            } else if (role_number == 2){
                role = 2;
                role_name = "Wizard";

                hp = 100;
                magic_attack = 30;
                magic_defense = 10;

            } else if (role_number == 3){
                role = 3;
                role_name = "Gunslinger";

                hp = 125;
                physical_attack = 25;
                defense = 10;

            }
        }


        public void StatCheck(){
            Console.WriteLine("============================================================");
            Console.WriteLine("| Player Name: " + player_name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| Role: " + role_name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| HP : " + hp + " |");
            Console.WriteLine("| Attack (Physical): " + physical_attack + " |");
            Console.WriteLine("| Attack (Magic): " + magic_attack + " |");
            Console.WriteLine("| Defense: " + defense + " |");
            Console.WriteLine("| Defense (Magic): " + magic_defense + " |");
        }

        public Boolean Dead(){
            if (hp <= 0){
                return true;
            } else {
                return false;
            }

        }

    }
}