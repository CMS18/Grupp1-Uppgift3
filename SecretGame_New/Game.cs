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
            Console.WriteLine("Welcome " + World.Player.PlayerName + "!\nYour challenge takes place in a big house that is set on fire." +
                " Is there someone who needs to be saved here? \nYou are carrying an empty bag. ");
            World.Player.Look("LOOK");
            do
            {
                do
                {
                    GiveCommand(); //Metod för input från spelaren. 

                    CheckValidWord(userInput); //Kolla om giltiga ord har angivits.

                } while (invalidInput); // kontrolloop för giltiga ord.

                Console.WriteLine("Du är nu utanför loopen för Kolla input");

                CheckCommand(userInput); // kontrollera vad som skrivits in och vidarebefordra spelaren till rätt metod.             

                //Console.ReadKey();

            } while (World.Player.Alive == true);

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

                if (inputs[0].ToString() == "TAKE")
                {
                    World.Player.Take(inputs[1]); //funkar med siffran 1, då item bör komma som nr 2 i input...
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "DROP")
                {
                    World.Player.DropItem(inputs[1]);
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "USE")
                {
                    World.Player.Use(userInput);
                    command = false;
                    break;
                }

                if (inputs[0].ToString() == "INSPECT")
                {
                    World.Player.InspectItem(inputs[1]);
                    command = false;
                    break;
                }
            }
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
            List<string> oneWord = new List<string>() { "help", "quit", "look" };

            string value = input;
            switch (value)
            {
                case "HELP":
                    Console.WriteLine("As a command you can use: " +
                        "\nMOVE FORWARD/BACKWARD, TAKE ITEM, USE ITEM, " +
                        "INSPECT ITEM, DROP ITEM, LOOK ");
                    break;

                case "QUIT":
                    Console.WriteLine("See you later!");
                    World.Player.Alive = false;
                    break;

                case "LOOK":
                    Console.WriteLine();
                    World.Player.Look(input);
                    break;
            }

            if (input != "HELP" && input != "QUIT" && input != "LOOK")
            {
                Console.WriteLine(@"Invalid command, try again. Enter ""help"" if you need guidance");
            }
        }

        private void GiveCommand()
        {
            Console.WriteLine("\nType in your next move");
            userInput = Console.ReadLine().ToUpper();
            string text = userInput.ToUpper();
            string[] inputs = text.Split(' ');

            if (inputs.Length == 1)
            {
                OneCommand(userInput);
                GiveCommand();
            }

            if (inputs.Length == 4)
            {
                ThreeCommands(userInput);
                GiveCommand();
            }        
        }

        private void ThreeCommands(string input)
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
            List<string> validInput = new List<string>(); // lista för att spara de "rätta" orden

            foreach (string e in validinputs)
            {
                if (e == inputs[0])
                {
                    Console.WriteLine("Okey");
                    validInput.Add(e);
                }
                if (e == inputs[1])
                {
                    Console.WriteLine("okey2");
                    validInput.Add(e);
                }
                if (e == inputs[3])  //Ändrar från 2 till 3 här eftersom vi vill plocka ut sista ordet ur inputs
                {
                    Console.WriteLine("okey3");
                    validInput.Add(e);
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
            if (validInput.Count <= 3)
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
                    Console.WriteLine("Okey");
                    validInputs.Add(e);

                    foreach (string f in validinput)
                    {
                        if (f == inputs[1])
                        {
                            Console.WriteLine("okey2");
                            validInputs.Add(f);
                        }

                    }
                }
            }
            if (!validinput.Contains(inputs[0]))
            {
                Console.WriteLine("As a command you can use: " +
                    "\nMOVE FORWARD/BACKWARD, TAKE ITEM, USE ITEM, " +
                    "INSPECT ITEM, DROP ITEM, LOOK ");
                GiveCommand();
            }

            if (validInputs.Count <= 2)
            {
                invalidInput = false;
            }

        }

        

        internal void SetUp()
        {
            //bygger världen
            WorldCreator creator = new WorldCreator();
            World = creator.BuildWorld();

        }
    }

}