using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{

    //  Un libro è un'entità che ha
    //Titolo
    //Autore
    //Genere
    //Prezzo

    class Libro
    {
        //Proprietà
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public double Prezzo { get; set; }


        //Costruttore

        public Libro()
        {

        }
    }
}
