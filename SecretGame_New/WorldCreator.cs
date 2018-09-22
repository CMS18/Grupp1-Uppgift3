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

            Item item0 = new Item(0, "Key");

            roomA.ListOfDoors.Add((doorA));
            roomA.RoomInventory.Add((item0));
            myWorld.ListOfRooms.Add((roomB));
            
            
           


            Player myPlayer = new Player("Catwoman", "Fast, smooth, smart", roomA, true, item0);

            myPlayer.Move(myPlayer.PresentLocation, "East", myWorld.ListOfRooms);

            Console.WriteLine(myPlayer.PresentLocation.ToString());

            Console.ReadLine();

        }
        


    }
}
