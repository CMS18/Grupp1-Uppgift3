using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class WorldCreator

    {
        public WorldCreator()

        {
            Room roomA = new Room("Room A", 0);
            Room roomB = new Room("Room B", 1);
            World myWorld = new World(roomA);

            Door doorA = new Door(roomB, false, "Door A");
            Door doorB = new Door(roomA, false, "Door B");

            Item item0 = new Item(0, "An old map of the rooms in this enormous house", "Map");
            Item item1 = new Item(1, "A big golden key", "Key");
            Item item2 = new Item(2, "A tasty red apple", "Apple");
            Item item3 = new Item(3, "A rusty but sharp knife", "Knife");
            Item item4 = new Item(4, "Biggest tool ever seen", "Hammer");


            roomA.ListOfDoors.Add((doorA));
            roomA.RoomInventory.Add((item1));
            roomA.RoomInventory.Add((item2));
            roomB.RoomInventory.Add((item3));
            roomB.RoomInventory.Add((item4));

            myWorld.ListOfRooms.Add((roomB));


            Player myPlayer = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);

            myPlayer.Move(myPlayer.PresentLocation, "East", myWorld.ListOfRooms);
            myPlayer.Move(myPlayer.PresentLocation, "West", myWorld.ListOfRooms);


            Console.WriteLine(myPlayer.PresentLocation.RoomName.ToString());

            Console.ReadLine();

        }



    }
}
