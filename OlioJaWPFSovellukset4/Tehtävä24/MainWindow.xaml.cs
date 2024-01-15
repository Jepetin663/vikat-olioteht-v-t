using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LottoSovellus
{
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();
        private List<List<int>> arvotutRivit = new List<List<int>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TulostaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rivienMaara = int.Parse(RivienMaaraTextBox.Text);
                string peli = ((ComboBoxItem)PelivalintaComboBox.SelectedItem).Content.ToString();
                List<List<int>> tulokset = ArvoRivit(peli, rivienMaara);
                TulostaRivit(tulokset);
            }
            catch (FormatException)
            {
                MessageBox.Show("Syötä validi numero rivien määrälle.");
            }
        }

        private void TyhjennaButton_Click(object sender, RoutedEventArgs e)
        {
            arvotutRivit.Clear();
            ArvotutRivitTextBlock.Text = string.Empty;
        }

        private void ViikonArvontaButton_Click(object sender, RoutedEventArgs e)
        {
            arvotutRivit = ArvoRivit("Lotto", 1);
            TulostaRivit(arvotutRivit);
        }

        private void TarkastaButton_Click(object sender, RoutedEventArgs e)
        {
            if (arvotutRivit.Count == 0)
            {
                MessageBox.Show("Arvo ensin viikon lottorivit.");
                return;
            }

            List<int> voittorivi = ArvoRivi("Lotto");
            int oikein = TarkistaOikeatNumerot(voittorivi, arvotutRivit);

            MessageBox.Show($"Voittorivi: {string.Join(", ", voittorivi)}\nOikein: {oikein}");
        }

        private List<List<int>> ArvoRivit(string peli, int maara)
        {
            List<List<int>> tulokset = new List<List<int>>();
            for (int i = 0; i < maara; i++)
            {
                List<int> rivi = ArvoRivi(peli);
                tulokset.Add(rivi);
            }
            return tulokset;
        }

        private List<int> ArvoRivi(string peli)
        {
            int numeroita = 0;
            int ylinNumero = 0;

            switch (peli)
            {
                case "Lotto":
                    numeroita = 7;
                    ylinNumero = 40;
                    break;
                case "Viking Lotto":
                    numeroita = 6;
                    ylinNumero = 48;
                    break;
                case "Eurojackpot":
                    numeroita = 5;
                    ylinNumero = 50;
                    break;
                default:
                    break;
            }

            HashSet<int> rivi = new HashSet<int>();

            while (rivi.Count < numeroita)
            {
                int arvottuNumero = random.Next(1, ylinNumero + 1);
                rivi.Add(arvottuNumero);
            }

            return rivi.OrderBy(x => x).ToList();
        }

        private int TarkistaOikeatNumerot(List<int> voittorivi, List<List<int>> arvotutRivit)
        {
            int oikein = 0;

            foreach (var rivi in arvotutRivit)
            {
                oikein += rivi.Intersect(voittorivi).Count();
            }

            return oikein;
        }

        private void TulostaRivit(List<List<int>> tulokset)
        {
            foreach (var rivi in tulokset)
            {
                ArvotutRivitTextBlock.Text += string.Join(", ", rivi) + "\n";
            }
        }
    }
}
