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
      

        public Item(string itemDescription, string name)
        {
         
            ItemDescription = itemDescription;
            ItemName = name;
        }

        public int UseItem()
        {
            throw new NotImplementedException();
        }

        //public void Inspect()
        //{

        
        //    Console.WriteLine(ItemName +  ItemDescription); 
        //}
    }
}
