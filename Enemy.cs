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

        public Boolean isDead(){
            if (hp <= 0){
                return true;
            } else {
                return false;
            }
        }

        public void UpdateHP(double enemy_damage){
            hp = hp - enemy_damage;

            if (hp <= 0){
                hp = 0;
            }
        }

        public void StatCheck(){
            double hp_display = Math.Floor(hp);

            Console.WriteLine("============================================================");
            Console.WriteLine("| Enemy Name: " + name + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| Description : " + description + " |");
            Console.WriteLine("============================================================");
            Console.WriteLine("| HP : " + hp_display + "/"+ hp_limit + " |");
            Console.WriteLine("| Attack (Physical): " + physical_attack + " |");
            Console.WriteLine("| Attack (Magic): " + magic_attack + " |");
            Console.WriteLine("| Defense: " + defense + " |");
            Console.WriteLine("| Defense (Magic): " + magic_defense + " |");
            Console.WriteLine("============================================================");
        }
    }

    public class BasicEnemy : Enemy{
        public void SetUp(string name_input, float hp_input, int hp_limit_input, int physical_attack_input, int magic_attack_input, int defense_input, int magic_defense_input, string description_input){
            name = name_input;
            hp = hp_input;
            hp_limit = hp_limit_input;
            physical_attack = physical_attack_input;
            magic_attack = magic_attack_input;
            defense = defense_input;
            magic_defense = magic_defense_input; 
            description = description_input;
        }

        
    }

    public class EnemyManager{
        public void SpawnEnemy(Enemy enemy = null)
        {
            if (enemy == null)
            {
                // Default behavior (e.g., spawn a basic enemy)
                enemy = new BasicEnemy();
            }

            // Spawn the enemy and perform other actions
        }
    }
}
