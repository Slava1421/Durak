using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    abstract class StopkaKards
    {
        protected List<Kard> kards;
        private int x, y;   // координаты стопки
        protected Kard kardV;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public StopkaKards()
        {
            kards = new List<Kard>();
        }
        public virtual void AddKard(Kard kard,bool addEnd=false)
        {
                kards.Add(kard);
        }
        public virtual void AddKard(List<Kard> k)
        {
            kards.AddRange(k);
        }

        public virtual Kard GetKardIndex(int index)
        {
            return kards[index];
        }
        public virtual List<Kard> GetKard()
        {
            return kards;
        }
        public virtual void DelKard(int index)
        {
            kards.RemoveAt(index);
        }
        public virtual void DelKard(Kard kard)
        {
            kards.Remove(kard);
        }
        public virtual void DelKardsList(List<Kard> kards)
        {
            foreach(Kard kard in kards)
                kards.Remove(kard);
        }
        public virtual void DelAllKard()
        {
            kards.Clear();
        }        
    }
}
