using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecretGame_New
{
    public class Game  //behöver vi Game eller ska vi sköta allt i Program (main)? En smaksak
    {
        public World World { get; set; }
        bool invalidInput = true;


        public void Play()
        {
            // Testrader för Grab-Inspect-Drop- metoder
            World.Player.Grab("Key");
            World.Player.InspectItem("Key");
            World.Player.DropItem("Key");
            World.Player.Grab("Key");
            World.Player.PutItemInBag("Key");
            World.Player.ItemFromBagToRoom("Key");
            World.Player.Look("Look");

            do
            {
                string userInput;
                do
                {
                    Console.WriteLine("Type in your next move");
                    userInput = Console.ReadLine().ToUpper();

                    KollaInput(userInput);

                } while (invalidInput); // kontrolloop för giltiga ord.

                Console.WriteLine("Du är nu utanför loopen för Kolla input");
                KollaInput2(userInput); // kontrollera vad som skrivits in och vidarebefordra spelaren till rätt metod. 

               // World.Player.SearchDoor(userInput); // om spelaren vill move east eller west. Ev förflyttas till inom KollaInput2?

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
            string text = input.ToUpper();
            //char[] separator = new char[] { (' ') };
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> validInputs = new List<string>();

            List<string> validinput = new List<string>(); // Lista med giltiga ord. 
            validinput.Add("MOVE");
            validinput.Add("EAST");
            validinput.Add("WEST");
            validinput.Add("GRAB");
            validinput.Add("USE");
            validinput.Add("DROP");
            validinput.Add("KEY");
            validinput.Add("APPLE");
            validinput.Add("INSPECT");


            foreach (string e in validinput)
            { 

                 if (e == inputs[0])
                 {
                    Console.WriteLine("Okey");
                    validInputs.Add(e);

                    foreach(string f in validinput)
                    {
                        if ( f == inputs[1])
                        {
                            Console.WriteLine("okey2"); 
                            validInputs.Add(f);
                        }

                    }                       
                 }            
            }
            if (!validinput.Contains(inputs[0]))
            {
                Console.WriteLine("Du har skrivit fel kommando.\n Möjliga kommandon: \n Move, Drop, Use, Take, \n East, West, Key, Apple ");
            }
            
            if (validInputs.Count == 2 )
            {
                invalidInput = false;
            }

        }

        public void KollaInput2(string userInput)
        {
            string text = userInput;
            //char[] separator = new char [] { (' ') };
            string[] inputs = text.Split(' '); //separator, StringSplitOptions.RemoveEmptyEntries);



            var query = inputs.Where(x => x == "MOVE")
                             .Select(x => x).ToList();
            
            if (query[0].ToString() == "MOVE")
            {
                World.Player.SearchDoor(userInput);
            }
            

            var query1 = inputs.Where(x => x == "GRAB")
                             .Select(x => x).ToList();

            if (query[0].ToString() == "GRAB")
            {
                // METOD FÖR GRAB World.Player.SearchDoor(userInput);
            }

            var query2 = inputs.Where(x => x == "DROP")
                             .Select(x => x).ToList();

            var query3 = inputs.Where(x => x == "TAKE")
                             .Select(x => x).ToList();

            var query4 = inputs.Where(x => x == "INSPECT")
                             .Select(x => x).ToList();

            if (query[0].ToString() == "INSPECT")
            {
                World.Player.Inspect(userInput);// METOD FÖR GRAB World.Player.SearchDoor(userInput);
            }

            var query5 = inputs.Where(x => x == "USE")
                             .Select(x => x).ToList();

            var query6 = inputs.Where(x => x == "MOVE")
           
                             .Select(x => x).ToList();

            //if(inputs[0] == "GRAB")
            //{
            //    string result = inputs[0];
            //World.Player.Grab(result);
            //}

            //foreach (string s in inputs)
            //{
            //    Console.WriteLine(s);
            //}

            //if (inputs[0] == "move")
            //{
            //    Console.WriteLine("Du vill gå ");
            //}

            //if (inputs[1] == "right")
            //{
            //    Console.WriteLine("Du vill gå till höger");
            //}
            //// Console.WriteLine(direction);
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
