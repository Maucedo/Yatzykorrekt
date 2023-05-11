using System.Collections.Generic;
using System.Linq;
using Yatzy_korrekt.Enum;

namespace Yatzy_korrekt
{
    public static class Calculate
    {
        //Skapar en bool som kollar ifall vi har något par, vilket
        //blir true ifall man har ett par, samma princip gäller på de där under.
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
            //här anropar vi på funktionen där ovan och kollar om man har par i 1-6. Samma princip gäller de nedan.
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

        
        public static Dictionary<NumberOfDices, int> HowManyOfEachKind(List<Dice> dieces)
        {
            // Här så gör vi ett dictionary där vi utifrån enum (vilket är Ettor, tvåor osv) kollar hur
            // många av varje tärningstyp vi har och sedan skickar tillbaks..
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
            // Här kollar vi om vi har 4st värde som är 0, utav 6, samt kollar så att fyra av
            // dem inte är likadana, för ifall dessa två grejer är sant så har man full house.
            if((FullHouse.Where(x => x.Value == 0).Count() == 4)
                && (HasAnyFourOfAKind(dieces) == false))
            {
                return true;  
            }
            return false;
        }

        // denna används i denhär classen (därför den är private) för att kolla hur många
        // av en viss tärning man har
        private static int HowManyOfAnyKind(List<Dice> dieces, int value)
        {
            return dieces.Where(x => x.tärningsnum == value).Count();
        }
        public static bool HasBigLadder(List<Dice> dieces)
        {
            //Här gör vi liknande som med fullhouse, fast här kollar
            //vi så det endast finns en 0a, samt i denna kollar vi om det är ettan som är 0an.
            var BigLadder = HowManyOfEachKind(dieces);
            if ((BigLadder.Where(x => x.Value == 0).Count() == 1) && HowManyOfAnyKind(dieces, 1) == 0) 
            {
                    return true;
            }
            return false;
        }
        public static bool HasSmallLadder(List<Dice> dieces)
        {
            //samma som i den ovan, fast här kollar man om 6an är en 0a, för då har man liten stege.
            var SmallLadder = HowManyOfEachKind(dieces);
            if ((SmallLadder.Where(x => x.Value == 0).Count() == 1) && HowManyOfAnyKind(dieces, 6) == 0)
            {
                return true;
            }
            return false;
        }

        // I denna ska vi se om vi har två par vilket vi gör genom att checka
        // alla värden vi har (asså med antal lika tärningar) och rangordnar de,
        // och om de nästhögsta talet är 2 så har man alltid minst 2 par.
        public static bool HasTwoPairs(List<Dice> dieces)
        {
            var värden = dieces.GroupBy(x => x.tärningsnum)
                .Select(group => new
                {
                    Value = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count);
            if (värden.ElementAt(1).Count == 2) 
            {
                return true;
            }
            return false;
        } 
        
    }
}
