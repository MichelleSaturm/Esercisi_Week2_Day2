using System;

namespace Classi
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona();
            Console.WriteLine("Inserisci il nome dello studente");
            p.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognnome dello studente");
            p.Cognome = Console.ReadLine();
            p.Età = 20;

            Persona p2 = new Persona("Michela", "Murtas");

            p.CodiceFiscale = "MRTMHL...";

            string nome = p.Nome;

            string dati = p.OttieniDati();

            Console.WriteLine(dati);
        }
    }
}
