using System;
using System.Collections.Generic;
using System.IO;

namespace Scuola
{
    class Program
    {
        public static string percorso = @"C:\Users\princ\OneDrive\Desktop\Week2\Esercizio1\mediavoti.txt";
        static void Main(string[] args)
        {
            //Console.WriteLine("Inserisci il tuo nome");
            //string nome = Console.ReadLine();

            //Console.WriteLine("Inserisci il tuo cognome");
            //string cognome = Console.ReadLine();


            Studente p = new Studente();
            Console.WriteLine("Inserisci il nome dello studente");
            p.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognnome dello studente");
            p.Cognome = Console.ReadLine();


            List<int> esami = new List<int>();

            bool isInt = true;
            int votoEsame = 0;

            do
            {
                Console.WriteLine("Inserisci il voto di un esame");
                isInt = int.TryParse(Console.ReadLine(), out votoEsame);
            } while (!isInt);

            esami.Add(votoEsame);

            int continuare = 1;
            bool isInt2 = true;
            while (continuare == 1)
            {
                do
                {
                    Console.WriteLine("Vuoi inserame un altro esame?");
                    Console.WriteLine("Premi 1 per inserire un altro esame");
                    Console.WriteLine("Premi 2 per terminare");
                    isInt2 = int.TryParse(Console.ReadLine(), out continuare);
                } while (!isInt2);
                if (continuare == 1)
                {
                    do
                    {
                        Console.WriteLine("Inserisci il voto di un esame");
                        isInt = int.TryParse(Console.ReadLine(), out votoEsame);
                    } while (!isInt2);

                    esami.Add(votoEsame);
                }
                //else
                //{
                //    break;
                //}
            }

            p.Esami = esami;

            int sommaVotiEsami = 0;
            foreach (int voto in esami)
            {
                sommaVotiEsami = sommaVotiEsami + voto;
            }

            double media = sommaVotiEsami / esami.Count;

            //Console.WriteLine($"Nome: {nome}");
            //Console.WriteLine($"Cognome: {cognome}");
            //Console.WriteLine($"Media Voti: {media}");

            
            using (StreamWriter scrittura = new StreamWriter(percorso))
            {
                scrittura.WriteLine($"Nome\t Cognome\t Media");
                scrittura.WriteLine($"{nome}\t {cognome}\t {media}");
            }
    }
        
}
}

