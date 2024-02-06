using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bartolucci.alessandro._4i.rubrica
{
    internal class Persona
    {
        public int IdPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }


        public Persona()
        {

        }



        public Persona(string riga)
        {

            string[] campi = riga.Split(';');

            int Id = 0;
            int.TryParse(campi[0], out Id);
            IdPersona = Id;
            
                
                this.Nome = campi[1];
                this.Cognome = campi[2];
               
          


        }







    }
}
