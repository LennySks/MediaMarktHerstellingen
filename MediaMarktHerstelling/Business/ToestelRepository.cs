using System.Collections.Generic;

namespace MediaMarktHerstelling
{
    internal static class ToestelRepository
    {
        internal static List<Toestel> Items { get; private set; }

        internal static void AddItem(Toestel toestel)
        {
            Items.Add(toestel);
            Persistence.Controller.AddToestel(toestel);
        }

        internal static Toestel GetItem(int id)
        {
            return Items.Find(s => s.Id == id);
        }

        internal static int GetNextId()
        {
            var next_id = 0;
            foreach (var k in Items)
                if (k.Id > next_id)
                    next_id = k.Id;
            return next_id + 1;
        }

        internal static Toestel FindItem(int id)
        {
            foreach (var t in Items)
                if (t.Id == id)
                    return t;
            return null;
        }

        internal static void DeleteItem(int id)
        {
            var toestel = GetItem(id);
            Items.Remove(toestel);
            Persistence.Controller.DeleteToestel(toestel);
        }

        internal static void Load(List<Toestel> toestel)
        {
            if (toestel == null)
                Items = new List<Toestel>();
            else
                Items = toestel;
        }

        internal static Toestel UpdateItem(Toestel toestel)
        {
            Persistence.Controller.UpdateToestel(toestel);
            return GetItem(toestel.Id);
        }
    }
}