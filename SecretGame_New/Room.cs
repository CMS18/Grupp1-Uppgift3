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

        public void PrintDescription()
        {
            if (RoomName == "Kitchen")
            {
                Console.WriteLine("This is the very first room in the very empty house.");
                    foreach(Item c in RoomInventory)
                    {
                    Console.WriteLine();
                    }
            }//Visa användaren aktuell rumsbeskrivning
        }

         

        public void LookClose()
        {

        }

    }
}
