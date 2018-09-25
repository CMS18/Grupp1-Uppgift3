using System;
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



            //WorldCreator gameBuilder = new WorldCreator();

            //var player = gameBuilder.Initialize();

            //player. sköta kommunikationen med spelaren.
            //Console.WriteLine("Vart vill du gå?");

            string text = Console.ReadLine();
            string[] inputs = text.Split(' ');

            foreach (string s in inputs)
            {
                Console.WriteLine(s);
            }

            if (inputs[0] == "move")
            {
                Console.WriteLine("Du vill gå ");
            }

            if (inputs[1] == "right")
            {
                Console.WriteLine("Du vill gå till höger");
            }
            // Console.WriteLine(direction);

        }

    }
}
 