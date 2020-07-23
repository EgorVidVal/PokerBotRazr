using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerTest
{
    public partial class Form1 : Form
    {
        //Класс с перемещанной колодой
        static RandomMap rMap = new RandomMap();
        //Класс в который помещаем перемешанную колоду и извлекаем карты по ходу игры
        MapHandTable handTable = new MapHandTable(rMap.ReadyMapForGame());
        //Конвертирует карты в числах в понятный текстовый
        MapIntMapString convert = new MapIntMapString();
        //Ход игры
        Hod hod = new Hod();

        int GameWho = 0;
        

        public Form1() => InitializeComponent();

        private void Rise_Click(object sender, EventArgs e)
        {
            if ((int)RateHod.Value > hod.RateBot)
            {
                GameWho = 1;
                hod.HodGamer = 3;
                hod.BankGamer = hod.BankGamer - (int)RateHod.Value;
                hod.RateGamer = (int)RateHod.Value;
                WindowsEvent.Text += $"Рейз игрок {hod.RateGamer}";
            }
            else
                WindowsEvent.Text += $"Ставка должна быть больше \n";

        }
        private void Check_Click(object sender, EventArgs e)
        {
           
            hod.HodGamer = 2;
            GameWho = 1;
            if (Check.Text == $"Koll {hod.RateBot}")
            {
                hod.BankGamer -= hod.RateBot - hod.RateGamer;
                hod.RateGamer = hod.RateBot;
            }
        }

        private void Fold_Click(object sender, EventArgs e)
        {
            GameWho = 1;
            hod.HodGamer = 1;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            hod.FactorialAsync((Count)hod.count);
            if (hod.Who == 0) GameWho = 0;
            else GameWho = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPerenmen();
        }

        public async void StartPerenmen()
        {
            await Task.Run(() => Visual());
        }
        public void Visual()
        {
            while(true)
            {
                this.Invoke(new Action(GamerVisualUpdate));
                this.Invoke(new Action(BotVisualUpdate));
                Thread.Sleep(500);  
            }
            
        }
        //Обновление в реальном времени на столе.
        public void GamerVisualUpdate()
        {
            //По оконачанию игры
            if (hod.count == 4)
            {
                //Обновляем карты
                rMap = new RandomMap();
                handTable = new MapHandTable(rMap.ReadyMapForGame());

                WindowsEvent.Text = hod.EndGame(hod.powerBot, hod.powerGamer);


                hod.count = 0;
            }

            //Добавляет карты в массивы класса
            hod.mapTable = handTable.TableMap(hod.count);
            hod.mapBot = handTable.PlayerMap(hod.count, 2);
            hod.mapGamer = handTable.PlayerMap(hod.count);

            //Показывает банк игрока
            BankGamer.Text = hod.BankGamer.ToString();
           
            //Меняет кнопку чек на кнопку колл
            if (hod.BotHod == 3)
            {
                Check.Text = $"Koll {hod.RateBot}";
                RateHod.Minimum = hod.RateBot;
            }                        
            else
                Check.Text = "Check";
            
            //Массивы для визуализации.
            RichTextBox[] tableMap = { Flop1, Flop2, Flop3, Tern, River };
            RichTextBox[] mapGamerObj = { HandGamer1, HandGamer2 };
            RichTextBox[] mapBotObj = { HandBot1, HandBot2 };

            //Выводин карты в реальном вермени
            //Карты стола
            MapTableAndHand(tableMap, convert.ConvertTextArray(hod.mapTable));
            //Карты игрока
            MapTableAndHand(mapGamerObj, convert.ConvertTextArray(hod.mapGamer));
            //Карты бота
            MapTableAndHand(mapBotObj, convert.ConvertTextArray(hod.mapBot));
            //Старшая комбинация рук игрока
            Power();
            //Визуализция сил бота и игрока
            PowerBotLabel.Text = hod.powerBot.ToString();
            PowerGamerLabel.Text = hod.powerGamer.ToString();
            
        }
        public void Power()
        {
            ReadyPower power = new ReadyPower(handTable.TableMap(hod.count).Concat(handTable.PlayerMap(hod.count)).ToArray());
            SeniorMap.Text = power.CombName() + " " +string.Join(" ", convert.ConvertTextArray(power.CombSenior()));
            SeniorMap.ForeColor = Color.Red;
        }
        //Визуализирует массив куда надо
        private void MapTableAndHand(RichTextBox[] VisualMap,string[] ReadyMap)
        {
      
            if (ReadyMap.Length != 0) 
                for (int i = 0; i < ReadyMap.Length; i++) VisualMap[i].Text = ReadyMap[i];
            else 
                for (int i = 0; i < VisualMap.Length; i++) VisualMap[i].Text = "";
        }

        public void BotVisualUpdate()
        {
            
            VisualBankBot.Text = hod.bankBot.ToString();
           
            if (hod.HodGamer == 3)
            {
                Botcheck.Text = $"Koll {hod.RateGamer}";
                RateVisualBot.Minimum = hod.RateGamer;
            }     
            else
                Botcheck.Text = "Check";

            if (GameWho == 1) VisualWhoGo.Text = "Ходит бот"; else VisualWhoGo.Text = "Ходит Игрок";
        }

        private void Botrise_Click(object sender, EventArgs e)
        {
            GameWho = 0;
            hod.BotHod = 3;
            hod.bankBot = hod.bankBot - (int)RateVisualBot.Value;
            hod.RateBot = (int)RateVisualBot.Value;
        }

        private void Botcheck_Click(object sender, EventArgs e)
        {
            GameWho = 0;
            hod.BotHod = 2;
            if (Botcheck.Text == $"Koll {hod.RateGamer}")
            {
                hod.bankBot -= hod.RateGamer;
                hod.RateBot = hod.RateGamer;
            }
        }

        private void Botfold_Click(object sender, EventArgs e)
        {
            GameWho = 0;
            hod.BotHod = 1;
        }

        private void HandGamer1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
