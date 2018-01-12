using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    class GamerMan:KardGamer
    {        
        private bool RulesGameHod(Kard kard,Dictionary<int, Kard> kardHod, Dictionary<int, Kard> KardBoy)
        {
            foreach (Kard k in new List<Kard>(kardHod.Values))
            {
                if (k.Rank == kard.Rank && kardHod.Count > 0)
                    return true;
            }
            foreach (Kard k in new List<Kard>(KardBoy.Values))
            {
                if (k.Rank == kard.Rank && KardBoy.Count > 0)
                    return true;
            }
            if (kardHod.Count == 0)
                return true;
            else
                return false;
        }
        public bool RulesGameBoy(Kard kard, int key, Dictionary<int, Kard> kardHod)
        {
            if (kard.Mast != kardHod[key].Mast && kard.Kozir == false)
                return false;
            else if (kard.Rank <= kardHod[key].Rank && kard.Kozir == false)
                return false;
            else if (kard.Rank <= kardHod[key].Rank && kard.Kozir == true && kardHod[key].Kozir == true)
                return false;
            return true;
        }
        public Kard AddKardHod(Kard kard, Dictionary<int, Kard> kardHod, Dictionary<int, Kard> KardBoy)
        {
            if (RulesGameHod(kard, kardHod, KardBoy))
            {                
                return kard;
            }
            else
                return null;                    
        }
        public Kard AddKardBoy(Kard kard, Dictionary<int, Kard> kardHod, int indexKardBoy)
        {              
            if (RulesGameBoy(kard,indexKardBoy, kardHod))
            {
                return kard;
            }              
            return null;
        }        
    }
}
