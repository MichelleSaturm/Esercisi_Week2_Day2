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

            //Aggiunta Formato
            Console.WriteLine("Inserisci il formato del libro da aggiungere");
            libro.Formato = InserisciFormato();

            //Aggiunta Prezzo
            Console.WriteLine("Inserisci il prezzo del libro da aggiungere");
            libro.Prezzo = GestisciPrezzo();

            libri.Add(libro);
        }

        public static void ModificaLibro()
        {
            Console.WriteLine("Inserisci il titolo del libro da modificare");
            string titolo = Console.ReadLine();

            List<Libro> libriDaModificare = CercaLibro(titolo);

            Libro libroDaModificare = new Libro();

            if (libriDaModificare.Count > 1)
            {
                libroDaModificare = CercaLibroPerAutore(libriDaModificare);
                libri.Remove(libroDaModificare);
            }
            else
            {
                libri.Remove(libriDaModificare[0]);
            }
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per modificare il titolo");
                Console.WriteLine("Premi 2 per modificare l'autore");
                Console.WriteLine("Premi 3 per modificare il genere");
                Console.WriteLine("Premi 4 per modificare il formato");
                Console.WriteLine("Premi 5 per modificare il prezzo");
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
                        Console.WriteLine("Inserisci il formato modificato");
                        libroDaModificare.Formato = InserisciFormato();
                        break;
                    case 5:
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

        public static TipoLibro InserisciFormato()

        {
            Console.WriteLine($"Premi {(int)TipoLibro.Cartaceo} per il formato {TipoLibro.Cartaceo}");
            Console.WriteLine($"Premi {(int)TipoLibro.EBook} per il formato {TipoLibro.EBook}");


            bool isInt = true;
            int formato = 0;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out formato);
            } while (!isInt);
            return (TipoLibro)formato;

        }

        public static void EliminaLibro()
        {
            Console.WriteLine("Inserisci il titolo del libro da eliminare");
            string titolo = Console.ReadLine();

            List<Libro> libriDaEliminare = CercaLibro(titolo);

            if (libriDaEliminare.Count > 1)
            {
                Libro libroDaEliminare = CercaLibroPerAutore(libriDaEliminare);
                libri.Remove(libroDaEliminare);
            }
            else
            {
                libri.Remove(libriDaEliminare[0]);
            }
        }

        public static Libro CercaLibroPerAutore(List<Libro> libriDaEliminare)
        {
            StampaLibri(libriDaEliminare);
            Console.WriteLine("Inserisci l'autore del libro da eliminare");
            string autore = Console.ReadLine();

            foreach (Libro libro in libriDaEliminare)
            {
                if (libro.Autore == autore)
                {
                    return libro;
                }
            }
            return null;
        }

        public static void SalvaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Titolo\t\t Autore\t\t Genere\t\t Formato\t\t Prezzo");
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {

                foreach (Libro libro in libri)
                {
                    sw.WriteLine($"{libro.Titolo}\t\t {libro.Autore}\t\t {libro.Genere}\t\t {libro.Formato}\t\t {libro.Prezzo}");
                }
            }
        }

        public static void StampaLibri()
        {
            Console.WriteLine("Titolo\t\t Autore\t\t Genere\t\t Formato\t\t Prezzo");
            Console.WriteLine();
            foreach (Libro libro in libri)
            {
                Console.WriteLine($"{libro.Titolo}\t\t {libro.Autore}\t\t {libro.Genere}\t\t {libro.Formato}\t\t {libro.Prezzo}");
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

        public static List<Libro> CercaLibro(string titolo)
        {
            List<Libro> libriConTitolo = new List<Libro>();

            foreach (Libro libro in libri)
            {
                if (libro.Titolo == titolo)
                {
                    libriConTitolo.Add(libro);
                }
            }
            return libriConTitolo;
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
                            // "Parsami"(Convertimi) la string campiDellaStringa a Enum -> il mio enum e typeof(Tipologia)
                            //                                                     L'enum è il tipo "ufficiale"
                            //                                                     Tipologia è la forzatura che do all'enum
                            //             Cast esplicito
                            libro.Genere = (Tipologia)Enum.Parse(typeof(Tipologia), campiDellaRiga[2]);
                            //int aaa =                int.Parse(                    "Pippo");
                            //             Cast implicito
                            libro.Formato = (TipoLibro)Enum.Parse(typeof(TipoLibro), campiDellaRiga[3]);
                            libro.Prezzo = Convert.ToDouble(campiDellaRiga[4]);

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
