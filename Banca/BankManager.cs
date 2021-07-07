using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Banca.ContoCorrente;

namespace Banca
{//Un utente può creare un conto
 //Un utente piò eliminare un conto

    class BankManager
    {
        static List<ContoCorrente> contiCorrenti = new List<ContoCorrente>();

        public static void InserimentoUtente()
        {
            ContoCorrente cc = new ContoCorrente();


            Console.WriteLine("Inserisci il nome dell'intestatario");
            cc.NomeIntestatario = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome dell'intestatario");
            cc.CognomeIntestatario = Console.ReadLine();

            Console.WriteLine("Inserisci la tipologia del conto");
            cc.TipoDiConto = InserisciTipoDiConto();

            Console.WriteLine("Inserisci saldo del conto");
            cc.Saldo = GestisciSaldo();

            cc.NumeroConto = InserimentoCodice();

            contiCorrenti.Add(cc);
            Console.WriteLine($"Complimenti. Hai completato la registrazione del Conto Corrente.\nIl codice associato al Conto Corrente è: {cc.NumeroConto}");
        }

        public static int InserimentoCodice()
        {
            List<int> numerirandom = new List<int>();
            int numrandom = 0;
            bool flag = false;
            do
            {
                Random random = new Random();
                numrandom = random.Next(100, 200);

                if (numerirandom.Contains(numrandom))
                {
                    flag = false;
                }
                else
                {
                    numerirandom.Add(numrandom);
                    flag = true;
                }
            } while (!flag);
            return numrandom;
        }

        public static Tipo InserisciTipoDiConto()

        {
            Console.WriteLine($"Premi {(int)Tipo.Corrente} per scegliere un conto di tipo: {Tipo.Corrente}");
            Console.WriteLine($"Premi {(int)Tipo.Risparmio} per scegliere un conto di tipo: {Tipo.Risparmio}");

            bool isInt = true;
            int tipoconto = 0;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out tipoconto);
            } while (!isInt);
            return (Tipo)tipoconto;


        }

        public static int EliminaConto()
        {
            bool isInt = true;
            int elimina = 0;
            Console.WriteLine("Inserisci il codice del conto che vuoi eliminare");
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out elimina);
                if (isInt == false)
                {
                    Console.WriteLine("Hai inserito un valore non corretto!\nRiprova");
                }
            } while (!isInt);

            ContoCorrente contodaeliminare = CercaConto(elimina);
            contiCorrenti.Remove(contodaeliminare);

            return elimina;

        }

        public static ContoCorrente CercaConto(int elimina)
        {
            bool flag = false;
            List<ContoCorrente> idutente = new List<ContoCorrente>();
            do
            {
                foreach (ContoCorrente cc in contiCorrenti)
                {
                    if (cc.NumeroConto == elimina)
                    {
                        idutente.Add(cc);
                        flag = true;
                        return cc;
                    }
                    else
                    {
                        Console.WriteLine("Il numero inserito non corrisponde a nessun conto.");
                        
                    }
                }
                return null;
            } while (!flag);

        }

        public static void StampaConti()
        {
            Console.WriteLine("Codice Conto\t Nome Intestatario\t Cognome Intestatario\t Tipo di Conto\t Saldo");
            Console.WriteLine();
            foreach (ContoCorrente cc in contiCorrenti)
            {
                Console.WriteLine($"{cc.NumeroConto}\t\t{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
            }
        }

        public static double GestisciSaldo()
        {
            bool isDouble = true;
            double saldoconto = 0;
            do
            {
                isDouble = double.TryParse(Console.ReadLine(), out saldoconto);
            } while (!isDouble);

            return saldoconto;
        }
    }
}
