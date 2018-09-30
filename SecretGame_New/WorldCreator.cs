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
            World world = new World();

            Room roomA = new Room("hallway", "You now stand at the entrance of a long hallway. " +
                "The hallways gets darker, increasingly filled with smoke, " +
                "and at the end of the hallway is an old wooden door. " +
                "Grab the key to unlock it and move on. ");
            Room roomB = new Room("kitchen", "You are standing in a big and smokefilled kitchen. " +
                "You can almost see nothing... But on the table you see a cat, terrified of the flames " +
                "rising up from the floor... ");
            Room roomC = new Room("diner", "You have reached the end of a long dark hallway." +
                "You can not  \n see no where to go but back, The final room and there is just one way out");
            Room finalRoom = new Room("Final Room", "Yay! You did it!");
            world.ListOfRooms.Add(roomA);
            world.ListOfRooms.Add(roomB);
            world.ListOfRooms.Add(roomC);
            world.ListOfRooms.Add(finalRoom);

            Item map = new Item("An old map of the rooms in this enormous house", "map");
            Item key = new Item("A big golden key", "key");
            Item apple = new Item("A tasty red apple", "apple");
            Item knife = new Item("A rusty but sharp knife", "knife");
            Item hammer = new Item("Biggest tool ever seen", "hammer");
            Item toy = new Item("An old fashioned doll", "plastic toy");
            roomA.RoomInventory.Add(key);
            roomA.RoomInventory.Add(map);
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
            world.Player.PlayerBag.Add(toy);
            world.Player.PlayerBag.Add(knife);

            return world; // Blev fel efter senaste mergen...Har lagt till denna men vet inte om det är rätt som det var tidigare...

        }
    }
}
