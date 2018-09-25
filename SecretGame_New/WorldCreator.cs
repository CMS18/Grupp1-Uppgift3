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
        

        }

        public World BuildWorld()// internal
        {
            //Build room A osv
            World world = new World();

            Room roomA = new Room("hallway", "You standing in a very light room, with a few signs of an other person"); //skippa id
            Room roomB = new Room("Room B", "jlkjlkj");
            Room roomC = new Room("Diner", "The final room and there is just one way out");
            Room finalRoom = new Room("Final Room","jljlJ");
            world.ListOfRooms.Add(roomA);
            world.ListOfRooms.Add(roomB);
            world.ListOfRooms.Add(roomC);
            world.ListOfRooms.Add(finalRoom);

            Item map = new Item("An old map of the rooms in this enormous house", "Map");
            Item key = new Item("A big golden key", "Key");
            Item apple = new Item("A tasty red apple", "Apple");
            Item knife = new Item("A rusty but sharp knife", "Knife");
            Item hammer = new Item("Biggest tool ever seen", "Hammer");
            roomA.RoomInventory.Add(map);
            roomA.RoomInventory.Add(key);
            roomB.RoomInventory.Add(knife);
            roomB.RoomInventory.Add(hammer);
            roomC.RoomInventory.Add(apple);

            Door doorA = new Door(roomB, true, "EAST", "Door A");
            Door doorBWest = new Door(roomA, false, "WEST", "Door BWest");
            Door doorBEast = new Door(roomC, false, "EAST", "Door BEast");
            Door doorCWest = new Door(roomB, false, "WEST", "Door CWest");
            Door doorCEast = new Door(finalRoom, false, "EAST", "Door CEast");
            roomA.ListOfDoors.Add(doorA);
            roomB.ListOfDoors.Add(doorBWest);
            roomB.ListOfDoors.Add(doorBEast);
            roomC.ListOfDoors.Add(doorCWest);
            roomC.ListOfDoors.Add(doorCEast);                 
           
            world.Player = new Player("Catwoman", "Fast, smooth, smart", roomA, true, map);
            return world;
        }


        //Room roomA = new Room("Room A", 0); //skippa id
        //Room roomB = new Room("Room B", 1);
        //Room roomC = new Room("Room C", 2);
        //Room finalRoom = new Room("Final Room", 3);
        //World myWorld = new World(roomA);

        //Door doorA = new Door(roomB, true, "EAST", "Door A");
        //Door doorBWest = new Door(roomA, false, "WEST", "Door BWest");
        //Door doorBEast = new Door(roomC, false, "EAST", "Door BEast");
        //Door doorCWest = new Door(roomB, false, "WEST", "Door CWest");
        //Door doorCEast = new Door(finalRoom, false, "EAST", "Door CEast");


        //Item item0 = new Item(0, "An old map of the rooms in this enormous house", "Map");
        //Item item1 = new Item(1, "A big golden key", "Key");
        //Item item2 = new Item(2, "A tasty red apple", "Apple");
        //Item item3 = new Item(3, "A rusty but sharp knife", "Knife");
        //Item item4 = new Item(4, "Biggest tool ever seen", "Hammer");

        //roomA.ListOfDoors.Add(doorA);
        //roomB.ListOfDoors.Add(doorBWest);
        //roomB.ListOfDoors.Add(doorBEast);
        //roomC.ListOfDoors.Add(doorCWest);
        //roomC.ListOfDoors.Add(doorCEast);
        //roomA.RoomInventory.Add(item1);
        //roomA.RoomInventory.Add(item2);
        //roomB.RoomInventory.Add(item3);
        //roomB.RoomInventory.Add(item4);

        //myWorld.ListOfRooms.Add(roomB);
        //myWorld.ListOfRooms.Add(roomC);

        //Player myPlayer = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);

        //myPlayer.Move(myPlayer.PresentLocation, "East", myWorld.ListOfRooms, true);
        //myPlayer.Move(myPlayer.PresentLocation, "East", myWorld.ListOfRooms, false);
        //myPlayer.Move(myPlayer.PresentLocation, "West", myWorld.ListOfRooms, false);

        //Console.WriteLine(myPlayer.PresentLocation.RoomName.ToString());

        //// myPlayer.Move( "West", myWorld.ListOfRooms);

        //Console.ReadLine();
        //public Player Initialize()
        //{
        //Room roomA = new Room("Room A", 0); //skippa id
        //Room roomB = new Room("Room B", 1);
        //Room roomC = new Room("Room C", 2);
        //Room finalRoom = new Room("Final Room", 3);
        //World myWorld = new World(roomA);

        //Door doorA = new Door(roomB, true, "EAST", "Door A");
        //Door doorBWest = new Door(roomA, false, "WEST", "Door BWest");
        //Door doorBEast = new Door(roomC, false, "EAST", "Door BEast");
        //Door doorCWest = new Door(roomB, false, "WEST", "Door CWest");
        //Door doorCEast = new Door(finalRoom, false, "EAST", "Door CEast");


        //Item item0 = new Item(0, "An old map of the rooms in this enormous house", "Map");
        //Item item1 = new Item(1, "A big golden key", "Key");
        //Item item2 = new Item(2, "A tasty red apple", "Apple");
        //Item item3 = new Item(3, "A rusty but sharp knife", "Knife");
        //Item item4 = new Item(4, "Biggest tool ever seen", "Hammer");

        //roomA.ListOfDoors.Add(doorA);
        //    roomB.ListOfDoors.Add(doorBWest);
        //    roomB.ListOfDoors.Add(doorBEast);
        //    roomC.ListOfDoors.Add(doorCWest);
        //    roomC.ListOfDoors.Add(doorCEast);
        //    roomA.RoomInventory.Add(item1);
        //    roomA.RoomInventory.Add(item2);
        //    roomB.RoomInventory.Add(item3);
        //    roomB.RoomInventory.Add(item4);

        //    myWorld.ListOfRooms.Add(roomB);
        //    myWorld.ListOfRooms.Add(roomC);

        //    Player myPlayer = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);

        ////}


    }
}
