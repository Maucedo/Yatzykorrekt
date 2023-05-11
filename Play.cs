using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzy_korrekt.Enum;

namespace Yatzy_korrekt
{
    public class Play
    {
        public int PointValue { get; set; }
        public NumberOfDices Type { get; set; }
        
        public Play(NumberOfDices type, int points)
        {
            Type = type;
            PointValue = points;
        }
    }
}
