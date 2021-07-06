using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classi
{
    class Persona
    {
        //Proprietà

        //shortcut -> prop tab tab

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età { get; set; }
        public string CodiceFiscale { get; set; }


        //Costruttori
        //shortcut -> ctor tab tab

        public Persona()
        {

        }

        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        //Metodi

        public string OttieniDati()
        {
            string dati = $"Ciao mi chiamo {Nome} {Cognome} e ho {Età} anni";
            return dati;
        }

    }
}
