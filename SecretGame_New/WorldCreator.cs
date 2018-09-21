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
            Room roomA = new Room("Room A");
            Room roomB = new Room("Room B");

            Door doorA = new Door(roomB, false,"Door A");

            List<Item> RoomAInventory = new List<Item>() { };  // skicka in formole lista 

           

        }

       
        
    }
}
