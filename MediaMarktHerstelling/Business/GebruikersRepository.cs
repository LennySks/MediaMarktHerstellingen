using System.Collections.Generic;
using System.Linq;

namespace MediaMarktHerstelling.Business
{
    internal class GebruikersRepository
    {
        internal static List<Gebruiker> Items { get; private set; } = new List<Gebruiker>();

        internal static Gebruiker GetItem(int id)
        {
            return Items.Find(l => l.Id == id);
        }

        internal static int GetNextId()
        {
            return Items.Count == 0 ? 1 : Items.Max(l => l.Id) + 1;
        }

        internal static void AddItem(Gebruiker lid)
        {
            Items.Add(lid);
            Persistence.Controller.AddGebruiker(lid);
        }

        //internal static void Items
        internal static void Load(List<Gebruiker> items)
        {
            if (items != null)
                Items = items;
            else
                Items = new List<Gebruiker>();
        }
    }
}