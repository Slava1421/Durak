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

namespace DurakGame
{
    public partial class Form1 : Form
    {
        Game gam;
        public Form1()
        {
            gam = new Game();
            gam.frm = this;
            gam.RunClearListCancelHod += StatusButtonCancel;
            gam.GameMessage += MessBot;
            InitializeComponent();
            DoubleBuffered = true;
        }
        private void MessBot(string mes, GameMes lab,Bitmap b=null)
        {
            switch (lab)
            {
                case GameMes.MessageBot:
                    MessageBot.Text = mes;
                    break;
                case GameMes.StatusHod:
                    StatusHod.Text = mes;
                    break;                
            }
            if (b != null)
                pictureBox2.BackgroundImage = b;
        }
        private void StatusButtonCancel(bool flag, ButtonsEnable but)
        {
            switch (but)
            {
                case ButtonsEnable.Cancel:
                    CancelButton.Enabled = flag;
                    break;
                case ButtonsEnable.AddKards:
                    KardsAdd.Enabled = flag;
                    break;
                case ButtonsEnable.Zabraat:
                    Zabrat.Enabled = flag;
                    break;
                case ButtonsEnable.Otboy:
                    Otboy.Enabled = flag;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gam.BotPlay();
            // button1.Enabled = false;

            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)    //перерисовка формы 
        {
            base.OnPaint(e);
            gam.Show(e.Graphics);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            while (!stopThread)
            {
                await Mygalk();
                pictureBox1.Location = new Point(21, strY);
            }
        }
        public async Task Mygalk()
        {
            await Task.Run(() =>
            {
                if (strY < 40 && !fff)
                {
                    Thread.Sleep(10);
                    strY++;
                }
                else
                    fff = true;
                if (strY >= 25 && fff)
                {
                    Thread.Sleep(10);
                    strY--;
                }
                else
                    fff = false;

            });
        }
        int strY = 25;
        bool flag = true, flag1=false, fff = false, stopThread = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (gam.ClickKoloda(e.X, e.Y) && flag == true)
                {
                    stopThread = true;
                    pictureBox1.Visible = false;
                    //pictureBox2.Visible = true;
                    //pictureBox3.Visible = true;
                    MessageBot.Visible = true;
                    gam.CreateGamer();

                    if (gam.ReturnStatusBot() == StatusGamer.Hod)
                        gam.BotPlay();
                    flag = false;
                }
                else if (gam.IsCaptured(e.X, e.Y))
                {
                    flag1 = true;
                }
                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (flag1 == true)
            {
                if (gam.ReturnStatusGamer() == StatusGamer.Hod)
                {
                    if (!gam.AddKardHod(e.X, e.Y))
                    {
                        gam.ComeBack();
                    }
                }
                else if (gam.ReturnStatusGamer() == StatusGamer.Otbit)
                {
                    if (!gam.AddKardBoy(e.X, e.Y))
                    {
                        gam.ComeBack();
                    }
                }
                flag1 = false;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            gam.Cancel();
            this.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gam.ZabratPlayer();
            this.Invalidate();
        }

        private void Otboy_Click(object sender, EventArgs e)
        {
            gam.OtboyCreate(true);
            //this.Invalidate();
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            gam.PlaceKursorOnKardGamer(e.X, e.Y);
            if (flag1 == true)
            {
                gam.CardMove(e.X,e.Y);
            }
            //this.Invalidate();
        }
    }
}
