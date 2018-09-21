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
        
        public bool Locked { get; set; } //open,closed,locked.

        public Door(Room leadsTO, bool locked , string doorname )
            
        {
            DoorName = doorname;
            LeadsTo = leadsTO;
            Locked = locked;

        }
    }
}
