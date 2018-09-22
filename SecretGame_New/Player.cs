﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Item> PlayerBag { get; set; }
        public string PlayerDescription { get; set; }
        public Room PresentLocation { get; set; }
        public bool Alive { get; set; }

        //constructor
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
    
        ////  List<Room> ListOfRooms = new List<Room>() { roomA, roomB };

        ////Ellen writes: Below I am trying to create method to move player

        //public Room Move(Room room, string direction) //direction is UserInput
        //{
        //    if (direction == "East")//cannot reach ListOfRooms from here - why?!)
        //    {
        //        PresentLocation = ??  //Here I want to set PresentLocation to RoomB instead
            
        //            return room;            //Can we use the keyword "this." here, to reach current room? 
        //    }
        //    else
        //    {
        //        return PresentLocation;
        //    }

        //}

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
