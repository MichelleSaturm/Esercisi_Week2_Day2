using System;

namespace Interessi
{
    class Program
    {
        // Scrivere una funzione che dato un importo di denaro iniziale,
        // un interesse annuo e un numero di anni permette di calcolare
        // l’importo di denaro accresciuto degli interessi dopo il numero di anni passati

        // Esempio
        // Voglio vincolare 10000 euro per 3 anni con un interesse del 3%

        // Dopo 1 anno : 10000 + (10000 * 3 / 100) = 10000 + 300 = 10300
        // Dopo 2 anni : 10300 + (10300 * 3 / 100) = 10300 + 309 = 10609
        // Dopo 3 anni : 10609 + (10609 * 3 / 100) = 10609 + 318,27 = 10927,27

        static void Main(string[] args)
        {
            CalcoloInteressi.Start();
        }
    }
}