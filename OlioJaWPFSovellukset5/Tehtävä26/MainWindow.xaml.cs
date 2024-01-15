using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MuistilistaSovellus
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> tehtavat = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            MuistilistaListBox.ItemsSource = tehtavat;

            // Lataa tallennetut tehtävät tiedostosta
            LataaTehtavat();
        }

        private void LisaaButton_Click(object sender, RoutedEventArgs e)
        {
            string tehtava = TehtavaTextBox.Text;

            if (!string.IsNullOrEmpty(tehtava))
            {
                tehtavat.Add(tehtava);
                TehtavaTextBox.Text = string.Empty;

                // Tallenna tehtävät tiedostoon
                TallennaTehtavat();
            }
        }

        private void TyhjennaButton_Click(object sender, RoutedEventArgs e)
        {
            tehtavat.Clear();

            // Tallenna tehtävätiedostoon
            TallennaTehtavat();
        }

        private void TallennaTehtavat()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("tehtavat.txt"))
                {
                    foreach (string tehtava in tehtavat)
                    {
                        writer.WriteLine(tehtava);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tallennusvirhe: {ex.Message}");
            }
        }

        private void LataaTehtavat()
        {
            try
            {
                if (File.Exists("tehtavat.txt"))
                {
                    using (StreamReader reader = new StreamReader("tehtavat.txt"))
                    {
                        while (!reader.EndOfStream)
                        {
                            string tehtava = reader.ReadLine();
                            tehtavat.Add(tehtava);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Latausvirhe: {ex.Message}");
            }
        }
    }
}
