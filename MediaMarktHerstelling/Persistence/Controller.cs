using System.Collections.Generic;
using System.Configuration;
using MediaMarktHerstelling.Business;

namespace MediaMarktHerstelling.Persistence
{
    public class Controller
    {
        private static string _connectionstring = "";

        private static string ConnectionString
        {
            get
            {
                if (_connectionstring == "")
                    _connectionstring = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

                return _connectionstring;
            }
        }


        internal static List<Gebruiker> GetGebruikers()
        {
            var mapper = new GebruikerMapper(ConnectionString);
            return mapper.GetGebruikersFromDb();
        }

        internal static void AddGebruiker(Gebruiker gebruiker)
        {
            var mapper = new GebruikerMapper(ConnectionString);
            mapper.AddGebruikerToDb(gebruiker);
        }


        #region Herstelling

        internal static List<Herstelling> GetAlleHerstellingen(int klantid)
        {
            var hm = new HerstellingMapper(ConnectionString);
            return hm.GetHerstellingenFromDB(klantid);
        }

        internal static void AddHerstelling(Herstelling herstelling)
        {
            var hm = new HerstellingMapper(ConnectionString);
            hm.AddHerstellingToDB(herstelling);
        }

        internal static void DeleteHerstelling(Herstelling herstelling)
        {
            var hm = new HerstellingMapper(ConnectionString);
            hm.DeleteHerstellingFromDB(herstelling);
        }

        internal static void UpdateHerstelling(Herstelling herstelling)
        {
            var hm = new HerstellingMapper(ConnectionString);
            hm.UpdateHerstellingInDB(herstelling);
        }

        #endregion

        #region Klant

        internal static List<Klant> GetAlleKlanten()
        {
            var km = new KlantMapper(ConnectionString);
            return km.GetKlantenFromDB();
        }

        internal static void AddKlant(Klant klant)
        {
            var km = new KlantMapper(ConnectionString);
            km.AddKlantToDB(klant);
        }

        internal static void DeleteKlant(Klant klant)
        {
            var km = new KlantMapper(ConnectionString);
            km.DeleteKlantFromDB(klant);
        }

        internal static void UpdateKlant(Klant klant)
        {
            var km = new KlantMapper(ConnectionString);
            km.UpdateKlantInDB(klant);
        }

        #endregion

        #region Toestel

        internal static List<Toestel> GetAlleToestellen()
        {
            var tm = new ToestelMapper(ConnectionString);
            return tm.GetToestelFromDB();
        }

        internal static void AddToestel(Toestel toestel)
        {
            var tm = new ToestelMapper(ConnectionString);
            tm.AddToestelToDB(toestel);
        }

        internal static void DeleteToestel(Toestel toestel)
        {
            var km = new ToestelMapper(ConnectionString);
            km.DeleteToestelInDB(toestel);
        }

        internal static void UpdateToestel(Toestel toestel)
        {
            var tm = new ToestelMapper(ConnectionString);
            tm.UpdateToestelInDB(toestel);
        }

        #endregion
    }
}