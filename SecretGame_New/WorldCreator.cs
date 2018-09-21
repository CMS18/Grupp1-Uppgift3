using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    class WorldCreator

    {
        public WorldCreator()

        {
            Room roomA = new Room("Room A", 0);
            Room roomB = new Room("Room B", 1);

            Door doorA = new Door(roomB, false, "Door A");

            Item item0 = new Item(0, "Key");

            roomA.ListOfDoors.Add((doorA));

           
            //  List<Room> ListOfRooms = new List<Room>() { roomA, roomB };


         }



    }
}
