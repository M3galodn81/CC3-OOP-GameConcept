using System;


namespace DatingSim
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // NPC Creation
            Character angel = new Character();
            angel.name = "Angel";
            angel.gender = 0;
            angel.height = angel.ConvertHeight(5,6);

            angel.intelligence_level = 6;
            angel.strength_level = 4;
            angel.relationship_level = 0;

            Character erica = new Character();
            erica.name = "Erica";
            erica.gender = 0;
            erica.height = erica.ConvertHeight(5,4);

            erica.intelligence_level = 7;
            erica.strength_level = 5; 
            erica.relationship_level = 0;
            

            Console.WriteLine("Hello World!"); 
            
            UserInterface.WelcomeScreen();
            UserInterface.Introduce();

            UserInterface.StatCheck(angel,erica);










        }
    }
}