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
        public List<Door> ListOfDoors { get; set; }
        public int RoomId { get; set; }
        public List<Exit> ListOfExits { get; set; }

        public Room(string name, int roomId)
        {
            RoomName = name;
            RoomId = roomId;
            RoomInventory = new List<Item>() { };
            ListOfDoors = new List<Door>() { };
        }
        public Room(string name, int roomId, Item item, Door exit)
        {
            RoomName = name;
            RoomId = roomId;
            RoomInventory = new List<Item>() { item };
            ListOfDoors = new List<Door>() { exit };
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
