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

        //public void SearchDoorAndMove(string input)
        //{
        //    PlayerName = playername;
        //    PlayerDescription = description;
        //    PresentLocation = room;
        //    Alive = alive;
        //    PlayerBag = new List<Item>() { item };
        //}

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

            var query1 = inputs.Where(i => i == "EAST" || i == "WEST")  // kollar vad väderstrecket ligger i input-listan
                                .Select(i => i).ToList();
                        
            var query = PresentLocation.ListOfDoors.Where(d => d.Direction == query1[0])
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

        public void Grab(string input)
        {
            var query = PresentLocation.RoomInventory.Where(i => i.ItemName == input)
                                                     .Select(d => d).ToList();

            InHand = query[0]; //player tar upp item
        }
        public void InspectItem(string input)
        {

            Console.WriteLine(InHand.ItemDescription); //skriver ut föremålets beskrivning
        }

        public void PutItemInBag(string input) //på kommando "TAKE"
        {
            //lägger till item i Playerbag o tar bort från Roominventory
            PlayerBag.Add(InHand);
            PresentLocation.RoomInventory.Remove(InHand);
            InHand = null;
            Console.WriteLine("Taken.");
        }

        public void DropItem(string input)
        {
            InHand = null;
            Console.WriteLine("Dropped."); //ev fixa utskriften av InHand (Item)
        }

        public void ItemFromBagToRoom(string input) //på kommando "LEAVE"
        {
            var query = PlayerBag.Where(i => i.ItemName == input)
                                         .Select(d => d).ToList();

            //lägger till item i Roominventory o tar bort från Playerbag
            PlayerBag.Remove(query[0]);
            PresentLocation.RoomInventory.Add(query[0]);
        }

        public int Use(/*presentLocation, item (userInput), item2 (userInput)*/)
        {
            throw new NotImplementedException();
        }
       
        public void Look(string input)
        {
            Console.WriteLine(PresentLocation.RoomDescription); //visar aktuell rumsbeskrivning
            Console.WriteLine("The items you can see in this room are: ");
            {
                Console.WriteLine("Här skrivs rummets föremål ut");
                //    Console.WriteLine(this.PresentLocation.RoomInventory[item]);    //skriva ut rummets föremål!
            }
        }

    }
}
