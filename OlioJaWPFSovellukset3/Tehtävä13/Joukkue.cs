using System;
using System.Collections.Generic;

namespace LiigaJoukkueSovellus
{
    public class Joukkue
    {
        public string Nimi { get; set; }
        public string Kotikaupunki { get; set; }
        private Dictionary<int, Pelaaja> Pelaajat { get; set; }

        public Joukkue(string nimi, string kotikaupunki)
        {
            Nimi = nimi;
            Kotikaupunki = kotikaupunki;
            Pelaajat = new Dictionary<int, Pelaaja>();
        }

        public Pelaaja HaePelaaja(int pelaajaNumero)
        {
            if (Pelaajat.ContainsKey(pelaajaNumero))
            {
                return Pelaajat[pelaajaNumero];
            }
            else
            {
                throw new KeyNotFoundException($"Pelaajaa numerolla {pelaajaNumero} ei löytynyt.");
            }
        }

        public void LisaaPelaaja(Pelaaja pelaaja)
        {
            try
            {
                Pelaajat.Add(pelaaja.PelaajaNumero, pelaaja);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Pelaaja numerolla {pelaaja.PelaajaNumero} on jo lisätty.", ex);
            }
        }

        public void PoistaPelaaja(int pelaajaNumero)
        {
            if (Pelaajat.ContainsKey(pelaajaNumero))
            {
                Pelaajat.Remove(pelaajaNumero);
            }
            else
            {
                throw new KeyNotFoundException($"Pelaajaa numerolla {pelaajaNumero} ei löytynyt.");
            }
        }

        public List<Pelaaja> HaePelaajat()
        {
            return new List<Pelaaja>(Pelaajat.Values);
        }
    }
}
