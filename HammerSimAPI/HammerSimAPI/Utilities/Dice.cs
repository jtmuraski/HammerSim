using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSimAPI.Utilities
{
    public static class Dice
    {
        public static int RollD6()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }
    }
}
