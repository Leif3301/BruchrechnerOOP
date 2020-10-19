/*
 Autor:         Dennis Frank
 Dateiname:     Programmsteuerung.cs
 Klasse:        IA219
 Datum:         05.10.2020
 Beschreibung:  Diese Klasse beinhaltet die Methode mit einer Hauptschleife
 Änderung:      
 */
using BruchrechnerOOP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP.Controller
{
    class Programmsteuerung
    {
        private Bruch[] _brueche;
        private Userinterface _userinterface;

        public Bruch[] Brueche
        {
            get { return _brueche; }
            set { _brueche = value; }
        }
        public Userinterface Userinterface
        {
            get { return _userinterface; }
            set { _userinterface = value; }
        }

        public Programmsteuerung()
        {
            
        }

        public void run()
        {
            bool programmFortsetzen = true;

            // Ausgeben des Startbildschirms
            _userinterface.GebeSplashScreenAus();
            System.Threading.Thread.Sleep(1300);

            // Fußgesteuerte Hauptschleife
            do
            {
                // Ausgabe des Menues
                string auswahl = Userinterface.GebeMenueAus();
                Console.Clear();

                // Fuehrt die gewaehlte Menue-Option aus
                Userinterface.WerteMenueEingabeAus(auswahl);

                // Abfrage ob Programm fortgesetzt werden soll
                Console.WriteLine("\nProgramm fortsetzen? ( j / n )");
                string eingabe = Console.ReadKey().KeyChar.ToString();
                do
                {
                    switch (eingabe)
                    {
                        case "j":
                            programmFortsetzen = true;
                            break;
                        case "n":
                            programmFortsetzen = false;
                            break;
                        default:
                            Console.WriteLine("Bitte eine gültige Eingabe machen!");
                            break;
                    }
                } while (!(eingabe.Equals("j") || eingabe.Equals("n")));
                Console.Clear();
            } while (programmFortsetzen);

            BeendeProgramm();
        }

        public void BeendeProgramm()
        {
            Userinterface.GebeBeendeBildschirmAus();
            System.Threading.Thread.Sleep(2000);

            Environment.Exit(0);
        }

        public void BruecheAddieren()
        {
            Userinterface.LeseBruchEin();
            
        }

        public void BruecheSubtrahieren()
        {

        }

        public void BruecheMultiplizieren()
        {

        }

        public void BruecheDividieren()
        {

        }
    }
}
