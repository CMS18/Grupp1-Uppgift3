using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretGame_New
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Item> PlayerBag { get; set; }
        public Item InHand { get; set; }
        public string PlayerDescription { get; set; }
        public Room PresentLocation { get; set; }
        public bool Alive { get; set; }

        public Player(string name, string description, Room room, bool alive)
        {
            PlayerName = name; // ta bort Player från namn -- blir det tårta på tårta?
            PlayerDescription = description;
            PresentLocation = room;
            Alive = alive;
            PlayerBag = new List<Item>() { };
        }

        public void SearchDoor(string input)
        {
            // gör om till lista för att kunna jämföra d.Direction med det andra ordet som användaren skrivit in. 
            string text = input;
            //char[] separator = new char [] { (' ') }; // TODO: får inte till empty stringsoptions..
            string[] inputs = text.Split(' ');

            var query1 = inputs.Where(i => i == "FORWARD" || i == "BACKWARD")  // kollar vad väderstrecket ligger i input-listan
                                .Select(i => i).ToList();

            var query = PresentLocation.ListOfDoors.Where(d => d.Direction == query1[0])
                                                   .Select(d => d).ToList();

            if (query[0].Locked == true)
            {
                Console.WriteLine("Door locked! Do you have a key? YES/NO: ");
                string answer = Console.ReadLine();
                if (answer == "YES")
                {
                    Console.WriteLine("Then please use it on the door.");
                    // Game.GiveCommand();     //anropa GiveCommand() - varför går det inte här?

                }
                else if (answer == "NO")
                {
                    Console.WriteLine("Sorry, you've got to find the key first. Take a LOOK again?");
                }
                else Console.WriteLine("Try again, write YES/NO: ");
            }
            else
            {
                PresentLocation = query[0].LeadsTo;
                Console.WriteLine(query[0].LeadsTo.RoomName);
                Console.WriteLine((query[0].LeadsTo.RoomDescription));
            }
        }

        public void Grab(string input) //input blir item
        {
            var query = PresentLocation.RoomInventory.Where(i => i.ItemName == input)
                                                     .Select(d => d).ToList();
            if (input == "KEY")
            {
                //InHand = query[0]; //player tar upp item
                //Console.WriteLine("You grab the " + InHand.ItemName + ".");
                Console.WriteLine("Du grabbar nyckeln");
            }
            else
            {
                Console.WriteLine("Sorry, there is no " + input + " in this room.");
            }
        }
        public void InspectItem(string input)
        {
            Console.WriteLine("You are holding a " + InHand.ItemName + ".");
            Console.WriteLine(InHand.ItemDescription); //skriver ut föremålets beskrivning
        }

        public void KeepItem(string input) //på kommando "TAKE" //byter namn till mer relevant (player stoppar inte katten i sin bag...)
        {
            if (InHand != null)
            {
                //lägger till item i Playerbag o tar bort från Roominventory
                PlayerBag.Add(InHand);
                PresentLocation.RoomInventory.Remove(InHand);
                InHand = null;
                Console.WriteLine("Taken.");
            }
            else
            {
                Console.WriteLine("You haven't got anything in your hand.");
            }
        }

        public void DropItem(string input)
        {
            Console.WriteLine("Dropped " + InHand.ItemName + ".");
            InHand = null;
        }

        public void ItemFromBagToRoom(string input) //på kommando "LEAVE" //ELLEN: här håller jag på och stökar
        {

            //var query = PlayerBag.Where(i => i.ItemName == input)
            //                             .Select(d => d).ToList();

            //lägger till item i Roominventory o tar bort från Playerbag
            string text = input;
            string[] inputs = text.Split(' ');
            if (inputs[1] == "KEY")
            {
                Console.WriteLine("Du lämnar nyckeln i rummet");
            }

            //PlayerBag.Remove.ToString();
            //PresentLocation.RoomInventory.Add(query[0]);
        }

        public int Use(string input/*presentLocation, item (userInput), item2 (userInput)*/)
        {
            string text = input;
            //char[] separator = new char [] { (' ') }; // TODO: får inte till empty stringsoptions..
            string[] inputs = text.Split(' ');

            if (InHand.ToString().Contains(inputs[1]))
            {
                if (inputs[1] == "KEY" && inputs[3] == "DOOR")
                {
                    Console.WriteLine("Door opened! You are now moving into the next room...");

                }
            }

            throw new NotImplementedException();
        }

        public void Look(string input)
        {
            Console.WriteLine(PresentLocation.RoomDescription); //visar aktuell rumsbeskrivning
            PresentLocation.PrintRoomInventory(PresentLocation);  //anropar metod som skriver ut rummets alla föremål
        }

        // Ellen: jag håller på att plocka ut för att göra ny metod EnterNewRoom men ej klart än...
        //public void EnterNewRoom()
        //{
        //    var query1 = inputs.Where(i => i == "FORWARD" || i == "BACKWARD")  // kollar vad väderstrecket ligger i input-listan
        //           .Select(i => i).ToList();
        //    var query = PresentLocation.ListOfDoors.Where(d => d.Direction == query1[0])
        //                                           .Select(d => d).ToList();
        //    PresentLocation = query[0].LeadsTo;
        //    Console.WriteLine(query[0].LeadsTo.RoomName);
        //    Console.WriteLine((query[0].LeadsTo.RoomDescription));
        //}


    }
}
