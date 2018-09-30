﻿using System;
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
                Console.WriteLine("Door locked!  ");
            }
            else
            {
                EnterNewRoom(input);
            }
        }

        public void Take(string input)
        {
            var query = PresentLocation.RoomInventory.Where(i => i.ItemName == input)
                                                     .Select(d => d).ToList();
            if (query[0] != null)
            {
                Console.WriteLine(query[0].ItemName + " taken.");
                PlayerBag.Add(query[0]);  //lägger till item i Playerbag o tar bort från Roominventory
                PresentLocation.RoomInventory.Remove(query[0]);
            }
            else if (query[0] == null)
            {
                Console.WriteLine("Sorry, there is no " + input + " in this room.");
            }

        }
        public void InspectItem(string input)
        {
            var query = PresentLocation.RoomInventory.Where(i => i.ItemName == input)
                                                    .Select(d => d).ToList();
            if (query[0] != null)
            {
                Console.WriteLine("You see a " + query[0].ItemName + ".");
                Console.WriteLine(query[0].ItemDescription); //skriver ut föremålets beskrivning
            }
            else if (query[0] == null)
            {
                Console.WriteLine("Sorry, there is no " + input + " in this room.");
            }
        }

        public void DropItem(string input)
        {
            var query = PlayerBag.Where(i => i.ItemName == input)
                                        .Select(d => d).ToList();
            if (query[0] != null)
            {
                Console.WriteLine("Dropped " + query[0].ItemName + " in the room.");
                PlayerBag.Remove(query[0]);
                PresentLocation.RoomInventory.Add(query[0]);
            }
            else if (query[0] == null)
            {
                Console.WriteLine("Sorry, there is nothing to drop.");
            }
        }

        public void Use(string input)
        {
            string text = input;
            //char[] separator = new char [] { (' ') }; // TODO: får inte till empty stringsoptions..
            string[] inputs = text.Split(' ');


            var query = PlayerBag.Where(i => i.ItemName.Equals(inputs[1]))
                                 .Select(d => d).ToList();
            if (query[0].ItemName == "KEY")
            {
                PresentLocation.FindDoor(PresentLocation);

            }
            if (query[0].ItemName !="KEY")
            {
                Console.WriteLine("Sorry you need to find the key first");

            }
          

        }
        public void Give(string input/*presentLocation, item (userInput), item2 (userInput)*/)
        {
            string text = input;
            //char[] separator = new char [] { (' ') }; // TODO: får inte till empty stringsoptions..
            string[] inputs = text.Split(' ');

            var query = PresentLocation.RoomInventory.Where(i => i.ItemName.Equals(inputs[1]))
                                                     .Select(d => d).ToList();
            if(query[0].ItemName == "CAT")
            {
                PresentLocation.GiveCat(input);
            }
           
        }

        public void Look(string input)
        {
            PresentLocation.PrintDescription(PresentLocation); //skriver ut rummets beskrivning och föremål
        }

        public void EnterNewRoom(string input)
        {
            string text = input;
            string[] inputs = text.Split(' ');
            var query1 = inputs.Where(i => i == "FORWARD" || i == "BACKWARD")
                               .Select(i => i).ToList();

            var query = PresentLocation.ListOfDoors.Where(d => d.Direction == query1[0])
                                                   .Select(d => d).ToList();
            PresentLocation = query[0].LeadsTo;

            if (PresentLocation.GameOver == true)
            {
                Console.WriteLine(query[0].LeadsTo.RoomName);
                Console.WriteLine(PresentLocation.RoomDescription);
                Alive = false;
            }
            else
            {
                PresentLocation.PrintDescription(PresentLocation);
            }
        }


    }
}
