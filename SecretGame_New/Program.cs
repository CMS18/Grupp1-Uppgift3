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
            Game myGame = new Game();
            myGame.SetUp();
                       
            myGame.Play();

        }

    }
}
 