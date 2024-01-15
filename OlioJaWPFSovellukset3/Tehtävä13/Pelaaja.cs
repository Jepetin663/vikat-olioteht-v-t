using System;

namespace LiigaJoukkueSovellus
{
    public class Pelaaja
    {
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public int PelaajaNumero { get; set; }

        public Pelaaja(string etunimi, string sukunimi, int pelaajaNumero)
        {
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            PelaajaNumero = pelaajaNumero;
        }

        public override string ToString()
        {
            return $"Pelaaja: {Etunimi} {Sukunimi}, Numero: {PelaajaNumero}";
        }
    }
}
