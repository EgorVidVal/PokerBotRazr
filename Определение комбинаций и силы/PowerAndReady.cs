using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    //Определяет силу комбинаций(для бота) и старшую комбинацию(Для визуализации) 
    class ReadyPower 
    {
        static int[] Map { get; set; }

        static int[] Senior { get; set; }
        static int[] Para { get; set; }
        static int[] TwoPara { get; set; } 
        static int[] Three { get; set; } 
        static int[] Street { get; set; } 
        static int[] Flash { get; set; } 
        static int[] Full_House { get; set; }
        static int[] Kare { get; set; } 
        static int[] StrinFlash { get; set; } 

        public ReadyPower(int[] map)
        {
            
            Map = map;

            Senior = new SeniorC(Map).Comb();
            Para = new ParaC(Map).Comb();
            TwoPara = new TwoParaC(Map).Comb();
            Three = new ThreeC(Map).Comb();
            Street = new StreetC(Map).Comb();
            Flash = new FlashC(Map).Comb();
            Full_House = new Full_HouseC(Map).Comb();
            Kare  = new KareC(Map).Comb();
            StrinFlash  = new StrinFlashC(Map).Comb();

            
        }

        public int CombPower()
        {
            PowerMap power = new PowerMap();
            return power.Power(Senior, Para, TwoPara,
            Three, Street, Flash, Full_House, Kare, StrinFlash);

        }
        public int[] CombSenior()
        {
            PowerMap power = new PowerMap();
            power.Power(Senior, Para, TwoPara,
            Three, Street, Flash, Full_House, Kare, StrinFlash);

            return power.SeniorComb;
        }
        public string CombName()
        {
            PowerMap power = new PowerMap();
            power.Power(Senior, Para, TwoPara,
            Three, Street, Flash, Full_House, Kare, StrinFlash);

            return power.NameCombSenior; 
        }
        public float[] VariantReady(int count)
        {
            Variant variant = new Variant(Senior, Para, TwoPara,
            Three, Street, Flash, Full_House, Kare, StrinFlash,count);
            
            return variant.Start();
        }

    }
}
