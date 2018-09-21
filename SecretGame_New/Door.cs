using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class Door //:Room
    {
       // public string Name { get; set; }
        public int LeadsTo { get; set; }
        public List<string> Direction { get; set; }
        public int Status { get; set; } //open,closed,locked.

        public Door(int leadsTO, int status)
        {
            
            leadsTO = Room.RoomName;
        }
    }
}
