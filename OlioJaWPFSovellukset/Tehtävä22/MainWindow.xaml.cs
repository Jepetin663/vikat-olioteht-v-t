using System;
using System.Windows;

namespace IkkunaLaskuri
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaskeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double leveys = double.Parse(LeveysTextBox.Text);
                double korkeus = double.Parse(KorkeusTextBox.Text);
                double karmiLeveys = double.Parse(KarmiTextBox.Text);

                double lasinPintaAla = LasinPintaAla(leveys, korkeus);
                double karminPiiri = KarminPiiri(leveys, korkeus, karmiLeveys);
                double ikkunanPintaAla = IkkunanPintaAla(leveys, korkeus);

                MessageBox.Show($"Karmin piiri: {karminPiiri:F2} cm\nLasin pinta-ala: {lasinPintaAla:F2} cm^2\nIkkunan pinta-ala: {ikkunanPintaAla:F2} cm^2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Syötä validit numerot.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe: {ex.Message}");
            }
        }

        private double LasinPintaAla(double leveys, double korkeus)
        {
            return leveys * korkeus;
        }

        private double KarminPiiri(double leveys, double korkeus, double karmiLeveys)
        {
            return 2 * (leveys + korkeus) + 4 * karmiLeveys;
        }

        private double IkkunanPintaAla(double leveys, double korkeus)
        {
            return LasinPintaAla(leveys, korkeus) + leveys * 2 * korkeus;
        }
    }
}
