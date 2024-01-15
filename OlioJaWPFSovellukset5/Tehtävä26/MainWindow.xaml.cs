using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MuistilistaSovellus
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Tehtava> tehtavat = new ObservableCollection<Tehtava>();

        public MainWindow()
        {
            InitializeComponent();
            MuistilistaListBox.ItemsSource = tehtavat;

            LataaTehtavat();
        }

        private void LisaaButton_Click(object sender, RoutedEventArgs e)
        {
            string tehtavanNimi = TehtavaTextBox.Text;
            string prioriteetti = ((ComboBoxItem)PrioriteettiComboBox.SelectedItem)?.Content.ToString();
            DateTime? deadline = DeadlineDatePicker.SelectedDate;

            if (!string.IsNullOrEmpty(tehtavanNimi) && prioriteetti != null)
            {
                Tehtava uusiTehtava = new Tehtava
                {
                    Nimi = tehtavanNimi,
                    Prioriteetti = prioriteetti,
                    Deadline = deadline
                };

                tehtavat.Add(uusiTehtava);
                TehtavaTextBox.Text = string.Empty;

                TallennaTehtavat();
            }
        }

        private void TyhjennaButton_Click(object sender, RoutedEventArgs e)
        {
            tehtavat.Clear();

            TallennaTehtavat();
        }

        private void TallennaTehtavat()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("tehtavat.txt"))
                {
                    foreach (Tehtava tehtava in tehtavat)
                    {
                        writer.WriteLine($"{tehtava.Nimi},{tehtava.Prioriteetti},{tehtava.Deadline}");
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
                            string[] tehtavaTiedot = reader.ReadLine().Split(',');
                            string nimi = tehtavaTiedot[0];
                            string prioriteetti = tehtavaTiedot[1];
                            DateTime? deadline = string.IsNullOrEmpty(tehtavaTiedot[2]) ? (DateTime?)null : DateTime.Parse(tehtavaTiedot[2]);

                            Tehtava tehtava = new Tehtava
                            {
                                Nimi = nimi,
                                Prioriteetti = prioriteetti,
                                Deadline = deadline
                            };

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

        private void TehtavaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Tehtava
    {
        public string Nimi { get; set; }
        public string Prioriteetti { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
