# rubrica

***
Realizzare un programma che visualizza due griglie; una con un elenco di persone, la'ltra con un elenco di contatti

- prevedere due classi: "Persona" e "Contatto"
- prevedere due file: "persone.csv" e "contatti.csv
- prevedere due griglie che visualizzano il contenuto dei due file

- Modificare il progetto UnoAMolti2 in modo che 
- abbia una classe Persone che deriva da List<Persona>
- abbia una classe Contatti che deriva da List<Contatto>
- utilizzi la classe Contatto come base
- abbia una serie di classi derivate ContattoEmail, ContattoWeb etc etc
- utilizzi i costruttori di Persone e Contatti per leggere i rispettivi file


<img src="https://github.com/ale02082000/rubrica/assets/127590077/fa8cdde7-aa9a-4015-b6fe-d6f83eaf5f0b">


***


``` c#
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

``` 

***
Il codice definisce una classe chiamata Persona.
Questa classe ha tre proprietà: IdPersona, Nome, e Cognome.
La classe ha due costruttori. Il primo è un costruttore vuoto.
Il secondo costruttore prende una stringa riga come parametro,  essa viene suddivisa in una serie di campi utilizzando il carattere ; come delimitatore.
Questi campi sono l'ID della persona, il nome e il cognome.
Nel progetto c'è anche la classe Contatto, con una struttura simile a questa.
***


``` c#

  private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;
            statusBarText.Text = $"{p.Cognome}";

            List<Contatto> contattiFiltrati = new List<Contatto>();
            foreach(var item in Contatti)
                if(item.IdPersona == p.IdPersona)
                    contattiFiltrati.Add(item);

            dgContatti.ItemsSource = contattiFiltrati;

        }
```
***
Il metodo dgDati_SelectionChanged gestisce l'evento di selezione cambiata nel DataGrid dgDati.
Quando un'istanza di Persona viene selezionata, il metodo estrae l'ID di quella persona e filtra i contatti associati a essa. Successivamente, i contatti filtrati vengono visualizzati nel DataGrid dgContatti.
Nello xaml.cs vengono create due liste in cui si caricano le informazioni prese dai due file csv (persone.csv) e (contatti.csv).

***

```

public class Contatti : List<Contatto>
    {
        public Contatti()
        {

        }

        public Contatti(string Nomefile)
        {

            StreamReader finContatti = new StreamReader(Nomefile);
            finContatti.ReadLine();
            while (!finContatti.EndOfStream)
            
                this.Add( Contatto.MakeContatto(finContatti.ReadLine()));

              
            
            finContatti.Close();
        }


***

Dopo aver studiato l'ereditarietà e il polimorfismo , abbiamo implementato questo codice:
definisce una classe chiamata Contatti che eredita dalla classe List<Contatto>,
Il secondo costruttore (public Contatti(string Nomefile)) legge un file di testo dal percorso specificato dal parametro Nomefile. Per ogni riga, chiama un metodo statico MakeContatto() della classe Contatto per creare un nuovo oggetto Contatto, che viene quindi aggiunto alla lista Contatti. Infine, il file viene chiuso dopo aver terminato la lettura.

***


