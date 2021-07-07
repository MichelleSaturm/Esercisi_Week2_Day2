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
        static string path = @"C:\Users\princ\source\repos\Esercisi_Week2_Day2\file_Banca.txt";

        public static void InserimentoUtente()
        {
            ContoCorrente cc = new ContoCorrente();

            Console.WriteLine();
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
            int numrandom;
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

        public static void Versamento()
        {
            do
            {
                bool isInt;
                int ricerca;

                do
                {
                    Console.WriteLine("Inserisci il Codice del tuo Conto");
                    isInt = int.TryParse(Console.ReadLine(), out ricerca);
                    if (isInt == false)
                    {
                        Console.WriteLine("Hai inserito un valore non corretto!\nRiprova");
                    }
                } while (!isInt);

                ContoCorrente contoVersamento = CercaConto(ricerca);

                if (contoVersamento == null)
                {
                    Console.WriteLine("Hai inserito un conto non esistente");
                }
                else
                {
                    CalcoloVersamento(contoVersamento);
                    break;

                }
            } while (true);
        }

        public static void StampaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Codice Conto\t Nome\t Cognome\t Tipo di Conto\t Saldo");
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (ContoCorrente cc in contiCorrenti)
                {
                    sw.WriteLine($"{cc.NumeroConto}\t\t{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
                }
            }

            Console.WriteLine("Ho salvato su file");
        }

        public static void CalcoloVersamento(ContoCorrente contoVersamento)
        {
            bool isInt;
            double versamento;

            Console.WriteLine($"Salve {contoVersamento.NomeIntestatario} {contoVersamento.CognomeIntestatario}. Nel Conto hai:{contoVersamento.Saldo}");
            Console.WriteLine("Quanto vuoi versare?");
            do
            {
                isInt = double.TryParse(Console.ReadLine(), out versamento);
            } while (!isInt);
            contoVersamento.Saldo = contoVersamento.Saldo + versamento;
            Console.WriteLine($"Hai versato {versamento}.\nIl tuo saldo aggiornato è {contoVersamento.Saldo}");
        }

        public static void Prelievo()
        {
            bool isInt;
            int ricerca;
            do
            {
                do
                {
                    Console.WriteLine("Inserisci il Codice del tuo Conto");
                    isInt = int.TryParse(Console.ReadLine(), out ricerca);
                    if (isInt == false)
                    {
                        Console.WriteLine("Hai inserito un valore non corretto!\nRiprova");
                    }
                } while (!isInt);
                ContoCorrente contoPrelievo = CercaConto(ricerca);

                if (contoPrelievo == null)
                {
                    Console.WriteLine("Hai inserito un conto non esistente");
                }
                else
                {
                    CalcoloPrelievo(contoPrelievo);
                    break;
                }
            } while (true);
        }

        public static void CalcoloPrelievo(ContoCorrente contoPrelievo)
        {
            double prelievo;
            bool isInt;
            Console.WriteLine($"Salve {contoPrelievo.NomeIntestatario} {contoPrelievo.CognomeIntestatario}. " +
                              $"Nel Conto hai:{contoPrelievo.Saldo}");
            do
            {
                Console.WriteLine("Quanto vuoi prelevare?");
                do
                {
                    isInt = double.TryParse(Console.ReadLine(), out prelievo);
                } while (!isInt);
                if (contoPrelievo.Saldo >= prelievo)
                {
                    contoPrelievo.Saldo = contoPrelievo.Saldo - prelievo;
                    Console.WriteLine($"Hai prelevato {prelievo}.\nIl tuo saldo aggiornato è {contoPrelievo.Saldo}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Hai inserito un'importo superiore al tuo saldo.");
                }
            } while (true);
        }

        public static Tipo InserisciTipoDiConto()

        {
            Console.WriteLine($"Premi {(int)Tipo.Corrente} per scegliere un conto di tipo: {Tipo.Corrente}");
            Console.WriteLine($"Premi {(int)Tipo.Risparmio} per scegliere un conto di tipo: {Tipo.Risparmio}");

            bool isInt;
            int tipoconto;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out tipoconto);
            } while (!isInt);
            return (Tipo)tipoconto;


        }

        public static int EliminaConto()
        {
            do
            {

                bool isInt;
                int elimina;
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
                if (contodaeliminare == null)
                {
                    Console.WriteLine("Hai inserito un conto non esistente");
                }
                else
                {
                    contiCorrenti.Remove(contodaeliminare);
                    Console.WriteLine("Ho eliminato il conto corrente");
                    return elimina;

                }
            } while (true);
        }

        public static ContoCorrente CercaConto(int conto)
        {

            foreach (ContoCorrente cc in contiCorrenti)
            {
                if (cc.NumeroConto == conto)
                {
                    return cc;
                }
            }

            return null;
        }

        public static void StampaConti()
        {
            Console.WriteLine("Codice Conto\t Nome\t Cognome\t Tipo di Conto\t Saldo");
            Console.WriteLine();
            foreach (ContoCorrente cc in contiCorrenti)
            {
                Console.WriteLine($"{cc.NumeroConto}\t\t{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
            }
        }

        public static double GestisciSaldo()
        {
            bool isDouble;
            double saldoconto;
            do
            {
                isDouble = double.TryParse(Console.ReadLine(), out saldoconto);
            } while (!isDouble);

            return saldoconto;
        }

        public static void LeggiDaFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string file = sr.ReadToEnd();
                    if (String.IsNullOrEmpty(file))
                    {
                        Console.WriteLine("Non sono presenti file da caricare.");
                    }
                    else
                    {
                        string[] righeDelMioFile = file.Split("\r\n");

                        for (int i = 1; i < (righeDelMioFile.Length - 1); i++)
                        {
                            ContoCorrente cc = new ContoCorrente ();

                            string riga = righeDelMioFile[i];
                            string[] campiDellaRiga = riga.Split("\t\t");

                            cc.NumeroConto = Convert.ToInt32(campiDellaRiga[0]);
                            cc.NomeIntestatario = campiDellaRiga[1];
                            cc.CognomeIntestatario = campiDellaRiga[2];
                            cc.TipoDiConto = (Tipo)Enum.Parse(typeof(Tipo), campiDellaRiga[3]);
                            cc.Saldo = Convert.ToDouble(campiDellaRiga[4]);

                            contiCorrenti.Add(cc);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Non sono presenti file da caricare.");
            }
        }

    }
}
