﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGame_New
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldCreator gameBuilder = new WorldCreator();

            //var player = gameBuilder.Initialize();

            //player. sköta kommunikationen med spelaren.
            Console.WriteLine("Vart vill du gå?");

            string direction = Console.ReadLine();
            string[] directions = direction.Split(' ');

            foreach (string s in directions)
            {
                Console.WriteLine(s);
            }

            if (directions[0] == "move")
            {
                Console.WriteLine("Du vill gå ");
            }

            if (directions[1] == "right")
            {
                Console.WriteLine("Du vill gå till höger");
            }
            // Console.WriteLine(direction);

        }
    
    }
}
 