using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Libreria.Libro;

namespace Libreria
{
    //Sarà possibile inserire un nuovo libro,
    //eliminare un libro, modificare un libro o cercare i libri per genere
    class LibreriaManager
    {
        static List<Libro> libri = new List<Libro>();
        static string path = @"C:\Users\princ\source\repos\Esercisi_Week2_Day2\libreriastampa.txt";
        public static void AggiungiLibro()
        {
            //Aggiunta libro

            //Inserimento Titolo
            Libro libro = new Libro();
            Console.WriteLine("Inserisci il titolo del libro da aggiungere");
            libro.Titolo = Console.ReadLine();

            //Aggiunta Autore
            Console.WriteLine("Inserisci l'autore del libro da aggiungere");
            libro.Autore = Console.ReadLine();

            //Aggiunta Genere
            Console.WriteLine("Inserisci il genere del libro da aggiungere");
            libro.Genere = InserisciGenere();

            //Aggiunta Prezzo
            Console.WriteLine("Inserisci il prezzo del libro da aggiungere");
            libro.Prezzo = GestisciPrezzo();

            libri.Add(libro);
        }

        public static void EliminaLibro()
        {
            Console.WriteLine("Inserisci il titolo del libro da eliminare");
            string titolo = Console.ReadLine();
            Libro libroDaEliminare = CercaLibro(titolo);
            if (libroDaEliminare != null)
            {
                libri.Remove(libroDaEliminare);
            }

        }


        public static void ModificaLibro()
        {
            Console.WriteLine("Inserisci il titolo del libro da modificare");
            string titolo = Console.ReadLine();
            Libro libroDaModificare = CercaLibro(titolo);
            libri.Remove(libroDaModificare);
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per modificare il titolo");
                Console.WriteLine("Premi 2 per modificare l'autore");
                Console.WriteLine("Premi 3 per modificare il genere");
                Console.WriteLine("Premi 4 per modificare il prezzo");
                Console.WriteLine("Premi 0 se hai terminato");

                int scelta = 0;
                bool isInt = true;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out scelta);
                } while (!isInt);

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserisci il titolo modificato");
                        libroDaModificare.Titolo = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci l'autore modificato");
                        libroDaModificare.Autore = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Inserisci il genere modificato");
                        libroDaModificare.Genere = InserisciGenere();
                        break;
                    case 4:
                        Console.WriteLine("Inserisci il prezzo modificato");
                        libroDaModificare.Prezzo = GestisciPrezzo();
                        break;
                    case 0:
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);
            libri.Add(libroDaModificare);
        }

        public static void SalvaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Titolo\t\t Autore\t\t Genere\t\t Prezzo");
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {

                foreach (Libro libro in libri)
                {
                    sw.WriteLine($"{libro.Titolo}\t\t {libro.Autore}\t\t {libro.Genere}\t\t {libro.Prezzo}");
                }
            }
        }

        public static void StampaLibri()
        {
            Console.WriteLine("Titolo\t\t Autore\t\t Genere\t\t Prezzo");
            Console.WriteLine();
            foreach (Libro libro in libri)
            {
                Console.WriteLine($"{libro.Titolo}\t\t {libro.Autore}\t\t {libro.Genere}\t\t {libro.Prezzo}");
            }
        }

        public static void StampaLibri(List<Libro> libri)
        {
            StampaLibri(libri);
        }


        public static void FiltraLibri()
        {
            Console.WriteLine("Scegli il genere di libro che vuoi vedere");
            Tipologia tipologiaDaFiltrare = InserisciGenere();
            List<Libro> libriPerGenere = new List<Libro>();
            foreach (Libro libro in libri)
            {
                if (libro.Genere == tipologiaDaFiltrare)
                {
                    libriPerGenere.Add(libro);
                }
            }
            if (libriPerGenere.Count > 0)
            {
                StampaLibri(libriPerGenere);
            }
            else
            {
                Console.WriteLine($"Non sono presenti libri {tipologiaDaFiltrare}");
            }

        }

        public static Libro CercaLibro(string titolo)
        {
            foreach (Libro libro in libri)
            {
                if (libro.Titolo == titolo)
                {
                    return libro;
                }
            }
            return null;
        }

        public static Tipologia InserisciGenere()

        {
            Console.WriteLine($"Premi {(int)Tipologia.Narrativa} per il genere {Tipologia.Narrativa}");
            Console.WriteLine($"Premi {(int)Tipologia.Storico} per il genere {Tipologia.Storico}");
            Console.WriteLine($"Premi {(int)Tipologia.Fantasy} per il genere {Tipologia.Fantasy}");

            bool isInt = true;
            int genere = 0;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out genere);
            } while (!isInt);
            return (Tipologia)genere;


        }

        public static double GestisciPrezzo()
        {
            bool isDouble = true;
            double prezzo = 0;
            do
            {
                isDouble = double.TryParse(Console.ReadLine(), out prezzo);
            } while (!isDouble);

            return prezzo;
        }

        public static void LeggiDaFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string file = sr.ReadToEnd();

                    //se il file è vuoto scrivo un messaggio

                    //bool stringaVuota = String.IsNullOrEmpty(file):
                    //equivale a scrivere file == ""

                    if (String.IsNullOrEmpty(file))
                    {
                        Console.WriteLine("Non ci sono libri!");
                    }
                    else
                    {
                        string[] righeDelMioFile = file.Split("\r\n");
                        //riga 1 -> intestazione (i = 1)
                        //riga 2 -> libri (titolo\t\t autore \t\t ecc ecc
                        //riga e -> libri (titolo\t\t autore \t\t ecc ecc
                        //.....
                        //ultima riga(lunghezzaArray -1) -> vuota


                        for (int i = 1; i < (righeDelMioFile.Length - 1); i++)
                        {
                            Libro libro = new Libro();

                            string riga = righeDelMioFile[i];
                            string[] campiDellaRiga = riga.Split("\t\t");

                            libro.Titolo = campiDellaRiga[0];
                            libro.Autore = campiDellaRiga[1];
                            //Parse(Converte) la string campiDellaStringa a Enum -> il mio enum è typeof(Tipologia)
                            //l'enum è il tipo "ufficiale"
                            //Tipologia è la forzatura che do all'enum
                            libro.Genere = (Tipologia)Enum.Parse(typeof(Tipologia), campiDellaRiga[2]);
                            libro.Prezzo = Convert.ToDouble(campiDellaRiga[3]);

                            libri.Add(libro);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Non ci sono libri!");
            }
        }
    }
}
