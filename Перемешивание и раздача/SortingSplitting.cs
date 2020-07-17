using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    //Разделяет карты отдельно на масти и ранги 
    class SortingSplitting
    {
        public SortingSplitting(int[] allmap)
        {
            mapAll = allmap;
        }

        //Карты
        public  int[] map;
        //Масти
        public  int[] suit;
        //Карты и масти
        public  int[] mapAll;
        
        //Разделяет на масти и карты
        public void MapConvertor(int[] Map)
        {
            //Копирует массив а не передает.
            mapAll = new int[Map.Length];
            for (int i = 0; i < Map.Length; i++) { mapAll[i] = Map[i]; }
           
            map = new int[Map.Length];
            suit = new int[Map.Length];

            for (int i = 0; i < Map.Length; i++)
            {
                string x = Map[i].ToString();
                map[i] = Convert.ToInt32(x[0].ToString() + x[1].ToString());
                suit[i] = Convert.ToInt32(x[2].ToString());
            }
        }
        //Сортирует сразу 3 массива, чтобы они были зеркальные
        public  void ArraySort()
        {
            int temp;
            int tempS;
            int tempAl;

            for (int i = 0; i < map.Length - 1; i++)
            {
                for (int j = i + 1; j < map.Length; j++)
                {
                    if (map[i] > map[j])
                    {
                        temp = map[i];
                        tempS = suit[i];
                        tempAl = mapAll[i];

                        map[i] = map[j];
                        suit[i] = suit[j];
                        mapAll[i] = mapAll[j];

                        map[j] = temp;
                        suit[j] = tempS;
                        mapAll[j] = tempAl;
                    }
                }
            }
        }
    }
}
