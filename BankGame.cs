using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    public class BankGame
    {

        public void FirstPart(ref int oneGamer, ref int twoGamer, ref int oneGamerRate, ref int twoGamerRate, ref int bankOne, ref int bankTwo)
        {
            oneGamerRate = 5;
            bankOne -= 5;

            twoGamerRate = 10;
            bankTwo -= 10;
            twoGamer = 3;
        }


    }
}
  
