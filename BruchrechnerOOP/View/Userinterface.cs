/*
 Autor:         Dennis Frank
 Dateiname:     Userinterface.cs
 Klasse:        IA219
 Datum:         28.09.2020
 Beschreibung:  Dient als Schnittstelle zwischen Computer und Mensch
 Änderung:      05.10.2020, 15.10.2020, 20.10.2020, 21.10.2020
 */
using BruchrechnerOOP.Controller;
using BruchrechnerOOP.Model;
using System;

namespace BruchrechnerOOP.View
{
    // Dient als Schnittstelle zwischen Computer und Mensch
    class Userinterface
    {
        private Bruch _bruch;
        private string _text;

        // Zugriffsmethode für einen Bruch
        public Bruch Bruch
        {
            get { return _bruch; }
            set { _bruch = value; }
        }

        // Zugriffsmethode für einen Text
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        // Standardkonstruktor
        public Userinterface()
        {

        }

        // Spezialkonstruktor
        public Userinterface(Bruch bruch, string text)
        {
            this.Bruch = bruch;
            this.Text = text;
        }

        // Konvertiert die Benutzereingabe in einen Integer
        protected int KonvertiereEingabeZuInt()
        {
            int eingabe;
            while (!int.TryParse(Console.ReadLine(), out eingabe))
            {
                Console.WriteLine("Bitte eine Ganzzahl eingeben!");
            }
            return eingabe;
        }

        // Liest einen Bruch ein
        public Bruch LeseBruchEin(int i)
        {
            GebeTextAus($"\nBitte {i}. Zähler eingeben: ");
            int zaehler = KonvertiereEingabeZuInt();
            GebeTextAus($"\nBitte {i}. Nenner eingeben: ");
            int nenner = KonvertiereEingabeZuInt();
            Bruch bruch = new Bruch(zaehler, nenner);
            return bruch;
        }

        // Gibt einen Bruch aus
        public void GebeBruchAus(Bruch bruch)
        {
            GebeTextAus($"{bruch.Zaehler}/{bruch.Nenner}");
        }

        // Gibt den Startbildschirm aus
        public void GebeSplashScreenAus()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            GebeTextAus("######################################################################");
            GebeTextAus("###########                ###########################################");
            GebeTextAus("###########  BRUCHRECHNER  ###########################################");
            GebeTextAus("###########                ###########################################");
            GebeTextAus("######################################################################");
            GebeTextAus("########################################                   ###########");
            GebeTextAus("########################################  by Dennis Frank  ###########");
            GebeTextAus("########################################                   ###########");
            GebeTextAus("######################################################################");
            GebeTextAus("                                                                      ");
            GebeTextAus("                                                                      ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Gibt den Bildschirm zum Beenden aus
        public void GebeBeendeBildschirmAus()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            GebeTextAus("");
            GebeTextAus("######################################################################");
            GebeTextAus("########################                   ###########################");
            GebeTextAus("########################  BEENDE PROGRAMM  ###########################");
            GebeTextAus("########################                   ###########################");
            GebeTextAus("######################################################################");
        }

        // Gibt das Menue aus
        public string GebeMenueAus()
        {
            GebeTextAus("Wählen Sie aus einer der folgenden Möglichkeiten:");
            System.Threading.Thread.Sleep(180);

            GebeTextAus("");
            GebeTextAus("[A]ddieren zweier Brüche");
            System.Threading.Thread.Sleep(180);

            GebeTextAus("[S]ubtrahieren zweier Brüche");
            System.Threading.Thread.Sleep(180);

            GebeTextAus("[M]ultiplikation zweier Brüche");
            System.Threading.Thread.Sleep(180);

            GebeTextAus("[D]ivision zweier Brüche");
            System.Threading.Thread.Sleep(180);

            GebeTextAus("\n[B]eenden des Programms");

            return Console.ReadKey().KeyChar.ToString();
        }

        // Wertet die gewaehlte Menüeingabe aus
        public void WerteMenueEingabeAus(string eingabe)
        {
            Programmsteuerung programmsteuerung = new Programmsteuerung();
            switch (eingabe)
            {
                case "a":
                    programmsteuerung.BruecheAddieren();
                    break;
                case "s":
                    programmsteuerung.BruecheSubtrahieren();
                    break;
                case "m":
                    programmsteuerung.BruecheMultiplizieren();
                    break;
                case "d":
                    programmsteuerung.BruecheDividieren();
                    break;
                case "b":
                    programmsteuerung.BeendeProgramm();
                    break;
                default:
                    GebeTextAus("Bitte gültige Eingabe machen!");
                    break;
            }
        }

        // Liest Text von der Konsle ein
        public string LeseTextEin()
        {
            Text = Console.ReadLine();
            return Text;
        }

        // Gibt Text auf der Konsole aus
        public void GebeTextAus(string Text)
        {
            Console.WriteLine(Text);
        }
    }
}
