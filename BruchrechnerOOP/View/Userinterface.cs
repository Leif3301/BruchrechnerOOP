/*
 Autor:         Dennis Frank
 Dateiname:     Userinterface.cs
 Klasse:        IA219
 Datum:         28.09.2020
 Beschreibung:  Diese Klasse definiert das Userinterface
 Änderung:      05.10.2020
 */
using BruchrechnerOOP.Controller;
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
        Bruch bruch = new Bruch();

        public Bruch Bruch
        {
            get { return _bruch; }
            set { _bruch = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Userinterface()
        {
            bruch.Zaehler = 0;
            bruch.Nenner = 0;
            Text = "--";
        }

        public Userinterface(Bruch bruch, string text)
        {
            this.Bruch = bruch;
            this.Text = text;
        }

        /**
         * Konvertiert die Benutzereingabe in einen Integer
         */
        protected int KonvertiereEingabeZuInt()
        {
            int eingabe = Convert.ToInt32(LeseTextEin());
            return eingabe;
        }

        /**
         * Liest einen Bruch ein
         */
        public Bruch LeseBruchEin()
        {          
            Console.WriteLine("Bitte Zähler eingeben: ");
            int zaehler = KonvertiereEingabeZuInt();
            Console.WriteLine("Bitte Nenner eingeben: ");
            int nenner = KonvertiereEingabeZuInt();
            Bruch bruch = new Bruch(zaehler, nenner);
            return bruch;
        }

        /**
         * Gibt einen Bruch aus
         */
        public void GebeBruchAus()
        {
            GebeTextAus(Bruch.Zaehler + "/" + Bruch.Nenner);
        }

        /**
         * Gibt den Startbildschirm aus
         */
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

        /**
         * Gibt das Menue aus
         */
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

        /**
         * Wertet die gewaehlte Eingabe aus
         */
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

        private string LeseTextEin()
        {
            string textEingabe = Console.ReadLine();
            return textEingabe;
        }

        private void GebeTextAus(string eingabe)
        {
            Console.WriteLine(eingabe);
        }
    }
}
