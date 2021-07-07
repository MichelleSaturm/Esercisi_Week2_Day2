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

            //Console.WriteLine("Inserisci il numero del conto");
            //cc.NumeroConto = Console.ReadLine();

            Console.WriteLine("Inserisci il nome dell'intestatario");
            cc.NomeIntestatario = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome dell'intestatario");
            cc.CognomeIntestatario = Console.ReadLine();

            Console.WriteLine("Inserisci la tipologia del conto");
            cc.TipoDiConto = InserisciTipoDiConto();

            Console.WriteLine("Inserisci saldo del conto");
            cc.Saldo = GestisciSaldo();

            contiCorrenti.Add(cc);
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

        //public static void EliminaConto()
        //{
        //    throw new NotImplementedException();
        //}

        public static void StampaConti()
        {
            Console.WriteLine("Nome Intestatario\t\t Cognome Intestatario\t\t Tipo di Conto\t\t Saldo");
            Console.WriteLine();
            foreach (ContoCorrente cc in contiCorrenti)
            {
                Console.WriteLine($"{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
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
