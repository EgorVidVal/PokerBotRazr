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
        
        bool firstRate = false;
        bool oneHodFirst = true;

        //Делает первоначальную ставку на префлопе
        public void FirstPart(ref int oneGamer, ref int twoGamer, ref int oneGamerRate, ref int twoGamerRate, ref int bankOne,ref int bankTwo)
        {
            oneGamerRate = 5;
            bankOne -= 5;

            twoGamerRate = 10;
            bankTwo -= 10;
            twoGamer = 3;

            firstRate = true;
            oneHodFirst = false;
        }
        //Для того чтобы небыло конфликтов на первоначальной ставке
        public void FirstPartEnd()
        {
            if (firstRate == true && count == 0 &&  HodGamer != 0)
            {
                BotHod = 0;
                firstRate = false;
            }
        }

        public void HodGame(Count count)
        {  
            while(true)
            {
                Thread.Sleep(500);
                switch (count)
                {
                    case Count.Preflop:
                        //В зависимости от того, кто ходит назначает первоначальную ставку
                        if (Who == 0 && oneHodFirst == true) FirstPart(ref HodGamer,ref BotHod, ref RateGamer, ref RateBot, ref BankGamer, ref bankBot);
                        if (Who == 1 && oneHodFirst == true) FirstPart(ref BotHod, ref HodGamer, ref RateBot, ref RateGamer, ref bankBot, ref BankGamer);
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
        
        public void GameStart()
        {
            
            if (Who == (int)WhoGoes.gamer)
            {
              
               
                GameRes(ref HodGamer, ref BotHod,ref powerGamer,ref powerBot);
                
             
            }
            else if (Who == (int)WhoGoes.bot)
            {

                GameRes(ref BotHod, ref HodGamer, ref powerBot, ref powerGamer);
            }
        }

        //Ход игры
        public void GameRes(ref int gamerOne,ref int gamerTwo, ref int powerGamerOne ,ref int powerGamerTwo)
        {
            while (true)
            {
                
                Thread.Sleep(200);
                //Чтобы первоначальная ставка прошла без лагов
                
                FirstPartEnd();

                if (GameWho == 0 && gamerOne != 0)
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
