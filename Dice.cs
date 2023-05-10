using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy_korrekt
{
    public class Dice
    {
        public int tärningsnum;
        public bool spara;

        public Dice(int tärningsnum, bool spara = false)
        {
            this.tärningsnum = tärningsnum;
            this.spara = spara;
        }
    }
}
