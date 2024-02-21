using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;

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
        
        public Item loot = new Item();
        
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
                        if (enemy_damage >= defense){
                            hp = hp - (enemy_damage - defense);
                        }
                        after_dmg = enemy_damage - defense;
                        break;
                    case 2:
                        double final_magic_attack = enemy_damage * (1 -(magic_defense * 0.01d));
                        hp = hp - final_magic_attack;
                        after_dmg = final_magic_attack;
                        break;
                    case 3:
                        if (enemy_damage >= defense){
                            hp = hp - (enemy_damage - defense);
                        }
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
            loot.id_number = -1;
        }
    
        public void RandomGen(int floor_level, int danger_level){
            Random rnd = new Random();
            switch (danger_level){
                case 1:
                    switch (floor_level){

                        case 1: //90 percent Skeleton / 10 ghost

                            int rE = rnd.Next(1,11);
                            if (rE != 10){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",100,100,20,0,10,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",100,100,0,10,10,10,2);
                                }
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",100,100,0,10,0,10,2);
                            }
                            break;

                        case 2:
                            rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,20,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,20,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",200,200,20,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",200,200,0,30,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,30,0,0,2);
                            }
                            break;

                        case 3:

                             rE = rnd.Next(1,11);
                            if (rE >= 6 && rE != 10){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Zombie", "A enemy that has high attack with low defense",200,200,50,0,0,0,1);
                                } else {
                                    SetUp("Giant Zombie ", "A zombie but stronger and tougher",250,250,0,70,10,10,1);
                                }
                            } else if (rE <= 5){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,300,40,10,25,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,300,0,45,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",250,250,0,50,0,0,2);
                            }
                            break;

                        case 4:
                             rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                            }
                            break;

                        case 5:
                             rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                            }
                            break;

                        case 6:
                             rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                            }
                            break;

                    }
                    // SetUp("Normal Enemy", "A regular foe", 50 + floor_level * 10, 100 + floor_level * 20, 20 + floor_level * 5, 10 + floor_level * 3, 5 + floor_level, 3 + floor_level, rnd.Next(1, 5));
                    break;
                case 2:
                    if (this is EliteEnemy eliteEnemy){
                        switch (floor_level){

                        case 1: //90 percent Skeleton / 10 ghost

                            int rE = rnd.Next(1,11);
                            if (rE != 10){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Gunslinger", "A skeleton that knows how to use a gun",100,100,20,0,10,0,1);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(1,"Critical Hit", "Launches a powerful shot that deals more damage", 0, 10,0);
                                } else {
                                    SetUp("Skeleton Wizard", "A skeleton that knows how to use magic very well",100,100,0,20,10,10,2);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(2,"Fireball", "Launches a powerful fireball", 0, 10,0);
                                }
                            } else {
                                SetUp("Shadow","A foe that cannot be hit with physical attacks",100,100,0,30,0,10,2);
                                eliteEnemy.first_skill = new Skill();
                                eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                            }
                            break;

                        case 2:
                            rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(1,"Critical Hit", "Launches a powerful shot that deals more damage", 0, 10,0);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(2,"Fireball", "Launches a powerful fireball", 0, 10,0);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",200,200,30,0,20,0,1);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(1,"Critical Hit", "Launches a powerful shot that deals more damage", 0, 10,0);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",200,200,0,40,10,20,2);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(2,"Fireball", "Launches a powerful fireball", 0, 10,0);
                                }
                            
                            } else {
                                SetUp("Shadow","A foe that cannot be hit with physical attacks",100,100,0,30,0,10,2);
                                eliteEnemy.first_skill = new Skill();
                                eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                            }
                            break;

                        case 3:

                             rE = rnd.Next(1,11);
                            if (rE >= 6 && rE != 10){
                                int HT = rnd.Next(1,3); 
                                if (HT == 1){
                                    SetUp("Zombie", "A enemy that has high attack with low defense",200,200,50,0,0,0,1);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                                } else {
                                    SetUp("Giant Zombie ", "A zombie but stronger and tougher",250,250,0,70,10,10,1);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                                }
                            } else if (rE <= 5){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,300,40,10,25,0,1);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,300,0,45,10,20,2);
                                    eliteEnemy.first_skill = new Skill();
                                    eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",250,250,0,50,0,0,2);
                                eliteEnemy.first_skill = new Skill();
                                eliteEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                            }
                            break;

                        case 4:
                             rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                            }
                            break;

                        case 5:
                             rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                            }
                            break;

                        case 6:
                             rE = rnd.Next(1,11);
                            if (rE <= 5){
                                int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                } else {
                                    SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                }
                            } else if (rE >= 6 && rE != 10){
                                 int HT = rnd.Next(1,3);
                                if (HT == 1){
                                    SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                } else {
                                    SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                }
                            
                            } else {
                                SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                            }
                            break;

                    }
                    
                    }
                    break;
                case 3:
                      if (this is BossEnemy bossEnemy){
                        switch (floor_level){

                            case 1:

                                int rE = rnd.Next(1,11);
                                if (rE != 10){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Skeleton Gunslinger", "A skeleton that knows how to use a gun",100,100,20,0,10,0,1);
                                        bossEnemy.first_skill = new Skill();
                                        bossEnemy.first_skill.SkillGeneralSetup(1,"Critical Hit", "Launches a powerful shot that deals more damage", 0, 2 ,0);
                                        bossEnemy.first_skill.SkillAttackSetup(1,0,50,0,0);
                                        bossEnemy.ultimate = new Skill();
                                        bossEnemy.first_skill.SkillGeneralSetup(1,"Mega Critical Hit", "Launches a mega powerful shot that deals a ton of damage", 0, 10,0);
                                        bossEnemy.first_skill.SkillAttackSetup(1,0,100,0,0);
                                    } else {
                                        SetUp("Skeleton Wizard", "A skeleton that knows how to use magic very well",100,100,0,20,10,10,2);
                                        bossEnemy.first_skill = new Skill();
                                        bossEnemy.first_skill.SkillGeneralSetup(2,"Fireball", "Launches a powerful fireball", 0, 10,0);
                                        bossEnemy.first_skill.SkillAttackSetup(1,0,50,0,0);
                                        bossEnemy.ultimate = new Skill();
                                        bossEnemy.first_skill.SkillGeneralSetup(1,"Mega Critical Hit", "Launches a mega powerful shot that deals a ton of damage", 0, 10,0);
                                        bossEnemy.first_skill.SkillAttackSetup(1,0,100,0,0);
                                    }
                                } else {
                                    SetUp("Shadow","A foe that cannot be hit with physical attacks",100,100,0,30,0,10,2);
                                    bossEnemy.first_skill = new Skill();
                                    bossEnemy.first_skill.SkillGeneralSetup(3,"Shadow Beam", "Launches a beam that damages you", 0, 20,0);
                                    bossEnemy.first_skill.SkillAttackSetup(1,0,50,0,0);
                                        bossEnemy.ultimate = new Skill();
                                        bossEnemy.first_skill.SkillGeneralSetup(1,"Mega Critical Hit", "Launches a mega powerful shot that deals a ton of damage", 0, 10,0);
                                        bossEnemy.first_skill.SkillAttackSetup(1,0,100,0,0);
                                }
                                break;

                                

                            case 2:

                               
                                    SetUp("Caelus", "???",100,100,20,0,10,0,1);
                                    bossEnemy.first_skill = new Skill();
                                    bossEnemy.first_skill.SkillGeneralSetup(1,"Critical Hit", "Launches a powerful shot that deals more damage", 0, 2 ,0);
                                    bossEnemy.first_skill.SkillAttackSetup(1,0,50,0,0);
                                    bossEnemy.ultimate = new Skill();
                                    bossEnemy.first_skill.SkillGeneralSetup(1,"Mega Critical Hit", "Launches a mega powerful shot that deals a ton of damage", 0, 10,0);
                                    bossEnemy.first_skill.SkillAttackSetup(1,0,100,0,0);
                                   
                                break;

                            case 3:

                                rE = rnd.Next(1,11);
                                if (rE >= 6 && rE != 10){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Zombie", "A enemy that has high attack with low defense",200,200,50,0,0,0,1);
                                    } else {
                                        SetUp("Giant Zombie ", "A zombie but stronger and tougher",250,250,0,70,10,10,1);
                                    }
                                } else if (rE <= 5){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,300,40,10,25,0,1);
                                    } else {
                                        SetUp("Goblin Caster", "A goblin that knows how to use magic",300,300,0,45,10,20,2);
                                    }
                                
                                } else {
                                    SetUp("Ghost","A foe that cannot be hit with physical attacks",250,250,0,50,0,0,2);
                                }
                                break;

                            case 4:
                                rE = rnd.Next(1,11);
                                if (rE <= 5){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                    } else {
                                        SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                    }
                                } else if (rE >= 6 && rE != 10){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                    } else {
                                        SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                    }
                                
                                } else {
                                    SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                                }
                                break;

                            case 5:
                                rE = rnd.Next(1,11);
                                if (rE <= 5){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                    } else {
                                        SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                    }
                                } else if (rE >= 6 && rE != 10){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                    } else {
                                        SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                    }
                                
                                } else {
                                    SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                                }
                                break;

                            case 6:
                                rE = rnd.Next(1,11);
                                if (rE <= 5){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Skeleton Archer", "A skeleton that knows how to use a bow",200,200,30,0,20,0,1);
                                    } else {
                                        SetUp("Skeleton Caster", "A skeleton that knows how to use magic",250,200,0,30,10,20,2);
                                    }
                                } else if (rE >= 6 && rE != 10){
                                    int HT = rnd.Next(1,3);
                                    if (HT == 1){
                                        SetUp("Goblin Slinger", "A goblin that knows how to use a slingshot",300,200,30,0,20,0,1);
                                    } else {
                                        SetUp("Goblin Caster", "A goblin that knows how to use magic",300,200,0,40,10,20,2);
                                    }
                                
                                } else {
                                    SetUp("Ghost","A foe that cannot be hit with physical attacks",200,200,0,40,0,0,2);
                                }
                                break;

                    }
                    
                    }
                    break;
                    
            }
            LootGen(floor_level,danger_level);     
        }       
    
        public void LootGen(int floor_level, int danger_level){
            Dictionary<int, double> lootTable = new Dictionary<int, double>();
            Random random = new Random();

            switch (danger_level){
                case 1:
                    switch (floor_level){
                        case 1:
                            lootTable.Add(1001,45);
                            lootTable.Add(2001,30);
                            lootTable.Add(1002,15);
                            lootTable.Add(2002,10);
                            break;
                        case 2:
                            lootTable.Add(1001,45);
                            lootTable.Add(2001,30);
                            lootTable.Add(1002,15);
                            lootTable.Add(2002,10);
                            break;
                        case 3:
                            lootTable.Add(1001,45);
                            lootTable.Add(2001,30);
                            lootTable.Add(1002,15);
                            lootTable.Add(2002,10);
                            break;
                        case 4:
                            lootTable.Add(1001,45);
                            lootTable.Add(2001,30);
                            lootTable.Add(1002,15);
                            lootTable.Add(2002,10);
                            break;
                        case 5:
                            lootTable.Add(1001,45);
                            lootTable.Add(2001,30);
                            lootTable.Add(1002,15);
                            lootTable.Add(2002,10);
                            break;
                        case 6:
                            lootTable.Add(1001,45);
                            lootTable.Add(2001,30);
                            lootTable.Add(1002,15);
                            lootTable.Add(2002,10);
                            break;
                    }
                    break;

                case 2:
                    switch (floor_level){
                            case 1:
                                lootTable.Add(1002,45);
                                lootTable.Add(2002,30);
                                lootTable.Add(1003,15);
                                lootTable.Add(2003,10);
                                break;
                            case 2:
                                lootTable.Add(1002,45);
                                lootTable.Add(2002,30);
                                lootTable.Add(1003,15);
                                lootTable.Add(2003,10);
                                break;
                            case 3:
                                lootTable.Add(1002,45);
                                lootTable.Add(2002,30);
                                lootTable.Add(1003,15);
                                lootTable.Add(2003,10);
                                break;
                            case 4:
                                lootTable.Add(1002,45);
                                lootTable.Add(2002,30);
                                lootTable.Add(1003,15);
                                lootTable.Add(2003,10);
                                break;
                            case 5:
                                lootTable.Add(1002,45);
                                lootTable.Add(2002,30);
                                lootTable.Add(1003,15);
                                lootTable.Add(2003,10);
                                break;
                            case 6:
                                lootTable.Add(1002,45);
                                lootTable.Add(2002,30);
                                lootTable.Add(1003,15);
                                lootTable.Add(2003,10);
                                break;
                        }
                    break;
                    
                case 3:
                    switch (floor_level){
                        case 1:
                            lootTable.Add(1005,60);
                            lootTable.Add(2005,30);
                            lootTable.Add(1004,15);
                            lootTable.Add(2004,10);
                            break;
                        case 2:
                            lootTable.Add(1005,60);
                            lootTable.Add(2005,30);
                            lootTable.Add(1004,15);
                            lootTable.Add(2004,10);
                            break;
                        case 3:
                            lootTable.Add(1005,60);
                            lootTable.Add(2005,30);
                            lootTable.Add(1004,15);
                            lootTable.Add(2004,10);
                            break;
                        case 4:
                            lootTable.Add(1005,60);
                            lootTable.Add(2005,30);
                            lootTable.Add(1004,15);
                            lootTable.Add(2004,10);
                            break;
                        case 5:
                            lootTable.Add(1005,60);
                            lootTable.Add(2005,30);
                            lootTable.Add(1004,15);
                            lootTable.Add(2004,10);
                            break;
                        case 6:
                            lootTable.Add(1005,60);
                            lootTable.Add(2005,30);
                            lootTable.Add(1004,15);
                            lootTable.Add(2004,10);
                            break;
                    }
                    break;

            }
        
            double totalWeight = lootTable.Values.Sum();
            double randomValue = random.NextDouble() * totalWeight;

            foreach (var entry in lootTable)
            {
                
                randomValue -= entry.Value;

                if (randomValue <= 0)
                    loot.QuickSetup(entry.Key);
                }
            if (loot.id_number == 0){
                 lootTable.Keys.FirstOrDefault();
            }
        }
    }

    public class EliteEnemy : Enemy{
        public Skill first_skill = null;
    }

    public class BossEnemy : Enemy{
        public Skill first_skill = null;
        public Skill ultimate = null;
    }
}
