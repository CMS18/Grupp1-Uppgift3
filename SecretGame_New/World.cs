using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class World
    {
        public List<Room> ListOfRooms { get; set; }

        public World(Room room)
        {
            ListOfRooms = new List<Room>() { room };
        }
    }
}
