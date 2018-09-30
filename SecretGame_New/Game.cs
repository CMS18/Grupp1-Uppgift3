using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecretGame_New
{
    public class Game
    {
        public World World { get; set; }
        bool invalidInput = true;
        string userInput;

        public void Play()
        {
            Console.WriteLine("Welcome to Text Adventure, " +
                              "prepare yourself for a challenging task... " +
                              "\nPlease type in your Players name: ");
            World.Player.PlayerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome " + World.Player.PlayerName + "! Your challenge takes place in a big house that is set on fire." +
                "You are carrying an empty bag.");
            World.Player.Look("LOOK");
            do
            {
                do
                {
                    GiveCommand(); //Metod för input från spelaren. 

                    CheckValidWord(userInput); //Kolla om giltiga ord har angivits.

                } while (invalidInput); // kontrolloop för giltiga ord.

                //Console.WriteLine("Du är nu utanför loopen för Kolla input");

                CheckCommand(userInput); // kontrollera vad som skrivits in och vidarebefordra spelaren till rätt metod.                           

            } while (World.Player.Alive == true);

            //här ligger spelloopen som kör tills död eller vinst
            //innehålla: skriv ut location, 
            //fråga anv vad vill du göra?
            //tolka texten
            //beroende på svar, anropa rätt kommando/subrutin

        }

        private void CheckOneWord(string input)
        {
            string text = input.ToUpper();
            //char[] separator = new char[] { (' ') };
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length < 2)
            {
                OneCommand(input);
            }
        }

        private void OneCommand(string input)
        {
            List<string> oneWord = new List<string>() { "help", "quite", "look" };

            string value = input;
            switch (value)
            {
                case "HELP":
                    Console.WriteLine("As a command you can use: " +
                        "\n MOVE FORWARD/BACKWARD, TAKE ITEM, USE ITEM, " +
                        "INSPECT ITEM, DROP ITEM, LOOK ");
                    break;

                case "QUITE":
                    Console.WriteLine("See you later!");
                    World.Player.Alive = false;
                    break;

                case "LOOK":
                    Console.WriteLine();
                    World.Player.Look(input);
                    break;
            }

            if (input != "HELP" && input != "QUITE" && input != "LOOK")
            {
                Console.WriteLine(@"Invalid command, try again. Enter ""help"" if you need guidance");
            }
        }

        private void GiveCommand()
        {
            Console.WriteLine("Type in your next move");
            userInput = Console.ReadLine().ToUpper();
            string text = userInput.ToUpper();
            string[] inputs = text.Split(' ');

            if (inputs.Length == 1)
            {
                OneCommand(userInput);
              
            }

            if (inputs.Length == 4)
            {
                FourCommands(userInput);
               
            }        
        }

        private void FourCommands(string input)
        {
            string text = input.ToUpper();
            //char[] separator = new char[] { (' ') };
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> validinputs = new List<string>(); // Lista med giltiga ord. 
            validinputs.Add("USE");
            validinputs.Add("KEY");
            validinputs.Add("APPLE");
            validinputs.Add("DOOR");
            validinputs.Add("ON");
            validinputs.Add("CAT");
            List<string> wordsToInterpret = new List<string>(); // lista för att spara de "rätta" orden

            foreach (string e in validinputs)
            {
                if (e == inputs[0])
                {
                    //Console.WriteLine("Okey");
                    wordsToInterpret.Add(e);
                }
                if (e == inputs[1])
                {
                    //Console.WriteLine("okey2");
                    wordsToInterpret.Add(e);
                }
                if (e == inputs[3])  //Ändrar från 2 till 3 här eftersom vi vill plocka ut sista ordet ur inputs
                {
                   // Console.WriteLine("okey3");
                    wordsToInterpret.Add(e);
                }
                //foreach (string f in validinputs) // GÅR INTE HA 3 foreach...!
                //{
                //    if (f == inputs[1])
                //    {
                //        Console.WriteLine("okey2");
                //        validInput.Add(f);
                //    }

                //foreach (string g in validinputs)
                //    {
                //         if (g == inputs[2])
                //         {
                //         Console.WriteLine("okey3");
                //         validInput.Add(g);
                //         }

                //    }
                //}
            }
            if (wordsToInterpret.Count <= 3)
            {
                invalidInput = false;
            }
        }


        private void CheckValidWord(string input)
        {
            string text = input.ToUpper();
            //char[] separator = new char[] { (' ') };
            string[] inputs = text.Split(' '); //(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> validInputs = new List<string>();

            List<string> validinput = new List<string>(); // Lista med giltiga ord. 
            validinput.Add("MOVE");
            validinput.Add("FORWARD");
            validinput.Add("BACKWARD");
            validinput.Add("TAKE");
            validinput.Add("USE");
            validinput.Add("DROP");
            validinput.Add("KEY"); 
            validinput.Add("APPLE");
            validinput.Add("INSPECT");
            validinput.Add("LOOK");
            validinput.Add("DOOR");
            validinput.Add("HAMMER");
            validinput.Add("CAT");

            foreach (string e in validinput)
            {

                if (e == inputs[0])
                {
                    //Console.WriteLine("Okey");
                    validInputs.Add(e);

                    foreach (string f in validinput)
                    {
                        if (f == inputs[1])
                        {
                            //Console.WriteLine("okey2");
                            validInputs.Add(f);
                        }

                    }
                }
            }
            if (!validinput.Contains(inputs[0]))
            {
                Console.WriteLine("Du har skrivit fel kommando.\n Möjliga kommandon: \n Move, Drop, Use, Take, \n East, West, Key, Apple ");
            }

            if (validInputs.Count <= 2)
            {
                invalidInput = false;
            }

        }

        public void CheckCommand(string userInput)
        {
            string text = userInput;
            //char[] separator = new char [] { (' ') };
            string[] inputs = text.Split(' '); //separator, StringSplitOptions.RemoveEmptyEntries);
            bool command = true;

            while (command)
            {
                //var query = inputs.Where(x => x == "MOVE")
                //                  .Select(x => x);

                if (inputs[0].ToString() == "MOVE")
                {
                    World.Player.SearchDoor(userInput);
                    command = false;

                    break;
                }


                //var query1 = inputs.Where(x => x == "GRAB")
                //            .Select(x => x).ToList();

                if (inputs[0].ToString() == "TAKE")
                {
                    World.Player.Take(inputs[1]); //funkar med siffran 1, då item bör komma som nr 2 i input...
                    command = false;
                    break;
                }

                //var query2 = inputs.Where(x => x == "DROP")
                //             .Select(x => x).ToList();
                if (inputs[0].ToString() == "DROP")
                {
                    World.Player.DropItem(inputs[1]); //funkar med siffran 1, då item bör komma som nr 2 i input...
                    command = false;
                    break;
                }

                if(inputs[0].ToString() == "USE")
                {
                    World.Player.Use(userInput);
                    command = false;
                    break;
                }
                //var query2 = inputs.Where(x => x == "DROP")
                //             .Select(x => x).ToList();

                //var query3 = inputs.Where(x => x == "TAKE")
                //             .Select(x => x).ToList();

                //var query4 = inputs.Where(x => x == "INSPECT")
                //             .Select(x => x).ToList();

                if (inputs[0].ToString() == "INSPECT")
                {
                    World.Player.InspectItem(inputs[1]); //funkar med siffran 1, då item bör komma som nr 2 i input...
                    command = false;
                    break;
                }

                //var query5 = inputs.Where(x => x == "USE")
                //             .Select(x => x).ToList();

                //if (query5[0].ToString() == "USE")
                //{
                //    World.Player.Use(userInput);
                //}
                //var query6 = inputs.Where(x => x == "MOVE")

                //             .Select(x => x).ToList();
            }
        }

        internal void SetUp()
        {
            //Ska bygga världen
            WorldCreator creator = new WorldCreator();
            World = creator.BuildWorld();

        }
    }

}