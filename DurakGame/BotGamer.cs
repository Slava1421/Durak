using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    class BotGamer:KardGamer
    {
        public Dictionary<int,Kard> AddKardHodBot(List<Kard> hod, List<Kard> boy)
        {
            List<Kard> kardMin = new List<Kard>();
            Dictionary<int, Kard> kardsR = new Dictionary<int, Kard>();
            RankKard rank;
            int count = 1;
            if (hod.Count == 0)
            {
                rank = kards.FindAll(k => k.Kozir == false).Min(k => k.Rank);
                kardMin = kards.FindAll(k => k.Rank == rank&& k.Kozir == false);
                foreach (Kard kar in kardMin)
                {
                    kardsR.Add(count, kar);
                    count++;
                }
            }
            else if (hod.Count > 0 && boy.Count > 0)
            {
                foreach(Kard kar in kards)
                {
                    if (hod.Find(k=>k.Rank==kar.Rank)!=null)
                    {
                        if(kardsR.Count==0)
                            kardsR.Add(hod.Count + 1, kar);
                        else if(kardsR.Count > 0)
                            kardsR.Add(kardsR.Keys.Max() + 1, kar);
                        continue;
                    }
                    else if (boy.Find(k => k.Rank == kar.Rank) != null)
                    {
                        if (kardsR.Count == 0)
                            kardsR.Add(hod.Count + 1, kar);
                        else if (kardsR.Count > 0)
                            kardsR.Add(kardsR.Keys.Max() + 1, kar);
                    }
                }
            }

            return kardsR;
        }
        public Dictionary<int, Kard> AddKardBoyBot(List<Kard> hod, int boy)
        {
            Dictionary<int, Kard> kardsR = new Dictionary<int, Kard>();
            foreach (var kar in hod)
            {
                var k = (kards.FindAll(f1=> 
                {
                    if (f1.Rank > kar.Rank && f1.Mast == kar.Mast && kar.Kozir == false)
                        return true;
                    else if (kar.Kozir == true && f1.Rank > kar.Rank && kar.Mast==f1.Mast)
                        return true;
                    else if (kar.Kozir == false && kar.Mast != f1.Mast && f1.Kozir==true)
                        return true;
                    return false;
                })).ToList();
                var f=k.FirstOrDefault(l=> 
                {
                    if (k.FindAll(u => u.Kozir == false).Count>0)
                    {
                        if (l.Rank == k.FindAll(u => u.Kozir == false).Min(x => x.Rank))
                        return true;
                    }
                    else if (k.FindAll(u => u.Kozir == true).Count>0)
                        if (l.Rank == k.FindAll(u => u.Kozir == true).Min(x => x.Rank))
                            return true;
                    return false;
                });
                if (f != null)
                {
                    if (kardsR.Count == 0)
                    {
                        kardsR.Add(boy + 1, f);
                    }
                    else if (kardsR.Count > 0)
                    {
                        kardsR.Add(kardsR.Last().Key + 1, f);
                    }
                }               
            }

            if (hod.Count != kardsR.Count)
            {
                return null;
            }
            else
            {
                foreach (Kard kk in kardsR.Values)
                    DelKard(kk);
                return kardsR;
            }
        }
        public void Zabrat(List<Kard> kardsAdd)
        {
            foreach (Kard k in kardsAdd)
                kards.Add(k);
        }
    }
}
