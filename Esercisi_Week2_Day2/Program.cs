using System;
using System.IO;

namespace Esercisi_Week2_Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\princ\OneDrive\Desktop\Week2\Esercizio1\Prova.txt";
            #region
            //Scrittura su file con chiusura manuale
            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine("Ciao a tutte!");
            sw.Close();
            #endregion

            //scrittura su file con chiusura automatica

            using (StreamWriter sw1 = new StreamWriter(path))
            {
                sw1.WriteLine("Come state?");
            }

            using (StreamWriter sw1 = new StreamWriter(path, true)) //con true non cancella "come state" ma aggiunge righe
            {
                sw1.WriteLine("Io bene!");
            }


            //Lettura

            //Lettura tutto il file 
            using (StreamReader sw1 = new StreamReader(path))
            {
                string contenutoFile = sw1.ReadToEnd();
            }

            //Lettura linea
            using (StreamReader sw1 = new StreamReader(path))
            {
                string contenutoRiga = sw1.ReadLine();
            }


            //Lettura lettura tutto il file con divisione per righe
            using (StreamReader sw1 = new StreamReader(path))
            {
                string contenutoFile = sw1.ReadToEnd();
                var arrayDiRighe = contenutoFile.Split("\r\n"); //crea una riga vuota (ultima posizione)
            }
        }
    }
}
