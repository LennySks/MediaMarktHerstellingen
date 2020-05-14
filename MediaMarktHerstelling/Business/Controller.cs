using System;
using System.Collections.Generic;
using System.Linq;
using MediaMarktHerstelling.Business;

namespace MediaMarktHerstelling
{
    public class Controller
    {
        private static bool _loaded;

        public Controller()
        {
            if (!_loaded)
            {
                var _herstellingen = new List<Herstelling>();
                GebruikersRepository.Load(Persistence.Controller.GetGebruikers());
                KlantRepository.Load(Persistence.Controller.GetAlleKlanten());
                ToestelRepository.Load(Persistence.Controller.GetAlleToestellen());
                foreach (var klant in KlantRepository.Items)
                    klant.Herstelling = Persistence.Controller.GetAlleHerstellingen(klant.Id);

                _loaded = true;
            }
        }

        public Gebruiker CurrentUser { get; private set; }

        public bool Aanmelden(string gebruikersnaam, string paswoord)
        {
            var gebruikers = GebruikersRepository.Items;

            var gebruiker = gebruikers.Find(x =>
                x.Gebruikersnaam.Equals(gebruikersnaam, StringComparison.CurrentCultureIgnoreCase));
            if (gebruiker == null) return false;
            var aangemeld = gebruiker.Aanmelden(paswoord);
            if (aangemeld) CurrentUser = gebruiker;
            return aangemeld;
        }

        public void Afmelden()
        {
            CurrentUser = null;
        }

        public Gebruiker Registreer(string gebruikersnaam, string paswoord)
        {
            var gList = GebruikersRepository.Items;

            var gebruiker = gList.Find(g => g.Gebruikersnaam.Equals(gebruikersnaam,
                StringComparison.CurrentCultureIgnoreCase));

            if (gebruiker != null) throw new ArgumentException("Deze gebruikersnaam bestaat reeds");

            var id = GebruikersRepository.GetNextId();

            gebruiker = new Gebruiker(id, gebruikersnaam, paswoord);

            GebruikersRepository.AddItem(gebruiker);

            return gebruiker;
        }

        #region Extra's

        public List<Herstelling> GetAlleHerstellingen()
        {
            var temp = new List<Herstelling>();
            foreach (var klant in GetAlleKlanten()) temp.AddRange(klant.Herstelling);
            return temp;
        }

        #endregion


        #region Herstelling

        public Herstelling NieuweHerstelling(double kostprijs, DateTime datumbinnen, DateTime datumklaar, int toestelid,
            int klantid)
        {

            var _klant = KlantRepository.GetItem(klantid);

            if (GetAlleHerstellingen().Any(x => x.ToestelId == toestelid))
            {
                throw new Exception("heeft al een herstelling");
            }
            else
            {
                var _herstelling = _klant.NieuweHerstelling(kostprijs, datumbinnen, datumklaar, toestelid, klantid);
                Persistence.Controller.AddHerstelling(_herstelling);
                return _herstelling;
            }
            
        }

        public void DeleteHerstelling(int klantid, int toestelid)
        {
            var klant = KlantRepository.GetItem(klantid);
            var toDelete = klant.Herstelling.First(y => y.KlantId == klantid && y.ToestelId == toestelid);
            klant.Herstelling.Remove(toDelete);
            Persistence.Controller.DeleteHerstelling(toDelete);
        }

        public void UpdateHerstelling(DateTime datumbinnen, double kostprijs, DateTime datumklaar, int toestelid,
            int klantid)
        {
            var klant = KlantRepository.GetItem(klantid);
            klant.UpdateHerstelling(datumbinnen, kostprijs, datumklaar, toestelid, klantid);
            Persistence.Controller.UpdateHerstelling(klant.Herstelling.First(x =>
                x.KlantId == klantid && x.ToestelId == toestelid));
        }

        public List<Herstelling> GetHerstellingFromKlantId(int id)
        {
            return Persistence.Controller.GetAlleHerstellingen(id);
        }

        #endregion

        #region Klant

        public Klant NieuweKlant(string naam, string telefoonummer)
        {
            var _klant = new Klant(naam, telefoonummer, KlantRepository.GetNextId());
            KlantRepository.AddItem(_klant);
            return _klant;
        }

        public Klant GetKlant(int id)
        {
            return KlantRepository.GetItem(id);
        }

        public List<Klant> GetAlleKlanten()
        {
            return KlantRepository.Items;
        }

        public Klant UpdateKlant(int id, string nieuweNaam, string nieuweTel)
        {
            var toUpdate = KlantRepository.GetItem(id);
            toUpdate.Naam = nieuweNaam;
            toUpdate.Telefoonnummer = nieuweTel;

            return KlantRepository.UpdateItem(toUpdate);
        }

        public void DeleteKlant(int id)
        {
            if (KlantRepository.GetItem(id) != null)
                KlantRepository.DeleteItem(id);
            else
                throw new Exception("Klant niet gevonden;");
        }

        #endregion

        #region Toestel

        public Toestel NieuweToestel(string omschrijving)
        {
            var _id = ToestelRepository.GetNextId();
            var _toestel = new Toestel(_id, omschrijving);
            ToestelRepository.AddItem(_toestel);
            return _toestel;
        }

        public List<Toestel> GetAlleToestellen()
        {
            return ToestelRepository.Items;
        }

        public Toestel GetToestel(int id)
        {
            return ToestelRepository.FindItem(id);
        }

        public Toestel UpdateToestel(int toestelid, string nieuweOmschrijving)
        {
            var toUpdate = ToestelRepository.GetItem(toestelid);
            toUpdate.Omschrijving = nieuweOmschrijving;

            return ToestelRepository.UpdateItem(toUpdate);
        }

        public void DeleteToestel(int id)
        {
            if (ToestelRepository.GetItem(id) != null)
                ToestelRepository.DeleteItem(id);
            else
                throw new Exception("Toestel niet gevonden");
        }

        #endregion
    }
}