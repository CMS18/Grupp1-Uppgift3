using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
   public class Item
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemId { get; set; }

        public Item(int roomId, string name)
        {
            ItemId = roomId;
            ItemName = name;
        }

        public int UseItem()
        {
            throw new NotImplementedException();
        }

        public int Inspect()
        {
            throw new NotImplementedException();
        }
    }
}
