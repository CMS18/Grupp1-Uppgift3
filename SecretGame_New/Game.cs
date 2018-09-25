using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class Game  //behöver vi Game eller ska vi sköta allt i Program (main)? En smaksak
    {
        public World World { get; set; }
        bool invalidInput = true;


        public void Play()
        {

            do
            {
                string userInput; 
                do
                {
                    Console.WriteLine("Type in your next move");
                    userInput = Console.ReadLine();
                    KollaInput(userInput);
                } while (invalidInput);

                World.Player.SearchDoor(userInput);
                Console.ReadKey();
             

            } while (World.Player.Alive == true); 
            
            //här ligger spelloopen som kör tills död eller vinst
            //innehålla: skriv ut location, 
            //fråga anv vad vill du göra?
            //tolka texten
            //beroende på svar, anropa rätt kommando/subrutin
            throw new NotImplementedException();
        }

        private void KollaInput(string input)
        {
            List<string> validinput = new List<string>();
            validinput.Add("EAST");
            validinput.Add("WEST");
           
            
                if (validinput.Contains(input))
                {
                    Console.WriteLine("Okey");
                    invalidInput = false;
                   
                }
                else
                {
                    Console.WriteLine("Du har skrivit fel");
                 
                }
                  
        }

        //Skapa instans av WorldCreator
        //anropa WorldCreator-metoden
        //låt WorldCreator-metoden returnera en referens till Player, hit till Game
        //Så blir Player är den enda som är synlig här
        internal void SetUp()
        {
            //Ska bygga världen
            WorldCreator creator = new WorldCreator();
            World = creator.BuildWorld();

        }
    }
}
