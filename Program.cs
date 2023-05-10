// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

int slag = 0;
var random = new Random();
var tärningar = new List<Tärning>(5);
for (int i = 0; i < tärningar.Capacity; i++)
{
    tärningar.Add(new Tärning(random.Next(1, 7)));
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


static List<int> TärningsRunda(Random random, List<Tärning> tärningar, int slag)
{
    foreach (Tärning y in tärningar)
    {
        Console.WriteLine(y.tärningsnum);
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
        var lista1 = new int[5];
        foreach (var värde in tärningar)
        {
            for (int i = 0; i < tärningar.Count; i++)
            {
                if (lista1.Contains(tärningar[i].tärningsnum))
                {
                    continue;
                }
                else
                {
                    lista1[i] = värde.tärningsnum;
                }
            }
        }
        var t = lista1;
        var f = tärningar;
    }
    return tärnspara;
}
    

class Tärning
{
    public int tärningsnum;
    public bool spara;

    public Tärning(int tärningsnum, bool spara = false)
    {
        this.tärningsnum = tärningsnum;
        this.spara = spara;
    }
}
