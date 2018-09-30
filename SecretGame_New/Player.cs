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
                Console.WriteLine("Door locked!  "); //Do you have a key? YES/ NO:
                //string answer = Console.ReadLine();
                //if (answer == "YES")
                //{
                //    Console.WriteLine("Then please use it on the door.");
                //    // Game.GiveCommand();     //anropa GiveCommand() - varför går det inte här?
                //    //här behöver vi fråga efter input igen (med GiveCommand)
                //}
                //else if (answer == "NO")
                //{
                //    Console.WriteLine("Sorry, you've got to find the key first. Take a LOOK again?");
                //    //här behöver vi fråga efter input igen
                //}
                //else Console.WriteLine("Try again, write YES/NO: ");
            }
            else
            {
                PresentLocation = query[0].LeadsTo;
                Console.WriteLine(query[0].LeadsTo.RoomName);
                Console.WriteLine(query[0].LeadsTo.RoomDescription);
                Console.WriteLine(query[0].LeadsTo.RoomInventory);
            }
        }

        public void Take(string input) //input blir item
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

        public void Use(string input/*presentLocation, item (userInput), item2 (userInput)*/)
        {
            string text = input;
            //char[] separator = new char [] { (' ') }; // TODO: får inte till empty stringsoptions..
            string[] inputs = text.Split(' ');
            Console.WriteLine("Use key on door");

            var query = PlayerBag.Where(i => i.ItemName.Equals(inputs[1]))
                                 .Select(d => d).ToList();
            if (query[0].ItemName =="KEY")
            {
                PresentLocation.FindDoor(PresentLocation);
                
            }
            if (query[0].ItemName != "KEY")
            {
                Console.WriteLine("Sorry you need to find the key first");

            }

            // PresentLocation.ListOfDoors
            //if (PlayerBag.Contains(input[1]).ToString())

            //if (InHand.ToString().Contains(inputs[1]))
            //{
            //    if (inputs[1] == "KEY" && inputs[3] == "DOOR")
            //    {
            //        Console.WriteLine("Door opened! You are now moving into the next room...");

            //    }
            //}
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
