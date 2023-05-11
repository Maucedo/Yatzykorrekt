// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy_korrekt;

//deklarerar variablar som används i koden
int slag = 0;
var random = new Random();
var tärningar = new List<Dice>(5);
int rundor = 4;


//Spelloop som då är varje gång en runda körs.
for (int k = 0; k < rundor; k++)
{

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


    slag = 0;
    tärningar = new List<Dice>(5);
}
Console.WriteLine("Spelet är slut");
Console.ReadLine();


//detta är funktionen för vad som händer ska hända under varje slag
static List<int> TärningsRunda(Random random, List<Dice> tärningar, int slag)
    {
        foreach (Dice y in tärningar)
        {
            Console.WriteLine(y.tärningsnum);
            // detta gör något
        }
        List<int> tärnspara = new List<int>();
        Console.WriteLine();
        if (slag < 2) //Detta är vad som ska hända ifall man inte slått alla slag än
        {
            Console.Write("Vad ska sparas? ");
            tärnspara = Console.ReadLine().Split(",").Select(int.Parse).ToList(); //frågar efter en input av vilka tärningar man ska spara och lägger dessa i tärnspara, samt bestämmer att inputen måste separeras med ett komma tecken ifall det är mer än ett nummer.
            //I denna foreach loopen säger vi att varje siffra i tärnspara (vilket är den listan med inputs) så ska vi göra det ekvivalenta elemetet true
            foreach (var t in tärnspara)
            {
                tärningar[t - 1].spara = true;
            }
            //i denna foreach loopen säger vi att alla tärningar som inte är true ska då "rullas om"
            foreach (var t in tärningar)
            {
                if (t.spara == false)
                {
                    t.tärningsnum = random.Next(1, 7);
                }

                t.spara = false; //sedan gör vi dessa till false igen så att man kan bestämma sig senare om man vill behålla tärningarna.
            }

        }
        else //Detta är vad som händer ifall det tredje slaget är färdigt
        {
            //Skriver ut 1-6 samt hur många av varje tärningsnummer som kom med i resultatet
            var DiceNumbers = Calculate.HowManyOfEachKind(tärningar);
            foreach (var item in DiceNumbers)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            //alla dessa skriver ut ifall man har par, triss osv, å skriver True ifall detta stämmer
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
            Console.ReadLine(); //readline är med här så att koden inte ska upphöra och man kan stanna och läsa vad som står

        }
        return tärnspara;

    }




