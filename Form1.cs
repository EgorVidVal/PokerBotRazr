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

        MapIntMapString convert = new MapIntMapString();

        Hod hod = new Hod();

        public Form1() => InitializeComponent();

        private void Rise_Click(object sender, EventArgs e)
        {
            if(hod.Who == (int)WhoGoes.gamer)
            {
                if ((int)RateHod.Value > hod.RateBot)
                {
                    hod.HodGamer = 3;
                    hod.BankGamer = hod.BankGamer - (int)RateHod.Value;
                    hod.RateGamer = (int)RateHod.Value;
                    WindowsEvent.Text += $"Рейз игрок {hod.RateGamer}";
                }
                else
                    WindowsEvent.Text += $"Ставка должна быть больше \n";
            }
            else WindowsEvent.Text += "Сейчас ходит бот \n";



        }
        private void Check_Click(object sender, EventArgs e)
        {
            if (hod.Who == (int)WhoGoes.gamer)
            {
                hod.HodGamer = 2;
                if (Check.Text == $"Koll {hod.RateBot}")
                {
                    hod.BankGamer -= hod.RateBot;
                    hod.RateGamer = hod.RateBot;
                } 
            }
            else WindowsEvent.Text += "Сейчас ходит бот \n";

        }

        private void Fold_Click(object sender, EventArgs e)
        {
            if (hod.Who == (int)WhoGoes.gamer)
            {
                hod.HodGamer = 1;
            }
            else WindowsEvent.Text += "Сейчас ходит бот \n";

        }

        private void Start_Click(object sender, EventArgs e)
        {
            hod.FactorialAsync((Count)hod.count);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPerenmen();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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
        public void GamerVisualUpdate()
        {
            BankGamer.Text = hod.BankGamer.ToString();
           
            if (hod.BotHod == 3)
            {
                Check.Text = $"Koll {hod.RateBot}";
                RateHod.Minimum = hod.RateBot;
            }                        
            else
                Check.Text = "Check";
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

            if (hod.Who == (int)WhoGoes.bot) VisualWhoGo.Text = "Ходит бот"; else VisualWhoGo.Text = "Ходит Игрок";
        }

        private void Botrise_Click(object sender, EventArgs e)
        {
            hod.BotHod = 3;
            hod.bankBot = hod.bankBot - (int)RateVisualBot.Value;
            hod.RateBot = (int)RateVisualBot.Value;
        }

        private void Botcheck_Click(object sender, EventArgs e)
        {
            hod.BotHod = 2;
            if (Botcheck.Text == $"Koll {hod.RateGamer}")
            {
                hod.bankBot -= hod.RateGamer;
                hod.RateBot = hod.RateGamer;
            }
        }

        private void Botfold_Click(object sender, EventArgs e)
        {
            hod.BotHod = 1;
        }

        private void RateVisualBot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void VisualBankBot_TextChanged(object sender, EventArgs e)
        {

        }

        private void WindowsEvent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
