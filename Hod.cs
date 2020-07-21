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

        public void GameStart()
        {
            if (Who == (int)WhoGoes.gamer)
            {
                Console.WriteLine("Ходит игрок");
                GameRes(ref HodGamer, ref BotHod);
            }
            else if (Who == (int)WhoGoes.bot)
            {
                Console.WriteLine("Ходит Бот");
                //Bot b = new Bot();

                //BotHod = b.BotStart(HodGamer);
                GameRes(ref BotHod, ref HodGamer);
            }
        }
        Bot b = new Bot();
        //Ход игры
        public void GameRes(ref int gamerOne,ref int gamerTwo)
        {
            while (true)
            {
                Thread.Sleep(2000);
                //Ожидание действие игрока
                Console.WriteLine("Ходит первый {0}", gamerOne);
                Console.WriteLine("Ходит второй {0}", gamerTwo);
                if (Who == (int)WhoGoes.bot && gamerOne == 0)
                {
                    //gamerOne = b.BotStart(HodGamer);
                }

                if (gamerOne != 0)
                {
                    if (Who == (int)WhoGoes.gamer)
                    {
                        //gamerTwo = b.BotStart(HodGamer);
                    }
                    
                    if (gamerTwo != 0)
                    {
                        //Проверяем продожитсья ли игра после решения.
                        bool checking = GameHod(ref gamerOne,ref gamerTwo);

                        if (checking == true)
                        {
                            Console.WriteLine("Все ок получилось");
                            //Складываем все ставки и добавляем в общие
                            //преходим на флоп
                            if (Who == 1) Who = 0; else Who = 1;
                            gamerOne = 0; gamerTwo = 0;
                            count++;

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
                }
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
