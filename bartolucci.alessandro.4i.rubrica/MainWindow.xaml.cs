using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace bartolucci.alessandro._4i.rubrica
{

    public partial class MainWindow : Window
    {
        Persone Persone;
        Contatti contatti;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Persone = new ("Persone.csv");
                dgPersone.ItemsSource = Persone;

                statusBarText.Text = $"Ho letto dal file {Persone.Count} persone";

                contatti = new ("Contatti.csv");

                statusBarText.Text = $"Ho letto dal file " +
                    $"{Persone.Count}  persone e " +
                    $"{contatti.Count} contatti";



                // dgContatti.ItemsSource = Contatti;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }
        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;
            if (p != null)
            {
                statusBarText.Text = $" Hai selezionato {p.Nome} {p.Cognome}";

                Contatti contattiFiltrati = new();
                foreach (var item in contatti)
                    if (item.IdPersona == p.IdPersona)
                        contattiFiltrati.Add(item);

                dgContatti.ItemsSource = contattiFiltrati;

            }

        }
        private void adOgniRiga(object sender, DataGridRowEventArgs e)
        {

            Persona p = e.Row.Item as Persona;

            if (p != null)
            {
                if (p.IdPersona == 1)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;

                }

            }
            
        }

        private void dgContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

