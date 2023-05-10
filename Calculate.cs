using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy_korrekt
{
    public static class Calculate
    {
        public static int HowManyOfAKind(List<Dice> dices, int value)
        {
            return dices.Where(x => x.tärningsnum == value).Count();
        }

    }
}
