using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PokerTest
{
    class PowerMap
    {
        public int[] SeniorComb { get; set; }
        public string NameCombSenior { get; set; }

        //Оценивает силу руки
        public int Power(int[] senior, int[] para, int[] twopara,int[] three,
                                int[] street, int[] flash, int[] fullhouse, int[] kare, int[] streetflash)
        {
            if (streetflash.Length == 5) { NameCombSenior = "Стрит флеш"; return 100 + Result(streetflash); }
            else{if (kare.Length == 4) { NameCombSenior = "Каре"; return 150 + Result(kare); }
                else{if(fullhouse.Length == 5) { NameCombSenior = "Фулхаус"; return 200 + Result(fullhouse); }
                    else{if (flash.Length == 5) { NameCombSenior = "Флеш"; return 250 + Result(flash); }
                        else{if (street.Length == 5) { NameCombSenior = "Стрит"; return 300 + Result(street); }
                            else{if(three.Length == 3) { NameCombSenior = "Тройка"; return 350 + Result(three); }
                                else{if (twopara.Length == 4) { NameCombSenior = "Две пары"; return 400 + Result(twopara); }//Вторая пара не учтитывается добавить
                                    else{if(para.Length == 2) { NameCombSenior = "Пара"; return 450 + Result(para); }
                                        else{if(senior.Length == 1) { NameCombSenior = "Старшая"; return 500 + Result(senior); }}
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        //Определяет на сколько сильная комбинация из возможных таки же коибинаций
        public int Result(int[] map)
        {

            if (map != null)
            {
                SortingSplitting sort = new SortingSplitting(map);
                SeniorCombMap(map);
                if (map.Length != 0)
                {
                    sort.MapConvertor(map);
                    return sort.map[0];
                }
            }
            return 0;
        }

        public void SeniorCombMap(int[] map)
        {
            
            SeniorComb = map;
        }

    }
}
