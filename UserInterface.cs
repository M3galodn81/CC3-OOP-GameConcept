// what the user sees

namespace DatingSim{

    public class UserInterface{

        //Starting Screen


        public static void WelcomeScreen(){
            Console.WriteLine("Welcome to this game");

            Console.WriteLine("Welcome to the world of \'Pure Pain and Suffering\' where you are idk forced to date someone cuz reasonssssssss.");
        }


        public static void Introduce(){
            Console.WriteLine("So what is your name?   ");
            string player_name = Console.ReadLine();
            if ((player_name == null) || (player_name == "")){
                player_name = "Player";
            }

            Console.WriteLine("Welcome, " + player_name);
            Console.WriteLine("I hope you will have fun here. :)");
            
        }


        // Act I
        public static string StatCheck(Character1, Character2){
            string value = "1 for " + Character1.name +"\n2 for " + Character2.name;

            return value;
        }


        public static void Day1(){
            

        }

    }
}