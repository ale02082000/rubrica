# rubrica

***
Realizzare un programma che visualizza due griglie; una con un elenco di persone, la'ltra con un elenco di contatti

- prevedere due classi: "Persona" e "Contatto"
- prevedere due file: "persone.csv" e "contatti.csv
- prevedere due griglie che visualizzano il contenuto dei due file


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
