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

        // Här vill vi visa hur många av varje vi har.
        var ones = Calculate.HowManyOfAKind(tärningar, 1);
        Console.WriteLine($"1: {ones}");
       

        var two = Calculate.HowManyOfAKind(tärningar, 2);
        Console.WriteLine($"2: {two}");

        var three = Calculate.HowManyOfAKind(tärningar, 3);
        Console.WriteLine($"3: {three}");

        var fours = Calculate.HowManyOfAKind(tärningar, 4);
        Console.WriteLine($"4: {fours}");

        var fives = Calculate.HowManyOfAKind(tärningar, 5);
        Console.WriteLine($"5: {fives}");

        var sixes = Calculate.HowManyOfAKind(tärningar, 6);
        Console.WriteLine($"6: {sixes}");

        var onepair = Calculate.HasAnyOnePair(tärningar);
        Console.WriteLine($"Ett par: {onepair}");

        var ThreeOfAKind = Calculate.HasAnyThreeOfAKind(tärningar);
        Console.WriteLine($"Triss: {ThreeOfAKind}");

        var FourOfAKind = Calculate.HasAnyFourOfAKind(tärningar);
        Console.WriteLine($"Fyrtal: {FourOfAKind}");

        var Yatzy = Calculate.HasAnyYatzy(tärningar);
        Console.WriteLine($"Yatzy: {Yatzy}");

        Console.ReadLine(); 
        
    }
    return tärnspara;
}
    

