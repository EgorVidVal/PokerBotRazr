using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    class Bot
    {
        public int Rate { get; set; }
        public int BotStart(int gamerResh)
        {
            int res = 0;
            Random r = new Random();

            if (gamerResh == 0)
            {
                res = r.Next(2, 4);
                if (res == 3)
                {
                    Rate = r.Next(10, 100);
                }
            }
            else if (gamerResh == 2)
            {
                res = r.Next(2, 4);
                if (res == 3)
                {
                    Rate = r.Next(10, 100);
                }
            }
            else if (gamerResh == 3)
            {
                res = r.Next(2, 4);
                if (res == 3)
                {
                    Rate = r.Next(10, 100);
                }
            }

            return res;


            
        }
    }
}
