namespace TowerGame{
    public class Floor{
        public int current_floor_level;
        public int floor;
        public int[] floor_rooms = new int[6]; 
        
        // 1 for safe
        // 2 for normal
        // 3 for danger
        // 4 for threat

        public void GenerateFloor(int floor_number){
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
        
    }
}