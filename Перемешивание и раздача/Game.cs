using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    //Раздает крарты ги стои и игрокам
    class MapHandTable
    {
        public MapHandTable(int[] map)
        {
            Map = map;
        }

        public int[] Map { get; set; }
        
        //Раздает карты на стол
        public int[] TableMap(int count)
        {
            switch (count)
            {
                case 1:
                    return new int[] { Map[0], Map[1], Map[2] };
                case 2:
                    return new int[] { Map[0], Map[1], Map[2], Map[3] };
                case 3:
                    return new int[] { Map[0], Map[1], Map[2], Map[3],Map[4]};
                default:
                    break;
            }
            return new int[0];
        }
        //раздает карты игрокам numberGamer = номер игрока.
        public int[] PlayerMap(int count, int numberGamer = 1)
        {
            if (count < 4)
                return new int[] { Map[5 + (numberGamer * 2)], Map[6 + (numberGamer * 2)] };
            else
                return new int[0];   
        }

    }
}

