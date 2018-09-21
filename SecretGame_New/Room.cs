using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class Room
    {
        public List<Item> RoomInventory { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public List<Exit> ListOfExits { get; set; }

        public Room(string name)
        {
            RoomName = name; 
        }

        public void PrintDescription()
        {
            //Visa användaren aktuell rumsbeskrivning
        }

        public void LookClose()
        {

        }

    }
}
