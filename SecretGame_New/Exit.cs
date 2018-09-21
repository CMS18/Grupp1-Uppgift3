using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    public class Exit 
    {
        public List<string> Direction { get; set; }

        public List<Exit> Exit1 { get; set; } // tre versioner av varje dörr. 
        
    }
}
