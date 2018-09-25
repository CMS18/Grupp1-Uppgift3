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

        public void SearchDoor(string input)
        {
            var query = PresentLocation.ListOfDoors.Where(d => d.Direction == input)
                                                   .Select(d => d).ToList();

            if (query[0].Locked == true)
            {
                Console.WriteLine("Door locked");
            }
            else
            {
                PresentLocation = query[0].LeadsTo;
                Console.WriteLine(query[0].LeadsTo.RoomName);
            }
        }

        public void SearchItem(string input)
        {
            var query = PresentLocation.RoomInventory.Where(i => i.ItemName == input)
                                                   .Select(d => d).ToList();

            if (query[0].Locked == true)
            {
                Console.WriteLine("Door locked");
            }
            else
            {
                PresentLocation = query[0].LeadsTo;
                Console.WriteLine(query[0].LeadsTo.RoomName);
            }

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
