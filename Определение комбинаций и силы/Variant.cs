using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    class Variant
    {
        private int[] Senior { get; set; }
        private int[] Para { get; set; }
        private int[] TwoPara { get; set; }
        private int[] Three { get; set; }
        private int[] Street { get; set; }
        private int[] Flash { get; set; }
        private int[] Fullhouse { get; set; }
        private int[] Kare { get; set; }
        private int[] Streetflash { get; set; }

        private float Count { get; set; }
        private float Map { get; set; }

        public float[] Ready { get; set; } = new float[9]; 

        public Variant(int[] senior, int[] para, int[] twopara, int[] three,
                                int[] street, int[] flash, int[] fullhouse, int[] kare, int[] streetflash,int count)
        {

            Para = para;
            TwoPara = twopara;
            Three = three;
            Street = street;
            Flash = flash;
            Fullhouse = fullhouse;
            Kare = kare;
            Streetflash = streetflash;

            switch (count)
            {
                case 0:
                    Count = 5;
                    Map = 48;
                    break;
                case 1:
                    Count = 2;
                    Map = 45;
                    break;
                case 2:
                    Count = 1;
                    Map = 44;
                    break;
            }
        }
        public float[] Start()
        {
            ParaVar();
            TwoParaVar();

            return Ready;
        }
        private void ParaVar()
        {
            if (Para != null&&Para.Length == 2)
            {
               
                Ready[0] = 100;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Ready[0] += (3 / Map) * 100;
                }
            }
        }
        private void TwoParaVar()
        {
            if (TwoPara != null && TwoPara.Length == 4)
            {
                Ready[1] = 100;
            }
            else
            {
                if(TwoPara != null && TwoPara.Length == 2)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        Ready[1] += (3 / Map) * 100;
                    }
                }
                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        Ready[1] += (3 / Map) * 100;
                    }
                }
               
            }
        }
           

    }
}
