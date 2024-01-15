using System;
using System.Windows;

namespace LiigaJoukkueSovellus
{
    public partial class MainWindow : Window
    {
        private Joukkue liigaJoukkue;

        public MainWindow()
        {
            InitializeComponent();
            liigaJoukkue = new Joukkue("HIFK", "Helsinki");
        }

        private void LisaaPelaajaButton_Click(object sender, RoutedEventArgs e)
        {
            string etunimi = PromptUser("Anna pelaajan etunimi:");
            string sukunimi = PromptUser("Anna pelaajan sukunimi:");

            int pelaajaNumero;
            if (!int.TryParse(PromptUser("Anna pelaajan numero:"), out pelaajaNumero))
            {
                MessageBox.Show("Virheellinen numero. Anna kokonaisluku.");
                return;
            }

            try
            {
                Pelaaja uusiPelaaja = new Pelaaja(etunimi, sukunimi, pelaajaNumero);
                liigaJoukkue.LisaaPelaaja(uusiPelaaja);
                PaivitaPelaajatListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe: {ex.Message}");
            }
        }

        private void PoistaPelaajaButton_Click(object sender, RoutedEventArgs e)
        {
            int pelaajaNumero;
            if (!int.TryParse(PromptUser("Anna pelaajan numero, jonka haluat poistaa:"), out pelaajaNumero))
            {
                MessageBox.Show("Virheellinen numero. Anna kokonaisluku.");
                return;
            }

            try
            {
                liigaJoukkue.PoistaPelaaja(pelaajaNumero);
                PaivitaPelaajatListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe: {ex.Message}");
            }
        }

        private void NaytaPelaajatButton_Click(object sender, RoutedEventArgs e)
        {
            PaivitaPelaajatListBox();
        }

        private void PaivitaPelaajatListBox()
        {
            PelaajaListBox.ItemsSource = liigaJoukkue.HaePelaajat();
        }

        private string PromptUser(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Syötä tieto", "");
        }
    }
}
