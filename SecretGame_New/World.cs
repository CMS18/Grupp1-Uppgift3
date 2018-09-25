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
        public List<Door> ListOfDoors { get; set; } // lagt till
        public List<Item> Inventory  { get; set; }
        //public List<Item> ListOfItemsPlayer { get; set; } //lagt till
        //public List<Item> ListOfItemsRoom { get; set; } //lagt till


        public World()
        {
            ListOfRooms = new List<Room>();
            ListOfDoors = new List<Door>();
            Inventory = new List<Item>();
        }


        public void MoveItemfromRoom()//??
        {

        }

        public void MoveItemfromPlayer()//??
        {

        }
    }
}
