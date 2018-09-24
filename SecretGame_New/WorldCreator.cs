using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class WorldCreator

    {
        public WorldCreator() //i constructorn ska bara vara basic saker, Lägg grupperna nedan i egna metoder 
            //under constructorn

        {
            Room roomA = new Room("Room A", 0); //skippa id
            Room roomB = new Room("Room B", 1);
            Room roomC = new Room("Room C", 2);
            Room finalRoom = new Room("Final Room", 3);
            World myWorld = new World(roomA);

            Door doorA = new Door(roomB, true, "EAST", "Door A");
            Door doorBWest = new Door(roomA, false, "WEST", "Door BWest");
            Door doorBEast = new Door(roomC, false, "EAST", "Door BEast");
            Door doorCWest = new Door(roomB, false, "WEST", "Door CWest");
            Door doorCEast = new Door(finalRoom, false, "EAST", "Door CEast");


            Item item0 = new Item(0, "An old map of the rooms in this enormous house", "Map");
            Item item1 = new Item(1, "A big golden key", "Key");
            Item item2 = new Item(2, "A tasty red apple", "Apple");
            Item item3 = new Item(3, "A rusty but sharp knife", "Knife");
            Item item4 = new Item(4, "Biggest tool ever seen", "Hammer");

            roomA.ListOfDoors.Add(doorA);
            roomB.ListOfDoors.Add(doorBWest);
            roomB.ListOfDoors.Add(doorBEast);
            roomC.ListOfDoors.Add(doorCWest);
            roomC.ListOfDoors.Add(doorCEast);
            roomA.RoomInventory.Add(item1);
            roomA.RoomInventory.Add(item2);
            roomB.RoomInventory.Add(item3);
            roomB.RoomInventory.Add(item4);

            myWorld.ListOfRooms.Add(roomB);
            myWorld.ListOfRooms.Add(roomC);

            Player myPlayer = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);

            myPlayer.Move(myPlayer.PresentLocation, "East", myWorld.ListOfRooms, true);
            myPlayer.Move(myPlayer.PresentLocation, "East", myWorld.ListOfRooms, false);
            myPlayer.Move(myPlayer.PresentLocation, "West", myWorld.ListOfRooms, false);

            Console.WriteLine(myPlayer.PresentLocation.RoomName.ToString());

            // myPlayer.Move( "West", myWorld.ListOfRooms);

            Console.ReadLine();

        }

        internal World BuildWorld()
        {
            World world = new World();

            //Build room A osv
            world.Player = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);
            return world;
        }

        public Player Initialize()
        {
        Room roomA = new Room("Room A", 0); //skippa id
        Room roomB = new Room("Room B", 1);
        Room roomC = new Room("Room C", 2);
        Room finalRoom = new Room("Final Room", 3);
        World myWorld = new World(roomA);

        Door doorA = new Door(roomB, true, "EAST", "Door A");
        Door doorBWest = new Door(roomA, false, "WEST", "Door BWest");
        Door doorBEast = new Door(roomC, false, "EAST", "Door BEast");
        Door doorCWest = new Door(roomB, false, "WEST", "Door CWest");
        Door doorCEast = new Door(finalRoom, false, "EAST", "Door CEast");


        Item item0 = new Item(0, "An old map of the rooms in this enormous house", "Map");
        Item item1 = new Item(1, "A big golden key", "Key");
        Item item2 = new Item(2, "A tasty red apple", "Apple");
        Item item3 = new Item(3, "A rusty but sharp knife", "Knife");
        Item item4 = new Item(4, "Biggest tool ever seen", "Hammer");

        roomA.ListOfDoors.Add(doorA);
            roomB.ListOfDoors.Add(doorBWest);
            roomB.ListOfDoors.Add(doorBEast);
            roomC.ListOfDoors.Add(doorCWest);
            roomC.ListOfDoors.Add(doorCEast);
            roomA.RoomInventory.Add(item1);
            roomA.RoomInventory.Add(item2);
            roomB.RoomInventory.Add(item3);
            roomB.RoomInventory.Add(item4);

            myWorld.ListOfRooms.Add(roomB);
            myWorld.ListOfRooms.Add(roomC);

            Player myPlayer = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);

        //}


    }
}
