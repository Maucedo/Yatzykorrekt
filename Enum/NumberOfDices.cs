using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy_korrekt.Enum
{
    //Här har vi en enumlista vilket är i en enum lista för vi vill ha de som
    //konstanter som inte går att ändra, dessa refereras till de andra flikarna via "using"
         public enum NumberOfDices
        {
            one,
            two,
            three,
            four,
            five,
            six,
            OnePair,
            TwoPairs,
            ThreeOfAKind,
            FoursOfAKind,
            Yatzy,
            FullHouse,
            SmallStraight,
            LargeStraight

        }
}
