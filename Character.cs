using System.Runtime.InteropServices;

namespace DatingSim{
    public class Character
    {
        public string name = "";
        public int intelligence_level = 0;
        public int strength_level = 0; 
        public int gender = 0;
        public int relationship_level = 0;

        public int height = 140;
        // height in cm

        //both intelligence and strength level are from 0 to 10

        // gender
        // female = 0
        // male = 1

        //relationship level
        // strangers = 0
        // acquintace = 1
        // friends = 2
        // ??????  = 3
        // gf/bf = 4 
       
       public void StatCheck() 
       {

        string gender_text = "";
        string relationship_level_text = "";

        if (gender == 0){
            gender_text = "Female";
        } else {
            gender_text = "Male";
        }

        switch (relationship_level){
            case 0:
                relationship_level_text = "Strangers";
                break;
            case 1:
                relationship_level_text = "Acquintance";
                break;
            case 2:
                relationship_level_text = "Friends";
                break;
            case 3:
                relationship_level_text = "?????";
                break;
            case 4:
                if (gender == 0){
                    relationship_level_text = "Girlfriend";
                } else {
                    relationship_level_text = "Boyfriend";
                }
                break;
            default:
                relationship_level_text = "IDK, Error moment";
                break;
        }



        Console.WriteLine("Name: " + name + 
        "\nGender: "+ gender_text + 
        "\nHeight: "+ height + " cm"+
        "\n" + 
        "\nIntelliegence Level: "+ intelligence_level + 
        "\nStrenght Level: "+ strength_level + 
        "\nRelationship Level: "+ relationship_level_text + 
        "\n");
       }

       public int ConvertHeight(int ft,int inc){
        double cm = (ft *12*2.54) + (inc * 2.54);
        int cm_final = (int)Math.Floor(cm);
        return cm_final;
       }
    }

}