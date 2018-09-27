using System;
using System.Collections.Generic;
using System.Linq; 

namespace SecretGame_New
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Item> PlayerBag { get; set; }
        public string PlayerDescription { get; set; }
        public Room PresentLocation { get; set; }
        public bool Alive { get; set; }

        //constructor 1
        public Player(string name, string description, Room room, bool alive)
        {
            PlayerName = name; // ta bort Player från namn -- blir det tårta på tårta?
            PlayerDescription = description;
            PresentLocation = room;
            Alive = alive;
            PlayerBag = new List<Item>() { };
        }

        //constructor 2
        public Player(string name, string description, Room room, bool alive, Item item)
        {
            PlayerName = name;
            PlayerDescription = description;
            PresentLocation = room;
            Alive = alive;
            PlayerBag = new List<Item>() { item };
        }

        //public Room Move( Door door) //direction is UserInput
        //{
        //    //if (locked == true)
            //{
            //    Console.WriteLine("You need a key to open this door. Look around in the room.");
            //    return PresentLocation;
            //}
            //else
            //{
            //    if (direction == "East")
            //    {
            //        int i = listofrooms.IndexOf(presentlocation);
            //        PresentLocation = listofrooms[i + 1];

            //        return PresentLocation;
            //    }
            //    else if (direction == "West")
            //    {
            //        int i = listofrooms.IndexOf(presentlocation);
            //        PresentLocation = listofrooms[i - 1];

            //        return PresentLocation;
            //    }
            //    else
            //    {
            //        return PresentLocation;
            //    }
            //} 

        //}
        public void SearchDoor(string input)
        {
            // gör om till lista för att kunna jämföra d.Direction med det andra ordet som användaren skrivit in. 
            string text = input; 
            //char[] separator = new char [] { (' ') }; // TODO: får inte till empty stringsoptions..
            string[] inputs = text.Split(' ');

            var query = PresentLocation.ListOfDoors.Where(d => d.Direction ==inputs[1]) // ändrat till [1] då input har blivit en array efter split. 
                                                   .Select(d => d).ToList();


            if (query[0].Locked == true)
            {
                Console.WriteLine("Door locked");
            }
            else
            {
                PresentLocation = query[0].LeadsTo;
                Console.WriteLine(query[0].LeadsTo.RoomName);
                Console.WriteLine((query[0].LeadsTo.RoomDescription)); 
            }


        }



        public int Grab(string result)
        {
            Console.WriteLine("Du vill ta ngt");
            throw new NotImplementedException();
        }
        public int Drop(/*presentLocation, item (userInput)*/)
        {
            throw new NotImplementedException();
        }
        public int Use(/*presentLocation, item (userInput), item2 (userInput)*/)
        {
            throw new NotImplementedException();
        }
        public int Open(/*presentLocation, exit (userInput)*/)
        {
            throw new NotImplementedException();
        }
        public int Look(/*presentLocation*/)
        {
            //kontrollerar rummets föremål, visa aktuell beskrivning
            throw new NotImplementedException();
        }
        public int Inspect( string input/*presentLocation,  (userInput)*/)
        {
            string text = input;
            //char[] separator = new char [] { (' ') }; // HUR SKA VI FÅ REDA PÅ RÄTT ITEM???
            string[] inputs = text.Split(' ');

          
            //Visa föremålets text
            throw new NotImplementedException();
        }
    }
}
