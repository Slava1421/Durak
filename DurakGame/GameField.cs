using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    class GameField
    {
        private Dictionary<int, Kard> kardHod; //карты хода на игровом поле
        private Dictionary<int, Kard> kardBoy;//карты которыми бьют
        private int x, y;   // координаты стопки
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Dictionary<int, Kard> KardBoy { get { return kardBoy; } }
        public Dictionary<int, Kard> KardHod { get { return kardHod; } }
        public GameField()
        {
            kardBoy = new Dictionary<int, Kard>();
            kardHod = new Dictionary<int, Kard>();
        }
        public void AddkardBoy(Kard kard,int key)
        {
            if (kardHod.Count > 0)
            {
                kardBoy.Add(key, kard);
            }
        }
        public void AddkardHod(Kard kard)
        {
            kardHod.Add(kardHod.Count + 1, kard);            
        }
        public void DelkardBoy(int key)
        {
            kardBoy.Remove(key);
        }
        public void DelkardBoy()
        {
            kardBoy.Clear();
        }
        public void DelkardHod(int key)
        {
            kardHod.Remove(key);
        }
        public void DelkardHod()
        {
            kardHod.Clear();
        }
    }
}
