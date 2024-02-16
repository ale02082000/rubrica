using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bartolucci.alessandro._4i.rubrica
{
      public class Persona
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
                 if (campi.Count() != 3)
            {
                throw new Exception("Le righe del file contatti.csv, devono essere di tre colonne"); 
            }

            int Id = 0;
            int.TryParse(campi[0], out Id);
            IdPersona = Id;
            
                
                this.Nome = campi[1];
                this.Cognome = campi[2];
               
          


        }







    }

    public class  Persone : List<Persona>
    {
        public Persone()
        {

        }

        public Persone(string Nomefile)
        {

            StreamReader finPersone = new StreamReader(Nomefile);
           finPersone.ReadLine();
            while (!finPersone.EndOfStream)
            
                this.Add(new Persona(finPersone.ReadLine()));

                
            
            finPersone.Close();
        }

    }
    

}
