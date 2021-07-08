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
            Console.WriteLine("Benvenuto nella tua banca di fiducia!");
            BankManager.InserimentoDatiDaFile();
            bool continuare = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---- Pannello Utente ----");
                Console.WriteLine("1 - Apri un nuovo Conto");
                Console.WriteLine("2 - Effettua un Prelievo");
                Console.WriteLine("3 - Effettua un Versamento");

                Console.WriteLine();
                Console.WriteLine("---- Pannello Bancario ----");
                Console.WriteLine("4 - Elimina un Conto");
                Console.WriteLine("5 - Visualizza i Conti presenti nella Banca ");
                Console.WriteLine("6 - Filtra i Conti per Tipo ");

                Console.WriteLine();
                Console.WriteLine("---- Uscita ----");
                Console.WriteLine("0 - Exit");

                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");

                
                


                int choice;
                bool isInt;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);

                switch (choice)
                {
                    case 1:
                        //BankManager.InserimentoUtente();
                        BankManager.InserimentoUtente2();
                        break;
                    case 2:
                        BankManager.Prelievo();
                        break;
                    case 3:
                        BankManager.Versamento(); 
                        break;
                    case 4:
                        BankManager.EliminaConto(); 
                        break;
                    case 5:
                        BankManager.StampaConti(); 
                        break;
                    case 6:
                        BankManager.FiltraConti();
                        break;
                    case 0:
                        BankManager.SalvaSuFile();
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
