using System;

namespace MediaMarktHerstelling.Business
{
    public class Gebruiker : Entity
    {
        public Gebruiker(int id, string gebruikersnaam, string paswoord) : base(id)
        {
            Gebruikersnaam = gebruikersnaam;
            if (!IsComplexPW(paswoord))

                throw new ArgumentException("Paswoord voldoet niet aan de vereisten");
            Paswoord = paswoord;
        }

        public string Gebruikersnaam { get; }
        public string Paswoord { get; }

        private bool IsComplexPW(string pw)
        {
            return true;
        }

        public bool Aanmelden(string paswoord)
        {
            return Paswoord.Equals(paswoord);
        }
    }
}