/*
 Autor:         Dennis Frank
 Dateiname:     Bruch.cs
 Klasse:        IA219
 Datum:         20.09.2020
 Beschreibung:  Definiert einen Bruch und stellt Rechenoperationen zur verfügung
 Änderung:      23.09.2020, 15.10.2020, 20.10.2020
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP.Model
{
    // Definiert einen Bruch und stellt Rechenoperationen zur verfügung
    class Bruch
    {
        private int _zaehler;
        private int _nenner;

        // Zugriffsmethode für den Zähler
        public int Zaehler
        {
            get { return _zaehler; }
            set { _zaehler = value; }
        }

        // Zugriffsmethode für den Nenner
        public int Nenner
        {
            get { return _nenner; }
            set { _nenner = value; }
        }

        // Standardkonstruktor
        public Bruch()
        {
            Zaehler = 1;
            Nenner = 1;
        }

        // Spezialkonstruktor
        public Bruch(int zaehler, int nenner)
        {
            if (nenner == 0)
            {
                Console.WriteLine("Der Nenner darf nicht 0 sein!");
                Console.WriteLine("Setze den Bruch auf 1.");
                Zaehler = 1;
                Nenner = 1;
            }
            else
            {
                this.Zaehler = zaehler;
                this.Nenner = nenner;
            }

            if (Nenner < 0)
            {
                Zaehler = -Zaehler;
                Nenner = -Nenner;
            }
        }

        // Ermittelt den größten gemeinsamen Teiler
        protected int BerechneGgt(int zahl1, int zahl2)
        {
            if (zahl1 == zahl2)
            {
                return zahl1;
            }
            else
            {
                while (zahl1 != zahl2)
                {
                    if (zahl1 > zahl2)
                    {
                        if ((zahl1 - zahl2) > 0)
                        {
                            zahl1 -= zahl2;
                        }
                    }
                    else
                    {
                        if ((zahl2 - zahl1) > 0)
                        {
                            zahl2 -= zahl1;
                        }
                    }
                }
                return zahl1;
            }
        }

        // Kürzt einen Bruch mit dem größten gemeinsamen Teiler
        protected Bruch Kuerze(int ergebnisZaehler, int ergebnisNenner)
        {
            Bruch ergebnisGekuerzt = new Bruch();

            int ggt = BerechneGgt(ergebnisZaehler, ergebnisNenner);


            ergebnisZaehler /= ggt;
            ergebnisNenner /= ggt;

            ergebnisGekuerzt.Zaehler = ergebnisZaehler;
            ergebnisGekuerzt.Nenner = ergebnisNenner;

            return ergebnisGekuerzt;
        }

        // Führt eine Multiplikation aus
        public Bruch Multipliziere(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            ergebnis.Zaehler = this.Zaehler * bruch.Zaehler;
            ergebnis.Nenner = this.Nenner * bruch.Nenner;

            ergebnis = Kuerze(ergebnis.Zaehler, ergebnis.Nenner);
            
            return ergebnis;
        }

        // Führt eine Division aus
        public Bruch Dividiere(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            ergebnis.Zaehler = this.Zaehler * bruch.Nenner;
            ergebnis.Nenner = this.Nenner * bruch.Zaehler;

            ergebnis = Kuerze(ergebnis.Zaehler, ergebnis.Nenner);

            return ergebnis;
        }

        // Führt eine Addition aus
        public Bruch Addiere(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            int tempZaehler1 = this.Zaehler * bruch.Nenner;
            int tempNenner1 = this.Nenner * bruch.Nenner;
            int tempZaehler2 = this.Nenner * bruch.Zaehler;

            ergebnis.Zaehler = tempZaehler1 + tempZaehler2;
            ergebnis.Nenner = tempNenner1;

            ergebnis = Kuerze(ergebnis.Zaehler, ergebnis.Nenner);

            return ergebnis;
        }

        // Führt eine Subtraktion aus
        public Bruch Subtrahiere(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            int tempZaehler1 = this.Zaehler * bruch.Nenner;
            int tempNenner1 = this.Nenner * bruch.Nenner;
            int tempZaehler2 = this.Nenner * bruch.Zaehler;

            ergebnis.Zaehler = tempZaehler1 - tempZaehler2;
            ergebnis.Nenner = tempNenner1;

            ergebnis = Kuerze(ergebnis.Zaehler, ergebnis.Nenner);

            return ergebnis;
        }

        // Weist das Ergebnis zu
        public Bruch Zuweisung(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            this.Zaehler = ergebnis.Zaehler = bruch.Zaehler;
            this.Nenner = ergebnis.Nenner = bruch.Nenner;

            return ergebnis;
        }
    }
}
