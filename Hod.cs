using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerTest
{
    class Hod
    {
        public int Who,bankBot=1000,BankGamer = 1000,RateBot,RateGamer,allRate,BotHod,HodGamer,count = 0;
        public int GameWho = 0;
        public int powerBot, powerGamer = 0;
        public int[] mapBot = new int[0];
        public int[] mapGamer = new int[0];
        public int[] mapTable = new int[0];

        public async void FactorialAsync(Count count)
        {
            await Task.Run(() => HodGame(count));                  
        }

        public void HodGame(Count count)
        {  
            while(true)
            {
                Thread.Sleep(500);
                switch (count)
                {
                    case Count.Preflop:
                        GameStart();
                        break;
                    case Count.Flop:
                        GameStart();
                        break;
                    case Count.Tern:
                        GameStart();
                        break;
                    case Count.River:
                        GameStart();
                        break;
                }
            }
        }
        //Для первой ставки
        bool firstRate = true;

        public void GameStart()
        {
            
            if (Who == (int)WhoGoes.gamer)
            {
                if (firstRate == true && count == 0)
                {
                    //Who = (int)WhoGoes.bot;
                    BankGamer -= 5;
                    bankBot -= 10;
                    
                    RateBot = 10;
                    RateGamer = 5;
                    
                    BotHod = 3;
                    firstRate = false;
                }
                GameRes(ref HodGamer, ref BotHod,ref powerGamer,ref powerBot);
                
             
            }
            else if (Who == (int)WhoGoes.bot)
            {
                if (firstRate == true && count == 0)
                {
                    //Who = (int)WhoGoes.gamer;
                    BankGamer -= 10;
                    bankBot -= 5;

                    RateBot = 5;
                    RateGamer = 10;
                    firstRate = false;
                    HodGamer = 3;
                }
                GameRes(ref BotHod, ref HodGamer, ref powerBot, ref powerGamer);
        
            }
        }

        //Ход игры
        public void GameRes(ref int gamerOne,ref int gamerTwo, ref int powerGamerOne ,ref int powerGamerTwo)
        {
            while (true)
            {
                Thread.Sleep(200);
                if(GameWho == 0 && gamerOne != 0)
                {
                    if (gamerOne == 1)
                    {
                        powerGamerOne = 0;
                        count = 4;
                        gamerOne = 0; gamerTwo = 0;
                        allRate += RateBot + RateGamer;
                        break;
                    }
                }
                if(GameWho == 1 && gamerTwo != 0)
                {
                    if (gamerTwo == 1)
                    {
                        powerGamerTwo = 0;
                        count = 4;
                        gamerOne = 0; gamerTwo = 0;
                        allRate += RateBot + RateGamer;
                        break;
                    }
                }
                if(gamerOne != 0 && gamerTwo != 0)
                {
                    //Проверяем продожитсья ли игра после решения.
                    bool checking = GameHod(ref gamerOne, ref gamerTwo);

                    //Если условия верны для продолжение игры
                    if (checking == true)
                    {
    
                        //Складываем все ставки и добавляем в общие
                        //преходим на следующий шаг
                        if (Who == 1) Who = 0; else Who = 1;
                        gamerOne = 0; gamerTwo = 0;
                        count++;
                        GameWho = Who;
                        allRate += RateBot + RateGamer;
                        RateGamer = 0;
                        RateBot = 0;

                        break;
                    }
                    else
                    {
                        gamerOne = 0;
                        if (Who == (int)WhoGoes.bot) Who = (int)WhoGoes.gamer; else Who = (int)WhoGoes.bot;
                        //Если условия не удволетворяют для продолжение игры то, мы меняем
                        GameStart();
                    }

                }
                powerBot = new ReadyPower(mapBot.Concat(mapTable).ToArray()).CombPower();
                powerGamer = new ReadyPower(mapGamer.Concat(mapTable).ToArray()).CombPower();
              

                //if (gamerOne != 0)
                //{
                //    if(gamerOne == 1)
                //    {
                //        powerGamerOne = 0;
                //        count = 4;
                //        gamerOne = 0; gamerTwo = 0;
                //        allRate += RateBot + RateGamer;
                //        break;
                //    }


                //    if (Who == (int)WhoGoes.gamer)
                //    {
                //        //gamerTwo = b.BotStart(HodGamer);
                //    }
                //    if (gamerTwo != 0)
                //    {
                //        if (gamerTwo == 1)
                //        {
                //            powerGamerTwo = 0;
                //            count = 4;
                //            gamerOne = 0; gamerTwo = 0;
                //            allRate += RateBot + RateGamer;
                //            break;
                //        }

                //        //Проверяем продожитсья ли игра после решения.
                //        bool checking = GameHod(ref gamerOne,ref gamerTwo);

                //        //Если условия верны для продолжение игры
                //        if (checking == true)
                //        {
                //            Console.WriteLine("Все ок получилось");

                //            //Складываем все ставки и добавляем в общие
                //            //преходим на следующий шаг
                //            if (Who == 1) Who = 0; else Who = 1;
                //            gamerOne = 0; gamerTwo = 0;
                //            count++;

                //            allRate += RateBot + RateGamer;
                //            RateGamer = 0;
                //            RateBot = 0;

                //            break;
                //        }
                //        else
                //        {
                //            Console.WriteLine("Не получилось");
                //            gamerOne = 0;
                //            if (Who == (int)WhoGoes.bot) Who = (int)WhoGoes.gamer; else Who = (int)WhoGoes.bot;
                //            //Если условия не удволетворяют для продолжение игры то, мы меняем
                //            GameStart();
                //        }
                //    }
                //}


            }
        }

        
        //Ход игры, можно ли продолжать.
        public bool GameHod(ref int gamerOne,ref int gamerTwo)
        {

            if (gamerOne == (int)Dey.CheckKoll && gamerTwo == (int)Dey.CheckKoll)
            {
                return true;
            }
            if (gamerOne == (int)Dey.CheckKoll && gamerTwo == (int)Dey.Rise)
            {
                return false;
            }
            if (gamerOne == (int)Dey.Rise && gamerTwo == (int)Dey.Rise)
            {
                return false;
            }
            if (gamerOne == (int)Dey.Rise && gamerTwo == (int)Dey.CheckKoll)
            {
                return true;
            }
            if (gamerOne == (int)Dey.CheckKoll && gamerTwo == (int)Dey.Rise)
            {
                return true;
            }
            return false;
        }
        
        public string EndGame(int Bot,int Gamer)
        {
            firstRate = true;
            if (count == 4)
            {
                

                if (Bot > Gamer)
                {
                    bankBot += allRate;
                    return "Выиграл бот";
                }
                else if (Bot == Gamer)
                {
                    bankBot += allRate / 2;
                    BankGamer += allRate / 2;
                    return "Ничья";
                }
                else
                {
                    BankGamer += allRate;
                    return "Выиграл игрок";
                }


            }
            return "";
           
        }
    }

    enum Dey
    {
        Fold = 1,
        CheckKoll,
        Rise,
    }

    enum Count
    {
        Preflop,
        Flop,
        Tern,
        River
    }
    enum WhoGoes
    {
        gamer,
        bot
    }
    
}
