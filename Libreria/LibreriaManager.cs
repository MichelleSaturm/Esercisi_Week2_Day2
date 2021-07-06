using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    //Sarà possibile inserire un nuovo libro,
    //eliminare un libro, modificare un libro o cercare i libri per genere
    class LibreriaManager
    {
        List<Libro> libri = new List<Libro> ();
        public void AggiungiLibro()
        {
            Libro libro = new Libro();
            Console.WriteLine("Inserisci il titolo del libro da aggiungere");
            libro.Titolo = Console.ReadLine();

            Console.WriteLine("Inserisci l'autore del libro da aggiungere");
            libro.Autore = Console.ReadLine();

            Console.WriteLine("Inserisci il genere del libro da aggiungere");
            libro.Genere = Console.ReadLine();

            bool isDouble = true;
            double prezzo = 0;
            do
            {
                Console.WriteLine("Inserisci il prezzo del libro da aggiungere");
                isDouble = double.TryParse(Console.ReadLine(), out prezzo);
            } while (!isDouble);

            libro.Prezzo = prezzo;

            libri.Add(libro);
        }

        public void EliminaLibro()
        {
            Console.WriteLine("Inserisci il titolo del libro da eliminare");
            string titolo = Console.ReadLine ();
            Libro libroDaEliminare = CercaLibro(titolo);
            if (libroDaEliminare != null)
            {
                libri.Remove(libroDaEliminare);
            }
            
        }

        public Libro CercaLibro(string titolo)
        {
            foreach(Libro libro in libri)
            {
                if (libro.Titolo == titolo)
                {
                    return libro;
                }
            }
            return null;
        }

    }
}
