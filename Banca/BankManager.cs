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

    //Per aprire un nuovo conto bisogna inserire almeno 100€
    //Da Corrente -> sia prelievo che versamento
    // Da Risparmio -> SOLO VERSAMENTO

    class BankManager
    {
        //Lista e percorso file in cima per essere accessibili a tutti
        static List<ContoCorrente> contiCorrenti = new List<ContoCorrente>();
        static string path = @"C:\Users\princ\source\repos\Esercisi_Week2_Day2\file_Banca.txt";

        //Inserimento dei dati dell'utente
        //public static void InserimentoUtente()
        //{
        //    ContoCorrente cc = new ContoCorrente();

        //    Console.WriteLine();
        //    Console.WriteLine("Inserisci il nome dell'intestatario");
        //    cc.NomeIntestatario = Console.ReadLine();

        //    Console.WriteLine("Inserisci il cognome dell'intestatario");
        //    cc.CognomeIntestatario = Console.ReadLine();

        //    Console.WriteLine("Inserisci la tipologia del conto");
        //    cc.TipoDiConto = InserisciTipoDiConto();

        //    Console.WriteLine("Inserisci saldo del conto");
        //    cc.Saldo = GestisciSaldo();

        //    cc.NumeroConto = GeneratoreNumeriUtente();

        //    contiCorrenti.Add(cc);
        //    Console.WriteLine($"Complimenti. Hai completato la registrazione del Conto Corrente.\nIl codice associato al Conto Corrente è: {cc.NumeroConto}");

        //}

        //Inserimento del tipo del conto (Corrente/Risparmio)
        public static Tipo InserisciTipoDiConto()

        {
            Console.WriteLine($"Premi {(int)Tipo.Corrente} per scegliere un conto di tipo: {Tipo.Corrente}");
            Console.WriteLine($"Premi {(int)Tipo.Risparmio} per scegliere un conto di tipo: {Tipo.Risparmio}");

            bool isInt;
            int tipoConto;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out tipoConto);
            } while (!isInt || tipoConto < 0 || tipoConto > 1);
            return (Tipo)tipoConto;
        }

        //Verifica Importo
        //public static double GestisciSaldo()
        //{
        //    bool isDouble;
        //    double saldoconto;
        //    do
        //    {
        //        isDouble = double.TryParse(Console.ReadLine(), out saldoconto);
        //    } while (!isDouble);

        //    return saldoconto;
        //}

        //Filtra i Conti per tipo di conto
        internal static void FiltraConti()
        {
            Console.WriteLine("Quale tipologia di conto vuoi mostrare?");
            Tipo filtro = InserisciTipoDiConto();
            List<ContoCorrente> contiFiltrati = new List<ContoCorrente>();
            foreach (ContoCorrente cc in contiCorrenti)
            {
                if (cc.TipoDiConto == filtro)
                {
                    contiFiltrati.Add(cc);
                }
            }
            if (contiFiltrati.Count > 0)
            {
                Console.WriteLine("Codice Conto\t Nome\t Cognome\t Tipo di Conto\t Saldo");
                Console.WriteLine();
                foreach (ContoCorrente cc in contiFiltrati)
                {
                    Console.WriteLine($"{cc.NumeroConto}\t\t{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
                }
            }
            else
            {
                Console.WriteLine($"Non sono presenti libri {filtro}");
            }
        }

        //Generatore numeri utenti casuali con controllo che non escano doppioni
        public static int GeneratoreNumeriUtente()
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

        //Elimina il conto [Inserito il metodo con il count]
        public static int EliminaConto()
        {
            //Metodo con il count
            //Console.WriteLine("Inserisci il numero del conto che vuoi eliminare");
            //StampaConti();

            //bool isInt = false;
            //int numConto = 0;
            //do
            //{
            //    isInt = int.TryParse(Console.ReadLine(), out numConto);
            //} while (!isInt || numConto < 0 || numConto > contiCorrenti.Count);
            //ContoCorrente contoDaEliminare = contiCorrenti.ElementAt(numConto - 1);
            //contiCorrenti.Remove(contoDaEliminare);

            do
            {
                bool isInt;
                int elimina;

                StampaConti();

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

        //Ricerca Conto con Numero di Conto
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

        //Stampa a Video i Conti presenti [Inserito Metodo con il Count]

        public static void StampaConti()
        {
            //Metodo con il counter
            //if (contiCorrenti.Count > 0)
            //{
            //    Console.WriteLine("Codice Conto\t Nome\t Cognome\t Tipo di Conto\t Saldo");
            //    Console.WriteLine();
            //    int count = 1;
            //    foreach (ContoCorrente cc in contiCorrenti)
            //    {
            //        Console.WriteLine($"{count}\t\t{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
            //        count++;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Non sono ancora presenti conti");
            //}

            Console.WriteLine("Codice Conto\t Nome\t Cognome\t Tipo di Conto\t Saldo");
            Console.WriteLine();
            foreach (ContoCorrente cc in contiCorrenti)
            {
                Console.WriteLine($"{cc.NumeroConto}\t\t{cc.NomeIntestatario}\t\t {cc.CognomeIntestatario}\t\t {cc.TipoDiConto}\t\t {cc.Saldo}");
            }
        }

        //Versamento sul Saldo
        public static void Versamento()
        {
            StampaConti();
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

        //Calcolo del Versamento
        public static void CalcoloVersamento(ContoCorrente contoVersamento)
        {
            bool isDouble;
            double versamento;

            Console.WriteLine($"Salve {contoVersamento.NomeIntestatario} {contoVersamento.CognomeIntestatario}. Nel Conto hai:{contoVersamento.Saldo}");
            Console.WriteLine("Quanto vuoi versare?");
            do
            {
                isDouble = double.TryParse(Console.ReadLine(), out versamento);
            } while (!isDouble);
            contoVersamento.Saldo += versamento;
            Console.WriteLine($"Hai versato {versamento}.\nIl tuo saldo aggiornato è {contoVersamento.Saldo}");
        }

        //Prelievo sul saldo
        public static void Prelievo()
        {
            bool isInt;
            int ricerca;
            StampaConti();
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
                int tipo = (int)contoPrelievo.TipoDiConto;

                if (contoPrelievo == null)
                {
                    Console.WriteLine("Hai inserito un conto non esistente");
                }
                else
                {
                    if (tipo == 1)
                    {
                        Console.WriteLine($"Mi dispiace {contoPrelievo.NomeIntestatario} {contoPrelievo.CognomeIntestatario}, hai un conto di tipo {contoPrelievo.TipoDiConto} e ti è permesso solamente fare dei versamenti.");
                        break;
                    }
                    else
                    {
                        CalcoloPrelievo(contoPrelievo);
                        break;
                    }
                }
            } while (true);

            //Altro Metodo
            //StampaConti();
            //ContoCorrente cc = Metodo();

            //contiCorrenti.Remove(cc)

            //    bool isDouble = false;
            //double importo = 0;
            //do
            //{ 
            //    Console.WriteLine(""); 
            //}
        }

        //Calcolo con il controllo della somma
        public static void CalcoloPrelievo(ContoCorrente contoPrelievo)
        {
            double prelievo;
            bool isDouble;
            Console.WriteLine($"Salve {contoPrelievo.NomeIntestatario} {contoPrelievo.CognomeIntestatario}. " +
                              $"Nel Conto hai:{contoPrelievo.Saldo}");
            do
            {
                Console.WriteLine("Quanto vuoi prelevare?");
                do
                {
                    isDouble = double.TryParse(Console.ReadLine(), out prelievo);
                } while (!isDouble);
                if (contoPrelievo.Saldo >= prelievo)
                {
                    contoPrelievo.Saldo = contoPrelievo.Saldo - prelievo;
                    Console.WriteLine($"Hai prelevato {prelievo}.\nIl tuo saldo aggiornato è {contoPrelievo.Saldo}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Hai inserito un'importo superiore al tuo saldo. Riprova");
                }
            } while (true);
        }

        //Salvataggio sul File
        public static void SalvaSuFile()
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
        }


        public static void InserimentoDatiDaFile()
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
                        string[] contenutoFile = file.Split("\r\n");

                        for (int i = 1; i < (contenutoFile.Length - 1); i++)
                        {
                            ContoCorrente cc = new ContoCorrente();

                            string dati = contenutoFile[i];
                            string[] righe = dati.Split("\t\t");

                            cc.NumeroConto = Convert.ToInt32(righe[0]);
                            cc.NomeIntestatario = righe[1];
                            cc.CognomeIntestatario = righe[2];
                            cc.TipoDiConto = (Tipo)Enum.Parse(typeof(Tipo), righe[3]);
                            cc.Saldo = Convert.ToDouble(righe[4]);

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


        public static void InserimentoUtente2()
        {
            Console.WriteLine();
            Console.WriteLine("Inserisci il nome dell'intestatario");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome dell'intestatario");
            string cognome = Console.ReadLine();

            Console.WriteLine("Inserisci la tipologia del conto");
            Tipo tipoDiConto = InserisciTipoDiConto();
            //Console.WriteLine($"Premi {(int)Tipo.Corrente} per scegliere un conto di tipo: {Tipo.Corrente}");
            //Console.WriteLine($"Premi {(int)Tipo.Risparmio} per scegliere un conto di tipo: {Tipo.Risparmio}");

            //bool isInt;
            //int tipoConto;
            //do
            //{
            //    isInt = int.TryParse(Console.ReadLine(), out tipoConto);
            //} while (!isInt || tipoConto < 0 || tipoConto > 1);
            //Tipo tipoDiConto = (Tipo)tipoConto;

            int numeroConto = GeneratoreNumeriUtente();
            Console.WriteLine($"Complimenti. Hai completato la registrazione del Conto Corrente.\nIl codice associato al Conto Corrente è: {numeroConto}");

            ContoCorrente cc = new ContoCorrente(numeroConto, nome, cognome, tipoDiConto);
            contiCorrenti.Add(cc);

        }
    }
}
