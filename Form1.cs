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
            hod.HodGamer = 3;
            hod.BankGamer = hod.BankGamer - (int)RateHod.Value;
        }

        private void Check_Click(object sender, EventArgs e)
        {
            hod.HodGamer = 2;
        }

        private void Fold_Click(object sender, EventArgs e)
        {
            hod.HodGamer = 1;
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
                this.Invoke(new Action(Test));
                Thread.Sleep(500);  
            }
            
        }
        public void Test()
        {
            BankGamer.Text = hod.BankGamer.ToString();
            VisualBankBot.Text = hod.bankBot.ToString();
        }

        private void Botrise_Click(object sender, EventArgs e)
        {
            hod.BotHod = 3;
            hod.bankBot = hod.bankBot - (int)RateVisualBot.Value;
        }

        private void Botcheck_Click(object sender, EventArgs e)
        {
            hod.BotHod = 2;
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
    }
}
