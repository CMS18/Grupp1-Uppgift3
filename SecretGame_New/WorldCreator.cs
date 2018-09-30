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
            World world = new World();

            Room roomA = new Room("hallway", "You stand at the entrance of a long hallway, " +
                "increasingly filled with smoke, " +
                "At the end of the hallway there is an old wooden door. " +
                "Can you find a key to unlock it? ");
            Room roomB = new Room("kitchen", "You are standing in a big and smokefilled kitchen. " +
                "You can almost see nothing... ");
            Room roomC = new Room("diner", "You have reached the dining room. On the table you see a cat, " +
                "terrified of the flames rising up from the floor..." +
                "On the other side of the room you see a door leading out! But you must get the cat first...");
            Room finalRoom = new Room("Final Room", "Yay! You did it! You are outside, and got the cat with you!");
            world.ListOfRooms.Add(roomA);
            world.ListOfRooms.Add(roomB);
            world.ListOfRooms.Add(roomC);
            world.ListOfRooms.Add(finalRoom);

            Item map = new Item("An old map of the rooms in this enormous house", "MAP");
            Item key = new Item("A big golden key", "KEY");
            Item apple = new Item("A tasty red apple", "APPLE");
            Item knife = new Item("A rusty but sharp knife", "KNIFE");
            Item hammer = new Item("Biggest tool ever seen", "HAMMER");
            Item toy = new Item("An old fashioned doll", "PLASTIC TOY");
            Item cat = new Item("A black cat", "CAT");
            roomA.RoomInventory.Add(key);
            roomA.RoomInventory.Add(map);
            roomB.RoomInventory.Add(hammer);
            roomC.RoomInventory.Add(apple);
            roomC.RoomInventory.Add(cat);

            Door doorA = new Door(roomB, true, "FORWARD", "Old wooden door");
            Door doorBBackward = new Door(roomA, false, "BACKWARD", "Door BBackward");
            Door doorBEast = new Door(roomC, false, "FORWARD", "Door BForward");
            Door doorCBackward = new Door(roomB, false, "BACKWARD", "Door CBackward");
            Door doorCForward = new Door(finalRoom, false, "FORWARD", "Door CForward", true);
            roomA.ListOfDoors.Add(doorA);
            roomB.ListOfDoors.Add(doorBBackward);
            roomB.ListOfDoors.Add(doorBEast);
            roomC.ListOfDoors.Add(doorCBackward);
            roomC.ListOfDoors.Add(doorCForward);

            world.Player = new Player("Catwoman", "Fast, smooth, smart", roomA, true);
            world.Player.PlayerBag.Add(toy);
            world.Player.PlayerBag.Add(knife);

            return world;

        }
    }
}
