using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakGame
{
    enum ButtonsEnable
    {
        Cancel,
        Zabraat,
        AddKards,
        Otboy
    }
    enum GameMes
    {
        MessageBot,
        StatusHod
    }
    class Game
    {
        private Koloda koloda;
        private Otboy Otboy;        
        
        private KardGamer MoveKard;
        private List<Kard> KardsPodkid { get; set; }
        List<GamerMan> pleayerKard = new List<GamerMan>();
        List<BotGamer> pleayerKardBot = new List<BotGamer>();
        List<KardGamer> Gamers = new List<KardGamer>();
        public Form1 frm;
        private GameField gameField;
        private Brush brush = Brushes.Green;
        bool flag,flagC=true;
        int xKard, yKard,indexKardBoy,koefUpMoveKard=100, dx, dy;
        private History hist;

        public delegate void ClearListCancelHod(bool flag, ButtonsEnable but);
        public event ClearListCancelHod RunClearListCancelHod;
        public delegate void BotMessageDelegate(string mes,GameMes lab,Bitmap f=null);
        public event BotMessageDelegate GameMessage;
        public Game()
        {
            hist = new History();
            koloda = new Koloda {X=20,Y=170 };
            gameField = new GameField { X = 200, Y = 150 };
            KardsPodkid = new List<Kard>();
        }        
        private void Mashtab()//Растоние между картами в стороны
        {
            foreach (KardGamer gam in Gamers)
            {
                if (gam.GetKard().Count > 6)
                {
                    gam.Dist = Constanta.dist - gam.GetKard().Count*2;
                }
                else
                {
                    gam.Dist = 50;
                }
            }
        }        
        public void Show(Graphics g)//прорисовка
        {
            int index=0;
            Mashtab();
            g.FillRectangle(brush, gameField.X, gameField.Y, Constanta.GamFilWidth, Constanta.GamFilHeight);
            if (koloda.GetKard().Count!=0)
            {
                if (koloda.GetKard().Last().Kozir==true)
                    g.DrawImage(koloda.GetKardIndex(koloda.GetKard().Count-1).Img, koloda.X +90, koloda.Y+10);
            }
            for (int j = 0; j < ShowKoloda(koloda.GetKard().Count); j++)
            {
                g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("_36"), koloda.X + (5 * j), koloda.Y + (5 * j));
            }
            if (pleayerKard.Count > 0)
            {
                for (int j = 0; j < pleayerKard.Count; j++)
                {
                    for (int i = 0; i < pleayerKard[j].GetKard().Count; i++)
                    {
                        if (i == koefUpMoveKard)
                            index = 20;
                        else
                            index = 0;
                        g.DrawImage(pleayerKard[j].GetKardIndex(i).Img, pleayerKard[j].X + pleayerKard[j].Dist * i, pleayerKard[j].Y-index);
                    }
                }
            }
            if (pleayerKardBot.Count > 0)
            {
                for (int j = 0; j < pleayerKardBot.Count; j++)
                {
                    for (int i = 0; i < pleayerKardBot[j].GetKard().Count; i++)                        
                        g.DrawImage(pleayerKardBot[j].GetKardIndex(i).Img, pleayerKardBot[j].X + pleayerKardBot[j].Dist * i, pleayerKardBot[j].Y);
                    //g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("_36"), pleayerKardBot[j].X + pleayerKardBot[j].Dist * i, pleayerKardBot[j].Y);
                }
            }
            if (gameField != null)
            {
                if (flag)
                    g.FillRectangle(Brushes.Black, xKard-2, yKard-2, Constanta.CARD_WIDTH+4, Constanta.CARD_HEIGHT+4);
                if (gameField.KardHod.Count > 0)
                {
                    for (int i = 0; i < gameField.KardHod.Count; i++)
                        g.DrawImage(gameField.KardHod[i+1].Img, (gameField.X+50)+i*75, gameField.Y+50);
                }
                if (gameField.KardBoy.Count > 0)
                {                   
                    foreach(var kar in gameField.KardBoy)
                    {
                        g.DrawImage(kar.Value.Img, (gameField.X + 50) + (kar.Key-1) * 75, gameField.Y + 90);
                    }
                }
            }
            if (MoveKard != null)
            {
                for (int i = 0; i < MoveKard.GetKard().Count; i++)
                    g.DrawImage(MoveKard.GetKardIndex(i).Img, MoveKard.X, MoveKard.Y);
            }
            if (Otboy != null)
            {
                for (int j = 0; j < ShowKoloda(Otboy.GetKard().Count); j++)
                {
                    g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("_36"), Otboy.X + (5 * j), Otboy.Y + (5 * j));
                }
            }

        }
        private int ShowKoloda(int countKar)//отображение перевернутых карт колоды
        {
            int k = 0;
            if (countKar > 3)
                k = 3;
            else
                switch (countKar)
                {
                    case 2:
                        k = 1;
                        break;
                    case 3:
                        k = 2;
                        break;
                }
            return k;
            
        }
        public bool ClickKoloda(int x,int y)//проверка клика по колоде
        {
            if (koloda.X + Constanta.CARD_WIDTH >= x && koloda.Y + Constanta.CARD_HEIGHT >= y && koloda.X <= x && koloda.Y<=y)
                return true;
            else
                return false;
        }
        private void AddGamerStart()//создание игроков
        {            
            for (int j = 0; j < Constanta.kolPlayer; j++)
            {
                pleayerKard.Add(new GamerMan()
                {
                    X = 300,
                    Y = 400 + (-370 * j),
                    Dist = Constanta.dist
                });
                AddKardGamer(pleayerKard[j],Constanta.kolKardGamer);
            }
            for (int j = 0; j < Constanta.kolBotPlayer; j++)
            {
                pleayerKardBot.Add(new BotGamer()
                {
                    X = 300,
                    Y = 30,
                    Dist = Constanta.dist
                });
                AddKardGamer(pleayerKardBot[j], Constanta.kolKardGamer);
            }
            Gamers.AddRange(pleayerKard);
            Gamers.AddRange(pleayerKardBot);
            GetKozir();
            GetStatusGamer(); 
        }        
        public void CreateGamer()
        {
            GameMessage("Поехали!", GameMes.MessageBot, (Bitmap)Properties.Resources.ResourceManager.GetObject("BotSmile"));
            AddGamerStart();
            foreach (GamerMan ga in pleayerKard)
                if (ga.statusGamer == StatusGamer.Hod)
                    GameMessage("Ваш ход!",GameMes.StatusHod);
                else
                    GameMessage("Ход противника!", GameMes.StatusHod);            
        }
        public StatusGamer ReturnStatusGamer()
        {
            return pleayerKard[pleayerKard.FindIndex(k => k is KardGamer)].statusGamer;
        }
        public StatusGamer ReturnStatusBot()
        {
            return pleayerKardBot[0].statusGamer;
        }
        private void GetKozir()//определение козырной карты
        {
            Random r=new Random();
            Kard kardKozyr;
            int val;
            val = r.Next(0, koloda.GetKard().Count);
            kardKozyr = koloda.GetKardIndex(val);
            for (int i = 0; i < koloda.GetKard().FindAll(block => block.Mast == kardKozyr.Mast).Count; i++)
                koloda.GetKard().FindAll(block => block.Mast == kardKozyr.Mast)[i].Kozir = true;

            koloda.DelKard(val);
            koloda.AddKard(kardKozyr,true);

            for(int j=0;j< Gamers.Count;j++)
                for (int i = 0; i < Gamers[j].GetKard().FindAll(block => block.Mast == kardKozyr.Mast).Count; i++)
                    Gamers[j].GetKard().FindAll(block => block.Mast == kardKozyr.Mast)[i].Kozir = true;
        }
        public bool IsCaptured(int x,int y)//определение выбраной карты
        {
            MoveKard = new GamerMan();
            if (pleayerKard.Count > 0)
            {
                for (int j = 0; j < Constanta.kolPlayer; j++)
                {
                    if (flagC)
                    {
                        hist.AddCancelPlayerKard(pleayerKard[j], ref flagC);
                    }                    
                    hist.gamerKardsOld = pleayerKard[j].GetKard(); 
                }
                for (int j = 0; j < Constanta.kolPlayer; j++)
                    for (int i = 0; i < pleayerKard[j].GetKard().Count; i++)
                    {
                        if (pleayerKard[j].X + pleayerKard[j].Dist * i <= x
                        && pleayerKard[j].X + pleayerKard[j].Dist * i + pleayerKard[j].Dist >= x
                        && pleayerKard[j].Y + Constanta.CARD_HEIGHT >= y
                        && pleayerKard[j].Y <= y)
                        {
                            MoveKard.AddKard(pleayerKard[j].GetKardIndex(i));
                            MoveKard.X = pleayerKard[j].X + pleayerKard[j].Dist * i;
                            MoveKard.Y = pleayerKard[j].Y;
                            pleayerKard[j].DelKard(i);
                            dx = x - pleayerKard[j].X - pleayerKard[j].Dist * i;                    // расстояние от курсора до левого верхнего угла перемещаемой стопки
                            dy = y - pleayerKard[j].Y;
                            return true;
                        }
                    }

            }
            hist.gamerKardsOld.Clear();
            return false;
        }
        public void PlaceKursorOnKardGamer(int x, int y)//приподнятие карты при наведении
        {
            foreach(KardGamer kar in pleayerKard)
                for (int i = 0; i < kar.GetKard().Count; i++)
                {
                    if (kar.X + kar.Dist * i <= x && kar.X + kar.Dist * i + kar.Dist >= x
                    && kar.Y + Constanta.CARD_HEIGHT >= y && kar.Y <= y)
                    {
                        koefUpMoveKard = i;
                        break;
                    }
                    else
                        koefUpMoveKard = 100;
                }
            frm.Invalidate();
        }
        public void CardMove(int x, int y)  // перемещение карты курсором 
        {
            if (x >= 200 && x <= 200 + Constanta.GamFilWidth
                && y >= 150 && y <= 150 + Constanta.GamFilHeight)
            {
                brush = Brushes.GreenYellow;
            }
            else
                brush = Brushes.Green;

            for(int i = 0; i < gameField.KardHod.Count; i++)
            {
                if (x >= (gameField.X + 50) + i * 75 && x <= (gameField.X + 50) + i * Constanta.CARD_WIDTH + Constanta.CARD_WIDTH
                    && y >= gameField.Y + 50 && y <= gameField.Y + 50 + Constanta.CARD_HEIGHT)
                {
                    xKard = (gameField.X + 50) + i * 75;
                    yKard = gameField.Y + 50;
                    indexKardBoy = i + 1;
                    flag = true;
                    break;
                }
                else
                    flag = false;
            }

            MoveKard.X = x - dx;
            MoveKard.Y = y - dy;
            frm.Invalidate();
        }
        public void ComeBack()//вернуть карту назад игроку, если она не туда помещена
        {
            MoveKard = null;
            for (int j = 0; j < Constanta.kolPlayer; j++)
            {
                pleayerKard[j].DelAllKard();
                pleayerKard[j].AddKard(hist.gamerKardsOld);
            }
            hist.gamerKardsOld.Clear();
            brush = Brushes.Green;
            flag = false;
            frm.Invalidate();
        }
        public bool AddKardHod(int x,int y)//обработка хода игрока
        {
            if (x >= 200 && x <= 200 + Constanta.GamFilWidth
                && y >= 150 && y <= 150 + Constanta.GamFilHeight)
            {
                if (pleayerKard[0].AddKardHod(MoveKard.GetKardIndex(0),gameField.KardHod,gameField.KardBoy)!=null)
                {
                    gameField.AddkardHod(MoveKard.GetKardIndex(0));
                    KardsPodkid.Add(MoveKard.GetKardIndex(0));
                    MoveKard = null;
                    hist.CancelKardIndex.Add(gameField.KardHod.Count);
                    hist.gamerKardsOld.Clear();
                 
                    RunClearListCancelHod(true, ButtonsEnable.Cancel);
                    brush = Brushes.Green;
                    flag = false;
                    RunClearListCancelHod(true, ButtonsEnable.AddKards);
                    frm.Invalidate();
                    return true;
                }
            }
            return false;

        }
        public bool AddKardBoy(int x, int y)//обработка отбивания
        {
            for (int i = 0; i < gameField.KardHod.Count; i++)
            {
                if (x >= (gameField.X + 50) + i * 75 && x <= (gameField.X + 50) + i * Constanta.CARD_WIDTH + Constanta.CARD_WIDTH
                    && y >= gameField.Y + 50 && y <= gameField.Y + 50 + Constanta.CARD_HEIGHT)
                {
                    if (pleayerKard[0].AddKardBoy(MoveKard.GetKardIndex(0), gameField.KardHod, indexKardBoy) != null)
                    {
                        try
                        {
                            KardsPodkid.Add(MoveKard.GetKardIndex(0));
                            gameField.AddkardBoy(MoveKard.GetKardIndex(0), indexKardBoy);
                            hist.CancelKardIndex.Add(indexKardBoy);
                            MoveKard = null;
                            hist.gamerKardsOld.Clear();
                            RunClearListCancelHod(true, ButtonsEnable.Cancel);
                            brush = Brushes.Green;
                            flag = false;
                            RunClearListCancelHod(true, ButtonsEnable.AddKards);
                            frm.Invalidate();
                            return true;
                        }
                        catch (ArgumentException)
                        {
                            KardsPodkid.Clear();
                            return false;
                        }
                    }
                }
            } 
            return false;
        }
        public void GetStatusGamer()//определение кто ходит, кто бьется
        {
            RankKard rank;
            List<Kard> kardMinList = new List<Kard>();
            Random ran = new Random();
            foreach (KardGamer gam in Gamers)
            {
                if (gam.GetKard().FindAll(block1 => block1.Kozir == true).Count>0)
                {
                    rank = gam.GetKard().FindAll(block1 => block1.Kozir == true).Min(k => k.Rank);
                    kardMinList.Add(gam.GetKard().FirstOrDefault(k => k.Rank == rank));
                }
            }
            if (kardMinList.Count > 0)
            {
                foreach (KardGamer gam in Gamers)//
                {
                    if (gam.GetKard().FirstOrDefault(k => k.Rank == kardMinList.Min(h => h.Rank) && k.Kozir == true) != null)
                    {
                        gam.statusGamer = StatusGamer.Hod;
                    }
                }
            }
            else
            {
                Gamers[ran.Next(0, Gamers.Count)].statusGamer = StatusGamer.Hod;
            }

            int indexPlayerHod = Gamers.FindIndex(k => k.statusGamer == StatusGamer.Hod);

            if (Gamers.Count == 2)
                if (indexPlayerHod == 0)
                    Gamers[indexPlayerHod + 1].statusGamer = StatusGamer.Otbit;
                else
                    Gamers[indexPlayerHod - 1].statusGamer = StatusGamer.Otbit;
            else if (Gamers.Count > 2)
            {
                //3 и более игрока
            }            
        }
        public void BotPlay()//активация бота
        {
            foreach(BotGamer b in pleayerKardBot)
            {
                if (b.statusGamer == StatusGamer.Hod)
                {
                    AddKardHodBot();
                    RunClearListCancelHod(false, ButtonsEnable.Otboy);
                }
                else if (b.statusGamer == StatusGamer.Otbit)
                {
                    RunClearListCancelHod(true, ButtonsEnable.Otboy);
                    AddKardBoyBot();
                }
            }
            RunClearListCancelHod(false, ButtonsEnable.AddKards);
            
        }
        
        private void AddKardHodBot()//обработка хода бота
        {
            Dictionary<int, Kard> botHodKards;
            foreach (BotGamer k in pleayerKardBot)
            {
                botHodKards = k.AddKardHodBot(gameField.KardHod.Values.ToList(), gameField.KardBoy.Values.ToList());
                if (botHodKards.Count > 0)
                {
                    foreach (var val in botHodKards)
                    {
                        GetAnimateCard(k.X, k.Y, (gameField.X + 50) + (val.Key-1) * 75, gameField.Y);
                        gameField.AddkardHod(val.Value);
                        k.DelKard(val.Value);                        
                    }
                    MoveKard = null;
                    RunClearListCancelHod(true, ButtonsEnable.Zabraat);
                }
                else
                {
                    GameMessage("У меня нет что подкинуть! Отбой.",GameMes.MessageBot, (Bitmap)Properties.Resources.ResourceManager.GetObject("BotSmile"));
                    OtboyCreate();
                }
            }

            RunClearListCancelHod(false, ButtonsEnable.Cancel);
            hist.ResetField(ref flagC);
        }
        private void AddKardBoyBot()//обработка отбивания бота
        {
            Dictionary<int, Kard> botBoyKards;
            List<Kard> kards = new List<Kard>();
            kards.AddRange(gameField.KardBoy.Values);
            kards.AddRange(gameField.KardHod.Values);
            foreach (BotGamer k in pleayerKardBot)
            {
                botBoyKards = k.AddKardBoyBot(KardsPodkid, gameField.KardBoy.Values.ToList().Count);
                if (botBoyKards !=null)
                {
                    foreach (var val in botBoyKards)
                    {
                        GetAnimateCard(k.X, k.Y, (gameField.X + 50) + (val.Key - 1) * 75, gameField.Y);
                        gameField.AddkardBoy(val.Value, val.Key);
                    }
                    MoveKard = null;
                    RunClearListCancelHod(true,ButtonsEnable.Otboy);
                }
                else
                {
                    GameMessage("Не могу побить! Забираю.",GameMes.MessageBot, (Bitmap)Properties.Resources.ResourceManager.GetObject("BotSmileGr"));
                    gameField.DelkardBoy();
                    gameField.DelkardHod();
                    GetAnimateCard(gameField.X, gameField.Y, k.X + k.Dist * k.GetKard().Count, k.Y);
                    k.Zabrat(kards);                    
                    DobavlenieKards();
                }
            }
            KardsPodkid.Clear();
            RunClearListCancelHod(false, ButtonsEnable.Cancel);
            hist.ResetField(ref flagC);
        }
        public void Cancel()//отмена действий
        {
            RunClearListCancelHod(false, ButtonsEnable.Cancel);
            RunClearListCancelHod(false, ButtonsEnable.AddKards);
            RunClearListCancelHod(false, ButtonsEnable.Otboy);
            for (int i=0;i<pleayerKard.Count;i++)
              hist.Undo(pleayerKard[i],gameField,ref flagC);
            KardsPodkid.Clear();
        }
        public void ZabratPlayer()//забрать карты игроком
        {
            List<Kard> kards = new List<Kard>();
            kards.AddRange(gameField.KardBoy.Values);
            kards.AddRange(gameField.KardHod.Values);
            GameMessage("Ахах, слабак!", GameMes.MessageBot, (Bitmap)Properties.Resources.ResourceManager.GetObject("BotSmileDur"));
            foreach (GamerMan gg in pleayerKard)
            {
                gameField.DelkardBoy();
                gameField.DelkardHod();
                GetAnimateCard(gameField.X, gameField.Y, gg.X + gg.Dist * gg.GetKard().Count, gg.Y);
                gg.AddKard(kards);               
            }
            DobavlenieKards();
            BotPlay();            
        }
        public void OtboyCreate(bool playerOtb=false)//создание отбоя
        {
            List<Kard> kards = new List<Kard>();
            kards.AddRange(gameField.KardBoy.Values);
            kards.AddRange(gameField.KardHod.Values);
            if (Otboy == null)
            {
                Otboy = new Otboy();
                Otboy.X = 850;
                Otboy.Y = 200;
            }
            gameField.DelkardBoy();
            gameField.DelkardHod();
            if (playerOtb)
                if (kards.Count > 4)
                    GameMessage("Было Сложно!", GameMes.MessageBot, (Bitmap)Properties.Resources.ResourceManager.GetObject("BotSmileGr"));
                else
                    GameMessage("Легко я отбился!", GameMes.MessageBot,(Bitmap)Properties.Resources.ResourceManager.GetObject("BotSmile"));
            GetAnimateCard(gameField.X, gameField.Y, Otboy.X , Otboy.Y);
            Otboy.AddKard(kards);            
            NextHod();
        }
        SortedSet<KardGamer> setOfGam = new SortedSet<KardGamer>(new MySortStatusGamer());
        private void NextHod()//следующий ход 
        {            
            DobavlenieKards();
            KardsPodkid.Clear();
            if (Gamers[0].statusGamer == StatusGamer.Hod)
            {
                Gamers[0].statusGamer = StatusGamer.Otbit;
                Gamers[1].statusGamer = StatusGamer.Hod;
                RunClearListCancelHod(false, ButtonsEnable.Zabraat);
                BotPlay();
                GameMessage("Ход противнка!", GameMes.StatusHod);                
            }
            else if (Gamers[0].statusGamer == StatusGamer.Otbit)
            {
                Gamers[0].statusGamer = StatusGamer.Hod;
                Gamers[1].statusGamer = StatusGamer.Otbit;
                RunClearListCancelHod(false, ButtonsEnable.Zabraat);
                BotPlay();
                GameMessage("Ваш ход!", GameMes.StatusHod);
            }
            RunClearListCancelHod(false,ButtonsEnable.AddKards);
            RunClearListCancelHod(false, ButtonsEnable.Cancel);
            RunClearListCancelHod(false, ButtonsEnable.Otboy);            
        }  
        private void AddKardGamer(KardGamer gam,int kolKard)//раздача карт
        {
            for (int i = 0; i < kolKard; i++)
            {
                if (koloda.GetKard().Count >i)
                {
                    GetAnimateCard(koloda.X, koloda.Y, gam.X+gam.Dist*i,gam.Y,speed:20);
                    gam.AddKard(koloda.GetKardIndex(i));
                    koloda.DelKard(i);
                }
            }
            MoveKard = null;
        } 
        private void DobavlenieKards()//добавляет карты во время игры с колоды, если меньше 6 у игрока
        {
            setOfGam.Clear();
            foreach (KardGamer k in Gamers)
                setOfGam.Add(k);
            foreach (KardGamer gam in setOfGam)
            {
                if (gam.GetKard().Count < 6)
                {
                    AddKardGamer(gam, 6 - gam.GetKard().Count);
                }
            }
        }
        /// <summary>
        /// анимирует карты
        /// </summary>
        /// <param name="xStart"></param> коорднаты начала анимации
        /// <param name="yStart"></param>
        /// <param name="xEnd"></param>коорднаты конца анимации
        /// <param name="yEnd"></param>
        /// <param name="step"></param>параметр для количества шагов анимации (чем больше, тем меньше шагов)
        /// <param name="speed"></param>скорость движения
        private void GetAnimateCard(int xStart,int yStart, int xEnd, int yEnd, int step = 40,int speed=50)  // возвращает верхнюю карту с удалением ее из стопки и анимацией перемещения 
        {
            MoveKard = new KardGamer();
            MoveKard.AddKard(new Kard((Bitmap)Properties.Resources.ResourceManager.GetObject("_36")));
            MoveKard.X = xStart;
            MoveKard.Y = yStart;
            int dx = MoveKard.X - xEnd;
            int dy = MoveKard.Y - yEnd;
            double distance = Math.Sqrt(dx * dx + dy * dy); // расстояние от колоды до последней карты в стопке - приемнике (по Пифагору)
            int count = (int)(distance / step);  // количество шагов
            if (count > 0)
            {
                dx = dx / count;  // размер шага
                dy = dy / count;
            }
            for (int i = 0; i < count; i++) // перемещаем и показываем
            {
                MoveKard.X -= dx;
                MoveKard.Y -= dy;
                frm.Refresh(); // просто Invalidate() здесь не проходит
                Thread.Sleep(speed);
            }
        }
            
    }
}
