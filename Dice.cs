using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy_korrekt
{
    //här är klassen för en tärning
    public class Dice
    {
        //Här är en tärnings attribut, tärningsnum är då värdet på tärningen, och Spara är då ifall
        //man vill spara på tärningen eller inte 
        public int tärningsnum;
        public bool spara;

        public Dice(int tärningsnum, bool spara = false)
        {
            this.tärningsnum = tärningsnum;
            this.spara = spara;
        }

    }
}
