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

        public enum Tipo
        {
            Corrente,
            Risparmio
        }
    }
}
