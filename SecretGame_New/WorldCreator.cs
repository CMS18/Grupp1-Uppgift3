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

        { }

        public World BuildWorld()// internal
        {
            //Build room A osv
            World world = new World();

            Room roomA = new Room("hallway", "You standing in a very light room, with a few signs of an other person"); 
            Room roomB = new Room("kitchen", "You are standing in a very nice kitchen.\n On the floor you see nothing...\n But on the table you see an apple");
            Room roomC = new Room("Diner", "The final room and there is just one way out");
            Room finalRoom = new Room("Final Room","Yay! You did it!");
            world.ListOfRooms.Add(roomA);
            world.ListOfRooms.Add(roomB);
            world.ListOfRooms.Add(roomC);
            world.ListOfRooms.Add(finalRoom);

            Item map = new Item("An old map of the rooms in this enormous house", "Map");
            Item key = new Item("A big golden key", "Key");
            Item apple = new Item("A tasty red apple", "Apple");
            Item knife = new Item("A rusty but sharp knife", "Knife");
            Item hammer = new Item("Biggest tool ever seen", "Hammer");
            roomA.RoomInventory.Add(key);
            roomA.RoomInventory.Add(map);
            roomB.RoomInventory.Add(knife);
            roomB.RoomInventory.Add(hammer);
            roomC.RoomInventory.Add(apple);

            Door doorA = new Door(roomB, false, "EAST", "Door A");
            Door doorBWest = new Door(roomA, false, "WEST", "Door BWest");
            Door doorBEast = new Door(roomC, false, "EAST", "Door BEast");
            Door doorCWest = new Door(roomB, false, "WEST", "Door CWest");
            Door doorCEast = new Door(finalRoom, false, "EAST", "Door CEast");
            roomA.ListOfDoors.Add(doorA);
            roomB.ListOfDoors.Add(doorBWest);
            roomB.ListOfDoors.Add(doorBEast);
            roomC.ListOfDoors.Add(doorCWest);
            roomC.ListOfDoors.Add(doorCEast);                 
           
            world.Player = new Player("Catwoman", "Fast, smooth, smart", roomA, true);
            return world;
        }

    }
}
