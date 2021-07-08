using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    //I conti hanno
    //Intestatario
    //TipoDiCOnto -> Corrente - Risparmio
    //Saldo

    class ContoCorrente
    {
        //Proprietà
        public int NumeroConto { get; set; }
        public string NomeIntestatario { get; set; }
        public string CognomeIntestatario { get; set; }
        public Tipo TipoDiConto { get; set; }
        public double Saldo { get; set; }


        //Costruttore

        public ContoCorrente()
        {

        }

        public ContoCorrente(int numeroConto, string nome, string cognome, Tipo tipoDiConto)
        {
            NumeroConto = numeroConto;
            NomeIntestatario = nome;
            CognomeIntestatario = cognome;
            TipoDiConto = tipoDiConto;
            Saldo = 100;
        }

        public enum Tipo
        {
            Corrente,
            Risparmio
        }

        public void AggiornaSaldo(double importo)
        {
            Saldo = Saldo + importo;
        }
    }
}
