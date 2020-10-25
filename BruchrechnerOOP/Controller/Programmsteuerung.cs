/*
 Autor:         Dennis Frank
 Dateiname:     Programmsteuerung.cs
 Klasse:        IA219
 Datum:         05.10.2020
 Beschreibung:  Fungiert als Verbindungsstück zwischen View- und Modelbestandteilen.
 Änderung:      15.10.2020, 20.10.2020, 21.10.2020
 */
using BruchrechnerOOP.Model;
using BruchrechnerOOP.View;
using System;

namespace BruchrechnerOOP.Controller
{
    // Fungiert als Verbindungsstück zwischen View- und Modelbestandteilen
    class Programmsteuerung
    {
        private Bruch _bruch1;
        private Bruch _bruch2;
        private Bruch _bruch3;
        private Userinterface _userinterface;

        // Zugriffsmethode für den ersten Bruch
        public Bruch Bruch1
        {
            get { return _bruch1; }
            set { _bruch1 = value; }
        }

        // Zugriffsmethode für den zweiten Bruch
        public Bruch Bruch2
        {
            get { return _bruch2; }
            set { _bruch2 = value; }
        }

        // Zugriffsmethode für den dritten Bruch
        public Bruch Bruch3
        {
            get { return _bruch3; }
            set { _bruch3 = value; }
        }

        // Zugriffsmethode für das Userinterface
        public Userinterface Userinterface
        {
            get { return _userinterface; }
            set { _userinterface = value; }
        }

        // Standardkonstruktor
        public Programmsteuerung()
        {

        }

        // Spezialkonstruktor
        public Programmsteuerung(Bruch bruch1, Bruch bruch2, Bruch bruch3, Userinterface userinterface)
        {
            Bruch1 = bruch1;
            Bruch2 = bruch2;
            Bruch3 = bruch3;
            Userinterface = userinterface;
        }

        public void run()
        {
            Userinterface ui = new Userinterface();
            bool programmFortsetzen = true;

            // Ausgeben des Startbildschirms
            ui.GebeSplashScreenAus();
            System.Threading.Thread.Sleep(1300);

            // Fußgesteuerte Hauptschleife
            do
            {
                // Ausgabe des Menues
                string auswahl = ui.GebeMenueAus();
                Console.Clear();

                // Fuehrt die gewaehlte Menue-Option aus
                ui.WerteMenueEingabeAus(auswahl);

                // Abfrage ob Programm fortgesetzt werden soll
                Console.WriteLine("\nProgramm fortsetzen? ( j / n )");
                bool firstRun = true;
                string eingabe = Console.ReadKey().KeyChar.ToString();
                do
                {
                    if(!firstRun)
                    {
                        Console.WriteLine("\nProgramm fortsetzen? ( j / n )");
                        eingabe = Console.ReadKey().KeyChar.ToString();
                    }

                    switch (eingabe)
                    {
                        case "j":
                            programmFortsetzen = true;
                            break;
                        case "n":
                            programmFortsetzen = false;
                            break;
                        default:
                            Console.WriteLine("\nBitte eine gültige Eingabe machen!");
                            firstRun = false;
                            break;
                    }
                } while (!(eingabe.Equals("j") || eingabe.Equals("n")));
                Console.Clear();
            } while (programmFortsetzen);

            BeendeProgramm();
        }

        // Methode zum beenden des Programms
        public void BeendeProgramm()
        {
            Userinterface ui = new Userinterface();
            ui.GebeBeendeBildschirmAus();
            System.Threading.Thread.Sleep(2000);

            Environment.Exit(0);
        }

        // Geschäftsprozess zum addieren zweier Brüche
        public void BruecheAddieren()
        {
            Userinterface ui = new Userinterface();
            Bruch bruch = new Bruch();

            Bruch1 = ui.LeseBruchEin(1);
            Bruch2 = ui.LeseBruchEin(2);

            ui.GebeTextAus($"\nIhre Eingabe: ({Bruch1.Zaehler}/{Bruch1.Nenner}) + ({Bruch2.Zaehler}/{Bruch2.Nenner})");

            Bruch3 = bruch.Zuweisung(Bruch1.Addiere(Bruch2));
            ui.GebeTextAus($"\nErgebnis: {Bruch3.Zaehler}/{Bruch3.Nenner}");
        }

        // Geschäftsprozess zum subtrahieren zweier Brüche
        public void BruecheSubtrahieren()
        {
            Userinterface ui = new Userinterface();
            Bruch bruch = new Bruch();

            Bruch1 = ui.LeseBruchEin(1);
            Bruch2 = ui.LeseBruchEin(2);

            ui.GebeTextAus($"\nIhre Eingabe: ({Bruch1.Zaehler}/{Bruch1.Nenner}) - ({Bruch2.Zaehler}/{Bruch2.Nenner})");

            Bruch3 = bruch.Zuweisung(Bruch1.Subtrahiere(Bruch2));

            ui.GebeTextAus($"\nErgebnis: {Bruch3.Zaehler}/{Bruch3.Nenner}");
        }

        // Geschäftsprozess zum multiplizieren zweier Brüche
        public void BruecheMultiplizieren()
        {
            Userinterface ui = new Userinterface();
            Bruch bruch = new Bruch();

            Bruch1 = ui.LeseBruchEin(1);
            Bruch2 = ui.LeseBruchEin(2);

            ui.GebeTextAus($"\nIhre Eingabe: ({Bruch1.Zaehler}/{Bruch1.Nenner}) * ({Bruch2.Zaehler}/{Bruch2.Nenner})");

            Bruch3 = bruch.Zuweisung(Bruch1.Multipliziere(Bruch2));
            ui.GebeTextAus($"\nErgebnis: {Bruch3.Zaehler}/{Bruch3.Nenner}");
        }

        // Geschäftsprozess zum dividieren zweier Brüche
        public void BruecheDividieren()
        {
            Userinterface ui = new Userinterface();
            Bruch bruch = new Bruch();

            Bruch1 = ui.LeseBruchEin(1);
            Bruch2 = ui.LeseBruchEin(2);

            ui.GebeTextAus($"\nIhre Eingabe: ({Bruch1.Zaehler}/{Bruch1.Nenner}) / ({Bruch2.Zaehler}/{Bruch2.Nenner})");

            Bruch3 = bruch.Zuweisung(Bruch1.Dividiere(Bruch2));
            ui.GebeTextAus($"\nErgebnis: {Bruch3.Zaehler}/{Bruch3.Nenner}");
        }
    }
}
