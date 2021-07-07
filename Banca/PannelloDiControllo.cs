using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    class PannelloDiControllo
    {
        public static void Start()
        {
            Console.WriteLine("Cosa vuoi fare?");
            bool continuare = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Premi 1 per aggiungere un conto");
                Console.WriteLine("Premi 2 per eliminare un conto");
                Console.WriteLine("Premi 3 per visualizzare i conti inseriti");
                //Console.WriteLine("Premi 4 per fare un prelievo in un conto");
                //Console.WriteLine("Premi 5 per fare un versamento in un conto");
                Console.WriteLine("Premi 0 se hai terminato");

                int choice = 0;
                bool isInt = true;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);

                switch (choice)
                {
                    case 1:
                        BankManager.InserimentoUtente();
                        break;
                    case 2:
                        BankManager.EliminaConto();
                        break;
                    case 3:
                        BankManager.StampaConti();
                        break;
                    //case 4:
                    //    BankManager.Prelievo();
                    //    break;
                    //case 5:
                    //    BankManager.Versamento();
                    //    break;
                    case 0:
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);

        }

    }
}
