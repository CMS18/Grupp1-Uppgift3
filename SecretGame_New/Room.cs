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


        public Room(string name, string description)
        {
            RoomName = name;
            RoomDescription = description;
            RoomInventory = new List<Item>() { };
            ListOfDoors = new List<Door>() { };
        }

        public void PrintDescription(Room room) //på kommando LOOK //argument: Room eller en input-string?
        {
            Console.WriteLine(RoomDescription);
            Console.WriteLine("The items you can see in this room are: ");
            foreach (Item item in RoomInventory)
            {
                Console.WriteLine(item.ItemName + ": " + item.ItemDescription); //listar rummets föremål
            }

            Console.WriteLine("The exits from this room are: ");
            foreach (Door door in ListOfDoors)
            {
                Console.WriteLine(door.DoorName + ", leads to: " + door.LeadsTo.RoomName); //listar rummets dörrar
            }
        }

        public void PrintRoomInventory(Room presentLocation)
        {
            Console.WriteLine("The items you can see in this room are: ");
            foreach (Item item in RoomInventory)
            {
                Console.WriteLine(item.ItemName);
            }
        }
        public void FindDoor(Room presentLocation)
        {
            foreach (Door door in ListOfDoors)
            {
                Console.WriteLine(door.DoorName + " , leads to: " + door.LeadsTo.RoomName + door.Locked); //listar rummets dörrar
                door.Locked = false; 
                Console.WriteLine("Dörren är upplåst" + door.Locked);
            }
        }
        public void LookClose()
        {

        }

    }

}
