using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    class MapIntMapString
    {
        //Конвертирует в текст числовые карты.
        public string ConvertText(int map)
        {
            string x = Convert.ToString(map);

            string mapText = Convert.ToString(x[0]) + Convert.ToString(x[1]);
            string must = Convert.ToString(x[2]);

            string ready = "";

            switch (mapText)
            {
                case "10": ready = "Т"; break;
                case "11": ready = "К"; break;
                case "12": ready = "Д"; break;
                case "13": ready = "В"; break;
                case "14": ready = "10"; break;
                case "15": ready = "9"; break;
                case "16": ready = "8"; break;
                case "17": ready = "7"; break;
                case "18": ready = "6"; break;
                case "19": ready = "5"; break;
                case "20": ready = "4"; break;
                case "21": ready = "3"; break;
                case "22": ready = "2"; break;
            }

            switch (must)
            {
                case "1": ready += "Б"; break;
                case "2": ready += "Ч"; break;
                case "3": ready += "П"; break;
                case "4": ready += "К"; break;

                default:
                    break;
            }
            return ready;
        }
        //Преобразует сразу массив
        public string[] ConvertTextArray(int[] Map)
        {
            string[] MapString = new string[Map.Length];

            for (int i = 0; i < MapString.Length; i++)
                MapString[i] = ConvertText(Map[i]);

            return MapString;
        }
    }
}
