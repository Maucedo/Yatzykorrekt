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
        private static bool HasOnePair(List<Dice> dices, int value)
        {
            return dices.Where(x => x.tärningsnum == value).Count() >= 2;
        }
        private static bool HasThreeOfAKind(List<Dice> dices, int value)
        {
            return dices.Where(x => x.tärningsnum == value).Count() >= 3;
        }
        private static bool HasFourOfAKind(List<Dice> dices, int value)
        {
            return dices.Where(x => x.tärningsnum == value).Count() >= 4;
        }
        private static bool HasYatzy(List<Dice> dices, int value)
        {
            return dices.Where(x => x.tärningsnum == value).Count() >= 5;
        }
        public static bool HasAnyOnePair(List<Dice> dices)
        {
            return HasOnePair(dices, 1)
                || HasOnePair(dices, 2)
                || HasOnePair(dices, 3)
                || HasOnePair(dices, 4)
                || HasOnePair(dices, 5)
                || HasOnePair(dices, 6);
        }
        public static bool HasAnyThreeOfAKind(List<Dice> dices)
        {
            return HasFourOfAKind(dices, 1)
                || HasFourOfAKind(dices, 2)
                || HasFourOfAKind(dices, 3)
                || HasFourOfAKind(dices, 4)
                || HasFourOfAKind(dices, 5)
                || HasFourOfAKind(dices, 6);
        }
        public static bool HasAnyFourOfAKind(List<Dice> dices)
        {
            return HasThreeOfAKind(dices, 1)
                || HasThreeOfAKind(dices, 2)
                || HasThreeOfAKind(dices, 3)
                || HasThreeOfAKind(dices, 4)
                || HasThreeOfAKind(dices, 5)
                || HasThreeOfAKind(dices, 6);
        }
        public static bool HasAnyYatzy(List<Dice> dices)
        {
            return HasYatzy(dices, 1)
                || HasYatzy(dices, 2)
                || HasYatzy(dices, 3)
                || HasYatzy(dices, 4)
                || HasYatzy(dices, 5)
                || HasYatzy(dices, 6);
        }

       public enum NumberOfDices
        {
            one,
            two,
            three,
            four,
            five,
            six
        }
        public static Dictionary<NumberOfDices, int> HowManyOfEachKind(List<Dice> dieces)
        {
            var DictOfDiceNum = new Dictionary<NumberOfDices, int>
            {
                {NumberOfDices.one, HowManyOfAnyKind(dieces, 1) },
                {NumberOfDices.two, HowManyOfAnyKind(dieces, 2) },
                {NumberOfDices.three, HowManyOfAnyKind(dieces, 3) },
                {NumberOfDices.four, HowManyOfAnyKind(dieces, 4) },
                {NumberOfDices.five, HowManyOfAnyKind(dieces, 5) },
                {NumberOfDices.six, HowManyOfAnyKind(dieces, 6) }
            };
            return DictOfDiceNum;
        }
        public static bool HasFullHouse(List<Dice> dieces)
        {
            var FullHouse = HowManyOfEachKind(dieces);

            if((FullHouse.Where(x => x.Value == 0).Count() == 4)
                && (HasAnyFourOfAKind(dieces) == false))
            {
                return true;  
            }
            return false;
        }
        private static int HowManyOfAnyKind(List<Dice> dieces, int value)
        {
            return dieces.Where(x => x.tärningsnum == value).Count();
        }
    }
}
