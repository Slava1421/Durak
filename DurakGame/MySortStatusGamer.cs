using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakGame
{
    class MySortStatusGamer : IComparer<KardGamer>
    {
        public int Compare(KardGamer firstGamer, KardGamer secondGamer)//сортировка по статусу игрока
        {
            if (firstGamer.statusGamer > secondGamer.statusGamer)
                return 1;
            if (firstGamer.statusGamer < secondGamer.statusGamer)
                return -1;
            else
                return 0;
        }
    }
}
