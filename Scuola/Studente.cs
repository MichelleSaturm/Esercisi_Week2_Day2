﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola
{
    class Studente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<int> Esami { get; set; }
    }

    public Studente(string nome, string cognome, int esami)
    {
       
    }

    public string OttieniDati()
    {
        string dati = $"Ciao mi chiamo {Nome} {Cognome} e ho {Età} anni";
        return dati;
    }

}
