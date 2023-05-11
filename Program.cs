// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy_korrekt;

int slag = 0;
var random = new Random();
var tärningar = new List<Dice>(5);
for (int i = 0; i < tärningar.Capacity; i++)
{
    tärningar.Add(new Dice(random.Next(1, 7)));
}


var tärnspara = TärningsRunda(random, tärningar, slag);
slag += 1;
Console.WriteLine("Slå igen?");
Console.ReadLine();

tärnspara = TärningsRunda(random, tärningar, slag);
slag += 1;

Console.WriteLine("Slå igen?");
Console.ReadLine();

tärnspara = TärningsRunda(random, tärningar, slag);


static List<int> TärningsRunda(Random random, List<Dice> tärningar, int slag)
{
    foreach (Dice y in tärningar)
    {
        Console.WriteLine(y.tärningsnum);
        // detta gör något
    }
    List<int> tärnspara = new List<int>();
    Console.WriteLine();
    if (slag < 2)
    {
        Console.Write("Vad ska sparas? ");
        tärnspara = Console.ReadLine().Split(",").Select(int.Parse).ToList();
        foreach (var t in tärnspara)
        {
            tärningar[t - 1].spara = true;
        }

        foreach (var t in tärningar)
        {
            if (t.spara == false)
            {
                t.tärningsnum = random.Next(1, 7);
            }

            t.spara = false;
        }

    }
    else
    {
        var DiceNumbers = Calculate.HowManyOfEachKind(tärningar);
        foreach (var item in DiceNumbers)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        var onepair = Calculate.HasAnyOnePair(tärningar);
        Console.WriteLine($"Ett par: {onepair}");

        var ThreeOfAKind = Calculate.HasAnyThreeOfAKind(tärningar);
        Console.WriteLine($"Triss: {ThreeOfAKind}");

        var FourOfAKind = Calculate.HasAnyFourOfAKind(tärningar);
        Console.WriteLine($"Fyrtal: {FourOfAKind}");

        var Yatzy = Calculate.HasAnyYatzy(tärningar);
        Console.WriteLine($"Yatzy: {Yatzy}");

        var FullHouse = Calculate.HasFullHouse(tärningar);
        Console.WriteLine($"Fullhouse: {FullHouse}");

        var TinyLadder = Calculate.HasSmallLadder(tärningar);
        Console.WriteLine($"Small Ladder: {TinyLadder}");

        var BigLadder = Calculate.HasBigLadder(tärningar);
        Console.WriteLine($"Big Ladder: {BigLadder}");

        var TwoPairs = Calculate.HasTwoPairs(tärningar);
        Console.WriteLine($"Two Pairs: {TwoPairs}");
        Console.ReadLine(); 
        
    }
    return tärnspara;
}
    

