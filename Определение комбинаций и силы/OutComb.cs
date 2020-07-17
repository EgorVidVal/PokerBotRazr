using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    class OutComb : SortingSplitting
    {

    public OutComb(int[] map): base(map)
        {
            if(map != null)
            {
                MapConvertor(map);
                ArraySort();
            } 
        }

        public virtual int[] Comb()
        {
            return new int[1];
        }
       
    }
    class SeniorC : OutComb
    {
        public SeniorC(int[] map) : base(map){}
       
        public override int[] Comb()
        {
            MapIntMapString convert = new MapIntMapString();
            int[] outMap = new int[0];
            if (map.Length != 0 && map != null)
            {
                outMap = new int[1] { mapAll[0] };
            }
            return outMap;

        }
    }
    class ParaC : OutComb
    {
        public ParaC(int[] map) : base(map) { }
        public override int[] Comb()
        {
            int[] Pair = new int[0];
            for (int i = 0; i < map.Length - 1; i++)
            {
                if (map[i] == map[i + 1])
                {
                    Pair = new int[2];

                    Pair[0] = mapAll[i];
                    Pair[1] = mapAll[i + 1];
                    return Pair;
                }
                else
                {

                }
            }
            return Pair;
        }
    }
    class TwoParaC : OutComb
    {
        public TwoParaC(int[] map) : base(map) { }
        public override int[] Comb()
        {
            int count = 0;
            int[] pair = new int[0];

            List<int> buffer = new List<int> { };

            for (int i = 0; i < map.Length - 1; i++)
            {
                if (map[i] == map[i + 1])
                {
                    buffer.Add(mapAll[i]);
                    buffer.Add(mapAll[i + 1]);
                    count++;
                    i++;
                }
                if (count == 2)
                {
                    pair = new int[4];
                    for (int x = 0; x < 4; x++) { pair[x] = buffer[x]; }
                    return pair;
                }
            }
            return pair;
        }
    }
    class ThreeC : OutComb
    {
        public ThreeC(int[] map) : base(map) { }
        public override int[] Comb()
        {
            int[] Pair = new int[0];
            List<int> buffer = new List<int> { };

            for (int i = 0; i < map.Length - 2; i++)
            {
                if (map[i] == map[i + 1] && map[i + 1] == map[i + 2])
                {
                    Pair = new int[3];

                    Pair[0] = mapAll[i];
                    Pair[1] = mapAll[i + 1];
                    Pair[2] = mapAll[i + 2];

                    return Pair;
                }
            }
            return Pair;
        }
    }
    class StreetC : OutComb
    {
        public StreetC(int[] map) : base(map) { }
        public override int[] Comb()
        {
            int[] mas = new int[5] { 10, 11, 12, 13, 14 };

            List<int> buffer;

            int[] outComb = new int[0];

            int MaxCount = 0;
            int count = 0;

            for (int c = 0; c < 10; c++)
            {
                count = 0;
                buffer = new List<int> { };
                for (int z = 0; z < 5; z++)
                {
                    for (int i = 0; i < map.Length; i++)
                    {
                        if (map[i] == mas[z])
                        {
                            buffer.Add(mapAll[i]);
                            count++;
                            break;
                        }
                    }
                    if (MaxCount < count)
                    {
                        MaxCount = count;
                        outComb = new int[count];

                        for (int i = 0; i < outComb.Length; i++) { outComb[i] = buffer[i]; }
                        if (count == 5) { z = 5; return outComb; }
                    }
                }
                for (int i = 0; i < mas.Length; i++)
                {
                    if (c == 8)
                    {
                        mas = new int[5] { 19, 20, 21, 22, 10 };
                        break;
                    }
                    else
                    {
                        mas[i] = mas[i] + 1;
                    }
                }
            }
            return outComb;
        }
    }
    class FlashC : OutComb
    {
        public FlashC(int[] AllMap) : base(AllMap) { }
        public override int[] Comb()
        {
            int count;
            int[] OutMap = new int[0];

            int bufferCount = 0;
            List<int> buffer;

            for (int i = 1; i < 5; i++)
            {
                count = 0;
                buffer = new List<int> { };

                for (int c = 0; c < suit.Length; c++)
                {
                    if (suit[c] == i)
                    {
                        buffer.Add(mapAll[c]);
                        count++;
                    }
                }
                if (bufferCount < count)
                {
                    bufferCount = count;
                    OutMap = new int[count];
                    for (int x = 0; x < count; x++) { OutMap[x] = buffer[x]; }
                }
                if (bufferCount == count)
                {
                    if (OutMap.Length != 0)
                    {
                        for (int x = 0; x < suit.Length; x++)
                        {
                            if (suit[x] == OutMap[0]) { break; }
                            if (suit[x] == buffer[0])
                            {
                                bufferCount = count;
                                OutMap = new int[count];
                                for (int b = 0; b < count; b++) { OutMap[b] = buffer[b]; }
                            }
                        }
                    }
                }
            }
            return OutMap;
        }
    }
    class Full_HouseC : OutComb
    {
        public Full_HouseC(int[] map) : base(map) { }
      
        public override int[] Comb()
        {
          
            int[] three = new ThreeC(mapAll).Comb();
           
            int[] outMap = new int[0];
            if (three.Length  == 3)
            {
                for (int i = 0; i < map.Length - 1; i++)
                {
                    if (map[i] == map[i + 1] && three[0] != map[i])
                    {
                        outMap = new int[5];
                        for (int x = 0; x < 3 - 1; x++) { outMap[x] = three[x]; }
                        outMap[3] = mapAll[i];
                        outMap[4] = mapAll[i + 1];
                        return three;
                    }
                }
            }
            return three;
        }
    }
    class KareC : OutComb
    {
        public KareC(int[] map) : base(map) { }

        public override int[] Comb()
        {        
            int[] Pair = new int[0];
            List<int> buffer = new List<int> { };

            for (int i = 0; i < map.Length - 3; i++)
            {
                if (map[i] == map[i + 1] && map[i + 1] == map[i + 2] && map[i + 2] == map[i + 3])
                {
                    Pair = new int[4];

                    Pair[0] = mapAll[i];
                    Pair[1] = mapAll[i + 1];
                    Pair[2] = mapAll[i + 2];
                    Pair[3] = mapAll[i + 3];

                    return Pair;
                }
            }
            return Pair;
        }
    }
    class StrinFlashC : OutComb
    {
        public StrinFlashC(int[] map) : base(map) { }

        public override int[] Comb()
        {

            int[] flash = new FlashC(mapAll).Comb();
            int[] street = new StreetC(mapAll).Comb();
            
            if (flash.Length == 5 && street.Length == 5)
            {
                int count = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (flash[i] == street[i])
                    {
                        count++;
                    }
                    if (count == 5)
                    {
                        return street;
                    }
                }
            }

            return new int[0];
        }

    }
   
}
