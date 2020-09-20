using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP
{
    class Programm
    {
        static void Main(string[] args)
        {
            Bruch bruch1 = new Bruch(7, 5);
            Bruch bruch2 = new Bruch(5, 4);
         
            Console.WriteLine("Ergebnis Multiplikation: " + bruch1.Multipliziere(bruch2).Ausgabe());
            Console.WriteLine("Ergebnis Division: " + bruch1.Dividiere(bruch2).Ausgabe());
            Console.WriteLine("Ergebnis Addition: " + bruch1.Addiere(bruch2).Ausgabe());
            Console.WriteLine("Ergebnis Subtraktion: " + bruch1.Subtrahiere(bruch2).Ausgabe());

            Console.ReadKey(true); // TODO: kommentieren
        }
    }
}
