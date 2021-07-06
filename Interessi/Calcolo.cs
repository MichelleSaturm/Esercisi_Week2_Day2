using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interessi
{
    class CalcoloInteressi
    {
        public static void Start()
        {
            int interesseAnnuo = 3;

            double importoDaVincolare = ChiediImportoDaVincolare();
            int anni = ChiediAnniDelVincolo();

            int tipoDiOutput = ChiediDoveVuoleStampare();

            //Iterazione
            InteressiIterazione(importoDaVincolare, anni, interesseAnnuo, tipoDiOutput);

            //Ricorsione
            //double importoFinale = InteressiRicorsione(importoDaVincolare, anni, interesseAnnuo);
            //Console.WriteLine($"Dopo {anni} anni da {importoDaVincolare} avrai {importoFinale}");
        }

        private static int ChiediAnniDelVincolo()
        {
            int anni = 0;
            bool isInt = true;
            do
            {
                Console.WriteLine("Per quanti anni?");
                isInt = int.TryParse(Console.ReadLine(), out anni);

            } while (!isInt);

            return anni;
        }

        private static double ChiediImportoDaVincolare()
        {
            double importoDaVincolare = 0;
            bool isDouble = true;
            do
            {
                Console.WriteLine("Quanto importo vuoi vincolare?");
                isDouble = double.TryParse(Console.ReadLine(), out importoDaVincolare);

            } while (!isDouble);

            return importoDaVincolare;
        }

        private static int ChiediDoveVuoleStampare()
        {
            int tipoDiOutput = 0;
            bool isInt = true;
            do
            {
                Console.WriteLine("Premi 0 per stampare su file, premi 1 per stampare a video");
                isInt = int.TryParse(Console.ReadLine(), out tipoDiOutput);
            } while (!isInt);

            return tipoDiOutput;
        }



        //Iterazione

        public static double InteressiIterazione(double importoDaVincolare, int anni, double interesseAnnuo, int tipoDiOutput)
        {
            double importoConInteressi = importoDaVincolare;

            for (var i = 0; i < anni; i++)
            {
                double importoAnnoPrecedente = importoConInteressi;
                double interessi = importoConInteressi * interesseAnnuo / 100;
                importoConInteressi = importoConInteressi + interessi;

                //Console.WriteLine($"Dopo {i + 1} anni, da {importoAnnoPrecedente} avrai maturato {interessi} " +
                //                  $"e il tuo nuovo capitale sarà {importoConInteressi}");
                string messaggio = $"Dopo {i + 1} anni, da {importoAnnoPrecedente } avrai maturato {interessi} " +
                    $"e il tuo nuovo capitale sarà {importoConInteressi}";

                FileManager.Indirizzatore(messaggio, true, 0);

                //FileManager.ScriviSuFile(messaggio, i);

                if (i == 0)
                {
                    FileManager.Indirizzatore(messaggio, false, tipoDiOutput);
                    //FileManager.ScriviSuFile2(messaggio, false);
                }
                else
                {
                    FileManager.Indirizzatore(messaggio, true, tipoDiOutput);
                    //FileManager.ScriviSuFile2(messaggio, true);
                }
            }

            //Console.WriteLine($"Quindi alla fine avrai {importoConInteressi}");
            string messaggioFinale = $"Quindi alla fine avrai {importoConInteressi}";
            FileManager.Indirizzatore(messaggioFinale, true, tipoDiOutput);
            //FileManager.ScriviSuFile(messaggioFinale);
            //FileManager.ScriviSuFile2(messaggioFinale, true);

            return importoConInteressi;
        }



        public static double InteressiRicorsione(double importo, int anni, double interesseAnnuo)
        {
            if (anni > 0)
            {
                return InteressiRicorsione((importo + (importo * interesseAnnuo / 100)), anni - 1, interesseAnnuo);
            }
            else
            {
                return importo;
            }
        }
    }
}