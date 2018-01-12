using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    class History
    {
        private List<int> cancelKardIndex;// карты которые нужно вернуть назад
        private GamerMan cancelPlayerKard;// карты игрока до хода
        private List<Kard> GamerKardsOld;
        public List<int> CancelKardIndex { set { cancelKardIndex = value; }get { return cancelKardIndex; } }
        public History()
        {
            cancelKardIndex = new List<int>();
        }
        public void AddCancelPlayerKard(GamerMan gam,ref bool flagC)
        {
            cancelPlayerKard = new GamerMan();
            for (int i = 0; i < gam.GetKard().Count; i++)
            {
                cancelPlayerKard.AddKard(gam.GetKardIndex(i));
            }
            flagC = false;
        }
        public void Undo(GamerMan gam, GameField fil, ref bool flagC)
        {
            if (gam.statusGamer == StatusGamer.Hod)
            {
                foreach (var key in cancelKardIndex)
                {
                    fil.DelkardHod(key);
                }
                gam.DelAllKard();
                gam.AddKard(cancelPlayerKard.GetKard());
                cancelPlayerKard=null;
                cancelKardIndex.Clear();
                flagC = true;
            }
            else if (gam.statusGamer == StatusGamer.Otbit)
            {
                foreach (var key in cancelKardIndex)
                {
                    fil.DelkardBoy(key);
                }
                gam.DelAllKard();
                gam.AddKard(cancelPlayerKard.GetKard());
                cancelPlayerKard=null;
                cancelKardIndex.Clear();
                flagC = true;
            }
        }
        public void ResetField(ref bool flagC)
        {
            cancelPlayerKard=null;
            cancelKardIndex.Clear();
            flagC = true;
        }
        public List<Kard> gamerKardsOld
        {
            get { return GamerKardsOld; }
            set
            {
                GamerKardsOld = new List<Kard>(value);
            }
        }
    }
}
