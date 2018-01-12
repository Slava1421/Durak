using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    enum RankKard
    {
        Perevern=100,
        tuz = 10,
        six =1,
        seven=2,
        eight=3,
        nine=4,
        ten=5,
        valet=6,
        dama=7,
        korol=8
    }
    enum MastKard
    {
        Perevern=100,
        Jir = 0,
        Bubna = 1,
        Chirva = 2,
        Pika = 3       
    }
    enum StatusGamer
    {
        Hod=1,
        Podkinut=2,
        Otbit=3,
        BezDeistviy=4
    }
    class Kard
    {
        private MastKard mast;//масть
        private RankKard rank;//6,7...валет,дама...
        private Bitmap img;//изображение
        private bool kozir;//козырь

        public MastKard Mast
        {
            get{ return mast;} 
            set { mast = value; }           
        }
        public Bitmap Img
        {
            get { return img; }
        }
        public RankKard Rank
        {
            get{ return rank;}
        }
        public bool Kozir
        {
            get { return kozir; }
            set { kozir = value; }
        }
        public Kard(MastKard _mast,RankKard _rank,Bitmap _img)
        {
            mast = _mast;
            rank = _rank;
            img = _img;
            kozir = false;
        }
        public Kard(Bitmap _img)
        {
            mast = (MastKard)100;
            rank = (RankKard)100;
            img = _img;
            kozir = false;
        }
    }
}
