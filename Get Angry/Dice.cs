using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Angry
{
    static class Dice
    {
        public static int throwDice()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }
    }
}
