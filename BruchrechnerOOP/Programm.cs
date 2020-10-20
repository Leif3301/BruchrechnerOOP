/*
 Autor:         Dennis Frank
 Dateiname:     Main.cs
 Klasse:        IA219
 Datum:         20.09.2020
 Beschreibung:  Dient als Hauptklasse
 Änderung:      05.10.2020, 15.10.2020, 20.10.2020
 */
using BruchrechnerOOP.Controller;

namespace BruchrechnerOOP
{
    // Dient als Hauptklasse
    class Programm
    {
        // Fungiert als Einstieg in das Programm
        static void Main(string[] args)
        {
            Programmsteuerung programmsteuerung = new Programmsteuerung();
            programmsteuerung.run();
        }
    }
}
