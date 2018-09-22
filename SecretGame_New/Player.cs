using System;
using System.Collections.Generic;

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
            PlayerName = name; 
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

        public Room Move(Room presentlocation, string direction, List<Room> listofrooms, bool locked) //direction is UserInput
        {
            if (locked == true)
            {
                Console.WriteLine("You need a key to open this door. Look around in the room.");
                return PresentLocation;
            }
            else
            {
                if (direction == "East")
                {
                    int i = listofrooms.IndexOf(presentlocation);
                    PresentLocation = listofrooms[i + 1];

                    return PresentLocation;
                }
                else if (direction == "West")
                {
                    int i = listofrooms.IndexOf(presentlocation);
                    PresentLocation = listofrooms[i - 1];

                    return PresentLocation;
                }
                else
                {
                    return PresentLocation;
                }
            } 

        }

        public int Grab(/*presentLocation, item (userInput)*/)
        {
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
        public int Inspect(/*presentLocation, item (userInput)*/)
        {
            //Visa föremålets text
            throw new NotImplementedException();
        }
    }
}
