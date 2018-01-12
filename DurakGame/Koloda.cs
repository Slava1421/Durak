using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    class Koloda:StopkaKards
    {
        public Koloda()
        {
            StartGame();
        }
        public override void AddKard(Kard kard, bool addEnd = false)
        {
            if (addEnd == false)
                kards.Add(kard);
            else
                kards.Insert(kards.Count, kard);
        }
        private void StartGame()//создание колоды
        {
            for (int i = 0; i < Constanta.RANK_COUNT; i++)
                for (int j = 0; j < Constanta.KolMast; j++)
                {
                    AddKard(new Kard((MastKard)j, i == 0 ? (RankKard)10 : (RankKard)i, (Bitmap)Properties.Resources.ResourceManager.GetObject("_" + (i + Constanta.RANK_COUNT * j).ToString())));
                }

            Peremeshka();
        }
        public void Peremeshka()
        {
            Random r = new Random();
            int val;
            for (int i = 0; i < Constanta.KolKard; i++)
            {
                val = r.Next(0, 36);
                kardV = kards[i];
                kards[i] = kards[val];
                kards[val] = kardV;
            }
        }
    }
}
