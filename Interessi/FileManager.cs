using System;
using System.IO;

namespace Interessi
{
    class FileManager
    {
        public static string path2 = @"C:\Users\princ\OneDrive\Desktop\Week2\Esercizio1\CalcInteressi2.txt";
        public static string path = @"C:\Users\princ\OneDrive\Desktop\Week2\Esercizio1\CalcInteressi.txt";

        public static void Indirizzatore(string messaggio, bool scriviInCoda, int formatoInt)
        {
            if (formatoInt == (int)Formato.File)
            {
                ScriviSuFile2(messaggio, scriviInCoda);
            }
            else
            {
                Console.WriteLine(messaggio);
            }
        }




        public static void ScriviSuFile2(string messaggio, bool scriviInCoda)
        {
            using (StreamWriter sw = new StreamWriter(path2, scriviInCoda))
            {
                sw.WriteLine(messaggio);
            }
        }

        public static void ScriviSuFile(string messaggio, int count)
        {
            if (count == 0)
            {
                using (StreamWriter sw = new StreamWriter(path2, false))
                {
                    sw.WriteLine(messaggio);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path2, true))
                {
                    sw.WriteLine(messaggio);
                }
            }
        }
        public static void ScriviSuFile(string messaggio)
        {
            ScriviSuFile(messaggio, 1);
        }

        enum Formato
        {
            File,
            Console
        }

    }
}