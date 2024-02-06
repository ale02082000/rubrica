using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace bartolucci.alessandro._4i.rubrica
{ 
 
    public partial class MainWindow : Window
    {
        List<Persona> Persone = new List<Persona>();
        List<Contatto> Contatti = new List<Contatto>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader finPersone = new StreamReader("persone.csv");
                finPersone.ReadLine(); 
                while (!finPersone.EndOfStream)
                {
                    string rigaPersona = finPersone.ReadLine();
                    Persona persona = new Persona(rigaPersona);
                    Persone.Add(persona);
                }
                dgPersone.ItemsSource = Persone; 

                statusBarText.Text = $"Ho letto dal file {Persone.Count} righe";

                
              
                StreamReader finContatti = new StreamReader("contatti.csv");
                finContatti.ReadLine(); 
                while (!finContatti.EndOfStream)
                {
                    string rigaContatto = finContatti.ReadLine();
                    Contatto contatto = new Contatto(rigaContatto);
                    Contatti.Add(contatto);
                } 
                dgContatti.ItemsSource = Contatti;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        } 
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
    }
}
