using System.Collections.Generic;
using System.Linq;

namespace MediaMarktHerstelling
{
    internal static class KlantRepository
    {
        internal static List<Klant> Items { get; private set; } = new List<Klant>();

        internal static void AddItem(Klant klant)
        {
            Items.Add(klant);
            Persistence.Controller.AddKlant(klant);
        }

        internal static Klant GetItem(int id)
        {
            return Items.Find(k => k.Id == id);
        }

        internal static int GetNextId()
        {
            var next_id = 0;
            foreach (var k in Items)
                if (k.Id > next_id)
                    next_id = k.Id;
            return next_id + 1;
        }

        internal static Klant FindItem(string naam)
        {
            foreach (var k in Items)
                if (k.Naam == naam)
                    return k;
            return null;
        }

        internal static void DeleteItem(int id)
        {
            var klant = GetItem(id);
            Items.Remove(klant);
            Persistence.Controller.DeleteKlant(klant);
        }

        internal static void Load(List<Klant> klanten)
        {
            if (klanten == null)
                Items = new List<Klant>();
            else
                Items = klanten;
        }

        internal static Klant UpdateItem(Klant t)
        {
            var item = Items.First(d => d.Id == t.Id);
            item.Naam = t.Naam;
            item.Telefoonnummer = t.Telefoonnummer;
            item.Id = t.Id;
            Persistence.Controller.UpdateKlant(item);
            return GetItem(item.Id);
        }
    }
}