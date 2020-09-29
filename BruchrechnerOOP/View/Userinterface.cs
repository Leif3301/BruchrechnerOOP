/*
 Autor:         Dennis Frank
 Dateiname:     Userinterface.cs
 Klasse:        IA219
 Datum:         28.09.2020
 Beschreibung:  Diese Klasse definiert das Userinterface
 Änderung:      
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP.View
{
    class Userinterface
    {
        private Bruch _bruch;
        private string _text;

        public Bruch Bruch { get; set; }
        public string Text { get; set; }

        protected int IntEingabe()
        {
            int eingabe = Convert.ToInt32(Console.ReadLine());
            return eingabe;
        }

        public Bruch LeseBruchEin()
        {          
            Console.WriteLine("Bitte Zähler eingeben: ");
            int zaehler = IntEingabe();
            Console.WriteLine("Bitte Nenner eingeben: ");
            int nenner = IntEingabe();
            Bruch bruch = new Bruch(zaehler, nenner);
            return bruch;
        }

        public void GebeBruchAus()
        {
            Console.WriteLine(Bruch.Zaehler + "/" + Bruch.Nenner);
        }

    }
}
