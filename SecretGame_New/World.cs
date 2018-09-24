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
        public Player Player { get; set; }

        public World()
        {
            ListOfRooms = new List<Room>();
        }
    }
}
