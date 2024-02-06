﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bartolucci.alessandro._4i.rubrica
{
    public enum TipoContatto { nessuno, Email, Telefono, Web, Instagram, Facebook, Cellulare }
    internal class Contatto
    {


        public int IdPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }


        public Contatto() {
            Tipo = TipoContatto.nessuno;

        }
        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');

            int Id = 0;
            int.TryParse(campi[0], out Id);
            IdPersona = Id;

            TipoContatto c;
            Enum.TryParse(campi[1], out c);
            this.Tipo = c;

            this.Valore = campi[2];



         

              
           


        }



    }
}

