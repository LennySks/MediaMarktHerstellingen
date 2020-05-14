using System;
using System.Collections.Generic;

namespace MediaMarktHerstelling
{
    public class Klant : Entity
    {
        public Klant(string naam, string telefoonnummer, int id) : base(id)
        {
            Naam = naam;
            Telefoonnummer = telefoonnummer;
        }

        public string Naam { get; set; }
        public string Telefoonnummer { get; set; }

        public List<Herstelling> Herstelling { get; set; } = new List<Herstelling>();

        public Herstelling NieuweHerstelling(double kostprijs, DateTime datumbinnen, DateTime datumklaar, int toestelid,
            int klantid)
        {
            var herstelling = new Herstelling(kostprijs, datumbinnen, datumklaar, toestelid, klantid);
            Herstelling.Add(herstelling);
            return herstelling;
        }

        internal void DeleteHerstelling(int toestelid)
        {
            var herstelling = Herstelling.Find(e => e.ToestelId == toestelid && e.KlantId == Id);
            Herstelling.Remove(herstelling);
        }

        internal void UpdateHerstelling(DateTime datumbinnen, double kostprijs, DateTime datumklaar, int toestelid,
            int klantid)
        {
            var herstelling = Herstelling.Find(e => e.ToestelId == toestelid && e.KlantId == Id);
            if (!(herstelling == null))
            {
                herstelling.Kostprijs = kostprijs;
                herstelling.ToestelId = toestelid;
                herstelling.DatumBinnen = datumbinnen;
                herstelling.DatumKlaar = datumklaar;
            }
        }

        internal void Load(List<Herstelling> herstelling)
        {
            Herstelling = herstelling;
        }

        public void Toestelklaar(Herstelling herstelling)
        {
            DateTime klaar;
            if (!herstelling.isHersteld) herstelling.isHersteld = true;
        }

        public double GemiddeldeWachtijd()
        {
            double totaal = 0;
            var aantal = Herstelling.Count;
            foreach (var h in Herstelling) totaal += (h.DatumKlaar - h.DatumBinnen).TotalHours;
            return totaal;
        }

        public override string ToString()
        {
            string omschrijving = "De gemiddelde wachtijd bedraagt " + Herstelling ;
            return omschrijving;
        }

    }
}