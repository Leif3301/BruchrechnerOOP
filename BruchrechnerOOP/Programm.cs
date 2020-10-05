/*
 Autor:         Dennis Frank
 Dateiname:     Main.cs
 Klasse:        IA219
 Datum:         20.09.2020
 Beschreibung:  Diese Klasse dient als Einstiegsklasse
 Änderung:      05.10.2020
 */
using BruchrechnerOOP.Controller;
using BruchrechnerOOP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP
{
    class Programm
    {
        private Programmsteuerung _programmsteuerung;

        public Programmsteuerung Programmsteuerung
        {
            get { return _programmsteuerung; }
            set { _programmsteuerung = value; }
        }
        static void Main(string[] args)
        {
            Programmsteuerung verwalter = new Programmsteuerung();
            verwalter.run();
        }
    }
}
