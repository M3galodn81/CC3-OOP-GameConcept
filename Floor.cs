namespace TowerGame{
    public class Floor{
        public int current_floor_level;
        public int floor;
        public int[] floor_rooms = new int[6]; 
        public List<Room> play_rooms = new List<Room>();
        
        // 1 for safehouse
        // 2 for normal
        // 3 for elite
        // 4 for boss

        public Floor(int floor_number){
            Random rnd = new Random();
            floor = floor_number;

            switch (floor_number){
                
                case 1:
                    floor_rooms[0] = 1;
                    floor_rooms[1] = 2;

                    floor_rooms[2] = rnd.Next(2,4);
                    floor_rooms[3] = rnd.Next(2,4);
                    floor_rooms[4] = rnd.Next(2,4);

                    floor_rooms[5] = 4;

                    int elite_count = 0;
                    for (int i = 2; i <= 4; i++){
                        if (floor_rooms[i] == 3){
                            elite_count++;
                        }
                    }
                    
                    if (elite_count > 1){
                        int randomIndex = rnd.Next(2,4);
                        floor_rooms[2] = 2;
                        floor_rooms[3] = 2;
                        floor_rooms[4] = 2;
                        floor_rooms[randomIndex] = 3;
                    }

                    break;

                case 2:

                    int safehouse_limit;
                    int safehouse_room;
                    int elite_limit;
                    int elite_room;

                    floor_rooms[0] = rnd.Next(1,3);
                    floor_rooms[1] = rnd.Next(1,3);

                    floor_rooms[2] = rnd.Next(2,4);
                    floor_rooms[3] = rnd.Next(2,4);
                    floor_rooms[4] = rnd.Next(2,4);

                    floor_rooms[5] = 4;

                    safehouse_limit = 1;
                    safehouse_room = 0;
                    for (int i = 0; i <= 1; i ++ ){
                       if (floor_rooms[i] == 1){
                        safehouse_room++;
                       } 
                    }

                    if (safehouse_room > safehouse_limit){
                        floor_rooms[rnd.Next(0,2)] = 2;
                    }

                    elite_limit = 2;
                    elite_room = 0;
                    for (int i = 0; i <= 1; i ++ ){
                       if (floor_rooms[i] == 3){
                        elite_room++;
                       } 
                    }

                    if (elite_room > elite_limit){
                        floor_rooms[rnd.Next(2,4)] = 2;
                    }

                    break;

                case 3:
                    floor_rooms[0] = rnd.Next(1,2);
                    floor_rooms[3] = rnd.Next(1,2);

                    floor_rooms[1] = rnd.Next(2,4);
                    floor_rooms[2] = rnd.Next(2,4);
                    floor_rooms[4] = rnd.Next(2,4);

                    floor_rooms[5] = 4;

                    // check there are 2 safehouse rooms
                    if (floor_rooms[0] == 1 && floor_rooms[3] == 1){
                        int randomIndex = rnd.Next(2);
                        if (randomIndex == 0){
                            floor_rooms[0] = 1;
                            floor_rooms[3] = 2;
                        } else {
                            floor_rooms[0] = 2;
                            floor_rooms[3] = 1; 
                        }
                    }
                    break;

                case 4:
                    floor_rooms[0] = rnd.Next(1,2);
                    floor_rooms[2] = rnd.Next(1,2);

                    floor_rooms[1] = rnd.Next(2,4);
                    floor_rooms[3] = rnd.Next(2,4);
                    floor_rooms[4] = rnd.Next(2,4);

                    floor_rooms[5] = 4;

                    // check there are 2 safehouse rooms
                    if (floor_rooms[0] == 1 && floor_rooms[2] == 1){
                        int randomIndex = rnd.Next(2);
                        if (randomIndex == 0){
                            floor_rooms[0] = 1;
                            floor_rooms[2] = 2;
                        } else {
                            floor_rooms[0] = 2;
                            floor_rooms[2] = 1; 
                        }
                    }

                    // adds a elite room if there is none
                    if (floor_rooms[1] == 2 && floor_rooms[3] == 2 && floor_rooms[4] == 2){
                        int[] indexList = [1,3,4]; 
                        int randomIndex = rnd.Next(0,indexList.Length);

                        floor_rooms[randomIndex] = 3;
                    }



                    break;

                case 5:

                    floor_rooms[0] = 2;
                    floor_rooms[1] = 2;
                    floor_rooms[2] = 2;
                    floor_rooms[3] = 2;
                    floor_rooms[4] = 2;
                    floor_rooms[5] = 4;

                    for (int no_of_elite = rnd.Next(1,5) ; no_of_elite!= 0 ; no_of_elite--){
                            floor_rooms[no_of_elite] = 3;
                    }


                    int hasSafe = rnd.Next(2);

                    if (hasSafe == 1){
                        int[] randomList = [0,2,4];
                        int randomIndex = rnd.Next(0,randomList.Length);

                        floor_rooms[randomIndex] = 1;
                    }
                    
                    break;

                case 6:
                    floor_rooms = new int[4] ;

                    floor_rooms[0] = 2;                 
                    floor_rooms[1] = 3;
                    floor_rooms[2] = 3;
                    floor_rooms[3] = 4;

                    break;
            
            }
        }
    
        public void Explore(){
           foreach(int i in floor_rooms){
                play_rooms.Add(Room.CreateRoom(floor,i));
            }
        }
    }

    public class Room {

        public int FloorLevel { get; private set; }
        public int RoomType { get; private set; }

        public Room(int floor_level, int room_type) {
            FloorLevel = floor_level;
            RoomType = room_type;
        }

        public static Room CreateRoom(int floor_level, int room_type) {
            switch (room_type) {
                case 1:
                    return new Safehouse(floor_level, room_type);
                case 2:
                    return new EnemyRoom(floor_level, room_type);
                case 3:
                    return new EliteRoom(floor_level, room_type);
                case 4:
                    return new BossRoom(floor_level, room_type);
                default:
                    throw new ArgumentException("Invalid room type");
            }
        }
    }

    public class Safehouse : Room {
        public Safehouse(int floor_level, int room_type) : base(floor_level, room_type) {
            // Safehouse-specific initialization
            Random rnd = new Random();
            Console.WriteLine("As you enter the room you see some supplies. ");

            switch (floor_level){
                case 1:
                    
                    
                    

                    Boolean quitLoop = false;
                    do {
                        switch (Console.ReadKey(true).Key){
                            case ConsoleKey.D1:


                                break;
                            case ConsoleKey.D2:
                                break;
                            case ConsoleKey.D3:
                                break;
                            case ConsoleKey.Q:
                                break;
                            case ConsoleKey.H:
                                break;
                            case ConsoleKey.X:
                                break;
                        }   
                    } while (! Console.KeyAvailable && !quitLoop);

                    break;

                case 2:

                    quitLoop = false;
                    do {
                        switch (Console.ReadKey(true).Key){
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                break;
                            case ConsoleKey.D3:
                                break;
                            case ConsoleKey.Q:
                                break;
                            case ConsoleKey.H:
                                break;
                            case ConsoleKey.X:
                                break;
                        }   
                    } while (! Console.KeyAvailable && !quitLoop);

                    break;

                case 3:

                    quitLoop = false;
                    do {
                        switch (Console.ReadKey(true).Key){
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                break;
                            case ConsoleKey.D3:
                                break;
                            case ConsoleKey.Q:
                                break;
                            case ConsoleKey.H:
                                break;
                            case ConsoleKey.X:
                                break;
                        }   
                    } while (! Console.KeyAvailable && !quitLoop);

                    break;

                case 4:

                    quitLoop = false;
                    do {
                        switch (Console.ReadKey(true).Key){
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                break;
                            case ConsoleKey.D3:
                                break;
                            case ConsoleKey.Q:
                                break;
                            case ConsoleKey.H:
                                break;
                            case ConsoleKey.X:
                                break;
                        }   
                    } while (! Console.KeyAvailable && !quitLoop);

                    break;


                case 5:

                    quitLoop = false;
                    do {
                        switch (Console.ReadKey(true).Key){
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                break;
                            case ConsoleKey.D3:
                                break;
                            case ConsoleKey.Q:
                                break;
                            case ConsoleKey.H:
                                break;
                            case ConsoleKey.X:
                                break;
                        }   
                    } while (! Console.KeyAvailable && !quitLoop);

                    break;

                case 6:

                    quitLoop = false;
                    do {
                        switch (Console.ReadKey(true).Key){
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                break;
                            case ConsoleKey.D3:
                                break;
                            case ConsoleKey.Q:
                                break;
                            case ConsoleKey.H:
                                break;
                            case ConsoleKey.X:
                                break;
                        }   
                    } while (! Console.KeyAvailable && !quitLoop);

                    break;

                default:
                    break;
            }


        }
    }

    public class EnemyRoom : Room {
        public EnemyRoom(int floor_level, int room_type) : base(floor_level, room_type) {
            // Enemy-specific initialization

            Console.WriteLine("Normal Enemy");

        }
    }

    public class EliteRoom : Room {
        public EliteRoom(int floor_level, int room_type) : base(floor_level, room_type) {
            // Elite-specific initialization

            Console.WriteLine("Elite Enemy");
        }
    }

    public class BossRoom : Room {
        public BossRoom(int floor_level, int room_type) : base(floor_level, room_type) {
            // Boss-specific initialization

            Console.WriteLine("Boss Enemy");
        }
    }

}