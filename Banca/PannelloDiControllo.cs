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
            Console.WriteLine("Benvenuto nella tua banca di fiducia!\nQuale operazione vuoi eseguire?");
            BankManager.LeggiDaFile();
            bool continuare = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---- Pannello Utente ----");
                Console.WriteLine("1 - Apri un nuovo Conto");
                Console.WriteLine("2 - Elimina un Conto");
                Console.WriteLine("3 - Effettua un Prelievo");
                Console.WriteLine("4 - Effettua un Versamento");

                Console.WriteLine();
                Console.WriteLine("---- Pannello Bancario ----");
                Console.WriteLine("5 - Visualizza i Conti presenti nella Banca ");
                Console.WriteLine("6 - Salva i Conti su File ");

                Console.WriteLine();
                Console.WriteLine("---- Uscita ----");
                Console.WriteLine("Premi 0 se hai terminato");

                Console.WriteLine();
                Console.Write("Inserisci la tua scelta:");

                
                


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
                        BankManager.Prelievo(); 
                        break;
                    case 4:
                        BankManager.Versamento();
                        break;
                    case 5:
                        BankManager.StampaConti(); 
                        break;
                    case 6:
                        BankManager.StampaSuFile();
                        break;
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
