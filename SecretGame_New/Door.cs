using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class Door
    {
        public string DoorName { get; set; }
        public Room LeadsTo { get; set; }
        public string Direction { get; set; }
        public bool Locked { get; set; }
        public bool GameOver { get; set; }

        public Door(Room leadsTO, bool locked, string direction, string doorname)
        {
            DoorName = doorname;
            LeadsTo = leadsTO;
            Direction = direction;
            Locked = locked;
        }
        public Door(Room leadsTO, bool locked, string direction, string doorname, bool GameOver) //constructor för sista dörren

        {
            DoorName = doorname;
            LeadsTo = leadsTO;
            Direction = direction;
            Locked = locked;
            GameOver = false;
        }
    }
}
